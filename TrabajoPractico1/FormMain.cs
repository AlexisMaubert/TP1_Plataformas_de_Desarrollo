using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private int idPago;
        private DateTime fechaElegida;
        public cerrarSesionDelegado cerrarSesionEvento;
        public FormMain(Banco b)
        {
            InitializeComponent();
            this.banco = b;
            nombreUsuario.Text = banco.mostrarUsuario(); //Se muestra el nombre del usuario en la vista

            this.refreshDataCaja();
            this.refreshDataPF();
            this.refreshDataPagos();
            this.refreshDataTarjetas();
            foreach (CajaDeAhorro caja in banco.obtenerCajaDeAhorro())
            {
                this.comboBoxTraerCajasATarjetas.Items.Add(caja.cbu);
                this.comboBoxCajaPago.Items.Add(caja.cbu);
            }
            foreach(Tarjeta tarjeta in banco.obtenerTarjetas())
            {
                this.comboBoxTarjetaPago.Items.Add(tarjeta.numero);
            }
            
            
        }
        public delegate void cerrarSesionDelegado();

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
            foreach (Pago pago in banco.obtenerPagos())
            {
                if(pago.pagado)
                {
                    dataGridViewPagos.Rows.Add( pago.id, pago.nombre, pago.monto, " - " );
                }
                else
                {
                    dataGridViewPagos.Rows.Add( pago.id, pago.nombre, " - ", pago.monto);
                }
            }

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
            banco.crearCajaDeAhorro(); // Las cajas de ahorro se crean con el saldo en 0
            this.refreshDataCaja();
        }
        private void btnNewPf_Click(object sender, EventArgs e)
        {
            //Metodo para crear plazo fijo que todavia no está definido :)
            this.refreshDataPF();
        }

        private void btnNewTarjeta_Click(object sender, EventArgs e)
        {
            banco.altaTarjeta(); // Las tarjetas se crean con un monto de 20 mil 
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
            comboBox1.Visible = false;
            label2.Visible = false;

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
            comboBox1.Show();
            label2.Show();

        }
        private void dataGridViewCaja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            esconderBtns();
            mostrarBtns();
            if(!Int32.TryParse(dataGridViewCaja.Rows[e.RowIndex].Cells[1].Value.ToString(), out cbuSeleccionado))
            {
                MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                
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
            if(Int32.TryParse(Interaction.InputBox("ingrese Dni del nuevo titular: ", "Agregando Titular"), out nuevodni))
            {
                if (banco.agregarUsuarioACaja(banco.BuscarCajaDeAhorro(cbuSeleccionado), nuevodni))
                {
                    MessageBox.Show("Se agrego el nuevo Titular", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDataCaja();
                }
            }
            else
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarTitular_Click(object sender, EventArgs e)
        {
            int nuevodni;
            if(Int32.TryParse(Interaction.InputBox("ingrese Dni del titular a eliminar: ", "Eliminar Titular"), out nuevodni))
            {
                if (banco.eliminarUsuarioDeCaja(banco.BuscarCajaDeAhorro(cbuSeleccionado), nuevodni))
                {
                    MessageBox.Show("Se removió titular con dni nro " + nuevodni, "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDataCaja();
                }
            }
            else
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                banco.depositar(banco.BuscarCajaDeAhorro(cbuSeleccionado), deposito);
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
                if (banco.retirar(banco.BuscarCajaDeAhorro(cbuSeleccionado), retiro))
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
                if (monto > banco.BuscarCajaDeAhorro(cbuSeleccionado).saldo)
                {
                    MessageBox.Show("El monto que desea transferir supera el saldo de la cuenta", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Int32.TryParse(Interaction.InputBox("Ingrese el CBU de la cuenta destino : ", "ingresar CBU"), out cbu))
                {
                    MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    if (banco.transferir(banco.BuscarCajaDeAhorro(cbuSeleccionado), cbu, monto))
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string seleccion = comboBox1.Items[index].ToString();
            if (index == 0)
            {
                dateTimePicker1.Visible = false;
                string movimientos = "";
                foreach (Movimiento movimiento in banco.obtenerMovimientos(cbuSeleccionado))
                {
                    movimientos = movimientos + movimiento.ToString() + "\n";
                }
                MessageBox.Show(movimientos, "Movimientos", MessageBoxButtons.OK);

            }
            else if (index == 1)
            {
                dateTimePicker1.Visible = true;
            }
            else if (index == 2)
            {
                dateTimePicker1.Visible = false;
                float monto;
                float.TryParse(Interaction.InputBox("ingrese monto del movimiento: ", "Monto Movimiento"), out monto);
                string movimientos = "";
                foreach (Movimiento movimiento in banco.buscarMovimiento(banco.BuscarCajaDeAhorro(cbuSeleccionado), monto))

                {
                    movimientos = movimientos + movimiento.ToString() + "\n";
                }
                if (monto <= 0)
                {
                    MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(movimientos, "Movimientos por monto", MessageBoxButtons.OK);
                }

            }
            else
            {
                dateTimePicker1.Visible = false;
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaElegida = dateTimePicker1.Value;
            string movimientos = "";
            foreach (Movimiento movimiento in banco.buscarMovimiento(banco.BuscarCajaDeAhorro(cbuSeleccionado), fechaElegida))

            {
                movimientos = movimientos + movimiento.ToString() + "\n";
            }
            MessageBox.Show(movimientos, "Movimientos por fecha", MessageBoxButtons.OK);
            dateTimePicker1.Visible = false;

        }
        //TARJETAS ------------------------

        private void dataGridViewTarjetas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!Int32.TryParse(dataGridViewTarjetas.Rows[e.RowIndex].Cells[2].Value.ToString(), out numeroTarjetaSeleccionado))
            {
                MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btnDarDeBajaTarjeta.Show();
                btnPagarTarjeta.Show();
            }
        }

        private void btnDarDeBajaTarjeta_Click(object sender, EventArgs e)
        {
            if (banco.bajaTarjeta(numeroTarjetaSeleccionado))
            {
                MessageBox.Show("Se ha dado de baja la tarjeta", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //
        //PAGOS
        //
        private void btnNewPago_Click(object sender, EventArgs e)
        {
            float monto;
            string nombre = Interaction.InputBox("Ingresar nombre del pago", "Ingresar nombre del pago");
            if(nombre == "" || nombre == null)
            {
                MessageBox.Show("Error en el ingreso de datos", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!float.TryParse(Interaction.InputBox("Ingresar el monto del pago", "Ingresar monto"), out monto))
            {
                MessageBox.Show("El monto ingresado no es válido", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                banco.nuevoPago(banco.buscarUsuarioLogeado(), nombre, monto); // hay que modificar esto para que al tocar el boton aparezcan opciones el algun lado del formulario para completar dinamicamente estos datos
                this.refreshDataPagos();
            }
        }
        private void dataGridViewPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Int32.TryParse(dataGridViewPagos.Rows[e.RowIndex].Cells[0].Value.ToString(), out idPago))
            {
                MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btnEliminarPago.Show();
                btnPagarPago.Show();
            }

        }
        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            if(banco.buscarPago(idPago).pagado)
            {
                banco.quitarPago(idPago);
                MessageBox.Show("Se ha eliminado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataPagos();
            }
            else
            {
                MessageBox.Show("El Pago necesita estar pagado😒", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPagarPago_Click(object sender, EventArgs e)
        {
            this.comboBoxCajaPago.Show();
            this.comboBoxTarjetaPago.Show();
        }

        private void comboBoxCajaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxCajaPago.SelectedIndex;
            string seleccion = comboBoxCajaPago.Items[index].ToString();

            int cbu;
            Int32.TryParse(seleccion, out cbu);

            if(banco.pagarPago(idPago, cbu))
            {
                MessageBox.Show("Se ha realizado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataPagos();
                refreshDataCaja();
            }
        }

        private void comboBoxTarjetaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxTarjetaPago.SelectedIndex;
            string seleccion = comboBoxTarjetaPago.Items[index].ToString();

            int numero;
            Int32.TryParse(seleccion, out numero);

            if (banco.pagarPago(idPago, numero))
            {
                MessageBox.Show("Se ha realizado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataPagos();
                refreshDataCaja();
                refreshDataTarjetas();
            }
        }
        public void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            dataGridViewCaja.Rows.Clear();
            dataGridViewPagos.Rows.Clear();
            dataGridViewTarjetas.Rows.Clear();
            dataGridViewPF.Rows.Clear();
            this.cerrarSesionEvento();
            
        }

    }
}






