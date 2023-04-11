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
using Commun.Cache;

namespace Presentation
{
    public partial class frmEntradaAC : Form
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
        public frmEntradaAC()
        {
            InitializeComponent();
            MostrarDatosSalidas();
        }

        public void MostrarDatosSalidas()
        {
            try
            {
                dataGridView1.DataSource = userModel.MostrarDEntradasAC();
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
                dataGridView2.DataSource = userModel.MostrarDBolsaAC(ID,"2");
            }
            catch (Exception)
            {

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
        public void InsertarDatos()
        {
            userModel.InsertarEntradaAC(IdBolsa, IdHilo, LoteHilatura, IdCaja, PesoBruto, PesoNeto, NumConos, "3", Malla, ColorCono);
            userModel.ActualizarStatusBolsa(IdBolsa, "3");
            MostrarDatosSalidas();
        }

        public void LeerMultiLine()
        {
            foreach (var row in tboxEntradaM.Lines)
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                InsertarDatos();
                tboxEntradaC.Clear();
                timer1.Stop();
            }
            catch
            {
                tboxEntradaC.Clear();
                timer1.Dispose();
                timer1.Stop();
                MessageBox.Show("No se encontró el producto seleccionado");
            } 
        }

        private void btnGuardarEM_Click(object sender, EventArgs e)
        {
            if (tboxEntradaM.Text != "")
            {
                LeerMultiLine();
                MessageBox.Show("Se realizó correctamente la entrada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tboxEntradaM.Clear();
            }
            else
                MessageBox.Show("Por favor selecciona una bolsa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void tboxEntradaC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tboxEntradaM.Text != null)
                    tboxEntradaM.Clear();

                if (tboxEntradaC.Text != null)
                {
                    try
                    {
                        if (tboxEntradaC.Text != null)
                        {
                            MostrarDatosI(tboxEntradaC.Text);
                            LeerDatos();
                            timer1.Start();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se encontró ningun producto" + ex);
                    }
                }
            }
            catch
            {

            }
           
        }

        private void tboxEntradaM_TextChanged(object sender, EventArgs e)
        {

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

        private void tboxEntradaM_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
