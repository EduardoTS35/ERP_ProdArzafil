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
    public partial class frmReporteNumeroRemisionS : Form
    {
        int statusProceso = 13;
        public frmReporteNumeroRemisionS()
        {
            InitializeComponent();
        }

        private void frmReporteNumeroRemisionS_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        private void getReport()
        {
            Reporte reporte = new Reporte();
            reporte.GetOrderRSucursal(Convert.ToInt32(tboxNumLote.Text), statusProceso);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD()
        {
            ReporteDetails reporteD = new ReporteDetails();
            reporteD.GetOrderDNumRemisionSucursal(Convert.ToInt32(tboxNumLote.Text), statusProceso);
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }

        private void btnGuardarEM_Click(object sender, EventArgs e)
        {
            try
            {
                if (tboxNumLote.Text != "")
                {
                    getReport();
                    getReportD();
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Por favor introduce un número de remisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Por favor introduce un número de remisión correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
