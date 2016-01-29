namespace NWAT
{
    partial class Kriterienverwaltung_View
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
            this.dataGridView_Crits = new System.Windows.Forms.DataGridView();
            this.btn_refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Crits)).BeginInit();
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
            this.btn_CritShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CritShow.Location = new System.Drawing.Point(457, 30);
            this.btn_CritShow.Name = "btn_CritShow";
            this.btn_CritShow.Size = new System.Drawing.Size(75, 23);
            this.btn_CritShow.TabIndex = 2;
            this.btn_CritShow.Text = "anzeigen";
            this.btn_CritShow.UseVisualStyleBackColor = true;
            this.btn_CritShow.Click += new System.EventHandler(this.btn_CritShow_Click);
            // 
            // btn_CritUpdate
            // 
            this.btn_CritUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CritUpdate.Location = new System.Drawing.Point(457, 60);
            this.btn_CritUpdate.Name = "btn_CritUpdate";
            this.btn_CritUpdate.Size = new System.Drawing.Size(75, 23);
            this.btn_CritUpdate.TabIndex = 3;
            this.btn_CritUpdate.Text = "ändern";
            this.btn_CritUpdate.UseVisualStyleBackColor = true;
            this.btn_CritUpdate.Click += new System.EventHandler(this.btn_CritUpdate_Click);
            // 
            // btn_CritDelete
            // 
            this.btn_CritDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CritDelete.Location = new System.Drawing.Point(457, 90);
            this.btn_CritDelete.Name = "btn_CritDelete";
            this.btn_CritDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_CritDelete.TabIndex = 4;
            this.btn_CritDelete.Text = "löschen";
            this.btn_CritDelete.UseVisualStyleBackColor = true;
            this.btn_CritDelete.Click += new System.EventHandler(this.btn_CritDelete_Click);
            // 
            // btn_CritCreate
            // 
            this.btn_CritCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CritCreate.Location = new System.Drawing.Point(428, 367);
            this.btn_CritCreate.Name = "btn_CritCreate";
            this.btn_CritCreate.Size = new System.Drawing.Size(104, 23);
            this.btn_CritCreate.TabIndex = 7;
            this.btn_CritCreate.Text = "Neu anlegen";
            this.btn_CritCreate.UseVisualStyleBackColor = true;
            this.btn_CritCreate.Click += new System.EventHandler(this.btn_CritCreate_Click);
            // 
            // dataGridView_Crits
            // 
            this.dataGridView_Crits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Crits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Crits.Location = new System.Drawing.Point(13, 31);
            this.dataGridView_Crits.MultiSelect = false;
            this.dataGridView_Crits.Name = "dataGridView_Crits";
            this.dataGridView_Crits.ReadOnly = true;
            this.dataGridView_Crits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Crits.Size = new System.Drawing.Size(398, 359);
            this.dataGridView_Crits.TabIndex = 8;
            this.dataGridView_Crits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Crits_CellContentClick);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.Location = new System.Drawing.Point(457, 120);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh.TabIndex = 9;
            this.btn_refresh.Text = "refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // Kriterienverwaltung_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 402);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.dataGridView_Crits);
            this.Controls.Add(this.btn_CritCreate);
            this.Controls.Add(this.btn_CritDelete);
            this.Controls.Add(this.btn_CritUpdate);
            this.Controls.Add(this.btn_CritShow);
            this.Controls.Add(this.lable_CritChoose);
            this.Name = "Kriterienverwaltung_View";
            this.Text = "Kriterienverwaltung";
            this.Load += new System.EventHandler(this.Kriterienverwaltung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Crits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable_CritChoose;
        private System.Windows.Forms.Button btn_CritShow;
        private System.Windows.Forms.Button btn_CritUpdate;
        private System.Windows.Forms.Button btn_CritDelete;
        private System.Windows.Forms.Button btn_CritCreate;
        private System.Windows.Forms.DataGridView dataGridView_Crits;
        private System.Windows.Forms.Button btn_refresh;
    }
}