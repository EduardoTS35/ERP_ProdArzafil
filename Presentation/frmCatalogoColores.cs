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
    public partial class frmCatalogoColores : Form
    {
        UserModel userModel = new UserModel();
        DataSet resultados = new DataSet();
        DataView mifiltro;
        public frmCatalogoColores()
        {
            InitializeComponent();
        }

        private void frmCatalogoColores_Load(object sender, EventArgs e)
        {
            MostrarCatalogo();
        }

        public void MostrarCatalogo()
        {
            resultados.Tables.Add(userModel.MostrarCatalogoColores());
            this.mifiltro = ((DataTable)resultados.Tables[0]).DefaultView;
            dataGridView1.DataSource = mifiltro;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.textBox1.Text.Split('¿');

            if(tboxColor.Text!= null)
            {
                tboxColor.Clear();
            }
            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(IDColor Like '%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += "AND (IDColor Like '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }

        private void tboxColor_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.tboxColor.Text.Split('¿');
            if(textBox1.Text!= null)
            {
                textBox1.Clear();
            }

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(Color LIKE'%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += "AND (Color LIKE '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }

        private void frmCatalogoColores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppCache.ActualIdColor == null & AppCache.ActualDescColor == null)
            {
                MessageBox.Show("Por favor elige un Color", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["Color"].Value.ToString()!="")
                {
                    AppCache.ActualIdColor = dataGridView1.Rows[e.RowIndex].Cells["IDColor"].Value.ToString();
                    AppCache.ActualDescColor = dataGridView1.Rows[e.RowIndex].Cells["Color"].Value.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor elige un Color", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Por favor elige un Color", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
    }
}
