using iTextSharp.text;
using iTextSharp.text.pdf;
using NWAT.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Klasse um die Erfüllung der Kriterien für ALLE Produkte eines Projekts in einer PDF Datei zu zeigen
/// </summary>
/// Erstellt von Adrian Glasnek

namespace NWAT.Printer
{
    class FulfillmentForEveryProduct
    {
         private readonly int maxProductsInTable = 5;

        Document FulfillmentPrinter = new Document(iTextSharp.text.PageSize.A4.Rotate());       //Eigentliches Dokument erstellen vom typ Document
        SaveFileDialog SfdFulfillment = new SaveFileDialog();       //Objekt vom Typ SaveFileDialog
        private Project _projectid;
        private Product _productid;
        private Fulfillment _fulfilled;

        //Benötigte Properties für Project, Product und Fulfillment
        public Project Project
        {
            get { return _projectid; }
            set { _projectid = value; }
        }

        public Product Product
        {
            get { return _productid; }
            set { _productid = value; }
        }

        public Fulfillment Fulfillment
        {
            get { return _fulfilled; }
            set { _fulfilled = value; }
        }

   


        private List<Fulfillment> _fufiList;

        public List<Fulfillment> FufiList
        {
            get { return _fufiList; }
            set { _fufiList = value; }
        }



        private ProjectCriterionController _projectCriterionController;
        public ProjectCriterionController ProjCritContr
        {
            get { return _projectCriterionController; }
            set { _projectCriterionController = value; }
        }

        private ProductController _projProduct;
        public ProductController ProjProduct
        {
            get { return _projProduct; }
            set { _projProduct = value; }
        }

        private FulfillmentController _fulfillmentController;
        public FulfillmentController FulFillContr
        {
            get { return _fulfillmentController; }
            set { _fulfillmentController = value; }
        }


        private List<ProjectCriterion> _sortedProjectCriterionStructure;

        public List<ProjectCriterion> SortedProjectCriterionStructure
        {
            get { return _sortedProjectCriterionStructure; }
            set { _sortedProjectCriterionStructure = value; }
        }

        private List<ProjectProduct> _allProductsForThisProject;

        public List<ProjectProduct> AllProductsForThisProject
        {
            get { return _allProductsForThisProject; }
            set { _allProductsForThisProject = value; }
        }
        

        //Konstruktor
        public FulfillmentForEveryProduct(int projectId)
        {
            this.ProjCritContr = new ProjectCriterionController();
            ProjectController projCont = new ProjectController();
            this.Project = projCont.GetProjectById(projectId);
          
            //Übergebene Liste von Methode "GetSortedCriterionStructure()" in Liste sortedProjectCriterionStructure schreiben
            this.SortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);
        }


        /// <summary>
        /// Methode um Pdf erstellen etc.
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public void CreateFulfillmentForEveryProductPdf()
        {
           
            ProjectProductController projprodContr = new ProjectProductController();
            this.AllProductsForThisProject = projprodContr.GetAllProjectProductsForOneProject(this.Project.Project_Id);
            List<ProjectCriterion> baseCriterions = this.ProjCritContr.GetBaseProjectCriterions(this.Project.Project_Id); //Get all base Criterions

            SfdFulfillment.Filter = "Pdf File |*.pdf";
            if (SfdFulfillment.ShowDialog() == DialogResult.OK)
            {
                
                FulfillmentPrinter.SetMargins(50, 200, 50, 125); //Seitenränder definieren
                try //try catch um Fehler abzufangen wenn eine gleichnamige PDF noch geöffnet ist
                {
                    PdfWriter writer = PdfWriter.GetInstance(FulfillmentPrinter, new FileStream(SfdFulfillment.FileName, FileMode.Create));
                    writer.PageEvent = new PdfPageEvents();
                }
                catch (Exception) { throw new Exception("Bitte schließen Sie das geöffnete Pdf!"); }

                //Dokument öffnen um es bearbeiten zu können
                FulfillmentPrinter.Open();

                ////int der die Anzahl der festen Spalten und die variable Anzahl der Produkte enthält
                int countProducts = AllProductsForThisProject.Count();

                int prodCounter = 1;
                //Zählt wieviele Produkte in der Datenbank liegen und schreibt dementsprechend viele Spalten auf das Pdf
                foreach (ProjectProduct Prod in AllProductsForThisProject)
                {
                    //Paragraph um Namen der Produkte mit den Abkürzungen in der Tabelle verbinden zu können
                    //Font für die Ausgabe der Produktlegende
                    Paragraph productName = new Paragraph();
                    Font prodNameFont = FontFactory.GetFont("Arial", 9);
                    productName.Font = prodNameFont;
                    productName.Add("Prd. " + prodCounter.ToString() + "     -     " + Prod.Product.Name+ "\n");
                    FulfillmentPrinter.Add(productName);   //Produktname der vergliechenen Produkte auf dem Dokument anzeige

                    prodCounter++;
                }
                 

                //Bei einer Anzahl von mehr als 5 Produkten innerhalb eines NWA-Projekts werden jeweils weitere Tabellen mit den restlichen Produkten generiert
                List<List<ProjectProduct>> tableLists = GetProdTableLists();
                int firstProdId = 1;
                int tableNumber = 1;
                foreach (List<ProjectProduct> prodsInTable in tableLists)
                {
                    
                    PdfPTable CritTable = GetNewProductTable(prodsInTable, firstProdId, tableNumber);
                    
                    //Methodenaufruf
                    PrintCriterionStructure(ref CritTable, prodsInTable);

                    //Tabelle zum Dokument Adden
                    FulfillmentPrinter.Add(CritTable);
    
                    firstProdId += this.maxProductsInTable;
                    tableNumber++;
                }

                //Close Dokument - Bearbeitung Beenden
                FulfillmentPrinter.Close();

                //Aufrufen der Hilfsmethode (aus Klasse CriterionStructurePrinter)- Seitenzahl und den Projektnamen auf Pdf     
                GetPageNumber(SfdFulfillment, 800);

                //Erfolgsmeldung
                MessageBox.Show("Pdf erfolgreich erstellt!");

                //PDf wird automatisch geöffnet nach der erfolgreichen Speicherung
                System.Diagnostics.Process.Start(SfdFulfillment.FileName);

            }
        }

        //Methode um das Grundgerüst der Tabellen zu erstellen
        private PdfPTable GetNewProductTable(List<ProjectProduct> productsForThisTable, int firstProdId, int tableNumber)
        {

            ProjectProductController projprodContr = new ProjectProductController();
            int numberOfallProductsForThisProject = projprodContr.GetAllProjectProductsForOneProject(this.Project.Project_Id).Count;
            int numOfProdsInThisTable = productsForThisTable.Count;

            //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)        
            Font arialBold = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
            Font products = FontFactory.GetFont("Arial_BOLD", 7, Font.NORMAL);
            //Erstellen einer Pdf Tabelle in der die Daten aus der Datenbank ausgegeben werden

            //Erstellen der PdfTable
            PdfPTable CritTable = new PdfPTable(numOfProdsInThisTable + 3);

           
            //int der die Anzahl der festen Spalten und die variable Anzahl der Produkte enthält
            int numberOfCells = numOfProdsInThisTable + 3;

            // Je nach Anzahl der Produkte in der Datenbank wir die relative Spaltenbreite gesetzt 
            if (numberOfCells == 3) { float[] widths = { 20f, 2f, 2f, }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 4) { float[] widths = { 20f, 2f, 1f, 3f, }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 5) { float[] widths = { 20, 2f, 2f, 3f, 3f }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 6) { float[] widths = { 20, 2f, 2f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 7) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 8) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 9) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
               
            // Die Grenzen der Tabelle unsichtbar machen
            CritTable.DefaultCell.Border = 1;
            //Anzeigen der ersten Zeilen als Überschrift auf jeder Seite des Dokuments
            CritTable.HeaderRows = 1;                     
            //Platz zwischen Produktlegende und der Tabelle
            CritTable.SpacingBefore = 20f;
            
            //if-Abfrage für die, je nach Anzahl der Produkte, korrekte "Überschrift der Tabelle"
            if (numberOfallProductsForThisProject > 4)
            {
                CritTable.AddCell(new Paragraph(String.Format("Tabellarische Übersicht aller Produkte   [{0}. Teil]", tableNumber), arialBold));
            }
            else
            {
                CritTable.AddCell(new Paragraph("Tabellarische Übersicht aller Produkte", arialBold));
            }
            //Leere Zelle sorgt für Abstand zwischen Header und Erfüllungen
            CritTable.AddCell(new Paragraph(" "));
            CritTable.AddCell(new Paragraph("*"));

            foreach (ProjectProduct Prods in productsForThisTable)
            {
                string prodHeader = "Prd." + firstProdId.ToString();
                CritTable.AddCell(new Paragraph(prodHeader, products));
                firstProdId++;
            }

            //Ausrichtung 0, d.h. links
            CritTable.HorizontalAlignment = 0;
            //Totale Breite der "Tabelle"
            CritTable.TotalWidth = 700f;
            //"Fixen" der Width
            CritTable.LockedWidth = true;

            return CritTable;
        }

        /// <summary>
        /// Methode die je nach Anzahl von Produkten mehrere Tabellen generiert
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public List<List<ProjectProduct>> GetProdTableLists()
        {

            List<List<ProjectProduct>> tableLists = new List<List<ProjectProduct>>();
            int numberOfTables = 1;
            if (this.AllProductsForThisProject.Count > this.maxProductsInTable)
            {
                numberOfTables = (this.AllProductsForThisProject.Count / this.maxProductsInTable) + 1;

            }
            List<ProjectProduct> tempAnalysedProd = new List<ProjectProduct>();
            int tableProdCounter = 1;
            foreach (ProjectProduct analysedProd in this.AllProductsForThisProject)
            {
                tempAnalysedProd.Add(analysedProd);
                if (tableProdCounter % this.maxProductsInTable == 0)
                {
                    tableLists.Add(tempAnalysedProd);
                    tableProdCounter = 1;
                    tempAnalysedProd = new List<ProjectProduct>();
                }
                tableProdCounter++;
            }
            tableLists.Add(tempAnalysedProd);
            return tableLists;
        }

        /// <summary>
        /// Eigentliche Print Methode um Pdf zu befüllen
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        private void PrintCriterionStructure(ref PdfPTable CritTable, List<ProjectProduct> productsInTable)
        {
            FulfillmentController fufiCont = new FulfillmentController();
            List<Fulfillment> fufiList = fufiCont.GetAllFulfillmentsForOneProject(this.Project.Project_Id);

            //Übergebene Liste von Methode "GetSortedCriterionStructure()" in Liste sortedProjectCriterionStructure schreiben
            List<ProjectCriterion> sortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);

            // Generische Liste - Dictionary Wertepaar vom Typ int - Schlüssel und Wert 
            Dictionary<int, int> enumerations = new Dictionary<int, int>() { { 1, 0 } };
        
                             
            //Foreach-Schleife druckt sortierte Kriterien auf das Pdf Dokument
            foreach (ProjectCriterion projectCriterion in SortedProjectCriterionStructure)
            {
                //Definieren der intend Variable um die richtige "Einrückung" auf dem Pdf Dokument erzielen zu können
                int layer = projectCriterion.Layer_Depth;
                int factor = 25;
                int intend;
                intend = layer * factor;

                //Aufzählunszahlen für die Kriterienstruktur in einen string schreiben
                string enumeration = GetEnumerationForCriterion(ref enumerations, layer);

                //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                Font CritStructFont = FontFactory.GetFont("Arial", 10);
                Font numbers = FontFactory.GetFont("Arial_BOLD", 7, Font.NORMAL);

                //Paragraph der die Zellen befüllt
                string CritsEnumeration = "[" + enumeration + "]" + " " + projectCriterion.Criterion.Description.ToString();

                Paragraph para = new Paragraph(CritsEnumeration, CritStructFont);
                //Einrückungsfaktor, das zugehörige Kriterien untereinander stehen
                para.IndentationLeft = intend;
                //Neue Tabellenzelle in der die Kriterienbeschreibung reingeschrieben wird
                PdfPCell Crits = new PdfPCell();
                //Der Zelle den Paragraphen übergeben
                Crits.AddElement(para);
                //Anzeigen von Linien im Pdf
                Crits.Border = 1;                   

                //Die Kriterienstruktur den zellen hinzufügen
                CritTable.AddCell(Crits);
                CritTable.AddCell(" ");
                if (projectCriterion.Weighting_Cardinal <= 0)
                {
                    CritTable.AddCell(new Paragraph("-", CritStructFont));
                }
                else
                {
                    CritTable.AddCell(new Paragraph("x", CritStructFont));
                }



                foreach (ProjectProduct projprod in productsInTable)
                {
                    
                    //try catch Anweisung um Fehler abzufangen. Fehler: Für das Produkt sind keine oder nicht alle Erfülungen in der DB hinterlegt
                    try
                    {
                        //Abfrage der Erfüllungen
                        Fulfillment fulfillForThisProdAndThisCrit = fufiList.Single(
                                fufi => fufi.Project_Id == projectCriterion.Project_Id &&
                                        fufi.Product_Id == projprod.Product_Id &&
                                        fufi.Criterion_Id == projectCriterion.Criterion.Criterion_Id);

                        //Wenn ein Kriterium erfüllt ist wird ein x gesetzt ansonsten ein -
                        if (fulfillForThisProdAndThisCrit.Fulfilled == true)
                        {
                            CritTable.AddCell(new Paragraph("x", CritStructFont));
                        }
                        else
                        {
                            CritTable.AddCell(new Paragraph("-", CritStructFont));
                        }
                    }

                    catch
                    {
                        throw new ApplicationException("Warnung!\n Nicht für alle Produkte des Projekts sind Erfüllungen hinterlegt! Bitte überprüfen Sie Ihre Eingaben! ");
                    }
                }         
            }
            CritTable.SpacingAfter = 100f; //Abstand zur nachfolgenden Tabelle
        }

        /// <summary>
        /// Methode um Kriterien eine Nummerierung zu geben
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public string GetEnumerationForCriterion(ref Dictionary<int, int> enumerations, int layer)
        {
            int lastLayer = enumerations.Keys.ToList().Max();

            string enumerationAsString = "";

            if (layer == lastLayer)
            {
                enumerations[layer] += 1;
            }
            if (layer > lastLayer)
            {
                lastLayer += 1;
                enumerations[lastLayer] = 1;
            }
            if (layer < lastLayer)
            {
                for (int deletingLayer = layer + 1; deletingLayer <= lastLayer; deletingLayer++)
                {
                    enumerations.Remove(deletingLayer);
                }
                enumerations[layer] += 1;
                lastLayer = layer;
            }

            for (int i = 1; i <= lastLayer; i++)
            {
                enumerationAsString += enumerations[i] + ".";
            }
            return enumerationAsString;
        }

        /// <summary>
        /// Methode um Nummern und Projektnamen auf Pdf zu drucken
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public void GetPageNumber(SaveFileDialog save, int pageNumberBottomPosition)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(save.FileName);
                Font BlackFont = FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK);
                using (MemoryStream stream = new MemoryStream())
                {
                    PdfReader reader = new PdfReader(bytes);
                    using (PdfStamper stamper = new PdfStamper(reader, stream))
                    {
                        int pages = reader.NumberOfPages;
                        //Schleife um zu gewährleisten das jede Seite des Dokuments berücksichtigt wird
                        for (int i = 1; i <= pages; i++)
                        {
                            //Seitenzahl
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), BlackFont), pageNumberBottomPosition, 15f, 0);
                            //Projekt Name
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(Project.Name.ToString(), BlackFont), 400, 15f, 0);
                        }
                    }
                    bytes = stream.ToArray();
                }
                File.WriteAllBytes(save.FileName, bytes);
            }
            catch (Exception) { throw new Exception("Bitte schließen Sie das geöffnete Pdf!"); }
        }
    }
}
