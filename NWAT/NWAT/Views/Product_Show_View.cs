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
    public partial class Product_Show_View : Form
    {
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private ProductController _productCont;

        public ProductController ProductCont
        {
            get { return _productCont; }
            set { _productCont = value; }
        }

        public Product_Show_View(int productID)
        {
           this.ProductCont = new ProductController();
           this.Product = this.ProductCont.GetProductById(productID);
           InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowProdSpecs()
        {

        }

        private void Product_Show_View_Load(object sender, EventArgs e)
        {

           String ProdName = this.Product.Name;
           String ProdProducer = this.Product.Producer;
           double ProdPrice = this.Product.Price.Value;
           label_ProdNameShow.Text = this.Product.Name; 
           label_ProdManuShow.Text = this.Product.Producer;
           label_ProdPrizeShow.Text = String.Format("{0:0.00}", this.Product.Price);
           this.FormClosing += new FormClosingEventHandler(Product_Show_View_FormClosing);
        }
        void Product_Show_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            Produktverwaltung_View back = new Produktverwaltung_View();
            back.Show();
        }

    }
}


