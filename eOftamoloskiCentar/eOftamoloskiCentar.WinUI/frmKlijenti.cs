using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.WinUI.ReportDefinitions;
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
    public partial class frmKlijenti : Form
    {
        public APIService KlijentService { get; set; } = new APIService("Klijent");
        public APIService UposlenikService { get; set; } = new APIService("Uposlenik");

        List<Klijent> ReportKlijent;
        KlijentSearchObject ReportKlijentSearchObject;

        public frmKlijenti()
        {
            InitializeComponent();
            dgvKlijenti.AutoGenerateColumns = false;
            loadDgvData();

        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            loadDgvData();
        }
        private async void loadDgvData()
        {
            var searchObject = new KlijentSearchObject();
            searchObject.Ime = txtIme.Text;
            searchObject.Prezime = txtPrezime.Text;
            ReportKlijentSearchObject = searchObject;

            var list = await KlijentService.Get<List<Klijent>>(searchObject);
            ReportKlijent = list;

            dgvKlijenti.DataSource = list;
        }

        private async void dgvKlijenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    try
                    {
                        var _model = dgvKlijenti.SelectedRows[0].DataBoundItem as Klijent;
                        var N = await KlijentService.Delete<Klijent>(_model.KlijentId);
                        MessageBox.Show("Successfully deleted.");
                        loadDgvData();

                    }
                    catch
                    {
                        MessageBox.Show("Deleting was not successful.");
                    }
                }
                else
                {
                    var _model = dgvKlijenti.SelectedRows[0].DataBoundItem as Klijent;

                    frmDijagnoze frm = new frmDijagnoze(_model.KlijentId);
                    frm.ShowDialog();
                }
            }
            else
            {
                var item = dgvKlijenti.SelectedRows[0].DataBoundItem as Klijent;

                frmKlijentDetalji frm = new frmKlijentDetalji(item);
                frm.ShowDialog();
            }
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            frmKlijentiRpt frm = new frmKlijentiRpt(ReportKlijent, ReportKlijentSearchObject);
            frm.Show();
        }

        private async void frmKlijenti_Load(object sender, EventArgs e)
        {
            var alluposlenik = await UposlenikService.Get<List<Uposlenik>>();
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
                    dgvKlijenti.Columns[3].Visible = false;
            }
        }
    }
}
