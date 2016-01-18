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

            //Benötigte Verbindung um Daten aus der Datenbank holen
            ProjectCriterionController cont = new ProjectCriterionController();
            List<ProjectCriterion> projCrits = cont.GetAllProjectCriterionsForOneProject(1); //TODO - Hier noch definieren das aktuelles Projekt gewählt wird

            //SaveFileDialog um Dokument am gewünschten Ort speicher zu können 
            SfdCriterion.Filter = "Pdf File |*.pdf";
            if (SfdCriterion.ShowDialog() == DialogResult.OK)
            {

                //Dokument Erstellen, Definieren des Formats
                Document CriterionStructureDoc = new Document(iTextSharp.text.PageSize.A4.Rotate()); //Dokument in Querformat
                CriterionStructureDoc.SetMargins(50, 200, 50, 125); //Seitenränder definieren
                try //try catch um Fehler abzufangen wenn eine gleichnamige PDF noch geöffnet ist
                {    
                    PdfWriter writer = PdfWriter.GetInstance(CriterionStructureDoc, new FileStream(SfdCriterion.FileName, FileMode.Create));
                    writer.PageEvent = new PdfPageEvents(); //Timestamp                
                }
                catch (Exception) 
                {MessageBox.Show(String.Format("{0}" + " noch geöffnet! Bitte Schließen!", SfdCriterion.FileName));}

               
                CriterionStructureDoc.Open();


               //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)
                ProjectCriterion stringProjectName = new ProjectCriterion();
                
                Font arial = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
                Paragraph heading = new Paragraph("Anforderungen des Anwenders",  arial);
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

                            PdfPTable CritTable = new PdfPTable(1);
                            PdfPCell Crits = new PdfPCell(new Phrase(projectCriterion.Criterion.Description.ToString(), CritStructFont));
                            Crits.Border = 0;
                            CritTable.AddCell(Crits);
                            CritTable.HorizontalAlignment = 0;
                            CritTable.TotalWidth = 350f; //Breite der "Tabelle"
                            CritTable.LockedWidth = true;
                            projectCriterionDescription.Add(CritTable);

                            //Passende Einrückung je nach Zugehörigkeit
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

        public void GetPageNumber(SaveFileDialog save, int pageNumberBottomPosition)
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
                        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), BlackFont), pageNumberBottomPosition, 15f, 0);
                    }
                }
                bytes = stream.ToArray();
            }
            File.WriteAllBytes(save.FileName, bytes);
        }

  
    }
}
