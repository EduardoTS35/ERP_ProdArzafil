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
using Domain;
using GemBox.Spreadsheet;
using Grumsom.cSharp;

namespace Presentation
{
    public partial class frmReportesGenerales : Form
    {
        public bool estadoConsulta = false;
        double pesoBruto = 0;
        double pesoNeto = 0;
        int bolsas;
        bool slc;
        UserModel userModel = new UserModel();
        public string Consulta { get; set; }



        public frmReportesGenerales()
        {
            InitializeComponent();
        }
        public void ReiniciarValores()
        {
            pesoBruto = 0;
            pesoNeto = 0;
            bolsas = 0;
        }

        public void SeleccionarElementos()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                checkedComboBox1.Items.Add(column.HeaderText, false);
            }
        }
        public void VisualizarColumnas(int item,bool estado)
        {
            try
            {
                dataGridView1.Columns[item].Visible = estado;
            }
            catch
            {

            }
        }
        private void ExportarAExcel(DataTable table)
        {
            InsertDataTableOptions options = new InsertDataTableOptions();
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            var workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("Reporte");
            options.ColumnHeaders = true;
            worksheet.InsertDataTable(table,options);
            workbook.Save("Reporte.xls");
        }
        public void CalcularTotales()
        {
            pesoBruto = 0;
            pesoNeto = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (dataGridView1.Columns.Contains("PesoBruto"))
                {
                    pesoBruto += Convert.ToDouble(row.Cells["PesoBruto"].Value);
                }
                if (dataGridView1.Columns.Contains("PesoNeto"))
                {
                    pesoNeto += Convert.ToDouble(row.Cells["PesoNeto"].Value);
                }
            }
            Math.Round(pesoBruto, 2);
            Math.Round(pesoNeto, 2);
            bolsas = dataGridView1.RowCount;
        }
        public void ImprimirReporte()
        {
            Print pdgv = new Print(dataGridView1);

            if (pesoBruto != 0 & pesoNeto != 0)
            {
                pdgv.Footer = "Peso Bruto Total = " + Math.Round(pesoBruto, 2) + "\nPeso Neto Total= " + Math.Round(pesoNeto, 2) + "\nBolsas Totales=" + bolsas;
            }
            else
            {
                pdgv.Footer = "S.E.T Programs";
            }
            pdgv.Title = "Unidad Arzafil S.A DE C.V";

            pdgv.SubTitle = "Exelencia, moda y vanguardia\n---";
            pdgv.PageNumbers = true;
            pdgv.StartPrinting();
        }
        public void VisualizarReporte()
        {
            Print pdgv = new Print(dataGridView1);
            if (pesoBruto != 0 & pesoNeto != 0)
            {
                pdgv.Footer = "Peso Bruto Total = " + Math.Round(pesoBruto, 2) + "\nPeso Neto Total= " + Math.Round(pesoNeto, 2) + "\nBolsas Totales=" + bolsas;
            }
            else
            {
                pdgv.Footer = "S.E.T Programs";
            }
            pdgv.Title = "Unidad Arzafil S.A DE C.V";
            pdgv.SubTitle = "Exelencia, moda y vanguardia\n---";
            pdgv.PageNumbers = true;
            pdgv.PrintPreviewDialog = true;
            pdgv.StartPrinting();
        }
        public void ConfigReporte()
        {
            Print pdgv = new Print(dataGridView1);
            if (pesoBruto != 0 & pesoNeto != 0)
            {
                pdgv.Footer = "Peso Bruto Total = " + Math.Round(pesoBruto, 2) + "\nPeso Neto Total= " + Math.Round(pesoNeto, 2) + "\nBolsas Totales=" + bolsas;
            }
            else
            {
                pdgv.Footer = "S.E.T Programs";
            }
            pdgv.Title = "Unidad Arzafil S.A DE C.V";

            pdgv.SubTitle = "Exelencia, moda y vanguardia\n---";
            pdgv.PageNumbers = true;
            pdgv.PrintSettingsDialog = true;
            pdgv.StartPrinting();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcularTotales();
            DialogResult dialogResult = MessageBox.Show("Solo se imprimirán las primeras 7 columnas", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                ImprimirReporte();
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            CalcularTotales();
            DialogResult dialogResult = MessageBox.Show("Solo se imprimirán las primeras 7 columnas", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                VisualizarReporte();
            }
            else if (dialogResult == DialogResult.No)
            {

            }



        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            CalcularTotales();
            DialogResult dialogResult = MessageBox.Show("Solo se imprimirán las primeras 7 columnas", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                ConfigReporte();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            
        }

            

        private void checkedComboBox1_Enter(object sender, EventArgs e)
        {
            if (slc != true)
            {
                SeleccionarElementos();
                slc = true;
            }
            
        }

        private void checkedComboBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                VisualizarColumnas(e.Index,Convert.ToBoolean(checkedComboBox1.GetItemCheckState(e.Index)));
            }
            catch
            {

            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = userModel.generarReporte(Consulta);
                ExportarAExcel(table);
                MessageBox.Show("Se guardó correctamente el archivo.","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch
            {

            }
        }

        private void frmReportesGenerales_FormClosed(object sender, FormClosedEventArgs e)
        {
            pesoBruto = 0;
            pesoNeto = 0;
        }
    }

}
