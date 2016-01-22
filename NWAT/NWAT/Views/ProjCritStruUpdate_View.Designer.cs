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
            this.dataGridView_CritStruUpd.Location = new System.Drawing.Point(13, 29);
            this.dataGridView_CritStruUpd.Name = "dataGridView_CritStruUpd";
            this.dataGridView_CritStruUpd.Size = new System.Drawing.Size(575, 520);
            this.dataGridView_CritStruUpd.TabIndex = 0;
            // 
            // btn_ProjCritStruSave
            // 
            this.btn_ProjCritStruSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritStruSave.Location = new System.Drawing.Point(597, 496);
            this.btn_ProjCritStruSave.Name = "btn_ProjCritStruSave";
            this.btn_ProjCritStruSave.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritStruSave.TabIndex = 1;
            this.btn_ProjCritStruSave.Text = "speichern";
            this.btn_ProjCritStruSave.UseVisualStyleBackColor = true;
            // 
            // btn_ProjCritStruCancle
            // 
            this.btn_ProjCritStruCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritStruCancle.Location = new System.Drawing.Point(597, 525);
            this.btn_ProjCritStruCancle.Name = "btn_ProjCritStruCancle";
            this.btn_ProjCritStruCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritStruCancle.TabIndex = 2;
            this.btn_ProjCritStruCancle.Text = "abbrechen";
            this.btn_ProjCritStruCancle.UseVisualStyleBackColor = true;
            // 
            // ProjCritStruUpdate_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.btn_ProjCritStruCancle);
            this.Controls.Add(this.btn_ProjCritStruSave);
            this.Controls.Add(this.dataGridView_CritStruUpd);
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