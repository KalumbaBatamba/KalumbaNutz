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

/// <summary>
/// 
/// </summary>
/// Erstellt von Adrian Glasnek
/// 


namespace NWAT.Printer
{
    public class CriterionStructurePrinter
    {

        //Methode um allen in der Datenbank gelisteten Projekte in einer PDF auszugeben

        public void CritStructPrinter()
        {

            ProjectCriterionController cont = new ProjectCriterionController();
            List<ProjectCriterion> projCrits = cont.GetAllProjectCriterionsForOneProject(1);

            //SaveFileDialog um Dokument am gewünschten Ort speicher zu können 
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();

                PdfPTable table = new PdfPTable(2);

                //Überschrift setzen
               
                Paragraph heading = new Paragraph("Kriterienstruktur                                                                                                                                  *");

                //Abstand nach Übersicht bis zur Tabelle
                heading.SpacingAfter = 18f;
                doc.Add(heading);
                         
               //Schleife um Daten aus Datenbank zu holen

                foreach (ProjectCriterion proj in projCrits)
                {
                    int layer = proj.Layer_Depth;

                    if (layer == 1)
                    {

                        Paragraph intend = new Paragraph(proj.Criterion.Description.ToString());

                        doc.Add(intend);
                    }

                    if (layer == 2)
                    {
                        Paragraph intend = new Paragraph(proj.Criterion.Description.ToString());
                        intend.IndentationLeft = 25f;
                        doc.Add(intend);
                    }

                    if (layer == 3)
                    {
                        Paragraph intend = new Paragraph(proj.Criterion.Description.ToString());
                        intend.IndentationLeft = 50f;
                        doc.Add(intend);
                    }
               
                    
                }

                doc.Close();

                MessageBox.Show("PDF erfolgreich angelegt");

                Application.Exit();
            }
        }

    }
}
