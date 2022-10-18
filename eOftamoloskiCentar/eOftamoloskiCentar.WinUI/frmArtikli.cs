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
        public frmArtikli()
        {
            InitializeComponent();
            dgvArtikli.AutoGenerateColumns = false;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            //var list = await ArtikalService.Get<List<Artikal>>();
            //var entity = await ArtikalService.GetById<Artikal>(3);
            //entity.Naziv = "Updated with product WinUI";
            //var update = await ArtikalService.Put<Artikal>(entity.ArtikalId, entity);

            var searchObject = new ArtikalSearchObject();
            searchObject.Naziv = txtNaziv.Text;

            var list = await ArtikalService.Get<List<Artikal>>(searchObject);

            dgvArtikli.DataSource = list;
        }

        private void dgvArtikli_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvArtikli.SelectedRows[0].DataBoundItem as Artikal;

            frmArtikalDetalji frm = new frmArtikalDetalji(item);
            frm.ShowDialog();
        }

        private void frmArtikli_Load(object sender, EventArgs e)
        {

        }
    }
}
