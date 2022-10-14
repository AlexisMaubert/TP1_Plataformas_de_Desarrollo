namespace TrabajoPractico1
{
    partial class FormLogin
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
            this.btn_login = new System.Windows.Forms.Button();
            this.inputDni = new System.Windows.Forms.TextBox();
            this.inputPass = new System.Windows.Forms.TextBox();
            this.textDni = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.Label();
            this.linkReg = new System.Windows.Forms.LinkLabel();
            this.textReg = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(63, 177);
            this.btn_login.Name = "btn_login";
            this.btn_login.Padding = new System.Windows.Forms.Padding(5);
            this.btn_login.Size = new System.Drawing.Size(147, 41);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "Iniciar sesión";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.iniciarSesion_Click);
            // 
            // inputDni
            // 
            this.inputDni.Location = new System.Drawing.Point(48, 49);
            this.inputDni.Name = "inputDni";
            this.inputDni.Size = new System.Drawing.Size(174, 27);
            this.inputDni.TabIndex = 1;
            // 
            // inputPass
            // 
            this.inputPass.Location = new System.Drawing.Point(48, 111);
            this.inputPass.Name = "inputPass";
            this.inputPass.Size = new System.Drawing.Size(174, 27);
            this.inputPass.TabIndex = 2;
            // 
            // textDni
            // 
            this.textDni.AutoSize = true;
            this.textDni.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textDni.Location = new System.Drawing.Point(112, 28);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(42, 18);
            this.textDni.TabIndex = 3;
            this.textDni.Text = "DNI";
            // 
            // textPass
            // 
            this.textPass.AutoSize = true;
            this.textPass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textPass.Location = new System.Drawing.Point(80, 90);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(110, 18);
            this.textPass.TabIndex = 4;
            this.textPass.Text = "Contraseña";
            this.textPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkReg
            // 
            this.linkReg.AutoSize = true;
            this.linkReg.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkReg.Location = new System.Drawing.Point(219, 232);
            this.linkReg.Name = "linkReg";
            this.linkReg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.linkReg.Size = new System.Drawing.Size(31, 16);
            this.linkReg.TabIndex = 5;
            this.linkReg.TabStop = true;
            this.linkReg.Text = "aca";
            this.linkReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReg_LinkClicked);
            // 
            // textReg
            // 
            this.textReg.AutoSize = true;
            this.textReg.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textReg.Location = new System.Drawing.Point(26, 232);
            this.textReg.Name = "textReg";
            this.textReg.Size = new System.Drawing.Size(196, 16);
            this.textReg.TabIndex = 6;
            this.textReg.Text = "No tenes cuenta? Registrate";
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titulo.Location = new System.Drawing.Point(198, 116);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(364, 59);
            this.titulo.TabIndex = 7;
            this.titulo.Text = "Iniciá sesión";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.inputDni);
            this.groupBox1.Controls.Add(this.btn_login);
            this.groupBox1.Controls.Add(this.inputPass);
            this.groupBox1.Controls.Add(this.textReg);
            this.groupBox1.Controls.Add(this.textDni);
            this.groupBox1.Controls.Add(this.linkReg);
            this.groupBox1.Controls.Add(this.textPass);
            this.groupBox1.Location = new System.Drawing.Point(253, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 271);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.titulo);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_login;
        private TextBox inputDni;
        private TextBox inputPass;
        private Label textDni;
        private Label textPass;
        private LinkLabel linkReg;
        private Label textReg;
        private Label titulo;
        private GroupBox groupBox1;
    }
}