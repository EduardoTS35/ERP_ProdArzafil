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
    public partial class frmConfigVendedores : Form
    {
        UserModel userModel = new UserModel();
        private bool editarVendedor = false;
        public frmConfigVendedores()
        {
            InitializeComponent();
            MostrarVendedores();
        }

        private void MostrarVendedores()
        {
            dataGridView1.DataSource = userModel.MostrarCatalogoVendedores();
        }

        private void LimpiarDatos()
        {
            tboxIdVendedor.Text = "";
            tboxPlaza.Text = "";
            tboxNombre.Text = "";
            tboxApellido.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editarVendedor == false)
            {
                if (tboxNombre.Text != "" & tboxApellido.Text != "" & tboxPlaza.Text != "")
                {

                    try
                    {
                        var validNombreApellido = userModel.ValidarVendedor(tboxNombre.Text,tboxApellido.Text);
                        DialogResult dialogResult = MessageBox.Show("¿Estás seguro de guardar los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (validNombreApellido == true)
                            {
                                MessageBox.Show("Este vendedor ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (validNombreApellido == false)
                            {
                                userModel.InsertarVendedor(tboxPlaza.Text, tboxNombre.Text, tboxApellido.Text);
                                MostrarVendedores();
                                MessageBox.Show("Se guardó correctamente el nuevo Vendedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarDatos();
                            }                       
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha surgido un error: " + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                else
                {
                    MessageBox.Show("Por favor completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            if (editarVendedor == true)
            {
                if (tboxIdVendedor.Text != "" & tboxPlaza.Text != "" & tboxNombre.Text != "" & tboxApellido.Text != "")

                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estás seguro de editar los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            userModel.ActualizarVendedor(tboxPlaza.Text, tboxNombre.Text,tboxApellido.Text, tboxIdVendedor.Text);
                            editarVendedor = false;
                            LimpiarDatos();
                            MostrarVendedores();
                            MessageBox.Show("Se actualizó correctamente el Vendedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Surgió un error: " + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (editarVendedor == true)
            {
                userModel.EliminarVendedor(tboxIdVendedor.Text);
                editarVendedor = false;
                LimpiarDatos();
                MostrarVendedores();
                MessageBox.Show("Se eliminó exitosamente el Vendedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una Vendedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["IDVendedor"].Value.ToString() != "")
            {
                editarVendedor = true;
                tboxIdVendedor.Text = dataGridView1.CurrentRow.Cells["IDVendedor"].Value.ToString();
                tboxPlaza.Text = dataGridView1.CurrentRow.Cells["Plaza"].Value.ToString();
                tboxNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                tboxApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un Vendedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tboxNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxApellido_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
