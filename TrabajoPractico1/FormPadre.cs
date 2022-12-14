using Microsoft.VisualBasic.ApplicationServices;

namespace TrabajoPractico1
{
    public partial class FormPadre : Form //Formulario "vacio" que va a contener todas las distintas vistas.
    {
        private Banco banco;
        FormLogin hijoLogin;
        FormReg hijoReg;
        FormMain hijoMain;

        public bool logued;

        public FormPadre()
        {
            InitializeComponent();
            banco = new Banco();  //Única instancia de banco.
            this.logued = false;
            this.hijoLogin = new FormLogin(this.banco); //Creo un formulario hijo y le paso como parámetro al banco.
            this.hijoLogin.MdiParent = this; //Indico que el formulario creado va a ser un hijo MDI de este formulario.
            this.hijoLogin.loginEvento += loginDelegado;
            this.hijoLogin.regEvento += regDelegado;
            this.hijoReg = new FormReg(banco);
            this.hijoReg.MdiParent = this;
            this.hijoReg.regBotonEvento += regBotonDelegado;
            this.hijoLogin.Show();
        }

        private void FormPadre_Load(object sender, EventArgs e)
        {

        }
        private void loginDelegado(int Dni, string Pass)
        {
            int result = banco.iniciarSesion(Dni, Pass);
            if (result == 0)
            {
                MessageBox.Show("Log in correcto, Usuario: " + this.banco.mostrarUsuario(), "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hijoLogin.Close();
                hijoMain = new FormMain(banco);
                //hijoLogin.usuario = Usuario;
                hijoMain.MdiParent = this;
                hijoMain.cerrarSesionEvento += cerrarSesionDelegado;
                hijoMain.Show();
            }
            else
            {
                if(result == 1)
                {
                    MessageBox.Show("Usuario no encontrado", "Log in incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == 2)
                {
                    MessageBox.Show("Este usuario está bloqueado", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == 3)
                {
                    MessageBox.Show("Se ha excedido el número de intentos\nEste usuario ahora está bloqueado", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == 4)
                {
                    MessageBox.Show("La contraseña ingresada fue incorrecta \nTe quedan " + (3 - banco.mostrarIntentosRestantes(Dni)) + " intentos.", "Contraseña incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                hijoLogin.Show();
            }
        }
        private void regDelegado()
        {
            hijoLogin.Close();
            this.hijoReg = new FormReg(banco);
            this.hijoReg.MdiParent = this;
            this.hijoReg.regBotonEvento += regBotonDelegado;
            hijoReg.Show();
        }
        private void regBotonDelegado()
        {
            hijoReg.Close();
            MessageBox.Show("Usuario registrado correctamente " , "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.hijoLogin = new FormLogin(this.banco); 
            this.hijoLogin.MdiParent = this;
            this.hijoLogin.loginEvento += loginDelegado;
            this.hijoLogin.regEvento += regDelegado;
            hijoLogin.Show();
        }
        private void cerrarSesionDelegado()
        {
            banco.cerrarSesion();
            MessageBox.Show("Muchas gracias por usar nuestra app", "Sesión finalizada 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hijoMain.Close();
            this.hijoLogin = new FormLogin(this.banco);
            this.hijoLogin.MdiParent = this;
            this.hijoLogin.loginEvento += loginDelegado;
            this.hijoLogin.regEvento += regDelegado;
            hijoLogin.Show();
        }
    }
}