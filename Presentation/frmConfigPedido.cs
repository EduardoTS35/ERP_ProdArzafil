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
    public partial class frmConfigPedido : Form
    {
        UserModel userModel = new UserModel();
        DataSet resultados = new DataSet();
        DataView mifiltro;
        private string IdPedido = null;
        private bool editarPedido = false;
        private bool editarFecha = false;
        string idPrimario;

        public frmConfigPedido()
        {
            InitializeComponent();
        }

        private void frmConfigPedido_Load(object sender, EventArgs e)
        {
            MostrarPedidos();
        }

        private void MostrarPedidos()
        {
            resultados.Dispose();
            resultados.Tables.Add(userModel.MostrarPedidos());
            this.mifiltro = ((DataTable)resultados.Tables[0]).DefaultView;
            dataGridView1.DataSource = mifiltro;
        }

        private void LimpiarDatos()
        {
            tboxNumPedido.Text = "";
            dTFechaE.Text = "";
            tboxCodHilo.Text = "";
            tboxCodColor.Text = "";
            tboxCodCaja.Text = "";
            tboxCantidadKG.Text = "";
            tboxCodCliente.Text = "";
            tboxCodCliente.Text = "";
            tboxCodVendedor.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editarPedido = true;
                idPrimario= dataGridView1.CurrentRow.Cells["IdPrimario"].Value.ToString();
                IdPedido = dataGridView1.CurrentRow.Cells["IDPedido"].Value.ToString();
                tboxNumPedido.Text = dataGridView1.CurrentRow.Cells["IDPedido"].Value.ToString();
                dTFechaE.Text = dataGridView1.CurrentRow.Cells["FechaEntrega"].Value.ToString();
                tboxCodVendedor.Text = dataGridView1.CurrentRow.Cells["IdVendedor"].Value.ToString();
                tboxCodCliente.Text = dataGridView1.CurrentRow.Cells["IdCliente"].Value.ToString();
                tboxCodCaja.Text = dataGridView1.CurrentRow.Cells["IdCaja"].Value.ToString();
                tboxCantidadKG.Text = dataGridView1.CurrentRow.Cells["PesoPedido"].Value.ToString();
                tboxCodHilo.Text = dataGridView1.CurrentRow.Cells["IdHilo"].Value.ToString();
                tboxCodColor.Text = dataGridView1.CurrentRow.Cells["IdColor"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un Pedido", "Advertencia");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
        }


        private void tboxNumPedidoB_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tboxNumPedidoB.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {                 
                    if (tboxCodVendedorB.Text.Length != 0)
                    {
                        tboxCodVendedorB.Clear();
                    }
                    if (tboxCodClienteB.Text.Length != 0)
                    {
                        tboxCodClienteB.Clear();
                    }
                    int num = Convert.ToInt32(tboxNumPedidoB.Text);
                    mifiltro.RowFilter = "IDPedido = " + num + "";
                }

            }
            catch
            {
            }

        }

        private void tboxCodVendedorB_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tboxCodVendedorB.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {
                    if (tboxNumPedidoB.Text.Length != 0)
                    {
                        tboxNumPedidoB.Clear();
                    }
                    if (tboxCodClienteB.Text.Length != 0)
                    {
                        tboxCodClienteB.Clear();
                    }
                    int num2 = Convert.ToInt32(this.tboxCodVendedorB.Text);
                    this.mifiltro.RowFilter = "IdVendedor = " + num2 + "";
                }

            }
            catch
            {
            }
        }

        private void tboxCodClienteB_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tboxCodClienteB.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {
                    if (tboxCodVendedorB.Text.Length != 0 )
                    {
                       tboxCodVendedorB.Clear();
                    }
                    if (tboxNumPedidoB.Text.Length != 0)
                    {
                        tboxNumPedidoB.Clear();
                    }
                    int num3 = Convert.ToInt32(this.tboxCodClienteB.Text);
                    this.mifiltro.RowFilter = "IdCliente = " + num3 + "";
                }

            }
            catch
            {
            }
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            editarPedido = true;
            if (editarPedido == true)
            {
                userModel.BorrarPedido(IdPedido);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                editarPedido = false;
                IdPedido = null;
                LimpiarDatos();
                MessageBox.Show("Se eliminó exitosamente el pedido");
                
            }
            else
            {
                MessageBox.Show("Seleccione un pedido", "Advertencia");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tboxNumPedidoB.Clear();
            tboxCodClienteB.Clear();
            tboxCodVendedorB.Clear();
            this.mifiltro.RowFilter = null;
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (editarPedido == true & editarFecha==true)
            {
                if (tboxNumPedido.Text != "" & dTFechaE.Text != "" & tboxCodHilo.Text != "" & tboxCodColor.Text != "" & tboxCodCaja.Text != "" & tboxCantidadKG.Text != "" & tboxCodVendedor.Text != "" & tboxCodCliente.Text != "")

                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estas seguro de editar la fecha del pedido?", "Adveritencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            userModel.ModificarPedidos(dTFechaE.Value.Date, IdPedido);
                            editarPedido = false;
                            IdPedido = null;
                            LimpiarDatos();
                            MessageBox.Show("Se actualizo correctamente. Actualiza la pantalla para visualizar el cambio.","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Surgio un error: " + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (editarPedido == true & editarFecha == false)
            {
                if (tboxNumPedido.Text != "" & dTFechaE.Text != "" & tboxCodHilo.Text != "" & tboxCodColor.Text != "" & tboxCodCaja.Text != "" & tboxCantidadKG.Text != "" & tboxCodVendedor.Text != "" & tboxCodCliente.Text != "")

                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estas seguro de editar la línea del pedido?", "Adveritencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            userModel.ModificarPedidos(tboxCodHilo.Text,tboxCodColor.Text,tboxCodCaja.Text,tboxCantidadKG.Text,idPrimario);
                            editarPedido = false;
                            IdPedido = null;
                            LimpiarDatos();
                            MessageBox.Show("Se actualizo correctamente. Actualiza la pantalla para visualizar el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Surgio un error: " + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void tboxNumPedidoB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxCodVendedorB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxCodClienteB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxNumPedido_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxCodVendedor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxCodCaja_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxCantidadKG_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxCodCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (tboxNumPedido.Text != "")
            {
                checkBox1.Checked = true;
                dTFechaE.Enabled = true;               
            }
            else
            {
                checkBox1.Checked = false;
                dTFechaE.Enabled = false;
                
            }
            if (checkBox1.Checked == true)
            {
                editarFecha = true;
                tboxCodVendedor.Enabled = false;
                tboxCodCaja.Enabled = false;
                tboxCantidadKG.Enabled = false;
                tboxCodHilo.Enabled = false;
                tboxCodColor.Enabled = false;
                tboxCodCliente.Enabled = false;
            }
            else
            {
                editarFecha = false;
                tboxCodVendedor.Enabled = true;
                tboxCodCaja.Enabled = true;
                tboxCantidadKG.Enabled = true;
                tboxCodHilo.Enabled = true;
                tboxCodColor.Enabled = true;
                tboxCodCliente.Enabled = true;
            }               
        }
    }
}
