namespace NWAT
{
    partial class Project_Update_View
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
            this.btn_ProjUpdate = new System.Windows.Forms.Button();
            this.textBox_ProjNameUpdate = new System.Windows.Forms.TextBox();
            this.label_ProjDescUpdate = new System.Windows.Forms.Label();
            this.textBox_ProjDescUpdate = new System.Windows.Forms.TextBox();
            this.label_ProjName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ProjUpdate
            // 
            this.btn_ProjUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjUpdate.Location = new System.Drawing.Point(506, 395);
            this.btn_ProjUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProjUpdate.Name = "btn_ProjUpdate";
            this.btn_ProjUpdate.Size = new System.Drawing.Size(112, 35);
            this.btn_ProjUpdate.TabIndex = 9;
            this.btn_ProjUpdate.Text = "ändern";
            this.btn_ProjUpdate.UseVisualStyleBackColor = true;
            this.btn_ProjUpdate.Click += new System.EventHandler(this.btn_ProjUpdate_Click);
            // 
            // textBox_ProjNameUpdate
            // 
            this.textBox_ProjNameUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ProjNameUpdate.Location = new System.Drawing.Point(22, 42);
            this.textBox_ProjNameUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_ProjNameUpdate.Name = "textBox_ProjNameUpdate";
            this.textBox_ProjNameUpdate.Size = new System.Drawing.Size(448, 26);
            this.textBox_ProjNameUpdate.TabIndex = 8;
            this.textBox_ProjNameUpdate.Text = "Name des ausgewählten Projektes";
            // 
            // label_ProjDescUpdate
            // 
            this.label_ProjDescUpdate.AutoSize = true;
            this.label_ProjDescUpdate.Location = new System.Drawing.Point(18, 98);
            this.label_ProjDescUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProjDescUpdate.Name = "label_ProjDescUpdate";
            this.label_ProjDescUpdate.Size = new System.Drawing.Size(158, 20);
            this.label_ProjDescUpdate.TabIndex = 7;
            this.label_ProjDescUpdate.Text = "Projektbeschreibung:";
            // 
            // textBox_ProjDescUpdate
            // 
            this.textBox_ProjDescUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ProjDescUpdate.Location = new System.Drawing.Point(22, 123);
            this.textBox_ProjDescUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_ProjDescUpdate.Multiline = true;
            this.textBox_ProjDescUpdate.Name = "textBox_ProjDescUpdate";
            this.textBox_ProjDescUpdate.Size = new System.Drawing.Size(448, 267);
            this.textBox_ProjDescUpdate.TabIndex = 6;
            this.textBox_ProjDescUpdate.Text = "Beschreibung des ausgewählten Projektes";
            // 
            // label_ProjName
            // 
            this.label_ProjName.AutoSize = true;
            this.label_ProjName.Location = new System.Drawing.Point(18, 15);
            this.label_ProjName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProjName.Name = "label_ProjName";
            this.label_ProjName.Size = new System.Drawing.Size(102, 20);
            this.label_ProjName.TabIndex = 5;
            this.label_ProjName.Text = "Projektname:";
            // 
            // Project_Update_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 448);
            this.Controls.Add(this.btn_ProjUpdate);
            this.Controls.Add(this.textBox_ProjNameUpdate);
            this.Controls.Add(this.label_ProjDescUpdate);
            this.Controls.Add(this.textBox_ProjDescUpdate);
            this.Controls.Add(this.label_ProjName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Project_Update_View";
            this.Text = "Projektupdate";
            this.Load += new System.EventHandler(this.Project_Update_View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ProjUpdate;
        private System.Windows.Forms.TextBox textBox_ProjNameUpdate;
        private System.Windows.Forms.Label label_ProjDescUpdate;
        private System.Windows.Forms.TextBox textBox_ProjDescUpdate;
        private System.Windows.Forms.Label label_ProjName;
    }
}