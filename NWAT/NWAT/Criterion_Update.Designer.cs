namespace NWAT
{
    partial class Criterion_Update
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
            this.textBox_CritDescUpdate = new System.Windows.Forms.TextBox();
            this.label_CritDescUpdate = new System.Windows.Forms.Label();
            this.textBox_CritNameUpdate = new System.Windows.Forms.TextBox();
            this.btn_CritUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_CritName
            // 
            this.label_CritName.AutoSize = true;
            this.label_CritName.Location = new System.Drawing.Point(12, 9);
            this.label_CritName.Name = "label_CritName";
            this.label_CritName.Size = new System.Drawing.Size(68, 13);
            this.label_CritName.TabIndex = 0;
            this.label_CritName.Text = "Kriteriename:";
            // 
            // textBox_CritDescUpdate
            // 
            this.textBox_CritDescUpdate.Location = new System.Drawing.Point(15, 79);
            this.textBox_CritDescUpdate.Multiline = true;
            this.textBox_CritDescUpdate.Name = "textBox_CritDescUpdate";
            this.textBox_CritDescUpdate.Size = new System.Drawing.Size(300, 175);
            this.textBox_CritDescUpdate.TabIndex = 1;
            this.textBox_CritDescUpdate.Text = "Beschreibung des ausgewählten Kriteriums";
            // 
            // label_CritDescUpdate
            // 
            this.label_CritDescUpdate.AutoSize = true;
            this.label_CritDescUpdate.Location = new System.Drawing.Point(12, 63);
            this.label_CritDescUpdate.Name = "label_CritDescUpdate";
            this.label_CritDescUpdate.Size = new System.Drawing.Size(112, 13);
            this.label_CritDescUpdate.TabIndex = 2;
            this.label_CritDescUpdate.Text = "Kriterienbeschreibung:";
            // 
            // textBox_CritNameUpdate
            // 
            this.textBox_CritNameUpdate.Location = new System.Drawing.Point(15, 26);
            this.textBox_CritNameUpdate.Name = "textBox_CritNameUpdate";
            this.textBox_CritNameUpdate.Size = new System.Drawing.Size(300, 20);
            this.textBox_CritNameUpdate.TabIndex = 3;
            this.textBox_CritNameUpdate.Text = "Name des ausgewählten Kriteriums";
            // 
            // btn_CritUpdate
            // 
            this.btn_CritUpdate.Location = new System.Drawing.Point(337, 256);
            this.btn_CritUpdate.Name = "btn_CritUpdate";
            this.btn_CritUpdate.Size = new System.Drawing.Size(75, 23);
            this.btn_CritUpdate.TabIndex = 4;
            this.btn_CritUpdate.Text = "ändern";
            this.btn_CritUpdate.UseVisualStyleBackColor = true;
            // 
            // Criterion_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.btn_CritUpdate);
            this.Controls.Add(this.textBox_CritNameUpdate);
            this.Controls.Add(this.label_CritDescUpdate);
            this.Controls.Add(this.textBox_CritDescUpdate);
            this.Controls.Add(this.label_CritName);
            this.Name = "Criterion_Update";
            this.Text = "Kriterium ändern";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CritName;
        private System.Windows.Forms.TextBox textBox_CritDescUpdate;
        private System.Windows.Forms.Label label_CritDescUpdate;
        private System.Windows.Forms.TextBox textBox_CritNameUpdate;
        private System.Windows.Forms.Button btn_CritUpdate;
    }
}