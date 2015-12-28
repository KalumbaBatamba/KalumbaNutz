namespace NWAT
{
    partial class Product_Update
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
            this.label_ProdPrize = new System.Windows.Forms.Label();
            this.textBox_ProdPrizeUpdate = new System.Windows.Forms.TextBox();
            this.textBox_ProdManuUpdate = new System.Windows.Forms.TextBox();
            this.label_ProdManu = new System.Windows.Forms.Label();
            this.btn_ProdUpdate = new System.Windows.Forms.Button();
            this.textBox_ProdDescUpdate = new System.Windows.Forms.TextBox();
            this.textBox_ProdNameUpdate = new System.Windows.Forms.TextBox();
            this.label_ProdDesc = new System.Windows.Forms.Label();
            this.label_ProdName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_ProdPrize
            // 
            this.label_ProdPrize.AutoSize = true;
            this.label_ProdPrize.Location = new System.Drawing.Point(11, 89);
            this.label_ProdPrize.Name = "label_ProdPrize";
            this.label_ProdPrize.Size = new System.Drawing.Size(33, 13);
            this.label_ProdPrize.TabIndex = 22;
            this.label_ProdPrize.Text = "Preis:";
            // 
            // textBox_ProdPrizeUpdate
            // 
            this.textBox_ProdPrizeUpdate.Location = new System.Drawing.Point(14, 105);
            this.textBox_ProdPrizeUpdate.Name = "textBox_ProdPrizeUpdate";
            this.textBox_ProdPrizeUpdate.Size = new System.Drawing.Size(300, 20);
            this.textBox_ProdPrizeUpdate.TabIndex = 21;
            // 
            // textBox_ProdManuUpdate
            // 
            this.textBox_ProdManuUpdate.Location = new System.Drawing.Point(14, 66);
            this.textBox_ProdManuUpdate.Name = "textBox_ProdManuUpdate";
            this.textBox_ProdManuUpdate.Size = new System.Drawing.Size(300, 20);
            this.textBox_ProdManuUpdate.TabIndex = 20;
            // 
            // label_ProdManu
            // 
            this.label_ProdManu.AutoSize = true;
            this.label_ProdManu.Location = new System.Drawing.Point(11, 50);
            this.label_ProdManu.Name = "label_ProdManu";
            this.label_ProdManu.Size = new System.Drawing.Size(54, 13);
            this.label_ProdManu.TabIndex = 19;
            this.label_ProdManu.Text = "Hersteller:";
            // 
            // btn_ProdUpdate
            // 
            this.btn_ProdUpdate.Location = new System.Drawing.Point(338, 257);
            this.btn_ProdUpdate.Name = "btn_ProdUpdate";
            this.btn_ProdUpdate.Size = new System.Drawing.Size(75, 23);
            this.btn_ProdUpdate.TabIndex = 18;
            this.btn_ProdUpdate.Text = "ändern";
            this.btn_ProdUpdate.UseVisualStyleBackColor = true;
            // 
            // textBox_ProdDescUpdate
            // 
            this.textBox_ProdDescUpdate.Location = new System.Drawing.Point(14, 164);
            this.textBox_ProdDescUpdate.Multiline = true;
            this.textBox_ProdDescUpdate.Name = "textBox_ProdDescUpdate";
            this.textBox_ProdDescUpdate.Size = new System.Drawing.Size(300, 116);
            this.textBox_ProdDescUpdate.TabIndex = 17;
            // 
            // textBox_ProdNameUpdate
            // 
            this.textBox_ProdNameUpdate.Location = new System.Drawing.Point(14, 27);
            this.textBox_ProdNameUpdate.Name = "textBox_ProdNameUpdate";
            this.textBox_ProdNameUpdate.Size = new System.Drawing.Size(300, 20);
            this.textBox_ProdNameUpdate.TabIndex = 16;
            // 
            // label_ProdDesc
            // 
            this.label_ProdDesc.AutoSize = true;
            this.label_ProdDesc.Location = new System.Drawing.Point(11, 148);
            this.label_ProdDesc.Name = "label_ProdDesc";
            this.label_ProdDesc.Size = new System.Drawing.Size(111, 13);
            this.label_ProdDesc.TabIndex = 15;
            this.label_ProdDesc.Text = "Produktbeschreibung:";
            // 
            // label_ProdName
            // 
            this.label_ProdName.AutoSize = true;
            this.label_ProdName.Location = new System.Drawing.Point(13, 10);
            this.label_ProdName.Name = "label_ProdName";
            this.label_ProdName.Size = new System.Drawing.Size(73, 13);
            this.label_ProdName.TabIndex = 14;
            this.label_ProdName.Text = "Produktname:";
            // 
            // Product_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.label_ProdPrize);
            this.Controls.Add(this.textBox_ProdPrizeUpdate);
            this.Controls.Add(this.textBox_ProdManuUpdate);
            this.Controls.Add(this.label_ProdManu);
            this.Controls.Add(this.btn_ProdUpdate);
            this.Controls.Add(this.textBox_ProdDescUpdate);
            this.Controls.Add(this.textBox_ProdNameUpdate);
            this.Controls.Add(this.label_ProdDesc);
            this.Controls.Add(this.label_ProdName);
            this.Name = "Product_Update";
            this.Text = "Product_Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ProdPrize;
        private System.Windows.Forms.TextBox textBox_ProdPrizeUpdate;
        private System.Windows.Forms.TextBox textBox_ProdManuUpdate;
        private System.Windows.Forms.Label label_ProdManu;
        private System.Windows.Forms.Button btn_ProdUpdate;
        private System.Windows.Forms.TextBox textBox_ProdDescUpdate;
        private System.Windows.Forms.TextBox textBox_ProdNameUpdate;
        private System.Windows.Forms.Label label_ProdDesc;
        private System.Windows.Forms.Label label_ProdName;
    }
}