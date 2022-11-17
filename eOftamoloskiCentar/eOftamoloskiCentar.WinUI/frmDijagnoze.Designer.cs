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
            this.components = new System.ComponentModel.Container();
            this.dgwDijagnoze = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sadrzaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtSadrzaj = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveDijagnoza = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgwDijagnoze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwDijagnoze
            // 
            this.dgwDijagnoze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDijagnoze.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Sadrzaj});
            this.dgwDijagnoze.Location = new System.Drawing.Point(34, 116);
            this.dgwDijagnoze.Name = "dgwDijagnoze";
            this.dgwDijagnoze.RowHeadersWidth = 51;
            this.dgwDijagnoze.RowTemplate.Height = 29;
            this.dgwDijagnoze.Size = new System.Drawing.Size(736, 322);
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
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(35, 58);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(252, 27);
            this.txtNaziv.TabIndex = 1;
            // 
            // txtSadrzaj
            // 
            this.txtSadrzaj.Location = new System.Drawing.Point(312, 58);
            this.txtSadrzaj.Name = "txtSadrzaj";
            this.txtSadrzaj.Size = new System.Drawing.Size(333, 27);
            this.txtSadrzaj.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dodaj novu dijagnozu";
            // 
            // btnSaveDijagnoza
            // 
            this.btnSaveDijagnoza.Location = new System.Drawing.Point(676, 38);
            this.btnSaveDijagnoza.Name = "btnSaveDijagnoza";
            this.btnSaveDijagnoza.Size = new System.Drawing.Size(94, 58);
            this.btnSaveDijagnoza.TabIndex = 4;
            this.btnSaveDijagnoza.Text = "Dodaj dijagnozu";
            this.btnSaveDijagnoza.UseVisualStyleBackColor = true;
            this.btnSaveDijagnoza.Click += new System.EventHandler(this.btnSaveDijagnoza_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Naziv";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sadržaj";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDijagnoze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveDijagnoza);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSadrzaj);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.dgwDijagnoze);
            this.Name = "frmDijagnoze";
            this.Text = "frmDijagnoze";
            this.Load += new System.EventHandler(this.frmDijagnoze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwDijagnoze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgwDijagnoze;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewTextBoxColumn Sadrzaj;
        private TextBox txtNaziv;
        private TextBox txtSadrzaj;
        private Label label1;
        private Button btnSaveDijagnoza;
        private Label label2;
        private Label label3;
        private ErrorProvider errorProvider1;
    }
}