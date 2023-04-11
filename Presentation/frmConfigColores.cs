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
    public partial class frmConfigColores : Form
    {
        UserModel userModel = new UserModel();
        private bool editarColores = false;
        string IdColor;
        public frmConfigColores()
        {
            InitializeComponent();
            MostrarColores();
        }

        private void MostrarColores()
        {
            dataGridView1.DataSource = userModel.MostrarCatalogoColores();
        }

        private void LimpiarDatos()
        {
            tboxIdColor.Text = "";
            tboxDesc.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var validIdColor= userModel.ValidarIdColor(tboxIdColor.Text);
            if (editarColores == false)
            {
                if (tboxDesc.Text != "" & tboxIdColor.Text != "" )
                {

                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estás seguro de guardar los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (validIdColor == true)
                            {
                                MessageBox.Show("Este código de color ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if(validIdColor == false)
                            {
                                userModel.InsertarColor(tboxIdColor.Text, tboxDesc.Text);
                                IdColor = null;
                                MostrarColores();
                                MessageBox.Show("Se guardó correctamente el nuevo Color", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (editarColores == true)
            {
                if (tboxIdColor.Text != "" & tboxDesc.Text != "")

                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estás seguro de editar los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (dialogResult == DialogResult.Yes)
                        {
                            tboxIdColor.Enabled = true;
                            userModel.ActualizarColor(IdColor, tboxIdColor.Text, tboxDesc.Text);
                            editarColores = false;
                            IdColor = null;
                            LimpiarDatos();
                            MostrarColores();
                            MessageBox.Show("Se actualizó correctamente el Color", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (editarColores == true)
            {
                userModel.EliminarColor(tboxIdColor.Text);
                editarColores = false;
                LimpiarDatos();
                MostrarColores();
                MessageBox.Show("Se eliminó exitosamente el Color", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un Color", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["IDColor"].Value.ToString() != "")
            {
                editarColores = true;
                tboxIdColor.Enabled = false;
                IdColor = dataGridView1.CurrentRow.Cells["IDColor"].Value.ToString();
                tboxIdColor.Text = dataGridView1.CurrentRow.Cells["IDColor"].Value.ToString();
                tboxDesc.Text = dataGridView1.CurrentRow.Cells["Color"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un Color", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tboxDesc_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
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
