namespace NWAT
{
    partial class Projektverwaltung_Form
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
            this.label_ProjectChoose = new System.Windows.Forms.Label();
            this.comboBox_SelectProject = new System.Windows.Forms.ComboBox();
            this.btn_ProjectShow = new System.Windows.Forms.Button();
            this.btn_ProjectUpdate = new System.Windows.Forms.Button();
            this.btn_ProjectExport = new System.Windows.Forms.Button();
            this.btn_ProjectImport = new System.Windows.Forms.Button();
            this.btn_ProjectPrint = new System.Windows.Forms.Button();
            this.btn_ProjectStartCreate = new System.Windows.Forms.Button();
            this.textBox_ProjectCreateName = new System.Windows.Forms.TextBox();
            this.label_ProjectCreate = new System.Windows.Forms.Label();
            this.btn_ProjectModify = new System.Windows.Forms.Button();
            this.btn_ProjImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_ProjectChoose
            // 
            this.label_ProjectChoose.AutoSize = true;
            this.label_ProjectChoose.Location = new System.Drawing.Point(9, 124);
            this.label_ProjectChoose.Name = "label_ProjectChoose";
            this.label_ProjectChoose.Size = new System.Drawing.Size(163, 13);
            this.label_ProjectChoose.TabIndex = 0;
            this.label_ProjectChoose.Text = "Vorhandenes Projekt auswählen:";
            this.label_ProjectChoose.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox_SelectProject
            // 
            this.comboBox_SelectProject.FormattingEnabled = true;
            this.comboBox_SelectProject.Location = new System.Drawing.Point(12, 141);
            this.comboBox_SelectProject.Name = "comboBox_SelectProject";
            this.comboBox_SelectProject.Size = new System.Drawing.Size(300, 21);
            this.comboBox_SelectProject.TabIndex = 1;
            this.comboBox_SelectProject.Text = "Wählen Sie ein Projekt aus der Liste aus";
            // 
            // btn_ProjectShow
            // 
            this.btn_ProjectShow.Location = new System.Drawing.Point(337, 141);
            this.btn_ProjectShow.Name = "btn_ProjectShow";
            this.btn_ProjectShow.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectShow.TabIndex = 2;
            this.btn_ProjectShow.Text = "anzeigen";
            this.btn_ProjectShow.UseVisualStyleBackColor = true;
            // 
            // btn_ProjectUpdate
            // 
            this.btn_ProjectUpdate.Location = new System.Drawing.Point(337, 171);
            this.btn_ProjectUpdate.Name = "btn_ProjectUpdate";
            this.btn_ProjectUpdate.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectUpdate.TabIndex = 3;
            this.btn_ProjectUpdate.Text = "ändern";
            this.btn_ProjectUpdate.UseVisualStyleBackColor = true;
            // 
            // btn_ProjectExport
            // 
            this.btn_ProjectExport.Location = new System.Drawing.Point(337, 229);
            this.btn_ProjectExport.Name = "btn_ProjectExport";
            this.btn_ProjectExport.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectExport.TabIndex = 4;
            this.btn_ProjectExport.Text = "archivieren";
            this.btn_ProjectExport.UseVisualStyleBackColor = true;
            // 
            // btn_ProjectImport
            // 
            this.btn_ProjectImport.Location = new System.Drawing.Point(409, 294);
            this.btn_ProjectImport.Name = "btn_ProjectImport";
            this.btn_ProjectImport.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectImport.TabIndex = 5;
            this.btn_ProjectImport.Text = "importieren";
            this.btn_ProjectImport.UseVisualStyleBackColor = true;
            // 
            // btn_ProjectPrint
            // 
            this.btn_ProjectPrint.Location = new System.Drawing.Point(337, 200);
            this.btn_ProjectPrint.Name = "btn_ProjectPrint";
            this.btn_ProjectPrint.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectPrint.TabIndex = 6;
            this.btn_ProjectPrint.Text = "drucken";
            this.btn_ProjectPrint.UseVisualStyleBackColor = true;
            // 
            // btn_ProjectStartCreate
            // 
            this.btn_ProjectStartCreate.Location = new System.Drawing.Point(337, 50);
            this.btn_ProjectStartCreate.Name = "btn_ProjectStartCreate";
            this.btn_ProjectStartCreate.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectStartCreate.TabIndex = 7;
            this.btn_ProjectStartCreate.Text = "anlegen";
            this.btn_ProjectStartCreate.UseVisualStyleBackColor = true;
            // 
            // textBox_ProjectCreateName
            // 
            this.textBox_ProjectCreateName.Location = new System.Drawing.Point(12, 50);
            this.textBox_ProjectCreateName.Name = "textBox_ProjectCreateName";
            this.textBox_ProjectCreateName.Size = new System.Drawing.Size(300, 20);
            this.textBox_ProjectCreateName.TabIndex = 8;
            this.textBox_ProjectCreateName.Text = "Projektname eingeben";
            // 
            // label_ProjectCreate
            // 
            this.label_ProjectCreate.AutoSize = true;
            this.label_ProjectCreate.Location = new System.Drawing.Point(9, 34);
            this.label_ProjectCreate.Name = "label_ProjectCreate";
            this.label_ProjectCreate.Size = new System.Drawing.Size(118, 13);
            this.label_ProjectCreate.TabIndex = 9;
            this.label_ProjectCreate.Text = "Neues Projekt anlegen:";
            // 
            // btn_ProjectModify
            // 
            this.btn_ProjectModify.Location = new System.Drawing.Point(12, 168);
            this.btn_ProjectModify.Name = "btn_ProjectModify";
            this.btn_ProjectModify.Size = new System.Drawing.Size(159, 23);
            this.btn_ProjectModify.TabIndex = 10;
            this.btn_ProjectModify.Text = "Projekt bearbeiten";
            this.btn_ProjectModify.UseVisualStyleBackColor = true;
            // 
            // btn_ProjImport
            // 
            this.btn_ProjImport.Location = new System.Drawing.Point(337, 259);
            this.btn_ProjImport.Name = "btn_ProjImport";
            this.btn_ProjImport.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjImport.TabIndex = 11;
            this.btn_ProjImport.Text = "importieren";
            this.btn_ProjImport.UseVisualStyleBackColor = true;
            // 
            // Projektverwaltung_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 291);
            this.Controls.Add(this.btn_ProjImport);
            this.Controls.Add(this.btn_ProjectModify);
            this.Controls.Add(this.label_ProjectCreate);
            this.Controls.Add(this.textBox_ProjectCreateName);
            this.Controls.Add(this.btn_ProjectStartCreate);
            this.Controls.Add(this.btn_ProjectPrint);
            this.Controls.Add(this.btn_ProjectImport);
            this.Controls.Add(this.btn_ProjectExport);
            this.Controls.Add(this.btn_ProjectUpdate);
            this.Controls.Add(this.btn_ProjectShow);
            this.Controls.Add(this.comboBox_SelectProject);
            this.Controls.Add(this.label_ProjectChoose);
            this.Name = "Projektverwaltung_Form";
            this.Text = "Projektverwaltung";
            this.Load += new System.EventHandler(this.Projektverwaltung_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ProjectChoose;
        private System.Windows.Forms.ComboBox comboBox_SelectProject;
        private System.Windows.Forms.Button btn_ProjectShow;
        private System.Windows.Forms.Button btn_ProjectUpdate;
        private System.Windows.Forms.Button btn_ProjectExport;
        private System.Windows.Forms.Button btn_ProjectImport;
        private System.Windows.Forms.Button btn_ProjectPrint;
        private System.Windows.Forms.Button btn_ProjectStartCreate;
        private System.Windows.Forms.TextBox textBox_ProjectCreateName;
        private System.Windows.Forms.Label label_ProjectCreate;
        private System.Windows.Forms.Button btn_ProjectModify;
        private System.Windows.Forms.Button btn_ProjImport;
    }
}