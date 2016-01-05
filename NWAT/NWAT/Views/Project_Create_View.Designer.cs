namespace NWAT
{
    partial class Project_Create_View
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
            this.btn_ProjCreate = new System.Windows.Forms.Button();
            this.textBox_ProjDescCreate = new System.Windows.Forms.TextBox();
            this.textBox_ProjNameCreate = new System.Windows.Forms.TextBox();
            this.label_ProjDesc = new System.Windows.Forms.Label();
            this.label_ProjName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ProjCreate
            // 
            this.btn_ProjCreate.Location = new System.Drawing.Point(338, 257);
            this.btn_ProjCreate.Name = "btn_ProjCreate";
            this.btn_ProjCreate.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCreate.TabIndex = 9;
            this.btn_ProjCreate.Text = "anlegen";
            this.btn_ProjCreate.UseVisualStyleBackColor = true;
            this.btn_ProjCreate.Click += new System.EventHandler(this.btn_ProjCreate_Click);
            // 
            // textBox_ProjDescCreate
            // 
            this.textBox_ProjDescCreate.Location = new System.Drawing.Point(14, 79);
            this.textBox_ProjDescCreate.Multiline = true;
            this.textBox_ProjDescCreate.Name = "textBox_ProjDescCreate";
            this.textBox_ProjDescCreate.Size = new System.Drawing.Size(300, 175);
            this.textBox_ProjDescCreate.TabIndex = 8;
            // 
            // textBox_ProjNameCreate
            // 
            this.textBox_ProjNameCreate.Location = new System.Drawing.Point(14, 27);
            this.textBox_ProjNameCreate.Name = "textBox_ProjNameCreate";
            this.textBox_ProjNameCreate.Size = new System.Drawing.Size(300, 20);
            this.textBox_ProjNameCreate.TabIndex = 7;
            // 
            // label_ProjDesc
            // 
            this.label_ProjDesc.AutoSize = true;
            this.label_ProjDesc.Location = new System.Drawing.Point(11, 63);
            this.label_ProjDesc.Name = "label_ProjDesc";
            this.label_ProjDesc.Size = new System.Drawing.Size(107, 13);
            this.label_ProjDesc.TabIndex = 6;
            this.label_ProjDesc.Text = "Projektbeschreibung:";
            // 
            // label_ProjName
            // 
            this.label_ProjName.AutoSize = true;
            this.label_ProjName.Location = new System.Drawing.Point(13, 10);
            this.label_ProjName.Name = "label_ProjName";
            this.label_ProjName.Size = new System.Drawing.Size(69, 13);
            this.label_ProjName.TabIndex = 5;
            this.label_ProjName.Text = "Projektname:";
            // 
            // Project_Create_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.btn_ProjCreate);
            this.Controls.Add(this.textBox_ProjDescCreate);
            this.Controls.Add(this.textBox_ProjNameCreate);
            this.Controls.Add(this.label_ProjDesc);
            this.Controls.Add(this.label_ProjName);
            this.Name = "Project_Create_Form";
            this.Text = "Projekt anlegen";
            this.Load += new System.EventHandler(this.Project_Create_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ProjCreate;
        private System.Windows.Forms.TextBox textBox_ProjDescCreate;
        private System.Windows.Forms.TextBox textBox_ProjNameCreate;
        private System.Windows.Forms.Label label_ProjDesc;
        private System.Windows.Forms.Label label_ProjName;
    }
}