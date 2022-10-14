using static TrabajoPractico1.FormLogin;

namespace TrabajoPractico1
{
    public partial class FormReg : Form //Formulario para el registro de los usuarios
    {
        Banco banco;
        private string nombre;
        private string apellido;
        private int dni;
        private string email;
        private string password;

        public regBotonDelegado regBotonEvento;

        public FormReg(Banco b)
        {
            InitializeComponent();
            this.banco = b;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            this.nombre = inputNombre.Text;
            this.apellido = inputApellido.Text;
            bool tryDni = Int32.TryParse(inputDni.Text, out this.dni);
            this.email = inputMail.Text;
            this.password = inputPass.Text;
            if(password != "" && email != "" && tryDni && apellido !="" && nombre != "")
            {
                banco.altaUsuario(nombre, apellido, dni, email, password);
                this.regBotonEvento();
            }
            else
            {
                MessageBox.Show("Por favor ingresar correctamente todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             

        }
        public delegate void regBotonDelegado();
        
        
    }
}