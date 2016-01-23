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

        private ProjectController _projectController;


        private ProjectCriterionController projCritCont;

        public ProjCritProdFulfilment_View(int projectId)
        {
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();
        }

        private void ProjCritProdFulfilment_Form_Load(object sender, EventArgs e)
        {

            using (ProjectProductController Projverw = new ProjectProductController())
            {
                ProjectProduct projprod = (ProjectProduct)comboBox_ProjCritProdFulf.SelectedItem;
                List<ProjectProduct> ProdList = Projverw.GetAllProjectProductsForOneProject(Project.Project_Id);
                List<Product> productsList = new List<Product>();
                foreach (ProjectProduct projProd in ProdList)
                {
                    productsList.Add(projProd.Product); 
                }
                comboBox_ProjCritProdFulf.DataSource = productsList;
                
                comboBox_ProjCritProdFulf.DisplayMember = "Name";    
            }
        }
        private void AddProjProdCritFulfilment()
        {

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

       
    }
}
