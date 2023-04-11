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
    public partial class frmConfigProductos : Form
    {
        UserModel userModel = new UserModel();

        bool editarHilo;
        bool editarComponente;
        string idHiloG;
        string componenteG;
        public frmConfigProductos()
        {
            InitializeComponent();
            CargarCatalogoHilos();
        }
        public void LimpiarDatos()
        {
            tboxIDHilo.Enabled = true;
            editarHilo = false;
            tboxIDHilo.Clear();
            tboxHilo.Clear();
            tboxTitulo.Clear();
            tboxCosto.Clear();
            tboxPorcentaje.Clear();
            cmbPorcentajeT.Text = "";
            dataGridView2.DataSource = null;
        }
        public void LimpiarDatosC()
        {
            editarComponente = false;
            cmbPorcentajeT.Text = "";
            tboxPorcentaje.Clear();
        }

        public void CargarCatalogoHilos()
        {

            dataGridView1.DataSource = userModel.MostrarHilos();
        }

        public void CargarComponentes()
        {
            dataGridView2.DataSource = userModel.SeleccionarComponentesH(tboxIDHilo.Text);
            cmbPorcentajeT.DataSource = userModel.ValidarComponentesT(tboxIDHilo.Text);
            cmbPorcentajeT.DisplayMember = "PorcentajeT";
            CargarMateriales();
        }

        public void CargarMateriales()
        {
            cmbMateriaPrima.DataSource = userModel.MostrarCatalogoMP();
            cmbMateriaPrima.DisplayMember = "Producto";
        }

        public void ActualizarHilo()
        {
            try
            {
                var validHilo = userModel.ValidarDescHilo(tboxHilo.Text, tboxTitulo.Text);
                if (idHiloG != "" & tboxIDHilo.Text != "" & tboxHilo.Text != "" & tboxTitulo.Text != "" & tboxCosto.Text != "")
                {
                    if (validHilo == true)
                    {
                        MessageBox.Show("Este hílo ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        tboxIDHilo.Enabled = true;
                        userModel.ActualizarHilo(idHiloG, tboxIDHilo.Text, tboxHilo.Text, tboxTitulo.Text, tboxCosto.Text);
                        MessageBox.Show("Se actualizó correctamente el Hilo.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCatalogoHilos();
                        LimpiarDatos();
                    }

                }
                else
                    MessageBox.Show("Por favor completa todos los campos, vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Por favor verifica que todos los datos esten correctos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void ActualizarComponentes()
        {
            try
            {
                if (tboxHilo.Text != "" & componenteG != "" & cmbMateriaPrima.Text != "" & tboxPorcentaje.Text != "")
                {
                    userModel.ActualizarComponente(tboxHilo.Text, componenteG, cmbMateriaPrima.Text, tboxPorcentaje.Text);
                    MessageBox.Show("Se actualizó correctamente el componente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarComponentes();
                    LimpiarDatosC();
                }
                else
                    MessageBox.Show("Por favor completa todos los campos, vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Por favor verifica que todos los datos esten correctos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void InsertarHilo()
        {
            try
            {
                var validIdHilo = userModel.ValidarIdHilo(tboxIDHilo.Text);
                var validHilo = userModel.ValidarDescHilo(tboxHilo.Text, tboxTitulo.Text);
                if (tboxIDHilo.Text != "" & tboxHilo.Text != "" & tboxTitulo.Text != "" & tboxCosto.Text != "")
                {
                    if (validIdHilo == true)
                    {
                        MessageBox.Show("Este código de hílo ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (validHilo == true)
                    {
                        MessageBox.Show("Este hílo ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (validIdHilo == false & validHilo == false)
                    {
                        userModel.InsertarHilo(tboxIDHilo.Text, tboxHilo.Text, tboxTitulo.Text, tboxCosto.Text);
                        MessageBox.Show("Se guardó correctamente el Hilo.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCatalogoHilos();
                        LimpiarDatos();
                    }
                }
                else
                    MessageBox.Show("Por favor completa todos los campos, vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Por favor verifica que todos los datos esten correctos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertarComponente()
        {
            var validComponenteH = userModel.ValidarComponenteH(tboxIDHilo.Text, cmbMateriaPrima.Text);
            if (tboxIDHilo.Text != "" & tboxHilo.Text != "" & tboxTitulo.Text != "" & tboxPorcentaje.Text != "" & cmbMateriaPrima.Text != "" & tboxCosto.Text != "")
            {
                try
                {
                    if (validComponenteH == true)
                    {
                        MessageBox.Show("Este hílo ya cuenta con el componente seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        userModel.InsertarComponente(tboxIDHilo.Text, tboxHilo.Text, tboxTitulo.Text, tboxPorcentaje.Text, cmbMateriaPrima.Text, tboxCosto.Text);
                        MessageBox.Show("Se guardó correctamente el componente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarComponentes();
                        LimpiarDatosC();
                    }
                }
                catch
                {
                    MessageBox.Show("Por favor verifica que todos los datos esten correctos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("Por favor completa todos los campos, vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void BorrarHilo()
        {
            if (tboxIDHilo.Text != "")
            {
                userModel.EliminarHilo(tboxIDHilo.Text);
                MessageBox.Show("Se elminó correctamente el Hilo.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCatalogoHilos();
            }
            else
                MessageBox.Show("Por favor completa todos los campos, vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void BorrarComponente()
        {
            if (tboxPorcentaje.Text != "")
            {
                userModel.EliminarComponente(tboxIDHilo.Text, cmbMateriaPrima.Text);
                MessageBox.Show("Se eliminó correctamente el componente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarComponentes();
            }
            else
                MessageBox.Show("Por favor completa todos los campos, vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void HabilitarComponentes()
        {
            if (editarHilo == true)
            {
                cmbMateriaPrima.Enabled = true;
                tboxPorcentaje.Enabled = true;
            }
            else
            {
                cmbMateriaPrima.Enabled = false;
                tboxPorcentaje.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["Hilo"].Value.ToString() != "")
                {
                    tboxIDHilo.Enabled = false;
                    idHiloG = dataGridView1.Rows[e.RowIndex].Cells["IdHilo"].Value.ToString();
                    tboxIDHilo.Text = dataGridView1.Rows[e.RowIndex].Cells["IdHilo"].Value.ToString();
                    tboxHilo.Text = dataGridView1.Rows[e.RowIndex].Cells["Hilo"].Value.ToString();
                    tboxTitulo.Text = dataGridView1.Rows[e.RowIndex].Cells["Titulo"].Value.ToString();
                    tboxCosto.Text = dataGridView1.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                    editarHilo = true;
                    editarComponente = false;
                    HabilitarComponentes();
                    CargarComponentes();
                }
                else
                {
                    MessageBox.Show("Por favor selecciona una opcción válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    editarHilo = false;
                }

            }
            catch
            {
                MessageBox.Show("Por favor selecciona una opcción válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editarHilo = false;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows[e.RowIndex].Cells["Componente"].Value.ToString() != null && dataGridView2.Rows[e.RowIndex].Cells["PorcentajeC"].Value.ToString() != null)
                {
                    componenteG = dataGridView2.Rows[e.RowIndex].Cells["Componente"].Value.ToString();
                    cmbMateriaPrima.Text = dataGridView2.Rows[e.RowIndex].Cells["Componente"].Value.ToString();
                    tboxPorcentaje.Text = dataGridView2.Rows[e.RowIndex].Cells["PorcentajeC"].Value.ToString();
                    editarComponente = true;
                }
                else
                {
                    MessageBox.Show("Por favor selecciona una opcción válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    editarHilo = false;
                }

            }
            catch
            {
                MessageBox.Show("Por favor selecciona una opcción válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editarHilo = false;
            }
        }

        private void btnAgregarComponente_Click(object sender, EventArgs e)
        {
            if (editarComponente == false)
            {
                InsertarComponente();
                cmbMateriaPrima.Text = "";
                tboxPorcentaje.Text = "";
                CargarComponentes();
            }
            else if (editarComponente == true)
            {
                ActualizarComponentes();
                editarComponente = false;
                cmbMateriaPrima.Text = "";
                tboxPorcentaje.Text = "";
                CargarComponentes();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (editarHilo == true)
                {
                    ActualizarHilo();
                }
                else if (editarHilo == false)
                {
                    InsertarHilo();
                }

            }
            catch
            {

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            BorrarHilo();
            LimpiarDatosC();
        }

        private void tboxCosto_KeyPress(object sender, KeyPressEventArgs e)
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
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tboxPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarDatosC();
        }

        private void tboxPorcentaje_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double porcentajeT;
                double porcentajeC;
                if (tboxPorcentaje.Text != "" && cmbPorcentajeT.Text!="")
                {
                    porcentajeC = Convert.ToInt32(tboxPorcentaje.Text);
                    porcentajeT = Convert.ToInt32(cmbPorcentajeT.Text);
                    porcentajeT -= porcentajeC;
                    if (porcentajeT + porcentajeC > 100)
                    {
                        //tboxPorcentaje.Clear();
                        MessageBox.Show("Por favor escribe un porcentaje menor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(tboxPorcentaje.Text!="" && cmbPorcentajeT.Text == "")
                {
                    porcentajeT = 0;
                    porcentajeC= Convert.ToInt32(tboxPorcentaje.Text);
                    if (porcentajeT + porcentajeC > 100)
                    {
                        //tboxPorcentaje.Clear();
                        MessageBox.Show("Por favor escribe un porcentaje menor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                
            }
            catch
            {
                tboxPorcentaje.Clear();
            }
        }

        private void btnBorrarComponente_Click(object sender, EventArgs e)
        {
            BorrarComponente();
            LimpiarDatosC();
        }
    }
}
