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
    public partial class frmArtikalDetalji : Form
    {
        public APIService ArtikliService { get; set; } = new APIService("Artikli");
        public APIService VrstaArtikla { get; set; } = new APIService("VrstaArtikla");

        private Artikal _model = null;
        static System.Byte[] file;
        public frmArtikalDetalji(Artikal model = null)
        {
            InitializeComponent();
            _model = model;
        }
        private async Task LoadVrstaArtikla()
        {
            var vrstaArtiklaList = await VrstaArtikla.Get<List<VrstaArtikla>>();

            cmbVrsta.DataSource = vrstaArtiklaList;
            cmbVrsta.DisplayMember = "NazivArtikla";
            cmbVrsta.ValueMember = "VrstaArtiklaId";
        }
        private async void frmArtikalDetalji_Load(object sender, EventArgs e)
        {
            await LoadVrstaArtikla();

            if (_model != null)
            {
                txtNaziv.Text = _model.Naziv;
                txtSifra.Text = _model.Sifra;
                cmbVrsta.SelectedValue = _model.VrstaArtiklaId.Value;
                txtOpis.Text = _model.Opis;
                txtCijena.Text = _model.Cijena.ToString();
                if (_model.Slika != null && _model.Slika.Length > 15)
                {
                    pbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbSlika.Image = Helper.ImageConverterFunction.FromByteToImage(_model.Slika);
                }
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                //var roleList = clbRole.CheckedItems.Cast<Rola>().ToList();
                //var roleIdList = roleList.Select(x => x.RolaId).ToList();

                if (_model == null)
                {
                    if (txtCijena.Text.Contains(','))
                        txtCijena.Text = txtCijena.Text.Replace(',', '.');
                    ArtikalInsertRequest insertRequest = new ArtikalInsertRequest()
                    {
                        Naziv = txtNaziv.Text,
                        VrstaArtiklaId = Convert.ToInt32(cmbVrsta.SelectedValue), 
                        Opis = txtOpis.Text,
                        Sifra = txtSifra.Text,
                        Cijena = Convert.ToDecimal(txtCijena.Text),
                        Slika = file
                    };

                    var user = await ArtikliService.Post<Artikal>(insertRequest);
                    MessageBox.Show("Successfully added.");
                }
                else
                {
                    byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(pbSlika.Image, typeof(byte[]));
                    ArtikalUpdateRequest updateRequest = new ArtikalUpdateRequest()
                    {
                        Naziv = txtNaziv.Text,
                        VrstaArtiklaId = Convert.ToInt32(cmbVrsta.SelectedValue),
                        Opis = txtOpis.Text,
                        Sifra = txtSifra.Text,
                        Cijena = Convert.ToDecimal(txtCijena.Text),
                        Slika = bytes
                    };

                    _model = await ArtikliService.Put<Artikal>(_model.ArtikalId, updateRequest);
                    MessageBox.Show("Successfully updated.");
                }
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                var N = await ArtikliService.Delete<Artikal>(_model.ArtikalId);
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

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if ((txtNaziv.Text) == "")
            {
                e.Cancel = true;
                txtNaziv.Focus();
                errorProvider1.SetError(txtNaziv, "Naziv mora biti unesen!");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtSifra_Validating(object sender, CancelEventArgs e)
        {
            if ((txtSifra.Text) == "")
            {
                e.Cancel = true;
                txtSifra.Focus();
                errorProvider2.SetError(txtSifra, "Sifra mora biti unesena!");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if ((txtCijena.Text) == "")
            {
                e.Cancel = true;
                txtCijena.Focus();
                errorProvider3.SetError(txtCijena, "Cijena mora biti unesena!");
            }
            else
            {
                e.Cancel = false;
            }
        }

        

        private void btnDodajSliku_Click_1(object sender, EventArgs e)
        {   
            var result = coverPhoto.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = coverPhoto.FileName;
                file = File.ReadAllBytes(fileName);

                Image img = Image.FromFile(fileName);
                pbSlika.Image = img;
                pbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
