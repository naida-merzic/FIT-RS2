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
    public partial class frmUposlenici : Form
    {
        public APIService UposlenikService { get; set; } = new APIService("Uposlenik");


        public frmUposlenici()
        {
            InitializeComponent();
            dgvUposlenici.AutoGenerateColumns = false;
        }

        private async void frmUposlenici_Load(object sender, EventArgs e)
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
                    dgvUposlenici.Columns[3].Visible = false;
            }
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var searchObject = new UposlenikSearchObject();
            searchObject.Ime = txtIme.Text;
            searchObject.Prezime = txtPrezime.Text;
            searchObject.IncludeRoles = true;

            var list = await UposlenikService.Get<List<Uposlenik>>(searchObject);

            dgvUposlenici.DataSource = list;
        }

        private async void dgvUposlenici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    var _model = dgvUposlenici.SelectedRows[0].DataBoundItem as Uposlenik;
                    var N = await UposlenikService.Delete<Uposlenik>(_model.UposlenikId);
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
                var item = dgvUposlenici.SelectedRows[0].DataBoundItem as Uposlenik;
                frmUposlenikDetalji frm = new frmUposlenikDetalji(item);
                frm.ShowDialog();
            }
        }
    }
}
