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

        /// <summary>
        /// Handles the Load event of the Produktverwaltung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
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

        /// <summary>
        /// Handles the Click event of the btn_ProdShow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProdShow_Click(object sender, EventArgs e)
        {
            try{
            int selectedIndex = comboBox_ProdChoose.SelectedIndex;
            Product selectedItem = (Product)comboBox_ProdChoose.SelectedItem;
            Product_Show_View ProdShow = new Product_Show_View(selectedItem.Product_Id);
            ProdShow.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProdUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProdUpdate_Click(object sender, EventArgs e)
        {
            try{
            int selectedIndex = comboBox_ProdChoose.SelectedIndex;
            Product selectedItem = (Product)comboBox_ProdChoose.SelectedItem;
            Product_Update_View ProdUpdate = new Product_Update_View(selectedItem.Product_Id);
            ProdUpdate.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProdDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProdDelete_Click(object sender, EventArgs e)
        {
            try{
            int selectedIndex = comboBox_ProdChoose.SelectedIndex;
            Product selectedItem = (Product)comboBox_ProdChoose.SelectedItem;
            using (ProductController prodDelete = new ProductController()) {

                prodDelete.DeleteProductFromDb(selectedItem.Product_Id);
            }
            
            MessageBox.Show("Wollen Sie das ausgeählte Produkt wirklich löschen?");
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
        private void DeleteProdFromDB()
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_ProdCreate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProdCreate_Click(object sender, EventArgs e)
        {
            try{
            Product_Create_View ProdCreate = new Product_Create_View();
            ProdCreate.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_refresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_refresh_Click(object sender, EventArgs e)
        {
           try{
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
           catch (Exception x)
           {
               MessageBox.Show("Ups da lief was schief");
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
