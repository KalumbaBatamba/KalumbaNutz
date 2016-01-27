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
    public partial class Project_Create_View : Form
    {
        private ProjectController projCont;
        public Project_Create_View()
        {
            this.projCont = new ProjectController();          
            InitializeComponent();
        }

        private void Project_Create_Form_Load(object sender, EventArgs e)
        {

            this.FormClosing += new FormClosingEventHandler(Project_Create_View_FormClosing);
        }
        void Project_Create_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            Projektverwaltung_View back = new Projektverwaltung_View();
            back.Show();
        }


        private void CreateNewProject()
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_ProjCreate_Click(object sender, EventArgs e)
        {
            Project projCre = new Project();
            projCre.Name = textBox_ProjNameCreate.Text;
            projCre.Description = textBox_ProjDescCreate.Text;
            projCont.InsertProjectIntoDb(projCre);

            this.Close();
        }
    }
}
