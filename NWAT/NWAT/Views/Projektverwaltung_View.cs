using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace NWAT
{
    public partial class Projektverwaltung_View : Form
    {
        private Form parentView;
        
        private ProjectController projCont;
        public Projektverwaltung_View(Form parentView)
        {
            this.parentView = parentView;
            this.projCont = new ProjectController();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Load event of the Projektverwaltung_Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Projektverwaltung_Form_Load(object sender, EventArgs e)
        {
            try{
            using (ProjectController Projverw = new ProjectController()) 
            {
                List<Project> ProjList = Projverw.GetAllProjectsFromDB();
                var bindingList = new BindingList<Project>(ProjList);
                var source = new BindingSource(bindingList, null);
                comboBox_SelectProject.DataSource = ProjList;
                comboBox_SelectProject.DisplayMember = "Name";
                comboBox_SelectProject.ValueMember = "Project_ID";
            }
            
            this.FormClosing += new FormClosingEventHandler(Projektverwaltung_View_FormClosing);
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }
        /// <summary>
        /// Handles the FormClosing event of the Projektverwaltung_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void Projektverwaltung_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentView.Show();
        }


        private void OpenViewCreateNewProject()
        {

        }

        private void GetAllProjects()
        {

        }

        private void OpenViewShowActivProject()
        {

        }

        private void OpenViewChangeActiveProject()
        {

        }
        private void PrintActiveProject()
        {

        }
        private void ExportActiveProject()
        {

        }
        private void ImportProject()
        {

        }
        private void OpenViewUpdateActiveProject()
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_ProjectStartCreate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjectStartCreate_Click(object sender, EventArgs e)
        {
            try{
            Project_Create_View ProjectCreate = new Project_Create_View(this);
            ProjectCreate.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProjectModify control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjectModify_Click(object sender, EventArgs e)
        {
            try{
            int selectedIndex = comboBox_SelectProject.SelectedIndex;
            Project selectedItem = (Project)comboBox_SelectProject.SelectedItem;
            aktuellesProjekt_View AktProjView = new aktuellesProjekt_View(this, selectedItem.Project_Id);
            AktProjView.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProjectShow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjectShow_Click(object sender, EventArgs e)
        {
            try{
            int selectedIndex = comboBox_SelectProject.SelectedIndex;
            Project selectedItem = (Project)comboBox_SelectProject.SelectedItem;
            Project_Show_View ProjectShow = new Project_Show_View(this, selectedItem.Project_Id);
            ProjectShow.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProjectUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjectUpdate_Click(object sender, EventArgs e)
        {
            try{
            int selectedIndex = comboBox_SelectProject.SelectedIndex;
            Project selectedItem = (Project)comboBox_SelectProject.SelectedItem;
            Project_Update_View ProjectUpdate = new Project_Update_View(this, selectedItem.Project_Id);
            ProjectUpdate.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProjImport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjImport_Click(object sender, EventArgs e)
        {
            string exportFilePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zip Files|*.zip";
            ofd.Title = "Wähle Exportdatei";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                exportFilePath = ofd.FileName;
            }
            if (exportFilePath != "")
            {
                try
                {
                    ProjectImporter projImporter = new ProjectImporter(exportFilePath);
                    projImporter.ImportWholeProject();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            RefreshDropDown();
        }

        /// <summary>
        /// Handles the Click event of the btn_refresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshDropDown();
        }

        /// <summary>
        /// Refreshes the combobox.
        /// </summary>
        /// Erstellt von Joshua Frey, am 29.01.2016
        public void RefreshDropDown()
        {
            try
            {
                using (ProjectController RefList = new ProjectController())
                {
                    List<Project> ProjList = RefList.GetAllProjectsFromDB();
                    var bindingList = new BindingList<Project>(ProjList);
                    var source = new BindingSource(bindingList, null);
                    comboBox_SelectProject.DataSource = ProjList;
                    comboBox_SelectProject.DisplayMember = "Name";
                    comboBox_SelectProject.ValueMember = "Project_ID";
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void comboBox_SelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// Handles the Click event of the btn_ProjectExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Joshua Frey, am 28.01.2016
        private void btn_ProjectExport_Click(object sender, EventArgs e)
        {
            Project selectedProject = (Project)comboBox_SelectProject.SelectedItem;
            if (selectedProject == null)
            {
                MessageBox.Show("Bitte wählen Sie erst ein bestehendes Project aus dem Dropdownfeld aus.");
            }
            else
            {
                int projectId = selectedProject.Project_Id;
                string folderPathForExport = "";
                FolderBrowserDialog folderBrowserDialogForExportFolder = new FolderBrowserDialog();

                if (folderBrowserDialogForExportFolder.ShowDialog() == DialogResult.OK)
                {
                    folderPathForExport = folderBrowserDialogForExportFolder.SelectedPath;
                }

                if (folderPathForExport != "" && projectId != 0)
                {
                    try
                    {
                        ProjectExporter projExporter = new ProjectExporter(projectId, folderPathForExport);
                        projExporter.ExportWholeProject();

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
            RefreshDropDown();
        }
    }
    public class aktRowProj
    {
        public static int ProjID;
        public static string ProjName;
        public static string ProjDescription;
    }
}
