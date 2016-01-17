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
using iTextSharp.text.pdf.draw;

/// <summary>
/// Klasse um die aktuellen in der Datenbank vorhanden Projekte in einer Liste auszugeben
/// </summary>
/// Erstellt von Adrian Glasnek
/// 


namespace NWAT.Printer
{

    
    public class ProjectDataPrinter
    {

        //Methode um allen in der Datenbank gelisteten Projekte in einer PDF auszugeben

        public void ProjectDataPrint(){

            ProjectController criContr = new ProjectController();
            List<Project> x = criContr.GetAllProjectsFromDB();

            //SaveFileDialog um Dokument am gewünschten Ort speicher zu können 
            SaveFileDialog sfdProjectData = new SaveFileDialog();
            sfdProjectData.Filter = "Pdf File |*.pdf";
            if (sfdProjectData.ShowDialog() == DialogResult.OK)
            {

                Document projectDataDoc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter writer = PdfWriter.GetInstance(projectDataDoc, new FileStream(sfdProjectData.FileName, FileMode.Create));
                projectDataDoc.Open();

                PdfPTable table = new PdfPTable(3);

                //Überschrift setzen
                Paragraph heading = new Paragraph("Projekte in Datenbank");

                //Abstand nach Übersicht bis zur Tabelle
                heading.SpacingAfter = 18f;

                

                //ProjectCriterionController cont = new ProjectCriterionController();
                //ProjectCriterion crit = cont.GetProjectCriterionByIds(2, 2);

                //int layer = crit.Layer_Depth;
                //double intendFactor = 10;
                //double intend = layer * intendFactor;

                //heading.IndentationLeft = (Convert.ToSingle(intend));

                projectDataDoc.Add(heading);




                //Breite der einzelnen Zellen

                table.TotalWidth = 316f;

                //Lock von Table Breite

                table.LockedWidth = true;



                //Proportionen der Tabelle

                float[] widths = new float[] { 1f, 2f, 3f };

                table.SetWidths(widths);

                table.HorizontalAlignment = 0;



                //Lass Platz zwischen Tabelleneinträgen

                table.SpacingBefore = 20f;

                table.SpacingAfter = 30f;

                //Überschriften für die Tabellenspalten

                table.AddCell("ID");

                table.AddCell("Projekt");

                table.AddCell("Beschreibung");

                //Schleife um Daten aus Datenbank zu holen

                foreach (Project proj in x)
                {

                    table.AddCell(proj.Project_Id.ToString());
                    table.AddCell(proj.Name.ToString());
                    table.AddCell(proj.Description.ToString());

                }
                projectDataDoc.Add(table);
                projectDataDoc.Close();

                MessageBox.Show("PDF erfolgreich angelegt");

                System.Diagnostics.Process.Start(sfdProjectData.FileName);
                Application.Exit();
            }
        }
        
    }

}

