namespace NWAT.Views
{
    partial class ProjCritParentAllocation_View
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
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Crit = new System.Windows.Forms.Label();
            this.label_Text = new System.Windows.Forms.Label();
            this.comboBox_CritName = new System.Windows.Forms.ComboBox();
            this.btn_zuordnen = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(26, 21);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(118, 13);
            this.label_Name.TabIndex = 0;
            this.label_Name.Text = "ausgewähltes Kriterium:";
            // 
            // label_Crit
            // 
            this.label_Crit.AutoSize = true;
            this.label_Crit.Location = new System.Drawing.Point(26, 46);
            this.label_Crit.Name = "label_Crit";
            this.label_Crit.Size = new System.Drawing.Size(35, 13);
            this.label_Crit.TabIndex = 1;
            this.label_Crit.Text = "label1";
            // 
            // label_Text
            // 
            this.label_Text.AutoSize = true;
            this.label_Text.Location = new System.Drawing.Point(26, 100);
            this.label_Text.Name = "label_Text";
            this.label_Text.Size = new System.Drawing.Size(232, 13);
            this.label_Text.TabIndex = 2;
            this.label_Text.Text = "Hat das ausgewählte Kriterium ein Vaterelement";
            // 
            // comboBox_CritName
            // 
            this.comboBox_CritName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_CritName.FormattingEnabled = true;
            this.comboBox_CritName.Location = new System.Drawing.Point(29, 129);
            this.comboBox_CritName.Name = "comboBox_CritName";
            this.comboBox_CritName.Size = new System.Drawing.Size(229, 21);
            this.comboBox_CritName.TabIndex = 3;
            this.comboBox_CritName.Text = "Vaterkriterium auswählen";
            // 
            // btn_zuordnen
            // 
            this.btn_zuordnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_zuordnen.Location = new System.Drawing.Point(29, 176);
            this.btn_zuordnen.Name = "btn_zuordnen";
            this.btn_zuordnen.Size = new System.Drawing.Size(75, 23);
            this.btn_zuordnen.TabIndex = 4;
            this.btn_zuordnen.Text = "zuordnen";
            this.btn_zuordnen.UseVisualStyleBackColor = true;
            this.btn_zuordnen.Click += new System.EventHandler(this.btn_zuordnen_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancle.Location = new System.Drawing.Point(122, 176);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(136, 23);
            this.btn_cancle.TabIndex = 5;
            this.btn_cancle.Text = "ohne Parent zuordnen";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // ProjCritParentAllocation_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 239);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_zuordnen);
            this.Controls.Add(this.comboBox_CritName);
            this.Controls.Add(this.label_Text);
            this.Controls.Add(this.label_Crit);
            this.Controls.Add(this.label_Name);
            this.Name = "ProjCritParentAllocation_View";
            this.Text = "ProjCritParentAllocation";
            this.Load += new System.EventHandler(this.ProjCritParentAllocation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Crit;
        private System.Windows.Forms.Label label_Text;
        private System.Windows.Forms.ComboBox comboBox_CritName;
        private System.Windows.Forms.Button btn_zuordnen;
        private System.Windows.Forms.Button btn_cancle;
    }
}