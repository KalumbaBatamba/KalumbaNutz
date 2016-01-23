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
            }
            catch (FormatException){
            MessageBox.Show("Bitte nur Zahlen eingeben");
            }
            
        }

        private void dataGridView_ProjCritBalance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
        int zeile = (dataGridView_ProjCritBalance.Rows.Count -1);
        }

       private void btn_SameBalance_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)
            {
                row.Cells[3].Value = 1;
            }




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
                   int critID = (int)row.Cells[1].Value ;
 //                  ProjectCriterion fromList = ProjCrits.Single(projKrit => projKrit.Criterion_Id == critID);
                   ProjectCriterion fromList = ProjCrits[i];
                  // ProjectCriterion fromList = ProjCrits[i];
            //       var str = row.Cells[3].Value.GetType();
                   //    MessageBox.Show("Var = " + str);
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
               dataGridView_ProjCritBalance.Columns[4].Width = 60;
               dataGridView_ProjCritBalance.Columns[5].Width = 350;
               dataGridView_ProjCritBalance.Columns[5].ReadOnly = true;
               this.Close();
       //    }
       }

        private void btn_ProjCritBalaCancle_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        

        private void dataGridView_ProjCritBalance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
