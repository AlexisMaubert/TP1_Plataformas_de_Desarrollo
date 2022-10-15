namespace TrabajoPractico1
{
    public partial class FormPadre : Form //Formulario "vacio" que va a contener todas las distintas vistas.
    {
        private Banco banco;
        FormLogin hijoLogin;
        FormReg hijoReg;
        FormMain hijoMain;
        public int dni;
        public string password;

        public bool logued;

        public FormPadre()
        {
            InitializeComponent();
            this.banco = new Banco();  //Única instancia de banco.
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
            this.password = Pass;
            this.dni = Dni;
            if(banco.iniciarSesion(this.dni, this.password))
            {
                MessageBox.Show("Log in correcto, Usuario: " + this.banco.mostrarUsuario(), "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hijoLogin.Close();
                hijoMain = new FormMain(banco);
                //hijoLogin.usuario = Usuario;
                hijoMain.MdiParent = this;
                hijoMain.Show();
            }
            else
            {
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
            this.hijoLogin = new FormLogin(this.banco); 
            this.hijoLogin.MdiParent = this;
            this.hijoLogin.loginEvento += loginDelegado;
            this.hijoLogin.regEvento += regDelegado;
            hijoLogin.Show();
        }
    }
}