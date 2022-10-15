using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPractico1
{
    public partial class FormMain : Form
    {

        private Banco banco;
        public FormMain(Banco b)
        {
            InitializeComponent();
            this.banco = b;
            label2.Text = banco.mostrarUsuario(); //Se muestra el nombre del usuario en la vista
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresData();
        }

        private void refresData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(banco.usuarioLogeado.cajas.ToArray());
          
        }

        
    }
}
