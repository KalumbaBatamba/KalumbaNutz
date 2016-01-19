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
    public partial class Project_Show_View : Form
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
        
      public Project_Show_View(int projectId)
        {
      //      this.prodCont = new ProductController();
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();
        }

        private void Project_Show_Form_Load(object sender, EventArgs e)
        {
            Project proj = ProjectCont.GetProjectById(Project.Project_Id);
            String ProjName = proj.Name;
            String ProjDesc = proj.Description;
            MessageBox.Show(ProjName + ProjDesc);
            label_ProjShowName.Text = proj.Name;
            label_ProjShowDesc.Text = proj.Description;
        }
        private void ShowProject()
        {

        }

        private void btn_ProjShowClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
