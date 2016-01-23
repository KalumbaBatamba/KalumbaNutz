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
using NWAT.Printer;

namespace NWAT
{

    public partial class ProjCritProdFulfilment_View : Form
    {
        private List<ProjectCriterion> _projCrits;

        public List<ProjectCriterion> ProjCrits
        {
            get { return _projCrits; }
            set { _projCrits = value; }
        }
        private Project _project;

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }

        private ProjectController _projectCont;

        public ProjectController ProjectCont
        {
            get { return _projectCont; }
            set { _projectCont = value; }
        }


        int aktProd;

        private ProjectController _projectController;


        private ProjectCriterionController projCritCont;

        public ProjCritProdFulfilment_View(int projectId)
        {
            int ProjectID = projectId;
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();
        }

        private void ProjCritProdFulfilment_Form_Load(object sender, EventArgs e)
        {

            using (ProjectProductController Projverw = new ProjectProductController())
            {
                ProjectProduct projprod = (ProjectProduct)comboBox_ProjCritProdFulf.SelectedItem;
                List<ProjectProduct> ProdList = Projverw.GetAllProjectProductsForOneProject(Project.Project_Id); //Project.Project_Id
                List<Product> productsList = new List<Product>();
                foreach (ProjectProduct projProd in ProdList)
                {
                    productsList.Add(projProd.Product); 
                }
                comboBox_ProjCritProdFulf.DataSource = productsList;
                
                comboBox_ProjCritProdFulf.DisplayMember = "Name";
         //       comboBox_ProjCritProdFulf.ValueMember = "Product_ID";
            }
            using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetSortedCriterionStructure(Project.Project_Id);
                using (CriterionController critCon = new CriterionController())
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                        projCrit.Name = singleCritId.Name.ToString();
                    }
                }

                dataGridView_ProjCritProdFulf.Rows.Clear();
                var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                var CritSource = new BindingSource(CritBindingList, null);
                dataGridView_ProjCritProdFulf.DataSource = ProjCrits;
                dataGridView_ProjCritProdFulf.Columns.Remove("Project_Id");
             //   dataGridView_ProjCritProdFulf.Columns.Remove("Criterion_Id");
             //   dataGridView_ProjCritProdFulf.Columns.Remove("Layer_Depth");
             //   dataGridView_ProjCritProdFulf.Columns.Remove("Parent_Criterion_Id");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Cardinal");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Layer");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Project");
                dataGridView_ProjCritProdFulf.Columns.Remove("Criterion");
                dataGridView_ProjCritProdFulf.Columns.Remove("ParentCriterion");
                dataGridView_ProjCritProdFulf.Columns.Remove("Project");
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView_ProjCritProdFulf.Columns.Add(chk);
             //   dataGridView_ProjCritProdFulf.Columns[0].CellType = Boolean;
                chk.Name = "chk";
             //   dataGridView_ProjCritProdFulf.Columns[0].CellType = Boolean;
              //  dataGridView_ProjCritProdFulf.Columns[1].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[2].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[3].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[4].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[5].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[6].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[7].ReadOnly = true;
                dataGridView_ProjCritProdFulf.Columns[4].DisplayIndex = 0;
                dataGridView_ProjCritProdFulf.Columns[3].DisplayIndex = 1;
                dataGridView_ProjCritProdFulf.Columns[1].DisplayIndex = 2;
                dataGridView_ProjCritProdFulf.Columns[0].DisplayIndex = 3;
                dataGridView_ProjCritProdFulf.Columns[2].DisplayIndex = 4;
                //dataGridView_ProjCritProdFulf.Columns[6].Width = 200;
          
            }



        }
        private void AddProjProdCritFulfilment()
        {
            Product selectedProd = (Product)comboBox_ProjCritProdFulf.SelectedItem;
            aktProd = selectedProd.Product_Id;

        }
        private void GetProjProdFromDB()
        {

        }
        private void GetProjCritsFromDB()
        {

        }

        private void btn_ProdFulfPrint_Click(object sender, EventArgs e)
        {
            Product selectedItem = (Product)comboBox_ProjCritProdFulf.SelectedItem;

            FulfillmentForEachProductPrinter PrintEachProduct = new FulfillmentForEachProductPrinter(Project.Project_Id, selectedItem.Product_Id);
            PrintEachProduct.CreateFulfillmentForEachProductPdf();
        }

        private void dataGridView_ProjCritProdFulf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ProjCritProdFulfSave_Click(object sender, EventArgs e)
        {
            using(FulfillmentController fulCont = new FulfillmentController()){
                foreach (DataGridViewRow row in dataGridView_ProjCritProdFulf.Rows)
                { 

                
                
                }
            }
        }

       
    }
}
