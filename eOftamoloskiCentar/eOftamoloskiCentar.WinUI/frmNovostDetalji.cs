using System;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
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
    public partial class frmNovostDetalji : Form
    {
        public APIService NovostService { get; set; } = new APIService("Novost");
        public APIService UposleniciService { get; set; } = new APIService("Uposlenik");


        private Novost _model = null;

        public frmNovostDetalji(Novost model = null)
        {
            InitializeComponent();
            _model = model;

        }
        private async Task LoadUposlenik()
        {
            var uposleniciList = await UposleniciService.Get<List<Uposlenik>>();

            cmbUposlenici.DataSource = uposleniciList;
            cmbUposlenici.DisplayMember = "FullName";
            cmbUposlenici.ValueMember = "UposlenikId";
        }
        private async void frmNovostDetalji_Load(object sender, EventArgs e)
        {
            await LoadUposlenik();

            if (_model != null)
            {
                txtNaslov.Text = _model.Naslov;
                txtSadrzaj.Text = _model.Sadrzaj;
                cmbUposlenici.SelectedValue = _model.UposlenikId.Value;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (_model == null)
                {
                    NovostUpsertRequest insertRequest = new NovostUpsertRequest()
                    {
                        Naslov = txtNaslov.Text,
                        Sadrzaj = txtSadrzaj.Text,
                        DatumObjave = DateTime.Now, //Convert.ToDateTime(txtDatum.Text),
                        UposlenikId=Convert.ToInt32(cmbUposlenici.SelectedValue)
                    };

                    var user = await NovostService.Post<Novost>(insertRequest);
                    MessageBox.Show("Successfully added.");
                }
                else
                {
                    NovostUpsertRequest updateRequest = new NovostUpsertRequest()
                    {
                        Naslov = txtNaslov.Text,
                        Sadrzaj = txtSadrzaj.Text,
                        DatumObjave = DateTime.Now, //Convert.ToDateTime(txtDatum.Text),
                        UposlenikId = Convert.ToInt32(cmbUposlenici.SelectedValue)
                    };

                    _model = await NovostService.Put<Novost>(_model.NovostId, updateRequest);
                    MessageBox.Show("Successfully updated.");
                }
            }
        }

        private void txtNaslov_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaslov.Text))
            {
                e.Cancel = true;
                txtNaslov.Focus();
                errorProvider1.SetError(txtNaslov, "Naslov should not be left blank!");
            }
            else
            {
                e.Cancel = false;

            }
        }
    }
}
