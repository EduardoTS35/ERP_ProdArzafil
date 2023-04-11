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
    public partial class frmSalidasMP : Form
    {
        UserModel userModel = new UserModel();
        double costoTotal;
        double materialR;
        double cantidadSalida;
        public frmSalidasMP()
        {
            InitializeComponent();
        }

        private void btnCatalogoMP_Click(object sender, EventArgs e)
        {
            frmCatalogoMP frmCatalogoMP = new frmCatalogoMP();
            frmCatalogoMP.Show();
            timerCatalogo.Start();
            costoTotal = 0;
            materialR = 0;
        }
        private void MostrarProveedores()
        {
            comboBox1.DataSource = userModel.ver_Proveedores();
            comboBox1.DisplayMember = "razonSocial";
            comboBox1.ValueMember = "idProveedor";
        }

        private void timerCatalogo_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualDescMP != null)
                {
                    btnCatalogoMP.Enabled = true;
                    lblDesc.Text = AppCache.ActualDescMP;
                    CargarcmbMaterialExistente();
                    AppCache.ActualDescMP = null;
                    timerCatalogo.Stop();
                }
                else
                    btnCatalogoMP.Enabled = false;
            }
            catch
            {
            }
        }

        private void CalcularCostoT()
        {
            if (AppCache.ActualCostoMP != null)
            {
                if (tboxCantidadS.Text == "")
                {
                    costoTotal = 0;
                }
                else
                {
                    costoTotal = Convert.ToDouble(AppCache.ActualCostoMP) *(- Math.Round(Convert.ToDouble(tboxCantidadS.Text), 3));
                }

            }
            else
            {
                MessageBox.Show("Por favor selecciona un material del catálogo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tboxCantidadS.Clear();
            }
        }

        private void CalcularCantidadR()
        {
            if (lblDesc.Text != "Descripción")
            {
                if (tboxCantidadS.Text == "")
                {
                    tboxCantidadR.Text = "0";
                }
                else
                {
                    try
                    {
                        materialR = Math.Round(Convert.ToDouble(cmbMaterialE.Text), 3) - (Math.Round(Convert.ToDouble(tboxCantidadS.Text), 3));
                        tboxCantidadR.Text = Convert.ToString(Math.Round(materialR,3));
                        if (materialR < 0)
                        {
                            MessageBox.Show("Por favor ingrese una cantidad válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tboxCantidadS.Clear();
                            tboxCantidadR.Text = "0";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Introduce un valor valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tboxCantidadS.Clear();
                        tboxCantidadR.Clear();
                    }
                        
                }

            }
            else
            {
                MessageBox.Show("Por favor selecciona un material del catálogo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tboxCantidadS.Clear();
            }
        }

        public void ConvertirANegativo()
        {
            cantidadSalida = 0;
            cantidadSalida = (Math.Round(Convert.ToDouble(tboxCantidadS.Text)*(-1),3));
        }

        private void InsertarSalida()
        {
            try
            {
                if (tboxCantidadS.Text != "")
                {
                    ConvertirANegativo();
                    userModel.InsertarSalidasMP(AppCache.ActualIdMP, lblDesc.Text, Convert.ToString(cantidadSalida), Convert.ToString(costoTotal),Convert.ToInt32(comboBox1.SelectedValue));
                    MessageBox.Show("Se realizó la salida correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    costoTotal = 0;
                    materialR = 0;
                    CargarcmbMaterialExistente();
                    tboxCantidadS.Clear();
                }
                else
                {
                    MessageBox.Show("Por favor completa todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            catch
            {

            }

        }

        private void CargarcmbMaterialExistente()
        {
            userModel.MostrarMaterialExistenteMP(lblDesc.Text);
            cmbMaterialE.DataSource = userModel.MostrarMaterialExistenteMP(lblDesc.Text);
            cmbMaterialE.DisplayMember = "PesoTotal";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarSalida();
        }

        private void tboxCantidadS_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularCantidadR();
            CalcularCostoT();
        }

        private void tboxCantidadS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.Equals(e.KeyChar, Keys.Oemcomma))
            {
                e.Handled = true;
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

        private void frmSalidasMP_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
        }
    }
}
