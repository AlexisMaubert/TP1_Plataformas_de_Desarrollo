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
            nombreUsuario.Text = banco.mostrarUsuario(); //Se muestra el nombre del usuario en la vista
            this.refreshDataCaja();
            this.refreshDataPF();
            this.refreshDataPagos();
            this.refreshDataTarjetas();
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e) //Si pongo el metodo refreshData en el boton de crear caja no está medio al pedo este?????
        {
            refreshDataCaja();
        }
        private void refreshDataCaja()
        {
            dataGridViewCaja.Rows.Clear();
            foreach (CajaDeAhorro caja in banco.obtenerCajaDeAhorro())
            {
                string nombres = "";
                foreach(Usuario titular in caja.titulares)
                {
                    nombres =  nombres + titular.nombre + " " + titular.apellido +" / ";
                }
                dataGridViewCaja.Rows.Add("", caja.cbu, nombres, caja.saldo);
            }
        }
        private void refreshDataPF()
        {
            dataGridViewPF.Rows.Clear();
            foreach (PlazoFijo pf in banco.obtenerPlzFijo())
            {
                string pagado = (pf.pagado) ? "Sí" : "No"; 
                dataGridViewPF.Rows.Add("", pf.titular.apellido + " " + pf.titular.nombre, pf.monto, pf.fechaIni, pf.fechaFin, pf.tasa,pagado );
            }
        }
        private void refreshDataPagos()
        {
            dataGridViewPagos.Rows.Clear();
            //Aca se tienen que agregar las cosas de los pagos pero no se como manejar el tema de los pagos
        }
        private void refreshDataTarjetas()
        {
            dataGridViewTarjetas.Rows.Clear();
            foreach (Tarjeta tarjeta in banco.obtenerTarjetas()) 
            {
                dataGridViewTarjetas.Rows.Add("", tarjeta.titular.apellido + " " + tarjeta.titular.nombre, tarjeta.numero, tarjeta.codigoV, tarjeta.limite, tarjeta.consumo);
            }
        }
        private void btnNewCaja_Click(object sender, EventArgs e)
        {
            banco.crearCajaDeAhorro(0);
            this.refreshDataCaja();
        }
        private void btnNewPf_Click(object sender, EventArgs e)
        {
            //Metodo para crear plazo fijo que todavia no está definido :)
            this.refreshDataPF();
        }

        private void btnNewPago_Click(object sender, EventArgs e)
        {
            banco.nuevoPago(banco.usuarioLogeado, "Nombre del pago", 0, "efectivo"); // hay que modificar esto para que al tocar el boton aparezcan opciones el algun lado del formulario para completar dinamicamente estos datos
            this.refreshDataPagos();
        }

        private void btnNewTarjeta_Click(object sender, EventArgs e)
        {
            banco.altaTarjeta(banco.usuarioLogeado, 20000);
            this.refreshDataTarjetas();
        }

        

        private void dataGridViewCaja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnBajaCaja.Show();
            btnModificarCaja.Show();
            btnDepositar.Show();
            btnRetirar.Show();
            btnTransferir.Show();
            btnDetalles.Show();
            btnMovimientos.Show();
            string usuarioSeleccionado = dataGridViewCaja.SelectedCells[0].Value.ToString();
         }

        private void btnBajaCaja_Click(object sender, EventArgs e)
        {

        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("detalles","detalles",MessageBoxButtons.OK);
        }
    }
}
