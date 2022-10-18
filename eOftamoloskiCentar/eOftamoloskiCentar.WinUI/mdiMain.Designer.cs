namespace eOftamoloskiCentar.WinUI
{
    partial class mdiMain
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uposleniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviUposlenikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artikliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviArtikalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klijentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKlijentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noviTerminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.novaNovostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 671);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(843, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uposleniciToolStripMenuItem,
            this.artikliToolStripMenuItem,
            this.klijentiToolStripMenuItem,
            this.terminiToolStripMenuItem,
            this.novostiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(843, 30);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "MenuStrip";
            // 
            // uposleniciToolStripMenuItem
            // 
            this.uposleniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem,
            this.noviUposlenikToolStripMenuItem});
            this.uposleniciToolStripMenuItem.Name = "uposleniciToolStripMenuItem";
            this.uposleniciToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.uposleniciToolStripMenuItem.Text = "Uposlenici";
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.pretragaToolStripMenuItem_Click);
            // 
            // noviUposlenikToolStripMenuItem
            // 
            this.noviUposlenikToolStripMenuItem.Name = "noviUposlenikToolStripMenuItem";
            this.noviUposlenikToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.noviUposlenikToolStripMenuItem.Text = "Novi uposlenik";
            this.noviUposlenikToolStripMenuItem.Click += new System.EventHandler(this.noviUposlenikToolStripMenuItem_Click);
            // 
            // artikliToolStripMenuItem
            // 
            this.artikliToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem,
            this.noviArtikalToolStripMenuItem});
            this.artikliToolStripMenuItem.Name = "artikliToolStripMenuItem";
            this.artikliToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.artikliToolStripMenuItem.Text = "Artikli";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // noviArtikalToolStripMenuItem
            // 
            this.noviArtikalToolStripMenuItem.Name = "noviArtikalToolStripMenuItem";
            this.noviArtikalToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.noviArtikalToolStripMenuItem.Text = "Novi artikal";
            this.noviArtikalToolStripMenuItem.Click += new System.EventHandler(this.noviArtikalToolStripMenuItem_Click);
            // 
            // klijentiToolStripMenuItem
            // 
            this.klijentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem1,
            this.noviKlijentToolStripMenuItem});
            this.klijentiToolStripMenuItem.Name = "klijentiToolStripMenuItem";
            this.klijentiToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.klijentiToolStripMenuItem.Text = "Klijenti";
            // 
            // pretragaToolStripMenuItem1
            // 
            this.pretragaToolStripMenuItem1.Name = "pretragaToolStripMenuItem1";
            this.pretragaToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.pretragaToolStripMenuItem1.Text = "Pretraga";
            this.pretragaToolStripMenuItem1.Click += new System.EventHandler(this.pretragaToolStripMenuItem1_Click);
            // 
            // noviKlijentToolStripMenuItem
            // 
            this.noviKlijentToolStripMenuItem.Name = "noviKlijentToolStripMenuItem";
            this.noviKlijentToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.noviKlijentToolStripMenuItem.Text = "Novi klijent";
            this.noviKlijentToolStripMenuItem.Click += new System.EventHandler(this.noviKlijentToolStripMenuItem_Click);
            // 
            // terminiToolStripMenuItem
            // 
            this.terminiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem1,
            this.noviTerminToolStripMenuItem});
            this.terminiToolStripMenuItem.Name = "terminiToolStripMenuItem";
            this.terminiToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.terminiToolStripMenuItem.Text = "Termini";
            // 
            // listToolStripMenuItem1
            // 
            this.listToolStripMenuItem1.Name = "listToolStripMenuItem1";
            this.listToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.listToolStripMenuItem1.Text = "List";
            this.listToolStripMenuItem1.Click += new System.EventHandler(this.listToolStripMenuItem1_Click);
            // 
            // noviTerminToolStripMenuItem
            // 
            this.noviTerminToolStripMenuItem.Name = "noviTerminToolStripMenuItem";
            this.noviTerminToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.noviTerminToolStripMenuItem.Text = "Novi termin";
            this.noviTerminToolStripMenuItem.Click += new System.EventHandler(this.noviTerminToolStripMenuItem_Click);
            // 
            // novostiToolStripMenuItem
            // 
            this.novostiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem2,
            this.novaNovostToolStripMenuItem});
            this.novostiToolStripMenuItem.Name = "novostiToolStripMenuItem";
            this.novostiToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.novostiToolStripMenuItem.Text = "Novosti";
            // 
            // listToolStripMenuItem2
            // 
            this.listToolStripMenuItem2.Name = "listToolStripMenuItem2";
            this.listToolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.listToolStripMenuItem2.Text = "List";
            this.listToolStripMenuItem2.Click += new System.EventHandler(this.listToolStripMenuItem2_Click);
            // 
            // novaNovostToolStripMenuItem
            // 
            this.novaNovostToolStripMenuItem.Name = "novaNovostToolStripMenuItem";
            this.novaNovostToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.novaNovostToolStripMenuItem.Text = "Nova novost";
            this.novaNovostToolStripMenuItem.Click += new System.EventHandler(this.novaNovostToolStripMenuItem_Click);
            // 
            // mdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 697);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "mdiMain";
            this.Text = "mdiMain";
            this.Load += new System.EventHandler(this.mdiMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem uposleniciToolStripMenuItem;
        private ToolStripMenuItem pretragaToolStripMenuItem;
        private ToolStripMenuItem noviUposlenikToolStripMenuItem;
        private ToolStripMenuItem artikliToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem;
        private ToolStripMenuItem noviArtikalToolStripMenuItem;
        private ToolStripMenuItem klijentiToolStripMenuItem;
        private ToolStripMenuItem pretragaToolStripMenuItem1;
        private ToolStripMenuItem noviKlijentToolStripMenuItem;
        private ToolStripMenuItem terminiToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem1;
        private ToolStripMenuItem noviTerminToolStripMenuItem;
        private ToolStripMenuItem novostiToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem2;
        private ToolStripMenuItem novaNovostToolStripMenuItem;
    }
}



