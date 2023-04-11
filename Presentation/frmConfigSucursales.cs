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
    public partial class frmConfigSucursales : Form
    {
        UserModel userModel = new UserModel();
        bool statusSeleccion;
        int statusBolsa;
        public frmConfigSucursales()
        {
            InitializeComponent();
        }
        public void MostrarDatos()
        {
            if (cmbSeleccion.Text == "Entradas")
            {
                dataGridView1.DataSource = userModel.MostrarBolsas("12");
                statusBolsa = 12;
            }
            else if (cmbSeleccion.Text == "Salidas")
            {
                dataGridView1.DataSource = userModel.MostrarBolsas("13");
                statusBolsa = 13;
            }
        }
        public void SeleccionarMovimiento()
        {

            statusSeleccion = true;
            tboxIdBolsa.Text = dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString();
            tboxIdHilo.Text = dataGridView1.CurrentRow.Cells["IdHilo"].Value.ToString();
            tboxLoteHilatura.Text = dataGridView1.CurrentRow.Cells["LoteTenido"].Value.ToString();
            tboxIdCaja.Text = dataGridView1.CurrentRow.Cells["IdColor"].Value.ToString();
            tboxMalla.Text = dataGridView1.CurrentRow.Cells["Malla"].Value.ToString();
            tboxColorCono.Text = dataGridView1.CurrentRow.Cells["ColorCono"].Value.ToString();
            tboxPesoBruto.Text = dataGridView1.CurrentRow.Cells["PesoBruto"].Value.ToString();
            tboxPesoNeto.Text = dataGridView1.CurrentRow.Cells["PesoNeto"].Value.ToString();
            tboxNumConos.Text = dataGridView1.CurrentRow.Cells["NumConos"].Value.ToString();

        }
        public void DeshacerMovimiento()
        {
            if (statusSeleccion == true)
            {
                try
                {
                    if (cmbSeleccion.Text == "Salidas")
                    {
                        userModel.ActualizarStatusBolsa(tboxIdBolsa.Text, Convert.ToString(statusBolsa - 1));
                        userModel.EliminarMovimientoReporteBolsa(tboxIdBolsa.Text, Convert.ToString(statusBolsa));
                        userModel.EliminarVenta(Convert.ToInt32(tboxIdBolsa.Text));
                        MessageBox.Show("Se realizo correctamente el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarDatos();
                        LimpiarTbox();
                        statusSeleccion = false;
                    }
                    else
                    {
                        userModel.ActualizarStatusBolsa(tboxIdBolsa.Text, Convert.ToString(statusBolsa - 1));
                        userModel.EliminarMovimientoReporteBolsa(tboxIdBolsa.Text, Convert.ToString(statusBolsa));
                        MessageBox.Show("Se realizo correctamente el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarDatos();
                        LimpiarTbox();
                        statusSeleccion = false;
                    }
                        

                }
                catch
                {
                    MessageBox.Show("Favor de comunicarse con soporte técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarTbox();
                    statusSeleccion = false;
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un movimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarTbox();
                statusSeleccion = false;
            }

        }
        public void LimpiarTbox()
        {
            tboxColorCono.Clear();
            tboxIdBolsa.Clear();
            tboxIdCaja.Clear();
            tboxIdHilo.Clear();
            tboxLoteHilatura.Clear();
            tboxMalla.Clear();
            tboxNumConos.Clear();
            tboxPesoBruto.Clear();
            tboxPesoNeto.Clear();
        }

        private void cmbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarMovimiento();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DeshacerMovimiento();
        }
    }
    
}
