namespace NWAT
{
    partial class ProjCritShow_View
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
            this.ProjCritShow = new System.Windows.Forms.DataGridView();
            this.btn_ProjCritStruClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProjCritShow)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjCritShow
            // 
            this.ProjCritShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjCritShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProjCritShow.Location = new System.Drawing.Point(13, 20);
            this.ProjCritShow.Name = "ProjCritShow";
            this.ProjCritShow.Size = new System.Drawing.Size(575, 520);
            this.ProjCritShow.TabIndex = 3;
            // 
            // btn_ProjCritStruClose
            // 
            this.btn_ProjCritStruClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritStruClose.Location = new System.Drawing.Point(597, 516);
            this.btn_ProjCritStruClose.Name = "btn_ProjCritStruClose";
            this.btn_ProjCritStruClose.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritStruClose.TabIndex = 5;
            this.btn_ProjCritStruClose.Text = "schliessen";
            this.btn_ProjCritStruClose.UseVisualStyleBackColor = true;
            // 
            // ProjCritShow_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.ProjCritShow);
            this.Controls.Add(this.btn_ProjCritStruClose);
            this.Name = "ProjCritShow_View";
            this.Text = "Projektkriterienstruktur";
            this.Load += new System.EventHandler(this.ProjCritShow_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProjCritShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProjCritShow;
        private System.Windows.Forms.Button btn_ProjCritStruClose;
    }
}