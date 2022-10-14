using System.Windows.Forms.VisualStyles;
using static TrabajoPractico1.FormReg;

namespace TrabajoPractico1
{
    public partial class FormLogin : Form
    {
        public Banco banco;
        public int dni;
        public string pass;

        public loginDelegado loginEvento;
        public regDelegado regEvento;
        public FormLogin(Banco b)
        {
            InitializeComponent();
            this.banco = b;
        }

        public delegate void loginDelegado(int Dni, string Pass);
        public delegate void regDelegado();

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
        private void iniciarSesion_Click(object sender, EventArgs e)
        {
            this.pass = inputPass.Text; //guardo la contrase�a del input en la variable pass
            //Try parse intenta convertir un String a Int y devuelve un booleano (Primer par�metro el string, segundo parametro la variable donde se va a guardar el resultado de la conversion)
            if (Int32.TryParse(inputDni.Text, out this.dni)) //Si la funci�n TryParse funciona guardo el resultado en la variable dni y ejecuto el IF
            {
                this.loginEvento(dni, pass); //Ejecuto el m�todo delegado para el inicio de sesi�n
            }
            else 
            {
                MessageBox.Show("Ingrese un n�mero de DNI v�lido", "Error en el ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void linkReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.regEvento();
        }

        private void FormLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}