using NWAT.DB;
using NWAT.HelperClasses;
using System;
using System.Windows.Forms;

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

        private Produktverwaltung_View parentView;

        public Product_Update_View(Produktverwaltung_View parentView, int productId)
        {
            this.parentView = parentView;
            using (ProductController ProdUpdView = new ProductController()) 
            {
                this.Product = ProdUpdView.GetProductById(productId);
            }

            InitializeComponent();
        }




        /// <summary>
        /// Handles the Load event of the Product_Update_Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Product_Update_Form_Load(object sender, EventArgs e)
        {
            String ProdName = this.Product.Name;
            String ProdProducer = this.Product.Producer;
            double ProdPrice = this.Product.Price.Value;
            textBox_ProdNameUpdate.Text = this.Product.Name;
            textBox_ProdManuUpdate.Text = this.Product.Producer;
            textBox_ProdPrizeUpdate.Text = String.Format("{0:0.00}", this.Product.Price);
            this.FormClosing += new FormClosingEventHandler(Product_Update_View_FormClosing);
        }
        /// <summary>
        /// Handles the FormClosing event of the Product_Update_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void Product_Update_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentView.RefreshDropdown();
            this.parentView.Show();
        }


        /// <summary>
        /// Handles the Click event of the btn_ProdUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (ProductController prodUpdate = new ProductController())
                {
                    Product prodNew = prodUpdate.GetProductById(Product.Product_Id);
                    prodNew.Product_Id = this.Product.Product_Id;
                    prodNew.Name = textBox_ProdNameUpdate.Text;
                    prodNew.Producer = textBox_ProdManuUpdate.Text;

                    double check;
                    if (CommonMethods.CheckIfForbiddenDelimiterInDb(prodNew.Name) ||
                        CommonMethods.CheckIfForbiddenDelimiterInDb(prodNew.Producer))
                    {
                        MessageBox.Show(CommonMethods.MessageForbiddenDelimiterWasFoundInText());
                    }
                    else
                    {
                        if (Double.TryParse(textBox_ProdPrizeUpdate.Text, out check))
                        {
                            prodNew.Price = Convert.ToDouble(textBox_ProdPrizeUpdate.Text);
                            prodUpdate.UpdateProductInDb(prodNew);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Der Preis darf nur aus Zahlen bestehen!");
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
        private void UpdateProduct()
        {

        }
    }
}
