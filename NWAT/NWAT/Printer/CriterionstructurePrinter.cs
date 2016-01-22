﻿using NWAT.DB;
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
            
        //Methode um allen in der Datenbank gelisteten Projekte in einer PDF auszugeben

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
                
                try //try catch um Fehler abzufangen wenn eine gleichnamige PDF noch geöffnet ist
                {    
                    PdfWriter writer = PdfWriter.GetInstance(CriterionStructureDoc, new FileStream(SfdCriterion.FileName, FileMode.Create));
                    writer.PageEvent = new PdfPageEvents(); //Timestamp                
                }
                catch (Exception) 
                {
                    MessageBox.Show(String.Format("{0}" + " noch geöffnet! Bitte Schließen!", SfdCriterion.FileNames));
                    return;
                }

               
                //Dokument zur Bearbeitung Öffnen
                CriterionStructureDoc.Open();

                //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)        
                Font arial = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
                
                 //Erstellen einer Pdf Tabelle in der die Daten aus der Datenbank ausgegeben werden
            
                PdfPTable CritTable = new PdfPTable(4);
                float[] widths = {300f, 5f, 15f, 100f }; //Relative Breite der Spalten in Relation zur gesamten Tabellengröße
                CritTable.DefaultCell.Border = 0;      // Die Grenzen der Tabelle unsichtbar machen
                CritTable.SetWidths(widths);          //Relationale Breiten der Tabellenspalten fixen
                CritTable.HeaderRows = 1;            //Anzeigen der Überschriften auf jeder Seite des Dokuments
                CritTable.AddCell(new Paragraph("Anforderungen des Anwenders", arial));
                CritTable.AddCell(new Paragraph(" ", arial));                   //Leere Zelle sorgt für Abstand - Formatierungszwecke
                CritTable.AddCell(new Paragraph("*", arial));
                CritTable.AddCell(new Paragraph("Kommentar", arial));
           
                CritTable.HorizontalAlignment = 0;
                CritTable.TotalWidth = 650f; //Totale Breite der "Tabelle"
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

            

                //Übergebene Liste von Methode "GetSortedCriterionStructure()" in Liste sortedProjectCriterionStructure schreiben

                List<ProjectCriterion> sortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);

                //Foreach-Schleife druckt sortierte Kriterien auf das Pdf Dokument

                // dict: layer => enum
                Dictionary<int, int> enumerations = new Dictionary<int, int>() { { 1, 0 } };

                foreach (ProjectCriterion projectCriterion in sortedProjectCriterionStructure)
                {

                    //Definieren der intend Variable um die richtige "Einrückung" auf dem Pdf Dokument erzielen zu können
                    int layer = projectCriterion.Layer_Depth;
                    int factor = 25;
                    int intend;

                    intend = layer * factor;
                    
                    
                    string enumeration = GetEnumerationForCriterion(ref enumerations, layer);
                    

                    //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                    Font CritStructFont = FontFactory.GetFont("Arial", 10);

                    //string der dem Paragraphen übergeben wird, mit den Enumerations und den Kriterien in einer Zeile
                    string CritsEnumeration = "[" +enumeration+"]" + " " + projectCriterion.Criterion.Description.ToString();

                    Paragraph para = new Paragraph(CritsEnumeration, CritStructFont);
                    para.IndentationLeft = intend;      //Einrückungsfaktor, das zugehörige Kriterien untereinander stehen
                    PdfPCell Crits = new PdfPCell();
                    Crits.AddElement(para);
                    
                    Crits.Border = 0;                   //Grenzen der Pdf Zellen auf 0, d.h. Ränder sind unsichtbar

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

                    CritTable.AddCell("");
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
