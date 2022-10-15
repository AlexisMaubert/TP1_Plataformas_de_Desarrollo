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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCajaDeAhorro = new System.Windows.Forms.TabPage();
            this.btnNewCaja = new System.Windows.Forms.Button();
            this.dataGridViewCaja = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCbu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitulares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPlazoFijo = new System.Windows.Forms.TabPage();
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
            this.btnNewPago = new System.Windows.Forms.Button();
            this.dataGridViewPagos = new System.Windows.Forms.DataGridView();
            this.ColumnPagosRealizados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPagosPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTarjetas = new System.Windows.Forms.TabPage();
            this.btnNewTarjeta = new System.Windows.Forms.Button();
            this.dataGridViewTarjetas = new System.Windows.Forms.DataGridView();
            this.ColumnIdTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitularTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumeroTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCodigoTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLimiteTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConsumosTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.nombreUsuario = new System.Windows.Forms.Label();
            this.btnMostrarDatos = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabCajaDeAhorro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaja)).BeginInit();
            this.tabPlazoFijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPF)).BeginInit();
            this.tabPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPagos)).BeginInit();
            this.tabTarjetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarjetas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCajaDeAhorro);
            this.tabControl1.Controls.Add(this.tabPlazoFijo);
            this.tabControl1.Controls.Add(this.tabPagos);
            this.tabControl1.Controls.Add(this.tabTarjetas);
            this.tabControl1.Location = new System.Drawing.Point(12, 61);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 424);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCajaDeAhorro
            // 
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
            // btnNewCaja
            // 
            this.btnNewCaja.Location = new System.Drawing.Point(15, 361);
            this.btnNewCaja.Name = "btnNewCaja";
            this.btnNewCaja.Size = new System.Drawing.Size(133, 23);
            this.btnNewCaja.TabIndex = 1;
            this.btnNewCaja.Text = "Nueva Caja de Ahorro";
            this.btnNewCaja.UseVisualStyleBackColor = true;
            this.btnNewCaja.Visible = false;
            this.btnNewCaja.Click += new System.EventHandler(this.btnNewCaja_Click);
            // 
            // dataGridViewCaja
            // 
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
            this.dataGridViewCaja.Size = new System.Drawing.Size(435, 345);
            this.dataGridViewCaja.TabIndex = 0;
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
            // tabPlazoFijo
            // 
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
            this.dataGridViewPF.RowTemplate.Height = 25;
            this.dataGridViewPF.Size = new System.Drawing.Size(640, 343);
            this.dataGridViewPF.TabIndex = 0;
            // 
            // ColumnIdPlf
            // 
            this.ColumnIdPlf.Frozen = true;
            this.ColumnIdPlf.HeaderText = "IdPlf";
            this.ColumnIdPlf.Name = "ColumnIdPlf";
            this.ColumnIdPlf.ReadOnly = true;
            this.ColumnIdPlf.Visible = false;
            // 
            // ColumnTitularPlz
            // 
            this.ColumnTitularPlz.Frozen = true;
            this.ColumnTitularPlz.HeaderText = "Titular";
            this.ColumnTitularPlz.Name = "ColumnTitularPlz";
            this.ColumnTitularPlz.ReadOnly = true;
            // 
            // ColumnMontoPlz
            // 
            this.ColumnMontoPlz.Frozen = true;
            this.ColumnMontoPlz.HeaderText = "Monto";
            this.ColumnMontoPlz.Name = "ColumnMontoPlz";
            this.ColumnMontoPlz.ReadOnly = true;
            // 
            // ColumnFechaInicioPlz
            // 
            this.ColumnFechaInicioPlz.Frozen = true;
            this.ColumnFechaInicioPlz.HeaderText = "Fecha Inicio";
            this.ColumnFechaInicioPlz.Name = "ColumnFechaInicioPlz";
            this.ColumnFechaInicioPlz.ReadOnly = true;
            // 
            // ColumnFechaFinPlz
            // 
            this.ColumnFechaFinPlz.Frozen = true;
            this.ColumnFechaFinPlz.HeaderText = "Fecha Fin";
            this.ColumnFechaFinPlz.Name = "ColumnFechaFinPlz";
            this.ColumnFechaFinPlz.ReadOnly = true;
            // 
            // ColumnTasaPlz
            // 
            this.ColumnTasaPlz.Frozen = true;
            this.ColumnTasaPlz.HeaderText = "Tasa";
            this.ColumnTasaPlz.Name = "ColumnTasaPlz";
            this.ColumnTasaPlz.ReadOnly = true;
            // 
            // ColumnPagadoPlz
            // 
            this.ColumnPagadoPlz.Frozen = true;
            this.ColumnPagadoPlz.HeaderText = "Pagado";
            this.ColumnPagadoPlz.Name = "ColumnPagadoPlz";
            this.ColumnPagadoPlz.ReadOnly = true;
            // 
            // tabPagos
            // 
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
            this.dataGridViewPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPagosRealizados,
            this.ColumnPagosPendientes});
            this.dataGridViewPagos.Location = new System.Drawing.Point(-4, 0);
            this.dataGridViewPagos.Name = "dataGridViewPagos";
            this.dataGridViewPagos.RowTemplate.Height = 25;
            this.dataGridViewPagos.Size = new System.Drawing.Size(244, 345);
            this.dataGridViewPagos.TabIndex = 0;
            // 
            // ColumnPagosRealizados
            // 
            this.ColumnPagosRealizados.Frozen = true;
            this.ColumnPagosRealizados.HeaderText = "Pagos Realizados";
            this.ColumnPagosRealizados.Name = "ColumnPagosRealizados";
            this.ColumnPagosRealizados.ReadOnly = true;
            // 
            // ColumnPagosPendientes
            // 
            this.ColumnPagosPendientes.Frozen = true;
            this.ColumnPagosPendientes.HeaderText = "PagosPendientes";
            this.ColumnPagosPendientes.Name = "ColumnPagosPendientes";
            this.ColumnPagosPendientes.ReadOnly = true;
            // 
            // tabTarjetas
            // 
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
            this.dataGridViewTarjetas.RowTemplate.Height = 25;
            this.dataGridViewTarjetas.Size = new System.Drawing.Size(543, 343);
            this.dataGridViewTarjetas.TabIndex = 0;
            // 
            // ColumnIdTarjeta
            // 
            this.ColumnIdTarjeta.Frozen = true;
            this.ColumnIdTarjeta.HeaderText = "Id";
            this.ColumnIdTarjeta.Name = "ColumnIdTarjeta";
            this.ColumnIdTarjeta.ReadOnly = true;
            this.ColumnIdTarjeta.Visible = false;
            // 
            // ColumnTitularTarjeta
            // 
            this.ColumnTitularTarjeta.Frozen = true;
            this.ColumnTitularTarjeta.HeaderText = "Titular";
            this.ColumnTitularTarjeta.Name = "ColumnTitularTarjeta";
            this.ColumnTitularTarjeta.ReadOnly = true;
            // 
            // ColumnNumeroTarjeta
            // 
            this.ColumnNumeroTarjeta.Frozen = true;
            this.ColumnNumeroTarjeta.HeaderText = "Número Tarjeta";
            this.ColumnNumeroTarjeta.Name = "ColumnNumeroTarjeta";
            this.ColumnNumeroTarjeta.ReadOnly = true;
            // 
            // ColumnCodigoTarjeta
            // 
            this.ColumnCodigoTarjeta.Frozen = true;
            this.ColumnCodigoTarjeta.HeaderText = "Código";
            this.ColumnCodigoTarjeta.Name = "ColumnCodigoTarjeta";
            this.ColumnCodigoTarjeta.ReadOnly = true;
            // 
            // ColumnLimiteTarjeta
            // 
            this.ColumnLimiteTarjeta.Frozen = true;
            this.ColumnLimiteTarjeta.HeaderText = "Límite";
            this.ColumnLimiteTarjeta.Name = "ColumnLimiteTarjeta";
            this.ColumnLimiteTarjeta.ReadOnly = true;
            // 
            // ColumnConsumosTarjeta
            // 
            this.ColumnConsumosTarjeta.Frozen = true;
            this.ColumnConsumosTarjeta.HeaderText = "Consumos";
            this.ColumnConsumosTarjeta.Name = "ColumnConsumosTarjeta";
            this.ColumnConsumosTarjeta.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido usuario:";
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.AutoSize = true;
            this.nombreUsuario.Location = new System.Drawing.Point(179, 21);
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.Size = new System.Drawing.Size(38, 15);
            this.nombreUsuario.TabIndex = 1;
            this.nombreUsuario.Text = "label2";
            // 
            // btnMostrarDatos
            // 
            this.btnMostrarDatos.Location = new System.Drawing.Point(609, 21);
            this.btnMostrarDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMostrarDatos.Name = "btnMostrarDatos";
            this.btnMostrarDatos.Size = new System.Drawing.Size(121, 22);
            this.btnMostrarDatos.TabIndex = 2;
            this.btnMostrarDatos.Text = "Mostrar datos";
            this.btnMostrarDatos.UseVisualStyleBackColor = true;
            this.btnMostrarDatos.Click += new System.EventHandler(this.btnMostrarDatos_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.btnMostrarDatos);
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
            this.tabControl1.ResumeLayout(false);
            this.tabCajaDeAhorro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaja)).EndInit();
            this.tabPlazoFijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPF)).EndInit();
            this.tabPagos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPagos)).EndInit();
            this.tabTarjetas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarjetas)).EndInit();
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
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnCbu;
        private DataGridViewTextBoxColumn ColumnTitulares;
        private DataGridViewTextBoxColumn ColumnSaldo;
        private Button btnMostrarDatos;
        private Button btnNewCaja;
        private Button btnNewPf;
        private DataGridView dataGridViewPF;
        private Button btnNewPago;
        private DataGridView dataGridViewPagos;
        private DataGridViewTextBoxColumn ColumnPagosRealizados;
        private DataGridViewTextBoxColumn ColumnPagosPendientes;
        private DataGridView dataGridViewTarjetas;
        private Button btnNewTarjeta;
        private DataGridViewTextBoxColumn ColumnIdPlf;
        private DataGridViewTextBoxColumn ColumnTitularPlz;
        private DataGridViewTextBoxColumn ColumnMontoPlz;
        private DataGridViewTextBoxColumn ColumnFechaInicioPlz;
        private DataGridViewTextBoxColumn ColumnFechaFinPlz;
        private DataGridViewTextBoxColumn ColumnTasaPlz;
        private DataGridViewTextBoxColumn ColumnPagadoPlz;
        private DataGridViewTextBoxColumn ColumnIdTarjeta;
        private DataGridViewTextBoxColumn ColumnTitularTarjeta;
        private DataGridViewTextBoxColumn ColumnNumeroTarjeta;
        private DataGridViewTextBoxColumn ColumnCodigoTarjeta;
        private DataGridViewTextBoxColumn ColumnLimiteTarjeta;
        private DataGridViewTextBoxColumn ColumnConsumosTarjeta;
    }
}