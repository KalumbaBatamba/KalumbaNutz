using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;



namespace NWAT
{
    /*Anzeige der Kriterien der DB, Möglichkeiten für bearbeiten, betrachten, löschen,  ändern, neu anlegen 
     */
    public partial class Kriterienverwaltung_View : Form
   

    {
        
       
      
        private CriterionController critCont;
        private Form parentView;
        public Kriterienverwaltung_View(Form parentView)
        {
            this.parentView = parentView;
            this.critCont = new CriterionController();
            InitializeComponent();


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
            dataGridView_Crits.Columns["Description"].Width = 250;
            dataGridView_Crits.Columns["Description"].HeaderText = "Beschreibung";

            dataGridView_Crits.Columns["Criterion_Id"].Width = 40;
            dataGridView_Crits.Columns["Criterion_ID"].HeaderText = "ID";

            dataGridView_Crits.Columns["Name"].Width = 200;
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
            this.parentView.Show();
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
                Criterion_Show_View CritShowView = new Criterion_Show_View(this, zelle1);
                CritShowView.Show();
            
            }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
            Criterion_Update_View CritUpdate = new Criterion_Update_View(this, zelle1);
            CritUpdate.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
            try
            {
                DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
                int critId = (int)row.Cells[0].Value;
                using (CriterionController critDelete = new CriterionController())
                {
                    System.Windows.Forms.DialogResult result;
                    if(critDelete.CheckIfCriterionIsAllocatedToAnyProject(critId))
                    {
                        result = MessageBox.Show("Das Kriterium ist einem oder mehreren Projekten zugeordnet.\n"+
                            "Wollen Sie das ausgeählte Kriterium wirklich löschen?",
                            "Löschbestätigung",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                    {
                        result = MessageBox.Show("Wollen Sie das ausgeählte Kriterium wirklich löschen?",
                           "Löschbestätigung",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    if (result == DialogResult.Yes)
                    {
                        critDelete.DeleteCriterionFromDb(critId);
                        RefreshList();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
            Criterion_Create_View CritCreate = new Criterion_Create_View(this);
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
            RefreshList();
        }

        /// <summary>
        /// Refreshes the list.
        /// für manuelles Refreshen
        /// </summary>
        /// Erstellt von Veit Berg, am 27.01.16
        public void RefreshList()
        {
            //List<Criterion> CritList = critCont.GetAllCriterionsFromDb();
            //var bindingList = new BindingList<Criterion>(CritList);
            //var source = new BindingSource(bindingList, null);
            //dataGridView_Crits.DataSource = CritList;
            try
            {
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
                MessageBox.Show(x.Message);
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
