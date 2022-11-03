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
    public partial class frmDijagnoze : Form
    {
        public APIService DijagnozaService { get; set; } = new APIService("Dijagnoza");
        List<Dijagnoza> _dijagnoze;
        int _id;

        public frmDijagnoze(int id)
        {
            InitializeComponent();
            dgwDijagnoze.AutoGenerateColumns = false;
            _id = id;
            LoadDijagnoze();
            
        }
        private async Task LoadDijagnoze()
        {
            DijagnozaSearchObject search = new DijagnozaSearchObject()
            {
                KlijentId = _id
            };
            var _dijagnoze = await DijagnozaService.Get<List<Dijagnoza>>(search);

            dgwDijagnoze.DataSource = _dijagnoze;   
        }
        private void frmDijagnoze_Load(object sender, EventArgs e)
        {

        }
    }
}
