using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;


namespace Presentation
{
    public partial class frmReporteEntradaAC : Form
    {
        int statusProceso = 3;
        public frmReporteEntradaAC()
        {
            InitializeComponent();
        }

        private void frmReporteEntradaAC_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void getReport(DateTime startDate, DateTime endDate)
        {
            Reporte reporte = new Reporte();
            reporte.GetOrderResumenBolsa(startDate, endDate,statusProceso);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD(DateTime startDate, DateTime endDate)
        {
            ReporteDetails reporteD = new ReporteDetails();
            reporteD.GetOrderDetallesBolsa(startDate, endDate,statusProceso);
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today;
            var toDate = DateTime.Today.AddDays(1);

            getReport(fromDate, toDate);
            getReportD(fromDate, toDate);
            this.reportViewer1.RefreshReport();
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = DateTime.Today.AddDays(1);

            getReport(fromDate, toDate);
            getReportD(fromDate, toDate);
            this.reportViewer1.RefreshReport();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            var fromDate = dtPFromDate.Value.ToShortDateString();
            var toDate = dtPToDate.Value.AddDays(1);

            getReport(Convert.ToDateTime(fromDate), new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 0));
            getReportD(Convert.ToDateTime(fromDate), new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 0));
            this.reportViewer1.RefreshReport();
        }
    }
}
