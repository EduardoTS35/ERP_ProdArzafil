using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commun.Cache;
using Domain;

namespace Presentation
{
    public partial class frmSalidaSucursalll : Form
    {
        UserModel userModel = new UserModel();
        string statusProceso;
        string statusProcesoAnterior;

        string IdBolsa;
        string NumPedido;
        string IdHilo;
        string IdColor;
        string IdCaja;
        string PesoBruto;
        string PesoNeto;
        string NumConos;
        int row;
        int Fila = 0;

        double precioTotal=0;
        double precioTotal2 = 0;
        int contadorBolsas=0;
        string Precio;
        public frmSalidaSucursalll()
        {
            InitializeComponent();
        }

        private void frmSalidaSucursalll_Load(object sender, EventArgs e)
        {
            MostrarNuevoNRemision();
            MostrarCliente();
            DefinirProceso();

        }
        public void MostrarCliente()
        {
            cmbCliente.DataSource = userModel.MostrarClienteSucursal();
            cmbCliente.DisplayMember = "RazonSocial";
            cmbCliente.ValueMember = "IdCliente";
        }
        public void DefinirProceso()
        {
            if (UserLoginCache.Area == "Sucursal 1")
            {
                statusProceso = "13";
                statusProcesoAnterior = "12";
            }
            if (UserLoginCache.Area == "Sucursal 2")
            {
                statusProceso = "15";
                statusProcesoAnterior = "14";
            }
        }
        public void MostrarNuevoNRemision()
        {
            try
            {
                cmbNumRemision.DataSource = userModel.MostrarLoteDeVentaSig();
                cmbNumRemision.DisplayMember = "LOTEVENTA";
                if (cmbNumRemision.Text == "")
                    cmbNumRemision.Text = "1";
            }
            catch (Exception)
            {

            }
        }
        public void MostrarDatosBolsa(string ID)
        {
            try
            {
                dataGridView1.DataSource = userModel.MostrarBolsaSucursales(ID, statusProcesoAnterior);
            }
            catch (Exception)
            {

            }
        }
        public void LeerDatos()
        {

            DataGridViewRow row = dataGridView1.Rows[this.row];
            IdBolsa = Convert.ToString(row.Cells["IDBolsa"].Value);
            NumPedido = Convert.ToString(row.Cells["NumPedido"].Value);
            IdHilo = Convert.ToString(row.Cells["IdHilo"].Value);
            IdColor = Convert.ToString(row.Cells["IdColor"].Value);
            IdCaja = Convert.ToString(row.Cells["LoteTenido"].Value);
            PesoBruto = Convert.ToString(row.Cells["PesoBruto"].Value);
            PesoNeto = Convert.ToString(row.Cells["PesoNeto"].Value);
            NumConos = Convert.ToString(row.Cells["NumConos"].Value);
            AppCache.IdBolsa = Convert.ToInt32(IdBolsa);
            Precio = tboxPrecio.Text;

        }

        private void getReport()
        {
            Reporte reporte = new Reporte();
            if (tboxNumRemision.Text != "")
            {
                reporte.GetOrderRSucursal(Convert.ToInt32(tboxNumRemision.Text), 13);
            }
            else
            {
                reporte.GetOrderRSucursal(Convert.ToInt32(cmbNumRemision.Text), 13);
            }

            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD()
        {
            ReporteDetails reporteD = new ReporteDetails();
            if (tboxNumRemision.Text != "")
            {
                reporteD.GetOrderDNumRemisionSucursal(Convert.ToInt32(tboxNumRemision.Text), 13);
            }
            else
            {
                reporteD.GetOrderDNumRemisionSucursal(Convert.ToInt32(cmbNumRemision.Text), 13);
            }
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }

        public void GuardarVenta()
        {
            if (tboxNumRemision.Text != "")
            {
                userModel.InsertarSalidaSucursales(IdBolsa, NumPedido, IdHilo, IdColor, IdCaja, PesoBruto, PesoNeto, NumConos, statusProceso, tboxNumRemision.Text, Convert.ToString(precioTotal2), Convert.ToInt32(cmbCliente.SelectedValue));
            }
            else
                userModel.InsertarSalidaSucursales(IdBolsa, NumPedido, IdHilo, IdColor, IdCaja, PesoBruto, PesoNeto, NumConos, statusProceso, cmbNumRemision.Text, Convert.ToString(precioTotal2), Convert.ToInt32(cmbCliente.SelectedValue));
        }

        private void InsertarLinea()
        {
            try
            {
                dgvVenta.Rows.Add(1);
                
                dgvVenta.Rows[this.Fila].Cells[0].Value = IdBolsa;
                dgvVenta.Rows[this.Fila].Cells[8].Value = NumPedido;
                dgvVenta.Rows[this.Fila].Cells[2].Value = IdHilo;
                dgvVenta.Rows[this.Fila].Cells[3].Value = IdColor;
                dgvVenta.Rows[this.Fila].Cells[6].Value = IdCaja;
                dgvVenta.Rows[this.Fila].Cells[7].Value = PesoBruto;
                dgvVenta.Rows[this.Fila].Cells[4].Value = PesoNeto;
                dgvVenta.Rows[this.Fila].Cells[5].Value = NumConos;
                dgvVenta.Rows[this.Fila].Cells[1].Value = Convert.ToString(Convert.ToDouble(Precio) * Convert.ToDouble(PesoNeto));
                dgvVenta.Rows[this.Fila].Cells[9].Value = Precio;
                precioTotal += Convert.ToDouble(Precio) * Convert.ToDouble(PesoNeto);
                precioTotal2= Convert.ToDouble(Precio) * Convert.ToDouble(PesoNeto);
                contadorBolsas++;
                Fila++;
                label11.Text = Convert.ToString(contadorBolsas);
                label12.Text = "$" + Convert.ToString(precioTotal);
            }
            catch
            {

            }
            
        }

        private void timerCodB_Tick(object sender, EventArgs e)
        {
            try
            {
                MostrarDatosBolsa(tboxCodB.Text);
                LeerDatos();
                if (IdBolsa != "")
                {
                    InsertarLinea();
                    GuardarVenta();
                    tboxCodB.Clear();
                }
                else if (tboxCodB.Text != "" & IdBolsa != "")
                    MessageBox.Show("No se econtró la bolsa seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timerCodB.Stop();
            }
            catch
            {
                tboxCodB.Clear();
                timerCodB.Stop();
                MessageBox.Show("No se econtró la bolsa seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarM_Click(object sender, EventArgs e)
        {
            //Cargar Hoja de Remisión
            getReport();
            getReportD();
            this.reportViewer1.RefreshReport();

            //Borrar Datos y reiniciar variable línea
            Fila = 0;
            precioTotal = 0;
            contadorBolsas = 0;
            label11.Text = Convert.ToString(contadorBolsas);
            label12.Text = "$" + Convert.ToString(precioTotal);
            MostrarNuevoNRemision();
            tboxNumRemision.Clear();

            dgvVenta.Rows.Clear();
            dgvVenta.Refresh();
        }


        private void tboxCodB_TextChanged(object sender, EventArgs e)
        {
            timerCodB.Start();
        }

        private void btnSalidaManual_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarDatosBolsa(tboxEntradaManual.Text);
                LeerDatos();
                if (IdBolsa != "")
                {
                    InsertarLinea();
                    GuardarVenta();
                    tboxEntradaManual.Clear();
                }
                else if (tboxEntradaManual.Text != "" & IdBolsa != "")
                    MessageBox.Show("No se econtró la bolsa seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                tboxEntradaManual.Clear();
                MessageBox.Show("No se econtró la bolsa seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
