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
                Document CriterionStructureDoc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter writer = PdfWriter.GetInstance(CriterionStructureDoc, new FileStream(SfdCriterion.FileName, FileMode.Create));
                writer.PageEvent = new PdfPageEvents(); //Timestamp
                CriterionStructureDoc.Open();

               //Überschrift und nötige Formatierung setzen

                Font arial = FontFactory.GetFont("Arial", 20);
                Paragraph heading = new Paragraph("Kriterienstruktur", arial);
                

                //Abstand nach Übersicht bis zur Tabelle
                heading.SpacingAfter = 18f;
                CriterionStructureDoc.Add(heading);
                         
               //Schleife um Daten aus Datenbank zu holen



                foreach (ProjectCriterion projectCriterion in projCrits)
                {
                        int layer = projectCriterion.Layer_Depth;
                        double factor = 25;
                        double intend = layer * factor;

                        //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                        Font CritStructFont = FontFactory.GetFont("Arial", 9);
                        Paragraph projectCriterionDescription = new Paragraph(projectCriterion.Criterion.Description.ToString(), CritStructFont);
                        projectCriterionDescription.IndentationLeft = (Convert.ToSingle(intend));
                        CriterionStructureDoc.Add(projectCriterionDescription);  
                }


                //Close Dokument - Bearbeitung Beenden
                CriterionStructureDoc.Close();

                //Aufrufen der Hilfsmethode um Seitenzahl auf das PDF Dokument zu schreiben
                CriterionStructurePrinter PageNumberObject = new CriterionStructurePrinter();
                PageNumberObject.GetPageNumber(SfdCriterion);
                
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

        public void GetPageNumber(SaveFileDialog save)
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
                        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), BlackFont), 568f, 15f, 0);
                    }
                }
                bytes = stream.ToArray();
            }
            File.WriteAllBytes(save.FileName, bytes);
        }

       


       


       
    }
}
