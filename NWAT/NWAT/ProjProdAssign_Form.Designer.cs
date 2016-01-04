namespace NWAT
{
    partial class ProjProdAssign_Form
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
            this.dataGridView_prodAvail = new System.Windows.Forms.DataGridView();
            this.AvailProdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailProdManu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_ProjProd = new System.Windows.Forms.DataGridView();
            this.ProjProdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjProdManu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_ProdAvail = new System.Windows.Forms.Label();
            this.label_ProjProd = new System.Windows.Forms.Label();
            this.btn_ProjProdCancle = new System.Windows.Forms.Button();
            this.btn_ProjProdSave = new System.Windows.Forms.Button();
            this.btn_ProdToPool = new System.Windows.Forms.Button();
            this.btn_ProdToProj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prodAvail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjProd)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_prodAvail
            // 
            this.dataGridView_prodAvail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_prodAvail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AvailProdID,
            this.AvailProdName,
            this.AvailProdManu});
            this.dataGridView_prodAvail.Location = new System.Drawing.Point(380, 31);
            this.dataGridView_prodAvail.Name = "dataGridView_prodAvail";
            this.dataGridView_prodAvail.Size = new System.Drawing.Size(290, 490);
            this.dataGridView_prodAvail.TabIndex = 11;
            // 
            // AvailProdID
            // 
            this.AvailProdID.HeaderText = "ID";
            this.AvailProdID.Name = "AvailProdID";
            this.AvailProdID.Width = 25;
            // 
            // AvailProdName
            // 
            this.AvailProdName.HeaderText = "Name";
            this.AvailProdName.Name = "AvailProdName";
            this.AvailProdName.Width = 150;
            // 
            // AvailProdManu
            // 
            this.AvailProdManu.HeaderText = "Hersteller";
            this.AvailProdManu.Name = "AvailProdManu";
            this.AvailProdManu.Width = 400;
            // 
            // dataGridView_ProjProd
            // 
            this.dataGridView_ProjProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjProdID,
            this.ProjProdName,
            this.ProjProdManu});
            this.dataGridView_ProjProd.Location = new System.Drawing.Point(18, 31);
            this.dataGridView_ProjProd.Name = "dataGridView_ProjProd";
            this.dataGridView_ProjProd.Size = new System.Drawing.Size(290, 490);
            this.dataGridView_ProjProd.TabIndex = 10;
            // 
            // ProjProdID
            // 
            this.ProjProdID.HeaderText = "ID";
            this.ProjProdID.Name = "ProjProdID";
            this.ProjProdID.Width = 25;
            // 
            // ProjProdName
            // 
            this.ProjProdName.HeaderText = "Name";
            this.ProjProdName.Name = "ProjProdName";
            this.ProjProdName.Width = 150;
            // 
            // ProjProdManu
            // 
            this.ProjProdManu.HeaderText = "Hersteller";
            this.ProjProdManu.Name = "ProjProdManu";
            this.ProjProdManu.Width = 450;
            // 
            // label_ProdAvail
            // 
            this.label_ProdAvail.AutoSize = true;
            this.label_ProdAvail.Location = new System.Drawing.Point(377, 10);
            this.label_ProdAvail.Name = "label_ProdAvail";
            this.label_ProdAvail.Size = new System.Drawing.Size(102, 13);
            this.label_ProdAvail.TabIndex = 9;
            this.label_ProdAvail.Text = "verfügbare Kriterien:";
            // 
            // label_ProjProd
            // 
            this.label_ProjProd.AutoSize = true;
            this.label_ProjProd.Location = new System.Drawing.Point(15, 10);
            this.label_ProjProd.Name = "label_ProjProd";
            this.label_ProjProd.Size = new System.Drawing.Size(110, 13);
            this.label_ProjProd.TabIndex = 8;
            this.label_ProjProd.Text = "zugeordnete Kriterien:";
            // 
            // btn_ProjProdCancle
            // 
            this.btn_ProjProdCancle.Location = new System.Drawing.Point(595, 527);
            this.btn_ProjProdCancle.Name = "btn_ProjProdCancle";
            this.btn_ProjProdCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjProdCancle.TabIndex = 15;
            this.btn_ProjProdCancle.Text = "abbrechen";
            this.btn_ProjProdCancle.UseVisualStyleBackColor = true;
            // 
            // btn_ProjProdSave
            // 
            this.btn_ProjProdSave.Location = new System.Drawing.Point(513, 527);
            this.btn_ProjProdSave.Name = "btn_ProjProdSave";
            this.btn_ProjProdSave.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjProdSave.TabIndex = 14;
            this.btn_ProjProdSave.Text = "speichern";
            this.btn_ProjProdSave.UseVisualStyleBackColor = true;
            // 
            // btn_ProdToPool
            // 
            this.btn_ProdToPool.Location = new System.Drawing.Point(314, 237);
            this.btn_ProdToPool.Name = "btn_ProdToPool";
            this.btn_ProdToPool.Size = new System.Drawing.Size(60, 23);
            this.btn_ProdToPool.TabIndex = 13;
            this.btn_ProdToPool.Text = ">>";
            this.btn_ProdToPool.UseVisualStyleBackColor = true;
            // 
            // btn_ProdToProj
            // 
            this.btn_ProdToProj.Location = new System.Drawing.Point(314, 207);
            this.btn_ProdToProj.Name = "btn_ProdToProj";
            this.btn_ProdToProj.Size = new System.Drawing.Size(60, 23);
            this.btn_ProdToProj.TabIndex = 12;
            this.btn_ProdToProj.Text = "<<";
            this.btn_ProdToProj.UseVisualStyleBackColor = true;
            // 
            // ProjProdAssign_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.dataGridView_prodAvail);
            this.Controls.Add(this.dataGridView_ProjProd);
            this.Controls.Add(this.label_ProdAvail);
            this.Controls.Add(this.label_ProjProd);
            this.Controls.Add(this.btn_ProjProdCancle);
            this.Controls.Add(this.btn_ProjProdSave);
            this.Controls.Add(this.btn_ProdToPool);
            this.Controls.Add(this.btn_ProdToProj);
            this.Name = "ProjProdAssign_Form";
            this.Text = "ProjProdAssign";
            this.Load += new System.EventHandler(this.ProjProdAssign_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prodAvail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_prodAvail;
        private System.Windows.Forms.DataGridView dataGridView_ProjProd;
        private System.Windows.Forms.Label label_ProdAvail;
        private System.Windows.Forms.Label label_ProjProd;
        private System.Windows.Forms.Button btn_ProjProdCancle;
        private System.Windows.Forms.Button btn_ProjProdSave;
        private System.Windows.Forms.Button btn_ProdToPool;
        private System.Windows.Forms.Button btn_ProdToProj;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailProdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailProdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailProdManu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjProdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjProdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjProdManu;
    }
}