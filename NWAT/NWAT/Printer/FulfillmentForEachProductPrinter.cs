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
/// Klasse um die Erfüllung der Kriterien je Produkt in einer PDF Datei zu zeigen
/// </summary>
/// Erstellt von Adrian Glasnek

namespace NWAT.Printer
{
    class FulfillmentForEachProductPrinter
    {
        //Objekt vom Typ SaveFileDialog
        SaveFileDialog SfdFulfillment = new SaveFileDialog();       
        private Project _projectid;
        private Product _productid;
        private Fulfillment _fulfilled;

        //Benötigte Properties
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

         private List<Fulfillment> _fulfillmentForEachProduct;

         public List<Fulfillment> FulfillmentForEachProduct
         {
             get { return _fulfillmentForEachProduct; }
             set { _fulfillmentForEachProduct = value; }
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

        //Konstruktor - Werden ProjectId und ProductId als Parameter übergeben
         public FulfillmentForEachProductPrinter(int projectId, int productId)
         {
             this.ProjCritContr = new ProjectCriterionController();
             ProjectController projCont = new ProjectController();
             this.Project = projCont.GetProjectById(projectId);

             this.ProjProduct = new ProductController();
             ProductController projProdController = new ProductController();
             this.Product = projProdController.GetProductById(productId);

             this.FulFillContr = new FulfillmentController();
             FulfillmentController fulCont = new FulfillmentController();
             this.FulfillmentForEachProduct = fulCont.GetAllFulfillmentsForSingleProduct(projectId, productId);

         }

         /// <summary>
         /// 
         /// </summary>
         /// Erstellt von Adrian Glasnek

        public void CreateFulfillmentForEachProductPdf()
        {
            //Benötigte Listen die von den Controllern übergeben werden 
            Product products = this.ProjProduct.GetProductById(this.Product.Product_Id);    //Get Product by Id from Database
            List<ProjectCriterion> baseCriterions = this.ProjCritContr.GetBaseProjectCriterions(this.Project.Project_Id); //Get all base Criterions
            
            SfdFulfillment.Filter = "Pdf File |*.pdf";
            if (SfdFulfillment.ShowDialog() == DialogResult.OK)
            {
                //Dokument erstellen und A4 als Format festlegen
                Document FulfillmentPrinter = new Document(iTextSharp.text.PageSize.A4.Rotate());
                //Seitenränder definieren
                FulfillmentPrinter.SetMargins(50, 200, 50, 125);

                //try catch um Fehler abzufangen wenn eine gleichnamige PDF noch geöffnet ist
                try 
                {  
                    PdfWriter writer = PdfWriter.GetInstance(FulfillmentPrinter, new FileStream(SfdFulfillment.FileName, FileMode.Create));
                    //Timestamp
                    writer.PageEvent = new PdfPageEvents();
                }
                catch (Exception) {MessageBox.Show(String.Format(SfdFulfillment.FileName + " noch geöffnet! Bitte Schließen!"));}
                
                //Dokument öffnen um es bearbeiten zu können
                FulfillmentPrinter.Open();

                //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)        
                Font arialBold = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);

                //Erstellen der Pdf Tabelle in der die Daten aus der Datenbank ausgegeben werden
                PdfPTable CritTable = new PdfPTable(4);
                //Relative Breite der Spalten in Relation zur gesamten Tabellengröße
                float[] widths = { 300f, 5f, 15f, 100f };
                // Die Grenzen der Tabelle teilweise sichtbar machen
                CritTable.DefaultCell.Border = 1;
                //Relationale Breiten der Tabellenspalten an die Tabelle übergeben
                CritTable.SetWidths(widths);
                //Anzeigen der Überschriften auf jeder Seite des Dokuments
                CritTable.HeaderRows = 1;

                //Name des Produkts wird mit angezeigt
                CritTable.AddCell(new Paragraph("Produkt-Einzeldarstellung   -   " + products.Name, arialBold));
                //Leere Zelle sorgt für Abstand - Formatierungszwecke
                CritTable.AddCell(new Paragraph(" ", arialBold));                  
                CritTable.AddCell(new Paragraph("E", arialBold));
                CritTable.AddCell(new Paragraph("Kommentar", arialBold));

                //Ausrichtung Links
                CritTable.HorizontalAlignment = 0;
                //Totale Breite der "Tabelle"
                CritTable.TotalWidth = 650f; 
                CritTable.LockedWidth = true;

                //Methodenaufruf
                PrintCriterionStructure(ref CritTable);

                //Tabelle zum Dokument Adden
                FulfillmentPrinter.Add(CritTable);

                //Close Dokument - Bearbeitung Beenden
                FulfillmentPrinter.Close();

                //Aufrufen der Hilfsmethode (aus Klasse CriterionStructurePrinter)- Seitenzahl und den Projektnamen auf Pdf     
                CriterionStructurePrinter PageNumberNameObject = new CriterionStructurePrinter(Project.Project_Id);
                PageNumberNameObject.GetPageNumber(SfdFulfillment, 800);

                //Meldung an den User nach erfolgreicher Erstellung
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
            //Übergebene Liste von Methode "GetSortedCriterionStructure()" in Liste sortedProjectCriterionStructure schreiben
            List<ProjectCriterion> sortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);
            
            // Generische Liste - Dictionary Wertepaar vom Typ int - Schlüssel und Wert
            Dictionary<int, int> enumerations = new Dictionary<int, int>() { { 1, 0 } };

            //Foreach-Schleife druckt sortierte Kriterien auf das Pdf Dokument
            foreach (ProjectCriterion projectCriterion in sortedProjectCriterionStructure)
            {
                //Verbindung zu Erfüllungsdaten aus der Datenbank
                Fulfillment fulfillmentForCurrtentCrit = _fulfillmentForEachProduct.SingleOrDefault(fufi => fufi.Criterion_Id == projectCriterion.Criterion_Id);

                //Fehlermeldung wenn nicht für alle Kriterien dieses Produktes eine Erfüllung hinterlegt ist
                if (fulfillmentForCurrtentCrit == null) 
                {
                    throw new NWATException(String.Format("Nicht für alle Kriterien zu diesem Produkt ist ein Erfüllungseintrag hinterlegt: \n Erfüllung für Kriterien ID {0} konnte nicht gefunden werden ", projectCriterion.Criterion_Id)); 
                }

                //Definieren der intend Variable um die richtige "Einrückung" auf dem Pdf Dokument erzielen zu können
                int layer = projectCriterion.Layer_Depth;
                int factor = 25;
                int intend;
                intend = layer * factor;

                //Aufzählunszahlen für die Kriterienstruktur in einen string schreiben
                string enumeration = GetEnumerationForCriterion(ref enumerations, layer);

                //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                Font CritStructFont = FontFactory.GetFont("Arial", 10);

                //Paragraph der die Zellen befüllt
                string CritsEnumeration = "[" + enumeration + "]" + " " + projectCriterion.Criterion.Description.ToString();

                //Neuer Paragraph der den string übergeben bekommt
                Paragraph para = new Paragraph(CritsEnumeration, CritStructFont);
                //Einrückungsfaktor, das zugehörige Kriterien untereinander stehen
                para.IndentationLeft = intend;
                //Neue Tabellenzelle in der die Kriterienbeschreibungen reingeschrieben werden
                PdfPCell Crits = new PdfPCell();
                //Der Zelle den Paragraphen übergeben
                Crits.AddElement(para);
                //Anzeigen von Linien im Pdf
                Crits.Border = 1;
                string comment = "";
                //Die Pdf Zellen an die Pdf Tabelle übergeben
                CritTable.AddCell(Crits);
                CritTable.AddCell("");

                //If Abfrage - Wenn Kriterium erfüllt dann setzte ein Kreuz, wenn nicht setzte ein -
                if (!fulfillmentForCurrtentCrit.Fulfilled)
                {
                    CritTable.AddCell(new Paragraph("-", CritStructFont));
                }
                else
                {
                    CritTable.AddCell(new Paragraph("x", CritStructFont));
                    comment = fulfillmentForCurrtentCrit.Comment;           //Falls Kommentar vorhanden, dann printe Kommentar mit
                }

                CritTable.AddCell(new Paragraph(comment, CritStructFont));
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

    }
}
