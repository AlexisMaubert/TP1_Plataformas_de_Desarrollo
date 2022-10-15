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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCbu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitulares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.ColumnPagosRealizados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPagosPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ColumnIdPlf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitularPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMontoPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFechaInicioPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFechaFinPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTasaPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPagadoPlz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.ColumnIdTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitularTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumeroTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCodigoTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLimiteTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConsumosTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 61);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(692, 260);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(684, 232);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CajasDeAhorro";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(441, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Nueva Caja de Ahorro";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnCbu,
            this.ColumnTitulares,
            this.ColumnSaldo});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(419, 236);
            this.dataGridView1.TabIndex = 0;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(684, 232);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PlazoFijo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(684, 232);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Pagos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(684, 232);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tarjetas";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 35);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "Mostrar datos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdPlf,
            this.ColumnTitularPlz,
            this.ColumnMontoPlz,
            this.ColumnFechaInicioPlz,
            this.ColumnFechaFinPlz,
            this.ColumnTasaPlz,
            this.ColumnPagadoPlz});
            this.dataGridView2.Location = new System.Drawing.Point(-4, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(593, 232);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPagosRealizados,
            this.ColumnPagosPendientes});
            this.dataGridView3.Location = new System.Drawing.Point(-4, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.Size = new System.Drawing.Size(423, 232);
            this.dataGridView3.TabIndex = 0;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdTarjeta,
            this.ColumnTitularTarjeta,
            this.ColumnNumeroTarjeta,
            this.ColumnCodigoTarjeta,
            this.ColumnLimiteTarjeta,
            this.ColumnConsumosTarjeta});
            this.dataGridView4.Location = new System.Drawing.Point(-4, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 25;
            this.dataGridView4.Size = new System.Drawing.Size(423, 229);
            this.dataGridView4.TabIndex = 0;
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(458, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Nuevo Pago";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(581, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Nuevo Plazo Fijo";
            this.button4.UseVisualStyleBackColor = true;
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
            this.ColumnTitularPlz.HeaderText = "Titular/es";
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
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(489, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Nueva Tarjeta";
            this.button5.UseVisualStyleBackColor = true;
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
            this.ColumnTitularTarjeta.HeaderText = "Titular/res";
            this.ColumnTitularTarjeta.Name = "ColumnTitularTarjeta";
            this.ColumnTitularTarjeta.ReadOnly = true;
            // 
            // ColumnNumeroTarjeta
            // 
            this.ColumnNumeroTarjeta.Frozen = true;
            this.ColumnNumeroTarjeta.HeaderText = "Numero Tarjeta";
            this.ColumnNumeroTarjeta.Name = "ColumnNumeroTarjeta";
            this.ColumnNumeroTarjeta.ReadOnly = true;
            // 
            // ColumnCodigoTarjeta
            // 
            this.ColumnCodigoTarjeta.Frozen = true;
            this.ColumnCodigoTarjeta.HeaderText = "Codigo";
            this.ColumnCodigoTarjeta.Name = "ColumnCodigoTarjeta";
            this.ColumnCodigoTarjeta.ReadOnly = true;
            // 
            // ColumnLimiteTarjeta
            // 
            this.ColumnLimiteTarjeta.Frozen = true;
            this.ColumnLimiteTarjeta.HeaderText = "Limite";
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Label label2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnCbu;
        private DataGridViewTextBoxColumn ColumnTitulares;
        private DataGridViewTextBoxColumn ColumnSaldo;
        private Button button1;
        private Button button2;
        private Button button4;
        private DataGridView dataGridView2;
        private Button button3;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn ColumnPagosRealizados;
        private DataGridViewTextBoxColumn ColumnPagosPendientes;
        private DataGridView dataGridView4;
        private DataGridViewTextBoxColumn ColumnIdPlf;
        private DataGridViewTextBoxColumn ColumnTitularPlz;
        private DataGridViewTextBoxColumn ColumnMontoPlz;
        private DataGridViewTextBoxColumn ColumnFechaInicioPlz;
        private DataGridViewTextBoxColumn ColumnFechaFinPlz;
        private DataGridViewTextBoxColumn ColumnTasaPlz;
        private DataGridViewTextBoxColumn ColumnPagadoPlz;
        private Button button5;
        private DataGridViewTextBoxColumn ColumnIdTarjeta;
        private DataGridViewTextBoxColumn ColumnTitularTarjeta;
        private DataGridViewTextBoxColumn ColumnNumeroTarjeta;
        private DataGridViewTextBoxColumn ColumnCodigoTarjeta;
        private DataGridViewTextBoxColumn ColumnLimiteTarjeta;
        private DataGridViewTextBoxColumn ColumnConsumosTarjeta;
    }
}