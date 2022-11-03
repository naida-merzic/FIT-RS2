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
        List<Klijent> ReportKlijent;
        KlijentSearchObject ReportKlijentSearchObject;

        public frmKlijenti()
        {
            InitializeComponent();
            dgvKlijenti.AutoGenerateColumns = false;
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            var searchObject = new KlijentSearchObject();
            searchObject.Ime = txtIme.Text;
            searchObject.Prezime = txtPrezime.Text;
            ReportKlijentSearchObject = searchObject;

            var list = await KlijentService.Get<List<Klijent>>(searchObject);
            ReportKlijent=list; 

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

        private void frmKlijenti_Load(object sender, EventArgs e)
        {

        }
    }
}
