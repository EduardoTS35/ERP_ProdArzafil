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
    public partial class frmEntradasMP : Form
    {
        UserModel userModel = new UserModel();
        double costoTotal;
        public frmEntradasMP()
        {
            InitializeComponent();
        }
        private void frmEntradasMP_Load(object sender, EventArgs e)
        {
            MostrarEntradas();
            MostrarProveedores();
        }

        private void btnCatalogoMP_Click(object sender, EventArgs e)
        {
            frmCatalogoMP frmCatalogoMP = new frmCatalogoMP();
            frmCatalogoMP.Show();
            timerCatalogo.Start();
        }
        private void MostrarProveedores()
        {
            comboBox1.DataSource= userModel.ver_Proveedores();
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

        private void tboxPesoNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tboxCosto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void MostrarEntradas()
        {
            userModel.MostrarEntradasMP();
            dataGridView1.DataSource = userModel.MostrarEntradasMP();
        }

        private void InsertarEntrada()
        {
            try
            {
                userModel.InsertarEntradasMP(AppCache.ActualIdMP,lblDesc.Text,tboxPesoNeto.Text,tboxCosto.Text,Convert.ToInt32(comboBox1.SelectedValue));
                MessageBox.Show("Se realizó la entrada correctamente", "Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                costoTotal = 0;
            }
            catch
            {

            }
            
        }

        private void CalculrarCosto()
        {
            try
            {
                if (AppCache.ActualCostoMP != null)
                {
                    costoTotal = Convert.ToDouble(AppCache.ActualCostoMP) * Convert.ToDouble(tboxPesoNeto.Text);
                    tboxCosto.Text = Convert.ToString(costoTotal);
                }
                else
                {
                    MessageBox.Show("Por favor selecciona un material del catálogo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tboxPesoNeto.Clear();
                }
            }
            catch
            {
                tboxCosto.Clear();
                tboxPesoNeto.Clear();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarEntrada();
            MostrarEntradas();
            tboxPesoNeto.Clear();
            tboxCosto.Text = "0";
        }

        private void tboxPesoNeto_KeyUp(object sender, KeyEventArgs e)
        {
            CalculrarCosto();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            tboxPesoNeto.Clear();
            tboxCosto.Text = "0";
        }
    }
}
