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
using BarcodeLib;
using System.Drawing.Printing;

namespace Presentation
{
    public partial class frmModificarBolsa : Form
    {
        UserModel userModel = new UserModel();
        double pesoTotalGB;
        double pesoTotalB;

        int numConosG2;
        double pesoUG;
        double pesoTG;
        public frmModificarBolsa()
        {
            InitializeComponent();
            MostrarInfo();
            MostrarId();
        }


        public void MostrarInfo()
        {

            userModel.SeleccionarBolsa(AppCache.IdBolsa);
            tboxIdBolsaG.Text = Convert.ToString(AppCache.IdBolsa);
            tboxNumConosG.Text = Convert.ToString(AppCache.NumConos);
            tboxPesoUG.Text = Convert.ToString(Math.Round(AppCache.PesoNeto / AppCache.NumConos,2));
            tboxPesoU.Text = Convert.ToString(Math.Round(AppCache.PesoNeto / AppCache.NumConos, 2));
            tboxPesoTG.Text = Convert.ToString(Math.Round(AppCache.PesoNeto,2));
            tboxPesoT.Text= Convert.ToString(Math.Round(AppCache.PesoNeto, 2));
            numConosG2 = AppCache.NumConos;
            pesoUG= Math.Round(AppCache.PesoNeto / AppCache.NumConos, 2);
            pesoTG = Math.Round(AppCache.PesoNeto, 2);
        }
        private void MostrarId()
        {
            cmbIdBolsa.DataSource = userModel.MostrarIdBolsa();
            cmbIdBolsa.DisplayMember = "BolsaSig";
            if (cmbIdBolsa.Text != null)
            {
            }
            else
                cmbIdBolsa.Text = "1";
        }

        public void CalcularBolsa()
        {
            try
            {
                int numConosG = Convert.ToInt32(tboxNumConosG.Text);
                int numConos = Convert.ToInt32(tboxNumConos.Text);
                double pesoUnitario = Convert.ToDouble(tboxPesoUG.Text);
                double pesoUnitarioB = Convert.ToDouble(Math.Round(AppCache.PesoBruto / AppCache.NumConos, 2));

                int numConosRestantes = numConosG - numConos;
                double pesoTotalG = numConosRestantes * pesoUnitario;
                double pesoTotal = numConos * pesoUnitario;
                pesoTotalGB = numConosRestantes * pesoUnitarioB;
                pesoTotalB = numConos * pesoUnitarioB;

                if (numConosRestantes > 0)
                {
                    tboxNumConosG.Text = Convert.ToString(numConosRestantes);
                    tboxPesoTG.Text = Convert.ToString(pesoTotalG);
                    tboxPesoT.Text = Convert.ToString(pesoTotal);
                }
                else
                {
                    tboxNumConos.Text = "0";
                    tboxNumConosG.Text = Convert.ToString(numConosG2);
                    tboxPesoUG.Text = Convert.ToString(pesoUG);
                    tboxPesoTG.Text = Convert.ToString(pesoTG);
                    MessageBox.Show("Seleccione una cantidad correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    

                }
            }
            catch
            {
                tboxNumConos.Text = "0";
                tboxNumConosG.Text = Convert.ToString(numConosG2);
                tboxPesoUG.Text = Convert.ToString(pesoUG);
                tboxPesoTG.Text = Convert.ToString(pesoTG);
            }

        }

        private void tboxNumConos_TextChanged(object sender, EventArgs e)
        {
            CalcularBolsa();
        }

        private void frmModificarBolsa_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppCache.modificarBolsafrm = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tboxNumConos.Text != null)
                {
                    userModel.CrearNuevaBolsa(cmbIdBolsa.Text, Convert.ToString(AppCache.NumPedidoBolsa), AppCache.IdHilo, AppCache.IdColor, Convert.ToString(AppCache.LoteHilatura), Convert.ToString(AppCache.LoteTenido), Convert.ToString(AppCache.IdCaja), Convert.ToString(pesoTotalB), tboxPesoT.Text, tboxNumConos.Text, Convert.ToString(AppCache.StatusProceso), AppCache.Malla, AppCache.ColorCono);
                    userModel.ModificarBolsa(tboxIdBolsaG.Text, Convert.ToString(pesoTotalGB), tboxPesoTG.Text, tboxNumConosG.Text, Convert.ToString(AppCache.StatusProceso));
                    MessageBox.Show("Se realizó correctamente el movimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tboxNumConos.Enabled = false;
                    btnImprimirNuevaEtiqueta.Enabled = true;
                    btnImprimirNuevaEtiqueta.Visible = true;
                }
                else
                    MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Surgió un error, comuniquese con soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            e.Graphics.DrawString("Unidad Arzafil", fontT, Brushes.Black, new RectangleF(7, largo, ancho, 40));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("Cod. Hilo: " + AppCache.IdHilo, ftext, Brushes.Black, new RectangleF(12, largo += 6, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bruto: " + Math.Round(pesoTotalB, 2) + " KG", font, Brushes.Black, new RectangleF(263, largo = 97, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Lote:  " + AppCache.LoteHilatura, ftext, Brushes.Black, new RectangleF(12, 125, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Neto: " + Math.Round(Convert.ToDouble(tboxPesoT.Text), 2) + " KG", font, Brushes.Black, new RectangleF(260, 200, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Núm.Conos: " + tboxNumConos.Text, ftext, Brushes.Black, new RectangleF(12, 177, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bolsa: " + cmbIdBolsa.Text, ftext, Brushes.Black, new RectangleF(12, 229, ancho, 25));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Turno:  " + "*", ftext, Brushes.Black, new RectangleF(12, 280, ancho, 25));
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToString("dd-MM-yyyy hh:mm"), ftext, Brushes.Black, new RectangleF(12, 330, ancho, 25));
            e.Graphics.DrawImage(img, 260, 310);
            
        }

        private void btnImprimirNuevaEtiqueta_Click(object sender, EventArgs e)
        {
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            PageSettings pageSettings = new PageSettings();
            PaperSize paper = new PaperSize("Etiqueta", 394, 551);
            printDocument1.PrinterSettings = ps;
            pageSettings.PaperSize = paper;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
            this.Close();
        }
    }
}
