namespace NWAT
{
    partial class Criterion_Form
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
            this.lable_CritChoose = new System.Windows.Forms.Label();
            this.btn_CritShow = new System.Windows.Forms.Button();
            this.btn_CritUpdate = new System.Windows.Forms.Button();
            this.btn_CritDelete = new System.Windows.Forms.Button();
            this.btn_CritCreate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CritDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.btn_CritShow.Location = new System.Drawing.Point(584, 30);
            this.btn_CritShow.Name = "btn_CritShow";
            this.btn_CritShow.Size = new System.Drawing.Size(75, 23);
            this.btn_CritShow.TabIndex = 2;
            this.btn_CritShow.Text = "anzeigen";
            this.btn_CritShow.UseVisualStyleBackColor = true;
            this.btn_CritShow.Click += new System.EventHandler(this.btn_CritShow_Click);
            // 
            // btn_CritUpdate
            // 
            this.btn_CritUpdate.Location = new System.Drawing.Point(584, 60);
            this.btn_CritUpdate.Name = "btn_CritUpdate";
            this.btn_CritUpdate.Size = new System.Drawing.Size(75, 23);
            this.btn_CritUpdate.TabIndex = 3;
            this.btn_CritUpdate.Text = "ändern";
            this.btn_CritUpdate.UseVisualStyleBackColor = true;
            this.btn_CritUpdate.Click += new System.EventHandler(this.btn_CritUpdate_Click);
            // 
            // btn_CritDelete
            // 
            this.btn_CritDelete.Location = new System.Drawing.Point(584, 90);
            this.btn_CritDelete.Name = "btn_CritDelete";
            this.btn_CritDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_CritDelete.TabIndex = 4;
            this.btn_CritDelete.Text = "löschen";
            this.btn_CritDelete.UseVisualStyleBackColor = true;
            this.btn_CritDelete.Click += new System.EventHandler(this.btn_CritDelete_Click);
            // 
            // btn_CritCreate
            // 
            this.btn_CritCreate.Location = new System.Drawing.Point(555, 526);
            this.btn_CritCreate.Name = "btn_CritCreate";
            this.btn_CritCreate.Size = new System.Drawing.Size(104, 23);
            this.btn_CritCreate.TabIndex = 7;
            this.btn_CritCreate.Text = "Neu anlegen";
            this.btn_CritCreate.UseVisualStyleBackColor = true;
            this.btn_CritCreate.Click += new System.EventHandler(this.btn_CritCreate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CritID,
            this.CritName,
            this.CritDesc});
            this.dataGridView1.Location = new System.Drawing.Point(13, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(525, 518);
            this.dataGridView1.TabIndex = 8;
            // 
            // CritID
            // 
            this.CritID.HeaderText = "ID";
            this.CritID.Name = "CritID";
            this.CritID.Width = 25;
            // 
            // CritName
            // 
            this.CritName.HeaderText = "Name";
            this.CritName.Name = "CritName";
            this.CritName.Width = 150;
            // 
            // CritDesc
            // 
            this.CritDesc.HeaderText = "Beschreibung";
            this.CritDesc.Name = "CritDesc";
            this.CritDesc.Width = 300;
            // 
            // Criterion_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_CritCreate);
            this.Controls.Add(this.btn_CritDelete);
            this.Controls.Add(this.btn_CritUpdate);
            this.Controls.Add(this.btn_CritShow);
            this.Controls.Add(this.lable_CritChoose);
            this.Name = "Criterion_Form";
            this.Text = "Kriterienverwaltung";
            this.Load += new System.EventHandler(this.Kriterienverwaltung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable_CritChoose;
        private System.Windows.Forms.Button btn_CritShow;
        private System.Windows.Forms.Button btn_CritUpdate;
        private System.Windows.Forms.Button btn_CritDelete;
        private System.Windows.Forms.Button btn_CritCreate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CritDesc;
    }
}