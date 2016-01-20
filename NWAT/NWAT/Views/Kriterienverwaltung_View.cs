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
        public void refreshList() 
        {
            List<Criterion> CritList = critCont.GetAllCriterionsFromDb();
            var bindingList = new BindingList<Criterion>(CritList);
            var source = new BindingSource(bindingList, null);
            dataGridView_Crits.DataSource = CritList;
            //   CritList.Add(new Criterion() {Criterion_Id = 1, Name = "Testname", Description= "Testdescr"});
            //   CritList.Add(new Criterion() { Criterion_Id = 2, Name = "Testname2", Description = "Testdescr2" });
            //  dataGridView_Crits.DataSource = source;
          

        }
        private void Kriterienverwaltung_Load(object sender, EventArgs e)
        {
      //      this.critCont = new CriterionController();
      //      InitializeComponent();
            dataGridView_Crits.Rows.Clear();

            List<Criterion> CritList = critCont.GetAllCriterionsFromDb();
            var bindingList = new BindingList<Criterion>(CritList);
            var source = new BindingSource(bindingList, null);
            //   CritList.Add(new Criterion() {Criterion_Id = 1, Name = "Testname", Description= "Testdescr"});
            //   CritList.Add(new Criterion() { Criterion_Id = 2, Name = "Testname2", Description = "Testdescr2" });
            //  dataGridView_Crits.DataSource = source;
            dataGridView_Crits.DataSource = CritList;
       //     while (1 < 2) {
            //    dataGridView_Crits.Refresh();
            //    System.Threading.Thread.Sleep(1000);
       //     }
     
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_CritShow_Click(object sender, EventArgs e)
        {
            using (CriterionController critShow = new CriterionController())
            {
                DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
                int zelle1 = (int)row.Cells[0].Value;
                string zelle2 = (string)row.Cells[1].Value;
                string zelle3 = (string)row.Cells[2].Value;
                //       aktRowCrit.CritID = zelle1;
                //       aktRowCrit.CritName = zelle2;
                //       aktRowCrit.CritDescription = zelle3;
                MessageBox.Show(zelle1.ToString() + zelle2 + zelle3);


                Criterion_Show_View CritShowView = new Criterion_Show_View(zelle1);
                CritShowView.Show();
            
            }

     //       DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
     //       int zelle1 = (int)row.Cells[0].Value;
     //       string zelle2 = (string)row.Cells[1].Value;
     //       string zelle3 = (string)row.Cells[2].Value;
     ////       aktRowCrit.CritID = zelle1;
     ////       aktRowCrit.CritName = zelle2;
     ////       aktRowCrit.CritDescription = zelle3;
     //       MessageBox.Show(zelle1.ToString() + zelle2 + zelle3);


     //       Criterion_Show_View CritShow = new Criterion_Show_View(zelle1);
     //       CritShow.Show();
        }

        private void btn_CritUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
            int zelle1 = (int)row.Cells[0].Value;
            string zelle2 = (string)row.Cells[1].Value;
            string zelle3 = (string)row.Cells[2].Value;
            aktRowCrit.CritID = zelle1;
            aktRowCrit.CritName = zelle2;
            aktRowCrit.CritDescription = zelle3;
            MessageBox.Show(zelle1.ToString() + zelle2 + zelle3);
            
            Criterion_Update_View CritUpdate = new Criterion_Update_View(zelle1);
            CritUpdate.Show();
            
        }

        private void btn_CritDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
            int zelle1 = (int)row.Cells[0].Value;
         //   aktRowCrit.CritID = zelle1;
         using (CriterionController critDelete = new CriterionController()){
         
             critDelete.DeleteCriterionFromDb(zelle1);
         
         }
            

       //     critCont.DeleteCriterionFromDb(zelle1);
            MessageBox.Show("Das Kriterium wurde gelöscht");
        }

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

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            using (CriterionController CritRefr = new CriterionController())
            {
                List<Criterion> CritList = CritRefr.GetAllCriterionsFromDb();
                var bindingList = new BindingList<Criterion>(CritList);
                var source = new BindingSource(bindingList, null);
                dataGridView_Crits.DataSource = CritList;
            }


//            dataGridView_Crits.DataSource = null;
  //        var bindingList = new BindingList<Criterion>() ;
 //           bindingList.Clear();
            
  //          List<Criterion> CritList = critCont.GetAllCriterionsFromDb();
   //         bindingList = CritList;
  //          var bindingList  = new BindingList<Criterion>(CritList);
 //           bindingList.  (CritList);
  //          var source = new BindingSource(bindingList, null);
            //   CritList.Add(new Criterion() {Criterion_Id = 1, Name = "Testname", Description= "Testdescr"});
            //   CritList.Add(new Criterion() { Criterion_Id = 2, Name = "Testname2", Description = "Testdescr2" });
            //  dataGridView_Crits.DataSource = source;
  //          dataGridView_Crits.DataSource = CritList;
        }
    }
}
public class aktRowCrit
{
    public static int CritID;
    public static string CritName;
    public static string CritDescription;

}
