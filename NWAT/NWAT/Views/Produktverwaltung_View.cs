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
    public partial class Produktverwaltung_View : Form
    {
        private ProductController prodCont;
        public Produktverwaltung_View()
        {
            this.prodCont = new ProductController();
            InitializeComponent();
        }

        private void Produktverwaltung_Load(object sender, EventArgs e)
        {

        }
        private void GetAllProdFromDB()
        {

        }

        private void btn_ProdShow_Click(object sender, EventArgs e)
        {
            Product_Show_View ProdShow = new Product_Show_View();
            ProdShow.Show();
        }

        private void btn_ProdUpdate_Click(object sender, EventArgs e)
        {
            Product_Update_View ProdUpdate = new Product_Update_View();
            ProdUpdate.Show();
        }

        private void btn_ProdDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wollen Sie das ausgeählte Produkt wirklich löschen?");
        }
        private void DeleteProdFromDB()
        {

        }

        private void btn_ProdCreate_Click(object sender, EventArgs e)
        {
            Product_Create_View ProdCreate = new Product_Create_View();
            ProdCreate.Show();
        }
    }
}
