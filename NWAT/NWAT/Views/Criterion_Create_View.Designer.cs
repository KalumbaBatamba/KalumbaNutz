namespace NWAT
{
    partial class Criterion_Create_View
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
            this.label_CritDesc = new System.Windows.Forms.Label();
            this.textBox_CritNameCreate = new System.Windows.Forms.TextBox();
            this.textBox_CritDescCreate = new System.Windows.Forms.TextBox();
            this.btn_CritCreate = new System.Windows.Forms.Button();
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
            // label_CritDesc
            // 
            this.label_CritDesc.AutoSize = true;
            this.label_CritDesc.Location = new System.Drawing.Point(10, 62);
            this.label_CritDesc.Name = "label_CritDesc";
            this.label_CritDesc.Size = new System.Drawing.Size(112, 13);
            this.label_CritDesc.TabIndex = 1;
            this.label_CritDesc.Text = "Kriterienbeschreibung:";
            // 
            // textBox_CritNameCreate
            // 
            this.textBox_CritNameCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CritNameCreate.Location = new System.Drawing.Point(13, 26);
            this.textBox_CritNameCreate.Name = "textBox_CritNameCreate";
            this.textBox_CritNameCreate.Size = new System.Drawing.Size(300, 20);
            this.textBox_CritNameCreate.TabIndex = 2;
            // 
            // textBox_CritDescCreate
            // 
            this.textBox_CritDescCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CritDescCreate.Location = new System.Drawing.Point(13, 78);
            this.textBox_CritDescCreate.Multiline = true;
            this.textBox_CritDescCreate.Name = "textBox_CritDescCreate";
            this.textBox_CritDescCreate.Size = new System.Drawing.Size(300, 175);
            this.textBox_CritDescCreate.TabIndex = 3;
            // 
            // btn_CritCreate
            // 
            this.btn_CritCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CritCreate.Location = new System.Drawing.Point(337, 256);
            this.btn_CritCreate.Name = "btn_CritCreate";
            this.btn_CritCreate.Size = new System.Drawing.Size(75, 23);
            this.btn_CritCreate.TabIndex = 4;
            this.btn_CritCreate.Text = "anlegen";
            this.btn_CritCreate.UseVisualStyleBackColor = true;
            this.btn_CritCreate.Click += new System.EventHandler(this.btn_CritCreate_Click);
            // 
            // Criterion_Create_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.btn_CritCreate);
            this.Controls.Add(this.textBox_CritDescCreate);
            this.Controls.Add(this.textBox_CritNameCreate);
            this.Controls.Add(this.label_CritDesc);
            this.Controls.Add(this.label_CritName);
            this.Name = "Criterion_Create_View";
            this.Text = "Kriterium anlegen";
            this.Load += new System.EventHandler(this.Criterion_Create_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CritName;
        private System.Windows.Forms.Label label_CritDesc;
        private System.Windows.Forms.TextBox textBox_CritNameCreate;
        private System.Windows.Forms.TextBox textBox_CritDescCreate;
        private System.Windows.Forms.Button btn_CritCreate;
    }
}