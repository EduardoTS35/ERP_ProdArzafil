using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using Commun.Cache;
using Domain;

namespace Presentation
{
    public partial class frmConfigHR : Form
    {
        UserModel userModel = new UserModel();
        bool statusSeleccion;
        int statusBolsa;

        string hilo;
        string IdBolsa;
        string NumPedido;
        string IdHilo;
        string IdColor;
        string color;
        string LoteT;
        string PesoBruto;
        string PesoNeto;
        string NumConos;
        string Malla;
        string ColorCono;
        string RazonSocial;
        string titulo;
        public frmConfigHR()
        {
            InitializeComponent();
        }

        public void MostrarDatos()
        {
            if (cmbSeleccion.Text == "Entradas")
            {
                dataGridView1.DataSource = userModel.MostrarEntradasHR();
                statusBolsa = 7;
            }
            else if (cmbSeleccion.Text == "Salidas")
            {
                dataGridView1.DataSource = userModel.MostrarBolsas("8");
                statusBolsa = 8;
            }
        }

        public void SeleccionarMovimiento()
        {
            try
            {
                statusSeleccion = true;
                tboxIdBolsa.Text = dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString();
                tboxIdHilo.Text = dataGridView1.CurrentRow.Cells["IdHilo"].Value.ToString();
                tboxLoteHilatura.Text = dataGridView1.CurrentRow.Cells["LoteTenido"].Value.ToString();
                tboxIdCaja.Text = dataGridView1.CurrentRow.Cells["IdColor"].Value.ToString();
                tboxMalla.Text = dataGridView1.CurrentRow.Cells["Malla"].Value.ToString();
                tboxColorCono.Text = dataGridView1.CurrentRow.Cells["ColorCono"].Value.ToString();
                tboxPesoBruto.Text = dataGridView1.CurrentRow.Cells["PesoBruto"].Value.ToString();
                tboxPesoNeto.Text = dataGridView1.CurrentRow.Cells["PesoNeto"].Value.ToString();
                tboxNumConos.Text = dataGridView1.CurrentRow.Cells["NumConos"].Value.ToString();

                hilo = Convert.ToString(dataGridView1.CurrentRow.Cells["Hilo"].Value);
                IdBolsa = Convert.ToString(dataGridView1.CurrentRow.Cells["IDBolsa"].Value);
                NumPedido = Convert.ToString(dataGridView1.CurrentRow.Cells["NumPedido"].Value);
                RazonSocial = Convert.ToString(dataGridView1.CurrentRow.Cells["RazonSocial"].Value);
                IdHilo = Convert.ToString(dataGridView1.CurrentRow.Cells["IdHilo"].Value);
                IdColor = Convert.ToString(dataGridView1.CurrentRow.Cells["IdColor"].Value);
                color = Convert.ToString(dataGridView1.CurrentRow.Cells["Color"].Value);
                LoteT = Convert.ToString(dataGridView1.CurrentRow.Cells["LoteTenido"].Value);
                PesoBruto = Convert.ToString(dataGridView1.CurrentRow.Cells["PesoBruto"].Value);
                PesoNeto = Convert.ToString(dataGridView1.CurrentRow.Cells["PesoNeto"].Value);
                NumConos = Convert.ToString(dataGridView1.CurrentRow.Cells["NumConos"].Value);
                Malla = Convert.ToString(dataGridView1.CurrentRow.Cells["Malla"].Value);
                ColorCono = Convert.ToString(dataGridView1.CurrentRow.Cells["ColorCono"].Value);
                titulo= Convert.ToString(dataGridView1.CurrentRow.Cells["Titulo"].Value);


                btnReimprimir.Enabled = true;
                btnReimprimir.Visible = true;
            }
            catch
            {
                MessageBox.Show("Por favor selecciona una opción válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void DeshacerMovimiento()
        {
            if (statusSeleccion == true)
            {
                try
                {
                    userModel.ActualizarStatusBolsa(tboxIdBolsa.Text, Convert.ToString(statusBolsa - 1));
                    userModel.EliminarMovimientoReporteBolsa(tboxIdBolsa.Text, Convert.ToString(statusBolsa));
                    MessageBox.Show("Se realizo correctamente el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos();
                    LimpiarTbox();
                    statusSeleccion = false;
                }
                catch
                {
                    MessageBox.Show("Favor de comunicarse con soporte técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarTbox();
                    statusSeleccion = false;
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un movimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarTbox();
                statusSeleccion = false;
            }

        }

        public void LimpiarTbox()
        {
            tboxColorCono.Clear();
            tboxIdBolsa.Clear();
            tboxIdCaja.Clear();
            tboxIdHilo.Clear();
            tboxLoteHilatura.Clear();
            tboxMalla.Clear();
            tboxNumConos.Clear();
            tboxPesoBruto.Clear();
            tboxPesoNeto.Clear();
        }

        private void cmbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarMovimiento();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DeshacerMovimiento();
        }

        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Barcode barcode = new Barcode();
            barcode.IncludeLabel = false;
            barcode.Alignment = AlignmentPositions.CENTER;
            barcode.LabelFont = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
            Image img = barcode.Encode(TYPE.CODE128, IdBolsa, Color.Black, Color.White, 240, 60);

            Image logo = Properties.Resources.Outlook;
            //Image logo = Image.FromFile(@"C:\Users\eduar\source\repos\Erp\Erp\Presentation\Resources\Outlook.jpg");

            PageSettings pageSettings = new PageSettings();
            PaperSize paper = new PaperSize("Etiqueta", 404, 551);
            pageSettings.PaperSize = paper;
            Font fontT = new Font("Arial", 18, FontStyle.Bold);
            Font font = new Font("Arial", 22, FontStyle.Bold);
            Font fontP = new Font("Arial", 16, FontStyle.Bold);
            Font ftext = new Font("Arial", 12, FontStyle.Bold);
            Font ftext2 = new Font("Arial", 14, FontStyle.Bold);
            Font fontS = new Font("Arial", 5);
            Pen blackpen = new Pen(Color.Black, 3);
            int ancho = 900;
            int largo = 20;

            e.Graphics.DrawImage(logo, new Rectangle(370, 15, 180, 60));
            e.Graphics.DrawRectangle(blackpen, 5, 5, 543, 375);
            e.Graphics.DrawRectangle(blackpen, 257, 190, 262, 100);
            e.Graphics.DrawLine(blackpen, 256, 240, 519, 240);            
            e.Graphics.DrawString(hilo+" "+titulo, fontT, Brushes.Black, new RectangleF(7, largo, ancho, 40));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("Lote Teñido:  " + LoteT, ftext2, Brushes.Black, new RectangleF(12, largo += 22, ancho, 22));
            e.Graphics.DrawString("Razón Social: " + RazonSocial, ftext, Brushes.Black, new RectangleF(12, 145, ancho, 22));
            e.Graphics.DrawString("Cod.Color: " + IdColor, ftext, Brushes.Black, new RectangleF(270, 92, ancho, 22));
            e.Graphics.DrawString("Color: " + color, ftext, Brushes.Black, new RectangleF(270, 122, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Núm.Conos:  "+NumConos, ftext, Brushes.Black, new RectangleF(12, 240, ancho, 22));
            e.Graphics.DrawString("Núm.Pedido:  " + NumPedido, ftext, Brushes.Black, new RectangleF(12, 190, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bruto: " + PesoBruto + " KG", font, Brushes.Black, new RectangleF(260, 200, ancho, 40));    
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Neto: " + PesoNeto + " KG", font, Brushes.Black, new RectangleF(260, 250, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bolsa: " + IdBolsa, ftext, Brushes.Black, new RectangleF(12, 285, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), ftext, Brushes.Black, new RectangleF(12, 335, ancho, 25));
            e.Graphics.DrawImage(img, 260, 310);
            
            e.Graphics.RotateTransform(180);
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToString("dd-MM-yyyy hh:mm"), ftext, Brushes.Black, new RectangleF(7, 170, ancho, 22));
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            PageSettings pageSettings = new PageSettings();
            PaperSize paper = new PaperSize("Etiqueta", 394, 551);
            printDocument1.PrinterSettings = ps;
            pageSettings.PaperSize = paper;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
            LimpiarForm();
        }
        public void LimpiarForm()
        {
            tboxIdBolsa.Clear();
            tboxIdHilo.Clear();
            tboxLoteHilatura.Clear();
            tboxIdCaja.Clear();
            tboxMalla.Clear();
            tboxColorCono.Clear();
            tboxNumConos.Clear();
            tboxPesoBruto.Clear();
            tboxPesoNeto.Clear();
            btnReimprimir.Enabled = false;
            btnReimprimir.Visible = false;
        }

        private void frmConfigHR_Load(object sender, EventArgs e)
        {
            btnReimprimir.Enabled = false;
            btnReimprimir.Visible = false;
        }
    }
}
