using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.SearchObjects;
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
    public partial class frmArtikli : Form
    {
        public APIService ArtikalService { get; set; } = new APIService("Artikli");
        protected List<Artikal> tempList = new List<Artikal>();

        public frmArtikli()
        {
            InitializeComponent();
            dgvArtikli.AutoGenerateColumns = false;
            loadDgvData();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            loadDgvData();
        }
        private async void loadDgvData()
        {
            var searchObject = new ArtikalSearchObject();
            searchObject.Naziv = txtNaziv.Text;

            tempList = await ArtikalService.Get<List<Artikal>>(searchObject);

            dgvArtikli.DataSource = tempList;
        }

        private void dgvArtikli_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvArtikli.SelectedRows[0].DataBoundItem as Artikal;

            frmArtikalDetalji frm = new frmArtikalDetalji(item);
            frm.ShowDialog();
            loadDgvData();

        }

        private void frmArtikli_Load(object sender, EventArgs e)
        {

        }
    }
}
