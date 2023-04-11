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
    public partial class frmConfigMP : Form
    {
        UserModel userModel = new UserModel();
        private bool editarMovimiento = false;
        public frmConfigMP()
        {
            InitializeComponent();
        }

        private void LimpiarDatos()
        {
            tboxID.Text = "";
            tboxFecha.Text = "";
            tboxIdProd.Text = "";
            tboxProd.Text = "";
        }

        private void MostrarMovimientos()
        {
            if (comboBox1.Text == "Entradas")
            {
                userModel.MostrarEntradasMP();
                dataGridView1.DataSource = userModel.MostrarEntradasMP();
            }
            else if (comboBox1.Text == "Salidas")
            {
                userModel.MostrarSalidasMP();
                dataGridView1.DataSource = userModel.MostrarSalidasMP();
            }
        }

        private void EliminarMovimiento()
        {
            if (editarMovimiento == true)
            {
                userModel.EliminarMovimientoMP(tboxID.Text);
                MessageBox.Show("Se realizó correctamente el cambio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                editarMovimiento = false;
            }
            else
                MessageBox.Show("Por favor selecciona un movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMovimientos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            EliminarMovimiento();
            MostrarMovimientos();
            LimpiarDatos();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0 & dataGridView1.CurrentRow.Cells["IdProducto"].Value.ToString() != "")
                {
                    editarMovimiento = true;
                    tboxID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    tboxFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                    tboxFechaS.Text = dataGridView1.CurrentRow.Cells["IdProducto"].Value.ToString();
                    tboxIdProd.Text = dataGridView1.CurrentRow.Cells["Producto"].Value.ToString();
                    tboxProd.Text = dataGridView1.CurrentRow.Cells["Peso"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Seleccione un movimiento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {

            }
        }
    }
}
