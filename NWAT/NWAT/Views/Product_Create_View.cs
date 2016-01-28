using NWAT.DB;
using NWAT.HelperClasses;
using System;
using System.Windows.Forms;

namespace NWAT
{
    public partial class Product_Create_View : Form
    {
        private ProductController prodCont;
        private Produktverwaltung_View parentView;
        public Product_Create_View(Produktverwaltung_View parentView)
        {
            this.parentView = parentView;
            this.prodCont = new ProductController();
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Product_Create control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Product_Create_Load(object sender, EventArgs e)
        {

            this.FormClosing += new FormClosingEventHandler(Product_Create_View_FormClosing);
        }
        /// <summary>
        /// Handles the FormClosing event of the Product_Create_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void Product_Create_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentView.RefreshDropdown();
            this.parentView.Show();
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
          Product prodCre = new Product();
          prodCre.Name = textBox_ProdNameCreate.Text;
          prodCre.Producer = textBox_ProdManuCreate.Text;
          double check;
          if (CommonMethods.CheckIfForbiddenDelimiterInDb(prodCre.Name) ||
              CommonMethods.CheckIfForbiddenDelimiterInDb(prodCre.Producer))
          {
              MessageBox.Show(CommonMethods.MessageForbiddenDelimiterWasFoundInText());
          }
          else
          {
              if (Double.TryParse(textBox_ProdPrizeCreate.Text, out check))
              {
                  prodCre.Price = Convert.ToDouble(textBox_ProdPrizeCreate.Text);
                  prodCont.InsertProductIntoDb(prodCre);
                  this.Close();
              }
              else
              {
                  MessageBox.Show("Der Preis darf nur aus Zahlen bestehen!");
              }
          }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void CreateNewProduct()
        {

        }
    }
}
