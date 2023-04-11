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
using System.Runtime.InteropServices;

namespace Presentation
{
    public partial class frmSalidaSucursal : Form
    {
        string IdBolsa;
        string NumPedido;
        string IdHilo;
        string IdColor;
        string IdCaja;
        string PesoBruto;
        string PesoNeto;
        string NumConos;
        string statusProceso;
        string statusProcesoAnterior;
        UserModel userModel = new UserModel();
        int Fila = 0;

        CreaTicket Ticket1 = new CreaTicket();

        string IdHilo2;
        string IdColor2;
        string Precio;

        public frmSalidaSucursal()
        {
            InitializeComponent();
        }

        private void frmSalidaSucursal_Load(object sender, EventArgs e)
        {
            DefinirProceso();
            MostrarNuevoNRemision();
            MostrarCliente();
            this.reportViewer1.RefreshReport();
        }

        public void MostrarCliente()
        {
            cmbCliente.DataSource = userModel.MostrarClienteSucursal();
            cmbCliente.DisplayMember = "RazonSocial";
            cmbCliente.ValueMember = "IdCliente";
        }
        public void DefinirProceso()
        {
            if (UserLoginCache.Area == "Sucursal 1")
            {
                statusProceso = "13";
                statusProcesoAnterior = "12";
            }
            if (UserLoginCache.Area == "Sucursal 2")
            {
                statusProceso = "15";
                statusProcesoAnterior = "14";
            }
        }
        private void getReport()
        {
            Reporte reporte = new Reporte();
            if (textBox1.Text != "")
            {
                reporte.GetOrderRSucursal(Convert.ToInt32(textBox1.Text), 13);
            }
            else
            {
                reporte.GetOrderRSucursal(Convert.ToInt32(comboBox2.Text), 13);
            }

            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD()
        {
            ReporteDetails reporteD = new ReporteDetails();
            if (textBox1.Text != "")
            {
                reporteD.GetOrderDNumRemisionSucursal(Convert.ToInt32(textBox1.Text), 13);
            }
            else
            {
                reporteD.GetOrderDNumRemisionSucursal(Convert.ToInt32(comboBox2.Text), 13);
            }
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }

        public void MostrarDatosBolsa(string ID)
        {
            try
            {
                dataGridView2.DataSource = userModel.MostrarBolsaSucursales(ID, statusProcesoAnterior);
            }
            catch (Exception)
            {

            }
        }

        public void LeerDatos()
        {

            DataGridViewRow row = dataGridView2.Rows[Fila];
            IdBolsa = Convert.ToString(row.Cells["IDBolsa"].Value);
            NumPedido = Convert.ToString(row.Cells["NumPedido"].Value);
            IdHilo = Convert.ToString(row.Cells["IdHilo"].Value);
            IdColor = Convert.ToString(row.Cells["IdColor"].Value);
            IdCaja = Convert.ToString(row.Cells["LoteTenido"].Value);
            PesoBruto = Convert.ToString(row.Cells["PesoBruto"].Value);
            PesoNeto = Convert.ToString(row.Cells["PesoNeto"].Value);
            NumConos = Convert.ToString(row.Cells["NumConos"].Value);
            AppCache.IdBolsa = Convert.ToInt32(IdBolsa);

        }

        public void MostrarNuevoNRemision()
        {
            try
            {
                comboBox2.DataSource = userModel.MostrarLoteDeVentaSig();
                comboBox2.DisplayMember = "LOTEVENTA";
                if (comboBox2.Text == "")
                    comboBox2.Text = "1";
            }
            catch (Exception)
            {

            }
        }

        private void CicloRegistroDgvVentas()
        {
            try
            {
                dgvVenta.Rows.Add(textBox3.Lines.Length);

                for (int lines = 0; lines < textBox3.Lines.Length; lines++)
                {
                    try
                    {
                        MostrarDatosBolsa(textBox3.Lines[lines]);
                        LeerDatos();
                        if (IdHilo != IdHilo2)
                        {
                            Precio = Microsoft.VisualBasic.Interaction.InputBox(
                                        "Introduce el precio del producto (" + IdHilo + "," + IdColor + "): ",
                                        "Precio del Producto",
                                        "0"
                                        );
                        }
                        InsertarDatos(lines);
                    }
                    catch
                    {
                        MessageBox.Show("La Bolsa de la línea número: " + lines + " no se encontró", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

                foreach (DataGridViewRow row in dgvVenta.Rows)
                {
                    IdBolsa = Convert.ToString(row.Cells[0].Value);
                    NumPedido = Convert.ToString(row.Cells[8].Value);
                    IdHilo = Convert.ToString(row.Cells[2].Value);
                    IdColor = Convert.ToString(row.Cells[3].Value);
                    IdCaja = Convert.ToString(row.Cells[6].Value);
                    PesoBruto = Convert.ToString(row.Cells[7].Value);
                    PesoNeto = Convert.ToString(row.Cells[4].Value);
                    NumConos = Convert.ToString(row.Cells[5].Value);
                    Precio = Convert.ToString(row.Cells[1].Value);
                    if (textBox1.Text != "")
                    {
                        userModel.InsertarSalidaSucursales(IdBolsa, NumPedido, IdHilo, IdColor, IdCaja, PesoBruto, PesoNeto, NumConos, statusProceso, textBox1.Text, Precio, Convert.ToInt32(cmbCliente.SelectedValue));
                    }
                    else
                        userModel.InsertarSalidaSucursales(IdBolsa, NumPedido, IdHilo, IdColor, IdCaja, PesoBruto, PesoNeto, NumConos, statusProceso, comboBox2.Text, Precio, Convert.ToInt32(cmbCliente.SelectedValue));
                }
                textBox3.Clear();

                MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }

        }


        private void InsertarDatos(int line)
        {

            dgvVenta.Rows[line].Cells[0].Value = IdBolsa;
            dgvVenta.Rows[line].Cells[8].Value = NumPedido;
            dgvVenta.Rows[line].Cells[2].Value = IdHilo;
            dgvVenta.Rows[line].Cells[3].Value = IdColor;
            dgvVenta.Rows[line].Cells[6].Value = IdCaja;
            dgvVenta.Rows[line].Cells[7].Value = PesoBruto;
            dgvVenta.Rows[line].Cells[4].Value = PesoNeto;
            dgvVenta.Rows[line].Cells[5].Value = NumConos;
            dgvVenta.Rows[line].Cells[1].Value = Convert.ToString(Convert.ToDouble(Precio) * Convert.ToDouble(PesoNeto));
            dgvVenta.Rows[line].Cells[9].Value = Precio;
            IdHilo2 = IdHilo;
            IdColor2 = IdColor;
        }

        private void ImprimirTicket()
        {
            string descripcion;
            double cantidad;
            double precio;
            double totalU;
            double total = 0;
            Ticket1.TextoIzquierda(UserLoginCache.FirstName + " " + UserLoginCache.LastName);
            Ticket1.TextoCentro("Venta mostrador"); // imprime en el centro "Venta mostrador"
            Ticket1.TextoExtremos(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm"));
            Ticket1.EncabezadoVenta(); // imprime encabezados
            Ticket1.LineasGuion(); // imprime una linea de guiones
            foreach (DataGridViewRow row in dgvVenta.Rows)
            {
                descripcion = Convert.ToString(row.Cells[1].Value);
                cantidad = Convert.ToDouble(row.Cells[6].Value);
                precio = Convert.ToDouble(row.Cells[9].Value);
                totalU = Convert.ToDouble(row.Cells[1].Value);

                Ticket1.AgregaArticulo(descripcion, cantidad, precio, totalU); //imprime una linea de descripcion
                total = +totalU;
            }

            Ticket1.LineasTotales(); // imprime linea
            Ticket1.AgregaTotales("Total", total); // imprime linea con total
            Ticket1.LineasGuion(); // imprime una linea de guiones
            Ticket1.CortaTicket(); // corta el ticket
        }

        private void CrearColumnas()
        {

        }
        private void LimpiarDgv()
        {
            DataTable dt = (DataTable)dataGridView2.DataSource;
            dt.Clear();
            dgvVenta.Columns.Clear();
            dgvVenta.Columns.Add("CodBolsa","Núm. Bolsa");
            dgvVenta.Columns.Add("pr", "Precio");
            dgvVenta.Columns.Add("CodHilo", "Cod. Hilo");
            dgvVenta.Columns.Add("CodColor", "Cod. Color");
            dgvVenta.Columns.Add("PN", "Peso Neto");
            dgvVenta.Columns.Add("Conos", "Núm. Conos");
            dgvVenta.Columns.Add("Caja", "Núm. Caja");
            dgvVenta.Columns.Add("PB", "Peso Bruto");
            dgvVenta.Columns.Add("idPedido", "Núm. Pedido");
            dgvVenta.Columns.Add("PrecioU", "Precio Unitario");
        }

        private void btnGuardarEM_Click(object sender, EventArgs e)
        {
            CicloRegistroDgvVentas();
            userModel.eliminar_RegistroDuplicado();
            getReport();
            getReportD();
            this.reportViewer1.RefreshReport();
            MostrarNuevoNRemision();
            LimpiarDgv();
        }

        private void btnImprimirNuevaEtiqueta_Click(object sender, EventArgs e)
        {
            ImprimirTicket();
        }


        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void timerNumRemision_Tick(object sender, EventArgs e)
        {
            MostrarNuevoNRemision();
        }
    }
}
