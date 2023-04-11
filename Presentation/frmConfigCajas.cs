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
    public partial class frmConfigCajas : Form
    {
        UserModel userModel = new UserModel();
        private bool editarCliente = false;

        public frmConfigCajas()
        {
            InitializeComponent();
            MostrarCajas();
        }

        private void MostrarCajas()
        {
            dataGridView1.DataSource = userModel.MostrarCatalogoCajas();
        }

        private void LimpiarDatos()
        {
            tboxIdCaja.Text = "";
            tboxDesc.Text = "";
            tboxCono.Text = "";
            tboxBolsa.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var validDescCaja = userModel.ValidarDescCaja(tboxDesc.Text);
                var validCarCajas = userModel.ValidarCarCaja(Convert.ToDouble(tboxCono.Text), Convert.ToDouble(tboxBolsa.Text));
                if (editarCliente == false)
                {
                    if (tboxDesc.Text != "" & tboxCono.Text != "" & tboxBolsa.Text != "")
                    {

                        try
                        {
                            DialogResult dialogResult = MessageBox.Show("¿Estás seguro de guardar los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (validDescCaja == true)
                                {
                                    MessageBox.Show("Esta caja ya se encuentra registrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (validDescCaja == false)
                                {
                                    userModel.InsertarCaja(tboxDesc.Text, tboxCono.Text, tboxBolsa.Text);
                                    MostrarCajas();
                                    MessageBox.Show("Se guardó correctamente la nueva Tara", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (editarCliente == true)
                {

                    if (tboxIdCaja.Text != "" & tboxDesc.Text != "" & tboxCono.Text != "" & tboxBolsa.Text != "")
                    {
                        try
                        {
                            DialogResult dialogResult = MessageBox.Show("¿Estás seguro de editar los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                            if (dialogResult == DialogResult.Yes)
                            {
                                tboxDesc.Enabled = true;
                                userModel.ActualizarCaja(tboxIdCaja.Text, tboxDesc.Text, tboxCono.Text, tboxBolsa.Text);
                                editarCliente = false;
                                LimpiarDatos();
                                MostrarCajas();
                                MessageBox.Show("Se actualizó correctamente la Tara", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show("Surgió un error: " + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (editarCliente == true)
            {
                tboxDesc.Enabled = true;
                userModel.EliminarCaja(tboxIdCaja.Text);
                editarCliente = false;
                LimpiarDatos();
                MostrarCajas();
                MessageBox.Show("Se eliminó exitosamente la Tara","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una Caja", "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["DescripcionCaja"].Value.ToString() != "" )
            {
                editarCliente = true;
                tboxDesc.Enabled = true;
                tboxIdCaja.Text = dataGridView1.CurrentRow.Cells["IDCaja"].Value.ToString();
                tboxDesc.Text = dataGridView1.CurrentRow.Cells["DescripcionCaja"].Value.ToString();
                tboxCono.Text = dataGridView1.CurrentRow.Cells["TaraCono"].Value.ToString();
                tboxBolsa.Text = dataGridView1.CurrentRow.Cells["TaraBolsa"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una Caja", "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void tboxCono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxBolsa_KeyPress(object sender, KeyPressEventArgs e)
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
