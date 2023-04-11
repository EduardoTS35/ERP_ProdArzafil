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
    public partial class frmConfigClientes : Form
    {
        UserModel userModel = new UserModel();
        private string IdCliente = null;
        private bool editarCliente = false;
        public frmConfigClientes()
        {
            InitializeComponent();
        }

        private void frmConfigClientes_Load(object sender, EventArgs e)
        {
            MostrarClientes();
            CargarCmbCajas();
        }

        private void MostrarClientes()
        {
            dataGridView1.DataSource = userModel.MostrarCatalogoClientes();
        }

        private void CargarCmbCajas()
        {
            cmbCaja.DataSource = userModel.MostrarCatalogoCajas();
            cmbCaja.DisplayMember = userModel.MostrarCatalogoCajas().Columns[0].ColumnName;
        }

        private void LimpiarDatos()
        {
            tboxRazonSocial.Text = "";
            tboxCalle.Text = "";
            tboxCiudad.Text = "";
            tboxEdo.Text = "";
            tboxRFC.Text = "";
            cmbCaja.Text = "";
            tboxNumero.Text = "";
            tboxPlaza.Text = "";
            tboxContacto.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var validrSocial = userModel.ValidarRazonSocial(tboxRazonSocial.Text);
            var validRFC = userModel.ValidarRFC(tboxRFC.Text);
            if (editarCliente == false)
            {
                if (tboxRazonSocial.Text != "" & tboxCalle.Text != "" & tboxCiudad.Text != "" & tboxEdo.Text != "" & tboxRFC.Text != "" & cmbCaja.Text != "" & tboxNumero.Text != "" & tboxPlaza.Text != "" & tboxContacto.Text != "")
                {

                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estas seguro de guardar los datos?", "Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (validrSocial == true)
                            {
                                MessageBox.Show("Este cliente ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (validRFC == true)
                            {
                                MessageBox.Show("El RFC del cliente ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if(validrSocial == false & validRFC == false)
                            {
                                userModel.InsertarClientes(tboxRazonSocial.Text, tboxCalle.Text, tboxCiudad.Text, tboxEdo.Text, tboxRFC.Text, tboxNumero.Text, cmbCaja.Text, tboxPlaza.Text, tboxContacto.Text);
                                MostrarClientes();
                                MessageBox.Show("Se guardo correctamente el nuevo cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarDatos();
                            }
                            
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Ha surgido un error: "+ ex+"","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                    }

                else
                {
                    MessageBox.Show("Por favor completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            }
            if (editarCliente == true)
            {
                if (tboxRazonSocial.Text != "" & tboxCalle.Text != "" & tboxCiudad.Text != "" & tboxEdo.Text != "" & tboxRFC.Text != "" & cmbCaja.Text != "" & tboxNumero.Text != "" & tboxPlaza.Text != "" & tboxContacto.Text != "")

                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estas seguro de editar los datos?", "Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            userModel.EditarClientes(tboxRazonSocial.Text, tboxCalle.Text, tboxCiudad.Text, tboxEdo.Text, tboxRFC.Text, tboxNumero.Text,cmbCaja.Text, tboxPlaza.Text, tboxContacto.Text, IdCliente);
                            editarCliente = false;
                            IdCliente = null;
                            LimpiarDatos();
                            MostrarClientes();
                            MessageBox.Show("Se actualizo correctamente el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Surgio un error: " + ex + "", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (editarCliente == true)
            {
                userModel.BorrarClientes(IdCliente);
                editarCliente = false;
                IdCliente = null;
                LimpiarDatos();
                MostrarClientes();
                MessageBox.Show("Se eliminó exitosamente el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un cliente", "Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void tboxCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
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

        private void tboxEdo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
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

        private void tboxRFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsUpper(e.KeyChar))
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
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tboxNumero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxPlaza_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editarCliente = true;
                IdCliente = dataGridView1.CurrentRow.Cells["IDCliente"].Value.ToString();
                tboxRazonSocial.Text = dataGridView1.CurrentRow.Cells["RazonSocial"].Value.ToString();
                tboxCalle.Text = dataGridView1.CurrentRow.Cells["Calle"].Value.ToString();
                tboxCiudad.Text = dataGridView1.CurrentRow.Cells["Ciudad"].Value.ToString();
                tboxEdo.Text = dataGridView1.CurrentRow.Cells["Edo"].Value.ToString();
                tboxRFC.Text = dataGridView1.CurrentRow.Cells["RFC"].Value.ToString();
                tboxNumero.Text = dataGridView1.CurrentRow.Cells["Numero"].Value.ToString();
                cmbCaja.Text = dataGridView1.CurrentRow.Cells["Caja"].Value.ToString();
                tboxPlaza.Text = dataGridView1.CurrentRow.Cells["Plaza"].Value.ToString();
                tboxContacto.Text = dataGridView1.CurrentRow.Cells["Contacto"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}



