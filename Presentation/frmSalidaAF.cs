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

namespace Presentation
{
    public partial class frmSalidaAF : Form
    {
        UserModel userModel = new UserModel();

        string IdBolsa;
        string NumPedido;
        string IdHilo;
        string IdColor;
        string LoteHilatura;
        string LoteT;
        string IdCaja;
        string PesoBruto;
        string PesoNeto;
        string NumConos;
        string Malla;
        string ColorCono;
        public frmSalidaAF()
        {
            InitializeComponent();
            MostrarSalidasAF();
            MostrarNumeroRemision();
        }
        private void getReport()
        {
            Reporte reporte = new Reporte();
            reporte.GetOrderResumenNumRemisionAF(Convert.ToInt32(comboBox2.Text));
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }


        private void getReportD()
        {
            ReporteDetails reporteD = new ReporteDetails();
            reporteD.GetOrderDetallesNumRemisionAF(Convert.ToInt32(comboBox2.Text));
            PruebasLDeBindingSource.DataSource = reporteD.pruebasLDe;
        }
        public void ValidarTextBox()
        {
            if (textBox1.Text != "")
            {
                textBox3.Clear();
            }
            if (textBox3.Text != "")
            {
                textBox1.Clear();
            }
        }
        //public async Task Subir()
        //{
        //    var task 
        //}

        public void MostrarSalidasAF()
        {
            try
            {
                dataGridView1.DataSource = userModel.MostrarSalidasAF();
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
                dataGridView2.DataSource = userModel.MostrarBolsaSAF(ID);
            }
            catch (Exception)
            {

            }
        }

        public void MostrarDatosBolsa2(string ID, string NumPedido)
        {
            try
            {
                dataGridView2.DataSource = userModel.MostrarBolsaSAF2(ID,NumPedido);
            }
            catch (Exception)
            {

            }
        }


        public void MostrarNuevoNRemision()
        {
            try
            {
                comboBox2.DataSource = userModel.MostrarNuevoNRemision();
                comboBox2.DisplayMember = "SigNumRemision";
                if (comboBox2.Text == "")
                    comboBox2.Text = "1";
            }
            catch (Exception)
            {

            }
        }

        public void MostrarNumeroRemision()
        {
            try
            {
                comboBox2.DataSource = userModel.MostrarNumeroRemision();
                comboBox2.DisplayMember = "NumRemision";
                if (comboBox2.Text == "")
                    comboBox2.Text = "1";
                    
            }
            catch (Exception)
            {

            }
        }

        public void LeerDatos()
        {
            DataGridViewRow row = dataGridView2.Rows[0];

            IdBolsa = Convert.ToString(row.Cells["IDBolsa"].Value);
            NumPedido = Convert.ToString(row.Cells["NumPedido"].Value);
            IdHilo = Convert.ToString(row.Cells["IdHilo"].Value);
            IdColor = Convert.ToString(row.Cells["IdColor"].Value);
            LoteHilatura = Convert.ToString(row.Cells["LoteHilatura"].Value);
            LoteT = Convert.ToString(row.Cells["LoteTenido"].Value);
            IdCaja = Convert.ToString(row.Cells["LoteTenido"].Value);
            PesoBruto = Convert.ToString(row.Cells["PesoBruto"].Value);
            PesoNeto = Convert.ToString(row.Cells["PesoNeto"].Value);
            NumConos = Convert.ToString(row.Cells["NumConos"].Value);
            Malla = Convert.ToString(row.Cells["Malla"].Value);
            ColorCono = Convert.ToString(row.Cells["ColorCono"].Value);

        }
        public void InsertarDatos()
        {
            if (checkBox1.Checked == false)
            {
                userModel.InsertarSalidasAF(IdBolsa, NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "10", comboBox2.Text, Malla, ColorCono);
            }
            else
            {                
                userModel.InsertarSalidasAF(IdBolsa, NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "11", comboBox2.Text, Malla, ColorCono);
            }
        }
        public void LeerMultiLine()
        {
            foreach (var row in textBox2.Lines)
            {
                try
                {
                    MostrarDatosBolsa(row);
                    LeerDatos();
                    InsertarDatos();
                }
                catch
                {
                    MessageBox.Show("La Bolsa número: " + row + " no se encontró", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void timerCodBar_Tick(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    if (userModel.ValidarSalidasAF(Convert.ToInt32(IdBolsa),Convert.ToInt32(textBox4.Text)) == true)
                    {
                        if (checkBox1.Checked == false)
                        {
                            userModel.InsertarSalidasAF(IdBolsa, textBox4.Text, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "10", comboBox2.Text, Malla, ColorCono);
                            MostrarSalidasAF();
                            textBox1.Clear();
                            timerCodBar.Stop();
                            MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            userModel.InsertarSalidasAF(IdBolsa, textBox4.Text, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "11", comboBox2.Text, Malla, ColorCono);
                            MostrarSalidasAF();
                            textBox1.Clear();
                            timerCodBar.Stop();
                            MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        timerCodBar.Stop();
                        textBox1.Clear();
                        MessageBox.Show("Por favor revise el número de pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                        

                }
                else
                {
                    timerCodBar.Stop();
                    textBox1.Clear();
                    
                }
                    
            }
            catch
            {
                textBox1.Clear();
                timerCodBar.Dispose();
                timerCodBar.Stop();
                MessageBox.Show("No se encontró el producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                {
                    if (comboBox2.Text == "")
                        comboBox2.Text = "1";
                    ValidarTextBox();
                    MostrarDatosBolsa(textBox1.Text);
                    LeerDatos();
                    timerCodBar.Start();
                }
            }
            catch (Exception)
            {

            }
        }

        private void timerCodB2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    if (checkBox1.Checked == false)
                    {
                        if (comboBox2.Text == "")
                            comboBox2.Text = "1";
                        userModel.InsertarSalidasAF(IdBolsa, NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "10", comboBox2.Text, Malla, ColorCono);
                        MostrarSalidasAF();
                        textBox2.Clear();
                        timerCodB2.Stop();
                        MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (comboBox2.Text == "")
                            comboBox2.Text = "1";
                        userModel.InsertarSalidasAF(IdBolsa, NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "11", comboBox2.Text, Malla, ColorCono);
                        MostrarSalidasAF();
                        textBox2.Clear();
                        timerCodB2.Stop();
                        MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                else
                    MessageBox.Show("Por favor ingrese el número de Bolsa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                textBox2.Clear();
                timerCodB2.Dispose();
                timerCodB2.Stop();
                MessageBox.Show("No se encontró el producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox2.Text != "")
            {
                try
                {
                    getReport();
                    getReportD();
                    this.reportViewer1.RefreshReport();
                    int numRemision = Convert.ToInt32(comboBox2.Text);
                    comboBox2.Text = Convert.ToString(numRemision + 1);
                }
                catch
                {
                    MessageBox.Show("Verifica los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor introduce un número de lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmSalidaAF_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LeerMultiLine();
            MostrarSalidasAF();
            textBox2.Clear();
            MessageBox.Show("Se realizó correctamente el movimiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            if (comboBox2.Text != "")
            {
                getReport();
                getReportD();
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Por favor introduce un número de lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int numRemision = Convert.ToInt32(comboBox2.Text);
            if (comboBox2.Text == "")
            {
                numRemision = 0;
            }
            comboBox2.Text = Convert.ToString(numRemision + 1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(comboBox2.Text)>=1)
            {
                comboBox2.Text = Convert.ToString(Convert.ToInt32(comboBox2.Text) - 1);
            }
            else
            {
                MessageBox.Show("El número de remisión debe de ser mayor a 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox2.Text) >= 1)
            {
                comboBox2.Text = Convert.ToString(Convert.ToInt32(comboBox2.Text) - 1);
            }
            else
            {
                MessageBox.Show("El número de remisión debe de ser mayor a 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
