namespace NWAT
{
    partial class Criterion_Delete
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
            this.btn_CritDelete_Cancle = new System.Windows.Forms.Button();
            this.btn_CritDelete = new System.Windows.Forms.Button();
            this.labelCritDeleteCheck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_CritName
            // 
            this.label_CritName.AutoSize = true;
            this.label_CritName.Location = new System.Drawing.Point(12, 56);
            this.label_CritName.Name = "label_CritName";
            this.label_CritName.Size = new System.Drawing.Size(172, 13);
            this.label_CritName.TabIndex = 0;
            this.label_CritName.Text = "Name des ausgewählten Kriteriums";
            // 
            // label_CritDesc
            // 
            this.label_CritDesc.AutoSize = true;
            this.label_CritDesc.Location = new System.Drawing.Point(12, 80);
            this.label_CritDesc.Name = "label_CritDesc";
            this.label_CritDesc.Size = new System.Drawing.Size(209, 13);
            this.label_CritDesc.TabIndex = 1;
            this.label_CritDesc.Text = "Beschreibung des ausgewählten Kriteriums";
            // 
            // btn_CritDelete_Cancle
            // 
            this.btn_CritDelete_Cancle.Location = new System.Drawing.Point(341, 256);
            this.btn_CritDelete_Cancle.Name = "btn_CritDelete_Cancle";
            this.btn_CritDelete_Cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_CritDelete_Cancle.TabIndex = 2;
            this.btn_CritDelete_Cancle.Text = "abbrechen";
            this.btn_CritDelete_Cancle.UseVisualStyleBackColor = true;
            // 
            // btn_CritDelete
            // 
            this.btn_CritDelete.Location = new System.Drawing.Point(260, 256);
            this.btn_CritDelete.Name = "btn_CritDelete";
            this.btn_CritDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_CritDelete.TabIndex = 3;
            this.btn_CritDelete.Text = "löschen";
            this.btn_CritDelete.UseVisualStyleBackColor = true;
            // 
            // labelCritDeleteCheck
            // 
            this.labelCritDeleteCheck.AutoSize = true;
            this.labelCritDeleteCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCritDeleteCheck.Location = new System.Drawing.Point(13, 13);
            this.labelCritDeleteCheck.Name = "labelCritDeleteCheck";
            this.labelCritDeleteCheck.Size = new System.Drawing.Size(384, 16);
            this.labelCritDeleteCheck.TabIndex = 4;
            this.labelCritDeleteCheck.Text = "Sind Sie sicher, dass Sie folgendes Kriterium löschen möchten?";
            // 
            // Criterion_Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.labelCritDeleteCheck);
            this.Controls.Add(this.btn_CritDelete);
            this.Controls.Add(this.btn_CritDelete_Cancle);
            this.Controls.Add(this.label_CritDesc);
            this.Controls.Add(this.label_CritName);
            this.Name = "Criterion_Delete";
            this.Text = "Kriterium löschen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CritName;
        private System.Windows.Forms.Label label_CritDesc;
        private System.Windows.Forms.Button btn_CritDelete_Cancle;
        private System.Windows.Forms.Button btn_CritDelete;
        private System.Windows.Forms.Label labelCritDeleteCheck;
    }
}