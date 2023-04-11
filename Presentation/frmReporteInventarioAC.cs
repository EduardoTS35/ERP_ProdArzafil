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
    public partial class frmReporteInventarioAC : Form
    {
        int statusProceso = 3;
        public frmReporteInventarioAC()
        {
            InitializeComponent();
        }

        private void frmReporteInventarioAC_Load(object sender, EventArgs e)
        {
            getReport();
            getReportD();
            this.reportViewer1.RefreshReport();
        }
        private void getReport()
        {
            Reporte reporte = new Reporte();
            reporte.GetOrderResumenBolsaInv(statusProceso);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD()
        {
            ReporteDetails reporteD = new ReporteDetails();
            reporteD.GetOrderDetallesBolsaInv(statusProceso);
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }
    }
}
