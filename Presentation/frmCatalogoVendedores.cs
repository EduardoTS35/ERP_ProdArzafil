using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commun.Cache;
using Domain;

namespace Presentation
{
    public partial class frmCatalogoVendedores : Form
    {
        UserModel userModel = new UserModel();
        DataSet resultados = new DataSet();
        DataView mifiltro;

        public frmCatalogoVendedores()
        {
            InitializeComponent();
        }

        private void frmCatalogoVendedores_Load(object sender, EventArgs e)
        {
            MostrarCatalogo();
        }

        public void MostrarCatalogo()
        {
            resultados.Tables.Add(userModel.MostrarCatalogoVendedores());
            this.mifiltro = ((DataTable)resultados.Tables[0]).DefaultView;
            dataGridView1.DataSource = mifiltro;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.textBox1.Text.Split(' ');

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(Nombre Like '%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += "AND (Nombre Like '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox2.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {
                    if (textBox1.Text.Length != 0)
                    {
                        textBox1.Clear();
                    }
                    int num2 = Convert.ToInt32(this.textBox2.Text);
                    this.mifiltro.RowFilter = "IdVendedor = " + num2 + "";
                }
            }
            catch
            {
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmCatalogoVendedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppCache.ActualDescVendedor == "")
            {
                MessageBox.Show("Por favor elige un Vendedor", "Advertencia");
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString() != "")
                {
                    AppCache.ActualIdVendedor = dataGridView1.Rows[e.RowIndex].Cells["IDVendedor"].Value.ToString();
                    AppCache.ActualDescVendedor = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    this.Close();
                }
                else
                    MessageBox.Show("Por favor elige un Vendedor", "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            catch
            {
                MessageBox.Show("Por favor elige un Vendedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
