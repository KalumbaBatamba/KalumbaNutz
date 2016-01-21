using NWAT.DB;
using NWAT.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NWAT.Printer;

namespace NWAT.Views
{
    public partial class ProjProdFulfillmentPrinter_View : Form
    {
        private ProjectController projCont;

        private Project _projectid;
        private Product _productid;
        private Fulfillment _fulfilled;

        public Project Project
        {
            get { return _projectid; }
            set { _projectid = value; }
        }


        public Product Product
        {
            get { return _productid; }
            set { _productid = value; }
        }

        public Fulfillment Fulfillment
        {
            get { return _fulfilled; }
            set { _fulfilled = value; }
        }

        private List<Fulfillment> _fulfillmentForEachProduct;

        public List<Fulfillment> FulfillmentForEachProduct
        {
            get { return _fulfillmentForEachProduct; }
            set { _fulfillmentForEachProduct = value; }
        }

        private ProjectCriterionController _projectCriterionController;
        public ProjectCriterionController ProjCritContr
        {
            get { return _projectCriterionController; }
            set { _projectCriterionController = value; }
        }


        private ProductController _projProduct;
        public ProductController ProjProduct
        {
            get { return _projProduct; }
            set { _projProduct = value; }
        }

        private FulfillmentController _fulfillmentController;
        public FulfillmentController FulFillContr
        {
            get { return _fulfillmentController; }
            set { _fulfillmentController = value; }
        }

        

        public ProjProdFulfillmentPrinter_View()
        {
            InitializeComponent();
            this.ProjProduct = new ProductController();
            ProductController projProdController = new ProductController();
            this.projCont = new ProjectController();
        }

        private void ProjProdFulfillmentPrinter_Load(object sender, EventArgs e)
        {
            using (ProjectController Projverw = new ProjectController())
            {
                List<Product> products = this.ProjProduct.GetAllProductsFromDb();
                var bindingList = new BindingList<Product>(products);
                var source = new BindingSource(bindingList, null);
                comboBox1_ShowProduct.DataSource = products;
                comboBox1_ShowProduct.DisplayMember = "Name";
                comboBox1_ShowProduct.ValueMember = "Project_ID";
            }

            int selectedIndex = comboBox1_ShowProduct.SelectedIndex;
            Project selectedItem = (Project)comboBox1_ShowProduct.SelectedItem;
            MessageBox.Show("Selected Item Text: " + selectedItem.Project_Id);

            Project_Show_View ProjectShow = new Project_Show_View(selectedItem.Project_Id);
            ProjectShow.Show();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_PrintFulfillmentForEachProduct_Click(object sender, EventArgs e)
        {
            
        }
    }
}
