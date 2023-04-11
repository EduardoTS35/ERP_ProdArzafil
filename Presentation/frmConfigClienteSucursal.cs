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
    public partial class frmConfigClienteSucursal : Form
    {
        UserModel userModel = new UserModel();
        private string IdCliente = null;
        private bool editarCliente = false;
        int idCliente;

        public frmConfigClienteSucursal()
        {
            InitializeComponent();
            MostrarClientes();
        }
        private void MostrarClientes()
        {
            dataGridView1.DataSource = userModel.MostrarClienteSucursal();
        }
        private void LimpiarDatos()
        {
            tboxRazonSocial.Text = "";
            tboxNumero.Text = "";
            tboxPlaza.Text = "";
            tboxCalle.Text = "";
            tboxCiudad.Text = "";
            tboxEdo.Text = "";
        }
        private void InsertarCliente()
        {
            try
            {
                userModel.InsertarClienteSucursal(tboxRazonSocial.Text,Convert.ToInt64(tboxNumero.Text),Convert.ToInt32(tboxPlaza.Text),tboxCalle.Text,tboxEdo.Text,tboxCiudad.Text);
                editarCliente = false;
            }
            catch
            {

            }
        }
        private void EditarCliente()
        {
            try
            {
                userModel.EditarClienteSucursal(tboxRazonSocial.Text, Convert.ToInt64(tboxNumero.Text), Convert.ToInt32(tboxPlaza.Text), tboxCalle.Text, tboxEdo.Text, tboxCiudad.Text, Convert.ToInt32(IdCliente));
                editarCliente = false;
            }
            catch
            {

            }
        }
        private void EliminarCliente()
        {
            try
            {
                userModel.EliminarClienteSucursal(Convert.ToInt32(IdCliente));
                editarCliente = false;
            }
            catch
            {

            }
        }
        private void SeleccionarCliente()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editarCliente = true;
                IdCliente = dataGridView1.CurrentRow.Cells["IdCliente"].Value.ToString();
                tboxRazonSocial.Text = dataGridView1.CurrentRow.Cells["RazonSocial"].Value.ToString();
                tboxNumero.Text = dataGridView1.CurrentRow.Cells["Numero"].Value.ToString();
                tboxPlaza.Text = dataGridView1.CurrentRow.Cells["Plaza"].Value.ToString();
                tboxCalle.Text = dataGridView1.CurrentRow.Cells["Calle"].Value.ToString();
                tboxEdo.Text = dataGridView1.CurrentRow.Cells["Edo"].Value.ToString();
                tboxCiudad.Text = dataGridView1.CurrentRow.Cells["Ciudad"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarCliente();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editarCliente == true)
            {
                try
                {
                    EditarCliente();
                    MessageBox.Show("Se realizó correctamente el cambio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("El cambio no se realizó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (editarCliente==false)
            {
                try
                {
                    InsertarCliente();
                    MessageBox.Show("Se realizó correctamente el registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("El registro no se realizó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LimpiarDatos();
            MostrarClientes();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (editarCliente == true)
            {
                try
                {
                    EliminarCliente();
                }
                catch
                {
                    MessageBox.Show("El registro no se realizó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimpiarDatos();
            MostrarClientes();
        }
    }
}
