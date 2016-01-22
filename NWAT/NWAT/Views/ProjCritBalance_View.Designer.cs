namespace NWAT
{
    partial class ProjCritBalance_View
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
            this.dataGridView_ProjCritBalance = new System.Windows.Forms.DataGridView();
            this.btn_ProjCritBalaCancle = new System.Windows.Forms.Button();
            this.btn_ProjCritBalaSave = new System.Windows.Forms.Button();
            this.btn_SameBalance = new System.Windows.Forms.Button();
            this.Strukture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ProjCritBalance
            // 
            this.dataGridView_ProjCritBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ProjCritBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjCritBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Strukture});
            this.dataGridView_ProjCritBalance.Location = new System.Drawing.Point(0, 20);
            this.dataGridView_ProjCritBalance.Name = "dataGridView_ProjCritBalance";
            this.dataGridView_ProjCritBalance.Size = new System.Drawing.Size(561, 520);
            this.dataGridView_ProjCritBalance.TabIndex = 12;
            this.dataGridView_ProjCritBalance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ProjCritBalance_CellContentClick);
            // 
            // btn_ProjCritBalaCancle
            // 
            this.btn_ProjCritBalaCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritBalaCancle.Location = new System.Drawing.Point(584, 516);
            this.btn_ProjCritBalaCancle.Name = "btn_ProjCritBalaCancle";
            this.btn_ProjCritBalaCancle.Size = new System.Drawing.Size(88, 23);
            this.btn_ProjCritBalaCancle.TabIndex = 14;
            this.btn_ProjCritBalaCancle.Text = "abbrechen";
            this.btn_ProjCritBalaCancle.UseVisualStyleBackColor = true;
            this.btn_ProjCritBalaCancle.Click += new System.EventHandler(this.btn_ProjCritBalaCancle_Click);
            // 
            // btn_ProjCritBalaSave
            // 
            this.btn_ProjCritBalaSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjCritBalaSave.Location = new System.Drawing.Point(584, 487);
            this.btn_ProjCritBalaSave.Name = "btn_ProjCritBalaSave";
            this.btn_ProjCritBalaSave.Size = new System.Drawing.Size(88, 23);
            this.btn_ProjCritBalaSave.TabIndex = 13;
            this.btn_ProjCritBalaSave.Text = "speichern";
            this.btn_ProjCritBalaSave.UseVisualStyleBackColor = true;
            this.btn_ProjCritBalaSave.Click += new System.EventHandler(this.btn_ProjCritBalaSave_Click);
            // 
            // btn_SameBalance
            // 
            this.btn_SameBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SameBalance.Location = new System.Drawing.Point(567, 20);
            this.btn_SameBalance.Name = "btn_SameBalance";
            this.btn_SameBalance.Size = new System.Drawing.Size(105, 23);
            this.btn_SameBalance.TabIndex = 15;
            this.btn_SameBalance.Text = "gleichgewichten";
            this.btn_SameBalance.UseVisualStyleBackColor = true;
            this.btn_SameBalance.Click += new System.EventHandler(this.btn_SameBalance_Click);
            // 
            // Strukture
            // 
            this.Strukture.HeaderText = "Str";
            this.Strukture.Name = "Strukture";
            this.Strukture.Width = 50;
            // 
            // ProjCritBalance_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.btn_SameBalance);
            this.Controls.Add(this.dataGridView_ProjCritBalance);
            this.Controls.Add(this.btn_ProjCritBalaCancle);
            this.Controls.Add(this.btn_ProjCritBalaSave);
            this.Name = "ProjCritBalance_View";
            this.Text = "Gewichtung";
            this.Load += new System.EventHandler(this.ProjCritBalance_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjCritBalance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ProjCritBalance;
        private System.Windows.Forms.Button btn_ProjCritBalaCancle;
        private System.Windows.Forms.Button btn_ProjCritBalaSave;
        private System.Windows.Forms.Button btn_SameBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Strukture;
    }
}