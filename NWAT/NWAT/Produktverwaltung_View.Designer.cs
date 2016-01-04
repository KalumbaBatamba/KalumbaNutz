namespace NWAT
{
    partial class Produktverwaltung_View
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
            this.label_ProdCreateName = new System.Windows.Forms.Label();
            this.textBox_ProdCreateName = new System.Windows.Forms.TextBox();
            this.btn_ProdDelete = new System.Windows.Forms.Button();
            this.btn_ProdUpdate = new System.Windows.Forms.Button();
            this.btn_ProdShow = new System.Windows.Forms.Button();
            this.lable_ProdChoose = new System.Windows.Forms.Label();
            this.comboBox_ProdChoose = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_ProdCreate
            // 
            this.btn_ProdCreate.Location = new System.Drawing.Point(363, 184);
            this.btn_ProdCreate.Name = "btn_ProdCreate";
            this.btn_ProdCreate.Size = new System.Drawing.Size(75, 23);
            this.btn_ProdCreate.TabIndex = 15;
            this.btn_ProdCreate.Text = "anlegen";
            this.btn_ProdCreate.UseVisualStyleBackColor = true;
            // 
            // label_ProdCreateName
            // 
            this.label_ProdCreateName.AutoSize = true;
            this.label_ProdCreateName.Location = new System.Drawing.Point(9, 165);
            this.label_ProdCreateName.Name = "label_ProdCreateName";
            this.label_ProdCreateName.Size = new System.Drawing.Size(122, 13);
            this.label_ProdCreateName.TabIndex = 14;
            this.label_ProdCreateName.Text = "Neues Produkt anlegen:";
            // 
            // textBox_ProdCreateName
            // 
            this.textBox_ProdCreateName.Location = new System.Drawing.Point(9, 184);
            this.textBox_ProdCreateName.Name = "textBox_ProdCreateName";
            this.textBox_ProdCreateName.Size = new System.Drawing.Size(300, 20);
            this.textBox_ProdCreateName.TabIndex = 13;
            this.textBox_ProdCreateName.Text = "Geben Sie den Produktname ein";
            // 
            // btn_ProdDelete
            // 
            this.btn_ProdDelete.Location = new System.Drawing.Point(363, 133);
            this.btn_ProdDelete.Name = "btn_ProdDelete";
            this.btn_ProdDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_ProdDelete.TabIndex = 12;
            this.btn_ProdDelete.Text = "löschen";
            this.btn_ProdDelete.UseVisualStyleBackColor = true;
            this.btn_ProdDelete.Click += new System.EventHandler(this.btn_ProdDelete_Click);
            // 
            // btn_ProdUpdate
            // 
            this.btn_ProdUpdate.Location = new System.Drawing.Point(363, 103);
            this.btn_ProdUpdate.Name = "btn_ProdUpdate";
            this.btn_ProdUpdate.Size = new System.Drawing.Size(75, 23);
            this.btn_ProdUpdate.TabIndex = 11;
            this.btn_ProdUpdate.Text = "ändern";
            this.btn_ProdUpdate.UseVisualStyleBackColor = true;
            this.btn_ProdUpdate.Click += new System.EventHandler(this.btn_ProdUpdate_Click);
            // 
            // btn_ProdShow
            // 
            this.btn_ProdShow.Location = new System.Drawing.Point(363, 73);
            this.btn_ProdShow.Name = "btn_ProdShow";
            this.btn_ProdShow.Size = new System.Drawing.Size(75, 23);
            this.btn_ProdShow.TabIndex = 10;
            this.btn_ProdShow.Text = "anzeigen";
            this.btn_ProdShow.UseVisualStyleBackColor = true;
            this.btn_ProdShow.Click += new System.EventHandler(this.btn_ProdShow_Click);
            // 
            // lable_ProdChoose
            // 
            this.lable_ProdChoose.AutoSize = true;
            this.lable_ProdChoose.Location = new System.Drawing.Point(6, 60);
            this.lable_ProdChoose.Name = "lable_ProdChoose";
            this.lable_ProdChoose.Size = new System.Drawing.Size(167, 13);
            this.lable_ProdChoose.TabIndex = 9;
            this.lable_ProdChoose.Text = "Vorhandenes Produkt auswählen:";
            // 
            // comboBox_ProdChoose
            // 
            this.comboBox_ProdChoose.FormattingEnabled = true;
            this.comboBox_ProdChoose.Location = new System.Drawing.Point(9, 76);
            this.comboBox_ProdChoose.Name = "comboBox_ProdChoose";
            this.comboBox_ProdChoose.Size = new System.Drawing.Size(300, 21);
            this.comboBox_ProdChoose.TabIndex = 8;
            this.comboBox_ProdChoose.Text = "Wählen Sie ein Produkt aus der Liste aus";
            // 
            // Produktverwaltung_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 391);
            this.Controls.Add(this.btn_ProdCreate);
            this.Controls.Add(this.label_ProdCreateName);
            this.Controls.Add(this.textBox_ProdCreateName);
            this.Controls.Add(this.btn_ProdDelete);
            this.Controls.Add(this.btn_ProdUpdate);
            this.Controls.Add(this.btn_ProdShow);
            this.Controls.Add(this.lable_ProdChoose);
            this.Controls.Add(this.comboBox_ProdChoose);
            this.Name = "Produktverwaltung_Form";
            this.Text = "Produktverwaltung";
            this.Load += new System.EventHandler(this.Produktverwaltung_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ProdCreate;
        private System.Windows.Forms.Label label_ProdCreateName;
        private System.Windows.Forms.TextBox textBox_ProdCreateName;
        private System.Windows.Forms.Button btn_ProdDelete;
        private System.Windows.Forms.Button btn_ProdUpdate;
        private System.Windows.Forms.Button btn_ProdShow;
        private System.Windows.Forms.Label lable_ProdChoose;
        private System.Windows.Forms.ComboBox comboBox_ProdChoose;
    }
}