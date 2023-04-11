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
    public partial class frmCatalogoHilos : Form
    {
        UserModel userModel = new UserModel();
        DataSet resultados = new DataSet();
        DataView mifiltro;
        public frmCatalogoHilos()
        {
            InitializeComponent();
        }

        private void frmCatalogoHilos_Load(object sender, EventArgs e)
        {
            MostrarCatalogo();
        }

        public void MostrarCatalogo()
        {
            resultados.Tables.Add(userModel.MostrarCatalogoHilos());
            this.mifiltro = ((DataTable)resultados.Tables[0]).DefaultView;
            dataGridView1.DataSource = mifiltro;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.textBox1.Text.Split('¿');
            if (tboxHilo.Text != null)
            {
                tboxHilo.Clear();
            }
            if (tboxTitulo.Text != null)
            {
                tboxTitulo.Clear();
            }

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(IDHilo Like '%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += "AND (IDHilo Like '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }

        private void tboxHilo_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.tboxHilo.Text.Split('¿');
            if (textBox1.Text != null)
            {
                textBox1.Clear();
            }
            if (tboxTitulo.Text != null)
            {
                tboxTitulo.Clear();
            }

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(Hilo LIKE'%" + palabra + "%' )";
                }
                else
                {
                    salidaDatos += "AND (Hilo LIKE '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }

        private void tboxTitulo_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = "";
            string[] palabraBusqueda = this.tboxTitulo.Text.Split('¿');
            if (textBox1.Text != null)
            {
                textBox1.Clear();
            }
            if (tboxHilo.Text != null)
            {
                tboxHilo.Clear();
            }

            foreach (string palabra in palabraBusqueda)
            {
                if (salidaDatos.Length == 0)
                {
                    salidaDatos = "(Titulo Like '%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += "AND (Titulo LIKE '%" + palabra + "%')";
                }
            }
            this.mifiltro.RowFilter = salidaDatos;
        }

        private void frmCatalogoHilos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppCache.ActualIdHilo == null & AppCache.ActualDescHilo==null & AppCache.ActualTituloHilo==null)
            {
                MessageBox.Show("Por favor elige un Hilo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["Hilo"].Value.ToString()!="")
                {
                    AppCache.ActualIdHilo = dataGridView1.Rows[e.RowIndex].Cells["IdHilo"].Value.ToString();
                    AppCache.ActualDescHilo = dataGridView1.Rows[e.RowIndex].Cells["Hilo"].Value.ToString();
                    AppCache.ActualTituloHilo = dataGridView1.Rows[e.RowIndex].Cells["Titulo"].Value.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor elige un Hilo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
            catch
            {
                MessageBox.Show("Por favor elige un Hilo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
    }
}
