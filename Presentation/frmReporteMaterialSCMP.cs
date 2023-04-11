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
    public partial class frmReporteMaterialSCMP : Form
    {
        public frmReporteMaterialSCMP()
        {
            InitializeComponent();
        }

        private void frmReporteMaterialSCMP_Load(object sender, EventArgs e)
        {
            getReport();
            getReportD();
            this.reportViewer1.RefreshReport();
        }
        private void getReport()
        {
            Reporte reporte = new Reporte();
            reporte.GetOrderResumenMaterialSinConfirmarMP();
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD()
        {
            ReporteDetails reporteD = new ReporteDetails();
            reporteD.GetOrderDetallesMaterialSinConfirmarMP();
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }
    }
}
