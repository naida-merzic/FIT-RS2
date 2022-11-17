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
    public partial class frmTermini : Form
    {
        public APIService UposlenikService { get; set; } = new APIService("Uposlenik");
        public APIService TerminService { get; set; } = new APIService("Termin");

        public frmTermini()
        {
            InitializeComponent();
            dgvTermini.AutoGenerateColumns = false;
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            var searchObject = new TerminSearchObject();
            searchObject.VrstaPregleda = txtVrsta.Text;
            searchObject.Ime = txtIme.Text;

            var list = await TerminService.Get<List<Termin>>(searchObject);

            dgvTermini.DataSource = list;
        }

        private async void dgvTermini_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    var _model = dgvTermini.SelectedRows[0].DataBoundItem as Termin;
                    var N = await TerminService.Delete<Termin>(_model.TerminId);
                    MessageBox.Show("Successfully deleted.");
                    //this.Hide();
                    //frmNewsSearch frm = new frmNewsSearch();
                    //frm.MdiParent = frmHome.ActiveForm;
                    //frm.Show();
                }
                catch
                {
                    MessageBox.Show("Deleting was not successful.");
                    //this.Hide();
                    //frmNewsSearch frm = new frmNewsSearch();
                    //frm.MdiParent = frmHome.ActiveForm;
                    //frm.Show();
                }
            }
            else
            {
                var item = dgvTermini.SelectedRows[0].DataBoundItem as Termin;

                frmTerminDetalji frm = new frmTerminDetalji(item);
                frm.ShowDialog();
            }
        }

        private async void frmTermini_Load(object sender, EventArgs e)
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
                    dgvTermini.Columns[3].Visible = false;
            }
        }
    }
}
