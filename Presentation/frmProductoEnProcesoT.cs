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
    
    public partial class frmProductoEnProcesoT : Form
    {
        int statusProceso = 6;
        public frmProductoEnProcesoT()
        {
            
            InitializeComponent();
        }

        private void frmProductoEnProcesoT_Load(object sender, EventArgs e)
        {
            getReport();
            getReportD();
            this.reportViewer1.RefreshReport();
        }

        private void getReport()
        {
            Reporte reporte = new Reporte();
            reporte.GetOrderResumenBolsaInvT(statusProceso);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD()
        {
            ReporteDetails reporteD = new ReporteDetails();
            reporteD.GetOrderDetallesBolsaInvT(statusProceso);
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }
    }
}
