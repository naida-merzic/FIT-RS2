using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.WinUI.Helper;
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
    public partial class frmUposlenikDetalji : Form
    {
        public APIService UposlenikService { get; set; } = new APIService("Uposlenik");
        public APIService KorService { get; set; } = new APIService("KorisnickiRacun");
        public APIService RoleService { get; set; } = new APIService("Rola");
        public APIService SpolService { get; set; } = new APIService("Spol");

        private Uposlenik _model = null;

        public frmUposlenikDetalji(Uposlenik model = null)
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
        private async void frmUposlenikDetalji_Load_1(object sender, EventArgs e)
        {
            await LoadRoles();
            await LoadSpolovi();

            if (_model != null)
            {
                txtIme.Text = _model.Ime;
                txtPrezime.Text = _model.Prezime;
                txtEmail.Text = _model.Email;
                txtUsername.Text = _model.KorisnickoIme;
                chkStatus.Checked = (bool)_model.Status;//GetValueOrDefault(false);

            }
        }
        private async Task LoadRoles()
        {
            var roles = await RoleService.Get<List<Rola>>();
            clbRole.DataSource = roles;
            clbRole.DisplayMember = "Naziv";
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (ErrorCheck())
                {
                    var roleList = clbRole.CheckedItems.Cast<Rola>().ToList();
                    var roleIdList = roleList.Select(x => x.RolaId).ToList();

                    if (_model == null)
                    {
                        KorisnickiRacunInsertRequest insertRequest = new KorisnickiRacunInsertRequest()
                        {
                            Ime = txtIme.Text,
                            Prezime = txtPrezime.Text,
                            Email = txtEmail.Text,
                            KorisnickoIme = txtUsername.Text,
                            Lozinka = txtPassword.Text,
                            LozinkaPotvrda = txtPasswordPotvrda.Text,
                            Status = chkStatus.Checked,
                            RoleList = roleIdList,
                            Adresa = txtAdresa.Text,
                            BrojTelefona = txtBrojTelefona.ToString(),
                            DatumRodjenja = dtpDatumRodjenja.Value,
                            SpolId = 1
                        };
                      

                        var user = await UposlenikService.Post<Uposlenik>(insertRequest);
                        MessageBox.Show("Successfully added.");
                    }
                    else
                    {
                        MessageBox.Show("Role list cannot be changed through edit mode!" +
                            "If you want to change the role list please delete the user and make new one with new roles!" + "Press OK and continue editing...");
                        KorisnickiRacunInsertRequest updateRequest = new KorisnickiRacunInsertRequest()
                        {
                            Ime = txtIme.Text,
                            Prezime = txtPrezime.Text,
                            Email = txtEmail.Text,
                            KorisnickoIme = txtUsername.Text,
                            Lozinka = txtPassword.Text,
                            LozinkaPotvrda = txtPasswordPotvrda.Text,
                            Status = chkStatus.Checked,
                            RoleList = roleIdList,
                            Adresa = txtAdresa.Text,
                            BrojTelefona = txtBrojTelefona.ToString(),
                            DatumRodjenja = dtpDatumRodjenja.Value,
                            SpolId = 1
                        };
                       
                        _model = await UposlenikService.Put<Uposlenik>(_model.UposlenikId, updateRequest);
                        MessageBox.Show("Successfully edited.");

                    }
                }
            }
        }
        private bool ErrorCheck()
        {
            if (!ErrorHandler.RequiredFiled(txtIme, errorProvider1) || !ErrorHandler.RequiredFiled(txtPrezime, errorProvider1)
                    || !ErrorHandler.RequiredFiled(txtAdresa, errorProvider1) || !ErrorHandler.RequiredFiled(txtUsername, errorProvider1)
                    || !ErrorHandler.RequiredFiled(txtPassword, errorProvider1) || !ErrorHandler.RequiredFiled(txtPasswordPotvrda, errorProvider1)
                    || !ErrorHandler.RequiredFiled(txtBrojTelefona, errorProvider1) || !ErrorHandler.RequiredFiled(txtEmail, errorProvider1) 
                    || !ErrorHandler.RequiredFiled(dtpDatumRodjenja, errorProvider1) || !ErrorHandler.RequiredFiled(cmbSpol, errorProvider1)
                    || !ErrorHandler.CheckFormatOfEmail(txtEmail, errorProvider1) || !ErrorHandler.PhoneCheck(txtBrojTelefona, errorProvider1)
                    || !ErrorHandler.checkPass(txtPassword, txtPasswordPotvrda, errorProvider1, "Password and confirmation must be the same")
                    || !ErrorHandler.CheckCLB(clbRole, errorProvider1)
                    )
                return false;
            return true;
        }
        /*
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

        private void txtUsername_Validating_1(object sender, CancelEventArgs e)
        {
            if ((txtUsername.Text).Length < 4)
            {
                e.Cancel = true;
                txtIme.Focus();
                errorProvider2.SetError(txtUsername, "Username should not be smaller than 4 charachter!");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text == "")
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider3.SetError(txtPassword, "Please enter password!");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtPasswordPotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text != txtPasswordPotvrda.Text)
            {
                e.Cancel = true;
                txtPasswordPotvrda.Focus();
                errorProvider4.SetError(txtPasswordPotvrda, "Password confirmation must match Password field");
            }
            else
            {
                e.Cancel = false;
            }
        }*/
    }
}

