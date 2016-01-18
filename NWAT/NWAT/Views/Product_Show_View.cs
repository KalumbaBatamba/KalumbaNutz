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
        private ProductController prodCont;
        public Product_Show_View()
        {
            this.prodCont = new ProductController();
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

           Product prod = prodCont.GetProductById(aktRowProd.ProdID);
           String ProdName = prod.Name;
           String ProdProducer = prod.Producer;
           double ProdPrice = prod.Price.Value;
           MessageBox.Show(ProdName + ProdProducer);
           label_ProdNameShow.Text = ProdName; 
           label_ProdManuShow.Text = ProdProducer;
           label_ProdPrizeShow.Text = String.Format("{0:0.00}", ProdPrice);

        //    Product prod = new Product();
        //    prod = prodCont.GetProductById(aktRowProd.ProdID);
      //      string test = aktRowProd.ProdID;
         //  MessageBox.Show(prod.Product_Id + prod.Name);
            //label_ProdNameShow.Text = prod.Product_Id.ToString();
        //    MessageBox.Show(prod.Name);
            
            
      //            label_ProdNameShow = prodCont.GetProductById(aktRowProd.ProdID);
        //    label_ProdDescShow.Text = ProdName; 
        //    label_ProdManuShow.Text = ProdProducer;
        //    label_ProdPrizeShow.Text = ProdPrice;
        }
    }
}


