using NWAT.DB;
using NWAT.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAT
{
    public partial class aktuellesProjekt_View : Form
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

        private ProjectController _projectController;


        public aktuellesProjekt_View(int projectId)
        {
         //   _projectController = new ProjectController();
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();
            
        }

        private void aktuellesProjekt_Load(object sender, EventArgs e)
        {
            using (ProjectController AktProjForm = new ProjectController())
            {
                Project proj = AktProjForm.GetProjectById(Project.Project_Id);
                String ProjName = proj.Name;
                String ProjDesc = proj.Description;
                MessageBox.Show(ProjName + ProjDesc);
                label_CurrProjNameShow.Text = this.Project.Name; //proj.Name;
                label_CurrProjDescShow.Text = this.Project.Description; //proj.Description;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_CurrProjProds_Enter(object sender, EventArgs e)
        {

        }
        private void OpenCritAssign()
        {

        }
        private void OpenCritStructure()
        {

        }

        private void btn_CurrProjKritAssign_Click(object sender, EventArgs e)
        {
            
            
            ProjCritAssign_View ProjCritAssign = new ProjCritAssign_View(Project.Project_Id);
            ProjCritAssign.Show();
        }

        private void btn_CurrProjCritStruShow_Click(object sender, EventArgs e)
        {
            ProjCritShow_View ProjCritShow = new ProjCritShow_View();
            ProjCritShow.Show();
        }

        private void btn_CurrProjCritStruUpdate_Click(object sender, EventArgs e)
        {
            ProjCritStruUpdate_View ProjCritStruUpdate = new ProjCritStruUpdate_View();
            ProjCritStruUpdate.Show();
        }

        private void btn_CurrProjCritStruPrint_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjCritStruBalance_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjCritStruEval_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjProdAssign_Click(object sender, EventArgs e)
        {
            ProjProdAssign_View ProjProdAssign = new ProjProdAssign_View(Project.Project_Id);
            ProjProdAssign.Show();

       //     ProjectProductAssign_View ProjectProductAssign = new ProjectProductAssign_View(Project.Project_Id);
       //     ProjectProductAssign.Show();
        }

        private void btn_CurrProjProdFulfCapt_Click(object sender, EventArgs e)
        {
            ProjCritProdFulfilment_View ProjCritProdFulfillment = new ProjCritProdFulfilment_View();
            ProjCritProdFulfillment.Show();
        }

        private void btnCurrProjProdFulfPrint_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjProdAnalShow_Click(object sender, EventArgs e)
        {

        }

        private void btn_Balance_Click(object sender, EventArgs e)
        {
            ProjCritBalance_View ProjCritBalance = new ProjCritBalance_View(Project.Project_Id);
            ProjCritBalance.Show();
        }
    }
}
