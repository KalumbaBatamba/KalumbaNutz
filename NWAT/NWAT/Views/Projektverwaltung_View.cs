﻿using System;
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
            List<Project> ProjList = projCont.GetAllProjectsFromDB();
            var bindingList = new BindingList<Project>(ProjList);
            var source = new BindingSource(bindingList, null);
            //   CritList.Add(new Criterion() {Criterion_Id = 1, Name = "Testname", Description= "Testdescr"});
            //   CritList.Add(new Criterion() { Criterion_Id = 2, Name = "Testname2", Description = "Testdescr2" });
            //  dataGridView_Crits.DataSource = source;
            comboBox_SelectProject.DataSource = ProjList;

            //   comboBox.DataSource = x;
            comboBox_SelectProject.DisplayMember = "Name";
            comboBox_SelectProject.ValueMember = "Project_ID";
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
        }

        private void btn_ProjectModify_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_SelectProject.SelectedIndex;
            Project selectedItem = (Project)comboBox_SelectProject.SelectedItem;
     //       aktRowProj.ProjID = selectedItem.Project_Id;
            MessageBox.Show("Selected Item Text: " + selectedItem.Project_Id);


            Project_Update_View ProjectModify = new Project_Update_View(selectedItem.Project_Id);
            ProjectModify.Show();
        }

        private void btn_ProjectShow_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_SelectProject.SelectedIndex;
            Project selectedItem = (Project)comboBox_SelectProject.SelectedItem;
     //       aktRowProj.ProjID = selectedItem.Project_Id;
            MessageBox.Show("Selected Item Text: " + selectedItem.Project_Id);
            
            Project_Show_View ProjectShow = new Project_Show_View(selectedItem.Project_Id);
            ProjectShow.Show();
        }

        private void btn_ProjectUpdate_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_SelectProject.SelectedIndex;
            Project selectedItem = (Project)comboBox_SelectProject.SelectedItem;
     //       aktRowProj.ProjID = selectedItem.Project_Id;
            MessageBox.Show("Selected Item Text: " + selectedItem.Project_Id);

            Project_Update_View ProjectUpdate = new Project_Update_View(selectedItem.Project_Id);
            ProjectUpdate.Show();
        }

        private void btn_ProjImport_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.cur";
            openFileDialog1.Title = "Select a Cursor File";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.
                this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            List<Project> ProjList = projCont.GetAllProjectsFromDB();
            var bindingList = new BindingList<Project>(ProjList);
            var source = new BindingSource(bindingList, null);
            comboBox_SelectProject.DataSource = ProjList;
            comboBox_SelectProject.DisplayMember = "Name";
            comboBox_SelectProject.ValueMember = "Project_ID";
            
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
