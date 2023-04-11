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
    public partial class Dashboard : Form
    {
        bool statusCerrar=false;
        UserModel userModel = new UserModel();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadUserData();
            Restricciones();
            openChildForm(new frmDashboard());
        }

        private void Restricciones()
        {
            if (lblArea.Text=="Producción")
            {
                btnSubMenuConfig.Enabled = false;
                btnSubMenuConfig.Visible = false;
                if (lblCharge.Text == "Supervisor")
                {
                    btnSubMenuConfig.Enabled = true;
                    btnSubMenuConfig.Visible = true;
                    btnConfigUsuarios.Enabled = true;
                    btnConfigUsuarios.Visible = false;
                    btnConfigMP.Enabled = false;
                    btnConfigMP.Visible = false;
                    btnConfigHR.Enabled = false;
                    btnConfigHR.Visible = false;
                    btnConfigH.Enabled = false;
                    btnConfigH.Visible = false;
                    btnConfigAC.Enabled = false;
                    btnConfigAC.Visible = false;
                    btnConfigT.Enabled = false;
                    btnConfigT.Visible = false;
                    btnConfigAF.Enabled = false;
                    btnConfigAF.Visible = false;
                    //botones Materia Prima
                    btnEntradaMP.Visible = false;
                    btnSalidasMP.Visible = false;
                    //botones hilatura
                    btnEntradaH.Visible = false;
                    button1.Visible = false;
                    //botones Crudo
                    btnEntradaAC.Visible = false;
                    btnSalidasAC.Visible = false;
                    //botones Tintorería
                    btnEntradaT.Visible = false;
                    btnSalidasT.Visible = false;
                    //botones Hiltura Reenconado
                    btnEntradaHR.Visible = false;
                    btnSalidasHR.Visible = false;
                    //botones Almacén Final
                    btnEntradaAF.Visible = false;
                    btnSalidasAF.Visible = false;

                }
                if (lblCharge.Text=="Auxiliar")
                {
                    btnConfigPedido.Enabled = false;
                    btnConfigPedido.Visible = false;
                    btnConfigMP.Enabled = false;
                    btnConfigMP.Visible = false;
                    btnConfigHR.Enabled = false;
                    btnConfigHR.Visible = false;
                    btnConfigH.Enabled = true;
                    btnConfigH.Visible = true;
                    btnConfigAC.Enabled = false;
                    btnConfigAC.Visible = false;
                    btnConfigT.Enabled = false;
                    btnConfigT.Visible = false;
                    btnConfigAF.Enabled = false;
                    btnConfigAF.Visible = false;
                    //botones Materia Prima
                    btnEntradaMP.Visible = false;
                    btnSalidasMP.Visible = false;
                    //botones hilatura
                    btnEntradaH.Visible = false;
                    button1.Visible = false;
                    //botones Crudo
                    btnEntradaAC.Visible = false;
                    btnSalidasAC.Visible = false;
                    //botones Tintorería
                    btnEntradaT.Visible = false;
                    btnSalidasT.Visible = false;
                    //botones Hiltura Reenconado
                    btnEntradaHR.Visible = false;
                    btnSalidasHR.Visible = false;
                    //botones Almacén Final
                    btnEntradaAF.Visible = false;
                    btnSalidasAF.Visible = false;
                }
            }
            if (lblArea.Text == "Almacén M.P.")
            {
                btnSubMenuPedido.Enabled = false;
                btnSubMenuPedido.Visible = false;

                btnSubMenuHilatura.Enabled = true;
                btnSubMenuHilatura.Visible = true;
                btnEntradaH.Enabled = true;
                button1.Enabled = false;
                btnReporteSH.Enabled = false;
                btnReporteHiloEnProcesoH.Enabled = false;

                btnSubMenuAC.Enabled = false;
                btnSubMenuAC.Visible = false;
                btnSubMenuTintoreria.Enabled = false;
                btnSubMenuTintoreria.Visible = false;
                btnSubMenuHR.Enabled = false;
                btnSubMenuHR.Visible = false;
                btnSubMenuAF.Enabled = false;
                btnSubMenuAF.Visible = false;
                btnSubMenuSucursal1.Enabled = false;
                btnSubMenuSucursal1.Visible = false;
                btnSubS2.Enabled = false;
                btnSubS2.Visible = false;

                btnSubMenuConfig.Enabled = true;
                btnSubMenuConfig.Visible = true;
                btnConfigMateriaP.Enabled = true;

                btnConfigUsuarios.Visible = false;
                btnConfigProductos.Visible = false;

                btnConfigCajas.Visible = false;
                btnConfigColores.Visible = false;
                btnConfigClientes.Visible = false;
                btnConfigVendedores.Visible = false;
                btnConfigBolsas.Visible = false;

                if (lblCharge.Text == "Auxiliar")
                {
                    btnConfigMP.Enabled = false;
                    btnConfigMP.Visible = false;
                }
            }
            if (lblArea.Text == "Hilatura")
            {
                btnSubMenuPedido.Enabled = false;
                btnSubMenuPedido.Visible = false;
                btnSubMenuMateriaP.Enabled = false;
                btnSubMenuMateriaP.Visible = false;
                btnSubMenuAC.Enabled = false;
                btnSubMenuAC.Visible = false;
                btnSubMenuTintoreria.Enabled = false;
                btnSubMenuTintoreria.Visible = false;
                btnSubMenuAF.Enabled = false;
                btnSubMenuAF.Visible = false;
                btnSubMenuSucursal1.Enabled = false;
                btnSubMenuSucursal1.Visible = false;
                btnSubS2.Enabled = false;
                btnSubS2.Visible = false;
                btnConfigUsuarios.Enabled = false;
                btnConfigUsuarios.Visible = false;
                btnConfigProductos.Enabled = false;
                btnConfigProductos.Visible = false;
                btnConfigColores.Enabled = false;
                btnConfigColores.Visible = false;
                btnConfigClientes.Enabled = false;
                btnConfigClientes.Visible = false;
                btnConfigVendedores.Enabled = false;
                btnConfigVendedores.Visible = false;
                btnConfigMateriaP.Enabled = false;
                btnConfigMateriaP.Visible = false;
                btnConfigBolsas.Enabled = true;
                btnConfigBolsas.Visible = true;
                btnConfigProductos.Enabled = false;
                btnConfigProductos.Visible = false;
                if (lblCharge.Text == "Auxiliar")
                {
                    btnConfigHR.Enabled = false;
                    btnConfigHR.Visible = false;
                    btnConfigH.Enabled = false;
                    btnConfigH.Visible = false;
                    btnConfigUsuarios.Enabled = false;
                    btnConfigUsuarios.Visible = false;
                    btnConfigProductos.Enabled = false;
                    btnConfigProductos.Visible = false;
                    btnConfigColores.Enabled = false;
                    btnConfigColores.Visible = false;
                    btnConfigClientes.Enabled = false;
                    btnConfigClientes.Visible = false;
                    btnConfigVendedores.Enabled = false;
                    btnConfigVendedores.Visible = false;
                    btnConfigMateriaP.Enabled = false;
                    btnConfigMateriaP.Visible = false;
                    btnConfigBolsas.Enabled = true;
                    btnConfigBolsas.Visible = true;
                    btnConfigProductos.Enabled = false;
                    btnConfigProductos.Visible = false;
                    btnConfigProveedor.Enabled = false;
                    btnConfigProveedor.Visible = false;
                    btnConfigCajas.Enabled = false;
                    btnConfigCajas.Visible = false;
                }
            }
            if (lblArea.Text == "Almacén Crudo")
            {
                btnSubMenuPedido.Enabled = false;
                btnSubMenuPedido.Visible = false;
                btnSubMenuHilatura.Enabled = false;
                btnSubMenuHilatura.Visible = false;
                btnSubMenuMateriaP.Enabled = false;
                btnSubMenuMateriaP.Visible = false;
                btnSubMenuTintoreria.Enabled = false;
                btnSubMenuTintoreria.Visible = false;
                btnSubMenuHR.Enabled = false;
                btnSubMenuHR.Visible = false;
                btnSubMenuAF.Enabled = false;
                btnSubMenuAF.Visible = false;
                btnSubMenuSucursal1.Enabled = false;
                btnSubMenuSucursal1.Visible = false;
                btnSubS2.Enabled = false;
                btnSubS2.Visible = false;
                btnSubMenuConfig.Enabled = false;
                btnSubMenuConfig.Visible = false;
                if (lblCharge.Text == "Auxiliar")
                {
                    btnConfigAC.Enabled = false;
                    btnConfigAC.Visible = false;
                }
            }
            if (lblArea.Text == "Tintorería")
            {
                btnSubMenuPedido.Enabled = false;
                btnSubMenuPedido.Visible = false;
                btnSubMenuHilatura.Enabled = false;
                btnSubMenuHilatura.Visible = false;
                btnSubMenuAC.Enabled = false;
                btnSubMenuAC.Visible = false;
                btnSubMenuMateriaP.Enabled = false;
                btnSubMenuMateriaP.Visible = false;
                btnSubMenuHR.Enabled = false;
                btnSubMenuHR.Visible = false;
                btnSubMenuAF.Enabled = false;
                btnSubMenuAF.Visible = false;
                btnSubMenuSucursal1.Enabled = false;
                btnSubMenuSucursal1.Visible = false;
                btnSubS2.Enabled = false;
                btnSubS2.Visible = false;
                btnSubMenuConfig.Enabled = false;
                btnSubMenuConfig.Visible = false;
                if (lblCharge.Text == "Auxiliar")
                {
                    btnConfigT.Enabled = false;
                    btnConfigT.Visible = false;
                }
            }
            if (lblArea.Text == "Almacén Final")
            {
                btnSubMenuPedido.Enabled = false;
                btnSubMenuPedido.Visible = false;
                btnSubMenuHilatura.Enabled = false;
                btnSubMenuHilatura.Visible = false;
                btnSubMenuAC.Enabled = false;
                btnSubMenuAC.Visible = false;
                btnSubMenuTintoreria.Enabled = false;
                btnSubMenuTintoreria.Visible = false;
                btnSubMenuHR.Enabled = false;
                btnSubMenuHR.Visible = false;
                btnSubMenuMateriaP.Enabled = false;
                btnSubMenuMateriaP.Visible = false;
                btnSubMenuSucursal1.Enabled = false;
                btnSubMenuSucursal1.Visible = false;
                btnSubS2.Enabled = false;
                btnSubS2.Visible = false;
                btnSubMenuConfig.Enabled = false;
                btnSubMenuConfig.Visible = false;
                if (lblCharge.Text == "Auxiliar")
                {
                    btnConfigAF.Enabled = false;
                    btnConfigAF.Visible = false;
                }
            }
            if (lblArea.Text == "Sucursal 1")
            {
                btnSubMenuPedido.Enabled = false;
                btnSubMenuPedido.Visible = false;
                btnSubMenuHilatura.Enabled = false;
                btnSubMenuHilatura.Visible = false;
                btnSubMenuAC.Enabled = false;
                btnSubMenuAC.Visible = false;
                btnSubMenuTintoreria.Enabled = false;
                btnSubMenuTintoreria.Visible = false;
                btnSubMenuHR.Enabled = false;
                btnSubMenuHR.Visible = false;
                btnSubMenuMateriaP.Enabled = false;
                btnSubMenuMateriaP.Visible = false;
                btnSubS2.Enabled = false;
                btnSubS2.Visible = false;
                btnSubMenuAF.Enabled = false;
                btnSubMenuAF.Visible = false;
                btnSubMenuConfig.Enabled = false;
                btnSubMenuConfig.Visible = false;
                if (lblCharge.Text == "Auxiliar")
                {
                    btnConfigS2.Enabled = false;
                    btnConfigS2.Visible = false;
                }
            }
            if (lblArea.Text == "Sucursal 2")
            {
                btnSubMenuPedido.Enabled = false;
                btnSubMenuPedido.Visible = false;
                btnSubMenuHilatura.Enabled = false;
                btnSubMenuHilatura.Visible = false;
                btnSubMenuAC.Enabled = false;
                btnSubMenuAC.Visible = false;
                btnSubMenuTintoreria.Enabled = false;
                btnSubMenuTintoreria.Visible = false;
                btnSubMenuHR.Enabled = false;
                btnSubMenuHR.Visible = false;
                btnSubMenuMateriaP.Enabled = false;
                btnSubMenuMateriaP.Visible = false;
                btnSubMenuSucursal1.Enabled = false;
                btnSubMenuSucursal1.Visible = false;
                btnSubMenuAF.Enabled = false;
                btnSubMenuAF.Visible = false;
                btnSubMenuConfig.Enabled = false;
                btnSubMenuConfig.Visible = false;
                if (lblCharge.Text == "Auxiliar")
                {
                    btnConfigS1.Enabled = false;
                    btnConfigS1.Visible = false;
                }
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)

                activeForm.Close();
            activeForm = childForm;
            childForm.Dock = DockStyle.Fill;
            childForm.TopLevel = false;
            childForm.TopMost = true;
            childForm.FormBorderStyle = FormBorderStyle.None;
            pnlFormloader.Controls.Add(childForm);
            pnlFormloader.Tag = childForm;
            childForm.Show();
            userModel.eliminar_RegistroDuplicado();
        }

        private void hideSubMenu()
        {
            if (pnlSubMenuPedido.Visible == true)
                pnlSubMenuPedido.Visible = false;
            if (pnlSubMenuMP.Visible == true)
                pnlSubMenuMP.Visible = false;
            if (pnlSubMenuH.Visible == true)
                pnlSubMenuH.Visible = false;
            if (pnlSubMenuAC.Visible == true)
                pnlSubMenuAC.Visible = false;
            if (pnlSubMenuT.Visible == true)
                pnlSubMenuT.Visible = false;
            if (pnlSubMenuHR.Visible == true)
                pnlSubMenuHR.Visible = false;
            if (pnlSubMenuAF.Visible == true)
                pnlSubMenuAF.Visible = false;
            if (pnlSubMenuS1.Visible == true)
                pnlSubMenuS1.Visible = false;
            if (pnlSubMenuS2.Visible == true)
                pnlSubMenuS2.Visible = false;
            if (pnlSubMenuConfig.Visible == true)
                pnlSubMenuConfig.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void loadUserData()
        {
            lblName.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            lblArea.Text = UserLoginCache.Area;
            lblCharge.Text = UserLoginCache.Position;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmDashboard());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuPedido_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuPedido);
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
           if (AppCache.StatusBascula == 0)
                {
                    openChildForm(new frmCrearPedido());
                    hideSubMenu();
                }
                else
                    MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void btnConfigPedido_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigPedido());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReportePedido_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReportePedido());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuMateriaP_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuMP);
        }

        private void btnEntradaMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmEntradasMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalidasMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmSalidasMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteInventarioMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmInventarioMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteEMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteEntradaMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteSMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteSalidaMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnReporteProductoMP_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteProdMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnSubMenuHilatura_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuH);
        }

        private void btnEntradaH_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmSalidaH2());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalidasH_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmEntradaH());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigH_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigH());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteInventarioH_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmInventarioHilatura());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteEH_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteEntradaH());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteSH_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteSalidaH());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuAC_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuAC);
        }

        private void btnEntradaAC_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmEntradaAC());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalidasAC_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmSalidaAC());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigAC_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigAC());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteInventarioAC_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteInventarioAC());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteEAC_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteEntradaAC());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteSAC_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteSalidaAC());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuTintoreria_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuT);
        }

        private void btnEntradaT_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmEntradaT());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalidasT_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmSalidaT());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigT_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigT());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteInventarioT_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteInventarioT());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteET_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteEntradaT());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteST_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteSalidaT());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuHR_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuHR);
        }

        private void btnEntradaHR_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmEntradaHR());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalidasHR_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmSalidaHR());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigHR_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigHR());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteInventarioHR_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteInventarioHR());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteEHR_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteEntradaHR());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteSHR_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteSalidaHR());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuAF_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuAF);
        }

        private void btnEntradaAF_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmEntradaAF());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalidasAF_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmSalidaAF());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigAF_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigAF());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteInventarioAF_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteInventarioAF());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteEAF_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteEntradaAF());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteSAF_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteSalidaAF());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuSucursal1_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuS1);
        }

        private void btnReporteInventarioS1_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteInventarioS1());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteES1_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteEntradaS1());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteSS1_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteSalidaS1());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubS2_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuS2);
        }

        private void btnReporteInventarioS2_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteInventarioS2());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteES2_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteEntradaS2());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteSS2_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteSalidaS2());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnContact_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmContact());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuConfig_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuConfig);
        }

        private void btnConfigUsuarios_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigUsuarios());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigProductos_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigProductos());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigCajas_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigCajas());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigColores_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigColores());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigClientes_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigClientes());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            statusCerrar = true;
            if (AppCache.StatusBascula == 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de cerrar sesión?", "Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void btnEntradaH_Click_1(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmEntradaH());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigVendedores_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigVendedores());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigMateriaP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigMateriaP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigBolsas_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigBolsas());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteHiloEnProcesoH_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteHiloEnProcesoH());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmSalidaH2());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                if (statusCerrar == false)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Estás seguro de cerrar el programa?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                        MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    e.Cancel = false;
            }
                
            
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (statusCerrar == false)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmProductoEnProcesoAC());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmProductoEnProcesoT());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmProductoEnProcesoHR());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pnlFormloader_Scroll(object sender, ScrollEventArgs e)
        {
            //panel1.AutoScrollPosition= new Point(Math.Abs(panel1.AutoScrollPosition.X),Math.Abs(CurrentPoint.Y))
        }

        private void btnProdSCAF_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmProductoEnProcesoAF());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigProveedor_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigProveedores());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteProveedoresMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteNumRemisionAF_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteNumRemisionAF());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteMaterialSCMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cONSULTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                frmConsulta consulta = new frmConsulta();
                consulta.Show();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cONSULTATINTORERÍAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                frmConsultaTenAdelante consulta = new frmConsultaTenAdelante();
                consulta.Show();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                if (UserLoginCache.Area == "Sistemas")
                {
                    frmEditarTablas consulta = new frmEditarTablas();
                    consulta.Show();
                }
                else
                {
                    MessageBox.Show("No cuentas con los permisos para usar esta herramienta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEntradasS1_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmEntradaSucursal());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEntradasS2_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmEntradaSucursal());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalidasS1_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmSalidaSucursalll());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalidasS2_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmSalidaSucursal());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClienteS1_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigClienteSucursal());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNumRemisionS_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmReporteNumeroRemisionS());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigS1_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusBascula == 0)
            {
                openChildForm(new frmConfigSucursales());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
