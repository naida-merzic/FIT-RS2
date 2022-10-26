using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.SearchObjects;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eOftamoloskiCentar.WinUI.ReportDefinitions
{
    public partial class frmKlijentiRpt : Form
    {
        private List<Klijent> _klijenti;
        private KlijentSearchObject _filters;
        public frmKlijentiRpt(List<Klijent> klijenti, KlijentSearchObject filters)
        {
            InitializeComponent();
            _klijenti = klijenti;
            _filters = filters;
        }

        private void frmKlijentiRpt_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.ReportPath = "C:/Users/User/Desktop/SeminarskiRS2/FIT-RS2/eOftamoloskiCentar/eOftamoloskiCentar.WinUI/ReportDefinitions/KlijentiReport.rdlc";

            string ime = "//";
            string prezime = "//";

            if (_filters != null)
            {
                if (_filters.Ime != null && _filters.Ime != "")
                    ime = _filters.Ime;//.Value.ToString();

                if (_filters.Prezime != null && _filters.Prezime != "")
                    prezime = _filters.Prezime;//.Value.ToString();
            }

            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("Ime", ime));
            rpc.Add(new ReportParameter("Prezime", prezime));

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DBSetKlijenti";

            rds.Value = _klijenti;
            var temp = _klijenti;
            foreach (var item in temp)
            {
                item.Spol.Naziv = item.Spol.Naziv;
            }
            rds.Value = temp;

            this.reportViewer1.ProcessingMode =ProcessingMode.Local;

            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            //C:\Users\User\Desktop\SeminarskiRS2\FIT-RS2\eOftamoloskiCentar\eOftamoloskiCentar.WinUI\ReportDefinitions\KlijentiReport.rdlc
        }
    }
}
