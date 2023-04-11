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
using Commun.Cache;

namespace Presentation
{
    public partial class frmReporteProdMP : Form
    {
        int IdProd=0;
        public frmReporteProdMP()
        {
            InitializeComponent();
        }

        private void frmReporteProdMP_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void getReport( int idProd, DateTime startDate, DateTime endDate)
        {
            Reporte reporte = new Reporte();
            reporte.GetOrderResumenProdMP(idProd,startDate,endDate);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD(int idProd, DateTime startDate, DateTime endDate)
        {
            ReporteDetails reporteD = new ReporteDetails();
            reporteD.GetOrderDetallesProdMP(idProd,startDate,endDate);
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }
            

        private void button1_Click(object sender, EventArgs e)
        {
            frmCatalogoMP frmCatalogoMP = new frmCatalogoMP();
            frmCatalogoMP.Show();
            timerCatalogo.Start();
        }

        private void timerCatalogo_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualDescMP != null)
                {
                    button1.Enabled = true;
                    lblDesc.Text = AppCache.ActualDescMP;
                    AppCache.ActualDescMP = null;
                    IdProd = Convert.ToInt32(AppCache.ActualIdMP);
                    timerCatalogo.Stop();
                }
                else
                    button1.Enabled = false;
            }
            catch
            {
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            if (IdProd != 0)
            {
                var fromDate = DateTime.Today;
                var toDate = DateTime.Today.AddDays(1);

                getReport(IdProd, fromDate, toDate);
                getReportD(IdProd, fromDate, toDate);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Por favor selecciona un Producto","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            if (IdProd != 0)
            {
                var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var toDate = DateTime.Today.AddDays(1);

                getReport(IdProd, fromDate, toDate);
                getReportD(IdProd, fromDate, toDate);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Por favor selecciona un Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (IdProd != 0)
            {
                var fromDate = dtPFromDate.Value.ToShortDateString();
                var toDate = dtPToDate.Value.AddDays(1);

                getReport(IdProd, Convert.ToDateTime(fromDate), new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 0));
                getReportD(IdProd, Convert.ToDateTime(fromDate), new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 0));
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Por favor selecciona un Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
