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
    public partial class frmConfigProveedores : Form
    {
        UserModel userModel = new UserModel();
        private bool editarProveedor = false;
        public frmConfigProveedores()
        {
            InitializeComponent();
        }
        private void frmConfigProveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
        }

        private void MostrarProveedores()
        {
            dataGridView1.DataSource = userModel.ver_Proveedores();
        }
        private void insertarProveedores(string razonSocial,string contacto)
        {
            try
            {
                userModel.insertar_Proveedores(razonSocial, contacto);
                MessageBox.Show("Se guardó correctamente el nuevo Proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarProveedores();
            }
            catch
            {

            }
        }
        public void actualizar_Proveedores(string razonSocial, string contacto,int idProveedor)
        {
            try
            {
                userModel.actualizar_Proveedores(razonSocial, contacto, idProveedor);
                MessageBox.Show("Se actualizó correctamente el Proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarProveedores();
            }
            catch
            {

            }
        }

        private void LimpiarDatos()
        {
            tboxIdProveedor.Text = "";
            tboxRazonSocial.Text = "";
            tboxContacto.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editarProveedor == false)
            {
                if (tboxRazonSocial.Text != "" && tboxContacto.Text != "")
                {
                    insertarProveedores(tboxRazonSocial.Text, tboxContacto.Text);
                }
                else
                {
                    MessageBox.Show("Por favor completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (editarProveedor==true)
            {
                if (tboxRazonSocial.Text != "" && tboxContacto.Text != "")
                {
                    actualizar_Proveedores(tboxRazonSocial.Text, tboxContacto.Text, Convert.ToInt32(tboxIdProveedor.Text));
                }
                else
                {
                    MessageBox.Show("Por favor completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LimpiarDatos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (editarProveedor == true)
            {
                if (tboxIdProveedor.Text != "")
                {
                    userModel.eliminar_Proveedor(Convert.ToInt32(tboxIdProveedor.Text));
                    MessageBox.Show("Se eliminó correctamente el Proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarProveedores();
                }
                else
                {
                    MessageBox.Show("Por favor completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["razonSocial"].Value.ToString() != "")
            {
                editarProveedor = true;
                tboxIdProveedor.Text = dataGridView1.CurrentRow.Cells["idProveedor"].Value.ToString();
                tboxRazonSocial.Text = dataGridView1.CurrentRow.Cells["razonSocial"].Value.ToString();
                tboxContacto.Text = dataGridView1.CurrentRow.Cells["contacto"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editarProveedor = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            editarProveedor = false;
        }
    }
}
