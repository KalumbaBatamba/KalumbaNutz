namespace NWAT
{
    partial class aktuellesProjekt_View
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
            this.label_CurrProjName = new System.Windows.Forms.Label();
            this.label_CurrProjNameShow = new System.Windows.Forms.Label();
            this.label_CurrProjDesc = new System.Windows.Forms.Label();
            this.label_CurrProjDescShow = new System.Windows.Forms.Label();
            this.groupBox_CurrProjCrits = new System.Windows.Forms.GroupBox();
            this.btn_Balance = new System.Windows.Forms.Button();
            this.btn_CurrProjKritAssign = new System.Windows.Forms.Button();
            this.btn_CurrProjCritStruShow = new System.Windows.Forms.Button();
            this.btn_CurrProjCritStruUpdate = new System.Windows.Forms.Button();
            this.btn_CurrProjCritStruPrint = new System.Windows.Forms.Button();
            this.groupBox_CurrProjProds = new System.Windows.Forms.GroupBox();
            this.btn_CurrProjProdAssign = new System.Windows.Forms.Button();
            this.btn_CurrProjProdFulfCapt = new System.Windows.Forms.Button();
            this.btnCurrProjProdFulfPrint = new System.Windows.Forms.Button();
            this.groupBox_CurrProjAnalys = new System.Windows.Forms.GroupBox();
            this.btn_CurrProjProdAnalShow = new System.Windows.Forms.Button();
            this.groupBox_CurrProjCrits.SuspendLayout();
            this.groupBox_CurrProjProds.SuspendLayout();
            this.groupBox_CurrProjAnalys.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_CurrProjName
            // 
            this.label_CurrProjName.AutoSize = true;
            this.label_CurrProjName.Location = new System.Drawing.Point(13, 13);
            this.label_CurrProjName.Name = "label_CurrProjName";
            this.label_CurrProjName.Size = new System.Drawing.Size(69, 13);
            this.label_CurrProjName.TabIndex = 0;
            this.label_CurrProjName.Text = "Projektname:";
            this.label_CurrProjName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_CurrProjName.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_CurrProjNameShow
            // 
            this.label_CurrProjNameShow.AutoSize = true;
            this.label_CurrProjNameShow.Location = new System.Drawing.Point(108, 13);
            this.label_CurrProjNameShow.Name = "label_CurrProjNameShow";
            this.label_CurrProjNameShow.Size = new System.Drawing.Size(148, 13);
            this.label_CurrProjNameShow.TabIndex = 1;
            this.label_CurrProjNameShow.Text = "Name des aktuellen Projektes";
            this.label_CurrProjNameShow.Click += new System.EventHandler(this.label_CurrProjNameShow_Click);
            // 
            // label_CurrProjDesc
            // 
            this.label_CurrProjDesc.AutoSize = true;
            this.label_CurrProjDesc.Location = new System.Drawing.Point(12, 29);
            this.label_CurrProjDesc.Name = "label_CurrProjDesc";
            this.label_CurrProjDesc.Size = new System.Drawing.Size(75, 13);
            this.label_CurrProjDesc.TabIndex = 2;
            this.label_CurrProjDesc.Text = "Beschreibung:";
            this.label_CurrProjDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_CurrProjDescShow
            // 
            this.label_CurrProjDescShow.AutoSize = true;
            this.label_CurrProjDescShow.Location = new System.Drawing.Point(108, 29);
            this.label_CurrProjDescShow.Name = "label_CurrProjDescShow";
            this.label_CurrProjDescShow.Size = new System.Drawing.Size(185, 13);
            this.label_CurrProjDescShow.TabIndex = 3;
            this.label_CurrProjDescShow.Text = "Beschreibung des aktuellen Projektes";
            // 
            // groupBox_CurrProjCrits
            // 
            this.groupBox_CurrProjCrits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_CurrProjCrits.Controls.Add(this.btn_Balance);
            this.groupBox_CurrProjCrits.Controls.Add(this.btn_CurrProjKritAssign);
            this.groupBox_CurrProjCrits.Controls.Add(this.btn_CurrProjCritStruShow);
            this.groupBox_CurrProjCrits.Controls.Add(this.btn_CurrProjCritStruUpdate);
            this.groupBox_CurrProjCrits.Controls.Add(this.btn_CurrProjCritStruPrint);
            this.groupBox_CurrProjCrits.Location = new System.Drawing.Point(7, 299);
            this.groupBox_CurrProjCrits.Name = "groupBox_CurrProjCrits";
            this.groupBox_CurrProjCrits.Size = new System.Drawing.Size(164, 167);
            this.groupBox_CurrProjCrits.TabIndex = 20;
            this.groupBox_CurrProjCrits.TabStop = false;
            this.groupBox_CurrProjCrits.Text = "Projektkriterien";
            // 
            // btn_Balance
            // 
            this.btn_Balance.Location = new System.Drawing.Point(6, 136);
            this.btn_Balance.Name = "btn_Balance";
            this.btn_Balance.Size = new System.Drawing.Size(111, 23);
            this.btn_Balance.TabIndex = 11;
            this.btn_Balance.Text = "Gewichtung";
            this.btn_Balance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Balance.UseVisualStyleBackColor = true;
            this.btn_Balance.Click += new System.EventHandler(this.btn_Balance_Click);
            // 
            // btn_CurrProjKritAssign
            // 
            this.btn_CurrProjKritAssign.Location = new System.Drawing.Point(6, 19);
            this.btn_CurrProjKritAssign.Name = "btn_CurrProjKritAssign";
            this.btn_CurrProjKritAssign.Size = new System.Drawing.Size(111, 23);
            this.btn_CurrProjKritAssign.TabIndex = 7;
            this.btn_CurrProjKritAssign.Text = "Kriterien zuordnen";
            this.btn_CurrProjKritAssign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CurrProjKritAssign.UseVisualStyleBackColor = true;
            this.btn_CurrProjKritAssign.Click += new System.EventHandler(this.btn_CurrProjKritAssign_Click);
            // 
            // btn_CurrProjCritStruShow
            // 
            this.btn_CurrProjCritStruShow.Location = new System.Drawing.Point(6, 48);
            this.btn_CurrProjCritStruShow.Name = "btn_CurrProjCritStruShow";
            this.btn_CurrProjCritStruShow.Size = new System.Drawing.Size(142, 23);
            this.btn_CurrProjCritStruShow.TabIndex = 8;
            this.btn_CurrProjCritStruShow.Text = "Kriterienstruktur anzeigen";
            this.btn_CurrProjCritStruShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CurrProjCritStruShow.UseVisualStyleBackColor = true;
            this.btn_CurrProjCritStruShow.Click += new System.EventHandler(this.btn_CurrProjCritStruShow_Click);
            // 
            // btn_CurrProjCritStruUpdate
            // 
            this.btn_CurrProjCritStruUpdate.Location = new System.Drawing.Point(6, 77);
            this.btn_CurrProjCritStruUpdate.Name = "btn_CurrProjCritStruUpdate";
            this.btn_CurrProjCritStruUpdate.Size = new System.Drawing.Size(142, 23);
            this.btn_CurrProjCritStruUpdate.TabIndex = 9;
            this.btn_CurrProjCritStruUpdate.Text = "Kriterienstruktur ändern";
            this.btn_CurrProjCritStruUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CurrProjCritStruUpdate.UseVisualStyleBackColor = true;
            this.btn_CurrProjCritStruUpdate.Click += new System.EventHandler(this.btn_CurrProjCritStruUpdate_Click);
            // 
            // btn_CurrProjCritStruPrint
            // 
            this.btn_CurrProjCritStruPrint.Location = new System.Drawing.Point(6, 106);
            this.btn_CurrProjCritStruPrint.Name = "btn_CurrProjCritStruPrint";
            this.btn_CurrProjCritStruPrint.Size = new System.Drawing.Size(142, 23);
            this.btn_CurrProjCritStruPrint.TabIndex = 10;
            this.btn_CurrProjCritStruPrint.Text = "Kriterienstruktur drucken";
            this.btn_CurrProjCritStruPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CurrProjCritStruPrint.UseVisualStyleBackColor = true;
            this.btn_CurrProjCritStruPrint.Click += new System.EventHandler(this.btn_CurrProjCritStruPrint_Click);
            // 
            // groupBox_CurrProjProds
            // 
            this.groupBox_CurrProjProds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_CurrProjProds.Controls.Add(this.btn_CurrProjProdAssign);
            this.groupBox_CurrProjProds.Controls.Add(this.btn_CurrProjProdFulfCapt);
            this.groupBox_CurrProjProds.Controls.Add(this.btnCurrProjProdFulfPrint);
            this.groupBox_CurrProjProds.Location = new System.Drawing.Point(177, 299);
            this.groupBox_CurrProjProds.Name = "groupBox_CurrProjProds";
            this.groupBox_CurrProjProds.Size = new System.Drawing.Size(163, 110);
            this.groupBox_CurrProjProds.TabIndex = 21;
            this.groupBox_CurrProjProds.TabStop = false;
            this.groupBox_CurrProjProds.Text = "Projektprodukte";
            this.groupBox_CurrProjProds.Enter += new System.EventHandler(this.groupBox_CurrProjProds_Enter);
            // 
            // btn_CurrProjProdAssign
            // 
            this.btn_CurrProjProdAssign.Location = new System.Drawing.Point(6, 19);
            this.btn_CurrProjProdAssign.Name = "btn_CurrProjProdAssign";
            this.btn_CurrProjProdAssign.Size = new System.Drawing.Size(111, 23);
            this.btn_CurrProjProdAssign.TabIndex = 6;
            this.btn_CurrProjProdAssign.Text = "Produkte zuordnen";
            this.btn_CurrProjProdAssign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CurrProjProdAssign.UseVisualStyleBackColor = true;
            this.btn_CurrProjProdAssign.Click += new System.EventHandler(this.btn_CurrProjProdAssign_Click);
            // 
            // btn_CurrProjProdFulfCapt
            // 
            this.btn_CurrProjProdFulfCapt.Location = new System.Drawing.Point(6, 48);
            this.btn_CurrProjProdFulfCapt.Name = "btn_CurrProjProdFulfCapt";
            this.btn_CurrProjProdFulfCapt.Size = new System.Drawing.Size(142, 23);
            this.btn_CurrProjProdFulfCapt.TabIndex = 13;
            this.btn_CurrProjProdFulfCapt.Text = "Erfüllung erfassen";
            this.btn_CurrProjProdFulfCapt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CurrProjProdFulfCapt.UseVisualStyleBackColor = true;
            this.btn_CurrProjProdFulfCapt.Click += new System.EventHandler(this.btn_CurrProjProdFulfCapt_Click);
            // 
            // btnCurrProjProdFulfPrint
            // 
            this.btnCurrProjProdFulfPrint.Location = new System.Drawing.Point(6, 77);
            this.btnCurrProjProdFulfPrint.Name = "btnCurrProjProdFulfPrint";
            this.btnCurrProjProdFulfPrint.Size = new System.Drawing.Size(142, 23);
            this.btnCurrProjProdFulfPrint.TabIndex = 14;
            this.btnCurrProjProdFulfPrint.Text = "Erfüllungen drucken";
            this.btnCurrProjProdFulfPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrProjProdFulfPrint.UseVisualStyleBackColor = true;
            this.btnCurrProjProdFulfPrint.Click += new System.EventHandler(this.btnCurrProjProdFulfPrint_Click);
            // 
            // groupBox_CurrProjAnalys
            // 
            this.groupBox_CurrProjAnalys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_CurrProjAnalys.Controls.Add(this.btn_CurrProjProdAnalShow);
            this.groupBox_CurrProjAnalys.Location = new System.Drawing.Point(346, 299);
            this.groupBox_CurrProjAnalys.Name = "groupBox_CurrProjAnalys";
            this.groupBox_CurrProjAnalys.Size = new System.Drawing.Size(173, 54);
            this.groupBox_CurrProjAnalys.TabIndex = 22;
            this.groupBox_CurrProjAnalys.TabStop = false;
            this.groupBox_CurrProjAnalys.Text = "Analyse";
            // 
            // btn_CurrProjProdAnalShow
            // 
            this.btn_CurrProjProdAnalShow.Location = new System.Drawing.Point(6, 19);
            this.btn_CurrProjProdAnalShow.Name = "btn_CurrProjProdAnalShow";
            this.btn_CurrProjProdAnalShow.Size = new System.Drawing.Size(111, 23);
            this.btn_CurrProjProdAnalShow.TabIndex = 15;
            this.btn_CurrProjProdAnalShow.Text = "Analyse anzeigen";
            this.btn_CurrProjProdAnalShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CurrProjProdAnalShow.UseVisualStyleBackColor = true;
            this.btn_CurrProjProdAnalShow.Click += new System.EventHandler(this.btn_CurrProjProdAnalShow_Click);
            // 
            // aktuellesProjekt_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 474);
            this.Controls.Add(this.groupBox_CurrProjAnalys);
            this.Controls.Add(this.groupBox_CurrProjProds);
            this.Controls.Add(this.groupBox_CurrProjCrits);
            this.Controls.Add(this.label_CurrProjDescShow);
            this.Controls.Add(this.label_CurrProjDesc);
            this.Controls.Add(this.label_CurrProjNameShow);
            this.Controls.Add(this.label_CurrProjName);
            this.Name = "aktuellesProjekt_View";
            this.Text = "aktuelles Projekt ";
            this.Load += new System.EventHandler(this.aktuellesProjekt_Load);
            this.groupBox_CurrProjCrits.ResumeLayout(false);
            this.groupBox_CurrProjProds.ResumeLayout(false);
            this.groupBox_CurrProjAnalys.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CurrProjName;
        private System.Windows.Forms.Label label_CurrProjNameShow;
        private System.Windows.Forms.Label label_CurrProjDesc;
        private System.Windows.Forms.Label label_CurrProjDescShow;
        private System.Windows.Forms.GroupBox groupBox_CurrProjCrits;
        private System.Windows.Forms.Button btn_CurrProjKritAssign;
        private System.Windows.Forms.Button btn_CurrProjCritStruShow;
        private System.Windows.Forms.Button btn_CurrProjCritStruUpdate;
        private System.Windows.Forms.Button btn_CurrProjCritStruPrint;
        private System.Windows.Forms.GroupBox groupBox_CurrProjProds;
        private System.Windows.Forms.Button btn_CurrProjProdAssign;
        private System.Windows.Forms.Button btn_CurrProjProdFulfCapt;
        private System.Windows.Forms.Button btnCurrProjProdFulfPrint;
        private System.Windows.Forms.GroupBox groupBox_CurrProjAnalys;
        private System.Windows.Forms.Button btn_CurrProjProdAnalShow;
        private System.Windows.Forms.Button btn_Balance;
    }
}