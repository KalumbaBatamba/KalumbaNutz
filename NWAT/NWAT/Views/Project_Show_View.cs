using NWAT.DB;
using System;
using System.Windows.Forms;
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

        private Form parentView;
        
      public Project_Show_View(Form parentView, int projectId)
        {
            this.parentView = parentView;
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();
        }

      /// <summary>
      /// Handles the Load event of the Project_Show_Form control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
      /// Erstellt von Veit Berg, am 27.01.16
        private void Project_Show_Form_Load(object sender, EventArgs e)
        {
            try{
            using (ProjectController ProjShowForm = new ProjectController())
            {
                Project proj = ProjShowForm.GetProjectById(Project.Project_Id);
                String ProjName = proj.Name;
                String ProjDesc = proj.Description;
                label_ProjShowName.Text = this.Project.Name; 
                label_ProjShowDesc.Text = this.Project.Description; 
            }
            this.FormClosing += new FormClosingEventHandler(Project_Show_View_FormClosing);
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }
        /// <summary>
        /// Handles the FormClosing event of the Project_Show_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void Project_Show_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            try{
                this.parentView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void ShowProject()
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_ProjShowClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjShowClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
