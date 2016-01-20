namespace NWAT
{
    partial class ProjCritProdFulfilment_View
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
            this.dgc_ProjCritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritIDParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritProdFulf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritFulComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ProjCritProdFulfCancle = new System.Windows.Forms.Button();
            this.btn_ProjCritProdFulfSave = new System.Windows.Forms.Button();
            this.comboBox_ProjCritProdFulf = new System.Windows.Forms.ComboBox();
            this.checkBox_ProjCritProdFulf = new System.Windows.Forms.CheckBox();
            this.btn_ProdFulfPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritProdFulf)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ProjCritProdFulf
            // 
            this.dataGridView_ProjCritProdFulf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ProjCritProdFulf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjCritProdFulf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_ProjCritID,
            this.dgc_ProjCritIDParent,
            this.dgc_ProjCritName,
            this.dgc_ProjCritProdFulf,
            this.dgc_ProjCritFulComment});
            this.dataGridView_ProjCritProdFulf.Location = new System.Drawing.Point(13, 52);
            this.dataGridView_ProjCritProdFulf.Name = "dataGridView_ProjCritProdFulf";
            this.dataGridView_ProjCritProdFulf.Size = new System.Drawing.Size(575, 488);
            this.dataGridView_ProjCritProdFulf.TabIndex = 9;
            this.dataGridView_ProjCritProdFulf.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ProjCritProdFulf_CellContentClick);
            // 
            // dgc_ProjCritID
            // 
            this.dgc_ProjCritID.HeaderText = "ID";
            this.dgc_ProjCritID.Name = "dgc_ProjCritID";
            this.dgc_ProjCritID.Width = 30;
            // 
            // dgc_ProjCritIDParent
            // 
            this.dgc_ProjCritIDParent.HeaderText = "Parent ID";
            this.dgc_ProjCritIDParent.Name = "dgc_ProjCritIDParent";
            this.dgc_ProjCritIDParent.Width = 80;
            // 
            // dgc_ProjCritName
            // 
            this.dgc_ProjCritName.HeaderText = "Name";
            this.dgc_ProjCritName.Name = "dgc_ProjCritName";
            this.dgc_ProjCritName.Width = 150;
            // 
            // dgc_ProjCritProdFulf
            // 
            this.dgc_ProjCritProdFulf.HeaderText = "Erfüllung";
            this.dgc_ProjCritProdFulf.Name = "dgc_ProjCritProdFulf";
            this.dgc_ProjCritProdFulf.Width = 60;
            // 
            // dgc_ProjCritFulComment
            // 
            this.dgc_ProjCritFulComment.HeaderText = "Kommentar";
            this.dgc_ProjCritFulComment.Name = "dgc_ProjCritFulComment";
            this.dgc_ProjCritFulComment.Width = 200;
            // 
            // btn_ProjCritProdFulfCancle
            // 
            this.btn_ProjCritProdFulfCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritProdFulfCancle.Location = new System.Drawing.Point(597, 516);
            this.btn_ProjCritProdFulfCancle.Name = "btn_ProjCritProdFulfCancle";
            this.btn_ProjCritProdFulfCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritProdFulfCancle.TabIndex = 11;
            this.btn_ProjCritProdFulfCancle.Text = "abbrechen";
            this.btn_ProjCritProdFulfCancle.UseVisualStyleBackColor = true;
            // 
            // btn_ProjCritProdFulfSave
            // 
            this.btn_ProjCritProdFulfSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            // checkBox_ProjCritProdFulf
            // 
            this.checkBox_ProjCritProdFulf.AutoSize = true;
            this.checkBox_ProjCritProdFulf.Location = new System.Drawing.Point(336, 77);
            this.checkBox_ProjCritProdFulf.Name = "checkBox_ProjCritProdFulf";
            this.checkBox_ProjCritProdFulf.Size = new System.Drawing.Size(15, 14);
            this.checkBox_ProjCritProdFulf.TabIndex = 13;
            this.checkBox_ProjCritProdFulf.UseVisualStyleBackColor = true;
            // 
            // btn_ProdFulfPrint
            // 
            this.btn_ProdFulfPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProdFulfPrint.Location = new System.Drawing.Point(597, 458);
            this.btn_ProdFulfPrint.Name = "btn_ProdFulfPrint";
            this.btn_ProdFulfPrint.Size = new System.Drawing.Size(75, 23);
            this.btn_ProdFulfPrint.TabIndex = 14;
            this.btn_ProdFulfPrint.Text = "drucken";
            this.btn_ProdFulfPrint.UseVisualStyleBackColor = true;
            this.btn_ProdFulfPrint.Click += new System.EventHandler(this.btn_ProdFulfPrint_Click);
            // 
            // ProjCritProdFulfilment_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.btn_ProdFulfPrint);
            this.Controls.Add(this.checkBox_ProjCritProdFulf);
            this.Controls.Add(this.comboBox_ProjCritProdFulf);
            this.Controls.Add(this.dataGridView_ProjCritProdFulf);
            this.Controls.Add(this.btn_ProjCritProdFulfCancle);
            this.Controls.Add(this.btn_ProjCritProdFulfSave);
            this.Name = "ProjCritProdFulfilment_View";
            this.Text = "Produkt-Kriterienerfüllung";
            this.Load += new System.EventHandler(this.ProjCritProdFulfilment_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritProdFulf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ProjCritProdFulf;
        private System.Windows.Forms.Button btn_ProjCritProdFulfCancle;
        private System.Windows.Forms.Button btn_ProjCritProdFulfSave;
        private System.Windows.Forms.ComboBox comboBox_ProjCritProdFulf;
        private System.Windows.Forms.CheckBox checkBox_ProjCritProdFulf;
        private System.Windows.Forms.Button btn_ProdFulfPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritIDParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritProdFulf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritFulComment;
    }
}