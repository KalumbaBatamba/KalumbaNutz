﻿namespace NWAT
{
    partial class NWAT_Start_View
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
            this.btn_ProjAdm.Location = new System.Drawing.Point(113, 30);
            this.btn_ProjAdm.Name = "btn_ProjAdm";
            this.btn_ProjAdm.Size = new System.Drawing.Size(203, 54);
            this.btn_ProjAdm.TabIndex = 0;
            this.btn_ProjAdm.Text = "Projektverwaltung";
            this.btn_ProjAdm.UseVisualStyleBackColor = true;
            this.btn_ProjAdm.Click += new System.EventHandler(this.btn_ProjAdm_Click);
            // 
            // btn_CritAdm
            // 
            this.btn_CritAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CritAdm.Location = new System.Drawing.Point(113, 114);
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
            this.btn_ProdAdm.Location = new System.Drawing.Point(113, 199);
            this.btn_ProdAdm.Name = "btn_ProdAdm";
            this.btn_ProdAdm.Size = new System.Drawing.Size(203, 63);
            this.btn_ProdAdm.TabIndex = 2;
            this.btn_ProdAdm.Text = "Produktverwaltung";
            this.btn_ProdAdm.UseVisualStyleBackColor = true;
            this.btn_ProdAdm.Click += new System.EventHandler(this.btn_ProdAdm_Click);
            // 
            // NWA_Start_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.btn_ProdAdm);
            this.Controls.Add(this.btn_CritAdm);
            this.Controls.Add(this.btn_ProjAdm);
            this.Name = "NWA_Start_Form";
            this.Text = "NWAT";
            this.Load += new System.EventHandler(this.NWA_Start_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ProjAdm;
        private System.Windows.Forms.Button btn_CritAdm;
        private System.Windows.Forms.Button btn_ProdAdm;
    }
}