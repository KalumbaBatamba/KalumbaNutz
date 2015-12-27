namespace NWAT
{
    partial class StartForm
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
            this.btn_ProjAdm = new System.Windows.Forms.Button();
            this.btn_CritAdm = new System.Windows.Forms.Button();
            this.btn_ProdAdm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ProjAdm
            // 
            this.btn_ProjAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ProjAdm.Location = new System.Drawing.Point(127, 91);
            this.btn_ProjAdm.Name = "btn_ProjAdm";
            this.btn_ProjAdm.Size = new System.Drawing.Size(203, 54);
            this.btn_ProjAdm.TabIndex = 0;
            this.btn_ProjAdm.Text = "Projektverwaltung";
            this.btn_ProjAdm.UseVisualStyleBackColor = true;
            // 
            // btn_CritAdm
            // 
            this.btn_CritAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CritAdm.Location = new System.Drawing.Point(127, 180);
            this.btn_CritAdm.Name = "btn_CritAdm";
            this.btn_CritAdm.Size = new System.Drawing.Size(203, 57);
            this.btn_CritAdm.TabIndex = 1;
            this.btn_CritAdm.Text = "Kriterienverwaltung";
            this.btn_CritAdm.UseVisualStyleBackColor = true;
            this.btn_CritAdm.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_ProdAdm
            // 
            this.btn_ProdAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ProdAdm.Location = new System.Drawing.Point(127, 268);
            this.btn_ProdAdm.Name = "btn_ProdAdm";
            this.btn_ProdAdm.Size = new System.Drawing.Size(203, 63);
            this.btn_ProdAdm.TabIndex = 2;
            this.btn_ProdAdm.Text = "Produktverwaltung";
            this.btn_ProdAdm.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 408);
            this.Controls.Add(this.btn_ProdAdm);
            this.Controls.Add(this.btn_CritAdm);
            this.Controls.Add(this.btn_ProjAdm);
            this.Name = "StartForm";
            this.Text = "NWAT";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ProjAdm;
        private System.Windows.Forms.Button btn_CritAdm;
        private System.Windows.Forms.Button btn_ProdAdm;
    }
}