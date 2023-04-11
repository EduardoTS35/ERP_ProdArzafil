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
    public partial class frmCrearPedido : Form
    {
        string idHilo;
        string idColor;
        string idCaja;
        string idVendedor;
        string idCliente;
        UserModel userModel = new UserModel();
        public frmCrearPedido()
        {
            InitializeComponent();
        }

        private void frmCrearPedido_Load(object sender, EventArgs e)
        {
            tboxMaxLenght();
        }

        private void tboxMaxLenght()
        {
            tboxNumPedido.MaxLength = 12;
            tboxIdHilo.MaxLength = 10;
            tboxIdColor.MaxLength = 10;
            tboxIdCaja.MaxLength = 5;
            tboxCantidadKg.MaxLength = 6;
            tboxIdVendedor.MaxLength = 5;
            tboxIdCliente.MaxLength = 6;
            tboxFechaC.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        public void InsertarDatosDGV()
        {
            try
            {
                if (tboxNumPedido.Text != "" & tboxFechaC.Text != "" & dtFechaEntrega.Text != "" & tboxIdHilo.Text != "" & tboxIdColor.Text != "" & tboxIdCaja.Text != "" & tboxCantidadKg.Text != "" & tboxIdVendedor.Text != "" & tboxIdCliente.Text != "")
                {

                string FechaE = Convert.ToDateTime(dtFechaEntrega.Value).ToString("yyyy-MM-dd");
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = tboxNumPedido.Text;
                dataGridView1.Rows[n].Cells[1].Value = tboxFechaC.Text;
                dataGridView1.Rows[n].Cells[2].Value = FechaE;
                dataGridView1.Rows[n].Cells[3].Value = idHilo;
                dataGridView1.Rows[n].Cells[4].Value = idColor;
                dataGridView1.Rows[n].Cells[5].Value = idCaja;
                dataGridView1.Rows[n].Cells[6].Value = tboxCantidadKg.Text;
                dataGridView1.Rows[n].Cells[7].Value = idVendedor;
                dataGridView1.Rows[n].Cells[8].Value = idCliente;

                }
                else
                {
                        
                }
            }
            catch
            {
            }
            dataGridView1.ClearSelection();
            tboxIdColor.Clear();
            tboxIdHilo.Clear();
            tboxCantidadKg.Clear();
            tboxIdColor.Text = "";
            tboxCantidadKg.Text = "";
            tboxIdHilo.Text = "";
        }

        public void InsertarPedido()
        {
            try
            {
                List<UserModel> salidasLotes = new List<UserModel>();
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {
                    var detail = new UserModel()
                    {
                        IDPedido = Convert.ToInt32(dataGridViewRow.Cells[0].Value),
                        FechaC = DateTime.Now,
                        FechaE = Convert.ToDateTime(dtFechaEntrega.Value),
                        IdHilo = Convert.ToString(dataGridViewRow.Cells[3].Value),
                        IdColor = Convert.ToString(dataGridViewRow.Cells[4].Value),
                        IdCaja = Convert.ToInt32(dataGridViewRow.Cells[5].Value),
                        CantPedido = Convert.ToInt32(dataGridViewRow.Cells[6].Value),
                        IdVendedor = Convert.ToInt32(dataGridViewRow.Cells[7].Value),
                        IdCliente = Convert.ToInt32(dataGridViewRow.Cells[8].Value)
                    };
                    salidasLotes.Add(detail);
                }
                UserModel salidasLoteM = new UserModel();
                salidasLoteM.InsertarDatosMasivo(salidasLotes);
                userModel.CorregirBulk();
                MessageBox.Show("¡Se inserto correctamente la orden!","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                AppCache.ActualIdHilo = null;
                AppCache.ActualIdColor = null;
                AppCache.ActualIdCaja = null;
                AppCache.ActualIdVendedor = null;
                AppCache.ActualIdCliente = null;
            }
            catch
            {
                MessageBox.Show("Orden invalida, vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tboxIdCaja_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxCantidadKg_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxIdVendedor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxIdCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCatalogoHilos_Click(object sender, EventArgs e)
        {
            frmCatalogoHilos frmCatalogoHilos = new frmCatalogoHilos();
            frmCatalogoHilos.Show();
            timerHilos.Start();
        }

        private void btnCatalogoColores_Click(object sender, EventArgs e)
        {
            frmCatalogoColores frmCatalogoColores = new frmCatalogoColores();
            frmCatalogoColores.Show();
            timerColores.Start();
        }

        private void btnCatalogoCajas_Click(object sender, EventArgs e)
        {
            frmCatalogoCajas frmCatalogoCajas = new frmCatalogoCajas();
            frmCatalogoCajas.Show();
            timerCajas.Start();
        }

        private void btnCatalogoVendedores_Click(object sender, EventArgs e)
        {
            frmCatalogoVendedores frmCatalogoVendedores = new frmCatalogoVendedores();
            frmCatalogoVendedores.Show();
            timerVendedores.Start();
        }

        private void btnCatalogoClientes_Click(object sender, EventArgs e)
        {
            tboxIdCaja.Clear();
            frmCatalogoClientes frmCatalogoClientes = new frmCatalogoClientes();
            frmCatalogoClientes.Show();
            timerClientes.Start();
        }

        private void btnBorrarDatos_Click(object sender, EventArgs e)
        { 
            dataGridView1.Rows.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            InsertarDatosDGV();
        }

        private void btnCrearPedido_Click(object sender, EventArgs e)
        {
            InsertarPedido();
            dataGridView1.Rows.Clear();
        }

        private void timerVendedores_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualIdVendedor != null)
                {
                    btnCatalogoVendedores.Enabled = true;
                    tboxIdVendedor.Text = AppCache.ActualDescVendedor;
                    idVendedor = AppCache.ActualIdVendedor;
                    AppCache.ActualIdVendedor = null;
                    timerVendedores.Stop();
                }
                else
                    btnCatalogoVendedores.Enabled = false;
            }
            catch
            {
            }
        }

        private void timerClientes_Tick(object sender, EventArgs e)
        {
            try
            {              
                if (AppCache.ActualIdCliente != null)
                {
                    btnCatalogoClientes.Enabled = true;
                    tboxIdCliente.Text = AppCache.ActualDescCliente;
                    idCliente = AppCache.ActualIdCliente;
                    AppCache.ActualIdCliente = null;

                    timerClientes.Stop();
                }
                else
                    btnCatalogoClientes.Enabled = false;
            }
            catch
            {
            }
        }

        private void timerCajas_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualIdCaja != null)
                {
                    btnCatalogoCajas.Enabled = true;
                    tboxIdCaja.Text = AppCache.ActualIdCaja;
                    idCaja = AppCache.ActualIdCaja;
                    AppCache.ActualIdCaja = null;
                    AppCache.ActualDescCaja = null;
                    AppCache.ActualNumConos = null;
                    timerCajas.Stop();
                }
                else
                    btnCatalogoCajas.Enabled = false;
            }
            catch
            {
            }
        }

        private void timerHilos_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualIdHilo != null)
                {
                    btnCatalogoHilos.Enabled = true;
                    tboxIdHilo.Text = AppCache.ActualDescHilo;
                    idHilo = AppCache.ActualIdHilo;
                    AppCache.ActualDescHilo = null;
                    AppCache.ActualIdHilo = null;

                    timerHilos.Stop();
                }
                else
                    btnCatalogoHilos.Enabled = false;
            }
            catch
            {
            }
        }

        private void timerColores_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualIdColor != null)
                {
                    btnCatalogoColores.Enabled = true;
                    tboxIdColor.Text = AppCache.ActualDescColor;
                    idColor = AppCache.ActualIdColor;
                    AppCache.ActualDescColor = null;
                    AppCache.ActualIdColor = null;
                    timerColores.Stop();
                }
                else
                    btnCatalogoColores.Enabled = false;
            }
            catch
            {
            }
        }
    }
}
