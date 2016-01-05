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
            this.dgc_ProjCritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_AvailCritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_AvailCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_AvailCritDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCrits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CritAvail)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ProjCrits
            // 
            this.label_ProjCrits.AutoSize = true;
            this.label_ProjCrits.Location = new System.Drawing.Point(12, 9);
            this.label_ProjCrits.Name = "label_ProjCrits";
            this.label_ProjCrits.Size = new System.Drawing.Size(110, 13);
            this.label_ProjCrits.TabIndex = 0;
            this.label_ProjCrits.Text = "zugeordnete Kriterien:";
            // 
            // label_CritsAvail
            // 
            this.label_CritsAvail.AutoSize = true;
            this.label_CritsAvail.Location = new System.Drawing.Point(374, 9);
            this.label_CritsAvail.Name = "label_CritsAvail";
            this.label_CritsAvail.Size = new System.Drawing.Size(102, 13);
            this.label_CritsAvail.TabIndex = 1;
            this.label_CritsAvail.Text = "verfügbare Kriterien:";
            // 
            // dataGridView_ProjCrits
            // 
            this.dataGridView_ProjCrits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjCrits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_ProjCritID,
            this.dgc_ProjCritName,
            this.dgc_ProjCritDesc});
            this.dataGridView_ProjCrits.Location = new System.Drawing.Point(15, 30);
            this.dataGridView_ProjCrits.Name = "dataGridView_ProjCrits";
            this.dataGridView_ProjCrits.Size = new System.Drawing.Size(290, 490);
            this.dataGridView_ProjCrits.TabIndex = 2;
            // 
            // dataGridView_CritAvail
            // 
            this.dataGridView_CritAvail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CritAvail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_AvailCritID,
            this.dgc_AvailCritName,
            this.dgc_AvailCritDesc});
            this.dataGridView_CritAvail.Location = new System.Drawing.Point(377, 30);
            this.dataGridView_CritAvail.Name = "dataGridView_CritAvail";
            this.dataGridView_CritAvail.Size = new System.Drawing.Size(290, 490);
            this.dataGridView_CritAvail.TabIndex = 3;
            // 
            // btn_CritToProj
            // 
            this.btn_CritToProj.Location = new System.Drawing.Point(311, 206);
            this.btn_CritToProj.Name = "btn_CritToProj";
            this.btn_CritToProj.Size = new System.Drawing.Size(60, 23);
            this.btn_CritToProj.TabIndex = 4;
            this.btn_CritToProj.Text = "<<";
            this.btn_CritToProj.UseVisualStyleBackColor = true;
            // 
            // btn_CritToPool
            // 
            this.btn_CritToPool.Location = new System.Drawing.Point(311, 236);
            this.btn_CritToPool.Name = "btn_CritToPool";
            this.btn_CritToPool.Size = new System.Drawing.Size(60, 23);
            this.btn_CritToPool.TabIndex = 5;
            this.btn_CritToPool.Text = ">>";
            this.btn_CritToPool.UseVisualStyleBackColor = true;
            // 
            // btn_ProjCritSave
            // 
            this.btn_ProjCritSave.Location = new System.Drawing.Point(510, 526);
            this.btn_ProjCritSave.Name = "btn_ProjCritSave";
            this.btn_ProjCritSave.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritSave.TabIndex = 6;
            this.btn_ProjCritSave.Text = "speichern";
            this.btn_ProjCritSave.UseVisualStyleBackColor = true;
            // 
            // btn_ProjCritCancle
            // 
            this.btn_ProjCritCancle.Location = new System.Drawing.Point(592, 526);
            this.btn_ProjCritCancle.Name = "btn_ProjCritCancle";
            this.btn_ProjCritCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritCancle.TabIndex = 7;
            this.btn_ProjCritCancle.Text = "abbrechen";
            this.btn_ProjCritCancle.UseVisualStyleBackColor = true;
            // 
            // dgc_ProjCritID
            // 
            this.dgc_ProjCritID.HeaderText = "ID";
            this.dgc_ProjCritID.Name = "dgc_ProjCritID";
            this.dgc_ProjCritID.Width = 25;
            // 
            // dgc_ProjCritName
            // 
            this.dgc_ProjCritName.HeaderText = "Name";
            this.dgc_ProjCritName.Name = "dgc_ProjCritName";
            this.dgc_ProjCritName.Width = 150;
            // 
            // dgc_ProjCritDesc
            // 
            this.dgc_ProjCritDesc.HeaderText = "Beschreibung";
            this.dgc_ProjCritDesc.Name = "dgc_ProjCritDesc";
            this.dgc_ProjCritDesc.Width = 450;
            // 
            // dgc_AvailCritID
            // 
            this.dgc_AvailCritID.HeaderText = "ID";
            this.dgc_AvailCritID.Name = "dgc_AvailCritID";
            this.dgc_AvailCritID.Width = 25;
            // 
            // dgc_AvailCritName
            // 
            this.dgc_AvailCritName.HeaderText = "Name";
            this.dgc_AvailCritName.Name = "dgc_AvailCritName";
            this.dgc_AvailCritName.Width = 150;
            // 
            // dgc_AvailCritDesc
            // 
            this.dgc_AvailCritDesc.HeaderText = "Beschreibung";
            this.dgc_AvailCritDesc.Name = "dgc_AvailCritDesc";
            this.dgc_AvailCritDesc.Width = 400;
            // 
            // ProjCritAssign_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_AvailCritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_AvailCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_AvailCritDesc;
    }
}