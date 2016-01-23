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
/// Klasse um eine Rechtschreibprüfung der Kriterienbeschreibungen auf Basis einer ausgegebenen Textdatei durchführen zu können
/// </summary>
/// Erstellt von Adrian Glasnek
/// 

namespace NWAT.Printer
{
    public class SpellVerification
    {
        private SaveFileDialog SfdCriterionTextFile = new SaveFileDialog();
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
         public SpellVerification(int projectId)
        {
             this.ProjCritContr = new ProjectCriterionController();
             ProjectController projCont = new ProjectController();
             this.Project = projCont.GetProjectById(projectId);
        }

        public void CreateTextFileWithCriterions()
        {
            //Benötigte Verbindung um Daten aus der Datenbank zu holen

            List<ProjectCriterion> baseCriterions = this.ProjCritContr.GetBaseProjectCriterions(this.Project.Project_Id); //Get all base Criterions
            List<ProjectCriterion> sortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);
            Dictionary<int, int> enumerations = new Dictionary<int, int>() { { 1, 0 } };

            SfdCriterionTextFile.Filter = "Text File |*.txt";
            if (SfdCriterionTextFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter FileWriter = new StreamWriter(SfdCriterionTextFile.OpenFile());

                FileWriter.Write("Projektkriterien zum Projekt " + this.Project.Name + "\r\n\r\n");
                FileWriter.Write("ID Beschreibung\r\n\r\n");

                foreach (ProjectCriterion projectCriterion in sortedProjectCriterionStructure)
                {
                    
                    //string der dem Paragraphen übergeben wird, mit den Enumerations und den Kriterien in einer Zeile
                    string CritsEnumeration = projectCriterion.Criterion.Criterion_Id + "  " + projectCriterion.Criterion.Description.ToString() + "\r\n";

                    FileWriter.Write(CritsEnumeration);
      
                }
          
                FileWriter.Dispose();
                FileWriter.Close();

            }

            System.Diagnostics.Process.Start(SfdCriterionTextFile.FileName);
        }

    }
}
