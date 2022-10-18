namespace eOftamoloskiCentar.WinUI
{
    partial class frmNovostDetalji
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNaslov = new System.Windows.Forms.TextBox();
            this.txtSadrzaj = new System.Windows.Forms.TextBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.cmbUposlenici = new System.Windows.Forms.ComboBox();
            this.Uposlenik = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naslov";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sadrzaj";
            // 
            // txtNaslov
            // 
            this.txtNaslov.Location = new System.Drawing.Point(44, 45);
            this.txtNaslov.Name = "txtNaslov";
            this.txtNaslov.Size = new System.Drawing.Size(243, 27);
            this.txtNaslov.TabIndex = 3;
            this.txtNaslov.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaslov_Validating);
            // 
            // txtSadrzaj
            // 
            this.txtSadrzaj.Location = new System.Drawing.Point(44, 161);
            this.txtSadrzaj.Name = "txtSadrzaj";
            this.txtSadrzaj.Size = new System.Drawing.Size(243, 27);
            this.txtSadrzaj.TabIndex = 4;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(44, 215);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(243, 29);
            this.btnSacuvaj.TabIndex = 6;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // cmbUposlenici
            // 
            this.cmbUposlenici.FormattingEnabled = true;
            this.cmbUposlenici.Location = new System.Drawing.Point(44, 107);
            this.cmbUposlenici.Name = "cmbUposlenici";
            this.cmbUposlenici.Size = new System.Drawing.Size(243, 28);
            this.cmbUposlenici.TabIndex = 7;
            // 
            // Uposlenik
            // 
            this.Uposlenik.AutoSize = true;
            this.Uposlenik.Location = new System.Drawing.Point(119, 84);
            this.Uposlenik.Name = "Uposlenik";
            this.Uposlenik.Size = new System.Drawing.Size(74, 20);
            this.Uposlenik.TabIndex = 8;
            this.Uposlenik.Text = "Uposlenik";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmNovostDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 354);
            this.Controls.Add(this.Uposlenik);
            this.Controls.Add(this.cmbUposlenici);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.txtSadrzaj);
            this.Controls.Add(this.txtNaslov);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmNovostDetalji";
            this.Text = "frmNovostDetalji";
            this.Load += new System.EventHandler(this.frmNovostDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNaslov;
        private TextBox txtSadrzaj;
        private Button btnSacuvaj;
        private ComboBox cmbUposlenici;
        private Label Uposlenik;
        private ErrorProvider errorProvider1;
    }
}