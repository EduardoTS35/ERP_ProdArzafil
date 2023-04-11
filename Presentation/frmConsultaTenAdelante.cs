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
    public partial class frmConsultaTenAdelante : Form
    {
        frmStatusProceso frm = new frmStatusProceso();
        List<string> columnasBolsas = new List<string>() { "B.IDBolsa", "B.NumPedido","CL.IDCliente","CL.RazonSocial","CL.Edo","CL.Ciudad", "B.IdHilo", "B.IdColor", "B.LoteHilatura", "B.LoteTenido", "B.IdCaja", "B.NumConos", "B.StatusProceso", "B.NumRemision", "B.Malla", "B.ColorCono" };
        string Consulta;
        UserModel userModel = new UserModel();
        public frmConsultaTenAdelante()
        {
            InitializeComponent();
        }
        public void CargarItemsCmb()
        {
            
            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dataGridView1.Columns["columna"];

            if (cmbTabla.Text == "Bolsas")
            {
                column.DataSource = columnasBolsas;
                cmbTabla.ValueMember = "Bolsas";
                frm.Show();

            }
        }
        private void GenerarConsulta()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["operador"].Value != null)
                    {
                        if (row.Cells["conector"].Value != null)
                        {
                            var column = row.Cells["columna"].Value.ToString();
                            var operador = row.Cells["Operador"].Value.ToString();
                            var valor = row.Cells["valor"].Value.ToString();
                            var conector = row.Cells["conector"].Value.ToString();

                            string lineaConsulta = " " + column + " " + operador + " '" + valor + "' " + conector;
                            Consulta += lineaConsulta;
                        }
                        else if (row.Cells["conector"].Value == null)
                        {
                            var column = row.Cells["columna"].Value.ToString();
                            var operador = row.Cells["Operador"].Value.ToString();
                            var valor = row.Cells["valor"].Value.ToString();
                            string lineaConsulta = " " + column + " " + operador + " '" + valor + "' ";
                            Consulta += lineaConsulta;
                        }

                    }
                }

            }
            catch (Exception)
            {
            }

        }

        private void cmbTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                CargarItemsCmb();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReportesGenerales frm = new frmReportesGenerales();
            Consulta = "SELECT b.IDBolsa,b.FechaRegistro,b.NumPedido,CL.IDCliente,CL.RazonSocial,CL.Edo,CL.Ciudad,b.IdHilo,b.IdColor,b.LoteHilatura,b.LoteTenido,B.IdCaja,B.PesoBruto,B.PesoNeto," +
                "B.NumConos,B.StatusProceso,B.FechaSalida,B.NumRemision,B.Malla,B.ColorCono " +
                "FROM Bolsas b " +
                "INNER JOIN Pedidos P " +
                "ON P.IDPedido = B.NumPedido " +
                "INNER JOIN Clientes CL " +
                "ON CL.IDCliente = P.IdCliente " +
                "WHERE B.IdHilo = P.IdHilo " +
                "AND B.IdColor = P.IdColor " +
                "AND ";
            GenerarConsulta();
            frm.dataGridView1.DataSource = userModel.generarReporte(Consulta);
            frm.Consulta = Consulta;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}
