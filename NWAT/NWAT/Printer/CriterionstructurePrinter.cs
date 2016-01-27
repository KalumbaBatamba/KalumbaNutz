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

        //Benötigte Properties für Project
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

         //Konstruktor
         public CriterionStructurePrinter(int projectId)
         {
             this.ProjCritContr = new ProjectCriterionController();
             ProjectController projCont = new ProjectController();
             this.Project = projCont.GetProjectById(projectId);
         }


         /// <summary>
         /// Methode um allen in der Datenbank gelisteten Projekte in einer PDF auszugeben
         /// </summary>
         /// Erstellt von Adrian Glasnek
        

        public void CreateCriterionStructurePdf()
        {

            //Benötigte Verbindung um Daten aus der Datenbank holen
            List<ProjectCriterion> baseCriterions = this.ProjCritContr.GetBaseProjectCriterions(this.Project.Project_Id); //Get all base Criterions

            //SaveFileDialog um Dokument am gewünschten Ort speichern zu können 
            SfdCriterion.Filter = "Pdf File |*.pdf";
            if (SfdCriterion.ShowDialog() == DialogResult.OK)
            {
                //Dokument Erstellen, Definieren des Formats
                Document CriterionStructureDoc = new Document(iTextSharp.text.PageSize.A4.Rotate()); //Dokument in Querformat
                CriterionStructureDoc.SetMargins(50, 200, 50, 125); //Seitenränder definieren

                //try catch um Fehler abzufangen wenn eine gleichnamige PDF noch geöffnet ist
                try 
                {    
                    PdfWriter writer = PdfWriter.GetInstance(CriterionStructureDoc, new FileStream(SfdCriterion.FileName, FileMode.Create));
                    //Timestamp
                    writer.PageEvent = new PdfPageEvents();                 
                }
                catch (Exception) { throw new Exception("Bitte schließen Sie das geöffnete Pdf!"); }

                //Dokument zur Bearbeitung Öffnen
                CriterionStructureDoc.Open();

                //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)        
                Font arial = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
                Font arialNormal = FontFactory.GetFont("Arial_BOLD", 10, Font.NORMAL);

                 //Erstellen einer Pdf Tabelle in der die Daten aus der Datenbank ausgegeben werden - 4 Spalten werden "übergeben"
                PdfPTable CritTable = new PdfPTable(4);

                //Relative Breite der Spalten in Relation zur gesamten Tabellengröße
                float[] widths = {300f, 5f, 15f, 100f };
                // Die Grenzen der Tabelle teilweise sichtbar machen
                CritTable.DefaultCell.Border = 1;
                //Relationale Breiten der Tabellenspalten fixen
                CritTable.SetWidths(widths);
                //Anzeigen der Überschriften auf jeder Seite des Dokuments
                CritTable.HeaderRows = 1;            
                CritTable.AddCell(new Paragraph("Anforderungen des Anwenders", arial));
                //Leere Zelle sorgt für Abstand - Formatierungszwecke
                CritTable.AddCell(new Paragraph(" ", arial));                  
                CritTable.AddCell(new Paragraph("*", arial));
                CritTable.AddCell(new Paragraph("Gew.", arialNormal));
           
                CritTable.HorizontalAlignment = 0;
                //Totale Breite der "Tabelle"
                CritTable.TotalWidth = 650f; 
                CritTable.LockedWidth = true;

                //Methodenaufruf
                PrintCriterionStructure(ref CritTable);

                //Tabelle zum Dokument Adden
                CriterionStructureDoc.Add(CritTable);
               
                //Close Dokument - Bearbeitung Beenden
                CriterionStructureDoc.Close();

                //Aufrufen der Hilfsmethode GetPageNumber - Seitenzahl und den Projektnamen auf Pdf     
                CriterionStructurePrinter PageNumberObject = new CriterionStructurePrinter(Project.Project_Id);
                PageNumberObject.GetPageNumber(SfdCriterion, 800);
                
                //Ausgabe bei erfolgreicher Ausgabe                
                MessageBox.Show("Pdf erfolgreich erstellt!");

                //PDf wird automatisch geöffnet nach der erfolgreichen Speicherung
                System.Diagnostics.Process.Start(SfdCriterion.FileName);
            }
        }

        /// <summary>
        /// Eigentliche Print Methode um Pdf zu befüllen
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        private void PrintCriterionStructure(ref PdfPTable CritTable)
        {
                //Liste für die sortierte Kriterienstruktur
                List<ProjectCriterion> sortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);

                // Generische Liste - Dictionary Wertepaar vom Typ int - Schlüssel und Wert
                Dictionary<int, int> enumerations = new Dictionary<int, int>() { { 1, 0 } };

                //Foreach-Schleife druckt sortierte Kriterien auf das Pdf Dokument
                foreach (ProjectCriterion projectCriterion in sortedProjectCriterionStructure)
                {
                    //Definieren der intend Variable um die richtige "Einrückung" auf dem Pdf Dokument erzielen zu können
                    int layer = projectCriterion.Layer_Depth;
                    int factor = 25;
                    int intend;
                    intend = layer * factor;

                    //Paragraph der die Zellen befüllt
                    string enumeration = GetEnumerationForCriterion(ref enumerations, layer);
                    
                    //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                    Font CritStructFont = FontFactory.GetFont("Arial", 10);

                    //string der dem Paragraphen übergeben wird, mit den Enumerations und den Kriterien in einer Zeile
                    string CritsEnumeration = "[" +enumeration+"]" + " " + projectCriterion.Criterion.Description.ToString();

                    Paragraph para = new Paragraph(CritsEnumeration, CritStructFont);
                    //Einrückungsfaktor, das zugehörige Kriterien untereinander stehen
                    para.IndentationLeft = intend;      
                    PdfPCell Crits = new PdfPCell();
                    Crits.AddElement(para);

                    //Grenzen der Pdf Zellen auf 1, d.h. Ränder teilweise sichtbar machen
                    Crits.Border = 1;                   

                    CritTable.AddCell(Crits);
                    CritTable.AddCell("");

                    //If Abfrage - Wenn eine Gewichtung in der Datenbank hinterlegt ist wird bei den Kriterien ein x gesetzt ansonsten ein -
                    if (projectCriterion.Weighting_Cardinal <= 0)
                    {
                        CritTable.AddCell(new Paragraph("-", CritStructFont));
                    }
                    else
                    {
                        CritTable.AddCell(new Paragraph("x", CritStructFont));
                    }

                    string balance = "  " + projectCriterion.Weighting_Cardinal.ToString();
                    CritTable.AddCell(new Paragraph(balance, CritStructFont));
                }
            
        }

        /// <summary>
        /// Methode um Kriterien eine Nummerierung zu geben
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public string  GetEnumerationForCriterion(ref Dictionary<int, int> enumerations, int layer)
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
        /// Hilfsmethode um Seitenzahl und betreffenden Projektname auf JEDE Seite des PDF Dokuments zu schreiben
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
