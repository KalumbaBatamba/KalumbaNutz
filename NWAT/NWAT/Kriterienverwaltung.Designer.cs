namespace NWAT
{
    partial class Kriterienverwaltung
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
            this.comboBox_CritChoose = new System.Windows.Forms.ComboBox();
            this.lable_CritChoose = new System.Windows.Forms.Label();
            this.btn_CritShow = new System.Windows.Forms.Button();
            this.btn_CritUpdate = new System.Windows.Forms.Button();
            this.btn_CritDelete = new System.Windows.Forms.Button();
            this.textBox_CritCreateName = new System.Windows.Forms.TextBox();
            this.label_CritCreateName = new System.Windows.Forms.Label();
            this.btn_CritCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_CritChoose
            // 
            this.comboBox_CritChoose.FormattingEnabled = true;
            this.comboBox_CritChoose.Location = new System.Drawing.Point(13, 30);
            this.comboBox_CritChoose.Name = "comboBox_CritChoose";
            this.comboBox_CritChoose.Size = new System.Drawing.Size(300, 21);
            this.comboBox_CritChoose.TabIndex = 0;
            this.comboBox_CritChoose.Text = "Wählen Sie ein Kriterium aus der Liste aus";
            // 
            // lable_CritChoose
            // 
            this.lable_CritChoose.AutoSize = true;
            this.lable_CritChoose.Location = new System.Drawing.Point(10, 14);
            this.lable_CritChoose.Name = "lable_CritChoose";
            this.lable_CritChoose.Size = new System.Drawing.Size(170, 13);
            this.lable_CritChoose.TabIndex = 1;
            this.lable_CritChoose.Text = "Vorhandenes Kriterium auswählen:";
            // 
            // btn_CritShow
            // 
            this.btn_CritShow.Location = new System.Drawing.Point(367, 27);
            this.btn_CritShow.Name = "btn_CritShow";
            this.btn_CritShow.Size = new System.Drawing.Size(75, 23);
            this.btn_CritShow.TabIndex = 2;
            this.btn_CritShow.Text = "anzeigen";
            this.btn_CritShow.UseVisualStyleBackColor = true;
            // 
            // btn_CritUpdate
            // 
            this.btn_CritUpdate.Location = new System.Drawing.Point(367, 57);
            this.btn_CritUpdate.Name = "btn_CritUpdate";
            this.btn_CritUpdate.Size = new System.Drawing.Size(75, 23);
            this.btn_CritUpdate.TabIndex = 3;
            this.btn_CritUpdate.Text = "ändern";
            this.btn_CritUpdate.UseVisualStyleBackColor = true;
            // 
            // btn_CritDelete
            // 
            this.btn_CritDelete.Location = new System.Drawing.Point(367, 87);
            this.btn_CritDelete.Name = "btn_CritDelete";
            this.btn_CritDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_CritDelete.TabIndex = 4;
            this.btn_CritDelete.Text = "löschen";
            this.btn_CritDelete.UseVisualStyleBackColor = true;
            // 
            // textBox_CritCreateName
            // 
            this.textBox_CritCreateName.Location = new System.Drawing.Point(13, 138);
            this.textBox_CritCreateName.Name = "textBox_CritCreateName";
            this.textBox_CritCreateName.Size = new System.Drawing.Size(300, 20);
            this.textBox_CritCreateName.TabIndex = 5;
            this.textBox_CritCreateName.Text = "Geben Sie den Kriterienname ein";
            // 
            // label_CritCreateName
            // 
            this.label_CritCreateName.AutoSize = true;
            this.label_CritCreateName.Location = new System.Drawing.Point(10, 122);
            this.label_CritCreateName.Name = "label_CritCreateName";
            this.label_CritCreateName.Size = new System.Drawing.Size(125, 13);
            this.label_CritCreateName.TabIndex = 6;
            this.label_CritCreateName.Text = "Neues Kriterium anlegen:";
            // 
            // btn_CritCreate
            // 
            this.btn_CritCreate.Location = new System.Drawing.Point(367, 138);
            this.btn_CritCreate.Name = "btn_CritCreate";
            this.btn_CritCreate.Size = new System.Drawing.Size(75, 23);
            this.btn_CritCreate.TabIndex = 7;
            this.btn_CritCreate.Text = "anlegen";
            this.btn_CritCreate.UseVisualStyleBackColor = true;
            // 
            // Kriterienverwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 291);
            this.Controls.Add(this.btn_CritCreate);
            this.Controls.Add(this.label_CritCreateName);
            this.Controls.Add(this.textBox_CritCreateName);
            this.Controls.Add(this.btn_CritDelete);
            this.Controls.Add(this.btn_CritUpdate);
            this.Controls.Add(this.btn_CritShow);
            this.Controls.Add(this.lable_CritChoose);
            this.Controls.Add(this.comboBox_CritChoose);
            this.Name = "Kriterienverwaltung";
            this.Text = "Kriterienverwaltung";
            this.Load += new System.EventHandler(this.Kriterienverwaltung_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_CritChoose;
        private System.Windows.Forms.Label lable_CritChoose;
        private System.Windows.Forms.Button btn_CritShow;
        private System.Windows.Forms.Button btn_CritUpdate;
        private System.Windows.Forms.Button btn_CritDelete;
        private System.Windows.Forms.TextBox textBox_CritCreateName;
        private System.Windows.Forms.Label label_CritCreateName;
        private System.Windows.Forms.Button btn_CritCreate;
    }
}