namespace TrabajoPractico1
{
    public partial class FormHijoProfe : Form
    {
        public bool logued;
        public string usuario;
        public string pass;
        public Banco elBanco;

        public TransfDelegado TransfEvento;
        public FormHijoProfe(Banco b)
        {
            logued = false;
            InitializeComponent();
            elBanco = b;
        }
        private void button1_Click(object sender, EventArgs e) //
        {
            usuario = textBox1.Text;
            pass = textBox4.Text;
            if (usuario != null && usuario != "")
            {
                this.TransfEvento(usuario, pass);
            }
            else
                MessageBox.Show("Debe ingresar un usuario!");

        }
        public delegate void TransfDelegado(string usuario, string pass);

        private void FormHijoProfe_Load(object sender, EventArgs e)
        {

        }


        //NECESITAMOS UN MEJOR FORMULARIO DE REGISTRO
        //PARA METER EL NOMBRE APELLIDO DNI ETC DEL USUARIO
        //POSIBLEMENTE UNA NUEVA VISTA (OTRO FORM) DEPENDIENDO DE QUE QUEDE MAS LINDO
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    if (elBanco.agregarUsuario(textBox3.Text, textBox2.Text))
        //        MessageBox.Show("Usuario Agregado con éxito");
        //   else
        //      MessageBox.Show("No se pudo agregar el usuario");
        //}

    }
}