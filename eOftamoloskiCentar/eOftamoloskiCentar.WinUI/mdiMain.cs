using eOftamoloskiCentar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eOftamoloskiCentar.WinUI
{
    public partial class mdiMain : Form
    {
        private int childFormNumber = 0;
        APIService _KorrRacunService = new APIService("KorisnickiRacun");
        APIService _UposleniciService = new APIService("Uposlenik");
        public mdiMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private async void mdiMain_Load(object sender, EventArgs e)
        {
            //var allusers = await _KorrRacunService.Get<List<KorisnickiRacun>>();
            var alluposlenik = await _UposleniciService.Get<List<Uposlenik>>();
            var uposlenik = alluposlenik.Where(x => x.KorisnickoIme == APIService.Username).FirstOrDefault();

            bool admin = false;
            if (uposlenik != null)
            {
                foreach (var item in uposlenik!.UposlenikRolas)
                {
                    if (item.Rola.Naziv == "Admin")
                    {
                        admin = true;
                        break;
                    }
                }
                if (admin == false)
                    noviUposlenikToolStripMenuItem.Enabled = false;
            }
        }

        private void noviUposlenikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUposlenikDetalji childForm = new frmUposlenikDetalji();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUposlenici childForm = new frmUposlenici();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArtikli childForm = new frmArtikli();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void noviArtikalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArtikalDetalji childForm = new frmArtikalDetalji();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKlijenti childForm = new frmKlijenti();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void noviKlijentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKlijentDetalji childForm = new frmKlijentDetalji();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTermini childForm = new frmTermini();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void noviTerminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTerminDetalji childForm = new frmTerminDetalji();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void listToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmNovosti childForm = new frmNovosti();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void novaNovostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovostDetalji childForm = new frmNovostDetalji();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
    }
}
