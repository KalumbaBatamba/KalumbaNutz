namespace NWAT
{
    partial class ProjCritAssign_View
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
            this.label_ProjCrits = new System.Windows.Forms.Label();
            this.label_CritsAvail = new System.Windows.Forms.Label();
            this.dataGridView_ProjCrits = new System.Windows.Forms.DataGridView();
            this.dataGridView_CritAvail = new System.Windows.Forms.DataGridView();
            this.btn_CritToProj = new System.Windows.Forms.Button();
            this.btn_CritToPool = new System.Windows.Forms.Button();
            this.btn_ProjCritSave = new System.Windows.Forms.Button();
            this.btn_ProjCritCancle = new System.Windows.Forms.Button();
            this.lable_Entkoppeln = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCrits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CritAvail)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ProjCrits
            // 
            this.label_ProjCrits.AutoSize = true;
            this.label_ProjCrits.Location = new System.Drawing.Point(12, 14);
            this.label_ProjCrits.Name = "label_ProjCrits";
            this.label_ProjCrits.Size = new System.Drawing.Size(110, 13);
            this.label_ProjCrits.TabIndex = 0;
            this.label_ProjCrits.Text = "zugeordnete Kriterien:";
            // 
            // label_CritsAvail
            // 
            this.label_CritsAvail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CritsAvail.AutoSize = true;
            this.label_CritsAvail.Location = new System.Drawing.Point(496, 14);
            this.label_CritsAvail.Name = "label_CritsAvail";
            this.label_CritsAvail.Size = new System.Drawing.Size(102, 13);
            this.label_CritsAvail.TabIndex = 1;
            this.label_CritsAvail.Text = "verfügbare Kriterien:";
            // 
            // dataGridView_ProjCrits
            // 
            this.dataGridView_ProjCrits.AllowUserToAddRows = false;
            this.dataGridView_ProjCrits.AllowUserToDeleteRows = false;
            this.dataGridView_ProjCrits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_ProjCrits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjCrits.Location = new System.Drawing.Point(15, 30);
            this.dataGridView_ProjCrits.MultiSelect = false;
            this.dataGridView_ProjCrits.Name = "dataGridView_ProjCrits";
            this.dataGridView_ProjCrits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ProjCrits.Size = new System.Drawing.Size(275, 289);
            this.dataGridView_ProjCrits.TabIndex = 2;
            this.dataGridView_ProjCrits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ProjCrits_CellContentClick);
            // 
            // dataGridView_CritAvail
            // 
            this.dataGridView_CritAvail.AllowUserToAddRows = false;
            this.dataGridView_CritAvail.AllowUserToDeleteRows = false;
            this.dataGridView_CritAvail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_CritAvail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CritAvail.Location = new System.Drawing.Point(374, 30);
            this.dataGridView_CritAvail.MultiSelect = false;
            this.dataGridView_CritAvail.Name = "dataGridView_CritAvail";
            this.dataGridView_CritAvail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_CritAvail.Size = new System.Drawing.Size(223, 289);
            this.dataGridView_CritAvail.TabIndex = 3;
            // 
            // btn_CritToProj
            // 
            this.btn_CritToProj.Location = new System.Drawing.Point(296, 141);
            this.btn_CritToProj.Name = "btn_CritToProj";
            this.btn_CritToProj.Size = new System.Drawing.Size(60, 23);
            this.btn_CritToProj.TabIndex = 4;
            this.btn_CritToProj.Text = "<<";
            this.btn_CritToProj.UseVisualStyleBackColor = true;
            this.btn_CritToProj.Click += new System.EventHandler(this.btn_CritToProj_Click);
            // 
            // btn_CritToPool
            // 
            this.btn_CritToPool.Location = new System.Drawing.Point(296, 180);
            this.btn_CritToPool.Name = "btn_CritToPool";
            this.btn_CritToPool.Size = new System.Drawing.Size(60, 23);
            this.btn_CritToPool.TabIndex = 5;
            this.btn_CritToPool.Text = ">>";
            this.btn_CritToPool.UseVisualStyleBackColor = true;
            this.btn_CritToPool.Click += new System.EventHandler(this.btn_CritToPool_Click);
            // 
            // btn_ProjCritSave
            // 
            this.btn_ProjCritSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritSave.Location = new System.Drawing.Point(439, 370);
            this.btn_ProjCritSave.Name = "btn_ProjCritSave";
            this.btn_ProjCritSave.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritSave.TabIndex = 6;
            this.btn_ProjCritSave.Text = "speichern";
            this.btn_ProjCritSave.UseVisualStyleBackColor = true;
            this.btn_ProjCritSave.Click += new System.EventHandler(this.btn_ProjCritSave_Click);
            // 
            // btn_ProjCritCancle
            // 
            this.btn_ProjCritCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritCancle.Location = new System.Drawing.Point(522, 370);
            this.btn_ProjCritCancle.Name = "btn_ProjCritCancle";
            this.btn_ProjCritCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritCancle.TabIndex = 7;
            this.btn_ProjCritCancle.Text = "schliessen";
            this.btn_ProjCritCancle.UseVisualStyleBackColor = true;
            this.btn_ProjCritCancle.Click += new System.EventHandler(this.btn_ProjCritCancle_Click);
            // 
            // lable_Entkoppeln
            // 
            this.lable_Entkoppeln.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lable_Entkoppeln.AutoSize = true;
            this.lable_Entkoppeln.Location = new System.Drawing.Point(8, 382);
            this.lable_Entkoppeln.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lable_Entkoppeln.Name = "lable_Entkoppeln";
            this.lable_Entkoppeln.Size = new System.Drawing.Size(425, 13);
            this.lable_Entkoppeln.TabIndex = 8;
            this.lable_Entkoppeln.Text = "Achtung: Beim Entkoppeln werden auch die Einträge aus der Fulfillment Tabelle gel" +
    "öscht";
            // 
            // ProjCritAssign_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 406);
            this.Controls.Add(this.lable_Entkoppeln);
            this.Controls.Add(this.btn_ProjCritCancle);
            this.Controls.Add(this.btn_ProjCritSave);
            this.Controls.Add(this.btn_CritToPool);
            this.Controls.Add(this.btn_CritToProj);
            this.Controls.Add(this.dataGridView_CritAvail);
            this.Controls.Add(this.dataGridView_ProjCrits);
            this.Controls.Add(this.label_CritsAvail);
            this.Controls.Add(this.label_ProjCrits);
            this.Name = "ProjCritAssign_View";
            this.Text = "Kriterienzuordnung";
            this.Load += new System.EventHandler(this.ProjCritAssign_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCrits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CritAvail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ProjCrits;
        private System.Windows.Forms.Label label_CritsAvail;
        private System.Windows.Forms.DataGridView dataGridView_ProjCrits;
        private System.Windows.Forms.DataGridView dataGridView_CritAvail;
        private System.Windows.Forms.Button btn_CritToProj;
        private System.Windows.Forms.Button btn_CritToPool;
        private System.Windows.Forms.Button btn_ProjCritSave;
        private System.Windows.Forms.Button btn_ProjCritCancle;
        private System.Windows.Forms.Label lable_Entkoppeln;
    }
}