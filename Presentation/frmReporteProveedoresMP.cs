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
    public partial class frmReporteProveedoresMP : Form
    {
        UserModel userModel = new UserModel();
        public frmReporteProveedoresMP()
        {
            InitializeComponent();
        }

        private void frmReporteProveedoresMP_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
            this.reportViewer1.RefreshReport();
        }
        private void MostrarProveedores()
        {
            cmbProveedores.DataSource = userModel.ver_Proveedores();
            cmbProveedores.DisplayMember = "razonSocial";
            cmbProveedores.ValueMember = "idProveedor";
        }
        private void getReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                Reporte reporte = new Reporte();
                reporte.GetOrderResumenProveedoresMP(Convert.ToInt32(cmbProveedores.SelectedValue), startDate, endDate);
                ReporteBindingSource.DataSource = reporte;
                PruebasLBindingSource.DataSource = reporte.pruebasL;
            }
            catch
            {
                MessageBox.Show("Por favor selecciona un proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void getReportD(DateTime startDate, DateTime endDate)
        {
            try
            {
                ReporteDetails reporteD = new ReporteDetails();
                reporteD.GetOrderDetallesProveedoresMP(Convert.ToInt32(cmbProveedores.SelectedValue), startDate, endDate);
                PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
            }
            catch
            {
                MessageBox.Show("Por favor selecciona un proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
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
