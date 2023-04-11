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
    public partial class frmConfigAC : Form
    {
        UserModel userModel = new UserModel();
        bool statusSeleccion;
        int statusBolsa;
        public frmConfigAC()
        {
            InitializeComponent();
        }

        public void MostrarDatos()
        {
            if (cmbSeleccion.Text == "Entradas")
            {
                dataGridView1.DataSource = userModel.MostrarDEntradasAC();
                statusBolsa = 3;
            }
            else if (cmbSeleccion.Text == "Salidas")
            {
                dataGridView1.DataSource = userModel.MostrarDSalidasAC();
                statusBolsa = 4;
            }
        }

        public void SeleccionarMovimiento()
        {

            statusSeleccion = true;
            tboxIdBolsa.Text = dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString();
            tboxFechaRegistro.Text = dataGridView1.CurrentRow.Cells["FechaRegistro"].Value.ToString();
            tboxIdHilo.Text = dataGridView1.CurrentRow.Cells["IdHilo"].Value.ToString();
            tboxLoteHilatura.Text = dataGridView1.CurrentRow.Cells["LoteHilatura"].Value.ToString();
            tboxIdCaja.Text = dataGridView1.CurrentRow.Cells["IdCaja"].Value.ToString();
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
                    userModel.ActualizarStatusBolsa(tboxIdBolsa.Text, Convert.ToString(statusBolsa - 1));
                    userModel.EliminarMovimientoReporteBolsa(tboxIdBolsa.Text, Convert.ToString(statusBolsa));
                    MessageBox.Show("Se realizo correctamente el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos();
                    statusSeleccion = false;
                    LimpiarTbox();
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
            tboxFechaRegistro.Clear();
            tboxIdBolsa.Clear();
            tboxIdCaja.Clear();
            tboxIdHilo.Clear();
            tboxLoteHilatura.Clear();
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
            try
            {
                SeleccionarMovimiento();
            }
            catch
            {

            }
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DeshacerMovimiento();
        }

        private void frmConfigAC_Load(object sender, EventArgs e)
        {

        }
    }
}
