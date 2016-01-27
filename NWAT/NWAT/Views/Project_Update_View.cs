using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NWAT.DB;
namespace NWAT
{
    public partial class Project_Update_View : Form
    {
        private Project _project;

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }

        private ProjectController _projectCont;

        public ProjectController ProjectCont
        {
            get { return _projectCont; }
            set { _projectCont = value; }
        }



   //     private ProjectController projCont;
        public Project_Update_View(int projectId)
        {
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);

           // this.ProjectCont = new ProjectController();
            InitializeComponent();
        }

        private void btn_ProjUpdate_Click(object sender, EventArgs e)
        {
            Project projUpd = ProjectCont.GetProjectById(Project.Project_Id);//new Project();
            projUpd.Project_Id = this.Project.Project_Id;
            projUpd.Name = textBox_ProjNameUpdate.Text;
            projUpd.Description = textBox_ProjDescUpdate.Text;
            ProjectCont.UpdateProjectInDb(projUpd);
            this.Close();
        }
        private void UpdateProject()
        {
           
        }

        private void Project_Update_View_Load(object sender, EventArgs e)
        {

            using (ProjectController UpdVieLoad = new ProjectController())
            {
                Project proj = UpdVieLoad.GetProjectById(Project.Project_Id);
                String ProjName = this.Project.Name;
                String ProjDesc = this.Project.Description;//proj.Description;
       //         MessageBox.Show(ProjName + ProjDesc);
                textBox_ProjNameUpdate.Text = this.Project.Name;//ProjName;
                textBox_ProjDescUpdate.Text = this.Project.Description; //ProjDesc;
            }
            //Project proj = ProjectCont.GetProjectById(aktRowProj.ProjID);
            //String ProjName = proj.Name;
            //String ProjDesc = proj.Description;
            //MessageBox.Show(ProjName + ProjDesc);
            //textBox_ProjNameUpdate.Text = ProjName;
            //textBox_ProjDescUpdate.Text = ProjDesc;
        
        //}
            this.FormClosing += new FormClosingEventHandler(Project_Update_View_FormClosing);
        }
        void Project_Update_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            //your code here
            Projektverwaltung_View start = new Projektverwaltung_View ();
            start.Show();
        }
    }
}
