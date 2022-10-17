using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrabajoPractico1
{
    public partial class FormMain : Form
    {
        private Banco banco;
        private int cbuSeleccionado;
        private int numeroTarjetaSeleccionado;
        private DateTime fechaElegida;

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
        public void esconderBtns()
        {
            btnBajaCaja.Visible = false;
            btnAgregarTitular.Visible = false;
            btnEliminarTitular.Visible = false;
            btnDepositar.Visible = false;
            btnRetirar.Visible = false;
            btnTransferir.Visible = false;
            btnDetalles.Visible = false;
            //btnMovimientos.Visible = false;
        }
        public void mostrarBtns()
        {
            btnBajaCaja.Show();
            btnAgregarTitular.Show();
            btnEliminarTitular.Show();
            btnDepositar.Show();
            btnRetirar.Show();
            btnTransferir.Show();
            btnDetalles.Show();
            //btnMovimientos.Show();
        }
        private void dataGridViewCaja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            esconderBtns();
            mostrarBtns();
            Int32.TryParse(dataGridViewCaja.Rows[e.RowIndex].Cells[1].Value.ToString(), out cbuSeleccionado);
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("detalles","detalles",MessageBoxButtons.OK);
        }

        private void btnBajaCaja_Click(object sender, EventArgs e)
        {
            if (banco.bajaCaja(cbuSeleccionado)) {
                MessageBox.Show("Borraste Exitosamente la caja", "Operacion exitosa 😏", MessageBoxButtons.OK,MessageBoxIcon.Information);
                esconderBtns();
                refreshDataCaja();
            }
            else
            {
               MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarTitular_Click(object sender, EventArgs e)
        {
            int nuevodni;
            Int32.TryParse(Interaction.InputBox("ingrese Dni del nuevo titular: ", "Agregando Titular"), out nuevodni);
            CajaDeAhorro caja = banco.obtenerCajaDeAhorro().Find(caja => caja.cbu == cbuSeleccionado);
            if (banco.agregarUsuarioACaja(caja, nuevodni))
            {
                MessageBox.Show("Se agrego el nuevo Titular", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataCaja();
            }
        }

        private void btnEliminarTitular_Click(object sender, EventArgs e)
        {
            int nuevodni;
            Int32.TryParse(Interaction.InputBox("ingrese Dni del titular a eliminar: ", "Eliminar Titular"), out nuevodni);
            CajaDeAhorro caja = banco.obtenerCajaDeAhorro().Find(caja => caja.cbu == cbuSeleccionado);
            if (banco.eliminarUsuarioDeCaja(caja, nuevodni))
            {
                MessageBox.Show("Se removió titular con dni nro "+nuevodni, "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataCaja();
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            int deposito;
            if(!Int32.TryParse(Interaction.InputBox("Monto a depositar : ", "ingresar monto"), out deposito)|| deposito <= 0)
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CajaDeAhorro caja = banco.obtenerCajaDeAhorro().Find(caja => caja.cbu == cbuSeleccionado);
                banco.depositar(caja, deposito);
                MessageBox.Show("Se depositó el monto con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataCaja();
            }
        }
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            int retiro;
            if (!Int32.TryParse(Interaction.InputBox("Monto a retirar : ", "ingresar monto"), out retiro) || retiro <= 0)
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CajaDeAhorro caja = banco.obtenerCajaDeAhorro().Find(caja => caja.cbu == cbuSeleccionado);
                if (banco.retirar(caja, retiro))
                {
                    MessageBox.Show("Se retiró el monto con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDataCaja();
                }
                else
                {
                    MessageBox.Show("El monto que desea retirar excede el saldo de la cuenta", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            int monto;
            int cbu;
            if (!Int32.TryParse(Interaction.InputBox("Monto a transferir : ", "ingresar monto"), out monto) || monto <= 0)
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CajaDeAhorro caja = banco.obtenerCajaDeAhorro().Find(caja => caja.cbu == cbuSeleccionado);
                if (monto > caja.saldo)
                {
                    MessageBox.Show("El monto que desea transferir supera el saldo de la cuenta", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Int32.TryParse(Interaction.InputBox("Ingrese el CBU de la cuenta destino : ", "ingresar CBU"), out cbu))
                {
                    MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    if (banco.transferir(caja, cbu, monto))
                    {
                        MessageBox.Show("Se tranfirió el monto con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshDataCaja();
                    }
                }
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            string movimientos = "";
            foreach(Movimiento movimiento in banco.obtenerMovimientos(cbuSeleccionado))
            {
                movimientos = movimientos + movimiento.ToString() + "\n";
            }
            MessageBox.Show(movimientos, "Movimientos", MessageBoxButtons.OK);
        }

        //TARJETAS ------------------------

        private void dataGridViewTarjetas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32.TryParse(dataGridViewTarjetas.Rows[e.RowIndex].Cells[2].Value.ToString(), out numeroTarjetaSeleccionado);
            btnDarDeBajaTarjeta.Show();
            btnPagarTarjeta.Show();
        }

        private void btnDarDeBajaTarjeta_Click(object sender, EventArgs e)
        {
            if (banco.bajaTarjeta(numeroTarjetaSeleccionado))
            {
                MessageBox.Show("Se ah dado de baja la tarjeta", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                esconderBtns();
                refreshDataTarjetas();
            }
            else
            {
                MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPagarTarjeta_Click(object sender, EventArgs e)
        {
            comboBoxTraerCajasATarjetas.Show();
        }

        //private void comboBoxTraerCajasATarjetas_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    for(int i = 0; i <= banco.usuarioLogeado.cajas.LongCount(); i++)
        //    {
                
        //    }
        //}
    }


    

    

}






