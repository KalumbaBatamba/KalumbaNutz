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
    public partial class Product_Create_View : Form
    {
        private ProductController prodCont;
        public Product_Create_View()
        {
            this.prodCont = new ProductController();
            InitializeComponent();
        }

        private void Product_Create_Load(object sender, EventArgs e)
        {

        }

        private void btn_ProdCreate_Click(object sender, EventArgs e)
        {
            Product prodCre = new Product();
         //   prodCre.Product_Id = aktRowProd.ProdID;
            prodCre.Name = textBox_ProdNameCreate.Text;
            prodCre.Producer = textBox_ProdManuCreate.Text;
            prodCre.Price = Convert.ToDouble(textBox_ProdPrizeCreate.Text);
            prodCont.InsertProductIntoDb(prodCre);
            this.Close();
        }
        private void CreateNewProduct()
        {

        }
    }
}
