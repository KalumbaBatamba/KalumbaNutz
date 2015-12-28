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
            this.lable_CritChoose = new System.Windows.Forms.Label();
            this.btn_CritShow = new System.Windows.Forms.Button();
            this.btn_CritUpdate = new System.Windows.Forms.Button();
            this.btn_CritDelete = new System.Windows.Forms.Button();
            this.btn_CritCreate = new System.Windows.Forms.Button();
            this.dataGridView_CritAll = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beschreibung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CritAll)).BeginInit();
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
            // 
            // btn_CritUpdate
            // 
            this.btn_CritUpdate.Location = new System.Drawing.Point(584, 60);
            this.btn_CritUpdate.Name = "btn_CritUpdate";
            this.btn_CritUpdate.Size = new System.Drawing.Size(75, 23);
            this.btn_CritUpdate.TabIndex = 3;
            this.btn_CritUpdate.Text = "ändern";
            this.btn_CritUpdate.UseVisualStyleBackColor = true;
            // 
            // btn_CritDelete
            // 
            this.btn_CritDelete.Location = new System.Drawing.Point(584, 90);
            this.btn_CritDelete.Name = "btn_CritDelete";
            this.btn_CritDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_CritDelete.TabIndex = 4;
            this.btn_CritDelete.Text = "löschen";
            this.btn_CritDelete.UseVisualStyleBackColor = true;
            // 
            // btn_CritCreate
            // 
            this.btn_CritCreate.Location = new System.Drawing.Point(555, 526);
            this.btn_CritCreate.Name = "btn_CritCreate";
            this.btn_CritCreate.Size = new System.Drawing.Size(104, 23);
            this.btn_CritCreate.TabIndex = 7;
            this.btn_CritCreate.Text = "Neu anlegen";
            this.btn_CritCreate.UseVisualStyleBackColor = true;
            // 
            // dataGridView_CritAll
            // 
            this.dataGridView_CritAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name,
            this.Beschreibung});
            this.dataGridView_CritAll.Location = new System.Drawing.Point(12, 30);
            this.dataGridView_CritAll.Name = "dataGridView_CritAll";
            this.dataGridView_CritAll.Size = new System.Drawing.Size(537, 519);
            this.dataGridView_CritAll.TabIndex = 8;
            this.dataGridView_CritAll.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 25;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.Width = 150;
            // 
            // Beschreibung
            // 
            this.Beschreibung.HeaderText = "Beschreibung";
            this.Beschreibung.Name = "Beschreibung";
            this.Beschreibung.Width = 318;
            // 
            // Kriterienverwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.dataGridView_CritAll);
            this.Controls.Add(this.btn_CritCreate);
            this.Controls.Add(this.btn_CritDelete);
            this.Controls.Add(this.btn_CritUpdate);
            this.Controls.Add(this.btn_CritShow);
            this.Controls.Add(this.lable_CritChoose);
            this.Name = "Kriterienverwaltung";
            this.Text = "Kriterienverwaltung";
            this.Load += new System.EventHandler(this.Kriterienverwaltung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CritAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable_CritChoose;
        private System.Windows.Forms.Button btn_CritShow;
        private System.Windows.Forms.Button btn_CritUpdate;
        private System.Windows.Forms.Button btn_CritDelete;
        private System.Windows.Forms.Button btn_CritCreate;
        private System.Windows.Forms.DataGridView dataGridView_CritAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beschreibung;
    }
}