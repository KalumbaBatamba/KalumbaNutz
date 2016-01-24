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
using iTextSharp.text.log;
using iTextSharp.text.pdf.draw;

/// <summary>
/// Klasse um die Erfüllung der Kriterien für ALLE Produkte in einer PDF Datei zu zeigen
/// </summary>
/// Erstellt von Adrian Glasnek

namespace NWAT.Printer
{


    class FulfillmentForEveryProduct
    {
        
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

        //Konstruktor
        public FulfillmentForEveryProduct(int projectId)
        {
            this.ProjCritContr = new ProjectCriterionController();
            ProjectController projCont = new ProjectController();
            this.Project = projCont.GetProjectById(projectId);

        }

        /// <summary>
        /// Methode um Pdf erstellen etc.
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public void CreateFulfillmentForEveryProductPdf()
        {
           
            ProjectProductController projprodContr = new ProjectProductController();
            List<ProjectProduct> allProductsForThisProject = projprodContr.GetAllProjectProductsForOneProject(this.Project.Project_Id);
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

                //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)        
                Font userNeedFont = FontFactory.GetFont("Arial", 9);
                Font arialBold = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
                Font products = FontFactory.GetFont("Arial_BOLD", 7, Font.NORMAL);

                //Dokument öffnen um es bearbeiten zu können
                FulfillmentPrinter.Open();

                //Legende zur Erklärung der Symbole
                Paragraph userNeeds = new Paragraph("    *         -     Anforderungen des Kunden",userNeedFont);
                FulfillmentPrinter.Add(userNeeds);

                //Anzahl der Produkte eines Projektes in einer int Variable speichern
                int countProducts = allProductsForThisProject.Count();

                //Tabelle in der die Kriterien reingeschrieben werden - Tabelle zwecks besserer Darstellung gewählt
                PdfPTable CritTable = new PdfPTable(countProducts + 3);
                int numberOfCells = countProducts + 3;
               
                // Je nach Anzahl der Produkte in der Datenbank wir die relative Spaltenbreite gesetzt 
                if (numberOfCells == 3) { float[] widths = { 20f, 2f, 1f, }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 4) { float[] widths = { 20f, 2f, 1f, 1f, }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 5) { float[] widths = { 20, 2, 1, 1, 1 }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 6) { float[] widths = { 20, 2, 1, 1, 1, 1 }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 7) { float[] widths = { 20f, 2f, 1f, 1f, 1f, 1f, 1f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 8) { float[] widths = { 20f, 2f, 1f, 1f, 1f, 1f, 1f, 1f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 9) { float[] widths = { 20f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 10) { float[] widths = { 20f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells >= 11) { throw new System.ArgumentException("Die Anzahl der maximal darstellbaren Produkte auf einer Seite wurde überschritten!"); }
                //Ab einer Anzahl von >10 Produkten wird eine Fehlermeldung ausgeworfen das nicht mehr Produkte auf die Seite des Pdfs passen
                         
                CritTable.DefaultCell.Border = 1;               // Die Grenzen der Tabelle unsichtbar machen
                CritTable.HeaderRows = 1;                     //Anzeigen der ersten Zeilen als Überschrift auf jeder Seite des Dokuments

                CritTable.SpacingBefore = 20f;      //Platz zwischen Produktlegende und der Tabelle
                CritTable.AddCell(new Paragraph("Tabellarische Übersicht aller Produkte", arialBold));
                CritTable.AddCell(new Paragraph(" "));                   //Leere Zelle sorgt für Abstand zwischen Header und Erfüllungen 
                CritTable.AddCell(new Paragraph("*"));      //Kde. steht für die Anforderungen des Kunden
                //Zählt wieviele Produkte in der Datenbank liegen und schreibt dementsprechend viele Spalten auf das Pdf
                for (int i = 1; i <= allProductsForThisProject.Count(); i++)
                {

                    string prodHeader = "Prd." + i.ToString(); 
                    CritTable.AddCell(new Paragraph(prodHeader,  products));
                 
                }


                CritTable.HorizontalAlignment = 0;
                CritTable.TotalWidth = 700f; //Totale Breite der "Tabelle"
                CritTable.LockedWidth = true;

                //Methodenaufruf
                PrintCriterionStructure(ref CritTable);

                //Tabelle zum Dokument Adden
                FulfillmentPrinter.Add(CritTable);

                //Close Dokument - Bearbeitung Beenden
                FulfillmentPrinter.Close();


                //Aufrufen der Hilfsmethode (aus Klasse CriterionStructurePrinter)- Seitenzahl und den Projektnamen auf Pdf     

                GetPageNumber(SfdFulfillment, 800);

                MessageBox.Show("Pdf erfolgreich erstellt!");

                //PDf wird automatisch geöffnet nach der erfolgreichen Speicherung
                System.Diagnostics.Process.Start(SfdFulfillment.FileName);

            }
        }

        /// <summary>
        /// Eigentliche Print Methode um Pdf zu befüllen
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        private void PrintCriterionStructure(ref PdfPTable CritTable)
        {

            Paragraph productName = new Paragraph();            //Paragraph um Namem der Produkte mit den Abkürzungen in der Tabelle verbinden zu können
            //Zugirff auf Erfüllungen der Kriterien für die Produkte aus der Datenbank
            FulfillmentController fufiCont = new FulfillmentController();
            List<Fulfillment> fufiList = fufiCont.GetAllFulfillmentsForOneProject(this.Project.Project_Id);

            //Zugirff auf Liste aller Produkte aus der Datenbank
            ProjectProductController projprodContr = new ProjectProductController();
            List<ProjectProduct> allProductsForThisProject = projprodContr.GetAllProjectProductsForOneProject(this.Project.Project_Id);

            //Übergebene Liste von Methode "GetSortedCriterionStructure()" in Liste sortedProjectCriterionStructure schreiben

            List<ProjectCriterion> sortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);
            // dict: layer => enum
            Dictionary<int, int> enumerations = new Dictionary<int, int>() { { 1, 0 } };

            //Variablen die in den unten folgenden foreach-Schleifen benötigt werden
            int iCount = 0;  
            int countCounter = 1;
            int i = 1;

            
            Font prodNameFont = FontFactory.GetFont("Arial", 9);    //Font für die Ausgabe der Produktlegende 
            productName.Font = prodNameFont;
                
                
                //Foreach-Schleife druckt sortierte Kriterien auf das Pdf Dokument
            foreach (ProjectCriterion projectCriterion in sortedProjectCriterionStructure)
            {
                Font CritStructFont = FontFactory.GetFont("Arial", 10);

                

                //Definieren der intend Variable um die richtige "Einrückung" auf dem Pdf Dokument erzielen zu können
                int layer = projectCriterion.Layer_Depth;
                int factor = 25;
                int intend;

                intend = layer * factor;

                string enumeration = GetEnumerationForCriterion(ref enumerations, layer);

                //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                


                //Paragraph der die Zellen befüllt
                string CritsEnumeration = "[" + enumeration + "]" + " " + projectCriterion.Criterion.Description.ToString();

                Paragraph para = new Paragraph(CritsEnumeration, CritStructFont);
                para.IndentationLeft = intend;      //Einrückungsfaktor, das zugehörige Kriterien untereinander stehen
                PdfPCell Crits = new PdfPCell();    //Neue Tabellenzelle in der die Kriterienbeschreibung reingeschrieben wird
                Crits.AddElement(para);             //Der Zelle den Paragraphen übergeben
                Crits.Border = 1;                   //Anzeigen von Linien im Pdf

                CritTable.AddCell(Crits);
                CritTable.AddCell("");
                if (projectCriterion.Weighting_Cardinal <= 0)
                {
                    CritTable.AddCell(new Paragraph("-", CritStructFont));
                }
                else
                {
                    CritTable.AddCell(new Paragraph("x", CritStructFont));
                }

                //if Schleife damit alle Produktnamen korrekt auf dem Pdf ausgegeben werden
                if (iCount == countCounter)
                {
                    
                    FulfillmentPrinter.Add(productName);   //Produktname der vergliechenen Produkte auf dem Dokument anzeige
                }


                //foreach Schleife um die Erfüllungen für alle in der Datenbank hinterlegten Produkte aus das Pdf zu drucken
                foreach (ProjectProduct projprod in allProductsForThisProject)
                {

                    try         //try catch Anweisung um Fehler abzufangen. Fehler: Für das Produkt sind keine oder nicht alle Erfülungen in der DB hinterlegt
                    {
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

                    catch { throw new ApplicationException("Warnung!\n Nicht für alle Produkte des Projekts sind Erfüllungen hinterlegt! Bitte überprüfen Sie Ihre Eingaben! "); }

                        //Hier wird der Name dem Paragraphen productName hinzugefügt - Um welche Produkte es sich handelt
                        
                        productName.Add("Prd. " + i.ToString()+ "     -     "+ projprod.Product.Name + "\n");     
                        i++;           

                }

                
                iCount++;       //Erhöhe Variable Count - Relevant für if-Schleife zum Printen der Produktnamen auf dem Pdf
               
            }
           
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
        /// Methode um Nummern auf Pdf zu drucken
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