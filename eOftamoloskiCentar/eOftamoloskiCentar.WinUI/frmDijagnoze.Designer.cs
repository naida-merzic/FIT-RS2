namespace eOftamoloskiCentar.WinUI
{
    partial class frmDijagnoze
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
            this.dgwDijagnoze = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sadrzaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDijagnoze)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwDijagnoze
            // 
            this.dgwDijagnoze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDijagnoze.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Sadrzaj});
            this.dgwDijagnoze.Location = new System.Drawing.Point(21, 55);
            this.dgwDijagnoze.Name = "dgwDijagnoze";
            this.dgwDijagnoze.RowHeadersWidth = 51;
            this.dgwDijagnoze.RowTemplate.Height = 29;
            this.dgwDijagnoze.Size = new System.Drawing.Size(736, 324);
            this.dgwDijagnoze.TabIndex = 0;
            // 
            // Naziv
            // 
            this.Naziv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            // 
            // Sadrzaj
            // 
            this.Sadrzaj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sadrzaj.DataPropertyName = "Sadrzaj";
            this.Sadrzaj.HeaderText = "Sadrzaj";
            this.Sadrzaj.MinimumWidth = 6;
            this.Sadrzaj.Name = "Sadrzaj";
            // 
            // frmDijagnoze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgwDijagnoze);
            this.Name = "frmDijagnoze";
            this.Text = "frmDijagnoze";
            this.Load += new System.EventHandler(this.frmDijagnoze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwDijagnoze)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgwDijagnoze;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewTextBoxColumn Sadrzaj;
    }
}