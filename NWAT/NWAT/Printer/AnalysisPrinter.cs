using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

/// <summary>
/// Klasse um die Analyseergebnisse inklusive der Kriterienstruktur in einer PDF Datei auszugeben
/// </summary>
/// Erstellt von Adrian Glasnek

namespace NWAT.Printer
{
    class AnalysePrinter
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

        private List<AnalysedProduct> _analysedProducts;

        public List<AnalysedProduct> AnalysedProducts
        {
            get { return _analysedProducts; }
            set { _analysedProducts = value; }
        }

        private List<ProjectCriterion> _sortedProjectCriterionStructure;

        public List<ProjectCriterion> SortedProjectCriterionStructure
        {
            get { return _sortedProjectCriterionStructure; }
            set { _sortedProjectCriterionStructure = value; }
        }
        
        

        //Konstruktor
        public AnalysePrinter(int projectId)
        {
            this.ProjCritContr = new ProjectCriterionController();
            ProjectController projCont = new ProjectController();
            this.Project = projCont.GetProjectById(projectId);
            
            //Hole Analyseergebnisse
            FunctioningAnalysis analysis = new FunctioningAnalysis(this.Project.Project_Id);

            this.AnalysedProducts = analysis.GetSortedAnalysedProducts();

            //Übergebene Liste von Methode "GetSortedCriterionStructure()" in Liste sortedProjectCriterionStructure schreiben
            this.SortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);
        }


        /// <summary>
        /// Methode um Pdf erstellen etc.
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public void PrintAnalysisResult()
        {
           
            
            
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
                catch (Exception) { MessageBox.Show(String.Format(SfdFulfillment.FileName + " noch geöffnet! Bitte Schließen!")); }

                //Dokument öffnen um es bearbeiten zu können
                FulfillmentPrinter.Open();

                Font headerRanking = FontFactory.GetFont("Arial_BOLD", 9, Font.NORMAL);
                PdfPTable rankingTable = new PdfPTable(3);
                rankingTable.HorizontalAlignment = 0;
                rankingTable.DefaultCell.Border = 0;
                rankingTable.TotalWidth = 200f;
                float[] widths = { 1f, 4f, 4f, }; 
                rankingTable.SetWidths(widths);


                int prodCounter = 1;
                //Zählt wieviele Produkte in der Datenbank liegen und schreibt dementsprechend viele Spalten auf das Pdf
                foreach(AnalysedProduct analysedProd in this.AnalysedProducts)
                {
                    rankingTable.AddCell(new Paragraph("Prd. " + prodCounter.ToString(), headerRanking));
                    rankingTable.AddCell(new Paragraph(analysedProd.ProjProd.Product.Name.ToString(), headerRanking));
                    rankingTable.AddCell(new Paragraph("Ergebnis: " + analysedProd.ProductAnalysisResult.ToString(), headerRanking));
                    rankingTable.TotalWidth = 500f;
                    prodCounter++;
                }

                FulfillmentPrinter.Add(rankingTable);
                
                //Bei einer Anzahl von mehr als 5 Produkten innerhalb eines NWA-Projekts werden jeweils weitere Tabellen mit den restlichen Produkten generiert
                List<List<AnalysedProduct>> tableLists = GetProdTableLists();
                int firstProdId = 1;
                int tableNumber = 1;
                foreach (List<AnalysedProduct> prodsInTable in tableLists)
                {
                    PdfPTable CritTable = GetNewProductTable(prodsInTable, firstProdId, tableNumber);

                    //Methodenaufruf
                    PrintCriterionStructure(ref CritTable, prodsInTable);

                    //Tabelle zum Dokument Adden
                    FulfillmentPrinter.Add(CritTable);

                    // Füge abstand zwischen den Tabellen ein
                    
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
        private PdfPTable GetNewProductTable(List<AnalysedProduct> productsForThisTable, int firstProdId, int tableNumber)
        {
            ProjectProductController projprodContr = new ProjectProductController();
            int numberOfallProductsForThisProject = projprodContr.GetAllProjectProductsForOneProject(this.Project.Project_Id).Count;

            int numOfProdsInThisTable = productsForThisTable.Count;

            //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)        
            Font arialBold = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
            Font products = FontFactory.GetFont("Arial_BOLD", 7, Font.NORMAL);
            //Erstellen einer Pdf Tabelle in der die Daten aus der Datenbank ausgegeben werden

            //Erstellen der PdfTable
            PdfPTable CritTable = new PdfPTable(numOfProdsInThisTable + 4);

           
            //int der die Anzahl der festen Spalten und die variable Anzahl der Produkte enthält
            int numberOfCells = numOfProdsInThisTable + 4;

            // Je nach Anzahl der Produkte in der Datenbank wir die relative Spaltenbreite gesetzt 
            if (numberOfCells == 3) { float[] widths = { 20f, 2f, 2f, }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 4) { float[] widths = { 20f, 2f, 1f, 3f, }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 5) { float[] widths = { 20, 2f, 2f, 3f, 3f }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 6) { float[] widths = { 20, 2f, 2f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 7) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 8) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
            if (numberOfCells == 9) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
            if (numberOfCells >= 10) { throw new System.ArgumentException("Die Anzahl der maximal darstellbaren Produkte auf einer Seite wurde überschritten!"); }
            //Ab einer Anzahl von >5 Produkten wird eine Fehlermeldung ausgeworfen das nicht mehr Produkte auf die Seite des Pdfs passen

            CritTable.DefaultCell.Border = 1;               // Die Grenzen der Tabelle unsichtbar machen
            CritTable.HeaderRows = 1;                     //Anzeigen der ersten Zeilen als Überschrift auf jeder Seite des Dokuments

            //Platz zwischen Produktlegende und der Tabelle
            CritTable.SpacingBefore = 20f;     
            if (numberOfallProductsForThisProject > 5)
            {
                CritTable.AddCell(new Paragraph(String.Format("Nutzwert - Analyse   [{0}. Teil]", tableNumber), arialBold));
            }
            else
            {
                CritTable.AddCell(new Paragraph("Nutzwert - Analyse", arialBold));
            }

            CritTable.AddCell(new Paragraph(" "));                   //Leere Zelle sorgt für Abstand zwischen Header und Erfüllungen 
            CritTable.AddCell(new Paragraph("Gew.", products));      //Spaltenüberschriften
            CritTable.AddCell(new Paragraph("Proz.", products));

            foreach (AnalysedProduct analysedProd in productsForThisTable)
            {
                string prodHeader = "Prd." + firstProdId.ToString();
                CritTable.AddCell(new Paragraph(prodHeader, products));
                firstProdId++;
            }

            CritTable.HorizontalAlignment = 0;
            //Totale Breite der "Tabelle"
            CritTable.TotalWidth = 700f;
            CritTable.LockedWidth = true;

            return CritTable;
        }

        /// <summary>
        /// Methode die je nach Anzahl von Produkten mehrere Tabellen generiert
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek
        
        public List<List<AnalysedProduct>> GetProdTableLists()
        {

            List<List<AnalysedProduct>> tableLists = new List<List<AnalysedProduct>>();
            int numberOfTables = 1;
            if (this.AnalysedProducts.Count > this.maxProductsInTable)
            {
                numberOfTables = (this.AnalysedProducts.Count / this.maxProductsInTable) + 1;

            }
            List<AnalysedProduct> tempAnalysedProd = new List<AnalysedProduct>();
            int tableProdCounter = 1;
            foreach (AnalysedProduct analysedProd in this.AnalysedProducts)
            {
                tempAnalysedProd.Add(analysedProd);
                if (tableProdCounter % this.maxProductsInTable == 0)
                {
                    tableLists.Add(tempAnalysedProd);
                    tableProdCounter = 1;
                    tempAnalysedProd = new List<AnalysedProduct>();
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

        private void PrintCriterionStructure(ref PdfPTable CritTable, List<AnalysedProduct> analysedProdsInThisTable)
        {            
            // Generische Liste - Dictionary Wertepaar vom Typ int - Schlüssel und Wert 
            Dictionary<int, int> enumerations = new Dictionary<int, int>() { { 1, 0 } };
        
                             
            //Foreach-Schleife druckt sortierte Kriterien auf das Pdf Dokument
            foreach (ProjectCriterion projectCriterion in this.SortedProjectCriterionStructure)
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
                CritTable.AddCell("");
                CritTable.AddCell(new Paragraph(projectCriterion.Weighting_Cardinal.ToString(), numbers));      //Weighting Cardinal
                try
                {
                    double percentageLayer = projectCriterion.Weighting_Percentage_Layer.Value * 100;
                    CritTable.AddCell(new Paragraph(percentageLayer.ToString(), numbers));
                }
                catch (Exception e) {throw new Exception ("Der Wert einer Gewichtung unter Geschwisterkriterien darf nicht 'NULL' betragen", e); }



                foreach (AnalysedProduct analysedProduct in analysedProdsInThisTable)
                {
                    try
                    {
                        AnalysisResultCrit resultCrit = analysedProduct.SortedAnalysisResultCrits.Single(resCrit => resCrit.ProjCrit.Criterion_Id == projectCriterion.Criterion_Id);
                        CritTable.AddCell(new Paragraph(resultCrit.ResultValue.ToString() ,numbers));
                    }
                    catch (Exception)
                    {
                        
                        throw;
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
    }
}
