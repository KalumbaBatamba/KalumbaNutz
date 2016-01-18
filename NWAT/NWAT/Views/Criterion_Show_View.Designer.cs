namespace NWAT
{
    partial class Criterion_Show_View
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
            this.label_CritName = new System.Windows.Forms.Label();
            this.label_CritShowName = new System.Windows.Forms.Label();
            this.label_CritDescLab = new System.Windows.Forms.Label();
            this.label_CritShowDesc = new System.Windows.Forms.Label();
            this.btn_CritShowClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_CritName
            // 
            this.label_CritName.AutoSize = true;
            this.label_CritName.Location = new System.Drawing.Point(12, 9);
            this.label_CritName.Name = "label_CritName";
            this.label_CritName.Size = new System.Drawing.Size(74, 13);
            this.label_CritName.TabIndex = 0;
            this.label_CritName.Text = "Kriterienname:";
            // 
            // label_CritShowName
            // 
            this.label_CritShowName.AutoSize = true;
            this.label_CritShowName.Location = new System.Drawing.Point(12, 32);
            this.label_CritShowName.Name = "label_CritShowName";
            this.label_CritShowName.Size = new System.Drawing.Size(178, 13);
            this.label_CritShowName.TabIndex = 1;
            this.label_CritShowName.Text = "Name des anzuzeigenden Kriteriums";
            this.label_CritShowName.Click += new System.EventHandler(this.label_CritShowName_Click);
            // 
            // label_CritDescLab
            // 
            this.label_CritDescLab.AutoSize = true;
            this.label_CritDescLab.Location = new System.Drawing.Point(12, 76);
            this.label_CritDescLab.Name = "label_CritDescLab";
            this.label_CritDescLab.Size = new System.Drawing.Size(112, 13);
            this.label_CritDescLab.TabIndex = 2;
            this.label_CritDescLab.Text = "Kriterienbeschreibung:";
            // 
            // label_CritShowDesc
            // 
            this.label_CritShowDesc.AutoSize = true;
            this.label_CritShowDesc.Location = new System.Drawing.Point(12, 100);
            this.label_CritShowDesc.Name = "label_CritShowDesc";
            this.label_CritShowDesc.Size = new System.Drawing.Size(209, 13);
            this.label_CritShowDesc.TabIndex = 3;
            this.label_CritShowDesc.Text = "Beschreigung des ausgewählten Kriteriums";
            // 
            // btn_CritShowClose
            // 
            this.btn_CritShowClose.Location = new System.Drawing.Point(337, 256);
            this.btn_CritShowClose.Name = "btn_CritShowClose";
            this.btn_CritShowClose.Size = new System.Drawing.Size(75, 23);
            this.btn_CritShowClose.TabIndex = 4;
            this.btn_CritShowClose.Text = "schliessen";
            this.btn_CritShowClose.UseVisualStyleBackColor = true;
            // 
            // Criterion_Show_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.btn_CritShowClose);
            this.Controls.Add(this.label_CritShowDesc);
            this.Controls.Add(this.label_CritDescLab);
            this.Controls.Add(this.label_CritShowName);
            this.Controls.Add(this.label_CritName);
            this.Name = "Criterion_Show_View";
            this.Text = "Kriteriendeltails";
            this.Load += new System.EventHandler(this.Criterion_Show_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CritName;
        private System.Windows.Forms.Label label_CritShowName;
        private System.Windows.Forms.Label label_CritDescLab;
        private System.Windows.Forms.Label label_CritShowDesc;
        private System.Windows.Forms.Button btn_CritShowClose;
    }
}