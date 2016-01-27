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
    public partial class Projektverwaltung_View : Form
    {
        
        private ProjectController projCont;
        public Projektverwaltung_View()
        {
            
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
                MessageBox.Show("Ups da lief was schief");
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
            NWAT_Start_View start = new NWAT_Start_View();
            start.Show();
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
            Project_Create_View ProjectCreate = new Project_Create_View();
            ProjectCreate.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
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
            aktuellesProjekt_View AktProjView = new aktuellesProjekt_View(selectedItem.Project_Id);
            AktProjView.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
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
            Project_Show_View ProjectShow = new Project_Show_View(selectedItem.Project_Id);
            ProjectShow.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
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
            Project_Update_View ProjectUpdate = new Project_Update_View(selectedItem.Project_Id);
            ProjectUpdate.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
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
            try{
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.cur";
            openFileDialog1.Title = "Select a Cursor File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_refresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            try{
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
                MessageBox.Show("Ups da lief was schief");
            }
        }

        private void comboBox_SelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_ProjectExport_Click(object sender, EventArgs e)
        {

        }

    }
    public class aktRowProj
    {
        public static int ProjID;
        public static string ProjName;
        public static string ProjDescription;
    }
}
