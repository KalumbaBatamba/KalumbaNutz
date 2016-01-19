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
         private SaveFileDialog SfdCriterion = new SaveFileDialog();
         private Project _project;

         public Project Project
         {
             get { return _project; }
             set { _project = value; }
         }

         private ProjectCriterionController _projectCriterionController;

         public ProjectCriterionController ProjCritContr
         {
             get { return _projectCriterionController; }
             set { _projectCriterionController = value; }
         }
         

         public CriterionStructurePrinter(int projectId)
         {
             this.ProjCritContr = new ProjectCriterionController();
             ProjectController projCont = new ProjectController();
             this.Project = projCont.GetProjectById(projectId);
         }
            
        //Methode um allen in der Datenbank gelisteten Projekte in einer PDF auszugeben

        public void CreateCriterionStructurePdf()
        {

            //Benötigte Verbindung um Daten aus der Datenbank holen
            
            List<ProjectCriterion> baseCriterions = this.ProjCritContr.GetBaseProjectCriterions(this.Project.Project_Id); //TODO - Hier noch definieren das aktuelles Projekt gewählt wird

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
                {
                    MessageBox.Show(String.Format("{0}" + " noch geöffnet! Bitte Schließen!", SfdCriterion.FileName));
                    return;
                }

               
                CriterionStructureDoc.Open();


               //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)
                string projectName = Project.Name;
                
                Font arial = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
                
                 
                
                
                
               
                
                         
               //Schleife um Daten aus Datenbank zu holen

                PdfPTable CritTable = new PdfPTable(3);
                float[] widths = {300f, 15f, 100f }; //Relative Breite der Spalten in Relation zur gesamten Tabellengröße
                CritTable.DefaultCell.Border = 0;
                CritTable.SetWidths(widths);
                
                CritTable.AddCell(new Paragraph("Anforderungen des Anwenders", arial));
                CritTable.AddCell(new Paragraph("*", arial));
                CritTable.AddCell(new Paragraph("Kommentar", arial));
                
           
                CritTable.HorizontalAlignment = 0;
                CritTable.TotalWidth = 700f; //Totale Breite der "Tabelle"
                CritTable.LockedWidth = true;

                //Methodenaufruf

                PrintCriterionStructure(ref CritTable);

                CriterionStructureDoc.Add(CritTable);

                //Close Dokument - Bearbeitung Beenden
                CriterionStructureDoc.Close();

                //Aufrufen der Hilfsmethode um Seitenzahl auf das PDF Dokument zu schreiben - Dokument und Einrückung der Seitenzahl wird der Methode übergeben     
                CriterionStructurePrinter PageNumberObject = new CriterionStructurePrinter(99);
                PageNumberObject.GetPageNumber(SfdCriterion, 800);
              
                MessageBox.Show("PDF erfolgreich angelegt");
                
                //PDf wird automatisch geöffnet nach der erfolgreichen Speicherung
                System.Diagnostics.Process.Start(SfdCriterion.FileName);

                
            }
        }

        private void PrintCriterionStructure(ref PdfPTable CritTable)
        {

            List<ProjectCriterion> sortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);

            

            foreach (ProjectCriterion projectCriterion in sortedProjectCriterionStructure)
            {
                
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


        public class CellSpacingEvent : IPdfPCellEvent
        {
            private int cellSpacing;
            public CellSpacingEvent(int cellSpacing)
            {
                this.cellSpacing = cellSpacing;
            }
            void IPdfPCellEvent.CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
            {
                //Grab the line canvas for drawing lines on
                PdfContentByte cb = canvases[PdfPTable.LINECANVAS];
                //Create a new rectangle using our previously supplied spacing
                cb.Rectangle(
                    position.Left + this.cellSpacing,
                    position.Bottom + this.cellSpacing,
                    (position.Right - this.cellSpacing) - (position.Left + this.cellSpacing),
                    (position.Top - this.cellSpacing) - (position.Bottom + this.cellSpacing)
                    );
                //Set a color
                cb.SetColorStroke(BaseColor.RED);
                //Draw the rectangle
                cb.Stroke();
            }
        }
  
    }
}
