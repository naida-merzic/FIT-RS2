using eOftamoloskiCentar.Model;
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
    public partial class frmLogin : Form
    {
        private readonly APIService _api = new APIService("Uposlenik");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;

            try
            {
                var result = await _api.Get<List<Uposlenik>>();
                var uposlenik = result.Where(x => x.KorisnickoIme == APIService.Username).FirstOrDefault();

                if (uposlenik == null)
                    throw new Exception();

                mdiMain frm = new mdiMain();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
