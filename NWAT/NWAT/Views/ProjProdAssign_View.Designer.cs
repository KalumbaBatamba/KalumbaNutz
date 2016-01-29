namespace NWAT
{
    partial class ProjProdAssign_View
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
            this.label_ProdAvail = new System.Windows.Forms.Label();
            this.label_ProjProd = new System.Windows.Forms.Label();
            this.btn_ProjProdCancle = new System.Windows.Forms.Button();
            this.btn_ProjProdSave = new System.Windows.Forms.Button();
            this.btn_ProdToPool = new System.Windows.Forms.Button();
            this.btn_ProdToProj = new System.Windows.Forms.Button();
            this.dataGridView_ProjProd = new System.Windows.Forms.DataGridView();
            this.label_entkoppeln = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prodAvail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjProd)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_prodAvail
            // 
            this.dataGridView_prodAvail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_prodAvail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_prodAvail.Location = new System.Drawing.Point(365, 31);
            this.dataGridView_prodAvail.Name = "dataGridView_prodAvail";
            this.dataGridView_prodAvail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_prodAvail.Size = new System.Drawing.Size(252, 324);
            this.dataGridView_prodAvail.TabIndex = 11;
            // 
            // label_ProdAvail
            // 
            this.label_ProdAvail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ProdAvail.AutoSize = true;
            this.label_ProdAvail.Location = new System.Drawing.Point(512, 15);
            this.label_ProdAvail.Name = "label_ProdAvail";
            this.label_ProdAvail.Size = new System.Drawing.Size(107, 13);
            this.label_ProdAvail.TabIndex = 9;
            this.label_ProdAvail.Text = "verfügbare Produkte:";
            // 
            // label_ProjProd
            // 
            this.label_ProjProd.AutoSize = true;
            this.label_ProjProd.Location = new System.Drawing.Point(15, 10);
            this.label_ProjProd.Name = "label_ProjProd";
            this.label_ProjProd.Size = new System.Drawing.Size(115, 13);
            this.label_ProjProd.TabIndex = 8;
            this.label_ProjProd.Text = "zugeordnete Produkte:";
            // 
            // btn_ProjProdCancle
            // 
            this.btn_ProjProdCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjProdCancle.Location = new System.Drawing.Point(542, 361);
            this.btn_ProjProdCancle.Name = "btn_ProjProdCancle";
            this.btn_ProjProdCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjProdCancle.TabIndex = 15;
            this.btn_ProjProdCancle.Text = "schliessen";
            this.btn_ProjProdCancle.UseVisualStyleBackColor = true;
            this.btn_ProjProdCancle.Click += new System.EventHandler(this.btn_ProjProdCancle_Click);
            // 
            // btn_ProjProdSave
            // 
            this.btn_ProjProdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjProdSave.Location = new System.Drawing.Point(461, 361);
            this.btn_ProjProdSave.Name = "btn_ProjProdSave";
            this.btn_ProjProdSave.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjProdSave.TabIndex = 14;
            this.btn_ProjProdSave.Text = "speichern";
            this.btn_ProjProdSave.UseVisualStyleBackColor = true;
            this.btn_ProjProdSave.Click += new System.EventHandler(this.btn_ProjProdSave_Click);
            // 
            // btn_ProdToPool
            // 
            this.btn_ProdToPool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProdToPool.Location = new System.Drawing.Point(279, 201);
            this.btn_ProdToPool.Name = "btn_ProdToPool";
            this.btn_ProdToPool.Size = new System.Drawing.Size(60, 23);
            this.btn_ProdToPool.TabIndex = 13;
            this.btn_ProdToPool.Text = ">>";
            this.btn_ProdToPool.UseVisualStyleBackColor = true;
            this.btn_ProdToPool.Click += new System.EventHandler(this.btn_ProdToPool_Click);
            // 
            // btn_ProdToProj
            // 
            this.btn_ProdToProj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProdToProj.Location = new System.Drawing.Point(279, 162);
            this.btn_ProdToProj.Name = "btn_ProdToProj";
            this.btn_ProdToProj.Size = new System.Drawing.Size(60, 23);
            this.btn_ProdToProj.TabIndex = 12;
            this.btn_ProdToProj.Text = "<<";
            this.btn_ProdToProj.UseVisualStyleBackColor = true;
            this.btn_ProdToProj.Click += new System.EventHandler(this.btn_ProdToProj_Click);
            // 
            // dataGridView_ProjProd
            // 
            this.dataGridView_ProjProd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ProjProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjProd.Location = new System.Drawing.Point(18, 31);
            this.dataGridView_ProjProd.MultiSelect = false;
            this.dataGridView_ProjProd.Name = "dataGridView_ProjProd";
            this.dataGridView_ProjProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ProjProd.Size = new System.Drawing.Size(243, 324);
            this.dataGridView_ProjProd.TabIndex = 10;
            // 
            // label_entkoppeln
            // 
            this.label_entkoppeln.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_entkoppeln.AutoSize = true;
            this.label_entkoppeln.Location = new System.Drawing.Point(9, 374);
            this.label_entkoppeln.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_entkoppeln.Name = "label_entkoppeln";
            this.label_entkoppeln.Size = new System.Drawing.Size(425, 13);
            this.label_entkoppeln.TabIndex = 16;
            this.label_entkoppeln.Text = "Achtung: Beim Entkoppeln werden auch die Einträge aus der Fulfillment Tabelle gel" +
    "öscht";
            // 
            // ProjProdAssign_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 395);
            this.Controls.Add(this.label_entkoppeln);
            this.Controls.Add(this.dataGridView_prodAvail);
            this.Controls.Add(this.dataGridView_ProjProd);
            this.Controls.Add(this.label_ProdAvail);
            this.Controls.Add(this.label_ProjProd);
            this.Controls.Add(this.btn_ProjProdCancle);
            this.Controls.Add(this.btn_ProjProdSave);
            this.Controls.Add(this.btn_ProdToPool);
            this.Controls.Add(this.btn_ProdToProj);
            this.Name = "ProjProdAssign_View";
            this.Text = "Projektproduktzuordnung";
            this.Load += new System.EventHandler(this.ProjProdAssign_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prodAvail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_prodAvail;
        private System.Windows.Forms.Label label_ProdAvail;
        private System.Windows.Forms.Label label_ProjProd;
        private System.Windows.Forms.Button btn_ProjProdCancle;
        private System.Windows.Forms.Button btn_ProjProdSave;
        private System.Windows.Forms.Button btn_ProdToPool;
        private System.Windows.Forms.Button btn_ProdToProj;
        private System.Windows.Forms.DataGridView dataGridView_ProjProd;
        private System.Windows.Forms.Label label_entkoppeln;
    }
}