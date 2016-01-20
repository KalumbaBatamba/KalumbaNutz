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
    public partial class ProjProdAssign_View : Form
    {
        private List<Product> _allProds;

        public List<Product> AllProds
        {
            get { return _allProds; }
            set { _allProds = value; }
        }

        private List<ProjectProduct> _projProds;

        public List<ProjectProduct> ProjProds
        {
            get { return _projProds; }
            set { _projProds = value; }
        }
        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        private ProjectProductController projProdCont;

        public ProjProdAssign_View(int projectID)
        {
            ProjectId = projectID;
            this.projProdCont = new ProjectProductController();
            InitializeComponent();
        }

        private void ProjProdAssign_Form_Load(object sender, EventArgs e)
        {
            using (ProjectProductController proProCont = new ProjectProductController())
            {
                ProjProds = proProCont.GetAllProjectProductsForOneProject(ProjectId);

            }
            using (ProductController prodCont = new ProductController())
            {
                AllProds = prodCont.GetAllProductsFromDb();

                if (ProjProds.Count != 0)
                {
                    foreach (ProjectProduct projProd in ProjProds)
                    {
                        Product allocatedProd = AllProds.Single(prod => prod.Product_Id == projProd.Product_Id);
                        AllProds.Remove(allocatedProd);
                    }
                }
            }
            dataGridView_prodAvail.Rows.Clear();
            var ProdBindingList = new BindingList<Product>(AllProds);
            var prodSource = new BindingSource(ProdBindingList, null);
            dataGridView_prodAvail.DataSource = AllProds;

            dataGridView_ProjProd.Rows.Clear();

            //using (ProductController prodCon = new ProductController())
            //{
            //    foreach (ProductCriterion prodCrit in ProjProds)
            //    {
            //        //    MessageBox.Show(projCrit.Criterion_Id.ToString());
            //        //      projCrit.Name = "test";
            //        var singleProdId = prodCon.GetProductById(ProjProds.Product_Id);
            //        projProds.Name = singleProdId.Name.ToString();
            //    }
           // }
       
            var ProjProdBindingList = new BindingList<ProjectProduct>(ProjProds);
            var projProdSource = new BindingSource(ProjProdBindingList, null);
            dataGridView_ProjProd.DataSource = ProjProds;
            //dataGridView_ProjProd.Columns.Remove("Project_Id");
            //dataGridView_ProjProd.Columns.Remove("Layer_Depth");
            //dataGridView_ProjProd.Columns.Remove("Weighting_Cardinal");
            //dataGridView_ProjProd.Columns.Remove("Weighting_Percentage_Layer");
            //dataGridView_ProjProd.Columns.Remove("Weighting_Percentage_Project");
            //dataGridView_ProjProd.Columns.Remove("Criterion");
            //dataGridView_ProjProd.Columns.Remove("ParentCriterion");
            //dataGridView_ProjProd.Columns.Remove("Project");
            //dataGridView_ProjProd.Columns[0].HeaderText = "ID";
            //dataGridView_ProjProd.Columns[0].Width = 30;
            //dataGridView_ProjProd.Columns[1].HeaderText = "P-ID";
            //dataGridView_ProjProd.Columns[1].Width = 30;
            //dataGridView_ProjProd.Columns[2].Width = 200;
            //  dataGridView_ProjCrits.Columns.Add("Name","Name");
            // DataGridViewColumn col = new DataGridViewTextBoxColumn();
            // col.DataPropertyName = "Name";
            // col.HeaderText = "Name";
            // col.Name = "test";
            //// col.
            // dataGridView_ProjCrits.Columns.Add(col);
        }
        private void AddProdToProject()
        {

        }
        private void DeleteProdFromProject()
        {

        }
        private void GetAllProdsFromDB()
        {

        }

        private void btn_ProdToProj_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView_prodAvail.SelectedRows[0];
            int ProdId = (int)row.Cells[0].Value;
            string ProdName = (string)row.Cells[1].Value;
            int index = dataGridView_prodAvail.CurrentCell.RowIndex;

            ProjectProduct projProdToAllocate = new ProjectProduct()
            {
                Project_Id = ProjectId,
                Product_Id = ProdId,
                //if(selectedParentCiterion.Criterion_Id == null )
                //{
                //Parent_Criterion_Id = null;
                //}
             //   Parent_Criterion_Id = selectedParentCiterion.Criterion_Id
            };
            AllProds.RemoveAt(index);
            ProjProds.Add(projProdToAllocate);
      //      AllCrits.Remove();

            //Criterion Crit = new Criterion();
            //Crit = projCritToAllocate.Criterion;
            //AllCrits.Remove(Crit);
            // testzeile
            //dataGridView_ProjCrits = null;
            //      exerciseListDataGridView.DataSource = da.DefaultView;
            //           this.dataGridView_ProjCrits.Refresh();
            //   dataGridView_ProjCrits.Rows.Clear();
            dataGridView_prodAvail.DataSource = null;
            dataGridView_prodAvail.DataSource = AllProds;
           dataGridView_ProjProd.DataSource = null;
       //     ParentView.AllocateNewProjectCriterion(projCritToAllocate, CriterionIdDeleteFromList);
            using (ProductController prodCon = new ProductController())
            {
                foreach (ProjectProduct projProd in ProjProds)
                {
                    //    MessageBox.Show(projCrit.Criterion_Id.ToString());
                    //      projCrit.Name = "test";
                    var singleProdId = prodCon.GetProductById(projProd.Product_Id);
                    projProd.Name = singleProdId.Name.ToString();
                }
            }


            dataGridView_ProjProd.DataSource = ProjProds;
            dataGridView_ProjProd.Columns.Remove("Project");
            dataGridView_ProjProd.Columns.Remove("Project_Id");
            dataGridView_ProjProd.Columns.Remove("Product");
            dataGridView_ProjProd.Columns[0].HeaderText = "ID";
            dataGridView_ProjProd.Columns[0].Width = 30;
           
            //dataGridView_ProjProd.Columns[1].HeaderText = "P-ID";
            //dataGridView_ProjProd.Columns[0].Width = 30;
            dataGridView_ProjProd.Columns[1].Width = 200;
         //   dataGridView_ProjProd.Columns[2].Width = 200;

        //    AllProds.RemoveAt(index);
         //   ProjProds.Add(projProdToAllocate);
        }

        private void btn_ProjProdSave_Click(object sender, EventArgs e)
        {
            projProdCont.ChangeAllocationOfProjectProducstListInDb(ProjectId,ProjProds);
            this.Close();
        }

        private void btn_ProdToPool_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView_ProjProd.SelectedRows[0];
            int ProdId = (int)row.Cells[0].Value;
               string ProdName = (string)row.Cells[1].Value ;
      //      int index = dataGridView_ProjProd.CurrentCell.RowIndex;
            //        dataGridView_CritAvail.Rows.RemoveAt(row.Index);
      //      ProjProds.RemoveAt(index);
            using (ProductController prodCont = new ProductController())
            {
                //     foreach (ProjectCriterion projCrit in ProjCrits)
                //     {
                Product addProd = prodCont.GetProductById(ProdId);
                //     }
                AllProds.Add(addProd);
            }
            //dataGridView_CritAvail.DataSource = null;
            //dataGridView_CritAvail.DataSource = AllCrits;
            //dataGridView_ProjCrits.DataSource = null;
            //dataGridView_ProjCrits.DataSource = ProjCrits;
            //dataGridView_ProjCrits.Columns.Remove("Project_Id");
            //dataGridView_ProjCrits.Columns.Remove("Layer_Depth");
            //dataGridView_ProjCrits.Columns.Remove("Weighting_Cardinal");
            //dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Layer");
            //dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Project");
            //dataGridView_ProjCrits.Columns.Remove("Criterion");
            //dataGridView_ProjCrits.Columns.Remove("ParentCriterion");
            //dataGridView_ProjCrits.Columns.Remove("Project");
            //        AllCrits.Add(critcont)
            //        AllCrits.Add(ProjCrits.)
            //if (ProjCrits.Count != 0)
            //{
            //ProjCritParentAllocation_View projCritAllView = new ProjCritParentAllocation_View(
            //    ProjCrits, 
            //    ProjectId, 
            //    CritId, 
            //    this);
            //projCritAllView.Show();
        }
       
    }
}
