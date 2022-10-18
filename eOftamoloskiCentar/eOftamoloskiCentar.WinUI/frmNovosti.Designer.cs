namespace eOftamoloskiCentar.WinUI
{
    partial class frmNovosti
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
            this.dgvNovosti = new System.Windows.Forms.DataGridView();
            this.Naslov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sadrzaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumObjave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Akcija = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lbl = new System.Windows.Forms.Label();
            this.txtNaslov = new System.Windows.Forms.TextBox();
            this.btnTrazi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNovosti)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNovosti
            // 
            this.dgvNovosti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNovosti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naslov,
            this.Sadrzaj,
            this.DatumObjave,
            this.Akcija});
            this.dgvNovosti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNovosti.Location = new System.Drawing.Point(34, 118);
            this.dgvNovosti.Name = "dgvNovosti";
            this.dgvNovosti.RowHeadersWidth = 51;
            this.dgvNovosti.RowTemplate.Height = 29;
            this.dgvNovosti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNovosti.Size = new System.Drawing.Size(634, 246);
            this.dgvNovosti.TabIndex = 0;
            this.dgvNovosti.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNovosti_CellContentClick);
            // 
            // Naslov
            // 
            this.Naslov.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Naslov.DataPropertyName = "Naslov";
            this.Naslov.HeaderText = "Naslov";
            this.Naslov.MinimumWidth = 6;
            this.Naslov.Name = "Naslov";
            // 
            // Sadrzaj
            // 
            this.Sadrzaj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sadrzaj.DataPropertyName = "Sadrzaj";
            this.Sadrzaj.HeaderText = "Sadrzaj";
            this.Sadrzaj.MinimumWidth = 6;
            this.Sadrzaj.Name = "Sadrzaj";
            // 
            // DatumObjave
            // 
            this.DatumObjave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumObjave.DataPropertyName = "DatumObjave";
            this.DatumObjave.HeaderText = "Datum objave";
            this.DatumObjave.MinimumWidth = 6;
            this.DatumObjave.Name = "DatumObjave";
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
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(34, 80);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(54, 20);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Naslov";
            // 
            // txtNaslov
            // 
            this.txtNaslov.Location = new System.Drawing.Point(105, 77);
            this.txtNaslov.Name = "txtNaslov";
            this.txtNaslov.Size = new System.Drawing.Size(434, 27);
            this.txtNaslov.TabIndex = 2;
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(557, 76);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(111, 29);
            this.btnTrazi.TabIndex = 3;
            this.btnTrazi.Text = "Trazi";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // frmNovosti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 450);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.txtNaslov);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgvNovosti);
            this.Name = "frmNovosti";
            this.Text = "frmNovosti";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNovosti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvNovosti;
        private Label lbl;
        private TextBox txtNaslov;
        private Button btnTrazi;
        private DataGridViewTextBoxColumn Naslov;
        private DataGridViewTextBoxColumn Sadrzaj;
        private DataGridViewTextBoxColumn DatumObjave;
        private DataGridViewButtonColumn Akcija;
    }
}