namespace eOftamoloskiCentar.WinUI
{
    partial class frmKlijenti
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.btnIzvjestaj = new System.Windows.Forms.Button();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Akcija = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Dijagnoze = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prezime";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(140, 49);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(426, 27);
            this.txtIme.TabIndex = 2;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(140, 91);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(426, 27);
            this.txtPrezime.TabIndex = 3;
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(607, 89);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(162, 29);
            this.btnTrazi.TabIndex = 4;
            this.btnTrazi.Text = "Trazi";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlijenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime,
            this.Prezime,
            this.Naziv,
            this.Akcija,
            this.Dijagnoze});
            this.dgvKlijenti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKlijenti.Location = new System.Drawing.Point(43, 146);
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.RowHeadersWidth = 51;
            this.dgvKlijenti.RowTemplate.Height = 29;
            this.dgvKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlijenti.Size = new System.Drawing.Size(726, 241);
            this.dgvKlijenti.TabIndex = 5;
            this.dgvKlijenti.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKlijenti_CellContentClick);
            // 
            // btnIzvjestaj
            // 
            this.btnIzvjestaj.Location = new System.Drawing.Point(607, 393);
            this.btnIzvjestaj.Name = "btnIzvjestaj";
            this.btnIzvjestaj.Size = new System.Drawing.Size(162, 29);
            this.btnIzvjestaj.TabIndex = 6;
            this.btnIzvjestaj.Text = "Kreiraj izvjestaj";
            this.btnIzvjestaj.UseVisualStyleBackColor = true;
            this.btnIzvjestaj.Click += new System.EventHandler(this.btnIzvjestaj_Click);
            // 
            // Ime
            // 
            this.Ime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.MinimumWidth = 6;
            this.Ime.Name = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.MinimumWidth = 6;
            this.Prezime.Name = "Prezime";
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Spol";
            this.Naziv.HeaderText = "Spol klijenta";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.Width = 125;
            // 
            // Akcija
            // 
            this.Akcija.HeaderText = "Akcija";
            this.Akcija.MinimumWidth = 6;
            this.Akcija.Name = "Akcija";
            this.Akcija.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Akcija.Text = "Brisi";
            this.Akcija.UseColumnTextForButtonValue = true;
            this.Akcija.Width = 125;
            // 
            // Dijagnoze
            // 
            this.Dijagnoze.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Dijagnoze.HeaderText = "Dijagnoze";
            this.Dijagnoze.MinimumWidth = 6;
            this.Dijagnoze.Name = "Dijagnoze";
            this.Dijagnoze.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Dijagnoze.Text = "Dijagnoze";
            this.Dijagnoze.UseColumnTextForButtonValue = true;
            // 
            // frmKlijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIzvjestaj);
            this.Controls.Add(this.dgvKlijenti);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmKlijenti";
            this.Text = "frmKlijenti";
            this.Load += new System.EventHandler(this.frmKlijenti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private Button btnTrazi;
        private DataGridView dgvKlijenti;
        private Button btnIzvjestaj;
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn Prezime;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewButtonColumn Akcija;
        private DataGridViewButtonColumn Dijagnoze;
    }
}