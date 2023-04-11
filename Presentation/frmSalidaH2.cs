using Commun.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using BarcodeLib;
using Domain;

namespace Presentation
{
    public partial class frmSalidaH2 : Form
    {
        UserModel userModel = new UserModel();
        string dataIN;
        string statusProceso = "2";



        public frmSalidaH2()
        {
            InitializeComponent();
        }
        private void frmEntradaH_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cmbComport.Items.AddRange(ports);
            MostrarId();
        }

        private void MostrarId()
        {
            cmbIdBolsa.DataSource = userModel.MostrarIdBolsa();
            cmbIdBolsa.DisplayMember = "BolsaSig";
            if (cmbIdBolsa.Text != "")
            {
            }
            else
                cmbIdBolsa.Text = "1";
        }

        private void ReiniciarProceso()
        {
            lblPesoB.Text = "0";
            lblPesoN.Text = "0";
        }

        private void ReiniciarCambioDeHilo()
        {
            cmbMalla.Text = null;
            cmbMalla.Enabled = false;

            cmbColorCono.Text = null;
            cmbColorCono.Enabled = false;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            tboxNumLote.Text = null;
            tboxNumConos.Text = null;

            lblDescCaja.Text = "Descripción";
            lblPesoCono.Text = "0";
            lblMultConos.Text = "0";
            lblBolsa.Text = "0";
            lblTara.Text = "0";

            lblTara2.Text = "0";
            lblPesoB.Text = "0";
            lblPesoN.Text = "0";

            AppCache.ActualPesoCono="0";
            AppCache.ActualPesoBolsa="0";
        }

        private void ReiniciarCambioDeCaja()
        {
            cmbMalla.Text = null;
            cmbMalla.Enabled = false;

            cmbColorCono.Text = null;
            cmbColorCono.Enabled = false;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            tboxNumLote.Text = null;
            tboxNumConos.Text = null;

            lblPesoCono.Text = "0";
            lblMultConos.Text = "0";
            lblBolsa.Text = "0";
            lblTara.Text = "0";

            lblTara2.Text = "0";
            lblPesoB.Text = "0";
            lblPesoN.Text = "0";
        }


        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cmbComport.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = (StopBits)1;
                serialPort1.Parity = 0;
                serialPort1.Open();
                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;
                //timerBascula.Start();
                AppCache.StatusBascula = 1;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serialPort1.Close();
                dataIN = "Desconectado";
                btnConectar.Enabled = true;
                //timerBascula.Stop();
                AppCache.StatusBascula = 0;
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            dataIN = "Desconectado";
            if (dataIN == "Desconectado")
            {
                serialPort1.Close();
                serialPort1.Dispose();
                btnConectar.Enabled = true;
                timerBascula.Stop();
                AppCache.StatusBascula = 0;
            }
            else
            {
                MessageBox.Show("Por favor intentelo nuevamete");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }

        private void ShowData(object sender, EventArgs e)
        {
            try
            {
                string trimDataIn = dataIN.Remove(0, 7);
                tboxBascula.Text = trimDataIn.Remove(6);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serialPort1.Close();
                btnConectar.Enabled = true;
                //timerBascula.Stop();
                AppCache.StatusBascula = 0;
            }
        }

        private void timerBascula_Tick(object sender, EventArgs e)
        {
            try
            {
                string trimDataIn = dataIN.Remove(0, 7);
                tboxBascula.Text = trimDataIn.Remove(6);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serialPort1.Close();
                btnConectar.Enabled = true;
                timerBascula.Stop();
                AppCache.StatusBascula = 0;
            }
            
        }

        private void btnCatalogoHilos_Click(object sender, EventArgs e)
        {
            frmCatalogoHilos frmCatalogoHilos = new frmCatalogoHilos();
            frmCatalogoHilos.Show();
            timerCatalogoH.Start();
        }

        private void btnCatalogoCajas_Click(object sender, EventArgs e)
        {
            frmCatalogoCajas frm = new frmCatalogoCajas();
            frm.Show();
            timerCatalogoC.Start();
        }

        private void timerCatalogoH_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualDescHilo != null)
                {
                    ReiniciarCambioDeHilo();
                    btnCatalogoHilos.Enabled = true;
                    lblDescHilo.Text = AppCache.ActualDescHilo;
                    AppCache.ActualDescHilo = null;
                    timerCatalogoH.Stop();
                    
                }
                else
                    btnCatalogoHilos.Enabled = false;
            }
            catch
            {
            }
        }

        private void timerCatalogoC_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualDescCaja != null)
                {
                    ReiniciarCambioDeCaja();
                    btnCatalogoCajas.Enabled = true;
                    lblDescCaja.Text = AppCache.ActualDescCaja;
                    AppCache.ActualDescCaja = null;
                    timerCatalogoC.Stop();
                }
                else
                    btnCatalogoCajas.Enabled = false;
            }
            catch
            {
            }
        }

        private void lblDescCaja_TextChanged(object sender, EventArgs e)
        {
            lblPesoCono.Text = AppCache.ActualPesoCono;
            lblBolsa.Text = AppCache.ActualPesoBolsa;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double pesoCono = Convert.ToDouble(lblPesoCono.Text);
                double pesoBolsa = Convert.ToDouble(lblBolsa.Text);

                double multiConos = Convert.ToDouble(tboxNumConos.Text) * pesoCono;
                lblMultConos.Text = Convert.ToString(Math.Round(multiConos, 3));
                double tara = Math.Round((multiConos + pesoBolsa) / 1000, 3);
                lblTara.Text = Convert.ToString(tara);
                lblTara2.Text = Convert.ToString(tara);
            }
            catch
            {

            }
           

        }

        private void frmEntradaH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                double pesoBruto = Convert.ToDouble(tboxBascula.Text);
                double tara = Convert.ToDouble(lblTara2.Text);
                double pesoNeto = pesoBruto - tara;

                lblPesoB.Text = tboxBascula.Text;
                lblPesoN.Text = Convert.ToString(Math.Round(pesoNeto, 3));

                try
                {
                    if (checkBox1.Checked == false & checkBox2.Checked == false)
                    {
                        MessageBox.Show("Por favor elige un color de cono o tipo de malla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (lblDescHilo.Text != "Descripción" & lblDescCaja.Text != "Descripción" & tboxNumLote.Text != "" & tboxNumConos.Text != "" & AppCache.ActualDescCaja != "" & lblPesoB.Text != "0")
                        {
                            if (cmbIdBolsa.Text != "")
                            {
                                if (checkBox3.CheckState == CheckState.Unchecked)
                                {
                                    userModel.InsertarSalidasH(cmbIdBolsa.Text, AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, statusProceso, cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                    userModel.InsertarSalidasHReporte(cmbIdBolsa.Text, AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, statusProceso, cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                    LeerResultadosComponentes();
                                    MessageBox.Show("Se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    printDocument1 = new PrintDocument();
                                    PrinterSettings ps = new PrinterSettings();
                                    PageSettings pageSettings = new PageSettings();
                                    PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                                    printDocument1.PrinterSettings = ps;
                                    pageSettings.PaperSize = paper;
                                    printDocument1.PrintPage += Imprimir;
                                    printDocument1.Print();
                                    ReiniciarProceso();
                                    MostrarId();
                                }
                                else if (checkBox3.CheckState == CheckState.Checked)
                                {
                                    if (userModel.ValidarCrudoAlmacenFinal(Convert.ToInt32(tboxNumPedido.Text), AppCache.ActualIdHilo, tboxColor.Text) == true)
                                    {
                                        userModel.InsertarSalidasH(cmbIdBolsa.Text, tboxNumPedido.Text, AppCache.ActualIdHilo, tboxColor.Text, tboxNumLote.Text, tboxLoteT.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, "9", cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                        userModel.InsertarSalidasHReporte(cmbIdBolsa.Text, AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, "9", cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                        LeerResultadosComponentes();
                                        MessageBox.Show("Se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        printDocument1 = new PrintDocument();
                                        PrinterSettings ps = new PrinterSettings();
                                        PageSettings pageSettings = new PageSettings();
                                        PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                                        printDocument1.PrinterSettings = ps;
                                        pageSettings.PaperSize = paper;
                                        printDocument1.PrintPage += Imprimir;
                                        printDocument1.Print();
                                        ReiniciarProceso();
                                        MostrarId();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El pedido no coincide.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }

                                }

                            }
                            else
                            {
                                if (checkBox3.CheckState == CheckState.Unchecked)
                                {
                                    userModel.InsertarSalidasH("1", AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, statusProceso, cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                    userModel.InsertarSalidasHReporte("1", tboxNumPedido.Text, AppCache.ActualIdHilo, tboxColor.Text, tboxNumLote.Text, tboxLoteT.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, statusProceso, cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                    LeerResultadosComponentes();
                                    MessageBox.Show("Se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    printDocument1 = new PrintDocument();
                                    PrinterSettings ps = new PrinterSettings();
                                    PageSettings pageSettings = new PageSettings();
                                    PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                                    printDocument1.PrinterSettings = ps;
                                    pageSettings.PaperSize = paper;
                                    printDocument1.PrintPage += Imprimir;
                                    printDocument1.Print();
                                    ReiniciarProceso();
                                    MostrarId();
                                }
                                else if (checkBox3.CheckState == CheckState.Checked)
                                {
                                    if (userModel.ValidarCrudoAlmacenFinal(Convert.ToInt32(tboxNumPedido.Text), AppCache.ActualIdHilo, tboxColor.Text) == true)
                                    {
                                        userModel.InsertarSalidasH("1", AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, "9", cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                        userModel.InsertarSalidasHReporte("1", AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, "9", cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                        LeerResultadosComponentes();
                                        MessageBox.Show("Se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        printDocument1 = new PrintDocument();
                                        PrinterSettings ps = new PrinterSettings();
                                        PageSettings pageSettings = new PageSettings();
                                        PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                                        printDocument1.PrinterSettings = ps;
                                        pageSettings.PaperSize = paper;
                                        printDocument1.PrintPage += Imprimir;
                                        printDocument1.Print();
                                        ReiniciarProceso();
                                        MostrarId();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El pedido no coincide.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }

                            }

                        }
                        else
                        {
                            MessageBox.Show("Por favor completa todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se insertaron los datos por: " + ex);
                }
            }
        }

        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Barcode barcode = new Barcode();
            barcode.IncludeLabel = false;
            barcode.Alignment = AlignmentPositions.CENTER;
            barcode.LabelFont = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
            Image img = barcode.Encode(TYPE.CODE128, cmbIdBolsa.Text, Color.Black, Color.White, 240, 60);
            PageSettings pageSettings = new PageSettings();
            PaperSize paper = new PaperSize("Etiqueta", 404, 551);
            pageSettings.PaperSize = paper;
            Font fontT = new Font("Arial", 22, FontStyle.Bold);
            Font font = new Font("Arial", 22, FontStyle.Bold);
            Font fontP = new Font("Arial", 16, FontStyle.Bold);
            Font ftext = new Font("Arial", 13, FontStyle.Bold);
            Font fontS = new Font("Arial", 5);
            Pen blackpen = new Pen(Color.Black, 3);
            int ancho = 900;
            int largo = 20;

            e.Graphics.DrawRectangle(blackpen, 5, 5, 543, 375);
            e.Graphics.DrawRectangle(blackpen, 257, 53, 262, 228);
            e.Graphics.DrawLine(blackpen, 256, 170, 519, 170);
            e.Graphics.DrawString(lblDescHilo.Text+" "+AppCache.ActualTituloHilo, fontT, Brushes.Black, new RectangleF(7, largo, ancho, 40));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("Cod. Hilo: " + AppCache.ActualIdHilo, ftext, Brushes.Black, new RectangleF(12, largo += 6, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bruto: " + Math.Round(Convert.ToDouble(lblPesoB.Text),3)  + " KG", font, Brushes.Black, new RectangleF(263, largo = 97, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Lote:  " + tboxNumLote.Text, ftext, Brushes.Black, new RectangleF(12, 115, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Neto: " + Math.Round(Convert.ToDouble(lblPesoN.Text), 3) + " KG", font, Brushes.Black, new RectangleF(260, 200, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Núm.Conos: " + tboxNumConos.Text, ftext, Brushes.Black, new RectangleF(12, 160, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));  
            e.Graphics.DrawString("Bolsa: " + cmbIdBolsa.Text, ftext, Brushes.Black, new RectangleF(12, 205, ancho, 25));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Malla o Cono:  " + cmbMalla.Text+cmbColorCono.Text, ftext, Brushes.Black, new RectangleF(12, 250, ancho, 25));
            e.Graphics.DrawString("Turno:  " + cmbTurno.Text, ftext, Brushes.Black, new RectangleF(12, 290, ancho, 25));
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), ftext, Brushes.Black, new RectangleF(12, 330, ancho, 25));
            e.Graphics.DrawImage(img, 260, 310);
            e.Graphics.RotateTransform(180);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
        private void LeerResultadosComponentes()
        {
            DataTable table = userModel.CalcularPesoComponente(AppCache.ActualIdHilo,lblPesoN.Text);
            

            string idComponente;
            string componente;
            string pesoComponente;
            string costo;

            for (int filas = 0; filas < table.Rows.Count; filas++)
            {
                idComponente = table.Rows[filas]["IdProducto"].ToString();
                componente = table.Rows[filas]["Componente"].ToString();
                pesoComponente = table.Rows[filas]["PesoComponente"].ToString();
                costo = table.Rows[filas]["CostoComponente"].ToString();
                userModel.InsertarComponentesHilatura(idComponente, componente, pesoComponente,costo);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                cmbMalla.Enabled = true;
                cmbColorCono.Text=null;
                cmbColorCono.Enabled = false;
                checkBox2.Text = "Habilitado";
                checkBox1.Text = "Inhabilitado";
                checkBox1.CheckState = CheckState.Unchecked;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                cmbColorCono.Enabled = true;
                cmbMalla.Text = null;
                cmbMalla.Text = "";
                cmbMalla.Enabled = false;
                checkBox1.Text = "Habilitado";
                checkBox2.Text = "Inhabilitado";
                checkBox2.CheckState = CheckState.Unchecked;
            }
        }

        private void tboxNumLote_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            double pesoBruto = Convert.ToDouble(tboxBascula.Text);
            double tara = Convert.ToDouble(lblTara2.Text);
            double pesoNeto = pesoBruto - tara;

            lblPesoB.Text = tboxBascula.Text;
            lblPesoN.Text = Convert.ToString(Math.Round(pesoNeto,3));

            try
            {
                if (checkBox1.Checked == false & checkBox2.Checked == false)
                {
                    MessageBox.Show("Por favor elige un color de cono o tipo de malla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (lblDescHilo.Text != "Descripción" & lblDescCaja.Text != "Descripción" & tboxNumLote.Text != "" & tboxNumConos.Text != "" & AppCache.ActualDescCaja != "" & lblPesoB.Text != "0")
                    {
                        if (cmbIdBolsa.Text != "")
                        {
                            if (checkBox3.CheckState == CheckState.Unchecked)
                            {
                                userModel.InsertarSalidasH(cmbIdBolsa.Text, AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, statusProceso, cmbMalla.Text, cmbColorCono.Text,tboxNotas.Text);
                                userModel.InsertarSalidasHReporte(cmbIdBolsa.Text, AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, statusProceso, cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                LeerResultadosComponentes();
                                MessageBox.Show("Se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                printDocument1 = new PrintDocument();
                                PrinterSettings ps = new PrinterSettings();
                                PageSettings pageSettings = new PageSettings();
                                PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                                printDocument1.PrinterSettings = ps;
                                pageSettings.PaperSize = paper;
                                printDocument1.PrintPage += Imprimir;
                                printDocument1.Print();
                                ReiniciarProceso();
                                MostrarId();
                            }
                            else if(checkBox3.CheckState == CheckState.Checked)
                            {
                                if (userModel.ValidarCrudoAlmacenFinal(Convert.ToInt32(tboxNumPedido.Text),AppCache.ActualIdHilo,tboxColor.Text) == true)
                                {
                                    userModel.InsertarSalidasH(cmbIdBolsa.Text,tboxNumPedido.Text, AppCache.ActualIdHilo,tboxColor.Text, tboxNumLote.Text,tboxLoteT.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, "9", cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                    userModel.InsertarSalidasHReporte(cmbIdBolsa.Text, AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, "9", cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                    LeerResultadosComponentes();
                                    MessageBox.Show("Se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    printDocument1 = new PrintDocument();
                                    PrinterSettings ps = new PrinterSettings();
                                    PageSettings pageSettings = new PageSettings();
                                    PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                                    printDocument1.PrinterSettings = ps;
                                    pageSettings.PaperSize = paper;
                                    printDocument1.PrintPage += Imprimir;
                                    printDocument1.Print();
                                    ReiniciarProceso();
                                    MostrarId();
                                }
                                else
                                {
                                    MessageBox.Show("El pedido no coincide.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                            }
                           
                        }
                        else
                        {
                            if (checkBox3.CheckState == CheckState.Unchecked)
                            {
                                userModel.InsertarSalidasH("1", AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, statusProceso, cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                userModel.InsertarSalidasHReporte("1", tboxNumPedido.Text, AppCache.ActualIdHilo, tboxColor.Text, tboxNumLote.Text,tboxLoteT.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, statusProceso, cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                LeerResultadosComponentes();
                                MessageBox.Show("Se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                printDocument1 = new PrintDocument();
                                PrinterSettings ps = new PrinterSettings();
                                PageSettings pageSettings = new PageSettings();
                                PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                                printDocument1.PrinterSettings = ps;
                                pageSettings.PaperSize = paper;
                                printDocument1.PrintPage += Imprimir;
                                printDocument1.Print();
                                ReiniciarProceso();
                                MostrarId();
                            }
                            else if (checkBox3.CheckState == CheckState.Checked)
                            {
                                if (userModel.ValidarCrudoAlmacenFinal(Convert.ToInt32(tboxNumPedido.Text), AppCache.ActualIdHilo, tboxColor.Text) == true)
                                {
                                    userModel.InsertarSalidasH("1", AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, "9", cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                    userModel.InsertarSalidasHReporte("1", AppCache.ActualIdHilo, tboxNumLote.Text, AppCache.ActualIdCaja, lblPesoB.Text, lblPesoN.Text, tboxNumConos.Text, "9", cmbMalla.Text, cmbColorCono.Text, tboxNotas.Text);
                                    LeerResultadosComponentes();
                                    MessageBox.Show("Se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    printDocument1 = new PrintDocument();
                                    PrinterSettings ps = new PrinterSettings();
                                    PageSettings pageSettings = new PageSettings();
                                    PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                                    printDocument1.PrinterSettings = ps;
                                    pageSettings.PaperSize = paper;
                                    printDocument1.PrintPage += Imprimir;
                                    printDocument1.Print();
                                    ReiniciarProceso();
                                    MostrarId();
                                }
                                else
                                {
                                    MessageBox.Show("El pedido no coincide.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                                
                        }                       

                    }
                    else
                    {
                        MessageBox.Show("Por favor completa todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se insertaron los datos por: " + ex);
            }
    }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
            {
                tboxNumPedido.Enabled = true;
                tboxNumPedido.Visible = true;
                lblNumPedido.Enabled = true;
                lblNumPedido.Visible = true;
                tboxColor.Enabled = true;
                tboxColor.Visible = true;
                lblCodColor.Enabled = true;
                lblCodColor.Visible = true;

                tboxLoteT.Enabled = true;
                tboxLoteT.Visible = true;
                lblLoteT.Enabled = true;
                lblLoteT.Visible = true;
            }
            else
            {
                tboxNumPedido.Enabled = false;
                tboxNumPedido.Visible = false;
                lblNumPedido.Enabled = false;
                lblNumPedido.Visible = false;
                tboxColor.Enabled = false;
                tboxColor.Visible = false;
                lblCodColor.Enabled = false;
                lblCodColor.Visible = false;

                tboxLoteT.Enabled = false;

                tboxLoteT.Visible = false;
                lblLoteT.Enabled = false;
                lblLoteT.Visible = false;

            }
            

        }

        private void cboxNotas_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxNotas.CheckState == CheckState.Checked)
            {
                tboxNotas.Visible = true;
                tboxNotas.Enabled = true;
            }
            else
            {
                tboxNotas.Visible = false;
                tboxNotas.Enabled = false;
                tboxNotas.Text = "NULL";
            }
        }
    }
}
