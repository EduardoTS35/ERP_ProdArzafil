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
    public partial class frmConfigBolsas : Form
    {
        UserModel userModel = new UserModel();
        private bool editarBolsa = false;
        DataSet resultados = new DataSet();
        DataView mifiltro;
        double pesoBolsa;
        double pesoCono;
        double tara;
        double pesoN;
        double pesoB;
        string statusProcesoG;
        
        public frmConfigBolsas()
        {
            InitializeComponent();
            AppCache.modificarBolsafrm = false;
            Restricciones();
            MostrarStatus();
        }
        public void MostrarStatus()
        {
            cmbStatusBolsa.DataSource = userModel.MostrarStatus();
            cmbStatusBolsa.DisplayMember = "Descripcion";
            cmbStatusBolsa.ValueMember = "IdProceso";
        }
        public void Restricciones()
        {
            if (UserLoginCache.Area == "Hilatura")
            {
                btnAgregar.Enabled = false;
                btnBorrar.Enabled = false;
                btnCatalogoC.Enabled = false;
            }
        }

        private void MostrarBolsas()
        {
            resultados.Tables.Add(userModel.MostrarBolsas());
            this.mifiltro = ((DataTable)resultados.Tables[0]).DefaultView;
            dataGridView1.DataSource = mifiltro;
        }

        private void LimpiarDatos()
        {
            tboxIDBolsa.Text = "";
            tboxNumPedido.Text = "";
            tboxPesoB.Text = "";
            tboxPesoN.Text = "";
            tboxNumConos.Text = "";
            tboxIdTara.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tboxIDBolsa.Text != "" & tboxNumConos.Text != "")
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("¿Estás seguro de editar los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        userModel.ActualizarBolsa(tboxIDBolsa.Text, tboxNumPedido.Text, Convert.ToString(cmbStatusBolsa.SelectedValue), statusProcesoG,tboxPesoB.Text,tboxIdTara.Text,tboxNumConos.Text);
                        editarBolsa = false;
                        LimpiarDatos();
                        MessageBox.Show("Se actualizó correctamente la Bolsa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        AppCache.IdBolsa = 0;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Surgió un error: " + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }        
            else
                MessageBox.Show("Seleccione una Bolsa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (editarBolsa == true)
            {
                userModel.EliminarBolsa(tboxIDBolsa.Text);
                editarBolsa = false;
                LimpiarDatos();
                MessageBox.Show("Se eliminó exitosamente el registro\n Reinicie la venta para verificar el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                AppCache.IdBolsa = 0;
            }
            else
            {
                MessageBox.Show("Seleccione un resgistro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString() != "")
            {
                btnCrearBolsas.Enabled = true;
                btnCrearBolsas.Visible = true;
                editarBolsa = true;
                tboxPesoB.Text = dataGridView1.CurrentRow.Cells["PesoBruto"].Value.ToString();
                AppCache.IdBolsa = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString());
                statusProcesoG = dataGridView1.CurrentRow.Cells["StatusProceso"].Value.ToString();
                tboxIDBolsa.Text = dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString();
                tboxNumPedido.Text = dataGridView1.CurrentRow.Cells["NumPedido"].Value.ToString();

                tboxPesoN.Text = dataGridView1.CurrentRow.Cells["PesoNeto"].Value.ToString();
                tboxNumConos.Text = dataGridView1.CurrentRow.Cells["NumConos"].Value.ToString();
                cmbStatusBolsa.SelectedValue = dataGridView1.CurrentRow.Cells["StatusProceso"].Value.ToString();
                tboxIdTara.Text = dataGridView1.CurrentRow.Cells["IdCaja"].Value.ToString();
                Restricciones();
            }
            else
            {
                MessageBox.Show("Seleccione una Bolsa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCrearBolsas.Enabled = false;
                btnCrearBolsas.Visible = false;
                Restricciones();
            }
        }

        private void tboxBuscadorIDHilo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tboxBuscadorIDHilo.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {
                    cmbStatusProceso.Text = "";
                    int num3 = Convert.ToInt32(this.tboxBuscadorIDHilo.Text);
                    this.mifiltro.RowFilter = "IDBolsa = " + num3 + "";
                }
            }
            catch
            {
            }
        }

        private void cmbStatusProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbStatusProceso.Text.Length == 0)
                {
                    mifiltro.RowFilter = null;
                }
                else
                {
                    tboxBuscadorIDHilo.Clear();
                    int num3 = Convert.ToInt32(this.cmbStatusProceso.Text);
                    this.mifiltro.RowFilter = "StatusProceso = " + num3 + "";
                }
                if (cmbStatusProceso.Text == "2")
                    tboxDesc.Text = "Salida Hilatura";
                else if(cmbStatusProceso.Text == "3")
                    tboxDesc.Text = "Entrada Almacén Crudo";
                else if (cmbStatusProceso.Text == "4")
                    tboxDesc.Text = "Salida Almacén Crudo ";
                else if (cmbStatusProceso.Text == "5")
                    tboxDesc.Text = "Entrada Tintorería";
                else if (cmbStatusProceso.Text == "6")
                    tboxDesc.Text = "Salida Tintorería";
                else if (cmbStatusProceso.Text == "7")
                    tboxDesc.Text = "Entrada H. Reenconado";
                else if (cmbStatusProceso.Text == "8")
                    tboxDesc.Text = "Salida H. Reenconado";
                else if (cmbStatusProceso.Text == "9")
                    tboxDesc.Text = "Entrada Almacen Final";
                else if (cmbStatusProceso.Text == "10")
                    tboxDesc.Text = "Salida Almacen Final Sucursal";
                else if (cmbStatusProceso.Text == "11")
                    tboxDesc.Text = "Status Intermedio Sucursales";
                else if (cmbStatusProceso.Text == "12")
                    tboxDesc.Text = "Sucursal 1";
                else if (cmbStatusProceso.Text == "13")
                    tboxDesc.Text = "Sucursal 2";
            }
            catch
            {
            }
        }

        private void btnCrearBolsas_Click(object sender, EventArgs e)
        {
            if (AppCache.modificarBolsafrm == false)
            {
                AppCache.modificarBolsafrm = true;
                frmModificarBolsa frmModificarBolsa = new frmModificarBolsa();
                frmModificarBolsa.Show();
            }
            else
                MessageBox.Show("Ya se ecnuentra abierta una ventana de configuración.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void cbModificarTara_CheckedChanged(object sender, EventArgs e)
        {
            if (editarBolsa == false)
            {
                cbModificarTara.Checked = false;
                MessageBox.Show("Seleccione una Bolsa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else
            {
                if (cbModificarTara.Checked == true)
                {
                    btnCatalogoC.Enabled = true;
                    btnCatalogoC.Visible = true;
                    tboxIdTara.Enabled = false;
                    
                }
                else if (cbModificarTara.Checked == false)
                {
                    btnCatalogoC.Enabled = false;
                    btnCatalogoC.Visible = false;
                    tboxIdTara.Enabled = false;
                    LimpiarDatos();
                    editarBolsa = false;
                }
            }
        }

        private void btnCatalogoC_Click(object sender, EventArgs e)
        {
            frmCatalogoCajas frm = new frmCatalogoCajas();
            frm.Show();
            timerCatalogoC.Start();
        }

        private void timerCatalogoC_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppCache.ActualDescCaja != null)
                {
                    btnCatalogoC.Enabled = true;
                    tboxIdTara.Text = AppCache.ActualIdCaja;
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
                pesoN = Convert.ToDouble(tboxPesoN.Text);
                tara = pesoCono + pesoBolsa;
                pesoB = Math.Round(pesoN + tara/1000, 2);
                tboxPesoB.Text = Convert.ToString(pesoB);
            }
            catch
            {

            }
        }

        private void frmConfigBolsas_Load(object sender, EventArgs e)
        {
            MostrarBolsas();
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

        private void tboxNumPedido_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString() != "")
            {
                btnCrearBolsas.Enabled = true;
                btnCrearBolsas.Visible = true;
                editarBolsa = true;
                tboxPesoB.Text = dataGridView1.CurrentRow.Cells["PesoBruto"].Value.ToString();
                AppCache.IdBolsa = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString());
                statusProcesoG = dataGridView1.CurrentRow.Cells["StatusProceso"].Value.ToString();
                tboxIDBolsa.Text = dataGridView1.CurrentRow.Cells["IDBolsa"].Value.ToString();
                tboxNumPedido.Text = dataGridView1.CurrentRow.Cells["NumPedido"].Value.ToString();

                tboxPesoN.Text = dataGridView1.CurrentRow.Cells["PesoNeto"].Value.ToString();
                tboxNumConos.Text = dataGridView1.CurrentRow.Cells["NumConos"].Value.ToString();
                cmbStatusBolsa.SelectedValue = dataGridView1.CurrentRow.Cells["StatusProceso"].Value.ToString();
                tboxIdTara.Text = dataGridView1.CurrentRow.Cells["IdCaja"].Value.ToString();
                Restricciones();
            }
            else
            {
                MessageBox.Show("Seleccione una Bolsa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCrearBolsas.Enabled = false;
                btnCrearBolsas.Visible = false;
                Restricciones();
            }
        }
    }
}
