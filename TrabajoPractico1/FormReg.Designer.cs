namespace TrabajoPractico1
{
    partial class FormReg
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.textPass = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.Label();
            this.textDni = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.Label();
            this.inputPass = new System.Windows.Forms.TextBox();
            this.inputMail = new System.Windows.Forms.TextBox();
            this.inputDni = new System.Windows.Forms.TextBox();
            this.inputApellido = new System.Windows.Forms.TextBox();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titulo.Location = new System.Drawing.Point(242, 50);
            this.titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(305, 59);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "Registrate";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnReg);
            this.groupBox1.Controls.Add(this.textPass);
            this.groupBox1.Controls.Add(this.textEmail);
            this.groupBox1.Controls.Add(this.textDni);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textNombre);
            this.groupBox1.Controls.Add(this.inputPass);
            this.groupBox1.Controls.Add(this.inputMail);
            this.groupBox1.Controls.Add(this.inputDni);
            this.groupBox1.Controls.Add(this.inputApellido);
            this.groupBox1.Controls.Add(this.inputNombre);
            this.groupBox1.Location = new System.Drawing.Point(121, 123);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(544, 402);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(204, 301);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(120, 35);
            this.btnReg.TabIndex = 10;
            this.btnReg.Text = "Registrarse";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // textPass
            // 
            this.textPass.AutoSize = true;
            this.textPass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textPass.Location = new System.Drawing.Point(39, 249);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(110, 18);
            this.textPass.TabIndex = 9;
            this.textPass.Text = "Contraseña";
            // 
            // textEmail
            // 
            this.textEmail.AutoSize = true;
            this.textEmail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textEmail.Location = new System.Drawing.Point(39, 200);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(54, 18);
            this.textEmail.TabIndex = 8;
            this.textEmail.Text = "Email";
            this.textEmail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textDni
            // 
            this.textDni.AutoSize = true;
            this.textDni.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textDni.Location = new System.Drawing.Point(39, 156);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(42, 18);
            this.textDni.TabIndex = 7;
            this.textDni.Text = "DNI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(39, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Apellido";
            // 
            // textNombre
            // 
            this.textNombre.AutoSize = true;
            this.textNombre.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textNombre.Location = new System.Drawing.Point(39, 49);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(78, 18);
            this.textNombre.TabIndex = 5;
            this.textNombre.Text = "Nombre";
            // 
            // inputPass
            // 
            this.inputPass.Location = new System.Drawing.Point(176, 246);
            this.inputPass.Name = "inputPass";
            this.inputPass.Size = new System.Drawing.Size(320, 27);
            this.inputPass.TabIndex = 4;
            // 
            // inputMail
            // 
            this.inputMail.Location = new System.Drawing.Point(176, 197);
            this.inputMail.Name = "inputMail";
            this.inputMail.Size = new System.Drawing.Size(320, 27);
            this.inputMail.TabIndex = 3;
            // 
            // inputDni
            // 
            this.inputDni.Location = new System.Drawing.Point(176, 147);
            this.inputDni.Margin = new System.Windows.Forms.Padding(4);
            this.inputDni.Name = "inputDni";
            this.inputDni.Size = new System.Drawing.Size(320, 27);
            this.inputDni.TabIndex = 2;
            // 
            // inputApellido
            // 
            this.inputApellido.Location = new System.Drawing.Point(176, 97);
            this.inputApellido.Margin = new System.Windows.Forms.Padding(4);
            this.inputApellido.Name = "inputApellido";
            this.inputApellido.Size = new System.Drawing.Size(320, 27);
            this.inputApellido.TabIndex = 1;
            // 
            // inputNombre
            // 
            this.inputNombre.Location = new System.Drawing.Point(176, 46);
            this.inputNombre.Margin = new System.Windows.Forms.Padding(4);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(320, 27);
            this.inputNombre.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(204, 354);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 29);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.titulo);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReg";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label titulo;
        private GroupBox groupBox1;
        private TextBox inputDni;
        private TextBox inputApellido;
        private TextBox inputNombre;
        private TextBox inputPass;
        private TextBox inputMail;
        private Label textDni;
        private Label label1;
        private Label textNombre;
        private Button btnReg;
        private Label textPass;
        private Label textEmail;
        private Button btnCancelar;
    }
}