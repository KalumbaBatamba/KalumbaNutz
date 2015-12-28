namespace NWAT
{
    partial class Project_Show_Form
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
            this.btn_ProjShowClose = new System.Windows.Forms.Button();
            this.label_ProjShowDesc = new System.Windows.Forms.Label();
            this.label_ProjDescLab = new System.Windows.Forms.Label();
            this.label_ProjShowName = new System.Windows.Forms.Label();
            this.label_ProjName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ProjShowClose
            // 
            this.btn_ProjShowClose.Location = new System.Drawing.Point(337, 257);
            this.btn_ProjShowClose.Name = "btn_ProjShowClose";
            this.btn_ProjShowClose.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjShowClose.TabIndex = 9;
            this.btn_ProjShowClose.Text = "schliessen";
            this.btn_ProjShowClose.UseVisualStyleBackColor = true;
            // 
            // label_ProjShowDesc
            // 
            this.label_ProjShowDesc.AutoSize = true;
            this.label_ProjShowDesc.Location = new System.Drawing.Point(12, 101);
            this.label_ProjShowDesc.Name = "label_ProjShowDesc";
            this.label_ProjShowDesc.Size = new System.Drawing.Size(208, 13);
            this.label_ProjShowDesc.TabIndex = 8;
            this.label_ProjShowDesc.Text = "Beschreigung des ausgewählten Projektes";
            // 
            // label_ProjDescLab
            // 
            this.label_ProjDescLab.AutoSize = true;
            this.label_ProjDescLab.Location = new System.Drawing.Point(12, 77);
            this.label_ProjDescLab.Name = "label_ProjDescLab";
            this.label_ProjDescLab.Size = new System.Drawing.Size(107, 13);
            this.label_ProjDescLab.TabIndex = 7;
            this.label_ProjDescLab.Text = "Projektbeschreibung:";
            // 
            // label_ProjShowName
            // 
            this.label_ProjShowName.AutoSize = true;
            this.label_ProjShowName.Location = new System.Drawing.Point(12, 33);
            this.label_ProjShowName.Name = "label_ProjShowName";
            this.label_ProjShowName.Size = new System.Drawing.Size(177, 13);
            this.label_ProjShowName.TabIndex = 6;
            this.label_ProjShowName.Text = "Name des anzuzeigenden Projektes";
            // 
            // label_ProjName
            // 
            this.label_ProjName.AutoSize = true;
            this.label_ProjName.Location = new System.Drawing.Point(12, 10);
            this.label_ProjName.Name = "label_ProjName";
            this.label_ProjName.Size = new System.Drawing.Size(69, 13);
            this.label_ProjName.TabIndex = 5;
            this.label_ProjName.Text = "Projektname:";
            // 
            // Project_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.btn_ProjShowClose);
            this.Controls.Add(this.label_ProjShowDesc);
            this.Controls.Add(this.label_ProjDescLab);
            this.Controls.Add(this.label_ProjShowName);
            this.Controls.Add(this.label_ProjName);
            this.Name = "Project_Show";
            this.Text = "Projekt anzeigen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ProjShowClose;
        private System.Windows.Forms.Label label_ProjShowDesc;
        private System.Windows.Forms.Label label_ProjDescLab;
        private System.Windows.Forms.Label label_ProjShowName;
        private System.Windows.Forms.Label label_ProjName;
    }
}