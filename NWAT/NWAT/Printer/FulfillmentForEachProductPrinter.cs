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
        
        SaveFileDialog SfdFulfillment = new SaveFileDialog();
        private Project _projectid;
        private Product _productid;

        //Benötigte Properties für Project und Product
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

        //Konstruktor
         public FulfillmentForEachProductPrinter(int projectId, int projprodId)
         {
             this.ProjCritContr = new ProjectCriterionController();
             ProjectController projCont = new ProjectController();
             this.Project = projCont.GetProjectById(projectId);

             this.ProjProduct = new ProductController();
             ProductController projProdController = new ProductController();
             this.Product = projProdController.GetProductById(projprodId);

         }

        public void CreateFulfillmentForEachProductPdf()
        {
            
            Product products = this.ProjProduct.GetProductById(this.Product.Product_Id);    //Get Product by Id from Database
            List<ProjectCriterion> baseCriterions = this.ProjCritContr.GetBaseProjectCriterions(this.Project.Project_Id); //Get all base Criterions
            

            SfdFulfillment.Filter = "Pdf File |*.pdf";
            if (SfdFulfillment.ShowDialog() == DialogResult.OK)
            {
                Document FulfillmentPrinter = new Document(iTextSharp.text.PageSize.A4.Rotate());
                FulfillmentPrinter.SetMargins(50, 200, 50, 125); //Seitenränder definieren
                try //try catch um Fehler abzufangen wenn eine gleichnamige PDF noch geöffnet ist
                {  
                    PdfWriter writer = PdfWriter.GetInstance(FulfillmentPrinter, new FileStream(SfdFulfillment.FileName, FileMode.Create));
                    writer.PageEvent = new PdfPageEvents();
                }
                catch (Exception) {MessageBox.Show(String.Format(SfdFulfillment.FileName + " noch geöffnet! Bitte Schließen!"));}
                
                //Dokument öffnen um es bearbeiten zu können
                FulfillmentPrinter.Open();

                //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)        
                Font arialBold = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);

                //Erstellen einer Pdf Tabelle in der die Daten aus der Datenbank ausgegeben werden

                PdfPTable CritTable = new PdfPTable(4);
                float[] widths = { 300f, 5f, 15f, 100f }; //Relative Breite der Spalten in Relation zur gesamten Tabellengröße
                CritTable.DefaultCell.Border = 0;      // Die Grenzen der Tabelle unsichtbar machen
                CritTable.SetWidths(widths);          //Relationale Breiten der Tabellenspalten fixen
                CritTable.HeaderRows = 1;            //Anzeigen der Überschriften auf jeder Seite des Dokuments

                CritTable.AddCell(new Paragraph("Produkt-Einzeldarstellung   -   " + products.Name, arialBold));
                CritTable.AddCell(new Paragraph(" ", arialBold));                   //Leere Zelle sorgt für Abstand - Formatierungszwecke
                CritTable.AddCell(new Paragraph("E", arialBold));
                CritTable.AddCell(new Paragraph("Kommentar", arialBold));

                CritTable.HorizontalAlignment = 0;
                CritTable.TotalWidth = 650f; //Totale Breite der "Tabelle"
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


            //Foreach-Schleife druckt sortierte Kriterien auf das Pdf Dokument
            foreach (ProjectCriterion projectCriterion in sortedProjectCriterionStructure)
            {

                //Definieren der intend Variable um die richtige "Einrückung" auf dem Pdf Dokument erzielen zu können
                int layer = projectCriterion.Layer_Depth;
                int factor = 25;
                int intend;

                intend = layer * factor;

                //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                Font CritStructFont = FontFactory.GetFont("Arial", 10);


                Paragraph para = new Paragraph(projectCriterion.Criterion.Description.ToString(), CritStructFont);
                para.IndentationLeft = intend;
                PdfPCell Crits = new PdfPCell();
                Crits.AddElement(para);
                Crits.Border = 0;

                CritTable.AddCell(Crits);
                CritTable.AddCell("");
                CritTable.AddCell("");
                CritTable.AddCell("");
            }

        }

    }
}
