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
    public partial class ProjCritBalance_View : Form
    {

        private List<Product> _allProds;

        public List<Product> AllProds
        {
            get { return _allProds; }
            set { _allProds = value; }
        }

        private List<ProjectCriterion> _projCrits;

        public List<ProjectCriterion> ProjCrits
        {
            get { return _projCrits; }
            set { _projCrits = value; }
        }
        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

     
        private ProjectCriterionController projCritCont;
     
        
        public ProjCritBalance_View(int projectID)
        {
            ProjectId = projectID;
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();
        }
        private void ProjCritBalance_View_Load(object sender, EventArgs e)
        {
            // Attach DataGridView events to the corresponding event handlers.
         
      //       this.dataGridView_ProjCritBalance.CellEndEdit += new
      //       DataGridViewCellEventHandler(dataGridView_ProjCritBalance_CellEndEdit);
            try
            {
                using (ProjectCriterionController proCriCont = new ProjectCriterionController())
                {
                    ProjCrits = proCriCont.GetSortedCriterionStructure(ProjectId);
                    //.GetAllProjectCriterionsForOneProject(ProjectId);
                    using (CriterionController critCon = new CriterionController())
                    {
                        foreach (ProjectCriterion projCrit in ProjCrits)
                        {
                            //    MessageBox.Show(projCrit.Criterion_Id.ToString());
                            //      projCrit.Name = "test";
                            var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                            projCrit.Name = singleCritId.Name.ToString();
                        }
                    }




                    dataGridView_ProjCritBalance.Rows.Clear();
                    var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                    var CritSource = new BindingSource(CritBindingList, null);
                    dataGridView_ProjCritBalance.DataSource = ProjCrits;
                    dataGridView_ProjCritBalance.Columns.Remove("Project_Id");
                    dataGridView_ProjCritBalance.Columns.Remove("Layer_depth");
                    //       dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Layer");
                    dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Project");
                    dataGridView_ProjCritBalance.Columns.Remove("Criterion");
                    dataGridView_ProjCritBalance.Columns.Remove("ParentCriterion");
                    dataGridView_ProjCritBalance.Columns.Remove("Project");
                    dataGridView_ProjCritBalance.Columns.Add("Beschreibung1", "Beschreibung");
                    int i = 0;
                    foreach (ProjectCriterion ProCri in ProjCrits)
                    {

                        dataGridView_ProjCritBalance["Beschreibung1", i].Value = ProCri.Criterion.Description;
                        i++;
                    } 
                    dataGridView_ProjCritBalance.Columns[1].HeaderText = "ID";
                    dataGridView_ProjCritBalance.Columns[1].Width = 30;
                    dataGridView_ProjCritBalance.Columns[1].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns[2].HeaderText = "P-ID";
                    dataGridView_ProjCritBalance.Columns[2].Width = 30;
                    dataGridView_ProjCritBalance.Columns[2].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns[3].HeaderText = "G(C)";
                    dataGridView_ProjCritBalance.Columns[3].Width = 30;
                    dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].Width = 30;
                    
                    dataGridView_ProjCritBalance.Columns[4].HeaderText ="G(PL)";
                    dataGridView_ProjCritBalance.Columns[4].Width = 100;
                //    dataGridView_ProjCritBalance.Columns["Weighting_Precentage_Layer"].Width = 150;

       //             dataGridView_ProjCritBalance.Columns[3].ValueType = typeof(String);
                    dataGridView_ProjCritBalance.Columns[4].ReadOnly = true;
          //          dataGridView_ProjCritBalance.Columns[4].Width = 30;
                    dataGridView_ProjCritBalance.Columns["Beschreibung1"].Width = 350;
                    dataGridView_ProjCritBalance.Columns[5].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns[5].Width = 100;
                    dataGridView_ProjCritBalance.Columns["Beschreibung1"].DisplayIndex = 6;

                }
            }
            catch (FormatException){
            MessageBox.Show("Bitte nur Zahlen eingeben");
            }
            this.dataGridView_ProjCritBalance.CellValidating += new
         DataGridViewCellValidatingEventHandler(dataGridView_ProjCritBalance_CellValidating);
     //   }
            this.FormClosing += new FormClosingEventHandler(ProjCritBalance_View_FormClosing);
        }
        void ProjCritBalance_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            //your code here
            aktuellesProjekt_View back = new aktuellesProjekt_View(ProjectId);
            back.Show();
        }


        private void dataGridView_ProjCritBalance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
        int zeile = (dataGridView_ProjCritBalance.Rows.Count -1);
        }

       private void btn_SameBalance_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)
            {
                row.Cells["Weighting_Cardinal"].Value = 1;
            }
            int i = 0;
            foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)
            {
                int critID = (int)row.Cells["Weighting_Cardinal"].Value;
                //                  ProjectCriterion fromList = ProjCrits.Single(projKrit => projKrit.Criterion_Id == critID);
                ProjectCriterion fromList = ProjCrits[i];
                // ProjectCriterion fromList = ProjCrits[i];
                //       var str = row.Cells[3].Value.GetType();
                //    MessageBox.Show("Var = " + str);
                i++;
                fromList.Weighting_Cardinal = (int)row.Cells["Weighting_Cardinal"].Value;
                projCritCont.UpdateProjectCriterionInDb(fromList);
            }
            refreshGrid();



 /*          //dataGridView_ProjCritBalance.
            int i = 0;
            foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)
            {
               // int i = 0;
                ProjectCriterion fromList = ProjCrits[i];
                i++;
                fromList.Weighting_Cardinal = (int)row.Cells[3].Value;
                projCritCont.UpdateProjectCriterionInDb(fromList);
            }
            dataGridView_ProjCritBalance.DataSource = null;
            dataGridView_ProjCritBalance.DataSource = ProjCrits; dataGridView_ProjCritBalance.Columns.Remove("Project_Id");
            dataGridView_ProjCritBalance.Columns.Remove("Layer_depth");
        //    dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Layer");
            dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Project");
            dataGridView_ProjCritBalance.Columns.Remove("Criterion");
            dataGridView_ProjCritBalance.Columns.Remove("ParentCriterion");
            dataGridView_ProjCritBalance.Columns.Remove("Project");
            dataGridView_ProjCritBalance.Columns[1].HeaderText = "ID";
            dataGridView_ProjCritBalance.Columns[1].Width = 30;
            dataGridView_ProjCritBalance.Columns[1].ReadOnly = true;
            dataGridView_ProjCritBalance.Columns[2].HeaderText = "P-ID";
            dataGridView_ProjCritBalance.Columns[2].Width = 30;
            dataGridView_ProjCritBalance.Columns[2].ReadOnly = true;
            dataGridView_ProjCritBalance.Columns[3].HeaderText = "G(C)";
            dataGridView_ProjCritBalance.Columns[3].Width = 30;
            //    dataGridView_ProjCritBalance.Columns[0].HeaderText = "P-ID";
            dataGridView_ProjCritBalance.Columns[4].ReadOnly = true;
            dataGridView_ProjCritBalance.Columns[4].Width = 30;
            dataGridView_ProjCritBalance.Columns[5].Width = 350;
            dataGridView_ProjCritBalance.Columns[5].ReadOnly = true;
        //    projCritCont.UpdateProjectCriterionInDb(ProjCrits);
            //   using (ProjectCriterionController proCritCon = new ProjectCriterionController())
            //    {
            //    if(ProjectCriterion proCrit in ProjCrits exists)
            //       {
                
            //    }
            //   }
            //    ProjectCriterion changedProCrit = new ProjectCriterion()
            //    {
                
            //    }


          //      int i = (int)row.Cells[3].Value;
        //    }
    //        using (ProjectCriterionController proCritCon = new ProjectCriterionController())
    //        {
    //            foreach (ProjectCriterion proCrit in ProjCrits)
    //            {
    //                var newBalance = 
    ////                proCrit.Weighting_Cardinal = dataGridView_ProjCritBalance.Columns[3]
    //                //    MessageBox.Show(projCrit.Criterion_Id.ToString());
    //                //      projCrit.Name = "test";
    //                //var singleProdId = prodCon.GetProductById(projProd.Product_Id);
    //                //projProd.Name = singleProdId.Name.ToString();
    //            }
    //        }
            //foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)
            //{
            //ProjCrits.
            //}
    
  */ 
       }

       private void btn_ProjCritBalaSave_Click(object sender, EventArgs e)
       {

           //foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)


           //{
           //           int c;
           //           bool check = int.TryParse(row.Cells[3].Value);

           //           if(row.Cells[3].Value is an Int)
           //}
           //PRüfen ob nur Int Werte eingetragen
           //bool res = true;
           //foreach (DataGridViewRow ro in dataGridView_ProjCritBalance.Rows)
           //{
           //    int c;
           //    res = int.TryParse((string)ro.Cells[3].Value, out c);


           //}
           //if (res == false)
           //{
           //    MessageBox.Show("Bitte nur Zahlen eintragen");
           //}
           //else
           //{

               //Werte der Gewichtung eintragen und speichern in DB 
               int i = 0;
               foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)
               {
                   int critID = (int)row.Cells["Weighting_Cardinal"].Value ;
 //                  ProjectCriterion fromList = ProjCrits.Single(projKrit => projKrit.Criterion_Id == critID);
                   ProjectCriterion fromList = ProjCrits[i];
                  // ProjectCriterion fromList = ProjCrits[i];
            //       var str = row.Cells[3].Value.GetType();
                   //    MessageBox.Show("Var = " + str);
                   i++;
                   fromList.Weighting_Cardinal = (int)row.Cells["Weighting_Cardinal"].Value; //wc vorher 3
                   projCritCont.UpdateProjectCriterionInDb(fromList);
               }
           //    ProjCritBalance_View ProjCritBalance = new ProjCritBalance_View(ProjectId);
           //    ProjCritBalance.Show();
           //this.Close();
               refreshGrid();
           
       /*        using (ProjectCriterionController proCriCont = new ProjectCriterionController())
               {
                   ProjCrits = proCriCont.GetSortedCriterionStructure(ProjectId);
                   //.GetAllProjectCriterionsForOneProject(ProjectId);
                   using (CriterionController critCon = new CriterionController())
                   {
                       foreach (ProjectCriterion projCrit in ProjCrits)
                       {
                           //    MessageBox.Show(projCrit.Criterion_Id.ToString());
                           //      projCrit.Name = "test";
                           var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                           projCrit.Name = singleCritId.Name.ToString();
                       }
                   }




              //     dataGridView_ProjCritBalance.Rows.Clear();
                   var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                   var CritSource = new BindingSource(CritBindingList, null);
                   dataGridView_ProjCritBalance.DataSource = ProjCrits;
                   dataGridView_ProjCritBalance.Columns.Remove("Project_Id");
                   dataGridView_ProjCritBalance.Columns.Remove("Layer_depth");
                   //       dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Layer");
                   dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Project");
                   dataGridView_ProjCritBalance.Columns.Remove("Criterion");
                   dataGridView_ProjCritBalance.Columns.Remove("ParentCriterion");
                   dataGridView_ProjCritBalance.Columns.Remove("Project");
                   dataGridView_ProjCritBalance.Columns[1].HeaderText = "ID";
                   dataGridView_ProjCritBalance.Columns[1].Width = 30;
                   dataGridView_ProjCritBalance.Columns[1].ReadOnly = true;
                   dataGridView_ProjCritBalance.Columns[2].HeaderText = "P-ID";
                   dataGridView_ProjCritBalance.Columns[2].Width = 30;
                   dataGridView_ProjCritBalance.Columns[2].ReadOnly = true;
                   dataGridView_ProjCritBalance.Columns[3].HeaderText = "G(C)";
                   dataGridView_ProjCritBalance.Columns[3].Width = 30;
                   //             dataGridView_ProjCritBalance.Columns[3].ValueType = typeof(String);
                   dataGridView_ProjCritBalance.Columns[4].ReadOnly = true;
                   dataGridView_ProjCritBalance.Columns[4].Width = 30;
                   dataGridView_ProjCritBalance.Columns[5].Width = 350;
                   dataGridView_ProjCritBalance.Columns[5].ReadOnly = true;

               }
           */
   /*            dataGridView_ProjCritBalance.DataSource = null;
               dataGridView_ProjCritBalance.DataSource = ProjCrits; dataGridView_ProjCritBalance.Columns.Remove("Project_Id");
               dataGridView_ProjCritBalance.Columns.Remove("Layer_depth");
               //    dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Layer");
               dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Project");
               dataGridView_ProjCritBalance.Columns.Remove("Criterion");
               dataGridView_ProjCritBalance.Columns.Remove("ParentCriterion");
               dataGridView_ProjCritBalance.Columns.Remove("Project");
               dataGridView_ProjCritBalance.Columns[1].HeaderText = "ID";
               dataGridView_ProjCritBalance.Columns[1].Width = 30;
               dataGridView_ProjCritBalance.Columns[1].ReadOnly = true;
               dataGridView_ProjCritBalance.Columns[2].HeaderText = "P-ID";
               dataGridView_ProjCritBalance.Columns[2].Width = 30;
               dataGridView_ProjCritBalance.Columns[2].ReadOnly = true;
               dataGridView_ProjCritBalance.Columns[3].HeaderText = "G(C)";
               dataGridView_ProjCritBalance.Columns[3].Width = 30;
               //    dataGridView_ProjCritBalance.Columns[0].HeaderText = "P-ID";
               dataGridView_ProjCritBalance.Columns[4].ReadOnly = true;
               dataGridView_ProjCritBalance.Columns[4].Width = 60;
               dataGridView_ProjCritBalance.Columns[5].Width = 350;
               dataGridView_ProjCritBalance.Columns[5].ReadOnly = true;
   //            this.Close();
       //    }
    */
       }

        private void btn_ProjCritBalaCancle_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void refreshGrid()
        {
            dataGridView_ProjCritBalance.DataSource = null;
            using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetSortedCriterionStructure(ProjectId);
                //.GetAllProjectCriterionsForOneProject(ProjectId);
                using (CriterionController critCon = new CriterionController())
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        //    MessageBox.Show(projCrit.Criterion_Id.ToString());
                        //      projCrit.Name = "test";
                        var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                        projCrit.Name = singleCritId.Name.ToString();
                    }
                }




               // dataGridView_ProjCritBalance.Rows.Clear();
                var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                var CritSource = new BindingSource(CritBindingList, null);
                dataGridView_ProjCritBalance.DataSource = ProjCrits;
                dataGridView_ProjCritBalance.Columns.Remove("Project_Id");
                dataGridView_ProjCritBalance.Columns.Remove("Layer_depth");
                //       dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Layer");
                dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Project");
                dataGridView_ProjCritBalance.Columns.Remove("Criterion");
                dataGridView_ProjCritBalance.Columns.Remove("ParentCriterion");
                dataGridView_ProjCritBalance.Columns.Remove("Project");
                //if (dataGridView_ProjCritBalance.Columns["Beschreibung1"] == null)
                //{
                //    dataGridView_ProjCritBalance.Columns.Remove("Beschreibung1");
                //}

                //if (dataGridView_ProjCritBalance.Columns["Beschreibung"] == null)
                //{
                //dataGridView_ProjCritBalance.Columns.Add("Beschreibung", "Beschreibung");
                int i = 0;
                foreach (ProjectCriterion ProCri in ProjCrits)
                {

                    dataGridView_ProjCritBalance["Beschreibung1", i].Value = ProCri.Criterion.Description;
                    i++;
                }
                //} else if (dataGridView_ProjCritBalance.Columns["Beschreibung"] != null)
                //{
            //    }
                dataGridView_ProjCritBalance.Columns["Criterion_Id"].HeaderText = "ID";
                dataGridView_ProjCritBalance.Columns[1].Width = 30;
                dataGridView_ProjCritBalance.Columns[1].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].HeaderText = "P-ID";
                dataGridView_ProjCritBalance.Columns[2].Width = 30;
                dataGridView_ProjCritBalance.Columns[2].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Weighting_Cardinal"].HeaderText = "G(C)";
                dataGridView_ProjCritBalance.Columns["Weighting_Cardinal"].Width = 30;
                //             dataGridView_ProjCritBalance.Columns[3].ValueType = typeof(String);
          //      dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Layer"].Width = 30;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Layer"].HeaderText = "G(PL)";
                
          //      dataGridView_ProjCritBalance.Columns["Beschreibung1"].Width = 200;
                dataGridView_ProjCritBalance.Columns["Criterion_Id"].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Weighting_Cardinal"].Width = 30;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Layer"].Width = 100;
                dataGridView_ProjCritBalance.Columns[5].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Criterion_Id"].DisplayIndex = 1;
                dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].DisplayIndex = 2;
                dataGridView_ProjCritBalance.Columns["Weighting_Cardinal"].DisplayIndex = 3;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Layer"].DisplayIndex = 4;
                dataGridView_ProjCritBalance.Columns["Name"].DisplayIndex = 5;
                dataGridView_ProjCritBalance.Columns["Beschreibung1"].DisplayIndex = 6;
                dataGridView_ProjCritBalance.Columns["Beschreibung1"].Width = 200;
                dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].Width = 30;
                dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].Width = 30;
            }
        }

        private void dataGridView_ProjCritBalance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
  //      public event DataGridViewCellValidatingEventHandler CellValidating();

        private void dataGridView_ProjCritBalance_CellValidating(object sender,   DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dataGridView_ProjCritBalance.Rows[e.RowIndex].ErrorText = "";
                int newInteger;

                // Don't try to validate the 'new row' until finished 
                // editing since there
                // is not any point in validating its initial value.
                //      if (dataGridView_ProjCritBalance.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == "")
                {

                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    dataGridView_ProjCritBalance.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
         //       dataGridView_ProjCritBalance.Rows[e.RowIndex].Cells[3].Value = ProjCrits[e.RowIndex].Weighting_Cardinal ;
         //      dataGridView_ProjCritBalance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 9;
                   

                    MessageBox.Show("Bitte nur Ganzzahlen eintragen");
                }
            }
     //       refreshGrid();
        }
    }
}
