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
    public partial class frmSalidaT : Form
    {
        UserModel userModel = new UserModel();

        string IdBolsa;
        string NumPedido;
        string IdHilo;
        string IdColor;
        string LoteHilatura;
        string LoteT;
        string IdCaja;
        string PesoBruto;
        string PesoNeto;
        string NumConos;
        string Malla;
        string ColorCono;
        public frmSalidaT()
        {
            InitializeComponent();
            MostrarSalidasT();
        }

        public void ValidarTextBox()
        {
            if (textBox1.Text != "")
            {
                textBox3.Clear();
                tboxEntradaC.Clear();
            }
            if (textBox3.Text != "")
            {
                textBox1.Clear();
                tboxEntradaC.Clear();
            }
            if (tboxEntradaC.Text != "")
            {
                textBox1.Clear();
                textBox3.Clear();
            }
        }

        public void MostrarSalidasT()
        {
            try
            {
                dataGridView1.DataSource = userModel.MostrarSalidasT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha ingresado ningun valor en la base de datos: " + ex);
            }

        }

        public void MostrarDatosLote(string ID)
        {
            try
            {
                dataGridView2.DataSource = userModel.MostrarLoteT(ID);
            }
            catch (Exception)
            {

            }
        }

        public void MostrarDatosI(string ID)
        {
            try
            {
                dataGridView2.DataSource = userModel.MostrarBolsaT(ID);
            }
            catch (Exception)
            {

            }
        }

        public void GuardarDatosLote()
        {           
            try
            {
                DataTable table = userModel.MostrarLoteT(tboxEntradaC.Text);
                userModel.ActualizarLote(tboxEntradaC.Text);

                for (int filas = 0; filas < table.Rows.Count; filas++)
                {

                    IdBolsa = table.Rows[filas]["IDBolsa"].ToString();
                    NumPedido = table.Rows[filas]["NumPedido"].ToString();
                    IdHilo = table.Rows[filas]["IdHilo"].ToString();
                    IdColor = table.Rows[filas]["IdColor"].ToString();
                    LoteHilatura = table.Rows[filas]["LoteHilatura"].ToString();
                    LoteT = table.Rows[filas]["LoteTenido"].ToString();
                    IdCaja = table.Rows[filas]["IdCaja"].ToString();
                    PesoBruto = table.Rows[filas]["PesoBruto"].ToString();
                    PesoNeto = table.Rows[filas]["PesoNeto"].ToString();
                    NumConos = table.Rows[filas]["NumConos"].ToString();
                    Malla = table.Rows[filas]["Malla"].ToString();
                    ColorCono = table.Rows[filas]["ColorCono"].ToString();

                    userModel.InsertarEntradasTRB(IdBolsa,NumPedido,IdHilo,IdColor,LoteHilatura,LoteT,IdCaja,PesoBruto,PesoNeto,NumConos,"6",Malla,ColorCono);
                }
                MessageBox.Show("Se realizó con exito el movimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

            }
        }

        public void LeerDatos()
        {
            DataGridViewRow row = dataGridView2.Rows[0];

            IdBolsa = Convert.ToString(row.Cells["IDBolsa"].Value);
            NumPedido = Convert.ToString(row.Cells["NumPedido"].Value);
            IdHilo = Convert.ToString(row.Cells["IdHilo"].Value);
            IdColor = Convert.ToString(row.Cells["IdColor"].Value);
            LoteHilatura = Convert.ToString(row.Cells["LoteHilatura"].Value);
            LoteT = Convert.ToString(row.Cells["LoteTenido"].Value);
            IdCaja = Convert.ToString(row.Cells["IdCaja"].Value);
            PesoBruto = Convert.ToString(row.Cells["PesoBruto"].Value);
            PesoNeto = Convert.ToString(row.Cells["PesoNeto"].Value);
            NumConos = Convert.ToString(row.Cells["NumConos"].Value);
            Malla = Convert.ToString(row.Cells["Malla"].Value);
            ColorCono = Convert.ToString(row.Cells["ColorCono"].Value);

        }

        private void tboxEntradaC_TextChanged(object sender, EventArgs e)
        {
            ValidarTextBox();
            MostrarDatosLote(tboxEntradaC.Text);
        }

        private void btnGuardarEM_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                LeerDatos();
                userModel.InsertarEntradasTRB(IdBolsa,NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "6", Malla, ColorCono);
                MostrarSalidasT();
                textBox3.Clear();
                MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (tboxEntradaC.Text != "")
            {
                GuardarDatosLote();
                MostrarSalidasT();
            }
           
        }

        private void tboxEntradaC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                {
                    ValidarTextBox();
                    MostrarDatosI(textBox1.Text);
                    LeerDatos();
                    timerBolsa.Start();
                }
            }
            catch (Exception)
            {

            }
        }

        private void timerBolsa_Tick(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    userModel.InsertarEntradasTRB(IdBolsa,NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "6", Malla, ColorCono);
                    MostrarSalidasT();
                    textBox1.Clear();
                    timerBolsa.Stop();
                    MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Por favor ingrese el número de Bolsa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                textBox1.Clear();
                timerBolsa.Dispose();
                timerBolsa.Stop();
                MessageBox.Show("No se encontró el producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                {
                    ValidarTextBox();
                    MostrarDatosI(textBox3.Text);
                    LeerDatos();
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
