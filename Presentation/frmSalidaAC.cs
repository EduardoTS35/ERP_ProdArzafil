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
    public partial class frmSalidaAC : Form
    {
        UserModel userModel = new UserModel();

        string IdBolsa;
        string IdHilo;
        string LoteHilatura;
        string IdCaja;
        string PesoBruto;
        string PesoNeto;
        string NumConos;
        string Malla;
        string ColorCono;

        public frmSalidaAC()
        {
            InitializeComponent();
            MostrarDatosSalidas();
        }

        public void MostrarDatosSalidas()
        {
            try
            {
                dataGridView1.DataSource = userModel.MostrarDSalidasAC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha ingresado ningun valor en la base de datos: " + ex);
            }

        }

        public void MostrarDatosI(string ID)
        {
            try
            {
                dataGridView2.DataSource = userModel.MostrarDBolsaAC(ID,"3");
            }
            catch (Exception)
            {

            }
        }
        public void InsertarDatos()
        {
            userModel.InsertarSalidasAC(IdBolsa, tboxNumPedido.Text, IdHilo, LoteHilatura, IdCaja, PesoBruto, PesoNeto, NumConos, "4", Malla, ColorCono);
            MostrarDatosSalidas();
        }
        public void LeerMultiLine()
        {
            foreach (var row in tboxSalidaM.Lines)
            {
                try
                {
                    MostrarDatosI(row);
                    LeerDatos();
                    InsertarDatos();
                }
                catch
                {
                    MessageBox.Show("La Bolsa número: " + row + " no se encontró", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void LeerDatos()
        {
            DataGridViewRow row = dataGridView2.Rows[0];

            IdBolsa = Convert.ToString(row.Cells[0].Value);
            IdHilo = Convert.ToString(row.Cells[2].Value);
            LoteHilatura = Convert.ToString(row.Cells[3].Value);
            IdCaja = Convert.ToString(row.Cells[4].Value);
            PesoBruto = Convert.ToString(row.Cells[5].Value);
            PesoNeto = Convert.ToString(row.Cells[6].Value);
            NumConos = Convert.ToString(row.Cells[7].Value);
            Malla = Convert.ToString(row.Cells[8].Value);
            ColorCono = Convert.ToString(row.Cells[9].Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tboxNumPedido.Text != "")
                {
                    userModel.InsertarSalidasAC(IdBolsa, tboxNumPedido.Text, IdHilo, LoteHilatura, IdCaja, PesoBruto, PesoNeto, NumConos, "4", Malla, ColorCono);
                    MostrarDatosSalidas();
                    tboxSalidaC.Clear();
                    timer1.Stop();
                }
                else
                    MessageBox.Show("Por favor ingrese el número de pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                tboxSalidaC.Clear();
                timer1.Dispose();
                timer1.Stop();
                MessageBox.Show("No se encontró el producto seleccionado","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnGuardarSM_Click(object sender, EventArgs e)
        {
            if (tboxSalidaM.Text != "")
            {
                if (tboxNumPedido.Text != "")
                {
                    LeerMultiLine();
                    MostrarDatosSalidas();
                    MessageBox.Show("Se realizó correctamente la entrada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Por favor ingrese el número de pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Por favor selecciona una bolsa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void tboxSalidaC_TextChanged(object sender, EventArgs e)
        {
            if (tboxSalidaM.Text != null)
                tboxSalidaM.Clear();

            if (tboxSalidaC.Text != null)
            {
                try
                {
                    if (tboxSalidaC.Text != null)
                    {
                        MostrarDatosI(tboxSalidaC.Text);
                        LeerDatos();
                        timer1.Start();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se encontró ningun producto" + ex,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void tboxSalidaC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxSalidaM_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxNumPedido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
