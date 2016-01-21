namespace NWAT.Views
{
    partial class ProjProdFulfillmentPrinter_View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1_ShowProduct = new System.Windows.Forms.ComboBox();
            this.btn_PrintFulfillmentForEachProduct = new System.Windows.Forms.Button();
            this.label_ChooseProduct = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1_ShowProduct
            // 
            this.comboBox1_ShowProduct.FormattingEnabled = true;
            this.comboBox1_ShowProduct.Location = new System.Drawing.Point(13, 48);
            this.comboBox1_ShowProduct.Name = "comboBox1_ShowProduct";
            this.comboBox1_ShowProduct.Size = new System.Drawing.Size(233, 21);
            this.comboBox1_ShowProduct.TabIndex = 0;
            this.comboBox1_ShowProduct.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_PrintFulfillmentForEachProduct
            // 
            this.btn_PrintFulfillmentForEachProduct.Location = new System.Drawing.Point(13, 116);
            this.btn_PrintFulfillmentForEachProduct.Name = "btn_PrintFulfillmentForEachProduct";
            this.btn_PrintFulfillmentForEachProduct.Size = new System.Drawing.Size(146, 23);
            this.btn_PrintFulfillmentForEachProduct.TabIndex = 1;
            this.btn_PrintFulfillmentForEachProduct.Text = "Erfüllung Drucken";
            this.btn_PrintFulfillmentForEachProduct.UseVisualStyleBackColor = true;
            this.btn_PrintFulfillmentForEachProduct.Click += new System.EventHandler(this.btn_PrintFulfillmentForEachProduct_Click);
            // 
            // label_ChooseProduct
            // 
            this.label_ChooseProduct.AutoSize = true;
            this.label_ChooseProduct.Location = new System.Drawing.Point(12, 21);
            this.label_ChooseProduct.Name = "label_ChooseProduct";
            this.label_ChooseProduct.Size = new System.Drawing.Size(44, 13);
            this.label_ChooseProduct.TabIndex = 2;
            this.label_ChooseProduct.Text = "Produkt";
            // 
            // ProjProdFulfillmentPrinter_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 288);
            this.Controls.Add(this.label_ChooseProduct);
            this.Controls.Add(this.btn_PrintFulfillmentForEachProduct);
            this.Controls.Add(this.comboBox1_ShowProduct);
            this.Name = "ProjProdFulfillmentPrinter_View";
            this.Text = "Erfüllung Drucken";
            this.Load += new System.EventHandler(this.ProjProdFulfillmentPrinter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1_ShowProduct;
        private System.Windows.Forms.Button btn_PrintFulfillmentForEachProduct;
        private System.Windows.Forms.Label label_ChooseProduct;
    }
}