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
    public partial class frmReporteInventarioS2 : Form
    {
        int statusProceso = 14;
        public frmReporteInventarioS2()
        {
            InitializeComponent();
        }

        private void frmReporteInventarioS2_Load(object sender, EventArgs e)
        {
            getReport();
            getReportD();
            this.reportViewer1.RefreshReport();
        }
        private void getReport()
        {
            Reporte reporte = new Reporte();
            reporte.GetOrderResumenBolsaInvAF(statusProceso);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD()
        {
            ReporteDetails reporteD = new ReporteDetails();
            reporteD.GetOrderDetallesBolsaInvAF(statusProceso);
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }
    }
}
