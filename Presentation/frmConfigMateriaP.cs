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
    public partial class frmConfigMateriaP : Form
    {
        UserModel userModel = new UserModel();
        private bool editarMaterial = false;
        public frmConfigMateriaP()
        {
            InitializeComponent();
            MostrarMaterial();
        }
        private void MostrarMaterial()
        {
            dataGridView1.DataSource = userModel.MostrarCatalogoMP();
        }

        private void LimpiarDatos()
        {
            tboxIdProducto.Text = "";
            tboxProducto.Text = "";
            tboxPrecio.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editarMaterial == false)
            {
                if ( tboxProducto.Text != "" & tboxPrecio.Text != "")
                {

                    try
                    {
                        var validDescMP = userModel.ValidarDescMP(tboxProducto.Text);
                        DialogResult dialogResult = MessageBox.Show("¿Estás seguro de guardar los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (validDescMP == true)
                            {
                                MessageBox.Show("Este material ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                userModel.InsertarMateriaP(tboxProducto.Text, tboxPrecio.Text);
                                MostrarMaterial();
                                MessageBox.Show("Se guardó correctamente el nuevo Material", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (editarMaterial == true)
            {
                if (tboxIdProducto.Text != "" & tboxIdProducto.Text != "" & tboxPrecio.Text != "")

                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estás seguro de editar los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            userModel.ActualizarMateriaP(tboxIdProducto.Text,tboxProducto.Text, tboxPrecio.Text);
                            editarMaterial = false;
                            LimpiarDatos();
                            MostrarMaterial();
                            MessageBox.Show("Se actualizó correctamente el Material", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (editarMaterial == true)
            {
                userModel.EliminarMateriaP(tboxIdProducto.Text);
                editarMaterial = false;
                LimpiarDatos();
                MostrarMaterial();
                MessageBox.Show("Se eliminó exitosamente el Material", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una Material", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["IdProducto"].Value.ToString() != "")
            {
                editarMaterial = true;
                tboxIdProducto.Text = dataGridView1.CurrentRow.Cells["IdProducto"].Value.ToString();
                tboxProducto.Text = dataGridView1.CurrentRow.Cells["Producto"].Value.ToString();
                tboxPrecio.Text = dataGridView1.CurrentRow.Cells["Costo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un Material", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tboxPrecio_KeyPress(object sender, KeyPressEventArgs e)
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
