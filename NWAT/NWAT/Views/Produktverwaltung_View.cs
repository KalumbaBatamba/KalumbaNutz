using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace NWAT
{
    public partial class Produktverwaltung_View : Form
    {
        private ProductController prodCont;
        private Form parentView;
        public Produktverwaltung_View(Form parentView)
        {
            this.parentView = parentView;
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

        /// <summary>
        /// Handles the FormClosing event of the Productverwaltung_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        

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
            Product_Show_View ProdShow = new Product_Show_View(this, selectedItem.Product_Id);
            ProdShow.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
            Product_Update_View ProdUpdate = new Product_Update_View(this, selectedItem.Product_Id);
            ProdUpdate.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
            try
            {
                int selectedIndex = comboBox_ProdChoose.SelectedIndex;
                Product selectedItem = (Product)comboBox_ProdChoose.SelectedItem;
                using (ProductController prodDelete = new ProductController())
                {


                    var result = MessageBox.Show("Wollen Sie das ausgeählte Produkt wirklich löschen?",
                        "Löschbestätigung",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        prodDelete.DeleteProductFromDb(selectedItem.Product_Id);
                        RefreshDropdown();
                    }
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
            Product_Create_View ProdCreate = new Product_Create_View(this);
            ProdCreate.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
            RefreshDropdown();
        }

        /// <summary>
        /// refreshs dropdown menue
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        public void RefreshDropdown()
        {
            try
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
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the Productverwaltung_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Produktverwaltung_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentView.Show();
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
