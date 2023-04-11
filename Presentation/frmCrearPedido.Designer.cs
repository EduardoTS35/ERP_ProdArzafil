
namespace Presentation
{
    partial class frmCrearPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearPedido));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IDPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEntraga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdHilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tboxNumPedido = new System.Windows.Forms.TextBox();
            this.tboxFechaC = new System.Windows.Forms.TextBox();
            this.tboxIdHilo = new System.Windows.Forms.TextBox();
            this.tboxIdColor = new System.Windows.Forms.TextBox();
            this.tboxIdCaja = new System.Windows.Forms.TextBox();
            this.tboxIdCliente = new System.Windows.Forms.TextBox();
            this.tboxIdVendedor = new System.Windows.Forms.TextBox();
            this.tboxCantidadKg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCatalogoHilos = new System.Windows.Forms.Button();
            this.btnCatalogoColores = new System.Windows.Forms.Button();
            this.btnCatalogoCajas = new System.Windows.Forms.Button();
            this.btnCatalogoVendedores = new System.Windows.Forms.Button();
            this.btnCatalogoClientes = new System.Windows.Forms.Button();
            this.btnCrearPedido = new System.Windows.Forms.Button();
            this.btnBorrarDatos = new System.Windows.Forms.Button();
            this.timerVendedores = new System.Windows.Forms.Timer(this.components);
            this.timerClientes = new System.Windows.Forms.Timer(this.components);
            this.timerCajas = new System.Windows.Forms.Timer(this.components);
            this.timerHilos = new System.Windows.Forms.Timer(this.components);
            this.timerColores = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPedido,
            this.FCreacion,
            this.FEntraga,
            this.IdHilo,
            this.IdColor,
            this.IdCaja,
            this.CantPedido,
            this.IdVendedor,
            this.IdCliente});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(185)))), ((int)(((byte)(212)))));
            this.dataGridView1.Location = new System.Drawing.Point(10, 80);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(185)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(1116, 286);
            this.dataGridView1.TabIndex = 59;
            // 
            // IDPedido
            // 
            this.IDPedido.HeaderText = "Num. Pedido";
            this.IDPedido.MinimumWidth = 6;
            this.IDPedido.Name = "IDPedido";
            this.IDPedido.ReadOnly = true;
            // 
            // FCreacion
            // 
            this.FCreacion.HeaderText = "Fecha Creacion";
            this.FCreacion.MinimumWidth = 6;
            this.FCreacion.Name = "FCreacion";
            this.FCreacion.ReadOnly = true;
            // 
            // FEntraga
            // 
            this.FEntraga.HeaderText = "Fecha Entrega";
            this.FEntraga.MinimumWidth = 6;
            this.FEntraga.Name = "FEntraga";
            this.FEntraga.ReadOnly = true;
            // 
            // IdHilo
            // 
            this.IdHilo.HeaderText = "Cod. Hilo";
            this.IdHilo.MinimumWidth = 6;
            this.IdHilo.Name = "IdHilo";
            this.IdHilo.ReadOnly = true;
            // 
            // IdColor
            // 
            this.IdColor.HeaderText = "Cod. Color";
            this.IdColor.MinimumWidth = 6;
            this.IdColor.Name = "IdColor";
            this.IdColor.ReadOnly = true;
            // 
            // IdCaja
            // 
            this.IdCaja.HeaderText = "Cod. Caja";
            this.IdCaja.MinimumWidth = 6;
            this.IdCaja.Name = "IdCaja";
            this.IdCaja.ReadOnly = true;
            // 
            // CantPedido
            // 
            this.CantPedido.HeaderText = "Cantidad Pedido";
            this.CantPedido.MinimumWidth = 6;
            this.CantPedido.Name = "CantPedido";
            this.CantPedido.ReadOnly = true;
            // 
            // IdVendedor
            // 
            this.IdVendedor.HeaderText = "Vendedor";
            this.IdVendedor.MinimumWidth = 6;
            this.IdVendedor.Name = "IdVendedor";
            this.IdVendedor.ReadOnly = true;
            // 
            // IdCliente
            // 
            this.IdCliente.HeaderText = "Cliente";
            this.IdCliente.MinimumWidth = 6;
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            // 
            // tboxNumPedido
            // 
            this.tboxNumPedido.BackColor = System.Drawing.Color.White;
            this.tboxNumPedido.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNumPedido.ForeColor = System.Drawing.Color.Black;
            this.tboxNumPedido.Location = new System.Drawing.Point(56, 426);
            this.tboxNumPedido.Margin = new System.Windows.Forms.Padding(4);
            this.tboxNumPedido.Name = "tboxNumPedido";
            this.tboxNumPedido.Size = new System.Drawing.Size(171, 30);
            this.tboxNumPedido.TabIndex = 1;
            this.tboxNumPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxNumPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxNumPedido_KeyPress);
            // 
            // tboxFechaC
            // 
            this.tboxFechaC.BackColor = System.Drawing.Color.White;
            this.tboxFechaC.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxFechaC.ForeColor = System.Drawing.Color.Black;
            this.tboxFechaC.Location = new System.Drawing.Point(56, 509);
            this.tboxFechaC.Margin = new System.Windows.Forms.Padding(4);
            this.tboxFechaC.Name = "tboxFechaC";
            this.tboxFechaC.ReadOnly = true;
            this.tboxFechaC.Size = new System.Drawing.Size(171, 30);
            this.tboxFechaC.TabIndex = 2;
            this.tboxFechaC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tboxIdHilo
            // 
            this.tboxIdHilo.BackColor = System.Drawing.Color.White;
            this.tboxIdHilo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxIdHilo.ForeColor = System.Drawing.Color.Black;
            this.tboxIdHilo.Location = new System.Drawing.Point(884, 509);
            this.tboxIdHilo.Margin = new System.Windows.Forms.Padding(4);
            this.tboxIdHilo.Name = "tboxIdHilo";
            this.tboxIdHilo.Size = new System.Drawing.Size(171, 30);
            this.tboxIdHilo.TabIndex = 8;
            this.tboxIdHilo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tboxIdColor
            // 
            this.tboxIdColor.BackColor = System.Drawing.Color.White;
            this.tboxIdColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxIdColor.ForeColor = System.Drawing.Color.Black;
            this.tboxIdColor.Location = new System.Drawing.Point(884, 592);
            this.tboxIdColor.Margin = new System.Windows.Forms.Padding(4);
            this.tboxIdColor.Name = "tboxIdColor";
            this.tboxIdColor.Size = new System.Drawing.Size(171, 30);
            this.tboxIdColor.TabIndex = 9;
            this.tboxIdColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tboxIdCaja
            // 
            this.tboxIdCaja.BackColor = System.Drawing.Color.White;
            this.tboxIdCaja.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxIdCaja.ForeColor = System.Drawing.Color.Black;
            this.tboxIdCaja.Location = new System.Drawing.Point(470, 592);
            this.tboxIdCaja.Margin = new System.Windows.Forms.Padding(4);
            this.tboxIdCaja.Name = "tboxIdCaja";
            this.tboxIdCaja.Size = new System.Drawing.Size(171, 30);
            this.tboxIdCaja.TabIndex = 6;
            this.tboxIdCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxIdCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxIdCaja_KeyPress);
            // 
            // tboxIdCliente
            // 
            this.tboxIdCliente.BackColor = System.Drawing.Color.White;
            this.tboxIdCliente.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxIdCliente.ForeColor = System.Drawing.Color.Black;
            this.tboxIdCliente.Location = new System.Drawing.Point(470, 509);
            this.tboxIdCliente.Margin = new System.Windows.Forms.Padding(4);
            this.tboxIdCliente.Name = "tboxIdCliente";
            this.tboxIdCliente.Size = new System.Drawing.Size(171, 30);
            this.tboxIdCliente.TabIndex = 5;
            this.tboxIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxIdCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxIdCliente_KeyPress);
            // 
            // tboxIdVendedor
            // 
            this.tboxIdVendedor.BackColor = System.Drawing.Color.White;
            this.tboxIdVendedor.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxIdVendedor.ForeColor = System.Drawing.Color.Black;
            this.tboxIdVendedor.Location = new System.Drawing.Point(470, 426);
            this.tboxIdVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.tboxIdVendedor.Name = "tboxIdVendedor";
            this.tboxIdVendedor.Size = new System.Drawing.Size(171, 30);
            this.tboxIdVendedor.TabIndex = 4;
            this.tboxIdVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxIdVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxIdVendedor_KeyPress);
            // 
            // tboxCantidadKg
            // 
            this.tboxCantidadKg.BackColor = System.Drawing.Color.White;
            this.tboxCantidadKg.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxCantidadKg.ForeColor = System.Drawing.Color.Black;
            this.tboxCantidadKg.Location = new System.Drawing.Point(884, 426);
            this.tboxCantidadKg.Margin = new System.Windows.Forms.Padding(4);
            this.tboxCantidadKg.Name = "tboxCantidadKg";
            this.tboxCantidadKg.Size = new System.Drawing.Size(171, 30);
            this.tboxCantidadKg.TabIndex = 7;
            this.tboxCantidadKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxCantidadKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxCantidadKg_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(67, 402);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Número de Pedido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(70, 490);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "Fecha de Creación";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(73, 568);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 64;
            this.label4.Text = "Fecha de Entrega";
            // 
            // dtFechaEntrega
            // 
            this.dtFechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEntrega.Location = new System.Drawing.Point(56, 592);
            this.dtFechaEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.dtFechaEntrega.Name = "dtFechaEntrega";
            this.dtFechaEntrega.Size = new System.Drawing.Size(169, 21);
            this.dtFechaEntrega.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(909, 485);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 64;
            this.label5.Text = "Código de Hilo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(904, 568);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 20);
            this.label6.TabIndex = 64;
            this.label6.Text = "Código de Color";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(495, 568);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 64;
            this.label7.Text = "Código de Caja";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(920, 402);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 64;
            this.label8.Text = "Cantidad KG";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(482, 402);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 20);
            this.label9.TabIndex = 64;
            this.label9.Text = "Nombre Vendedor";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(525, 485);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 64;
            this.label10.Text = "Cliente";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(901, 660);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(225, 52);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar  a Pedido";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCatalogoHilos
            // 
            this.btnCatalogoHilos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnCatalogoHilos.FlatAppearance.BorderSize = 0;
            this.btnCatalogoHilos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogoHilos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogoHilos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnCatalogoHilos.Image = ((System.Drawing.Image)(resources.GetObject("btnCatalogoHilos.Image")));
            this.btnCatalogoHilos.Location = new System.Drawing.Point(541, 661);
            this.btnCatalogoHilos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCatalogoHilos.Name = "btnCatalogoHilos";
            this.btnCatalogoHilos.Size = new System.Drawing.Size(153, 52);
            this.btnCatalogoHilos.TabIndex = 12;
            this.btnCatalogoHilos.Text = "Catálogo Hilos";
            this.btnCatalogoHilos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCatalogoHilos.UseVisualStyleBackColor = false;
            this.btnCatalogoHilos.Click += new System.EventHandler(this.btnCatalogoHilos_Click);
            // 
            // btnCatalogoColores
            // 
            this.btnCatalogoColores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnCatalogoColores.FlatAppearance.BorderSize = 0;
            this.btnCatalogoColores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogoColores.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogoColores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnCatalogoColores.Image = ((System.Drawing.Image)(resources.GetObject("btnCatalogoColores.Image")));
            this.btnCatalogoColores.Location = new System.Drawing.Point(716, 660);
            this.btnCatalogoColores.Margin = new System.Windows.Forms.Padding(4);
            this.btnCatalogoColores.Name = "btnCatalogoColores";
            this.btnCatalogoColores.Size = new System.Drawing.Size(153, 52);
            this.btnCatalogoColores.TabIndex = 13;
            this.btnCatalogoColores.Text = "Catálogo Colores";
            this.btnCatalogoColores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCatalogoColores.UseVisualStyleBackColor = false;
            this.btnCatalogoColores.Click += new System.EventHandler(this.btnCatalogoColores_Click);
            // 
            // btnCatalogoCajas
            // 
            this.btnCatalogoCajas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnCatalogoCajas.FlatAppearance.BorderSize = 0;
            this.btnCatalogoCajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogoCajas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogoCajas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnCatalogoCajas.Image = ((System.Drawing.Image)(resources.GetObject("btnCatalogoCajas.Image")));
            this.btnCatalogoCajas.Location = new System.Drawing.Point(366, 660);
            this.btnCatalogoCajas.Margin = new System.Windows.Forms.Padding(4);
            this.btnCatalogoCajas.Name = "btnCatalogoCajas";
            this.btnCatalogoCajas.Size = new System.Drawing.Size(153, 52);
            this.btnCatalogoCajas.TabIndex = 14;
            this.btnCatalogoCajas.Text = "Catálogo Cajas";
            this.btnCatalogoCajas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCatalogoCajas.UseVisualStyleBackColor = false;
            this.btnCatalogoCajas.Click += new System.EventHandler(this.btnCatalogoCajas_Click);
            // 
            // btnCatalogoVendedores
            // 
            this.btnCatalogoVendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnCatalogoVendedores.FlatAppearance.BorderSize = 0;
            this.btnCatalogoVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogoVendedores.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogoVendedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnCatalogoVendedores.Image = ((System.Drawing.Image)(resources.GetObject("btnCatalogoVendedores.Image")));
            this.btnCatalogoVendedores.Location = new System.Drawing.Point(16, 660);
            this.btnCatalogoVendedores.Margin = new System.Windows.Forms.Padding(4);
            this.btnCatalogoVendedores.Name = "btnCatalogoVendedores";
            this.btnCatalogoVendedores.Size = new System.Drawing.Size(153, 52);
            this.btnCatalogoVendedores.TabIndex = 15;
            this.btnCatalogoVendedores.Text = "Listado Venedores";
            this.btnCatalogoVendedores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCatalogoVendedores.UseVisualStyleBackColor = false;
            this.btnCatalogoVendedores.Click += new System.EventHandler(this.btnCatalogoVendedores_Click);
            // 
            // btnCatalogoClientes
            // 
            this.btnCatalogoClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnCatalogoClientes.FlatAppearance.BorderSize = 0;
            this.btnCatalogoClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogoClientes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogoClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnCatalogoClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnCatalogoClientes.Image")));
            this.btnCatalogoClientes.Location = new System.Drawing.Point(191, 660);
            this.btnCatalogoClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnCatalogoClientes.Name = "btnCatalogoClientes";
            this.btnCatalogoClientes.Size = new System.Drawing.Size(153, 52);
            this.btnCatalogoClientes.TabIndex = 16;
            this.btnCatalogoClientes.Text = "Listado Clientes";
            this.btnCatalogoClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCatalogoClientes.UseVisualStyleBackColor = false;
            this.btnCatalogoClientes.Click += new System.EventHandler(this.btnCatalogoClientes_Click);
            // 
            // btnCrearPedido
            // 
            this.btnCrearPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnCrearPedido.FlatAppearance.BorderSize = 0;
            this.btnCrearPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearPedido.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnCrearPedido.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearPedido.Image")));
            this.btnCrearPedido.Location = new System.Drawing.Point(901, 11);
            this.btnCrearPedido.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrearPedido.Name = "btnCrearPedido";
            this.btnCrearPedido.Size = new System.Drawing.Size(225, 52);
            this.btnCrearPedido.TabIndex = 11;
            this.btnCrearPedido.Text = "Crear Pedido";
            this.btnCrearPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCrearPedido.UseVisualStyleBackColor = false;
            this.btnCrearPedido.Click += new System.EventHandler(this.btnCrearPedido_Click);
            // 
            // btnBorrarDatos
            // 
            this.btnBorrarDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnBorrarDatos.FlatAppearance.BorderSize = 0;
            this.btnBorrarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarDatos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.btnBorrarDatos.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrarDatos.Image")));
            this.btnBorrarDatos.Location = new System.Drawing.Point(668, 11);
            this.btnBorrarDatos.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrarDatos.Name = "btnBorrarDatos";
            this.btnBorrarDatos.Size = new System.Drawing.Size(225, 52);
            this.btnBorrarDatos.TabIndex = 17;
            this.btnBorrarDatos.Text = "Borrar Datos";
            this.btnBorrarDatos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBorrarDatos.UseVisualStyleBackColor = false;
            this.btnBorrarDatos.Click += new System.EventHandler(this.btnBorrarDatos_Click);
            // 
            // timerVendedores
            // 
            this.timerVendedores.Tick += new System.EventHandler(this.timerVendedores_Tick);
            // 
            // timerClientes
            // 
            this.timerClientes.Tick += new System.EventHandler(this.timerClientes_Tick);
            // 
            // timerCajas
            // 
            this.timerCajas.Tick += new System.EventHandler(this.timerCajas_Tick);
            // 
            // timerHilos
            // 
            this.timerHilos.Tick += new System.EventHandler(this.timerHilos_Tick);
            // 
            // timerColores
            // 
            this.timerColores.Tick += new System.EventHandler(this.timerColores_Tick);
            // 
            // frmCrearPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1143, 726);
            this.Controls.Add(this.btnBorrarDatos);
            this.Controls.Add(this.btnCrearPedido);
            this.Controls.Add(this.btnCatalogoClientes);
            this.Controls.Add(this.btnCatalogoVendedores);
            this.Controls.Add(this.btnCatalogoCajas);
            this.Controls.Add(this.btnCatalogoColores);
            this.Controls.Add(this.btnCatalogoHilos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dtFechaEntrega);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxIdCliente);
            this.Controls.Add(this.tboxIdVendedor);
            this.Controls.Add(this.tboxCantidadKg);
            this.Controls.Add(this.tboxIdCaja);
            this.Controls.Add(this.tboxIdColor);
            this.Controls.Add(this.tboxIdHilo);
            this.Controls.Add(this.tboxFechaC);
            this.Controls.Add(this.tboxNumPedido);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCrearPedido";
            this.Text = "frmCrearPedido";
            this.Load += new System.EventHandler(this.frmCrearPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tboxNumPedido;
        private System.Windows.Forms.TextBox tboxFechaC;
        private System.Windows.Forms.TextBox tboxIdHilo;
        private System.Windows.Forms.TextBox tboxIdColor;
        private System.Windows.Forms.TextBox tboxIdCaja;
        private System.Windows.Forms.TextBox tboxIdCliente;
        private System.Windows.Forms.TextBox tboxIdVendedor;
        private System.Windows.Forms.TextBox tboxCantidadKg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFechaEntrega;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCatalogoHilos;
        private System.Windows.Forms.Button btnCatalogoColores;
        private System.Windows.Forms.Button btnCatalogoCajas;
        private System.Windows.Forms.Button btnCatalogoVendedores;
        private System.Windows.Forms.Button btnCatalogoClientes;
        private System.Windows.Forms.Button btnCrearPedido;
        private System.Windows.Forms.Button btnBorrarDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEntraga;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdHilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.Timer timerVendedores;
        private System.Windows.Forms.Timer timerClientes;
        private System.Windows.Forms.Timer timerCajas;
        private System.Windows.Forms.Timer timerHilos;
        private System.Windows.Forms.Timer timerColores;
    }
}