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
    public partial class Kriterienverwaltung_View : Form
   

    {
        
       
      
        private CriterionController critCont;
        public Kriterienverwaltung_View()
        {
            this.critCont = new CriterionController();
            InitializeComponent();


        }
        /// <summary>
        /// Refreshes the list.
        /// </summary>
        /// Erstellt von Veit Berg, am 27.01.16
        public void refreshList() 
        {
            List<Criterion> CritList = critCont.GetAllCriterionsFromDb();
            var bindingList = new BindingList<Criterion>(CritList);
            var source = new BindingSource(bindingList, null);
            dataGridView_Crits.DataSource = CritList;
        }
        /// <summary>
        /// Handles the Load event of the Kriterienverwaltung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Kriterienverwaltung_Load(object sender, EventArgs e)
        {
            dataGridView_Crits.Rows.Clear();

            List<Criterion> CritList = critCont.GetAllCriterionsFromDb();
            var bindingList = new BindingList<Criterion>(CritList);
            var source = new BindingSource(bindingList, null);
            dataGridView_Crits.DataSource = CritList;
            this.FormClosing += new FormClosingEventHandler(Kriterienverwaltung_View_FormClosing);
        }
        /// <summary>
        /// Handles the FormClosing event of the Kriterienverwaltung_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void Kriterienverwaltung_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            NWAT_Start_View back = new NWAT_Start_View();
            back.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_CritShow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CritShow_Click(object sender, EventArgs e)
        {
            try{
            using (CriterionController critShow = new CriterionController())
            {
                DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
                int zelle1 = (int)row.Cells[0].Value;
                string zelle2 = (string)row.Cells[1].Value;
                string zelle3 = (string)row.Cells[2].Value;
                Criterion_Show_View CritShowView = new Criterion_Show_View(zelle1);
                CritShowView.Show();
            
            }
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_CritUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CritUpdate_Click(object sender, EventArgs e)
        {
            try{
            DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
            int zelle1 = (int)row.Cells[0].Value;
            string zelle2 = (string)row.Cells[1].Value;
            string zelle3 = (string)row.Cells[2].Value;
            aktRowCrit.CritID = zelle1;
            aktRowCrit.CritName = zelle2;
            aktRowCrit.CritDescription = zelle3;
            Criterion_Update_View CritUpdate = new Criterion_Update_View(zelle1);
            CritUpdate.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_CritDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CritDelete_Click(object sender, EventArgs e)
        {
            try{
            DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
            int zelle1 = (int)row.Cells[0].Value;
            using (CriterionController critDelete = new CriterionController()){     
             critDelete.DeleteCriterionFromDb(zelle1);       
         }
            MessageBox.Show("Das Kriterium wurde gelöscht");
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_CritCreate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CritCreate_Click(object sender, EventArgs e)
        {
            Criterion_Create_View CritCreate = new Criterion_Create_View();
            CritCreate.Show();
        }
        private void GetAllCritsFromDB()
        {

        }
        private void DeleteCritFromDB()
        {

        }

        private void dataGridView_Crits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            using (CriterionController CritRefr = new CriterionController())
            {
                List<Criterion> CritList = CritRefr.GetAllCriterionsFromDb();
                var bindingList = new BindingList<Criterion>(CritList);
                var source = new BindingSource(bindingList, null);
                dataGridView_Crits.DataSource = CritList;
            }
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
    }
}
public class aktRowCrit
{
    public static int CritID;
    public static string CritName;
    public static string CritDescription;

}
