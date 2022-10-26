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
    public partial class frmTerminDetalji : Form
    {
        public APIService TerminService { get; set; } = new APIService("Termin");
        public APIService KlijentService { get; set; } = new APIService("Klijent");
        public APIService SpolService { get; set; } = new APIService("Spol");


        private Termin _model = null;

        public frmTerminDetalji(Termin model = null)
        {
            InitializeComponent();
            _model = model;
        }
        //private async Task LoadSpolovi()
        //{
        //    var spoloviList = await SpolService.Get<List<Spol>>();

        //    cmbSpolovi.DataSource = spoloviList;
        //    cmbSpolovi.DisplayMember = "Naziv";
        //    cmbSpolovi.ValueMember = "SpolId";
        //}
        private async Task LoadKlijenti()
        {
            var klijentiList = await KlijentService.Get<List<Klijent>>();

            cmbKlijenti.DataSource = klijentiList;
            cmbKlijenti.DisplayMember = "FullName";
            cmbKlijenti.ValueMember = "KlijentId";
        }

        private async void frmTerminDetalji_Load(object sender, EventArgs e)
        {
            //await LoadSpolovi();
            await LoadKlijenti();

            if (_model != null)
            {
                //txtIme.Text = _model.Klijent.Ime;
                //txtPrezime.Text = _model.Klijent.Prezime;
                dtpDatum.Format = DateTimePickerFormat.Custom;
                dtpDatum.CustomFormat = "HH:mm tt";
                dtpDatum.Value = _model.DatumTermina;
                txtVrsta.Text = _model.VrstaPregleda;

                //cmbSpolovi.SelectedValue = _mod.Value;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (_model == null)
                {
                    //KlijentInsertRequest klijentInsert = new KlijentInsertRequest()
                    //{
                    //    Ime = txtIme.Text,
                    //    Prezime = txtPrezime.Text,
                    //    SpolId = Convert.ToInt32(cmbSpolovi.SelectedValue)
                    //};
                    //var klijent = await KlijentService.Post<Klijent>(klijentInsert);

                    TerminInsertRequest insertRequest = new TerminInsertRequest()
                    {
                        DatumTermina =dtpDatum.Value,//Convert.ToDateTime(txtDatum.Text),
                        VrstaPregleda=txtVrsta.Text,
                        KlijentId=Convert.ToInt32(cmbKlijenti.SelectedValue)//klijent.KlijentId,
                    };
                    var user = await TerminService.Post<Termin>(insertRequest);
                    MessageBox.Show("Successfully added.");
                }
                else
                {
                    var klijentID = Convert.ToInt32(cmbKlijenti.SelectedValue);
                    TerminUpdateRequest updateRequest = new TerminUpdateRequest()
                    {
                        DatumTermina = dtpDatum.Value,//Convert.ToDateTime("txtDatum.Text"),
                        VrstaPregleda = txtVrsta.Text,
                        KlijentId = klijentID,//klijent.KlijentId,
                        //Ime = txtIme.Text,
                        //Prezime = txtPrezime.Text,
                    };

                    _model = await TerminService.Put<Termin>(_model.TerminId, updateRequest);
                    MessageBox.Show("Successfully edited.");

                }
            }
        }
    }
}
