using iTextSharp.text;
using NWAT.DB;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


/// <summary>
/// Klasse um eine Textdatei zu erstellen um die Kriterienbeschreibungen einer Rechtschreibprüfung unterziehen zu können
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

         /// <summary>
         /// Methode zur Erstellung der Textdatei
         /// </summary>
         /// Erstellt von Adrian Glasnek
         /// 

        public void CreateTextFileWithCriterions()
        {
            //Zugriff auf benötigte Listen um Daten aus der Datenbank zu holen
            List<ProjectCriterion> baseCriterions = this.ProjCritContr.GetBaseProjectCriterions(this.Project.Project_Id); //Get all base Criterions
            List<ProjectCriterion> sortedProjectCriterionStructure = this.ProjCritContr.GetSortedCriterionStructure(this.Project.Project_Id);
            
            //SaveFileDialog starten 
            SfdCriterionTextFile.Filter = "Text File |*.txt";
            if (SfdCriterionTextFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter FileTextWriter = new StreamWriter(SfdCriterionTextFile.OpenFile());

                FileTextWriter.Write("Projektkriterien zum Projekt " + this.Project.Name + "\r\n\r\n");
                FileTextWriter.Write("ID Beschreibung\r\n\r\n");

                foreach (ProjectCriterion projectCriterion in sortedProjectCriterionStructure)
                {
                    //string der dem Paragraphen übergeben wird, mit den Kriterien
                    string Crits = projectCriterion.Criterion.Criterion_Id + "  " + projectCriterion.Criterion.Description.ToString() + "\r\n";
                    FileTextWriter.Write(Crits);
                }
                FileTextWriter.Dispose();
                FileTextWriter.Close();
            }
            //Text Dokument nach erfolgreicher Ablage öffnen
            System.Diagnostics.Process.Start(SfdCriterionTextFile.FileName); 
        }

    }
}
