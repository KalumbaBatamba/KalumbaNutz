﻿using System;
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
            Produktverwaltung_View back = new Produktverwaltung_View();
            back.Show();
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
          if (prodCre.Name.Contains("|") || prodCre.Producer.Contains("|"))
            {
                MessageBox.Show("Das Zeichen: | ist nicht erlaubt. Bitte ändern Sie Ihre Eingabe");
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
                MessageBox.Show("Ups da lief was schief");
            }
        }
        private void CreateNewProduct()
        {

        }
    }
}
