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
    public partial class frmCatalogoCajas : Form
    {
        UserModel userModel = new UserModel();
        DataSet resultados = new DataSet();
        DataView mifiltro;

        public frmCatalogoCajas()
        {
            InitializeComponent();
        }

        private void frmCatalogoCajas_Load(object sender, EventArgs e)
        {
            MostrarCatalogo();
        }

        public void MostrarCatalogo()
        {
            resultados.Tables.Add(userModel.MostrarCatalogoCajas());
            this.mifiltro = ((DataTable)resultados.Tables[0]).DefaultView;
            dataGridView1.DataSource = mifiltro;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.textBox1.Text.Split('¿');

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(DescripcionCaja LIKE'%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += "AND (DescripcionCaja LIKE'%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }


        private void tboxTaraConos_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tboxTaraConos.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {
                    if (tboxTaraBolsa.Text.Length != 0)
                    {
                        tboxTaraBolsa.Clear();
                    }
                    if (textBox1.Text.Length != 0)
                    {
                        textBox1.Clear();
                    }
                    int num3 = Convert.ToInt32(this.tboxTaraConos.Text);
                    this.mifiltro.RowFilter = "TaraCono = " + num3 + "";
                }
            }
            catch
            {
            }
        }

        private void tboxTaraBolsa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tboxTaraBolsa.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {
                    if (tboxTaraConos.Text.Length != 0)
                    {
                        tboxTaraConos.Clear();
                    }
                    if (textBox1.Text.Length != 0)
                    {
                        textBox1.Clear();
                    }
                    int num3 = Convert.ToInt32(this.tboxTaraBolsa.Text);
                    this.mifiltro.RowFilter = "Tara = " + num3 + "";
                }
            }
            catch
            {
            }
        }

        private void tboxNumConos_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmCatalogoCajas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppCache.ActualIdCaja == null & AppCache.ActualDescCaja == null & AppCache.ActualNumConos == null)
            {
                MessageBox.Show("Por favor elige una Caja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dataGridView1.Rows[e.RowIndex].Cells["DescripcionCaja"].Value.ToString() != "")
                {
                    AppCache.ActualIdCaja = dataGridView1.Rows[e.RowIndex].Cells["IDCaja"].Value.ToString();
                    AppCache.ActualDescCaja = dataGridView1.Rows[e.RowIndex].Cells["DescripcionCaja"].Value.ToString();
                    AppCache.ActualPesoCono = dataGridView1.Rows[e.RowIndex].Cells["TaraCono"].Value.ToString();
                    AppCache.ActualPesoBolsa = dataGridView1.Rows[e.RowIndex].Cells["TaraBolsa"].Value.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor elige una Caja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch
            {
                MessageBox.Show("Por favor elige una Caja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
