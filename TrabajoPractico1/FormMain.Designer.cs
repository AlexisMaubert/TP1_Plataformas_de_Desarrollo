namespace TrabajoPractico1
{
    partial class FormMain
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
            this.tabCajaDeAhorro = new System.Windows.Forms.TabPage();
            this.detalleTxt = new System.Windows.Forms.TextBox();
            this.montoText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnEliminarTitular = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.btnRetirar = new System.Windows.Forms.Button();
            this.btnDepositar = new System.Windows.Forms.Button();
            this.btnAgregarTitular = new System.Windows.Forms.Button();
            this.btnBajaCaja = new System.Windows.Forms.Button();
            this.btnNewCaja = new System.Windows.Forms.Button();
            this.dataGridViewCaja = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCbu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitulares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPlazoFijo = new System.Windows.Forms.TabPage();
            this.comboBoxPFCBU = new System.Windows.Forms.ComboBox();
            this.btnEliminarPF = new System.Windows.Forms.Button();
            this.btnNewPf = new System.Windows.Forms.Button();
            this.dataGridViewPF = new System.Windows.Forms.DataGridView();
            this.ColumnIdPlf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitularPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMontoPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFechaInicioPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFechaFinPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTasaPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPagadoPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagos = new System.Windows.Forms.TabPage();
            this.comboBoxTarjetaPago = new System.Windows.Forms.ComboBox();
            this.comboBoxCajaPago = new System.Windows.Forms.ComboBox();
            this.btnPagarPago = new System.Windows.Forms.Button();
            this.btnEliminarPago = new System.Windows.Forms.Button();
            this.btnNewPago = new System.Windows.Forms.Button();
            this.dataGridViewPagos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPagosRealizados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPagosPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTarjetas = new System.Windows.Forms.TabPage();
            this.comboBoxTraerCajasATarjetas = new System.Windows.Forms.ComboBox();
            this.btnPagarTarjeta = new System.Windows.Forms.Button();
            this.btnDarDeBajaTarjeta = new System.Windows.Forms.Button();
            this.btnNewTarjeta = new System.Windows.Forms.Button();
            this.dataGridViewTarjetas = new System.Windows.Forms.DataGridView();
            this.ColumnIdTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitularTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumeroTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCodigoTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLimiteTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConsumosTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabUsuario = new System.Windows.Forms.TabPage();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBloqueado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nombreUsuario = new System.Windows.Forms.Label();
            this.tabCajaDeAhorro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaja)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPlazoFijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPF)).BeginInit();
            this.tabPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPagos)).BeginInit();
            this.tabTarjetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarjetas)).BeginInit();
            this.tabUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCajaDeAhorro
            // 
            this.tabCajaDeAhorro.Controls.Add(this.detalleTxt);
            this.tabCajaDeAhorro.Controls.Add(this.montoText);
            this.tabCajaDeAhorro.Controls.Add(this.label2);
            this.tabCajaDeAhorro.Controls.Add(this.dateTimePicker1);
            this.tabCajaDeAhorro.Controls.Add(this.btnEliminarTitular);
            this.tabCajaDeAhorro.Controls.Add(this.btnDetalles);
            this.tabCajaDeAhorro.Controls.Add(this.btnTransferir);
            this.tabCajaDeAhorro.Controls.Add(this.btnRetirar);
            this.tabCajaDeAhorro.Controls.Add(this.btnDepositar);
            this.tabCajaDeAhorro.Controls.Add(this.btnAgregarTitular);
            this.tabCajaDeAhorro.Controls.Add(this.btnBajaCaja);
            this.tabCajaDeAhorro.Controls.Add(this.btnNewCaja);
            this.tabCajaDeAhorro.Controls.Add(this.dataGridViewCaja);
            this.tabCajaDeAhorro.Location = new System.Drawing.Point(4, 24);
            this.tabCajaDeAhorro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCajaDeAhorro.Name = "tabCajaDeAhorro";
            this.tabCajaDeAhorro.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCajaDeAhorro.Size = new System.Drawing.Size(752, 396);
            this.tabCajaDeAhorro.TabIndex = 0;
            this.tabCajaDeAhorro.Text = "CajasDeAhorro";
            this.tabCajaDeAhorro.UseVisualStyleBackColor = true;
            // 
            // detalleTxt
            // 
            this.detalleTxt.Location = new System.Drawing.Point(547, 267);
            this.detalleTxt.Name = "detalleTxt";
            this.detalleTxt.Size = new System.Drawing.Size(106, 23);
            this.detalleTxt.TabIndex = 14;
            this.detalleTxt.Text = "Detalle";
            this.detalleTxt.Visible = false;
            this.detalleTxt.TextChanged += new System.EventHandler(this.detalleTxt_TextChanged);
            // 
            // montoText
            // 
            this.montoText.Location = new System.Drawing.Point(547, 238);
            this.montoText.Name = "montoText";
            this.montoText.Size = new System.Drawing.Size(106, 23);
            this.montoText.TabIndex = 13;
            this.montoText.Text = "Monto";
            this.montoText.Visible = false;
            this.montoText.TextChanged += new System.EventHandler(this.montoText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Filtrar movimientos por:";
            this.label2.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(547, 210);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(106, 23);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.Value = new System.DateTime(2022, 11, 6, 0, 0, 0, 0);
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnEliminarTitular
            // 
            this.btnEliminarTitular.Location = new System.Drawing.Point(539, 69);
            this.btnEliminarTitular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarTitular.Name = "btnEliminarTitular";
            this.btnEliminarTitular.Size = new System.Drawing.Size(114, 22);
            this.btnEliminarTitular.TabIndex = 9;
            this.btnEliminarTitular.Text = "Eliminar Titular";
            this.btnEliminarTitular.UseVisualStyleBackColor = true;
            this.btnEliminarTitular.Visible = false;
            this.btnEliminarTitular.Click += new System.EventHandler(this.btnEliminarTitular_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.Location = new System.Drawing.Point(522, 303);
            this.btnDetalles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(131, 29);
            this.btnDetalles.TabIndex = 7;
            this.btnDetalles.Text = "Mostrar movimientos";
            this.btnDetalles.UseVisualStyleBackColor = true;
            this.btnDetalles.Visible = false;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // btnTransferir
            // 
            this.btnTransferir.Location = new System.Drawing.Point(555, 155);
            this.btnTransferir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(98, 22);
            this.btnTransferir.TabIndex = 6;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
            this.btnTransferir.Visible = false;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // btnRetirar
            // 
            this.btnRetirar.Location = new System.Drawing.Point(555, 129);
            this.btnRetirar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRetirar.Name = "btnRetirar";
            this.btnRetirar.Size = new System.Drawing.Size(98, 22);
            this.btnRetirar.TabIndex = 5;
            this.btnRetirar.Text = "Retirar";
            this.btnRetirar.UseVisualStyleBackColor = true;
            this.btnRetirar.Visible = false;
            this.btnRetirar.Click += new System.EventHandler(this.btnRetirar_Click);
            // 
            // btnDepositar
            // 
            this.btnDepositar.Location = new System.Drawing.Point(555, 103);
            this.btnDepositar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(98, 22);
            this.btnDepositar.TabIndex = 4;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Visible = false;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // btnAgregarTitular
            // 
            this.btnAgregarTitular.Location = new System.Drawing.Point(539, 43);
            this.btnAgregarTitular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarTitular.Name = "btnAgregarTitular";
            this.btnAgregarTitular.Size = new System.Drawing.Size(114, 22);
            this.btnAgregarTitular.TabIndex = 3;
            this.btnAgregarTitular.Text = "Agregar Titular";
            this.btnAgregarTitular.UseVisualStyleBackColor = true;
            this.btnAgregarTitular.Visible = false;
            this.btnAgregarTitular.Click += new System.EventHandler(this.btnAgregarTitular_Click);
            // 
            // btnBajaCaja
            // 
            this.btnBajaCaja.Location = new System.Drawing.Point(539, 16);
            this.btnBajaCaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBajaCaja.Name = "btnBajaCaja";
            this.btnBajaCaja.Size = new System.Drawing.Size(114, 22);
            this.btnBajaCaja.TabIndex = 2;
            this.btnBajaCaja.Text = "Borrar Caja";
            this.btnBajaCaja.UseVisualStyleBackColor = true;
            this.btnBajaCaja.Visible = false;
            this.btnBajaCaja.Click += new System.EventHandler(this.btnBajaCaja_Click);
            // 
            // btnNewCaja
            // 
            this.btnNewCaja.Location = new System.Drawing.Point(15, 361);
            this.btnNewCaja.Name = "btnNewCaja";
            this.btnNewCaja.Size = new System.Drawing.Size(150, 23);
            this.btnNewCaja.TabIndex = 1;
            this.btnNewCaja.Text = "Nueva Caja de Ahorro";
            this.btnNewCaja.UseVisualStyleBackColor = true;
            this.btnNewCaja.Click += new System.EventHandler(this.btnNewCaja_Click);
            // 
            // dataGridViewCaja
            // 
            this.dataGridViewCaja.AllowUserToAddRows = false;
            this.dataGridViewCaja.AllowUserToDeleteRows = false;
            this.dataGridViewCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnCbu,
            this.ColumnTitulares,
            this.ColumnSaldo});
            this.dataGridViewCaja.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewCaja.Name = "dataGridViewCaja";
            this.dataGridViewCaja.RowHeadersWidth = 51;
            this.dataGridViewCaja.RowTemplate.Height = 29;
            this.dataGridViewCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewCaja.Size = new System.Drawing.Size(435, 345);
            this.dataGridViewCaja.TabIndex = 0;
            this.dataGridViewCaja.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCaja_CellContentClick);
            this.dataGridViewCaja.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCaja_CellContentClick);
            // 
            // ColumnId
            // 
            this.ColumnId.Frozen = true;
            this.ColumnId.HeaderText = "ID";
            this.ColumnId.MinimumWidth = 6;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            this.ColumnId.Width = 125;
            // 
            // ColumnCbu
            // 
            this.ColumnCbu.Frozen = true;
            this.ColumnCbu.HeaderText = "CBU";
            this.ColumnCbu.MinimumWidth = 6;
            this.ColumnCbu.Name = "ColumnCbu";
            this.ColumnCbu.ReadOnly = true;
            this.ColumnCbu.Width = 125;
            // 
            // ColumnTitulares
            // 
            this.ColumnTitulares.Frozen = true;
            this.ColumnTitulares.HeaderText = "Titular/res";
            this.ColumnTitulares.MinimumWidth = 6;
            this.ColumnTitulares.Name = "ColumnTitulares";
            this.ColumnTitulares.ReadOnly = true;
            this.ColumnTitulares.Width = 125;
            // 
            // ColumnSaldo
            // 
            this.ColumnSaldo.Frozen = true;
            this.ColumnSaldo.HeaderText = "Saldo";
            this.ColumnSaldo.MinimumWidth = 6;
            this.ColumnSaldo.Name = "ColumnSaldo";
            this.ColumnSaldo.ReadOnly = true;
            this.ColumnSaldo.Width = 125;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCajaDeAhorro);
            this.tabControl1.Controls.Add(this.tabPlazoFijo);
            this.tabControl1.Controls.Add(this.tabPagos);
            this.tabControl1.Controls.Add(this.tabTarjetas);
            this.tabControl1.Controls.Add(this.tabUsuario);
            this.tabControl1.Location = new System.Drawing.Point(12, 61);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 424);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPlazoFijo
            // 
            this.tabPlazoFijo.Controls.Add(this.comboBoxPFCBU);
            this.tabPlazoFijo.Controls.Add(this.btnEliminarPF);
            this.tabPlazoFijo.Controls.Add(this.btnNewPf);
            this.tabPlazoFijo.Controls.Add(this.dataGridViewPF);
            this.tabPlazoFijo.Location = new System.Drawing.Point(4, 24);
            this.tabPlazoFijo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPlazoFijo.Name = "tabPlazoFijo";
            this.tabPlazoFijo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPlazoFijo.Size = new System.Drawing.Size(752, 396);
            this.tabPlazoFijo.TabIndex = 1;
            this.tabPlazoFijo.Text = "PlazoFijo";
            this.tabPlazoFijo.UseVisualStyleBackColor = true;
            // 
            // comboBoxPFCBU
            // 
            this.comboBoxPFCBU.FormattingEnabled = true;
            this.comboBoxPFCBU.Location = new System.Drawing.Point(145, 358);
            this.comboBoxPFCBU.Name = "comboBoxPFCBU";
            this.comboBoxPFCBU.Size = new System.Drawing.Size(121, 23);
            this.comboBoxPFCBU.TabIndex = 3;
            this.comboBoxPFCBU.Text = "Lista de CBUs";
            this.comboBoxPFCBU.Visible = false;
            this.comboBoxPFCBU.SelectedIndexChanged += new System.EventHandler(this.comboBoxPFCBU_SelectedIndexChanged);
            // 
            // btnEliminarPF
            // 
            this.btnEliminarPF.Location = new System.Drawing.Point(666, 79);
            this.btnEliminarPF.Name = "btnEliminarPF";
            this.btnEliminarPF.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarPF.TabIndex = 2;
            this.btnEliminarPF.Text = "Eliminar";
            this.btnEliminarPF.UseVisualStyleBackColor = true;
            this.btnEliminarPF.Click += new System.EventHandler(this.btnEliminarPF_Click);
            // 
            // btnNewPf
            // 
            this.btnNewPf.Location = new System.Drawing.Point(16, 358);
            this.btnNewPf.Name = "btnNewPf";
            this.btnNewPf.Size = new System.Drawing.Size(107, 23);
            this.btnNewPf.TabIndex = 1;
            this.btnNewPf.Text = "Nuevo Plazo Fijo";
            this.btnNewPf.UseVisualStyleBackColor = true;
            this.btnNewPf.Click += new System.EventHandler(this.btnNewPf_Click);
            // 
            // dataGridViewPF
            // 
            this.dataGridViewPF.AllowUserToAddRows = false;
            this.dataGridViewPF.AllowUserToDeleteRows = false;
            this.dataGridViewPF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdPlf,
            this.ColumnTitularPlz,
            this.ColumnMontoPlz,
            this.ColumnFechaInicioPlz,
            this.ColumnFechaFinPlz,
            this.ColumnTasaPlz,
            this.ColumnPagadoPlz});
            this.dataGridViewPF.Location = new System.Drawing.Point(-4, 0);
            this.dataGridViewPF.Name = "dataGridViewPF";
            this.dataGridViewPF.RowHeadersWidth = 51;
            this.dataGridViewPF.RowTemplate.Height = 25;
            this.dataGridViewPF.Size = new System.Drawing.Size(664, 343);
            this.dataGridViewPF.TabIndex = 0;
            this.dataGridViewPF.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPF_CellContentClick);
            this.dataGridViewPF.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPF_CellContentClick);
            // 
            // ColumnIdPlf
            // 
            this.ColumnIdPlf.Frozen = true;
            this.ColumnIdPlf.HeaderText = "IdPlf";
            this.ColumnIdPlf.MinimumWidth = 6;
            this.ColumnIdPlf.Name = "ColumnIdPlf";
            this.ColumnIdPlf.ReadOnly = true;
            this.ColumnIdPlf.Visible = false;
            this.ColumnIdPlf.Width = 125;
            // 
            // ColumnTitularPlz
            // 
            this.ColumnTitularPlz.Frozen = true;
            this.ColumnTitularPlz.HeaderText = "Titular";
            this.ColumnTitularPlz.MinimumWidth = 6;
            this.ColumnTitularPlz.Name = "ColumnTitularPlz";
            this.ColumnTitularPlz.ReadOnly = true;
            this.ColumnTitularPlz.Width = 125;
            // 
            // ColumnMontoPlz
            // 
            this.ColumnMontoPlz.Frozen = true;
            this.ColumnMontoPlz.HeaderText = "Monto";
            this.ColumnMontoPlz.MinimumWidth = 6;
            this.ColumnMontoPlz.Name = "ColumnMontoPlz";
            this.ColumnMontoPlz.ReadOnly = true;
            this.ColumnMontoPlz.Width = 125;
            // 
            // ColumnFechaInicioPlz
            // 
            this.ColumnFechaInicioPlz.Frozen = true;
            this.ColumnFechaInicioPlz.HeaderText = "Fecha Inicio";
            this.ColumnFechaInicioPlz.MinimumWidth = 6;
            this.ColumnFechaInicioPlz.Name = "ColumnFechaInicioPlz";
            this.ColumnFechaInicioPlz.ReadOnly = true;
            this.ColumnFechaInicioPlz.Width = 125;
            // 
            // ColumnFechaFinPlz
            // 
            this.ColumnFechaFinPlz.Frozen = true;
            this.ColumnFechaFinPlz.HeaderText = "Fecha Fin";
            this.ColumnFechaFinPlz.MinimumWidth = 6;
            this.ColumnFechaFinPlz.Name = "ColumnFechaFinPlz";
            this.ColumnFechaFinPlz.ReadOnly = true;
            this.ColumnFechaFinPlz.Width = 125;
            // 
            // ColumnTasaPlz
            // 
            this.ColumnTasaPlz.Frozen = true;
            this.ColumnTasaPlz.HeaderText = "Tasa";
            this.ColumnTasaPlz.MinimumWidth = 6;
            this.ColumnTasaPlz.Name = "ColumnTasaPlz";
            this.ColumnTasaPlz.ReadOnly = true;
            this.ColumnTasaPlz.Width = 125;
            // 
            // ColumnPagadoPlz
            // 
            this.ColumnPagadoPlz.Frozen = true;
            this.ColumnPagadoPlz.HeaderText = "Pagado";
            this.ColumnPagadoPlz.MinimumWidth = 6;
            this.ColumnPagadoPlz.Name = "ColumnPagadoPlz";
            this.ColumnPagadoPlz.ReadOnly = true;
            this.ColumnPagadoPlz.Width = 125;
            // 
            // tabPagos
            // 
            this.tabPagos.Controls.Add(this.comboBoxTarjetaPago);
            this.tabPagos.Controls.Add(this.comboBoxCajaPago);
            this.tabPagos.Controls.Add(this.btnPagarPago);
            this.tabPagos.Controls.Add(this.btnEliminarPago);
            this.tabPagos.Controls.Add(this.btnNewPago);
            this.tabPagos.Controls.Add(this.dataGridViewPagos);
            this.tabPagos.Location = new System.Drawing.Point(4, 24);
            this.tabPagos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagos.Name = "tabPagos";
            this.tabPagos.Size = new System.Drawing.Size(752, 396);
            this.tabPagos.TabIndex = 2;
            this.tabPagos.Text = "Pagos";
            this.tabPagos.UseVisualStyleBackColor = true;
            // 
            // comboBoxTarjetaPago
            // 
            this.comboBoxTarjetaPago.FormattingEnabled = true;
            this.comboBoxTarjetaPago.Location = new System.Drawing.Point(574, 125);
            this.comboBoxTarjetaPago.Name = "comboBoxTarjetaPago";
            this.comboBoxTarjetaPago.Size = new System.Drawing.Size(120, 23);
            this.comboBoxTarjetaPago.TabIndex = 5;
            this.comboBoxTarjetaPago.Text = "Tarjetas";
            this.comboBoxTarjetaPago.Visible = false;
            this.comboBoxTarjetaPago.SelectedIndexChanged += new System.EventHandler(this.comboBoxTarjetaPago_SelectedIndexChanged);
            // 
            // comboBoxCajaPago
            // 
            this.comboBoxCajaPago.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxCajaPago.FormattingEnabled = true;
            this.comboBoxCajaPago.Location = new System.Drawing.Point(433, 125);
            this.comboBoxCajaPago.Name = "comboBoxCajaPago";
            this.comboBoxCajaPago.Size = new System.Drawing.Size(120, 21);
            this.comboBoxCajaPago.TabIndex = 4;
            this.comboBoxCajaPago.Text = "Cajas De Ahorro";
            this.comboBoxCajaPago.Visible = false;
            this.comboBoxCajaPago.SelectedIndexChanged += new System.EventHandler(this.comboBoxCajaPago_SelectedIndexChanged);
            // 
            // btnPagarPago
            // 
            this.btnPagarPago.Location = new System.Drawing.Point(433, 88);
            this.btnPagarPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPagarPago.Name = "btnPagarPago";
            this.btnPagarPago.Size = new System.Drawing.Size(82, 22);
            this.btnPagarPago.TabIndex = 3;
            this.btnPagarPago.Text = "Pagar";
            this.btnPagarPago.UseVisualStyleBackColor = true;
            this.btnPagarPago.Visible = false;
            this.btnPagarPago.Click += new System.EventHandler(this.btnPagarPago_Click);
            // 
            // btnEliminarPago
            // 
            this.btnEliminarPago.Location = new System.Drawing.Point(433, 62);
            this.btnEliminarPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarPago.Name = "btnEliminarPago";
            this.btnEliminarPago.Size = new System.Drawing.Size(82, 22);
            this.btnEliminarPago.TabIndex = 2;
            this.btnEliminarPago.Text = "Eliminar";
            this.btnEliminarPago.UseVisualStyleBackColor = true;
            this.btnEliminarPago.Visible = false;
            this.btnEliminarPago.Click += new System.EventHandler(this.btnEliminarPago_Click);
            // 
            // btnNewPago
            // 
            this.btnNewPago.Location = new System.Drawing.Point(24, 360);
            this.btnNewPago.Name = "btnNewPago";
            this.btnNewPago.Size = new System.Drawing.Size(100, 23);
            this.btnNewPago.TabIndex = 1;
            this.btnNewPago.Text = "Nuevo Pago";
            this.btnNewPago.UseVisualStyleBackColor = true;
            this.btnNewPago.Click += new System.EventHandler(this.btnNewPago_Click);
            // 
            // dataGridViewPagos
            // 
            this.dataGridViewPagos.AllowUserToAddRows = false;
            this.dataGridViewPagos.AllowUserToDeleteRows = false;
            this.dataGridViewPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.ColumnPagosRealizados,
            this.ColumnPagosPendientes});
            this.dataGridViewPagos.Location = new System.Drawing.Point(-4, 0);
            this.dataGridViewPagos.Name = "dataGridViewPagos";
            this.dataGridViewPagos.RowHeadersWidth = 51;
            this.dataGridViewPagos.RowTemplate.Height = 25;
            this.dataGridViewPagos.Size = new System.Drawing.Size(406, 345);
            this.dataGridViewPagos.TabIndex = 0;
            this.dataGridViewPagos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPagos_CellContentClick);
            this.dataGridViewPagos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPagos_CellContentClick);
            this.dataGridViewPagos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPagos_CellContentClick);
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // ColumnPagosRealizados
            // 
            this.ColumnPagosRealizados.Frozen = true;
            this.ColumnPagosRealizados.HeaderText = "Pagos Realizados";
            this.ColumnPagosRealizados.MinimumWidth = 6;
            this.ColumnPagosRealizados.Name = "ColumnPagosRealizados";
            this.ColumnPagosRealizados.ReadOnly = true;
            this.ColumnPagosRealizados.Width = 125;
            // 
            // ColumnPagosPendientes
            // 
            this.ColumnPagosPendientes.Frozen = true;
            this.ColumnPagosPendientes.HeaderText = "PagosPendientes";
            this.ColumnPagosPendientes.MinimumWidth = 6;
            this.ColumnPagosPendientes.Name = "ColumnPagosPendientes";
            this.ColumnPagosPendientes.ReadOnly = true;
            this.ColumnPagosPendientes.Width = 125;
            // 
            // tabTarjetas
            // 
            this.tabTarjetas.Controls.Add(this.comboBoxTraerCajasATarjetas);
            this.tabTarjetas.Controls.Add(this.btnPagarTarjeta);
            this.tabTarjetas.Controls.Add(this.btnDarDeBajaTarjeta);
            this.tabTarjetas.Controls.Add(this.btnNewTarjeta);
            this.tabTarjetas.Controls.Add(this.dataGridViewTarjetas);
            this.tabTarjetas.Location = new System.Drawing.Point(4, 24);
            this.tabTarjetas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTarjetas.Name = "tabTarjetas";
            this.tabTarjetas.Size = new System.Drawing.Size(752, 396);
            this.tabTarjetas.TabIndex = 3;
            this.tabTarjetas.Text = "Tarjetas";
            this.tabTarjetas.UseVisualStyleBackColor = true;
            // 
            // comboBoxTraerCajasATarjetas
            // 
            this.comboBoxTraerCajasATarjetas.FormattingEnabled = true;
            this.comboBoxTraerCajasATarjetas.Location = new System.Drawing.Point(608, 129);
            this.comboBoxTraerCajasATarjetas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTraerCajasATarjetas.Name = "comboBoxTraerCajasATarjetas";
            this.comboBoxTraerCajasATarjetas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxTraerCajasATarjetas.Size = new System.Drawing.Size(117, 23);
            this.comboBoxTraerCajasATarjetas.TabIndex = 4;
            this.comboBoxTraerCajasATarjetas.Text = "Cajas de ahorro";
            this.comboBoxTraerCajasATarjetas.Visible = false;
            this.comboBoxTraerCajasATarjetas.SelectedIndexChanged += new System.EventHandler(this.comboBoxTraerCajasATarjetas_SelectedIndexChanged);
            // 
            // btnPagarTarjeta
            // 
            this.btnPagarTarjeta.Location = new System.Drawing.Point(608, 96);
            this.btnPagarTarjeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPagarTarjeta.Name = "btnPagarTarjeta";
            this.btnPagarTarjeta.Size = new System.Drawing.Size(117, 22);
            this.btnPagarTarjeta.TabIndex = 3;
            this.btnPagarTarjeta.Text = "Pagar Consumos";
            this.btnPagarTarjeta.UseVisualStyleBackColor = true;
            this.btnPagarTarjeta.Visible = false;
            this.btnPagarTarjeta.Click += new System.EventHandler(this.btnPagarTarjeta_Click);
            // 
            // btnDarDeBajaTarjeta
            // 
            this.btnDarDeBajaTarjeta.Location = new System.Drawing.Point(608, 70);
            this.btnDarDeBajaTarjeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDarDeBajaTarjeta.Name = "btnDarDeBajaTarjeta";
            this.btnDarDeBajaTarjeta.Size = new System.Drawing.Size(117, 22);
            this.btnDarDeBajaTarjeta.TabIndex = 2;
            this.btnDarDeBajaTarjeta.Text = "Dar de baja";
            this.btnDarDeBajaTarjeta.UseVisualStyleBackColor = true;
            this.btnDarDeBajaTarjeta.Visible = false;
            this.btnDarDeBajaTarjeta.Click += new System.EventHandler(this.btnDarDeBajaTarjeta_Click);
            // 
            // btnNewTarjeta
            // 
            this.btnNewTarjeta.Location = new System.Drawing.Point(16, 358);
            this.btnNewTarjeta.Name = "btnNewTarjeta";
            this.btnNewTarjeta.Size = new System.Drawing.Size(102, 23);
            this.btnNewTarjeta.TabIndex = 1;
            this.btnNewTarjeta.Text = "Nueva Tarjeta";
            this.btnNewTarjeta.UseVisualStyleBackColor = true;
            this.btnNewTarjeta.Click += new System.EventHandler(this.btnNewTarjeta_Click);
            // 
            // dataGridViewTarjetas
            // 
            this.dataGridViewTarjetas.AllowUserToAddRows = false;
            this.dataGridViewTarjetas.AllowUserToDeleteRows = false;
            this.dataGridViewTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTarjetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdTarjeta,
            this.ColumnTitularTarjeta,
            this.ColumnNumeroTarjeta,
            this.ColumnCodigoTarjeta,
            this.ColumnLimiteTarjeta,
            this.ColumnConsumosTarjeta});
            this.dataGridViewTarjetas.Location = new System.Drawing.Point(-4, 0);
            this.dataGridViewTarjetas.Name = "dataGridViewTarjetas";
            this.dataGridViewTarjetas.RowHeadersWidth = 51;
            this.dataGridViewTarjetas.RowTemplate.Height = 25;
            this.dataGridViewTarjetas.Size = new System.Drawing.Size(606, 343);
            this.dataGridViewTarjetas.TabIndex = 0;
            this.dataGridViewTarjetas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTarjetas_CellContentClick);
            // 
            // ColumnIdTarjeta
            // 
            this.ColumnIdTarjeta.Frozen = true;
            this.ColumnIdTarjeta.HeaderText = "Id";
            this.ColumnIdTarjeta.MinimumWidth = 6;
            this.ColumnIdTarjeta.Name = "ColumnIdTarjeta";
            this.ColumnIdTarjeta.ReadOnly = true;
            this.ColumnIdTarjeta.Visible = false;
            this.ColumnIdTarjeta.Width = 125;
            // 
            // ColumnTitularTarjeta
            // 
            this.ColumnTitularTarjeta.Frozen = true;
            this.ColumnTitularTarjeta.HeaderText = "Titular";
            this.ColumnTitularTarjeta.MinimumWidth = 6;
            this.ColumnTitularTarjeta.Name = "ColumnTitularTarjeta";
            this.ColumnTitularTarjeta.ReadOnly = true;
            this.ColumnTitularTarjeta.Width = 125;
            // 
            // ColumnNumeroTarjeta
            // 
            this.ColumnNumeroTarjeta.Frozen = true;
            this.ColumnNumeroTarjeta.HeaderText = "Número Tarjeta";
            this.ColumnNumeroTarjeta.MinimumWidth = 6;
            this.ColumnNumeroTarjeta.Name = "ColumnNumeroTarjeta";
            this.ColumnNumeroTarjeta.ReadOnly = true;
            this.ColumnNumeroTarjeta.Width = 125;
            // 
            // ColumnCodigoTarjeta
            // 
            this.ColumnCodigoTarjeta.Frozen = true;
            this.ColumnCodigoTarjeta.HeaderText = "Código";
            this.ColumnCodigoTarjeta.MinimumWidth = 6;
            this.ColumnCodigoTarjeta.Name = "ColumnCodigoTarjeta";
            this.ColumnCodigoTarjeta.ReadOnly = true;
            this.ColumnCodigoTarjeta.Width = 70;
            // 
            // ColumnLimiteTarjeta
            // 
            this.ColumnLimiteTarjeta.Frozen = true;
            this.ColumnLimiteTarjeta.HeaderText = "Límite";
            this.ColumnLimiteTarjeta.MinimumWidth = 6;
            this.ColumnLimiteTarjeta.Name = "ColumnLimiteTarjeta";
            this.ColumnLimiteTarjeta.ReadOnly = true;
            this.ColumnLimiteTarjeta.Width = 125;
            // 
            // ColumnConsumosTarjeta
            // 
            this.ColumnConsumosTarjeta.Frozen = true;
            this.ColumnConsumosTarjeta.HeaderText = "Consumos";
            this.ColumnConsumosTarjeta.MinimumWidth = 6;
            this.ColumnConsumosTarjeta.Name = "ColumnConsumosTarjeta";
            this.ColumnConsumosTarjeta.ReadOnly = true;
            this.ColumnConsumosTarjeta.Width = 125;
            // 
            // tabUsuario
            // 
            this.tabUsuario.Controls.Add(this.btnDesbloquear);
            this.tabUsuario.Controls.Add(this.dataGridViewUsuarios);
            this.tabUsuario.Location = new System.Drawing.Point(4, 24);
            this.tabUsuario.Name = "tabUsuario";
            this.tabUsuario.Size = new System.Drawing.Size(752, 396);
            this.tabUsuario.TabIndex = 4;
            this.tabUsuario.Text = "Usuarios";
            this.tabUsuario.UseVisualStyleBackColor = true;
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.Location = new System.Drawing.Point(619, 76);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(87, 23);
            this.btnDesbloquear.TabIndex = 1;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colNombre,
            this.colDni,
            this.colEmail,
            this.colBloqueado,
            this.colAdmin});
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.RowTemplate.Height = 25;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(578, 338);
            this.dataGridViewUsuarios.TabIndex = 0;
            this.dataGridViewUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuarios_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colDni
            // 
            this.colDni.HeaderText = "Dni";
            this.colDni.Name = "colDni";
            this.colDni.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colBloqueado
            // 
            this.colBloqueado.HeaderText = "Bloqueado";
            this.colBloqueado.Name = "colBloqueado";
            this.colBloqueado.ReadOnly = true;
            // 
            // colAdmin
            // 
            this.colAdmin.HeaderText = "Admin";
            this.colAdmin.Name = "colAdmin";
            this.colAdmin.ReadOnly = true;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(649, 490);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(95, 23);
            this.btnCerrarSesion.TabIndex = 13;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido :";
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.AutoSize = true;
            this.nombreUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nombreUsuario.Location = new System.Drawing.Point(131, 34);
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.Size = new System.Drawing.Size(40, 15);
            this.nombreUsuario.TabIndex = 1;
            this.nombreUsuario.Text = "label2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.nombreUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabCajaDeAhorro.ResumeLayout(false);
            this.tabCajaDeAhorro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaja)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPlazoFijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPF)).EndInit();
            this.tabPagos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPagos)).EndInit();
            this.tabTarjetas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarjetas)).EndInit();
            this.tabUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabCajaDeAhorro;
        private TabPage tabPlazoFijo;
        private Label label1;
        private Label nombreUsuario;
        private TabPage tabPagos;
        private TabPage tabTarjetas;
        private DataGridView dataGridViewCaja;
        private DateTimePicker dateTimePicker1;
        private Button btnNewCaja;
        private Button btnNewPf;
        private DataGridView dataGridViewPF;
        private Button btnNewPago;
        private DataGridView dataGridViewPagos;
        private DataGridView dataGridViewTarjetas;
        private Button btnNewTarjeta;
        private DataGridViewTextBoxColumn ColumnIdPlf;
        private DataGridViewTextBoxColumn ColumnTitularPlz;
        private DataGridViewTextBoxColumn ColumnMontoPlz;
        private DataGridViewTextBoxColumn ColumnFechaInicioPlz;
        private DataGridViewTextBoxColumn ColumnFechaFinPlz;
        private DataGridViewTextBoxColumn ColumnTasaPlz;
        private DataGridViewTextBoxColumn ColumnPagadoPlz;
        private Button btnDetalles;
        private Button btnTransferir;
        private Button btnRetirar;
        private Button btnDepositar;
        private Button btnAgregarTitular;
        private Button btnBajaCaja;
        private Button btnPagarPago;
        private Button btnEliminarPago;
        private Button btnEliminarTitular;
        private Button btnPagarTarjeta;
        private Button btnDarDeBajaTarjeta;
        private ComboBox comboBoxTraerCajasATarjetas;
        private Label label2;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn ColumnPagosRealizados;
        private DataGridViewTextBoxColumn ColumnPagosPendientes;
        private ComboBox comboBoxTarjetaPago;
        private ComboBox comboBoxCajaPago;
        private Button btnCerrarSesion;
        private DataGridViewTextBoxColumn ColumnIdTarjeta;
        private DataGridViewTextBoxColumn ColumnTitularTarjeta;
        private DataGridViewTextBoxColumn ColumnNumeroTarjeta;
        private DataGridViewTextBoxColumn ColumnCodigoTarjeta;
        private DataGridViewTextBoxColumn ColumnLimiteTarjeta;
        private DataGridViewTextBoxColumn ColumnConsumosTarjeta;
        private Button btnEliminarPF;
        private ComboBox comboBoxPFCBU;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnCbu;
        private DataGridViewTextBoxColumn ColumnTitulares;
        private DataGridViewTextBoxColumn ColumnSaldo;
        private TabPage tabUsuario;
        private DataGridView dataGridViewUsuarios;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDni;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colBloqueado;
        private DataGridViewTextBoxColumn colAdmin;
        private TextBox montoText;
        private TextBox detalleTxt;
        private Button btnDesbloquear;
    }
}