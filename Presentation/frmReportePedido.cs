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
    public partial class frmReportePedido : Form
    {
        public frmReportePedido()
        {
            InitializeComponent();
        }

        private void frmReportePedido_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void getReport(DateTime startDate, DateTime endDate)
        {
            Reporte reporte = new Reporte();
            reporte.GenerarOrdenRPF(startDate, endDate);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD(DateTime startDate, DateTime endDate)
        {
            ReporteDetails reporteD = new ReporteDetails();
                reporteD.GenerarOrdenReporteD(startDate, endDate);
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }

        private void getReportRID(int ID)
        {
            Reporte reporte = new Reporte();
            reporte.GenerarOrdenRPID(ID);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }

        private void getReportDID(int ID)
        {
            ReporteDetails reporte = new ReporteDetails();
            reporte.GenerarOrdenReporteDID(ID);
            PruebasLDeBindingSource.DataSource = reporte.pruebasLDe;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today;
            var toDate = DateTime.Today.AddDays(40);

            getReport(fromDate, toDate);
            getReportD(fromDate, toDate);
            this.reportViewer1.RefreshReport();
        }

        private void btnSemana_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-60);
            var toDate = DateTime.Today;

            getReport(fromDate, toDate);
            getReportD(fromDate, toDate);
            this.reportViewer1.RefreshReport();
        }

        private void btnPersonalizado_Click(object sender, EventArgs e)
        {
            if (tboxNumPedido.Text == "")
            {
                MessageBox.Show("Por favor introduce el número de orden","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int ID = Convert.ToInt32(tboxNumPedido.Text);
                    getReportRID(ID);
                    getReportDID(ID);
                    this.reportViewer1.RefreshReport();
                }
                catch
                {
                    MessageBox.Show("Error, Intentelo nuevamente");
                }
                
            }
            

        }

        private void tboxNumPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
