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
    public partial class frmConfigUsuarios : Form
    {
        UserModel userModel = new UserModel();
        private string IdUsuario=null;
        private bool editarUsuario = false;
        bool validacion;
        public frmConfigUsuarios()
        {
            InitializeComponent();
        }

        private void frmConfigClientes_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            dataGridView1.DataSource = userModel.MostrarUsuarios();
        }

        public void VerificarDatos()
        {
            if (tboxNombre.Text != "" & tboxApellido.Text != "" & tboxUsuario.Text != "" & cmbCargo.Text != "" & cmbArea.Text != "" & tboxCorreoE.Text != "")
            {
                validacion = true;
            }
            else
                validacion = false;
        }

        private void LimpiarDatos()
        {
            tboxNombre.Text = "";
            tboxApellido.Text = "";
            tboxUsuario.Text = "";
            tboxContraseña.Text = "";
            tboxConfirmarContraseña.Text = "";
            cmbCargo.Text = "";
            cmbArea.Text = "";
            tboxCorreoE.Text = "";
        }

        private void tboxContraseña_Enter(object sender, EventArgs e)
        {
           tboxContraseña.UseSystemPasswordChar = true;
        }

        private void tboxConfirmarContraseña_Enter(object sender, EventArgs e)
        {
          tboxConfirmarContraseña.UseSystemPasswordChar = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VerificarDatos();
            if (validacion == true & tboxContraseña.Text!="")
            {
                if (editarUsuario == false)
                {
                    if (tboxContraseña.Text == tboxConfirmarContraseña.Text)
                    {
                        var validNombre = userModel.ValidarNombresUsuarios(tboxNombre.Text, tboxApellido.Text);
                        var validUsuario = userModel.ValidarUsuario(tboxUsuario.Text);
                        if (validNombre == true)
                        {
                            MessageBox.Show("El nombre y apellido coinciden con otro registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (validUsuario==true)
                        {
                            MessageBox.Show("Este usuario ya fue registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if(validNombre==false & validUsuario==false)
                        {
                            userModel.InsertarUSuarios(tboxNombre.Text, tboxApellido.Text, tboxUsuario.Text, tboxContraseña.Text, cmbCargo.Text, cmbArea.Text, tboxCorreoE.Text);
                            MessageBox.Show("El usuario se registro de manera exitosa.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarUsuarios();
                            LimpiarDatos();
                        }                       
                    }
                    else
                        MessageBox.Show("Las contraseñas no coinciden, vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (tboxContraseña.Text == tboxConfirmarContraseña.Text)
                    {
                        userModel.EditarUSuarios(tboxNombre.Text, tboxApellido.Text, tboxUsuario.Text, tboxContraseña.Text, cmbCargo.Text, cmbArea.Text, tboxCorreoE.Text,IdUsuario);
                        MessageBox.Show("El usuario se actualizó de manera exitosa.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarUsuarios();
                        tboxUsuario.Enabled = true;
                        tboxNombre.Enabled = true;
                        tboxApellido.Enabled = true;
                        LimpiarDatos();
                    }
                    else
                        MessageBox.Show("Las contraseñas no coinciden, vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
                MessageBox.Show("Por favor completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (editarUsuario == true & tboxUsuario.Text!="")
            {
                userModel.BorrarUsuario(IdUsuario);
                editarUsuario = false;
                IdUsuario = null;
                LimpiarDatos();
                MostrarUsuarios();
                MessageBox.Show("Se eliminó exitosamente el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tboxUsuario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxContraseña_Enter_1(object sender, EventArgs e)
        {
            tboxContraseña.UseSystemPasswordChar = true;
        }

        private void tboxConfirmarContraseña_Enter_1(object sender, EventArgs e)
        {
            tboxConfirmarContraseña.UseSystemPasswordChar = true;
        }

        private void tboxContraseña_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                e.Handled = true;
            }
        }

        private void tboxConfirmarContraseña_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editarUsuario = true;
                tboxUsuario.Enabled = false;
                IdUsuario = dataGridView1.CurrentRow.Cells["IdUsuario"].Value.ToString();
                tboxNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                tboxApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                tboxUsuario.Text = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
                cmbCargo.Text = dataGridView1.CurrentRow.Cells["Cargo"].Value.ToString();
                cmbArea.Text = dataGridView1.CurrentRow.Cells["Area"].Value.ToString();
                tboxCorreoE.Text = dataGridView1.CurrentRow.Cells["CorreoE"].Value.ToString();
                tboxUsuario.Enabled = false;
                tboxNombre.Enabled = false;
                tboxApellido.Enabled = false;
            }
            else
            {
                MessageBox.Show("Seleccione un usuario", "Advertencia");
            }
        }
    }
}
