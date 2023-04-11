using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using Domain;
using Commun.Cache;

namespace Presentation
{
    public partial class frmConfigH : Form
    {
        UserModel userModel = new UserModel();    
        DateTime toDate = DateTime.Now;
        DateTime fromDate = DateTime.Today.AddDays(-30);

        int statusBolsa;
        double precioUnitario;
        bool statusSeleccion = false;

        string hilo;
        string IdBolsa;
        string IdHilo;
        string LoteHilatura;
        string PesoBruto;
        string PesoNeto;
        string NumConos;
        string Malla;
        string ColorCono;
        string dataIN;
        string titulo;
        string IdCaja;
        public frmConfigH()
        {
            InitializeComponent();
        }

        public void MostrarDatos()
        {
            if (cmbSeleccion.Text == "Entradas")
            {
                if (UserLoginCache.Position == "Auxiliar")
                {
                    btnBorrar.Enabled = false;
                }
                if (btnReimprimir.Visible == true)
                    btnReimprimir.Visible = false;
                LimpiarForm();
                try
                {
                    dataGridView1.DataSource = userModel.MostrarEntradasH();
                }
                catch
                {

                }
                statusBolsa = 3;
                label2.Text = "ID Producto";
                label4.Text = "Producto";
                label5.Text = "Peso";
                label6.Text = "Costo";
                label7.Visible = false;
                tboxIdCaja.Enabled = false;
                tboxIdCaja.Visible = false;
                tboxKilosMP.Enabled = false;
                tboxKilosMP.Visible = true;
                cBoxDefinirKilos.Enabled = true;
                cBoxDefinirKilos.Visible = true;
            }
            else if (cmbSeleccion.Text == "Salidas")
            {
                LimpiarForm();
                try
                {
                    dataGridView1.DataSource = userModel.MostrarSalidasH();
                }
                catch
                {

                }
                statusBolsa = 4;
                label2.Text = "ID Bolsa";
                label5.Text = "IdHilo";
                label6.Text = "Peso Bruto";
                label7.Text = "Peso Neto";
                label7.Visible = true;
                tboxIdCaja.Enabled = true;
                tboxIdCaja.Visible = true;
                tboxKilosMP.Enabled = false;
                tboxKilosMP.Visible = false;
                cBoxDefinirKilos.Enabled = false;
                cBoxDefinirKilos.Visible = false;
            }
        }

        public void SeleccionarMovimiento()
        {

            statusSeleccion = true;
            if (cmbSeleccion.Text == "Entradas")
            {
                tboxIdBolsa.Text = dataGridView1.CurrentRow.Cells["IdProducto"].Value.ToString();
                tboxFechaRegistro.Text = dataGridView1.CurrentRow.Cells["Producto"].Value.ToString();
                tboxIdHilo.Text = dataGridView1.CurrentRow.Cells["Peso"].Value.ToString();
                tboxLoteHilatura.Text = dataGridView1.CurrentRow.Cells["Costo"].Value.ToString();
                CalcularPrecioUnitario();
                
            }
            else if (cmbSeleccion.Text == "Salidas")
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                tboxIdBolsa.Text = dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString();
                tboxFechaRegistro.Text = dataGridView1.CurrentRow.Cells["FechaRegistro"].Value.ToString();
                tboxIdHilo.Text = dataGridView1.CurrentRow.Cells["IdHilo"].Value.ToString();
                tboxLoteHilatura.Text = dataGridView1.CurrentRow.Cells["PesoBruto"].Value.ToString();
                tboxIdCaja.Text = dataGridView1.CurrentRow.Cells["PesoNeto"].Value.ToString();
                userModel.GuardarInfoBolsa(Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString()));

                hilo = Convert.ToString(row.Cells["Hilo"].Value);
                IdBolsa = Convert.ToString(row.Cells["IDBolsa"].Value);
                IdHilo = Convert.ToString(row.Cells["IdHilo"].Value);
                LoteHilatura = Convert.ToString(row.Cells["LoteHilatura"].Value);
                IdCaja = Convert.ToString(row.Cells["IdCaja"].Value);
                PesoBruto = Convert.ToString(row.Cells["PesoBruto"].Value);
                PesoNeto = Convert.ToString(row.Cells["PesoNeto"].Value);
                NumConos = Convert.ToString(row.Cells["NumConos"].Value);
                Malla = Convert.ToString(row.Cells["Malla"].Value);
                ColorCono = Convert.ToString(row.Cells["ColorCono"].Value);
                titulo = Convert.ToString(row.Cells["Titulo"].Value);
            }
            
        }

        private void CalcularPrecioUnitario()
        {
            precioUnitario = Convert.ToDouble(tboxLoteHilatura.Text) / Convert.ToDouble(tboxIdHilo.Text);
        }

        public void MostrarBotonReimpresion()
        {
            if (cmbSeleccion.Text == "Salidas" & statusSeleccion == true)
            {
                btnReimprimir.Visible = true;
                btnReimprimir.Enabled = true;
            }
            else
            {
                btnReimprimir.Visible = false;
                btnReimprimir.Enabled = false;
            }   
        }

        public void LimpiarForm()
        {
            tboxIdBolsa.Clear();
            tboxFechaRegistro.Clear();
            tboxIdHilo.Clear();
            tboxLoteHilatura.Clear();
            tboxIdCaja.Clear();
            btnReimprimir.Enabled = false;
            btnReimprimir.Visible = false;
        }

        public void EliminarBolsa(string IdBolsa)
        {
            userModel.EliminarEHilatura(IdBolsa);
            userModel.EliminarEHilaturaReporte(IdBolsa);
        }

        public void EliminarEntradaMP(string IdProducto,string Producto, string Peso, string Costo)
        {
            userModel.EliminarEntradaMP(IdProducto,Producto,Peso,Costo);
        }

        private void cmbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() != "")
            {
                SeleccionarMovimiento();              
                MostrarBotonReimpresion();
            }
            else
                MessageBox.Show("Por favor seleccione una opción valida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Barcode barcode = new Barcode();
            barcode.IncludeLabel = false;
            barcode.Alignment = AlignmentPositions.CENTER;
            barcode.LabelFont = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
            Image img = barcode.Encode(TYPE.CODE128, IdBolsa, Color.Black, Color.White, 240, 60);
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
            e.Graphics.DrawString(hilo + " " + titulo, fontT, Brushes.Black, new RectangleF(7, largo, ancho, 40));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("Cod. Hilo: " + IdHilo, ftext, Brushes.Black, new RectangleF(12, largo += 6, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bruto: " + PesoBruto + " KG", font, Brushes.Black, new RectangleF(263, largo = 97, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Lote:  " + LoteHilatura, ftext, Brushes.Black, new RectangleF(12, 125, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Neto: " + PesoNeto + " KG", font, Brushes.Black, new RectangleF(260, 200, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Núm.Conos: " + NumConos, ftext, Brushes.Black, new RectangleF(12, 177, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bolsa: " + IdBolsa, ftext, Brushes.Black, new RectangleF(12, 229, ancho, 25));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Turno:  " + "*", ftext, Brushes.Black, new RectangleF(12, 280, ancho, 25));
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), ftext, Brushes.Black, new RectangleF(12, 330, ancho, 25));
            e.Graphics.DrawImage(img, 260, 310);
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (cmbSeleccion.Text == "Salidas")
            {
                if (tboxIdBolsa.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Estás seguro de eliminar el registro de la bolsa?", "Adveritencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        EliminarBolsa(tboxIdBolsa.Text);
                        MostrarDatos();
                        MessageBox.Show("Se realizó correctamente el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }
                else
                    MessageBox.Show("Por favor seleccione una bolsa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbSeleccion.Text == "Entradas")
            {
                if (tboxIdBolsa.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Estás seguro de eliminar el registro?", "Adveritencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (cBoxDefinirKilos.Checked == true)
                        {
                            EliminarEntradaMP(tboxIdBolsa.Text, tboxFechaRegistro.Text, Convert.ToString(Convert.ToDouble(tboxKilosMP.Text)*-1),Convert.ToString((precioUnitario*Convert.ToDouble(tboxKilosMP.Text))*-1));
                        }
                        else
                        {
                            MessageBox.Show("Por favor escribe la cantidad de kilos a corregir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                        MostrarDatos();
                        MessageBox.Show("Se realizó correctamente el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }
                else
                    MessageBox.Show("Por favor seleccione un registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cBoxDefinirKilos_CheckedChanged(object sender, EventArgs e)
        {
            if (tboxIdBolsa.Text != "")
            {
                if (cBoxDefinirKilos.Checked == true)
                    tboxKilosMP.Enabled = true;
                else
                    tboxKilosMP.Enabled = false;
            }
            else
                MessageBox.Show("Por favor seleccione un registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tboxKilosMP_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tboxKilosMP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double pesoTotal = Convert.ToDouble(tboxIdHilo.Text);
                double pesoDeseado = Convert.ToDouble(tboxKilosMP.Text);

                if (pesoTotal < pesoDeseado)
                {
                    MessageBox.Show("Por favor seleccione una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tboxKilosMP.Clear();
                }
            }
            catch
            {

            }
        }

        private void frmConfigH_Load(object sender, EventArgs e)
        {
            
            if (UserLoginCache.Area == "Hilatura")
            {
                cmbSeleccion.Enabled = false;
                cmbSeleccion.Text = "Salidas";
                MostrarDatos();
            }
        }
    }
}
