namespace NWAT
{
    partial class ProjCritBalance
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
            this.dataGridView_ProjCritBalance = new System.Windows.Forms.DataGridView();
            this.btn_ProjCritBalaCancle = new System.Windows.Forms.Button();
            this.btn_ProjCritBalaSave = new System.Windows.Forms.Button();
            this.ProjCritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritIDParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritBala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ProjCritBalance
            // 
            this.dataGridView_ProjCritBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjCritBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjCritID,
            this.ProjCritIDParent,
            this.ProjCritName,
            this.ProjCritBala,
            this.ProjCritDesc});
            this.dataGridView_ProjCritBalance.Location = new System.Drawing.Point(13, 20);
            this.dataGridView_ProjCritBalance.Name = "dataGridView_ProjCritBalance";
            this.dataGridView_ProjCritBalance.Size = new System.Drawing.Size(575, 520);
            this.dataGridView_ProjCritBalance.TabIndex = 3;
            // 
            // btn_ProjCritBalaCancle
            // 
            this.btn_ProjCritBalaCancle.Location = new System.Drawing.Point(597, 516);
            this.btn_ProjCritBalaCancle.Name = "btn_ProjCritBalaCancle";
            this.btn_ProjCritBalaCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritBalaCancle.TabIndex = 5;
            this.btn_ProjCritBalaCancle.Text = "abbrechen";
            this.btn_ProjCritBalaCancle.UseVisualStyleBackColor = true;
            // 
            // btn_ProjCritBalaSave
            // 
            this.btn_ProjCritBalaSave.Location = new System.Drawing.Point(597, 487);
            this.btn_ProjCritBalaSave.Name = "btn_ProjCritBalaSave";
            this.btn_ProjCritBalaSave.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritBalaSave.TabIndex = 4;
            this.btn_ProjCritBalaSave.Text = "speichern";
            this.btn_ProjCritBalaSave.UseVisualStyleBackColor = true;
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
            // ProjCritBala
            // 
            this.ProjCritBala.HeaderText = "Gewichtungsfaktor";
            this.ProjCritBala.Name = "ProjCritBala";
            this.ProjCritBala.Width = 110;
            // 
            // ProjCritDesc
            // 
            this.ProjCritDesc.HeaderText = "Beschreibung";
            this.ProjCritDesc.Name = "ProjCritDesc";
            this.ProjCritDesc.Width = 158;
            // 
            // ProjCritBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.dataGridView_ProjCritBalance);
            this.Controls.Add(this.btn_ProjCritBalaCancle);
            this.Controls.Add(this.btn_ProjCritBalaSave);
            this.Name = "ProjCritBalance";
            this.Text = "Gleichgewichtung";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritBalance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ProjCritBalance;
        private System.Windows.Forms.Button btn_ProjCritBalaCancle;
        private System.Windows.Forms.Button btn_ProjCritBalaSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritIDParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritBala;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritDesc;
    }
}