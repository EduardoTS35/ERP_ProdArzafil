
namespace Presentation
{
    partial class frmReportePedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource11 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource12 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tboxNumPedido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPersonalizado = new System.Windows.Forms.Button();
            this.btnSemana = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.ReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PruebasLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PruebasLDeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLDeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource10.Name = "Reporte";
            reportDataSource10.Value = this.ReporteBindingSource;
            reportDataSource11.Name = "Resumen";
            reportDataSource11.Value = this.PruebasLBindingSource;
            reportDataSource12.Name = "Detalles";
            reportDataSource12.Value = this.PruebasLDeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource10);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource11);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource12);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentation.Reportes.ReportePedidos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(195, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(948, 726);
            this.reportViewer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.tboxNumPedido);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnPersonalizado);
            this.panel1.Controls.Add(this.btnSemana);
            this.panel1.Controls.Add(this.btnToday);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 726);
            this.panel1.TabIndex = 5;
            // 
            // tboxNumPedido
            // 
            this.tboxNumPedido.Location = new System.Drawing.Point(16, 61);
            this.tboxNumPedido.Name = "tboxNumPedido";
            this.tboxNumPedido.Size = new System.Drawing.Size(145, 22);
            this.tboxNumPedido.TabIndex = 5;
            this.tboxNumPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxNumPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxNumPedido_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Núm. Pedido";
            // 
            // btnPersonalizado
            // 
            this.btnPersonalizado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.btnPersonalizado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonalizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonalizado.ForeColor = System.Drawing.Color.White;
            this.btnPersonalizado.Location = new System.Drawing.Point(16, 105);
            this.btnPersonalizado.Margin = new System.Windows.Forms.Padding(4);
            this.btnPersonalizado.Name = "btnPersonalizado";
            this.btnPersonalizado.Size = new System.Drawing.Size(145, 37);
            this.btnPersonalizado.TabIndex = 0;
            this.btnPersonalizado.Text = "Núm. Orden";
            this.btnPersonalizado.UseVisualStyleBackColor = false;
            this.btnPersonalizado.Click += new System.EventHandler(this.btnPersonalizado_Click);
            // 
            // btnSemana
            // 
            this.btnSemana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.btnSemana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSemana.ForeColor = System.Drawing.Color.White;
            this.btnSemana.Location = new System.Drawing.Point(16, 539);
            this.btnSemana.Margin = new System.Windows.Forms.Padding(4);
            this.btnSemana.Name = "btnSemana";
            this.btnSemana.Size = new System.Drawing.Size(145, 37);
            this.btnSemana.TabIndex = 0;
            this.btnSemana.Text = "Vencidos";
            this.btnSemana.UseVisualStyleBackColor = false;
            this.btnSemana.Click += new System.EventHandler(this.btnSemana_Click);
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Location = new System.Drawing.Point(16, 315);
            this.btnToday.Margin = new System.Windows.Forms.Padding(4);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(145, 37);
            this.btnToday.TabIndex = 0;
            this.btnToday.Text = "Por Vencer";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // ReporteBindingSource
            // 
            this.ReporteBindingSource.DataSource = typeof(Domain.Reporte);
            // 
            // PruebasLBindingSource
            // 
            this.PruebasLBindingSource.DataSource = typeof(Domain.PruebasL);
            // 
            // PruebasLDeBindingSource
            // 
            this.PruebasLDeBindingSource.DataSource = typeof(Domain.PruebasLDe);
            // 
            // frmReportePedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1143, 726);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReportePedido";
            this.Text = "frmReportePedido";
            this.Load += new System.EventHandler(this.frmReportePedido_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLDeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteBindingSource;
        private System.Windows.Forms.BindingSource PruebasLBindingSource;
        private System.Windows.Forms.BindingSource PruebasLDeBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tboxNumPedido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPersonalizado;
        private System.Windows.Forms.Button btnSemana;
        private System.Windows.Forms.Button btnToday;
    }
}