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
    public partial class Product_Update_View : Form
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
        
        
  //      private ProductController prodCont;
        public Product_Update_View(int productId)
        {
      //      this.prodCont = new ProductController();
            this.ProductCont = new ProductController();
            this.Product = this.ProductCont.GetProductById(productId);
            InitializeComponent();
        }
        


      
        private void Product_Update_Form_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(prod.Name + prod.Producer);
            String ProdName = this.Product.Name;
            String ProdProducer = this.Product.Producer;
            double ProdPrice = this.Product.Price.Value;
            MessageBox.Show(ProdName + ProdProducer);
            textBox_ProdNameUpdate.Text = this.Product.Name;
            textBox_ProdManuUpdate.Text = this.Product.Producer;
            textBox_ProdPrizeUpdate.Text = String.Format("{0:0.00}", this.Product.Price);
        }

        private void btn_ProdUpdate_Click(object sender, EventArgs e)
        {
        //    int x = this.Product.Product_Id;
            Product prodNew = ProductCont.GetProductById(Product.Product_Id);
            prodNew.Product_Id = this.Product.Product_Id;  // aktRowProd.ProdID;
            prodNew.Name = textBox_ProdNameUpdate.Text;
            prodNew.Producer = textBox_ProdManuUpdate.Text;
            prodNew.Price = Convert.ToDouble(textBox_ProdPrizeUpdate.Text);
            ProductCont.UpdateProductInDb(prodNew);
            this.Close();
        }
        private void UpdateProduct()
        {

        }
    }
}
