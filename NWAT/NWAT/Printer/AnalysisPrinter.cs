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
/// Klasse um die Analyseergebnisse inklusive der Kriterienstruktur in einer PDF Datei auszugeben
/// </summary>
/// Erstellt von Adrian Glasnek

namespace NWAT.Printer
{
    class AnalysePrinter
    {
       
        Document FulfillmentPrinter = new Document(iTextSharp.text.PageSize.A4.Rotate());       //Eigentliches Dokument erstellen vom typ Document
        SaveFileDialog SfdFulfillment = new SaveFileDialog();       //Objekt vom Typ SaveFileDialog
        private Project _projectid;
        private Product _productid;
        private Fulfillment _fulfilled;

        //Benötigte Properties für Project, Product und Fulfillment
        public Project Project
        {
            get { return _projectid; }
            set { _projectid = value; }
        }

        public Product Product
        {
            get { return _productid; }
            set { _productid = value; }
        }

        public Fulfillment Fulfillment
        {
            get { return _fulfilled; }
            set { _fulfilled = value; }
        }

        private List<Fulfillment> _fufiList;

        public List<Fulfillment> FufiList
        {
            get { return _fufiList; }
            set { _fufiList = value; }
        }



        private ProjectCriterionController _projectCriterionController;
        public ProjectCriterionController ProjCritContr
        {
            get { return _projectCriterionController; }
            set { _projectCriterionController = value; }
        }

        private ProductController _projProduct;
        public ProductController ProjProduct
        {
            get { return _projProduct; }
            set { _projProduct = value; }
        }

        private FulfillmentController _fulfillmentController;
        public FulfillmentController FulFillContr
        {
            get { return _fulfillmentController; }
            set { _fulfillmentController = value; }
        }

        //Konstruktor
        public AnalysePrinter(int projectId)
        {
            this.ProjCritContr = new ProjectCriterionController();
            ProjectController projCont = new ProjectController();
            this.Project = projCont.GetProjectById(projectId);

        }

        /// <summary>
        /// Methode um Pdf erstellen etc.
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public void PrintAnalysisResult()
        {
           
            ProjectProductController projprodContr = new ProjectProductController();
            List<ProjectProduct> allProductsForThisProject = projprodContr.GetAllProjectProductsForOneProject(this.Project.Project_Id);
            List<ProjectCriterion> baseCriterions = this.ProjCritContr.GetBaseProjectCriterions(this.Project.Project_Id); //Get all base Criterions

            SfdFulfillment.Filter = "Pdf File |*.pdf";
            if (SfdFulfillment.ShowDialog() == DialogResult.OK)
            {
                
                FulfillmentPrinter.SetMargins(50, 200, 50, 125); //Seitenränder definieren
                try //try catch um Fehler abzufangen wenn eine gleichnamige PDF noch geöffnet ist
                {
                    PdfWriter writer = PdfWriter.GetInstance(FulfillmentPrinter, new FileStream(SfdFulfillment.FileName, FileMode.Create));
                    writer.PageEvent = new PdfPageEvents();
                }
                catch (Exception) { MessageBox.Show(String.Format(SfdFulfillment.FileName + " noch geöffnet! Bitte Schließen!")); }

                //Dokument öffnen um es bearbeiten zu können
                FulfillmentPrinter.Open();

                //Überschrift und nötige Formatierung setzen (Schriftart, Fett Druck, Schriftgröße)        
                Font arialBold = FontFactory.GetFont("Arial_BOLD", 10, Font.BOLD);
                Font products = FontFactory.GetFont("Arial_BOLD", 7, Font.NORMAL);
                //Erstellen einer Pdf Tabelle in der die Daten aus der Datenbank ausgegeben werden

                //int der die Anzahl der festen Spalten und die variable Anzahl der Produkte enthält
                int countProducts = allProductsForThisProject.Count();

                //Erstellen der PdfTable
                PdfPTable CritTable = new PdfPTable(countProducts + 4);

                //int der die Anzahl der festen Spalten und die variable Anzahl der Produkte enthält
                int numberOfCells = countProducts + 4;
               
                // Je nach Anzahl der Produkte in der Datenbank wir die relative Spaltenbreite gesetzt 
                if (numberOfCells == 3) { float[] widths = { 20f, 2f, 2f, }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 4) { float[] widths = { 20f, 2f, 1f, 3f, }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 5) { float[] widths = { 20, 2f, 2f, 3f, 3f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 6) { float[] widths = { 20, 2f, 2f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 7) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 8) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 9) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 10) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 11) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells == 12) { float[] widths = { 20f, 2f, 2f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 3f }; CritTable.SetWidths(widths); ;}
                if (numberOfCells >= 13) { throw new System.ArgumentException("Die Anzahl der maximal darstellbaren Produkte auf einer Seite wurde überschritten!"); }
                //Ab einer Anzahl von >8 Produkten wird eine Fehlermeldung ausgeworfen das nicht mehr Produkte auf die Seite des Pdfs passen
                         
                CritTable.DefaultCell.Border = 1;               // Die Grenzen der Tabelle unsichtbar machen
                CritTable.HeaderRows = 1;                     //Anzeigen der ersten Zeilen als Überschrift auf jeder Seite des Dokuments

                CritTable.SpacingBefore = 20f;      //Platz zwischen Produktlegende und der Tabelle
                CritTable.AddCell(new Paragraph("Nutzwert - Analyse", arialBold));
                CritTable.AddCell(new Paragraph(" "));                   //Leere Zelle sorgt für Abstand zwischen Header und Erfüllungen 
                CritTable.AddCell(new Paragraph("Gew.", products));      //Spaltenüberschriften
                CritTable.AddCell(new Paragraph("Proz.", products));

                
                
                //Zählt wieviele Produkte in der Datenbank liegen und schreibt dementsprechend viele Spalten auf das Pdf
                for (int i = 1; i <= allProductsForThisProject.Count(); i++)
                {
                    string prodHeader = "Prd." + i.ToString(); 
                    CritTable.AddCell(new Paragraph(prodHeader,  products));      
                }

                CritTable.HorizontalAlignment = 0;
                //Totale Breite der "Tabelle"
                CritTable.TotalWidth = 700f; 
                CritTable.LockedWidth = true;

                //Methodenaufruf
                PrintCriterionStructure(ref CritTable);

                //Tabelle zum Dokument Adden
                FulfillmentPrinter.Add(CritTable);

                //Close Dokument - Bearbeitung Beenden
                FulfillmentPrinter.Close();

                //Aufrufen der Hilfsmethode (aus Klasse CriterionStructurePrinter)- Seitenzahl und den Projektnamen auf Pdf     
                GetPageNumber(SfdFulfillment, 800);

                //Erfolgsmeldung
                MessageBox.Show("Pdf erfolgreich erstellt!");

                //PDf wird automatisch geöffnet nach der erfolgreichen Speicherung
                System.Diagnostics.Process.Start(SfdFulfillment.FileName);

            }
        }

        /// <summary>
        /// Eigentliche Print Methode um Pdf zu befüllen
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        private void PrintCriterionStructure(ref PdfPTable CritTable)
        {
            //Zugirff auf Erfüllungen der Kriterien für die Produkte aus der Datenbank
            FulfillmentController fufiCont = new FulfillmentController();
            List<Fulfillment> fufiList = fufiCont.GetAllFulfillmentsForOneProject(this.Project.Project_Id);

            //Zugirff auf Liste aller Produkte aus der Datenbank
            ProjectProductController projprodContr = new ProjectProductController();
            List<ProjectProduct> allProductsForThisProject = projprodContr.GetAllProjectProductsForOneProject(this.Project.Project_Id);

            //Übergebene Liste von Methode "GetSortedCriterionStructure()" in Liste sortedProjectCriterionStructure schreiben
            List<ProjectCriterion> sortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);
            
            // Generische Liste - Dictionary Wertepaar vom Typ int - Schlüssel und Wert 
            Dictionary<int, int> enumerations = new Dictionary<int, int>() { { 1, 0 } };

            //Variablen die in den unten folgenden foreach-Schleifen benötigt werden
            int iCount = 0;  
            int countCounter = 1;
            int i = 1;

            //Paragraph um Namen der Produkte mit den Abkürzungen in der Tabelle verbinden zu können
            //Font für die Ausgabe der Produktlegende
            Paragraph productName = new Paragraph();            
            Font prodNameFont = FontFactory.GetFont("Arial", 9);    
            productName.Font = prodNameFont;
                             
            //Foreach-Schleife druckt sortierte Kriterien auf das Pdf Dokument
            foreach (ProjectCriterion projectCriterion in sortedProjectCriterionStructure)
            {
                //Definieren der intend Variable um die richtige "Einrückung" auf dem Pdf Dokument erzielen zu können
                int layer = projectCriterion.Layer_Depth;
                int factor = 25;
                int intend;
                intend = layer * factor;

                //Aufzählunszahlen für die Kriterienstruktur in einen string schreiben
                string enumeration = GetEnumerationForCriterion(ref enumerations, layer);

                //Schriftgröße der angezeigten Kriterienstruktur bestimmen
                Font CritStructFont = FontFactory.GetFont("Arial", 10);
                Font numbers = FontFactory.GetFont("Arial_BOLD", 7, Font.NORMAL);

                //Paragraph der die Zellen befüllt
                string CritsEnumeration = "[" + enumeration + "]" + " " + projectCriterion.Criterion.Description.ToString();

                Paragraph para = new Paragraph(CritsEnumeration, CritStructFont);
                //Einrückungsfaktor, das zugehörige Kriterien untereinander stehen
                para.IndentationLeft = intend;
                //Neue Tabellenzelle in der die Kriterienbeschreibung reingeschrieben wird
                PdfPCell Crits = new PdfPCell();
                //Der Zelle den Paragraphen übergeben
                Crits.AddElement(para);
                //Anzeigen von Linien im Pdf
                Crits.Border = 1;                   

                //Die Kriterienstruktur den zellen hinzufügen
                CritTable.AddCell(Crits);
                CritTable.AddCell("");
                CritTable.AddCell(new Paragraph(projectCriterion.Weighting_Cardinal.ToString(), numbers));      //Weighting Cardinal
                try
                {
                    double percentageLayer = projectCriterion.Weighting_Percentage_Layer.Value * 100;
                    CritTable.AddCell(new Paragraph(percentageLayer.ToString(), numbers));
                }
                catch (Exception e) {throw new Exception ("Der Wert einer Gewichtung unter Geschwisterkriterien darf nicht 'NULL' betragen", e); }
     

                //if Schleife damit alle Produktnamen korrekt auf dem Pdf ausgegeben werden
                if (iCount == countCounter)
                {                    
                    FulfillmentPrinter.Add(productName);   //Produktname der vergliechenen Produkte auf dem Dokument anzeige
                }

                //foreach Schleife um die Erfüllungen für alle in der Datenbank hinterlegten Produkte aus das Pdf zu drucken
                foreach (ProjectProduct projprod in allProductsForThisProject)
                {
                    //try catch Anweisung um Fehler abzufangen. Fehler: Für das Produkt sind keine oder nicht alle Erfülungen in der DB hinterlegt
                    try         
                    {
                        //Abfrage der Erfüllungen
                        Fulfillment fulfillForThisProdAndThisCrit = fufiList.Single(
                                fufi => fufi.Project_Id == projectCriterion.Project_Id &&
                                        fufi.Product_Id == projprod.Product_Id &&
                                        fufi.Criterion_Id == projectCriterion.Criterion.Criterion_Id);
                        
                        //Wenn ein Kriterium erfüllt ist wird ein x gesetzt ansonsten ein -
                        if (fulfillForThisProdAndThisCrit.Fulfilled == true)
                        {
                            CritTable.AddCell(new Paragraph("x", CritStructFont));
                        }
                        else
                        {
                            CritTable.AddCell(new Paragraph("-", CritStructFont));
                        }
                    }

                    catch { throw new ApplicationException("Warnung!\n Nicht für alle Produkte des Projekts sind Erfüllungen hinterlegt! Bitte überprüfen Sie Ihre Eingaben! "); }

                        //Gleichzeitig wird noch gesagt um welche Produkte es sich handelt
                        productName.Add("Prd. " + i.ToString()+ "     -     "+ projprod.Product.Name + "\n");
       
                    i++;            

                }       
                iCount++;       //Erhöhe Variable Count - Relevant für if-Schleife zum Printen der Produktnamen auf dem Pdf         
            }
           
        }

        /// <summary>
        /// Methode um Kriterien eine Nummerierung zu geben
        /// </summary>
        /// 
        /// Erstellt von Adrian Glasnek

        public string GetEnumerationForCriterion(ref Dictionary<int, int> enumerations, int layer)
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
        /// Methode um Nummern auf Pdf zu drucken
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
