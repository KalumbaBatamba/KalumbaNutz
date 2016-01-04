namespace NWAT
{
    partial class ProjCritShow_Form
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
            this.ProjCritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritIDParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjCritDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ProjCritStruClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProjCritShow)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjCritShow
            // 
            this.ProjCritShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProjCritShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjCritID,
            this.ProjCritIDParent,
            this.ProjCritName,
            this.ProjCritDesc});
            this.ProjCritShow.Location = new System.Drawing.Point(13, 20);
            this.ProjCritShow.Name = "ProjCritShow";
            this.ProjCritShow.Size = new System.Drawing.Size(575, 520);
            this.ProjCritShow.TabIndex = 3;
            // 
            // ProjCritID
            // 
            this.ProjCritID.HeaderText = "ID";
            this.ProjCritID.Name = "ProjCritID";
            this.ProjCritID.Width = 30;
            // 
            // ProjCritIDParent
            // 
            this.ProjCritIDParent.HeaderText = "Parent ID";
            this.ProjCritIDParent.Name = "ProjCritIDParent";
            this.ProjCritIDParent.Width = 50;
            // 
            // ProjCritName
            // 
            this.ProjCritName.HeaderText = "Name";
            this.ProjCritName.Name = "ProjCritName";
            this.ProjCritName.Width = 150;
            // 
            // ProjCritDesc
            // 
            this.ProjCritDesc.HeaderText = "Beschreibung";
            this.ProjCritDesc.Name = "ProjCritDesc";
            this.ProjCritDesc.Width = 300;
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
            // ProjCritShow_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.ProjCritShow);
            this.Controls.Add(this.btn_ProjCritStruClose);
            this.Name = "ProjCritShow_Form";
            this.Text = "ProjCritShow_Form";
            this.Load += new System.EventHandler(this.ProjCritShow_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProjCritShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProjCritShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritIDParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjCritDesc;
        private System.Windows.Forms.Button btn_ProjCritStruClose;
    }
}