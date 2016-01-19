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
using iTextSharp.text.pdf.draw;

/// <summary>
/// Klasse um die Analyseergebnisse in einer PDF Datei zu zeigen
/// </summary>
/// Erstellt von Adrian Glasnek

namespace NWAT.Printer
{
    class AnalysisPrinter
    {
       
        public void PrintAnalysis()
        {
            //Aufruf der Methode Analyse um Ergebnisse zu berechnen
            Analysis analysisObject = new Analysis();
            analysisObject.Analyse();

            //SaveFileDialog einrichten

            SaveFileDialog SfdAnalysis = new SaveFileDialog();
            SfdAnalysis.Filter = "Pdf File |*.pdf";
            if (SfdAnalysis.ShowDialog() == DialogResult.OK)
            {
                //Dokument erstellen - Formatierungen angeben

                Document AnalysisPrinterDoc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                
                try //try catch um Fehler abzufangen wenn eine gleichnamige PDF noch geöffnet ist
                {
                    PdfWriter writer = PdfWriter.GetInstance(AnalysisPrinterDoc, new FileStream(SfdAnalysis.FileName, FileMode.Create));
                    writer.PageEvent = new PdfPageEvents();
                }
                catch (Exception){MessageBox.Show(String.Format("{0}" + " noch geöffnet! Bitte Schließen!", SfdAnalysis.FileName)); }
                    
                    AnalysisPrinterDoc.Open();

                //Größe der Überschrift, Schriftart und Überschrifttext festlegen
                Font arial = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
                Paragraph heading = new Paragraph("Analyseergebnis", arial);

                //Abstand nach Übersicht bis zur Tabelle
                heading.SpacingAfter = 18f;
                AnalysisPrinterDoc.Add(heading);

                
                MessageBox.Show("PDF erfolgreich angelegt");
                AnalysisPrinterDoc.Close();

                //Aufrufen der Hilfsmethode um Seitenzahl auf das PDF Dokument zu schreiben - Dokument und Einrückung der Seitenzahl wird der Methode übergeben
                //CriterionStructurePrinter PageNumberObject = new CriterionStructurePrinter();
                //PageNumberObject.GetPageNumber(SfdAnalysis, 568);

                //PDf wird automatisch geöffnet nach der erfolgreichen Speicherung

                System.Diagnostics.Process.Start(SfdAnalysis.FileName);

            }

        }
    }
}
