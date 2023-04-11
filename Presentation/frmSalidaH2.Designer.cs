
namespace Presentation
{
    partial class frmSalidaH2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalidaH2));
            this.lblBascula = new System.Windows.Forms.Label();
            this.cmbIdBolsa = new System.Windows.Forms.ComboBox();
            this.cmbComport = new System.Windows.Forms.ComboBox();
            this.tboxNumLote = new System.Windows.Forms.TextBox();
            this.tboxNumConos = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.btnCatalogoHilos = new System.Windows.Forms.Button();
            this.btnCatalogoCajas = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.lblBolsa = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTara2 = new System.Windows.Forms.Label();
            this.lblTara = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPesoN = new System.Windows.Forms.Label();
            this.lblPesoB = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblMultConos = new System.Windows.Forms.Label();
            this.lblPesoCono = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumLote = new System.Windows.Forms.Label();
            this.lblDescCaja = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDescHilo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerBascula = new System.Windows.Forms.Timer(this.components);
            this.timerCatalogoH = new System.Windows.Forms.Timer(this.components);
            this.timerCatalogoC = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.cmbMalla = new System.Windows.Forms.ComboBox();
            this.cmbColorCono = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tboxBascula = new System.Windows.Forms.TextBox();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tboxNumPedido = new System.Windows.Forms.TextBox();
            this.lblNumPedido = new System.Windows.Forms.Label();
            this.lblCodColor = new System.Windows.Forms.Label();
            this.tboxColor = new System.Windows.Forms.TextBox();
            this.lblLoteT = new System.Windows.Forms.Label();
            this.tboxLoteT = new System.Windows.Forms.TextBox();
            this.tboxNotas = new System.Windows.Forms.TextBox();
            this.cboxNotas = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblBascula
            // 
            this.lblBascula.AutoSize = true;
            this.lblBascula.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBascula.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblBascula.Location = new System.Drawing.Point(862, 203);
            this.lblBascula.Name = "lblBascula";
            this.lblBascula.Size = new System.Drawing.Size(206, 36);
            this.lblBascula.TabIndex = 46;
            this.lblBascula.Text = "Datos Báscula";
            this.lblBascula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbIdBolsa
            // 
            this.cmbIdBolsa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbIdBolsa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIdBolsa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbIdBolsa.Enabled = false;
            this.cmbIdBolsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdBolsa.FormattingEnabled = true;
            this.cmbIdBolsa.Items.AddRange(new object[] {
            "hola",
            "adios",
            "arre",
            "tal vez",
            "no se"});
            this.cmbIdBolsa.Location = new System.Drawing.Point(766, 686);
            this.cmbIdBolsa.Name = "cmbIdBolsa";
            this.cmbIdBolsa.Size = new System.Drawing.Size(166, 32);
            this.cmbIdBolsa.TabIndex = 45;
            // 
            // cmbComport
            // 
            this.cmbComport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbComport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComport.FormattingEnabled = true;
            this.cmbComport.Location = new System.Drawing.Point(766, 12);
            this.cmbComport.Name = "cmbComport";
            this.cmbComport.Size = new System.Drawing.Size(91, 37);
            this.cmbComport.TabIndex = 45;
            // 
            // tboxNumLote
            // 
            this.tboxNumLote.Location = new System.Drawing.Point(28, 348);
            this.tboxNumLote.MaxLength = 10;
            this.tboxNumLote.Name = "tboxNumLote";
            this.tboxNumLote.Size = new System.Drawing.Size(154, 22);
            this.tboxNumLote.TabIndex = 44;
            this.tboxNumLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxNumLote_KeyPress);
            // 
            // tboxNumConos
            // 
            this.tboxNumConos.Location = new System.Drawing.Point(192, 422);
            this.tboxNumConos.MaxLength = 3;
            this.tboxNumConos.Name = "tboxNumConos";
            this.tboxNumConos.Size = new System.Drawing.Size(73, 22);
            this.tboxNumConos.TabIndex = 44;
            this.tboxNumConos.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tboxNumConos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxNumConos_KeyPress);
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnConectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.ForeColor = System.Drawing.Color.White;
            this.btnConectar.Location = new System.Drawing.Point(976, 12);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(154, 47);
            this.btnConectar.TabIndex = 41;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnDesconectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesconectar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesconectar.ForeColor = System.Drawing.Color.White;
            this.btnDesconectar.Location = new System.Drawing.Point(976, 67);
            this.btnDesconectar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(154, 47);
            this.btnDesconectar.TabIndex = 42;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = false;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Gainsboro;
            this.label24.Location = new System.Drawing.Point(864, 27);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 23);
            this.label24.TabIndex = 43;
            this.label24.Text = "Puerto";
            // 
            // btnCatalogoHilos
            // 
            this.btnCatalogoHilos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnCatalogoHilos.FlatAppearance.BorderSize = 0;
            this.btnCatalogoHilos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogoHilos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogoHilos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnCatalogoHilos.Image = ((System.Drawing.Image)(resources.GetObject("btnCatalogoHilos.Image")));
            this.btnCatalogoHilos.Location = new System.Drawing.Point(29, 84);
            this.btnCatalogoHilos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCatalogoHilos.Name = "btnCatalogoHilos";
            this.btnCatalogoHilos.Size = new System.Drawing.Size(153, 52);
            this.btnCatalogoHilos.TabIndex = 38;
            this.btnCatalogoHilos.Text = "Catálogo Hilos";
            this.btnCatalogoHilos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCatalogoHilos.UseVisualStyleBackColor = false;
            this.btnCatalogoHilos.Click += new System.EventHandler(this.btnCatalogoHilos_Click);
            // 
            // btnCatalogoCajas
            // 
            this.btnCatalogoCajas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnCatalogoCajas.FlatAppearance.BorderSize = 0;
            this.btnCatalogoCajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogoCajas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogoCajas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnCatalogoCajas.Image = ((System.Drawing.Image)(resources.GetObject("btnCatalogoCajas.Image")));
            this.btnCatalogoCajas.Location = new System.Drawing.Point(27, 164);
            this.btnCatalogoCajas.Margin = new System.Windows.Forms.Padding(4);
            this.btnCatalogoCajas.Name = "btnCatalogoCajas";
            this.btnCatalogoCajas.Size = new System.Drawing.Size(153, 52);
            this.btnCatalogoCajas.TabIndex = 39;
            this.btnCatalogoCajas.Text = "Catálogo Cajas";
            this.btnCatalogoCajas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCatalogoCajas.UseVisualStyleBackColor = false;
            this.btnCatalogoCajas.Click += new System.EventHandler(this.btnCatalogoCajas_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label20.Location = new System.Drawing.Point(150, 526);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 34);
            this.label20.TabIndex = 37;
            this.label20.Text = "+";
            // 
            // lblBolsa
            // 
            this.lblBolsa.AutoSize = true;
            this.lblBolsa.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBolsa.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblBolsa.Location = new System.Drawing.Point(223, 560);
            this.lblBolsa.Name = "lblBolsa";
            this.lblBolsa.Size = new System.Drawing.Size(21, 23);
            this.lblBolsa.TabIndex = 33;
            this.lblBolsa.Text = "0";
            this.lblBolsa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(837, 421);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 32);
            this.label7.TabIndex = 37;
            this.label7.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label18.Location = new System.Drawing.Point(153, 572);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(160, 23);
            this.label18.TabIndex = 36;
            this.label18.Text = "_______________";
            // 
            // lblTara2
            // 
            this.lblTara2.AutoSize = true;
            this.lblTara2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTara2.ForeColor = System.Drawing.Color.White;
            this.lblTara2.Location = new System.Drawing.Point(948, 466);
            this.lblTara2.Name = "lblTara2";
            this.lblTara2.Size = new System.Drawing.Size(31, 32);
            this.lblTara2.TabIndex = 33;
            this.lblTara2.Text = "0";
            this.lblTara2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTara
            // 
            this.lblTara.AutoSize = true;
            this.lblTara.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTara.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTara.Location = new System.Drawing.Point(223, 608);
            this.lblTara.Name = "lblTara";
            this.lblTara.Size = new System.Drawing.Size(21, 23);
            this.lblTara.TabIndex = 35;
            this.lblTara.Text = "0";
            this.lblTara.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(850, 486);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(240, 32);
            this.label9.TabIndex = 36;
            this.label9.Text = "_______________";
            // 
            // lblPesoN
            // 
            this.lblPesoN.AutoSize = true;
            this.lblPesoN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesoN.ForeColor = System.Drawing.Color.White;
            this.lblPesoN.Location = new System.Drawing.Point(948, 551);
            this.lblPesoN.Name = "lblPesoN";
            this.lblPesoN.Size = new System.Drawing.Size(31, 32);
            this.lblPesoN.TabIndex = 35;
            this.lblPesoN.Text = "0";
            this.lblPesoN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPesoB
            // 
            this.lblPesoB.AutoSize = true;
            this.lblPesoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesoB.ForeColor = System.Drawing.Color.White;
            this.lblPesoB.Location = new System.Drawing.Point(948, 391);
            this.lblPesoB.Name = "lblPesoB";
            this.lblPesoB.Size = new System.Drawing.Size(31, 32);
            this.lblPesoB.TabIndex = 34;
            this.lblPesoB.Text = "0";
            this.lblPesoB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label14.Location = new System.Drawing.Point(158, 468);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 23);
            this.label14.TabIndex = 32;
            this.label14.Text = "X";
            // 
            // lblMultConos
            // 
            this.lblMultConos.AutoSize = true;
            this.lblMultConos.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultConos.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblMultConos.Location = new System.Drawing.Point(222, 515);
            this.lblMultConos.Name = "lblMultConos";
            this.lblMultConos.Size = new System.Drawing.Size(21, 23);
            this.lblMultConos.TabIndex = 30;
            this.lblMultConos.Text = "0";
            this.lblMultConos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPesoCono
            // 
            this.lblPesoCono.AutoSize = true;
            this.lblPesoCono.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesoCono.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPesoCono.Location = new System.Drawing.Point(222, 468);
            this.lblPesoCono.Name = "lblPesoCono";
            this.lblPesoCono.Size = new System.Drawing.Size(21, 23);
            this.lblPesoCono.TabIndex = 29;
            this.lblPesoCono.Text = "0";
            this.lblPesoCono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label22.Location = new System.Drawing.Point(24, 608);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 23);
            this.label22.TabIndex = 24;
            this.label22.Text = "Tara";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(24, 515);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "Total";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label21.Location = new System.Drawing.Point(24, 560);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 23);
            this.label21.TabIndex = 22;
            this.label21.Text = "Bolsa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(24, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "Núm. Conos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(24, 468);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "Peso Cono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(648, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 32);
            this.label3.TabIndex = 21;
            this.label3.Text = "Peso Neto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(682, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 32);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tara";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(640, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "Peso Bruto";
            // 
            // lblNumLote
            // 
            this.lblNumLote.AutoSize = true;
            this.lblNumLote.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumLote.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblNumLote.Location = new System.Drawing.Point(222, 346);
            this.lblNumLote.Name = "lblNumLote";
            this.lblNumLote.Size = new System.Drawing.Size(101, 23);
            this.lblNumLote.TabIndex = 19;
            this.lblNumLote.Text = "Núm. Lote";
            this.lblNumLote.TextChanged += new System.EventHandler(this.lblDescCaja_TextChanged);
            // 
            // lblDescCaja
            // 
            this.lblDescCaja.AutoSize = true;
            this.lblDescCaja.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescCaja.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDescCaja.Location = new System.Drawing.Point(223, 179);
            this.lblDescCaja.Name = "lblDescCaja";
            this.lblDescCaja.Size = new System.Drawing.Size(119, 23);
            this.lblDescCaja.TabIndex = 19;
            this.lblDescCaja.Text = "Descripción";
            this.lblDescCaja.TextChanged += new System.EventHandler(this.lblDescCaja_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(972, 694);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 23);
            this.label8.TabIndex = 19;
            this.label8.Text = "Consecutivo";
            // 
            // lblDescHilo
            // 
            this.lblDescHilo.AutoSize = true;
            this.lblDescHilo.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescHilo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDescHilo.Location = new System.Drawing.Point(222, 99);
            this.lblDescHilo.Name = "lblDescHilo";
            this.lblDescHilo.Size = new System.Drawing.Size(119, 23);
            this.lblDescHilo.TabIndex = 19;
            this.lblDescHilo.Text = "Descripción";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label13.Location = new System.Drawing.Point(152, 487);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 23);
            this.label13.TabIndex = 31;
            this.label13.Text = "_______________";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timerBascula
            // 
            this.timerBascula.Tick += new System.EventHandler(this.timerBascula_Tick);
            // 
            // timerCatalogoH
            // 
            this.timerCatalogoH.Tick += new System.EventHandler(this.timerCatalogoH_Tick);
            // 
            // timerCatalogoC
            // 
            this.timerCatalogoC.Tick += new System.EventHandler(this.timerCatalogoC_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.Imprimir);
            // 
            // cmbMalla
            // 
            this.cmbMalla.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMalla.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMalla.Enabled = false;
            this.cmbMalla.FormattingEnabled = true;
            this.cmbMalla.Items.AddRange(new object[] {
            "Limpia",
            "Media",
            "Sucia"});
            this.cmbMalla.Location = new System.Drawing.Point(29, 244);
            this.cmbMalla.Name = "cmbMalla";
            this.cmbMalla.Size = new System.Drawing.Size(153, 24);
            this.cmbMalla.TabIndex = 45;
            // 
            // cmbColorCono
            // 
            this.cmbColorCono.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbColorCono.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbColorCono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorCono.Enabled = false;
            this.cmbColorCono.FormattingEnabled = true;
            this.cmbColorCono.Items.AddRange(new object[] {
            "Blanco",
            "Azul",
            "Rojo",
            "Carton"});
            this.cmbColorCono.Location = new System.Drawing.Point(29, 296);
            this.cmbColorCono.Name = "cmbColorCono";
            this.cmbColorCono.Size = new System.Drawing.Size(153, 24);
            this.cmbColorCono.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Location = new System.Drawing.Point(222, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "Color de Cono";
            this.label10.TextChanged += new System.EventHandler(this.lblDescCaja_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Location = new System.Drawing.Point(223, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 23);
            this.label12.TabIndex = 19;
            this.label12.Text = "Malla";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(388, 296);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 27);
            this.checkBox1.TabIndex = 48;
            this.checkBox1.Text = "Habilitado";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(388, 249);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(130, 27);
            this.checkBox2.TabIndex = 48;
            this.checkBox2.Text = "Habilitado";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // tboxBascula
            // 
            this.tboxBascula.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxBascula.Location = new System.Drawing.Point(852, 242);
            this.tboxBascula.Name = "tboxBascula";
            this.tboxBascula.Size = new System.Drawing.Size(226, 75);
            this.tboxBascula.TabIndex = 49;
            this.tboxBascula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbTurno
            // 
            this.cmbTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Items.AddRange(new object[] {
            "1ro",
            "2do",
            "3er",
            "4to"});
            this.cmbTurno.Location = new System.Drawing.Point(29, 12);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(91, 37);
            this.cmbTurno.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(134, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 23);
            this.label11.TabIndex = 51;
            this.label11.Text = "Turno";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(332, 670);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(394, 47);
            this.button1.TabIndex = 52;
            this.button1.Text = "Imprimir y Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.checkBox3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox3.Location = new System.Drawing.Point(444, 19);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(165, 27);
            this.checkBox3.TabIndex = 53;
            this.checkBox3.Text = "Almacén Final";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckStateChanged += new System.EventHandler(this.checkBox3_CheckStateChanged);
            // 
            // tboxNumPedido
            // 
            this.tboxNumPedido.Enabled = false;
            this.tboxNumPedido.Location = new System.Drawing.Point(448, 52);
            this.tboxNumPedido.MaxLength = 30;
            this.tboxNumPedido.Name = "tboxNumPedido";
            this.tboxNumPedido.Size = new System.Drawing.Size(165, 22);
            this.tboxNumPedido.TabIndex = 54;
            this.tboxNumPedido.Visible = false;
            // 
            // lblNumPedido
            // 
            this.lblNumPedido.AutoSize = true;
            this.lblNumPedido.BackColor = System.Drawing.Color.Transparent;
            this.lblNumPedido.Enabled = false;
            this.lblNumPedido.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPedido.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNumPedido.Location = new System.Drawing.Point(620, 52);
            this.lblNumPedido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumPedido.Name = "lblNumPedido";
            this.lblNumPedido.Size = new System.Drawing.Size(129, 23);
            this.lblNumPedido.TabIndex = 55;
            this.lblNumPedido.Text = "Núm. Pedido";
            this.lblNumPedido.Visible = false;
            // 
            // lblCodColor
            // 
            this.lblCodColor.AutoSize = true;
            this.lblCodColor.BackColor = System.Drawing.Color.Transparent;
            this.lblCodColor.Enabled = false;
            this.lblCodColor.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodColor.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCodColor.Location = new System.Drawing.Point(620, 92);
            this.lblCodColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodColor.Name = "lblCodColor";
            this.lblCodColor.Size = new System.Drawing.Size(110, 23);
            this.lblCodColor.TabIndex = 57;
            this.lblCodColor.Text = "Cód. Color";
            this.lblCodColor.Visible = false;
            // 
            // tboxColor
            // 
            this.tboxColor.Enabled = false;
            this.tboxColor.Location = new System.Drawing.Point(448, 92);
            this.tboxColor.MaxLength = 30;
            this.tboxColor.Name = "tboxColor";
            this.tboxColor.Size = new System.Drawing.Size(165, 22);
            this.tboxColor.TabIndex = 56;
            this.tboxColor.Visible = false;
            // 
            // lblLoteT
            // 
            this.lblLoteT.AutoSize = true;
            this.lblLoteT.BackColor = System.Drawing.Color.Transparent;
            this.lblLoteT.Enabled = false;
            this.lblLoteT.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoteT.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblLoteT.Location = new System.Drawing.Point(620, 135);
            this.lblLoteT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoteT.Name = "lblLoteT";
            this.lblLoteT.Size = new System.Drawing.Size(114, 23);
            this.lblLoteT.TabIndex = 59;
            this.lblLoteT.Text = "Lote Teñido";
            this.lblLoteT.Visible = false;
            // 
            // tboxLoteT
            // 
            this.tboxLoteT.Enabled = false;
            this.tboxLoteT.Location = new System.Drawing.Point(448, 135);
            this.tboxLoteT.MaxLength = 30;
            this.tboxLoteT.Name = "tboxLoteT";
            this.tboxLoteT.Size = new System.Drawing.Size(165, 22);
            this.tboxLoteT.TabIndex = 58;
            this.tboxLoteT.Visible = false;
            // 
            // tboxNotas
            // 
            this.tboxNotas.Enabled = false;
            this.tboxNotas.Location = new System.Drawing.Point(388, 452);
            this.tboxNotas.Multiline = true;
            this.tboxNotas.Name = "tboxNotas";
            this.tboxNotas.Size = new System.Drawing.Size(193, 180);
            this.tboxNotas.TabIndex = 60;
            this.tboxNotas.Visible = false;
            // 
            // cboxNotas
            // 
            this.cboxNotas.AutoSize = true;
            this.cboxNotas.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxNotas.ForeColor = System.Drawing.Color.White;
            this.cboxNotas.Location = new System.Drawing.Point(388, 417);
            this.cboxNotas.Name = "cboxNotas";
            this.cboxNotas.Size = new System.Drawing.Size(169, 27);
            this.cboxNotas.TabIndex = 61;
            this.cboxNotas.Text = "Habilitar Notas";
            this.cboxNotas.UseVisualStyleBackColor = true;
            this.cboxNotas.CheckedChanged += new System.EventHandler(this.cboxNotas_CheckedChanged);
            // 
            // frmSalidaH2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1143, 726);
            this.Controls.Add(this.cboxNotas);
            this.Controls.Add(this.tboxNotas);
            this.Controls.Add(this.lblLoteT);
            this.Controls.Add(this.tboxLoteT);
            this.Controls.Add(this.lblCodColor);
            this.Controls.Add(this.tboxColor);
            this.Controls.Add(this.lblNumPedido);
            this.Controls.Add(this.tboxNumPedido);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbTurno);
            this.Controls.Add(this.tboxBascula);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblTara);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblBascula);
            this.Controls.Add(this.cmbColorCono);
            this.Controls.Add(this.cmbMalla);
            this.Controls.Add(this.cmbIdBolsa);
            this.Controls.Add(this.cmbComport);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tboxNumLote);
            this.Controls.Add(this.tboxNumConos);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblDescHilo);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.lblDescCaja);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblNumLote);
            this.Controls.Add(this.btnCatalogoHilos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCatalogoCajas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBolsa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblTara2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPesoCono);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblMultConos);
            this.Controls.Add(this.lblPesoN);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblPesoB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSalidaH2";
            this.Text = "frmEntradaH";
            this.Load += new System.EventHandler(this.frmEntradaH_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEntradaH_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbComport;
        private System.Windows.Forms.TextBox tboxNumConos;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnCatalogoHilos;
        private System.Windows.Forms.Button btnCatalogoCajas;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblBolsa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTara2;
        private System.Windows.Forms.Label lblTara;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPesoN;
        private System.Windows.Forms.Label lblPesoB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblMultConos;
        private System.Windows.Forms.Label lblPesoCono;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescCaja;
        private System.Windows.Forms.Label lblDescHilo;
        private System.Windows.Forms.Label label13;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timerBascula;
        private System.Windows.Forms.Label lblBascula;
        private System.Windows.Forms.Timer timerCatalogoH;
        private System.Windows.Forms.Timer timerCatalogoC;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox tboxNumLote;
        private System.Windows.Forms.Label lblNumLote;
        private System.Windows.Forms.ComboBox cmbIdBolsa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbMalla;
        private System.Windows.Forms.ComboBox cmbColorCono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox tboxBascula;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox tboxNumPedido;
        private System.Windows.Forms.Label lblNumPedido;
        private System.Windows.Forms.Label lblCodColor;
        private System.Windows.Forms.TextBox tboxColor;
        private System.Windows.Forms.Label lblLoteT;
        private System.Windows.Forms.TextBox tboxLoteT;
        private System.Windows.Forms.TextBox tboxNotas;
        private System.Windows.Forms.CheckBox cboxNotas;
    }
}