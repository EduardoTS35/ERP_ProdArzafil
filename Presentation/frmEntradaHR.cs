using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Commun.Cache;
using System.IO.Ports;
using BarcodeLib;
using System.Drawing.Printing;

namespace Presentation
{
    public partial class frmEntradaHR : Form
    {
        UserModel userModel = new UserModel();

        string hilo;
        string IdBolsa;
        string NumPedido;
        string IdHilo;
        string IdColor;
        string color;
        string LoteHilatura;
        string LoteT;
        string IdCaja;
        string PesoBruto;
        string PesoNeto;
        string NumConos;
        string Malla;
        string ColorCono;
        string dataIN;
        string RazonSocial;
        string titulo;

        double pesoBolsa;
        double pesoCono;
        double tara;
        double pesoN;
        double pesoB;

   

        public frmEntradaHR()
        {
            InitializeComponent();
            MostrarEntradasHR();
        }


        public void MostrarEntradasHR()
        {
            try
            {
                dataGridView1.DataSource = userModel.MostrarEntradasHR();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha ingresado ningun valor en la base de datos: " + ex);
            }

        }

        public void MostrarDatosBolsa(string ID)
        {
            try
            {
                dataGridView2.DataSource = userModel.MostrarBolsaHR(ID);
            }
            catch (Exception)
            {

            }
        }

        public void LeerDatos()
        {
            DataGridViewRow row = dataGridView2.Rows[0];

            hilo = Convert.ToString(row.Cells["Hilo"].Value);
            IdBolsa = Convert.ToString(row.Cells["IDBolsa"].Value);
            NumPedido=Convert.ToString(row.Cells["NumPedido"].Value);
            IdHilo = Convert.ToString(row.Cells["IdHilo"].Value);
            IdColor = Convert.ToString(row.Cells["IdColor"].Value);
            color = Convert.ToString(row.Cells["Color"].Value);
            LoteHilatura = Convert.ToString(row.Cells["LoteHilatura"].Value);
            LoteT = Convert.ToString(row.Cells["LoteTenido"].Value);
            IdCaja = Convert.ToString(row.Cells["IdCaja"].Value);
            PesoBruto = Convert.ToString(row.Cells["PesoBruto"].Value);
            PesoNeto = Convert.ToString(row.Cells["PesoNeto"].Value);
            NumConos = Convert.ToString(row.Cells["NumConos"].Value);
            Malla = Convert.ToString(row.Cells["Malla"].Value);
            ColorCono = Convert.ToString(row.Cells["ColorCono"].Value);
            RazonSocial= Convert.ToString(row.Cells["RazonSocial"].Value);
            titulo = Convert.ToString(row.Cells["Titulo"].Value);
        }


        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cmbComport.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = (StopBits)1;
                serialPort1.Parity = (Parity)0;
                serialPort1.Open();
                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;
                timerBascula.Start();
                AppCache.StatusBascula = 1;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConectar.Enabled = true;
                btnDesconectar.Enabled = true;
                AppCache.StatusBascula = 0;
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            dataIN = "Desconectado";
            if (dataIN == "Desconectado")
            {
                serialPort1.Close();
                btnConectar.Enabled = true;
                timerBascula.Stop();
                AppCache.StatusBascula = 0;
            }
            else
            {
                MessageBox.Show("Por favor intentelo nuevamete");
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadExisting();
        }

        private void timerBascula_Tick(object sender, EventArgs e)
        {
            string trimDataIn = dataIN.Remove(0, 7);
            textBox1.Text = trimDataIn.Remove(6);
        }

        private void timerCatalogoC_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualDescCaja != null)
                {
                    btnCatalogoC.Enabled = true;
                    tboxNumConos.Enabled = true;
                    AppCache.ActualDescCaja = null;
                    timerCatalogoC.Stop();
                }
                else
                    btnCatalogoC.Enabled = false;
            }
            catch
            {
            }
        }

        private void tboxNumConos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pesoBolsa = Convert.ToDouble(AppCache.ActualPesoBolsa);
                pesoCono = Convert.ToDouble(tboxNumConos.Text) * (Convert.ToDouble(AppCache.ActualPesoCono));
                tara = Math.Round((pesoCono + pesoBolsa)/1000,3);
            }
            catch
            {

            }
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
            e.Graphics.DrawString(hilo + " " + titulo, fontT, Brushes.Black, new RectangleF(7, largo, ancho, 40));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("Lote Teñido:  " + LoteT, ftext2, Brushes.Black, new RectangleF(12, largo += 22, ancho, 22));
            e.Graphics.DrawString("Razón Social: " + RazonSocial, ftext, Brushes.Black, new RectangleF(12, 145, ancho, 22));
            e.Graphics.DrawString("Cod.Color: " + IdColor, ftext, Brushes.Black, new RectangleF(270, 92, ancho, 22));
            e.Graphics.DrawString("Color: " + color, ftext, Brushes.Black, new RectangleF(270, 122, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Núm.Conos:  " + tboxNumConos.Text, ftext, Brushes.Black, new RectangleF(12, 240, ancho, 22));
            e.Graphics.DrawString("Núm.Pedido:  " + NumPedido, ftext, Brushes.Black, new RectangleF(12, 190, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bruto: " + Math.Round(pesoB,3) + " KG", font, Brushes.Black, new RectangleF(260, 200, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Neto: " + Math.Round(pesoN,3) + " KG", font, Brushes.Black, new RectangleF(260, 250, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bolsa: " + IdBolsa, ftext, Brushes.Black, new RectangleF(12, 285, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), ftext, Brushes.Black, new RectangleF(12, 335, ancho, 25));
            e.Graphics.DrawImage(img, 260, 310);
        }

        private void frmEntradaHR_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                pesoB = Convert.ToDouble(textBox1.Text);
                pesoN = pesoB - tara;

                try
                {
                    if (IdBolsa != "")
                    {
                        LeerDatos();
                        userModel.InsertarEntradasTRB(IdBolsa, NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, AppCache.ActualIdCaja, Convert.ToString(Math.Round(pesoB, 3)), Convert.ToString(Math.Round(pesoN, 3)), tboxNumConos.Text, "7", Malla, ColorCono);
                        MostrarEntradasHR();
                        textBox3.Clear();
                        MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        PageSettings pageSettings = new PageSettings();
                        PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                        printDocument1.PrinterSettings = ps;
                        pageSettings.PaperSize = paper;
                        printDocument1.PrintPage += Imprimir;
                        printDocument1.Print();
                    }
                    else
                    {
                        MessageBox.Show("Por favor selecciona una bolsa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se insertaron los datos por: " + ex);
                }
            }

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                {
                    MostrarDatosBolsa(textBox3.Text);
                    LeerDatos();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnCatalogoC_Click(object sender, EventArgs e)
        {
            frmCatalogoCajas frm = new frmCatalogoCajas();
            frm.Show();
            timerCatalogoC.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AppCache.ActualIdCaja != "")
            {
                pesoB = Convert.ToDouble(textBox1.Text);
                pesoN = pesoB - tara;

                try
                {
                    if (IdBolsa != "")
                    {
                        LeerDatos();
                        userModel.InsertarEntradasTRB(IdBolsa, NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, Convert.ToString(Math.Round(pesoB,3)), Convert.ToString(Math.Round(pesoN, 3)), tboxNumConos.Text, "7", Malla, ColorCono);
                        MostrarEntradasHR();
                        textBox3.Clear();
                        MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        PageSettings pageSettings = new PageSettings();
                        PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                        printDocument1.PrinterSettings = ps;
                        pageSettings.PaperSize = paper;
                        printDocument1.PrintPage += Imprimir;
                        printDocument1.Print();
                        AppCache.ActualIdCaja = null;
                        AppCache.ActualDescCaja = null;

                    }
                    else
                    {
                        MessageBox.Show("Por favor selecciona una bolsa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se insertaron los datos por: " + ex);
                }
            }
            else
                MessageBox.Show("Por favor complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void frmEntradaHR_Load(object sender, EventArgs e)
        {
            AppCache.ActualIdCaja = null;
            AppCache.ActualDescCaja = null;
            string[] ports = SerialPort.GetPortNames();
            cmbComport.Items.AddRange(ports);
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                pesoB = Convert.ToDouble(textBox1.Text);
                pesoN = pesoB - tara;

                try
                {
                    if (IdBolsa != "")
                    {
                        LeerDatos();
                        userModel.InsertarEntradasTRB(IdBolsa, NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, AppCache.ActualIdCaja, Convert.ToString(Math.Round(pesoB, 3)), Convert.ToString(Math.Round(pesoN, 3)), tboxNumConos.Text, "7", Malla, ColorCono);
                        MostrarEntradasHR();
                        textBox3.Clear();
                        MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        PageSettings pageSettings = new PageSettings();
                        PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                        printDocument1.PrinterSettings = ps;
                        pageSettings.PaperSize = paper;
                        printDocument1.PrintPage += Imprimir;
                        printDocument1.Print();
                    }
                    else
                    {
                        MessageBox.Show("Por favor selecciona una bolsa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se insertaron los datos por: " + ex);
                }
            }
        }
    }
}
