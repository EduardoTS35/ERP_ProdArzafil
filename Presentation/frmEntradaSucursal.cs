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
    public partial class frmEntradaSucursal : Form
    {
        string IdBolsa;
        string NumPedido;
        string IdHilo;
        string IdColor;
        string IdCaja;
        string PesoBruto;
        string PesoNeto;
        string NumConos;
        string statusProceso="12";
        
        UserModel userModel = new UserModel();
        public frmEntradaSucursal()
        {
            InitializeComponent();
        }

        private void frmEntradaSucursal_Load(object sender, EventArgs e)
        {
            DefinirProceso();
            MostrarEntradaSucursal();
        }
        public void LeerMultiLine()
        {
            foreach (var row in textBox3.Lines)
            {
                try
                {
                    MostrarDatosBolsa(row);
                    LeerDatos();
                    userModel.InsertarEntradaSucursales(IdBolsa, NumPedido, IdHilo, IdColor, IdCaja, PesoBruto, PesoNeto, NumConos, statusProceso);
                }
                catch
                {
                    MessageBox.Show("La Bolsa número: " + row + " no se encontró", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void timerCodB_Tick(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    userModel.InsertarEntradaSucursales(IdBolsa, NumPedido, IdHilo, IdColor, IdCaja, PesoBruto, PesoNeto, NumConos, statusProceso);
                    MostrarEntradaSucursal();
                    textBox1.Clear();
                    timerCodB.Stop();
                    MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Por favor ingrese el número de Bolsa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                textBox1.Clear();
                timerCodB.Dispose();
                timerCodB.Stop();
                MessageBox.Show("No se encontró el producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DefinirProceso()
        {
            if(UserLoginCache.Area=="Sucursal 1")
            {
                statusProceso = "12";
            }
            if(UserLoginCache.Area=="Sucursal 2")
            {
                statusProceso = "14";
            }
        }
        public void MostrarEntradaSucursal()
        {
            try
            {
                dataGridView1.DataSource = userModel.MostrarSucursal(statusProceso);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha ingresado ningun valor en la base de datos: " + ex);
            }

        }

        public void MostrarDatosBolsa(string ID)
        {
            try
            {
                dataGridView2.DataSource = userModel.MostrarBolsaSucursales(ID,"11");
            }
            catch (Exception)
            {

            }
        }
        public void ValidarTextBox()
        {
            if (textBox1.Text != "")
            {
                textBox3.Clear();
            }
            if (textBox3.Text != "")
            {
                textBox1.Clear();
            }
        }
        public void LeerDatos()
        {
            DataGridViewRow row = dataGridView2.Rows[0];

            IdBolsa = Convert.ToString(row.Cells["IDBolsa"].Value);
            NumPedido = Convert.ToString(row.Cells["NumPedido"].Value);
            IdHilo = Convert.ToString(row.Cells["IdHilo"].Value);
            IdColor = Convert.ToString(row.Cells["IdColor"].Value);
            IdCaja = Convert.ToString(row.Cells["LoteTenido"].Value);
            PesoBruto = Convert.ToString(row.Cells["PesoBruto"].Value);
            PesoNeto = Convert.ToString(row.Cells["PesoNeto"].Value);
            NumConos = Convert.ToString(row.Cells["NumConos"].Value);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                {
                    ValidarTextBox();
                    MostrarDatosBolsa(textBox1.Text);
                    LeerDatos();
                    timerCodB.Start();
                }
            }
            catch (Exception)
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarEM_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                LeerMultiLine();
                MostrarEntradaSucursal();
                MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
