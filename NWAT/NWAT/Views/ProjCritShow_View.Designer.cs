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
            this.dgc_ProjCritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritIDParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ProjCritShow)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjCritShow
            // 
            this.ProjCritShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProjCritShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_ProjCritID,
            this.dgc_ProjCritIDParent,
            this.dgc_ProjCritName,
            this.dgc_ProjCritDesc});
            this.ProjCritShow.Location = new System.Drawing.Point(13, 20);
            this.ProjCritShow.Name = "ProjCritShow";
            this.ProjCritShow.Size = new System.Drawing.Size(575, 520);
            this.ProjCritShow.TabIndex = 3;
            // 
            // btn_ProjCritStruClose
            // 
            this.btn_ProjCritStruClose.Location = new System.Drawing.Point(597, 516);
            this.btn_ProjCritStruClose.Name = "btn_ProjCritStruClose";
            this.btn_ProjCritStruClose.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritStruClose.TabIndex = 5;
            this.btn_ProjCritStruClose.Text = "schliessen";
            this.btn_ProjCritStruClose.UseVisualStyleBackColor = true;
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
            // dgc_ProjCritDesc
            // 
            this.dgc_ProjCritDesc.HeaderText = "Beschreibung";
            this.dgc_ProjCritDesc.Name = "dgc_ProjCritDesc";
            this.dgc_ProjCritDesc.Width = 270;
            // 
            // ProjCritShow_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.ProjCritShow);
            this.Controls.Add(this.btn_ProjCritStruClose);
            this.Name = "ProjCritShow_View";
            this.Text = "ProjCritShow_Form";
            this.Load += new System.EventHandler(this.ProjCritShow_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProjCritShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProjCritShow;
        private System.Windows.Forms.Button btn_ProjCritStruClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritIDParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritDesc;
    }
}