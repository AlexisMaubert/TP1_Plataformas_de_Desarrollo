using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
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
        private int idCaja;
        private int idTarjeta;
        private int idPago;
        private int idPF;
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
        }

        public delegate void cerrarSesionDelegado();
        //
        //
        //CERRAR SESION
        //
        //
        public void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            dataGridViewCaja.Rows.Clear();
            dataGridViewPagos.Rows.Clear();
            dataGridViewTarjetas.Rows.Clear();
            dataGridViewPF.Rows.Clear();
            this.cerrarSesionEvento();
        }
        //
        //
        //ESCONDER Y MOSTRAR BOTONES
        //
        //
        public void esconderBtns()
        {
            btnBajaCaja.Visible = false;
            btnAgregarTitular.Visible = false;
            btnEliminarTitular.Visible = false;
            btnDepositar.Visible = false;
            btnRetirar.Visible = false;
            btnTransferir.Visible = false;
            btnDetalles.Visible = false;
            comboBox1.Visible = false;
            label2.Visible = false;
            btnEliminarPF.Visible = false;
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
            comboBox1.Show();
            label2.Show();
            btnEliminarPF.Show();
        }
        //
        //
        //MOSTRAR DATOS COMBO-BOX Y DATAGRIDVIEW
        //
        //

        //LISTAS DATA
        private void refreshListas()
        {
            this.comboBoxTraerCajasATarjetas.Items.Clear();
            this.comboBoxCajaPago.Items.Clear();
            this.comboBoxTarjetaPago.Items.Clear();
            this.comboBoxPFCBU.Items.Clear();
            foreach (CajaDeAhorro caja in banco.obtenerCajaDeAhorro())
            {
                this.comboBoxTraerCajasATarjetas.Items.Add(caja.cbu);
                this.comboBoxCajaPago.Items.Add(caja.cbu);
                this.comboBoxPFCBU.Items.Add(caja.cbu);
            }
            foreach (Tarjeta tarjeta in banco.obtenerTarjetas())
            {
                this.comboBoxTarjetaPago.Items.Add(tarjeta.numero);
            }
        }
        //CAJA DATA
        private void refreshDataCaja()
        {
            dataGridViewCaja.Rows.Clear();
            foreach (CajaDeAhorro caja in banco.obtenerCajaDeAhorro())
            {
                string nombres = "";
                foreach (Usuario titular in caja.titulares)
                {
                    nombres = nombres + titular.nombre + " " + titular.apellido + " / ";
                }
                dataGridViewCaja.Rows.Add(caja.id, caja.cbu, nombres, caja.saldo);
            }
            this.refreshListas();
        }
        //PLAZO FIJO DATA
        private void refreshDataPF()
        {
            dataGridViewPF.Rows.Clear();
            foreach (PlazoFijo pf in banco.obtenerPlzFijo())
            {
                string pagado = (pf.pagado) ? "Sí" : "No";
                dataGridViewPF.Rows.Add(pf.id, pf.titular.apellido + " " + pf.titular.nombre, pf.monto, pf.fechaIni, pf.fechaFin, pf.tasa, pagado);
            }
        }
        //PAGOS DATA
        private void refreshDataPagos()
        {
            dataGridViewPagos.Rows.Clear();
            foreach (Pago pago in banco.obtenerPagos())
            {
                if (pago.pagado)
                {
                    dataGridViewPagos.Rows.Add(pago.id, pago.nombre, pago.monto, " - ");
                }
                else
                {
                    dataGridViewPagos.Rows.Add(pago.id, pago.nombre, " - ", pago.monto);
                }
            }
            this.refreshListas();
        }
        //DATA TARJETAS
        private void refreshDataTarjetas()
        {
            dataGridViewTarjetas.Rows.Clear();
            foreach (Tarjeta tarjeta in banco.obtenerTarjetas())
            {
                dataGridViewTarjetas.Rows.Add(tarjeta.id, tarjeta.titular.apellido + " " + tarjeta.titular.nombre, tarjeta.numero, tarjeta.codigoV, tarjeta.limite, tarjeta.consumo);
            }
            this.refreshListas();
        }
        // 
        //
        //PESTAÑA CAJA DE AHORRO
        //
        //
        private void btnNewCaja_Click(object sender, EventArgs e)
        {
            int result = banco.crearCajaDeAhorro();
            if(result == 1)
            {
                MessageBox.Show("No se pudo crear la caja", "Error de creacion de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 2)
            {
                MessageBox.Show("No se pudo asignar la caja al usuario", "Error de asignacion de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.refreshDataCaja();
        }
        //DATA GRID VIEW
        private void dataGridViewCaja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!Int32.TryParse(dataGridViewCaja.Rows[e.RowIndex].Cells[0].Value.ToString(), out idCaja))
                {
                    MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mostrarBtns();
                }
            }
            else
            {
                esconderBtns();
            }
        }
        //BAJA DE CAJA
        private void btnBajaCaja_Click(object sender, EventArgs e)
        {
            int result = banco.bajaCaja(idCaja);
            if (result == 0)
            {
                MessageBox.Show("Borraste Exitosamente la caja", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                esconderBtns();
                refreshDataCaja();
            }
            if (result == 1)
            {
                MessageBox.Show("No se encontró la caja de ahorro que se desea eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 2)
            {
                MessageBox.Show("Esta caja de ahorro tiene saldo", "Error de eliminacion de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 3)
            {
                MessageBox.Show("No se pudo eliminar la caja (Nivel: DB)", "Error de eliminacion de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 4)
            {
                MessageBox.Show("Ha ocurrido un error al intentar eliminar la caja", "Error de eliminacion de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //AGREGAR TITULAR
        private void btnAgregarTitular_Click(object sender, EventArgs e)
        {
            int nuevodni;
            if (Int32.TryParse(Interaction.InputBox("ingrese Dni del nuevo titular: ", "Agregando Titular"), out nuevodni))
            {
                int result = banco.agregarUsuarioACaja(idCaja, nuevodni);
                if (result == 0)
                {
                    MessageBox.Show("Se agrego el nuevo Titular", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(result == 1)
                {
                    MessageBox.Show("No se encontró un usuario con dni nro " + nuevodni, "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 2)
                {
                    MessageBox.Show("No se encontró la caja de ahorro deseada", "Caja de ahorro no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 3)
                {
                    MessageBox.Show("El usuario ya es el titular de esta caja (Nivel: DB)", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 4)
                {
                    MessageBox.Show("No se pudo agregar la relacion en la base de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 5)
                {
                    MessageBox.Show("El usuario ya es el titular de esta caja (Nivel: APP)", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 6)
                {
                    MessageBox.Show("Ha ocurrido un error al intentar agregar un titular a la caja de ahorro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else   
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshDataCaja();
        }
        //ELIMINAR TITULAR
        private void btnEliminarTitular_Click(object sender, EventArgs e)
        {
            int nuevodni;
            if (Int32.TryParse(Interaction.InputBox("ingrese Dni del titular a eliminar: ", "Eliminar Titular"), out nuevodni))
            {
                int result = banco.eliminarUsuarioDeCaja(idCaja, nuevodni);
                if (result == 0)
                {
                    MessageBox.Show("Se removió titular con dni nro " + nuevodni, "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(result == 1)
                {
                    MessageBox.Show("No se encontró un usuario con dni nro " + nuevodni, "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 2)
                {
                    MessageBox.Show("No se encontró la caja de ahorro", "Caja de ahorro no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 3)
                {
                    MessageBox.Show("No se ha podido eliminar el usuario de la caja (Nivel: APP)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result ==4 )
                {
                    MessageBox.Show("No se ha podido eliminar el usuario de la caja (Nivel: DB)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 5)
                {
                    MessageBox.Show("Ha ocurrido un error al intentar eliminar un titular a la caja de ahorro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshDataCaja();
        }
        //DEPOSITAR
        private void btnDepositar_Click(object sender, EventArgs e)
        {
            int deposito;
            if (!Int32.TryParse(Interaction.InputBox("Monto a depositar : ", "ingresar monto"), out deposito) || deposito <= 0)
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (banco.depositar(idCaja, deposito))
                {
                    MessageBox.Show("Se depositó el monto con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDataCaja();
                }
            }
        }
        //RETIRAR
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            int retiro;
            if (!Int32.TryParse(Interaction.InputBox("Monto a retirar : ", "ingresar monto"), out retiro) || retiro <= 0)
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (banco.retirar(idCaja, retiro))
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
        //TRANSFERIR
        private void btnTransferir_Click(object sender, EventArgs e)
        {
            int monto;
            int cbu;
            int result;
            if (!Int32.TryParse(Interaction.InputBox("Monto a transferir : ", "ingresar monto"), out monto) || monto <= 0)
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!Int32.TryParse(Interaction.InputBox("Ingrese el CBU de la cuenta destino : ", "ingresar CBU"), out cbu))
                {
                    MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (banco.transferir(idCaja, cbu, monto))
                    {
                        MessageBox.Show("Se tranfirió el monto con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshDataCaja();
                    }
                }
            }
        }
        //DETALLES
        private void btnDetalles_Click(object sender, EventArgs e)
        {
            string movimientos = "";
            foreach (Movimiento movimiento in banco.obtenerMovimientos(idCaja))
            {
                movimientos = movimientos + movimiento.ToString() + "\n";
            }
            MessageBox.Show(movimientos, "Movimientos", MessageBoxButtons.OK);
        }
        //ELEGIR COMO FILTRAR LOS DETALLES
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string seleccion = comboBox1.Items[index].ToString();
            if (index == 0)
            {
                dateTimePicker1.Visible = false;
                string movimientos = "";
                foreach (Movimiento movimiento in banco.obtenerMovimientos(idCaja))
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
                foreach (Movimiento movimiento in banco.buscarMovimiento(banco.BuscarCajaDeAhorro(idCaja), monto))
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
        //ELEGIR FECHA
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaElegida = dateTimePicker1.Value;
            string movimientos = "";
            foreach (Movimiento movimiento in banco.buscarMovimiento(banco.BuscarCajaDeAhorro(idCaja), fechaElegida))
            {
                movimientos = movimientos + movimiento.ToString() + "\n";
            }
            MessageBox.Show(movimientos, "Movimientos por fecha", MessageBoxButtons.OK);
            dateTimePicker1.Visible = false;
        }
        //
        //
        //PESTAÑA PLAZO FIJO
        //
        //
        private void btnNewPf_Click(object sender, EventArgs e)
        {
            comboBoxPFCBU.Visible = true;
        }
        //DATA GRID VIEW
        private void dataGridViewPF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!Int32.TryParse(dataGridViewPF.Rows[e.RowIndex].Cells[0].Value.ToString(), out idPF))
                {
                    MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    esconderBtns();
                    mostrarBtns();
                }
            }
            else
            {
                esconderBtns();
            }
        }
        //ELIMINAR PLAZO FIJO
        private void btnEliminarPF_Click(object sender, EventArgs e)
        {
            int result = banco.eliminarPlazoFijo(idPF);
            if(result == 0)
            {
                MessageBox.Show("Se eliminó el plazo fijo con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (result == 1)
            {
                MessageBox.Show("No se encontró el plazo fijo que se desea eliminar", "Plazo fijo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 2)
            {
                MessageBox.Show("El plazo fijo todavía no esta pago", "Plazo fijo no se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 3)
            {
                MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshDataPF();
        }
        //LISTA CBU
        private void comboBoxPFCBU_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxPFCBU.SelectedIndex;
            string seleccion = comboBoxPFCBU.Items[index].ToString();
            int cbu;
            Int32.TryParse(seleccion, out cbu);
            CajaDeAhorro caja = banco.BuscarCajaDeAhorroPorCbu(cbu);
            int monto;
            if (!Int32.TryParse(Interaction.InputBox("ingrese el monto para crear el PF", "Monto Plazo fijo"), out monto) && monto >= 0)
            {
                MessageBox.Show("Ingrese un monto válido", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int result = banco.crearPlazoFijo(caja.id, monto);
                if (result == 0)
                {
                    MessageBox.Show("Plazo Fijo creado con exito.", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (result == 1)
                {
                    MessageBox.Show("El monto del plazo fijo debe ser mayor o igual a 1000", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == 2)
                {
                    MessageBox.Show("No se encontró la caja de ahorro", "Caja de ahorro no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == 3)
                {
                    MessageBox.Show("La cuenta no posee los fondos suficientes.", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == 4)
                {
                    MessageBox.Show("No se pudo aregar el plazo fijo a la base de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == 5)
                {
                    MessageBox.Show("Ha ocurrido un error al intentar crear el plazo fijo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refreshDataPF();
            }
            comboBoxPFCBU.Visible = false;
            refreshDataPF();
        }
        //
        //
        //PESTAÑA PAGOS
        //
        //
        private void btnNewPago_Click(object sender, EventArgs e)
        {
            string nombre = Interaction.InputBox("Ingresar nombre del pago", "Ingresar nombre del pago");
            if (nombre == "" || nombre == null)
            {
                MessageBox.Show("Error en el ingreso de datos", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!float.TryParse(Interaction.InputBox("Ingresar el monto del pago", "Ingresar monto"), out float monto))
            {
                MessageBox.Show("El monto ingresado no es válido", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int result = banco.nuevoPago(nombre, monto);
                if (result == 0)
                {
                    MessageBox.Show("Pago creado con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (result == 1)
                {
                    MessageBox.Show("Error en el ingreso a la base de datos", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == 2)
                {
                    MessageBox.Show("Error al intentar crear el pago", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.refreshDataPagos();
            }
        }
        //DATA GRID VIEW
        private void dataGridViewPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
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
            else
            {
                esconderBtns();
            }
        }
        //ELIMINAR PAGO
        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            int result = banco.quitarPago(idPago);
            if (result == 0)
            {
                banco.quitarPago(idPago);
                MessageBox.Show("Se ha eliminado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataPagos();
            }
            if(result == 1)
            {
                MessageBox.Show("No se encontró el pago que desea eliminar", "Error al buscar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(result == 2)
            {
                MessageBox.Show("El Pago necesita estar pagado😒", "Error al intentar eliminar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 2)
            {
                MessageBox.Show("Ha ocurrido un error al intentar eliminar el pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //PAGAR PAGO
        private void btnPagarPago_Click(object sender, EventArgs e)
        {
            this.comboBoxCajaPago.Show();
            this.comboBoxTarjetaPago.Show();
        }
        // LISTA DE CBU
        private void comboBoxCajaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxCajaPago.SelectedIndex;
            string seleccion = comboBoxCajaPago.Items[index].ToString();
            int cbu;
            Int32.TryParse(seleccion, out cbu);
            int result = banco.pagarPago(idPago, cbu);
            if (result == 0)
            {
                MessageBox.Show("Se ha realizado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataPagos();
                refreshDataCaja();
            }
            if(result == 1)
            {
                MessageBox.Show("No se encontró el pago que desea pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 2)
            {
                MessageBox.Show("El pago selecionado ya ha sido realizado", "Pago ya realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 3)
            {
                MessageBox.Show("El saldo disponible no es suficiente para realizar el pago", "Pago no realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 4)
            {
                MessageBox.Show("No se encontró el método de pago con el que desea pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LISTA DE TARJETAS
        private void comboBoxTarjetaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxTarjetaPago.SelectedIndex;
            string seleccion = comboBoxTarjetaPago.Items[index].ToString();
            int numero;
            Int32.TryParse(seleccion, out numero);
            int result = banco.pagarPago(idPago, numero);
            if (result == 0)
            {
                MessageBox.Show("Se ha realizado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataPagos();
                refreshDataCaja();
                refreshDataTarjetas();
            }
            if (result == 1)
            {
                MessageBox.Show("No se encontró el pago que desea pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 2)
            {
                MessageBox.Show("El pago selecionado ya ha sido realizado", "Pago ya realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 3)
            {
                MessageBox.Show("El saldo disponible no es suficiente para realizar el pago", "Pago no realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 4)
            {
                MessageBox.Show("No se encontró el método de pago con el que desea pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //
        //PESTAÑA TARJETAS
        //
        //
        private void btnNewTarjeta_Click(object sender, EventArgs e)
        {
            if (banco.altaTarjeta())
            {
                MessageBox.Show("Se ha creado exitosamente la tarjeta de crédito", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.refreshDataTarjetas();
        }
        //DATA GRID VIEW
        private void dataGridViewTarjetas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!Int32.TryParse(dataGridViewTarjetas.Rows[e.RowIndex].Cells[0].Value.ToString(), out idTarjeta))
                {
                    MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnDarDeBajaTarjeta.Show();
                    btnPagarTarjeta.Show();
                }
            }
            else
            {
                esconderBtns();
            }
        }
        //BAJA TARJETA
        private void btnDarDeBajaTarjeta_Click(object sender, EventArgs e)
        {
            int result = banco.bajaTarjeta(idTarjeta);
            if (result == 0)
            {
                MessageBox.Show("Se ha dado de baja la tarjeta", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                esconderBtns();
            }
            if (result == 1)
            {
                MessageBox.Show("No se encontró la tarjeta deseada", "Tarjeta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 2)
            {
                MessageBox.Show("La tarjeta seleccionada todavía posee consumos sin pagar ", "No se pudo eliminar la tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (result == 3)
            {
                MessageBox.Show("Ha ocurrido un error al intentar eliminar la tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            refreshDataTarjetas();
        }
        //PAGAR TARJETA
        private void btnPagarTarjeta_Click(object sender, EventArgs e)
        {
            comboBoxTraerCajasATarjetas.Show();
        }
        //LISTA DE CBU
        private void comboBoxTraerCajasATarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxTraerCajasATarjetas.SelectedIndex;
            string seleccion = comboBoxTraerCajasATarjetas.Items[index].ToString();

            Int32.TryParse(seleccion, out int  cbu);

            int result = banco.pagarTarjeta(idTarjeta, cbu);
            if (result == 0)
            {
                MessageBox.Show("Se ha realizado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataPagos();
                refreshDataCaja();
                refreshDataTarjetas();
            }
            if(result == 1)
            {
                MessageBox.Show("No se ha encontrado la tarjeta de crédito seleccionada", "Tarjeta de crédito no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 2)
            {
                MessageBox.Show("No se ha encontrado la caja de ahorro", "Caja de ahorro no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == 3)
            {
                MessageBox.Show("El saldo de la caja de ahorro es insuficiente para realizar este pago", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}






