using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NWAT.Printer
{


    /// <summary>
    /// 
    /// </summary>
    /// Erstellt von Adrian Glasnek
    /// 

    

    public class ProjectDataPrinter
    {

        //Methode um allen in der Datenbank gelisteten Projekte in einer PDF auszugeben

        public void ProjectDataPrint(){

            ProjectController criContr = new ProjectController();
            List<Project> x = criContr.GetAllProjectsFromDB();

            //SaveFileDialog um Dokument am gewünschten Ort speicher zu können 
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();

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

                doc.Add(heading);




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
                doc.Add(table);
                doc.Close();

                MessageBox.Show("PDF erfolgreich angelegt");
                Application.Exit();
            }
        }
        
    }

}

