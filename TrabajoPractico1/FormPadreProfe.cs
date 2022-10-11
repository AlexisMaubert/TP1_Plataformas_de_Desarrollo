namespace TrabajoPractico1
{
    public partial class FormPadreProfe : Form
    {
        private Banco banco;
        FormHijoProfe hijoLogin;
        //Form3 hijoMain;
        internal string texto;
        string usuario;
        string pass;
        bool logued;
        public bool touched;
        public FormPadreProfe()
        {
            InitializeComponent();
            banco = new Banco();
            logued = false;
            hijoLogin = new FormHijoProfe(banco);
            hijoLogin.logued = false;
            hijoLogin.MdiParent = this;
            //hijoLogin.TransfEvento += TransfDelegado;
            hijoLogin.Show();
            touched = false;
        }
        //private void TransfDelegado(string Usuario, string Pass)
        //{
        //    this.usuario = Usuario;
        //    this.pass = Pass;
        //    if (banco.iniciarSesion(usuario, pass))
        //    {
        //        MessageBox.Show("Log in correcto, Usuario: " + usuario, "titulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        hijoLogin.Close();
        //        hijoMain = new Form3(new object[] { usuario, banco });
        //        hijoMain.usuario = Usuario;
        //        hijoMain.MdiParent = this;
        //        hijoMain.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Log in incorrecto", "titulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        hijoLogin.Show();
        //    }
        //}
    }
}