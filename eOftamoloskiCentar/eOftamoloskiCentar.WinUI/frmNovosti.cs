﻿using eOftamoloskiCentar.Model;
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
    public partial class frmNovosti : Form
    {
        public APIService NovostService { get; set; } = new APIService("Novost");

        public frmNovosti()
        {
            InitializeComponent();
            dgvNovosti.AutoGenerateColumns = false;

        }

        private async void dgvNovosti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    var _model = dgvNovosti.SelectedRows[0].DataBoundItem as Novost;
                    var N = await NovostService.Delete<Novost>(_model.NovostId);
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
                var item = dgvNovosti.SelectedRows[0].DataBoundItem as Novost;

                frmNovostDetalji frm = new frmNovostDetalji(item);
                frm.ShowDialog();
            }
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            var searchObject = new NovostSearchObject();
            searchObject.Naslov = txtNaslov.Text;

            var list = await NovostService.Get<List<Novost>>(searchObject);

            dgvNovosti.DataSource = list;
        }
    }
}