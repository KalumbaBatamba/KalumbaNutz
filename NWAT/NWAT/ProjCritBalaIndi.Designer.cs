namespace NWAT
{
    partial class ProjCritBalaIndi
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
            this.dataGridView_ProjCritBalaIndi = new System.Windows.Forms.DataGridView();
            this.btn_ProjCritBalaIndiCancle = new System.Windows.Forms.Button();
            this.btn_ProjCritBalaIndiSave = new System.Windows.Forms.Button();
            this.ProjCritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritIDParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritBalaInd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritBalaIndi)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ProjCritBalaIndi
            // 
            this.dataGridView_ProjCritBalaIndi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjCritBalaIndi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjCritID,
            this.ProjCritIDParent,
            this.ProjCritName,
            this.ProjCritBalaInd,
            this.ProjCritDesc});
            this.dataGridView_ProjCritBalaIndi.Location = new System.Drawing.Point(13, 20);
            this.dataGridView_ProjCritBalaIndi.Name = "dataGridView_ProjCritBalaIndi";
            this.dataGridView_ProjCritBalaIndi.Size = new System.Drawing.Size(575, 520);
            this.dataGridView_ProjCritBalaIndi.TabIndex = 6;
            // 
            // btn_ProjCritBalaIndiCancle
            // 
            this.btn_ProjCritBalaIndiCancle.Location = new System.Drawing.Point(597, 516);
            this.btn_ProjCritBalaIndiCancle.Name = "btn_ProjCritBalaIndiCancle";
            this.btn_ProjCritBalaIndiCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritBalaIndiCancle.TabIndex = 8;
            this.btn_ProjCritBalaIndiCancle.Text = "abbrechen";
            this.btn_ProjCritBalaIndiCancle.UseVisualStyleBackColor = true;
            // 
            // btn_ProjCritBalaIndiSave
            // 
            this.btn_ProjCritBalaIndiSave.Location = new System.Drawing.Point(597, 487);
            this.btn_ProjCritBalaIndiSave.Name = "btn_ProjCritBalaIndiSave";
            this.btn_ProjCritBalaIndiSave.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritBalaIndiSave.TabIndex = 7;
            this.btn_ProjCritBalaIndiSave.Text = "speichern";
            this.btn_ProjCritBalaIndiSave.UseVisualStyleBackColor = true;
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
            // ProjCritDesc
            // 
            this.ProjCritDesc.HeaderText = "Beschreibung";
            this.ProjCritDesc.Name = "ProjCritDesc";
            this.ProjCritDesc.Width = 158;
            // 
            // ProjCritBalaIndi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.dataGridView_ProjCritBalaIndi);
            this.Controls.Add(this.btn_ProjCritBalaIndiCancle);
            this.Controls.Add(this.btn_ProjCritBalaIndiSave);
            this.Name = "ProjCritBalaIndi";
            this.Text = "ProjCritBalaIndi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritBalaIndi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ProjCritBalaIndi;
        private System.Windows.Forms.Button btn_ProjCritBalaIndiCancle;
        private System.Windows.Forms.Button btn_ProjCritBalaIndiSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritIDParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritBalaInd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritDesc;
    }
}