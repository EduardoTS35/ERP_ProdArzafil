using Commun.Cache;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmCatalogoClientes : Form
    {

        UserModel userModel = new UserModel();
        DataSet resultados = new DataSet();
        DataView mifiltro;

        public frmCatalogoClientes()
        {
            InitializeComponent();
        }

        private void frmCatalogoClientes_Load(object sender, EventArgs e)
        {
            MostrarCatalogo();
        }

        public void MostrarCatalogo()
        {
            resultados.Tables.Add(userModel.MostrarCatalogoClientes());
            this.mifiltro = ((DataTable)resultados.Tables[0]).DefaultView;
            dataGridView1.DataSource = mifiltro;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.textBox1.Text.Split('¿');
            if (tboxCiudad.Text != null)
                tboxCiudad.Clear();
            if (tboxEdo.Text != null)
                tboxEdo.Clear();
            if (tboxPlaza.Text != null)
                tboxPlaza.Clear();

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(RazonSocial LIKE'%" + palabra + "%' )";
                }
                else
                {
                    salidaDatos += "AND (RazonSocial LIKE'%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }

        private void tboxCiudad_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.tboxCiudad.Text.Split('¿');
            if (textBox1.Text != null)
                textBox1.Clear();
            if (tboxEdo.Text != null)
                tboxEdo.Clear();
            if (tboxPlaza.Text != null)
                tboxPlaza.Clear();

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(Ciudad Like '%" + palabra + "%' )";
                }
                else
                {
                    salidaDatos += "AND (Ciudad Like '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }

        private void tboxEdo_KeyUp(object sender, KeyEventArgs e)
        {
            if (tboxCiudad.Text != null)
                tboxCiudad.Clear();
            if (textBox1.Text != null)
                textBox1.Clear();
            if (tboxPlaza.Text != null)
                tboxPlaza.Clear();
            string salidaDatos = "";
            string[] palabraBusqueda = this.tboxEdo.Text.Split('¿');

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(Edo Like '%" + palabra + "%' )";
                }
                else
                {
                    salidaDatos += "AND (Edo Like '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }

        private void tboxPlaza_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tboxPlaza.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {
                    if (textBox1.Text.Length != 0)
                    {
                        textBox1.Clear();
                    }
                    if (tboxCiudad.Text.Length != 0)
                    {
                        tboxCiudad.Clear();
                    }
                    if (tboxEdo.Text != null)
                        tboxEdo.Clear();
                    int num3 = Convert.ToInt32(this.tboxPlaza.Text);
                    this.mifiltro.RowFilter = "Plaza = " + num3 + "";
                }

            }
            catch
            {
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

        private void frmCatalogoClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppCache.ActualDescCliente == "")
            {
                MessageBox.Show("Por favor elige un Cliente", "Advertencia");
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString() != "")
                {
                    AppCache.ActualIdCliente = dataGridView1.Rows[e.RowIndex].Cells["IDCliente"].Value.ToString();
                    AppCache.ActualDescCliente = dataGridView1.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString();
                    this.Close();
                    
                }
                else
                    MessageBox.Show("Por favor elige un Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Por favor elige un Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
