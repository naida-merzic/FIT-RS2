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
    public partial class frmKlijentDetalji : Form
    {
        public APIService KlijentService { get; set; } = new APIService("Klijent");
        public APIService SpolService { get; set; } = new APIService("Spol");

        private Klijent _model = null;
        public frmKlijentDetalji(Klijent model = null)
        {
            InitializeComponent();
            _model = model;
        }
        private async Task LoadSpolovi()
        {
            var spoloviList = await SpolService.Get<List<Spol>>();

            cmbSpol.DataSource = spoloviList;
            cmbSpol.DisplayMember = "Naziv";
            cmbSpol.ValueMember = "SpolId";
        }

        private async void frmKlijentDetalji_Load(object sender, EventArgs e)
        {
            await LoadSpolovi();

            if (_model != null)
            {
                txtIme.Text = _model.KorisnickiRacun.Ime;
                txtPrezime.Text = _model.KorisnickiRacun.Prezime;
                //cmbSpol.SelectedValue = _model.SpolId.Value;
                //potrebno termin ucitat
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (_model == null)
                {
                    KlijentInsertRequest insertRequest = new KlijentInsertRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        //SpolId = Convert.ToInt32(cmbSpol.SelectedValue),
                        //termine dodati
                        KorisnickoIme = txtUsername.Text,
                        Lozinka = txtPass.Text,
                    };

                    var user = await KlijentService.Post<Klijent>(insertRequest);
                    MessageBox.Show("Successfully added.");
                }
                else
                {
                    KlijentUpdateRequest updateRequest = new KlijentUpdateRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        //SpolId = Convert.ToInt32(cmbSpol.SelectedValue),
                        //termine dodati
                    };

                    _model = await KlijentService.Put<Klijent>(_model.KlijentId, updateRequest);
                    MessageBox.Show("Successfully updated.");
                }
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                e.Cancel = true;
                txtIme.Focus();
                errorProvider1.SetError(txtIme, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;

            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                e.Cancel = true;
                txtPrezime.Focus();
                errorProvider2.SetError(txtPrezime, "Surname should not be left blank!");
            }
            else
            {
                e.Cancel = false;

            }
        }
    }
}
