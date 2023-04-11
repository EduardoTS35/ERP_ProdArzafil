
namespace Presentation
{
    partial class frmReporteEntradaT
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteEntradaT));
            this.ReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PruebasLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PruebasLDeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtPToDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLDeBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
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
            reportDataSource1.Name = "Reporte";
            reportDataSource1.Value = this.ReporteBindingSource;
            reportDataSource2.Name = "Resumen";
            reportDataSource2.Value = this.PruebasLBindingSource;
            reportDataSource3.Name = "Detalles";
            reportDataSource3.Value = this.PruebasLDeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentation.Reportes.ReportesTintoreria.ReporteEntradasTintoreria.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(238, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(893, 701);
            this.reportViewer1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnAplicar);
            this.panel1.Controls.Add(this.btnHoy);
            this.panel1.Controls.Add(this.btnMes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtPFromDate);
            this.panel1.Controls.Add(this.dtPToDate);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 700);
            this.panel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 473);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "a: ";
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnAplicar.FlatAppearance.BorderSize = 0;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnAplicar.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(20, 597);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(155, 52);
            this.btnAplicar.TabIndex = 14;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnHoy.FlatAppearance.BorderSize = 0;
            this.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoy.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnHoy.Image = ((System.Drawing.Image)(resources.GetObject("btnHoy.Image")));
            this.btnHoy.Location = new System.Drawing.Point(20, 19);
            this.btnHoy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(166, 52);
            this.btnHoy.TabIndex = 12;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHoy.UseVisualStyleBackColor = false;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnMes
            // 
            this.btnMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnMes.FlatAppearance.BorderSize = 0;
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnMes.Image = ((System.Drawing.Image)(resources.GetObject("btnMes.Image")));
            this.btnMes.Location = new System.Drawing.Point(20, 179);
            this.btnMes.Margin = new System.Windows.Forms.Padding(4);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(166, 52);
            this.btnMes.TabIndex = 13;
            this.btnMes.Text = "Mes";
            this.btnMes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMes.UseVisualStyleBackColor = false;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 398);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "de: ";
            // 
            // dtPFromDate
            // 
            this.dtPFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPFromDate.Location = new System.Drawing.Point(65, 393);
            this.dtPFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtPFromDate.Name = "dtPFromDate";
            this.dtPFromDate.Size = new System.Drawing.Size(96, 21);
            this.dtPFromDate.TabIndex = 1;
            // 
            // dtPToDate
            // 
            this.dtPToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPToDate.Location = new System.Drawing.Point(65, 468);
            this.dtPToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtPToDate.Name = "dtPToDate";
            this.dtPToDate.Size = new System.Drawing.Size(96, 21);
            this.dtPToDate.TabIndex = 1;
            // 
            // frmReporteEntradaT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1143, 726);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReporteEntradaT";
            this.Text = "frmReporteEntradaT";
            this.Load += new System.EventHandler(this.frmReporteEntradaT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PruebasLDeBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteBindingSource;
        private System.Windows.Forms.BindingSource PruebasLBindingSource;
        private System.Windows.Forms.BindingSource PruebasLDeBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPFromDate;
        private System.Windows.Forms.DateTimePicker dtPToDate;
    }
}