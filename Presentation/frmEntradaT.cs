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

namespace Presentation
{
    public partial class frmEntradaT : Form
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

        bool validacion;

        public frmEntradaT()
        {
            InitializeComponent();
            MostrarEntradasT();
            MostrarLoteActual();
        }

        public void MostrarLoteActual()
        {
            try
            {
                comboBox1.DataSource = userModel.MostrarLoteActualT();
                comboBox1.DisplayMember = "LoteTenido";
                if (comboBox1.Text == "")
                {
                    comboBox1.Text = "1";
                }
            }
            catch
            {

            }
        }

        public void MostrarEntradasT()
        {
            try
            {
                dataGridView1.DataSource = userModel.MostrarEntradasT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha ingresado ningun valor en la base de datos: " + ex);
            }

        }

        public void MostrarDatosI(string ID)
        {
            try
            {
                ValidarEntrada(Convert.ToInt32(ID), AppCache.ActualIdColor);
                if (validacion == true)
                {
                    try
                    {
                        dataGridView2.DataSource = userModel.MostrarBolsaT1(ID);
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Por favor verifica el color seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }
        public void InsertarDatos()
        {
            userModel.InsertarEntradasTRB(IdBolsa, NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "5", Malla, ColorCono);
            userModel.AgregarDatosT(IdBolsa, LoteT, IdColor);
        }

        public void LeerMultiLine()
        {
            foreach (var row in tboxEntradaM.Lines)
            {
                try
                {
                    MostrarDatosI(row);
                    LeerDatos();
                    InsertarDatos();
                }
                catch
                {
                    MessageBox.Show("La Bolsa número: " + row + " no se encontró", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            MessageBox.Show("Se realizó correctamente el proceso.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LeerDatos()
        {
            try
            {
                DataGridViewRow row = dataGridView2.Rows[0];

                IdBolsa = Convert.ToString(row.Cells[0].Value);
                NumPedido = Convert.ToString(row.Cells[1].Value);
                IdHilo = Convert.ToString(row.Cells[2].Value);
                LoteHilatura = Convert.ToString(row.Cells[4].Value);
                IdCaja = Convert.ToString(row.Cells[6].Value);
                PesoBruto = Convert.ToString(row.Cells[10].Value);
                PesoNeto = Convert.ToString(row.Cells[11].Value);
                NumConos = Convert.ToString(row.Cells[9].Value);
                Malla = Convert.ToString(row.Cells[7].Value);
                ColorCono = Convert.ToString(row.Cells[8].Value);
                if (tboxNumLote.Text != "")
                    LoteT = tboxNumLote.Text;
                else
                    LoteT = comboBox1.Text;
            }
            catch
            {

            }

        }

        private void ValidarEntrada(int idBolsa, string idColor)
        {
            validacion=userModel.ValidarEntradaT(idBolsa,idColor);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                userModel.ValidarEntradaT(Convert.ToInt32(tboxEntradaC.Text), AppCache.ActualIdColor);

                //cAMBIAR EL METODO
                if (validacion == true)
                {
                    userModel.InsertarEntradasTRB(IdBolsa, NumPedido, IdHilo, IdColor, LoteHilatura, LoteT, IdCaja, PesoBruto, PesoNeto, NumConos, "5", Malla, ColorCono);
                    userModel.AgregarDatosT(IdBolsa, LoteT, IdColor);
                    MostrarEntradasT();
                    tboxEntradaC.Clear();
                    MostrarLoteActual();
                    timer1.Stop();
                }
                else
                {
                    MostrarEntradasT();
                    tboxEntradaC.Clear();
                    MostrarLoteActual();
                    timer1.Stop();
                }
            }
            catch
            {
                tboxEntradaC.Clear();
                timer1.Dispose();
                timer1.Stop();
            }
        }

        private void tboxEntradaC_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (tboxEntradaM.Text != null)
                    tboxEntradaM.Clear();

                if (tboxEntradaC.Text != null)
                {
                    try
                    {
                        if (tboxEntradaC.Text != "" & tboxColor.Text != "")
                        {
                            if (tboxNumLote.Text != "")
                            {
                                if (userModel.ValidarColorLoteT(Convert.ToInt32(tboxNumLote.Text)) == false)
                                {
                                    IdColor = AppCache.ActualIdColor;
                                    LoteT = tboxNumLote.Text;
                                    MostrarDatosI(tboxEntradaC.Text);
                                    LeerDatos();
                                    timer1.Start();
                                }
                                else if (AppCache.ActualColorLoteT == AppCache.ActualIdColor)
                                {
                                    IdColor = AppCache.ActualIdColor;
                                    LoteT = tboxNumLote.Text;
                                    MostrarDatosI(tboxEntradaC.Text);
                                    LeerDatos();
                                    timer1.Start();
                                }
                                else
                                {
                                    MessageBox.Show("El color seleccionado no coincide con el lote de teñido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tboxEntradaC.Clear();
                                }

                            }
                            else
                            {
                                if (userModel.ValidarColorLoteT(Convert.ToInt32(comboBox1.Text)) == false)
                                {
                                    IdColor = AppCache.ActualIdColor;
                                    LoteT = tboxNumLote.Text;
                                    MostrarDatosI(tboxEntradaC.Text);
                                    LeerDatos();
                                    timer1.Start();
                                }
                                else if (AppCache.ActualColorLoteT == AppCache.ActualIdColor)
                                {
                                    IdColor = AppCache.ActualIdColor;
                                    LoteT = tboxNumLote.Text;
                                    MostrarDatosI(tboxEntradaC.Text);
                                    LeerDatos();
                                    timer1.Start();
                                }
                                else
                                {
                                    MessageBox.Show("El color seleccionado no coincide con el lote de teñido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tboxEntradaC.Clear();
                                }
                                    
                                
                            }
                            
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se encontró ningun producto" + ex);
                    }
                }
            }
            catch
            {

            }
        }

        private void btnGuardarEM_Click(object sender, EventArgs e)
        {
            if (tboxEntradaM.Text !=null & tboxColor.Text!=null)
            {
                if (tboxNumLote.Text != "")
                {
                    if (userModel.ValidarColorLoteT(Convert.ToInt32(tboxNumLote.Text)) == false)
                    {
                        IdColor = AppCache.ActualIdColor;
                        LoteT = tboxNumLote.Text;
                        LeerMultiLine();
                        MostrarLoteActual();
                        MostrarEntradasT();

                        tboxEntradaM.Clear();
                    }
                    else if(AppCache.ActualColorLoteT==AppCache.ActualIdColor)
                    {
                        IdColor = AppCache.ActualIdColor;
                        LoteT = tboxNumLote.Text;
                        LeerMultiLine();
                        MostrarLoteActual();
                        MostrarEntradasT();

                        tboxEntradaM.Clear();
                    }
                    else
                    {
                        MessageBox.Show("El color seleccionado no coincide con el lote de teñido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tboxEntradaC.Clear();
                    }
                }
                else
                {
                    if (userModel.ValidarColorLoteT(Convert.ToInt32(comboBox1.Text)) == false)
                    {
                        IdColor = AppCache.ActualIdColor;
                        LoteT = tboxNumLote.Text;
                        LeerMultiLine();
                        MostrarLoteActual();
                        MostrarEntradasT();

                        tboxEntradaM.Clear();
                    }
                    else if (AppCache.ActualColorLoteT == AppCache.ActualIdColor)
                    {
                        IdColor = AppCache.ActualIdColor;
                        LoteT = tboxNumLote.Text;
                        LeerMultiLine();
                        MostrarLoteActual();
                        MostrarEntradasT();

                        tboxEntradaM.Clear();
                    }
                    else
                    {
                        MessageBox.Show("El color seleccionado no coincide con el lote de teñido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tboxEntradaC.Clear();
                    }
                }
               
            }
            else
                MessageBox.Show("Por favor completa todos los campos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void tboxEntradaM_TextChanged(object sender, EventArgs e)
        {

        }

        private void timerCatalogo_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualDescColor != null)
                {
                    btnCatalogoColores.Enabled = true;
                    tboxColor.Text = AppCache.ActualDescColor;
                    AppCache.ActualDescColor = null;
                    timerCatalogo.Stop();
                    
                }
                else
                    btnCatalogoColores.Enabled = false;
            }
            catch
            {
            }
        }

        private void btnCatalogoColores_Click(object sender, EventArgs e)
        {
            frmCatalogoColores frmCatalogoColores = new frmCatalogoColores();
            frmCatalogoColores.Show();
            timerCatalogo.Start();
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

        private void tboxEntradaC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxEntradaM_KeyPress(object sender, KeyPressEventArgs e)
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
