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
    public partial class frmCatalogoMP : Form
    {
        UserModel userModel = new UserModel();
        DataSet resultados = new DataSet();
        DataView mifiltro;
        public frmCatalogoMP()
        {
            InitializeComponent();
        }

        private void frmCatalogoMP_Load(object sender, EventArgs e)
        {
            MostrarCatalogo();
        }
        public void MostrarCatalogo()
        {
            resultados.Tables.Add(userModel.MostrarCatalogoMP());
            this.mifiltro = ((DataTable)resultados.Tables[0]).DefaultView;
            dataGridView1.DataSource = mifiltro;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {
                    if (tboxNumConos.Text.Length != 0)
                    {
                        tboxNumConos.Clear();
                    }

                    int num3 = Convert.ToInt32(this.textBox1.Text);
                    this.mifiltro.RowFilter = "IdProducto = " + num3 + "";
                }
            }
            catch
            {
            }
        }

        private void tboxNumConos_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.tboxNumConos.Text.Split('¿');

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(Producto LIKE'%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += "AND (Producto LIKE'%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCatalogoMP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppCache.ActualDescMP==null)
            {
                MessageBox.Show("Por favor elige un Material", "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                AppCache.ActualIdMP = null;
                AppCache.ActualDescMP = null;
                AppCache.ActualCostoMP = null;
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AppCache.ActualIdMP = dataGridView1.Rows[e.RowIndex].Cells["IdProducto"].Value.ToString();
                AppCache.ActualDescMP = dataGridView1.Rows[e.RowIndex].Cells["Producto"].Value.ToString();
                AppCache.ActualCostoMP = dataGridView1.Rows[e.RowIndex].Cells["Costo"].Value.ToString();
                this.Close();
            }
            catch
            {

            }
        }
    }
}
