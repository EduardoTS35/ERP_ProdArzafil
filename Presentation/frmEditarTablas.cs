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
    public partial class frmEditarTablas : Form
    {
        List<string> columnasBolsas = new List<string>() { "IDBolsa", "NumPedido", "IdHilo", "IdColor", "LoteHilatura", "LoteTenido", "IdCaja", "NumConos", "StatusProceso", "NumRemision", "Malla", "ColorCono" };
        List<string> columnasAMP = new List<string>() { "IdProducto", "Peso", "StatusMaterial", "Proveedor" };
        List<string> columnasCatalogoMP = new List<string>() { "IdProducto", "Producto", "Costo" };
        List<string> columnasClientes = new List<string>() { "IDCliente", "RazonSocial", "Calle", "Ciudad", "Edo", "RFC", "Plaza" };
        List<string> columnasColores = new List<string>() { "IDColor", "Color" };
        List<string> columnasHilos = new List<string>() { "IDHilo", "Hilo", "Titulo", "Precio" };
        List<string> columnasProveedores = new List<string>() { "IdProveedor", "razonSocial", "contacto" };
        List<string> columnasPedidos = new List<string>() { "IdPrimario", "IdPedido", "FechaCreacion","FechaEntrega","IdHilo","IdColor","IdCaja","PesoPedido","IdVendedor","IdCliente" };
        string Consulta;
        UserModel userModel = new UserModel();
        frmStatusProceso frm = new frmStatusProceso();
        public frmEditarTablas()
        {
            InitializeComponent();
        }
        private void CargarItemsCmb()
        {


            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dataGridView1.Columns["columna"];

            if (cmbTabla.Text == "Bolsas")
            {
                column.DataSource = columnasBolsas;
                cmbTabla.ValueMember = "Bolsas";
                //frm.Show();

            }
            else if (cmbTabla.Text == "Almacén Materia Prima")
            {
                column.DataSource = (columnasAMP);
                cmbTabla.ValueMember = "AlmacenMateriaPrima";
            }
            else if (cmbTabla.Text == "Catálogo Almacén Materia Prima")
            {
                column.DataSource = (columnasCatalogoMP);
                cmbTabla.ValueMember = "CatalogoMateriaPrima";
            }
            else if (cmbTabla.Text == "Clientes")
            {
                column.DataSource = (columnasClientes);
                cmbTabla.ValueMember = "Clientes";
            }
            else if (cmbTabla.Text == "Colores")
            {
                column.DataSource = (columnasColores);
                cmbTabla.ValueMember = "Colores";
            }
            else if (cmbTabla.Text == "Hilos")
            {
                column.DataSource = (columnasHilos);
                cmbTabla.ValueMember = "Hilos2";
            }
            else if (cmbTabla.Text == "Proveedores")
            {
                column.DataSource = (columnasProveedores);
                cmbTabla.ValueMember = "Proveedores";
            }
            else if (cmbTabla.Text == "Pedidos")
            {
                column.DataSource = (columnasPedidos);
                cmbTabla.ValueMember = "Pedidos";
            }

        }
        private void GenerarConsulta()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["operador"].Value != null)
                    {
                        if (row.Cells["conector"].Value != null)
                        {
                            var column = row.Cells["columna"].Value.ToString();
                            var operador = row.Cells["Operador"].Value.ToString();
                            var valor = row.Cells["valor"].Value.ToString();
                            var conector = row.Cells["conector"].Value.ToString();

                            string lineaConsulta = " " + column + " " + operador + " '" + valor + "' " + conector;
                            Consulta += lineaConsulta;
                        }
                        else if (row.Cells["conector"].Value == null)
                        {
                            var column = row.Cells["columna"].Value.ToString();
                            var operador = row.Cells["Operador"].Value.ToString();
                            var valor = row.Cells["valor"].Value.ToString();
                            string lineaConsulta = " " + column + " " + operador + " '" + valor + "' ";
                            Consulta += lineaConsulta;
                        }

                    }
                }

            }
            catch (Exception)
            {
            }

        }

        private void cmbTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                CargarItemsCmb();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 2)
                {
                    Consulta = "UPDATE " + cmbTabla.ValueMember + " SET ";
                    GenerarConsulta();
                    userModel.editarTablas(Consulta);
                    MessageBox.Show("Se realizó correctamente el cambio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("Por favor verifica la sintaxis", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Por favor verifica la sintaxis", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }

}
