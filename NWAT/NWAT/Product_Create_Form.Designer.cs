namespace NWAT
{
    partial class Product_Create_Form
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
            this.btn_ProdCreate = new System.Windows.Forms.Button();
            this.textBox_ProdDescCreate = new System.Windows.Forms.TextBox();
            this.textBox_ProdNameCreate = new System.Windows.Forms.TextBox();
            this.label_ProdDesc = new System.Windows.Forms.Label();
            this.label_ProdName = new System.Windows.Forms.Label();
            this.label_ProdManu = new System.Windows.Forms.Label();
            this.textBox_ProdManuCreate = new System.Windows.Forms.TextBox();
            this.textBox_ProdPrizeCreate = new System.Windows.Forms.TextBox();
            this.label_ProdPrize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ProdCreate
            // 
            this.btn_ProdCreate.Location = new System.Drawing.Point(336, 265);
            this.btn_ProdCreate.Name = "btn_ProdCreate";
            this.btn_ProdCreate.Size = new System.Drawing.Size(75, 23);
            this.btn_ProdCreate.TabIndex = 9;
            this.btn_ProdCreate.Text = "anlegen";
            this.btn_ProdCreate.UseVisualStyleBackColor = true;
            // 
            // textBox_ProdDescCreate
            // 
            this.textBox_ProdDescCreate.Location = new System.Drawing.Point(12, 172);
            this.textBox_ProdDescCreate.Multiline = true;
            this.textBox_ProdDescCreate.Name = "textBox_ProdDescCreate";
            this.textBox_ProdDescCreate.Size = new System.Drawing.Size(300, 116);
            this.textBox_ProdDescCreate.TabIndex = 8;
            // 
            // textBox_ProdNameCreate
            // 
            this.textBox_ProdNameCreate.Location = new System.Drawing.Point(12, 35);
            this.textBox_ProdNameCreate.Name = "textBox_ProdNameCreate";
            this.textBox_ProdNameCreate.Size = new System.Drawing.Size(300, 20);
            this.textBox_ProdNameCreate.TabIndex = 7;
            // 
            // label_ProdDesc
            // 
            this.label_ProdDesc.AutoSize = true;
            this.label_ProdDesc.Location = new System.Drawing.Point(9, 156);
            this.label_ProdDesc.Name = "label_ProdDesc";
            this.label_ProdDesc.Size = new System.Drawing.Size(111, 13);
            this.label_ProdDesc.TabIndex = 6;
            this.label_ProdDesc.Text = "Produktbeschreibung:";
            // 
            // label_ProdName
            // 
            this.label_ProdName.AutoSize = true;
            this.label_ProdName.Location = new System.Drawing.Point(11, 18);
            this.label_ProdName.Name = "label_ProdName";
            this.label_ProdName.Size = new System.Drawing.Size(73, 13);
            this.label_ProdName.TabIndex = 5;
            this.label_ProdName.Text = "Produktname:";
            // 
            // label_ProdManu
            // 
            this.label_ProdManu.AutoSize = true;
            this.label_ProdManu.Location = new System.Drawing.Point(9, 58);
            this.label_ProdManu.Name = "label_ProdManu";
            this.label_ProdManu.Size = new System.Drawing.Size(54, 13);
            this.label_ProdManu.TabIndex = 10;
            this.label_ProdManu.Text = "Hersteller:";
            // 
            // textBox_ProdManuCreate
            // 
            this.textBox_ProdManuCreate.Location = new System.Drawing.Point(12, 74);
            this.textBox_ProdManuCreate.Name = "textBox_ProdManuCreate";
            this.textBox_ProdManuCreate.Size = new System.Drawing.Size(300, 20);
            this.textBox_ProdManuCreate.TabIndex = 11;
            // 
            // textBox_ProdPrizeCreate
            // 
            this.textBox_ProdPrizeCreate.Location = new System.Drawing.Point(12, 113);
            this.textBox_ProdPrizeCreate.Name = "textBox_ProdPrizeCreate";
            this.textBox_ProdPrizeCreate.Size = new System.Drawing.Size(300, 20);
            this.textBox_ProdPrizeCreate.TabIndex = 12;
            // 
            // label_ProdPrize
            // 
            this.label_ProdPrize.AutoSize = true;
            this.label_ProdPrize.Location = new System.Drawing.Point(9, 97);
            this.label_ProdPrize.Name = "label_ProdPrize";
            this.label_ProdPrize.Size = new System.Drawing.Size(33, 13);
            this.label_ProdPrize.TabIndex = 13;
            this.label_ProdPrize.Text = "Preis:";
            // 
            // Product_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.label_ProdPrize);
            this.Controls.Add(this.textBox_ProdPrizeCreate);
            this.Controls.Add(this.textBox_ProdManuCreate);
            this.Controls.Add(this.label_ProdManu);
            this.Controls.Add(this.btn_ProdCreate);
            this.Controls.Add(this.textBox_ProdDescCreate);
            this.Controls.Add(this.textBox_ProdNameCreate);
            this.Controls.Add(this.label_ProdDesc);
            this.Controls.Add(this.label_ProdName);
            this.Name = "Product_Create";
            this.Text = "Produkt anlegen";
            this.Load += new System.EventHandler(this.Product_Create_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ProdCreate;
        private System.Windows.Forms.TextBox textBox_ProdDescCreate;
        private System.Windows.Forms.TextBox textBox_ProdNameCreate;
        private System.Windows.Forms.Label label_ProdDesc;
        private System.Windows.Forms.Label label_ProdName;
        private System.Windows.Forms.Label label_ProdManu;
        private System.Windows.Forms.TextBox textBox_ProdManuCreate;
        private System.Windows.Forms.TextBox textBox_ProdPrizeCreate;
        private System.Windows.Forms.Label label_ProdPrize;
    }
}