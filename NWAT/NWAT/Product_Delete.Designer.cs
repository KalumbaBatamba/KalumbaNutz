namespace NWAT
{
    partial class Product_Delete
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
            this.labelProdDeleteCheck = new System.Windows.Forms.Label();
            this.btn_ProdDelete = new System.Windows.Forms.Button();
            this.btn_ProdDelete_Cancle = new System.Windows.Forms.Button();
            this.label_ProdDesc = new System.Windows.Forms.Label();
            this.label_ProdName = new System.Windows.Forms.Label();
            this.label_ProdManu = new System.Windows.Forms.Label();
            this.label_ProdPrize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProdDeleteCheck
            // 
            this.labelProdDeleteCheck.AutoSize = true;
            this.labelProdDeleteCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProdDeleteCheck.Location = new System.Drawing.Point(11, 12);
            this.labelProdDeleteCheck.Name = "labelProdDeleteCheck";
            this.labelProdDeleteCheck.Size = new System.Drawing.Size(379, 16);
            this.labelProdDeleteCheck.TabIndex = 9;
            this.labelProdDeleteCheck.Text = "Sind Sie sicher, dass Sie folgendes Produkt löschen möchten?";
            // 
            // btn_ProdDelete
            // 
            this.btn_ProdDelete.Location = new System.Drawing.Point(258, 256);
            this.btn_ProdDelete.Name = "btn_ProdDelete";
            this.btn_ProdDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_ProdDelete.TabIndex = 8;
            this.btn_ProdDelete.Text = "löschen";
            this.btn_ProdDelete.UseVisualStyleBackColor = true;
            // 
            // btn_ProdDelete_Cancle
            // 
            this.btn_ProdDelete_Cancle.Location = new System.Drawing.Point(339, 255);
            this.btn_ProdDelete_Cancle.Name = "btn_ProdDelete_Cancle";
            this.btn_ProdDelete_Cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProdDelete_Cancle.TabIndex = 7;
            this.btn_ProdDelete_Cancle.Text = "abbrechen";
            this.btn_ProdDelete_Cancle.UseVisualStyleBackColor = true;
            // 
            // label_ProdDesc
            // 
            this.label_ProdDesc.AutoSize = true;
            this.label_ProdDesc.Location = new System.Drawing.Point(10, 124);
            this.label_ProdDesc.Name = "label_ProdDesc";
            this.label_ProdDesc.Size = new System.Drawing.Size(212, 13);
            this.label_ProdDesc.TabIndex = 6;
            this.label_ProdDesc.Text = "Beschreibung des ausgewählten Produktes";
            // 
            // label_ProdName
            // 
            this.label_ProdName.AutoSize = true;
            this.label_ProdName.Location = new System.Drawing.Point(10, 55);
            this.label_ProdName.Name = "label_ProdName";
            this.label_ProdName.Size = new System.Drawing.Size(175, 13);
            this.label_ProdName.TabIndex = 5;
            this.label_ProdName.Text = "Name des ausgewählten Produktes";
            // 
            // label_ProdManu
            // 
            this.label_ProdManu.AutoSize = true;
            this.label_ProdManu.Location = new System.Drawing.Point(10, 78);
            this.label_ProdManu.Name = "label_ProdManu";
            this.label_ProdManu.Size = new System.Drawing.Size(191, 13);
            this.label_ProdManu.TabIndex = 10;
            this.label_ProdManu.Text = "Hersteller des ausgewählten Produktes";
            // 
            // label_ProdPrize
            // 
            this.label_ProdPrize.AutoSize = true;
            this.label_ProdPrize.Location = new System.Drawing.Point(10, 101);
            this.label_ProdPrize.Name = "label_ProdPrize";
            this.label_ProdPrize.Size = new System.Drawing.Size(170, 13);
            this.label_ProdPrize.TabIndex = 11;
            this.label_ProdPrize.Text = "Preis des ausgewählten Produktes";
            // 
            // Product_Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.label_ProdPrize);
            this.Controls.Add(this.label_ProdManu);
            this.Controls.Add(this.labelProdDeleteCheck);
            this.Controls.Add(this.btn_ProdDelete);
            this.Controls.Add(this.btn_ProdDelete_Cancle);
            this.Controls.Add(this.label_ProdDesc);
            this.Controls.Add(this.label_ProdName);
            this.Name = "Product_Delete";
            this.Text = "Produkt löschen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProdDeleteCheck;
        private System.Windows.Forms.Button btn_ProdDelete;
        private System.Windows.Forms.Button btn_ProdDelete_Cancle;
        private System.Windows.Forms.Label label_ProdDesc;
        private System.Windows.Forms.Label label_ProdName;
        private System.Windows.Forms.Label label_ProdManu;
        private System.Windows.Forms.Label label_ProdPrize;
    }
}