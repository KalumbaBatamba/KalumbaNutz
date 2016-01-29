using NWAT.DB;
using NWAT.HelperClasses;
using System;
using System.Windows.Forms;
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

        private Form parentView;


        public Project_Update_View(Form parentView, int projectId)
        {
            this.parentView = parentView;
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btn_ProjUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                Project projUpd = ProjectCont.GetProjectById(Project.Project_Id);
                projUpd.Project_Id = this.Project.Project_Id;

                bool forbiddenCharInStrings = false;
                if (CommonMethods.CheckIfForbiddenDelimiterInDb(textBox_ProjNameUpdate.Text) ||
                    CommonMethods.CheckIfForbiddenDelimiterInDb(textBox_ProjNameUpdate.Text))
                {
                    MessageBox.Show(CommonMethods.MessageForbiddenDelimiterWasFoundInText());
                }
                else
                {

                    if (CommonMethods.CheckIfSpecialCharsAreInString(textBox_ProjNameUpdate.Text))
                    {
                        forbiddenCharInStrings = true;
                        MessageBox.Show(CommonMethods.MessageForbiddenDelimiterWasFoundInProjectName());
                    }
                    if (CommonMethods.CheckIfForbiddenDelimiterInDb(textBox_ProjNameUpdate.Text))
                    {
                        forbiddenCharInStrings = true;
                        MessageBox.Show(CommonMethods.MessageForbiddenDelimiterWasFoundInText());
                    }
                    if (!forbiddenCharInStrings)
                    {
                        projUpd.Name = textBox_ProjNameUpdate.Text;
                        projUpd.Description = textBox_ProjDescUpdate.Text;
                        ProjectCont.UpdateProjectInDb(projUpd);
                        this.Close();  
                    }
                                     
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void UpdateProject()
        {
           
        }

        /// <summary>
        /// Handles the Load event of the Project_Update_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Project_Update_View_Load(object sender, EventArgs e)
        {
            try{

            using (ProjectController UpdVieLoad = new ProjectController())
            {
                Project proj = UpdVieLoad.GetProjectById(Project.Project_Id);
                String ProjName = this.Project.Name;
                String ProjDesc = this.Project.Description;
                textBox_ProjNameUpdate.Text = this.Project.Name;
                textBox_ProjDescUpdate.Text = this.Project.Description;
            }
            this.FormClosing += new FormClosingEventHandler(Project_Update_View_FormClosing);
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }
        /// <summary>
        /// Handles the FormClosing event of the Project_Update_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void Project_Update_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            try{
                this.parentView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
