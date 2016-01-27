namespace NWAT
{
    partial class ProjCritStruUpdate_View
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
            this.dataGridView_CritStruUpd = new System.Windows.Forms.DataGridView();
            this.btn_ProjCritStruSave = new System.Windows.Forms.Button();
            this.btn_ProjCritStruCancle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CritStruUpd)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_CritStruUpd
            // 
            this.dataGridView_CritStruUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_CritStruUpd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CritStruUpd.Location = new System.Drawing.Point(20, 45);
            this.dataGridView_CritStruUpd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView_CritStruUpd.Name = "dataGridView_CritStruUpd";
            this.dataGridView_CritStruUpd.Size = new System.Drawing.Size(1299, 1081);
            this.dataGridView_CritStruUpd.TabIndex = 0;
            this.dataGridView_CritStruUpd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CritStruUpd_CellEndEdit);
            // 
            // btn_ProjCritStruSave
            // 
            this.btn_ProjCritStruSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritStruSave.Location = new System.Drawing.Point(1333, 1044);
            this.btn_ProjCritStruSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProjCritStruSave.Name = "btn_ProjCritStruSave";
            this.btn_ProjCritStruSave.Size = new System.Drawing.Size(112, 35);
            this.btn_ProjCritStruSave.TabIndex = 1;
            this.btn_ProjCritStruSave.Text = "speichern";
            this.btn_ProjCritStruSave.UseVisualStyleBackColor = true;
            this.btn_ProjCritStruSave.Click += new System.EventHandler(this.btn_ProjCritStruSave_Click);
            // 
            // btn_ProjCritStruCancle
            // 
            this.btn_ProjCritStruCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritStruCancle.Location = new System.Drawing.Point(1333, 1089);
            this.btn_ProjCritStruCancle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProjCritStruCancle.Name = "btn_ProjCritStruCancle";
            this.btn_ProjCritStruCancle.Size = new System.Drawing.Size(112, 35);
            this.btn_ProjCritStruCancle.TabIndex = 2;
            this.btn_ProjCritStruCancle.Text = "schliessen";
            this.btn_ProjCritStruCancle.UseVisualStyleBackColor = true;
            this.btn_ProjCritStruCancle.Click += new System.EventHandler(this.btn_ProjCritStruCancle_Click);
            // 
            // ProjCritStruUpdate_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 1144);
            this.Controls.Add(this.btn_ProjCritStruCancle);
            this.Controls.Add(this.btn_ProjCritStruSave);
            this.Controls.Add(this.dataGridView_CritStruUpd);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProjCritStruUpdate_View";
            this.Text = "Kriterienstruktur";
            this.Load += new System.EventHandler(this.ProjCritStruUpdate_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CritStruUpd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_CritStruUpd;
        private System.Windows.Forms.Button btn_ProjCritStruSave;
        private System.Windows.Forms.Button btn_ProjCritStruCancle;
    }
}