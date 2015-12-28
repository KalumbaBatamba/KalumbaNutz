namespace NWAT
{
    partial class ProjCritProdFulfilment_Form
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
            this.dataGridView_ProjCritProdFulf = new System.Windows.Forms.DataGridView();
            this.btn_ProjCritProdFulfCancle = new System.Windows.Forms.Button();
            this.btn_ProjCritProdFulfSave = new System.Windows.Forms.Button();
            this.comboBox_ProjCritProdFulf = new System.Windows.Forms.ComboBox();
            this.ProjCritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritIDParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritBalaInd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritProdFulf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox_ProjCritProdFulf = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritProdFulf)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ProjCritProdFulf
            // 
            this.dataGridView_ProjCritProdFulf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjCritProdFulf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjCritID,
            this.ProjCritIDParent,
            this.ProjCritName,
            this.ProjCritBalaInd,
            this.ProjCritProdFulf});
            this.dataGridView_ProjCritProdFulf.Location = new System.Drawing.Point(13, 52);
            this.dataGridView_ProjCritProdFulf.Name = "dataGridView_ProjCritProdFulf";
            this.dataGridView_ProjCritProdFulf.Size = new System.Drawing.Size(575, 488);
            this.dataGridView_ProjCritProdFulf.TabIndex = 9;
            // 
            // btn_ProjCritProdFulfCancle
            // 
            this.btn_ProjCritProdFulfCancle.Location = new System.Drawing.Point(597, 516);
            this.btn_ProjCritProdFulfCancle.Name = "btn_ProjCritProdFulfCancle";
            this.btn_ProjCritProdFulfCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritProdFulfCancle.TabIndex = 11;
            this.btn_ProjCritProdFulfCancle.Text = "abbrechen";
            this.btn_ProjCritProdFulfCancle.UseVisualStyleBackColor = true;
            // 
            // btn_ProjCritProdFulfSave
            // 
            this.btn_ProjCritProdFulfSave.Location = new System.Drawing.Point(597, 487);
            this.btn_ProjCritProdFulfSave.Name = "btn_ProjCritProdFulfSave";
            this.btn_ProjCritProdFulfSave.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritProdFulfSave.TabIndex = 10;
            this.btn_ProjCritProdFulfSave.Text = "speichern";
            this.btn_ProjCritProdFulfSave.UseVisualStyleBackColor = true;
            // 
            // comboBox_ProjCritProdFulf
            // 
            this.comboBox_ProjCritProdFulf.FormattingEnabled = true;
            this.comboBox_ProjCritProdFulf.Location = new System.Drawing.Point(13, 25);
            this.comboBox_ProjCritProdFulf.Name = "comboBox_ProjCritProdFulf";
            this.comboBox_ProjCritProdFulf.Size = new System.Drawing.Size(229, 21);
            this.comboBox_ProjCritProdFulf.TabIndex = 12;
            this.comboBox_ProjCritProdFulf.Text = "Wählen Sie das Produkt aus";
            // 
            // ProjCritID
            // 
            this.ProjCritID.HeaderText = "ID";
            this.ProjCritID.Name = "ProjCritID";
            this.ProjCritID.Width = 30;
            // 
            // ProjCritIDParent
            // 
            this.ProjCritIDParent.HeaderText = "Parent ID";
            this.ProjCritIDParent.Name = "ProjCritIDParent";
            this.ProjCritIDParent.Width = 80;
            // 
            // ProjCritName
            // 
            this.ProjCritName.HeaderText = "Name";
            this.ProjCritName.Name = "ProjCritName";
            this.ProjCritName.Width = 150;
            // 
            // ProjCritBalaInd
            // 
            this.ProjCritBalaInd.HeaderText = "Gewichtungsfaktor";
            this.ProjCritBalaInd.Name = "ProjCritBalaInd";
            this.ProjCritBalaInd.Width = 110;
            // 
            // ProjCritProdFulf
            // 
            this.ProjCritProdFulf.HeaderText = "Erfüllung";
            this.ProjCritProdFulf.Name = "ProjCritProdFulf";
            this.ProjCritProdFulf.Width = 158;
            // 
            // checkBox_ProjCritProdFulf
            // 
            this.checkBox_ProjCritProdFulf.AutoSize = true;
            this.checkBox_ProjCritProdFulf.Location = new System.Drawing.Point(489, 77);
            this.checkBox_ProjCritProdFulf.Name = "checkBox_ProjCritProdFulf";
            this.checkBox_ProjCritProdFulf.Size = new System.Drawing.Size(15, 14);
            this.checkBox_ProjCritProdFulf.TabIndex = 13;
            this.checkBox_ProjCritProdFulf.UseVisualStyleBackColor = true;
            // 
            // ProjCritProdFulfilment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.checkBox_ProjCritProdFulf);
            this.Controls.Add(this.comboBox_ProjCritProdFulf);
            this.Controls.Add(this.dataGridView_ProjCritProdFulf);
            this.Controls.Add(this.btn_ProjCritProdFulfCancle);
            this.Controls.Add(this.btn_ProjCritProdFulfSave);
            this.Name = "ProjCritProdFulfilment";
            this.Text = "Produkt-Kriterienerfüllung";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritProdFulf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ProjCritProdFulf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritIDParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritBalaInd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritProdFulf;
        private System.Windows.Forms.Button btn_ProjCritProdFulfCancle;
        private System.Windows.Forms.Button btn_ProjCritProdFulfSave;
        private System.Windows.Forms.ComboBox comboBox_ProjCritProdFulf;
        private System.Windows.Forms.CheckBox checkBox_ProjCritProdFulf;
    }
}