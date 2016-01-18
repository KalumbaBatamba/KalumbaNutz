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
        private ProductController prodCont;
        public Product_Update_View()
        {
            this.prodCont = new ProductController();
            InitializeComponent();
        }

        private void Product_Update_Form_Load(object sender, EventArgs e)
        {
            Product prod = prodCont.GetProductById(aktRowProd.ProdID);
           // MessageBox.Show(prod.Name + prod.Producer);
            String ProdName = prod.Name;
            String ProdProducer = prod.Producer;
            double ProdPrice = prod.Price.Value;
            MessageBox.Show(ProdName + ProdProducer);
            textBox_ProdNameUpdate.Text = ProdName;
            textBox_ProdManuUpdate.Text = ProdProducer;
            textBox_ProdPrizeUpdate.Text = String.Format("{0:0.00}", ProdPrice);
        }

        private void btn_ProdUpdate_Click(object sender, EventArgs e)
        {
            Product prodNew = new Product();
            prodNew.Product_Id = aktRowProd.ProdID;
            prodNew.Name = textBox_ProdNameUpdate.Text;
            prodNew.Producer = textBox_ProdManuUpdate.Text;
            prodNew.Price = Convert.ToDouble(textBox_ProdPrizeUpdate.Text);
            prodCont.UpdateProductInDb(prodNew);
           // this.Close();
        }
        private void UpdateProduct()
        {

        }
    }
}
