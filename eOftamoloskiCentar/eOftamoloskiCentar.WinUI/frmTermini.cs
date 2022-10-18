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

        private void frmTermini_Load(object sender, EventArgs e)
        {

        }
    }
}
