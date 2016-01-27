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

        /// <summary>
        /// Handles the Load event of the Project_Create_Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Project_Create_Form_Load(object sender, EventArgs e)
        {

            this.FormClosing += new FormClosingEventHandler(Project_Create_View_FormClosing);
        }
        /// <summary>
        /// Handles the FormClosing event of the Project_Create_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void Project_Create_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            try{
            Projektverwaltung_View back = new Projektverwaltung_View();
            back.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }


        private void CreateNewProject()
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_ProjCreate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjCreate_Click(object sender, EventArgs e)
        {
            try{
            Project projCre = new Project();
            projCre.Name = textBox_ProjNameCreate.Text;
            projCre.Description = textBox_ProjDescCreate.Text;
            projCont.InsertProjectIntoDb(projCre);

            this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
    }
}
