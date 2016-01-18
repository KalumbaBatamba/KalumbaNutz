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
/// Klasse um die Erfüllung der Kriterien in einer PDF Datei zu zeigen
/// </summary>
/// Erstellt von Adrian Glasnek

namespace NWAT.Printer
{

    class FulfillmentForEachProductPrinter
    {


        public void PrintFulfillment()
        {

            ProjectCriterionController cont = new ProjectCriterionController();
            List<ProjectCriterion> projCrits = cont.GetAllProjectCriterionsForOneProject(1);

            SaveFileDialog SfdFulfillment = new SaveFileDialog();
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
                catch (Exception) {MessageBox.Show(String.Format("{0}" + " noch geöffnet! Bitte Schließen!", SfdFulfillment.FileName));}
                
                FulfillmentPrinter.Open();

                Font arial = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
                Paragraph heading = new Paragraph("Erfüllung der Kriterien", arial);
                heading.Add(new Chunk(new VerticalPositionMark()));
                heading.Add(new Chunk("E                        Kommentar", arial));
                heading.SpacingAfter = 15f; //Abstand nach der Überschrift
                FulfillmentPrinter.Add(heading);

                foreach (ProjectCriterion projectCriterion in projCrits)
                {
                    int layer = projectCriterion.Layer_Depth;
                    double factor = 25;
                    double intend = layer * factor;

                    //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                    Font CritStructFont = FontFactory.GetFont("Arial", 9);
                    Paragraph projectCriterionDescription = new Paragraph(/*projectCriterion.Criterion.Description.ToString(), CritStructFont*/);

                    PdfPTable CritTable = new PdfPTable(1);
                    PdfPCell Crits = new PdfPCell(new Phrase(projectCriterion.Criterion.Description.ToString(), CritStructFont));
                    Crits.Border = 0;
                    CritTable.AddCell(Crits);
                    CritTable.HorizontalAlignment = 0;
                    CritTable.TotalWidth = 350f; //Breite der "Tabelle"
                    CritTable.LockedWidth = true;
                    projectCriterionDescription.Add(CritTable);
                    
                    projectCriterionDescription.IndentationLeft = (Convert.ToSingle(intend));
                    FulfillmentPrinter.Add(projectCriterionDescription);
                }

                FulfillmentPrinter.Close();

                //Aufrufen der Hilfsmethode um Seitenzahl auf das PDF Dokument zu schreiben
                CriterionStructurePrinter PageNumberObject = new CriterionStructurePrinter();
                PageNumberObject.GetPageNumber(SfdFulfillment, 800); 

                MessageBox.Show("PDF erfolgreich angelegt");

                //PDf wird automatisch geöffnet nach der erfolgreichen Speicherung
                System.Diagnostics.Process.Start(SfdFulfillment.FileName);
            
            }
        }
    }
}
