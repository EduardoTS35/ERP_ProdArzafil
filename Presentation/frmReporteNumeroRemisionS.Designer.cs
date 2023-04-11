
namespace Presentation
{
    partial class frmReporteNumeroRemisionS
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PruebasLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PruebasLDeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnGuardarEM = new System.Windows.Forms.Button();
            this.tboxNumLote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLDeBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // reportViewer1
            // 
            reportDataSource4.Name = "Reporte";
            reportDataSource4.Value = this.ReporteBindingSource;
            reportDataSource5.Name = "Resumen";
            reportDataSource5.Value = this.PruebasLBindingSource;
            reportDataSource6.Name = "Detalles";
            reportDataSource6.Value = this.PruebasLDeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentation.Reportes.ReportesSucursal1.ReporteNumeroRemisionS.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 72);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1119, 642);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnGuardarEM
            // 
            this.btnGuardarEM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.btnGuardarEM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarEM.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarEM.ForeColor = System.Drawing.Color.White;
            this.btnGuardarEM.Location = new System.Drawing.Point(476, 12);
            this.btnGuardarEM.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarEM.Name = "btnGuardarEM";
            this.btnGuardarEM.Size = new System.Drawing.Size(156, 45);
            this.btnGuardarEM.TabIndex = 68;
            this.btnGuardarEM.Text = "Generar Reporte";
            this.btnGuardarEM.UseVisualStyleBackColor = false;
            this.btnGuardarEM.Click += new System.EventHandler(this.btnGuardarEM_Click);
            // 
            // tboxNumLote
            // 
            this.tboxNumLote.Location = new System.Drawing.Point(12, 35);
            this.tboxNumLote.Name = "tboxNumLote";
            this.tboxNumLote.Size = new System.Drawing.Size(224, 22);
            this.tboxNumLote.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(243, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 21);
            this.label3.TabIndex = 66;
            this.label3.Text = "Número de Remisión";
            // 
            // frmReporteNumeroRemisionS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1143, 726);
            this.Controls.Add(this.btnGuardarEM);
            this.Controls.Add(this.tboxNumLote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteNumeroRemisionS";
            this.Text = "frmReporteNumeroRemisionS";
            this.Load += new System.EventHandler(this.frmReporteNumeroRemisionS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLDeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteBindingSource;
        private System.Windows.Forms.BindingSource PruebasLBindingSource;
        private System.Windows.Forms.BindingSource PruebasLDeBindingSource;
        private System.Windows.Forms.Button btnGuardarEM;
        private System.Windows.Forms.TextBox tboxNumLote;
        private System.Windows.Forms.Label label3;
    }
}