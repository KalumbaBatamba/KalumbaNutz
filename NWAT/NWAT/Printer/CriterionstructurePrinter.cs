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
/// Klasse um die Kriterienstruktur in einer PDF Datei zu zeigen
/// </summary>
/// Erstellt von Adrian Glasnek
/// 

namespace NWAT.Printer
{
    public class CriterionStructurePrinter
    {

        //Objekt SfdCriterion erstellen
         SaveFileDialog SfdCriterion = new SaveFileDialog();
         
            
        //Methode um allen in der Datenbank gelisteten Projekte in einer PDF auszugeben

        public void CritStructPrinter()
        {

            ProjectCriterionController cont = new ProjectCriterionController();
            List<ProjectCriterion> projCrits = cont.GetAllProjectCriterionsForOneProject(1);

            //SaveFileDialog um Dokument am gewünschten Ort speicher zu können 
            SfdCriterion.Filter = "Pdf File |*.pdf";
            if (SfdCriterion.ShowDialog() == DialogResult.OK)
            {

                //Dokument Erstellen, Definieren des Formats
                Document CriterionStructureDoc = new Document(iTextSharp.text.PageSize.A4.Rotate()); //Dokument in Querformat
                CriterionStructureDoc.SetMargins(50, 200, 50, 125); //Seitenränder definieren
                PdfWriter writer = PdfWriter.GetInstance(CriterionStructureDoc, new FileStream(SfdCriterion.FileName, FileMode.Create));
                writer.PageEvent = new PdfPageEvents(); //Timestamp
                CriterionStructureDoc.Open();


               //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)
                Font arial = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
                Paragraph heading = new Paragraph("Anforderungen des Anwenders", arial);
                heading.Add(new Chunk(new VerticalPositionMark()));
                heading.Add(new Chunk("*                        Kommentar", arial));
                 
                
                
                
                //Abstand nach Übersicht bis zur Tabelle
                heading.SpacingAfter = 15f;
                CriterionStructureDoc.Add(heading);
                         
               //Schleife um Daten aus Datenbank zu holen

                    foreach (ProjectCriterion projectCriterion in projCrits)
                    {
                        int layer = projectCriterion.Layer_Depth;
                        double factor = 25;
                        double intend = layer * factor;

                        //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                        Font CritStructFont = FontFactory.GetFont("Arial", 10);
                        Paragraph projectCriterionDescription = new Paragraph(/*projectCriterion.Criterion.Description.ToString(), CritStructFont)*/);

                        PdfPTable table = new PdfPTable(1);
                        PdfPCell cell = new PdfPCell(new Phrase(projectCriterion.Criterion.Description.ToString(), CritStructFont));
                        cell.Border = 0;
                        table.AddCell(cell);
                        table.HorizontalAlignment =0;
                        table.TotalWidth = 350f; //Breite der "Tabelle"
                        table.LockedWidth = true;
                        projectCriterionDescription.Add(table);
                       

                        projectCriterionDescription.IndentationLeft = (Convert.ToSingle(intend));
                        CriterionStructureDoc.Add(projectCriterionDescription);
                       
                    }
                


                //Close Dokument - Bearbeitung Beenden
                CriterionStructureDoc.Close();

                //Aufrufen der Hilfsmethode um Seitenzahl auf das PDF Dokument zu schreiben - Dokument und Einrückung der Seitenzahl wird der Methode übergeben
                CriterionStructurePrinter PageNumberObject = new CriterionStructurePrinter();
                PageNumberObject.GetPageNumber(SfdCriterion, 800);
                
                MessageBox.Show("PDF erfolgreich angelegt");
                
                //PDf wird automatisch geöffnet nach der erfolgreichen Speicherung
                System.Diagnostics.Process.Start(SfdCriterion.FileName);

                
            }
        }

        /// <summary>
        /// Hilfsmethode um Seitenzahl auf das PDF Dokument zu schreiben
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public void GetPageNumber(SaveFileDialog save, int pageNumberBottom)
        {
            byte[] bytes = File.ReadAllBytes(save.FileName);
            Font BlackFont = FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK);
            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);
                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;
                    for (int i = 1; i <= pages; i++)
                    {
                        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), BlackFont), pageNumberBottom, 15f, 0);
                    }
                }
                bytes = stream.ToArray();
            }
            File.WriteAllBytes(save.FileName, bytes);
        }

       


       


       
    }
}
