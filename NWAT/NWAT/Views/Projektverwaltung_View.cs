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

        private void Projektverwaltung_Form_Load(object sender, EventArgs e)
        {
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

        private void btn_ProjectStartCreate_Click(object sender, EventArgs e)
        {
            Project_Create_View ProjectCreate = new Project_Create_View();
            ProjectCreate.Show();
            Hide();
        }

        private void btn_ProjectModify_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_SelectProject.SelectedIndex;
            Project selectedItem = (Project)comboBox_SelectProject.SelectedItem;
            aktuellesProjekt_View AktProjView = new aktuellesProjekt_View(selectedItem.Project_Id);
            AktProjView.Show();
            Hide();
        }

        private void btn_ProjectShow_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_SelectProject.SelectedIndex;
            Project selectedItem = (Project)comboBox_SelectProject.SelectedItem;
            Project_Show_View ProjectShow = new Project_Show_View(selectedItem.Project_Id);
            ProjectShow.Show();
            Hide();
        }

        private void btn_ProjectUpdate_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_SelectProject.SelectedIndex;
            Project selectedItem = (Project)comboBox_SelectProject.SelectedItem;
            Project_Update_View ProjectUpdate = new Project_Update_View(selectedItem.Project_Id);
            ProjectUpdate.Show();
            Hide();
        }

        private void btn_ProjImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.cur";
            openFileDialog1.Title = "Select a Cursor File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
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

        private void comboBox_SelectProject_SelectedIndexChanged(object sender, EventArgs e)
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
