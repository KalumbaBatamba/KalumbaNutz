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
            using (ProductController prodCon = new ProductController())
            {
                List<Product> ProdList = prodCon.GetAllProductsFromDb();
                var bindingList = new BindingList<Product>(ProdList);
                var source = new BindingSource(bindingList, null);
                comboBox_ProdChoose.DataSource = ProdList;
                comboBox_ProdChoose.DisplayMember = "Name";
                comboBox_ProdChoose.ValueMember = "Product_ID";
            }
            
        }
        private void GetAllProdFromDB()
        {

        }

        private void btn_ProdShow_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_ProdChoose.SelectedIndex;
            Product selectedItem = (Product)comboBox_ProdChoose.SelectedItem;
            Product_Show_View ProdShow = new Product_Show_View(selectedItem.Product_Id);
            ProdShow.Show();
            Hide();
        }

        private void btn_ProdUpdate_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_ProdChoose.SelectedIndex;
            Product selectedItem = (Product)comboBox_ProdChoose.SelectedItem;
            Product_Update_View ProdUpdate = new Product_Update_View(selectedItem.Product_Id);
            ProdUpdate.Show();
            Hide();
        }

        private void btn_ProdDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_ProdChoose.SelectedIndex;
            Product selectedItem = (Product)comboBox_ProdChoose.SelectedItem;
            using (ProductController prodDelete = new ProductController()) {

                prodDelete.DeleteProductFromDb(selectedItem.Product_Id);
            }
            
            MessageBox.Show("Wollen Sie das ausgeählte Produkt wirklich löschen?");
        }
        private void DeleteProdFromDB()
        {

        }

        private void btn_ProdCreate_Click(object sender, EventArgs e)
        {
            Product_Create_View ProdCreate = new Product_Create_View();
            ProdCreate.Show();
            Hide();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            using (ProductController ProdRefr = new ProductController())
            {
                List<Product> ProdList = ProdRefr.GetAllProductsFromDb();
                var bindingList = new BindingList<Product>(ProdList);
                var source = new BindingSource(bindingList, null);
                comboBox_ProdChoose.DataSource = ProdList;
                comboBox_ProdChoose.DisplayMember = "Name";
                comboBox_ProdChoose.ValueMember = "Product_ID";
            }
        }
    }
    public class aktRowProd
    {
        public static int ProdID;
        public static string ProdName;
        public static string ProdDescription;
        public static string ProdPrize;
    }
}
