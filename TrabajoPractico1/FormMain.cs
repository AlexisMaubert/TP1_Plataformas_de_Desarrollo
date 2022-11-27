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
        private int usuarioSeleccionado;
        private bool cambioMonto = false;
        private bool cambioFecha = false;
        private bool cambioDetalle = false;
        private DateTime fechaElegida;
        public cerrarSesionDelegado cerrarSesionEvento;

        public FormMain(Banco b)
        {
            InitializeComponent();
            this.banco = b;
            nombreUsuario.Text = banco.mostrarUsuario(); //Se muestra el nombre del usuario en la vista

            if (!banco.esAdmin())
            {
                tabControl1.TabPages.Remove(tabUsuario);
            }
            this.refreshDataCaja();
            this.refreshDataPF();
            this.refreshDataPagos();
            this.refreshDataTarjetas();
            this.refreshDataUsuarios();
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
            dataGridViewUsuarios.Rows.Clear();
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
            label2.Visible = false;
            btnEliminarPF.Visible = false;
            detalleTxt.Visible = false;
            montoText.Visible = false;
            dateTimePicker1.Visible = false;
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
            label2.Show();
            btnEliminarPF.Show();
            detalleTxt.Show();
            montoText.Show();
            dateTimePicker1.Show();
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
            List<CajaDeAhorro> lista;
            if (banco.esAdmin())
            {
                lista = banco.obtenerTodasLasCajasDeAhorro();
            }
            else
            {
                lista = banco.obtenerCajaDeAhorro();
            }
            foreach (CajaDeAhorro caja in lista)
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
            List<PlazoFijo> lista;
            if (banco.esAdmin())
            {
                lista = banco.obtenerTodosLosPlazosFijos();
            }
            else
            {
                lista = banco.obtenerPlzFijo();
            }
            foreach (PlazoFijo pf in lista)
            {
                dataGridViewPF.Rows.Add(pf.id, pf.titular.apellido + " " + pf.titular.nombre, pf.monto, pf.fechaIni, pf.fechaFin, pf.tasa, (pf.pagado) ? "Sí" : "No");
            }
            refreshListas();
        }
        //PAGOS DATA
        private void refreshDataPagos()
        {
            dataGridViewPagos.Rows.Clear();
            List<Pago> lista;
            if (banco.esAdmin())
            {
                lista = banco.obtenerTodosLosPagos();
            }
            else
            {
                lista = banco.obtenerPagos();
            }
            foreach (Pago pago in lista)
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
            List<Tarjeta> lista;
            if (banco.esAdmin())
            {
                lista = banco.obtenerTodasLasTarjetas();
            }
            else
            {
                lista = banco.obtenerTarjetas();
            }
            foreach (Tarjeta tarjeta in lista)
            {
                dataGridViewTarjetas.Rows.Add(tarjeta.id, tarjeta.titular.apellido + " " + tarjeta.titular.nombre, tarjeta.numero, tarjeta.codigoV, tarjeta.limite, tarjeta.consumo);
            }
            this.refreshListas();
        }
        //Usuarios
        private void refreshDataUsuarios()
        {
            dataGridViewUsuarios.Rows.Clear();
            foreach (Usuario usuario in banco.obtenerUsuarios())
            {
                dataGridViewUsuarios.Rows.Add(usuario.id, usuario.apellido + " " + usuario.nombre, usuario.dni, usuario.mail, (usuario.bloqueado) ? "Si" : "No", (usuario.isAdmin) ? "Si" : "No");
            }
        }
        // 
        //
        //PESTAÑA CAJA DE AHORRO
        //
        //
        private void btnNewCaja_Click(object sender, EventArgs e)
        {
            int index = banco.crearCajaDeAhorro();
            switch (index)
            {
                case 0:
                    MessageBox.Show("Creaste exitosamente la caja", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.refreshDataCaja();
                    break;
                case 1:
                    MessageBox.Show("No se pudo crear la caja", "Error de creacion de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("No se pudo asignar la caja al usuario", "Error de asignacion de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
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
            int index = banco.bajaCaja(idCaja);
            switch (index)
            {
                case 0:
                    MessageBox.Show("Borraste Exitosamente la caja", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    esconderBtns();
                    refreshDataCaja();
                    refreshDataPF();
                    break;
                case 1:
                    MessageBox.Show("No se encontró la caja de ahorro que se desea eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("Esta caja de ahorro tiene saldo", "Error de eliminacion de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("Ha ocurrido un error al intentar eliminar la caja", "Error de eliminacion de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        //AGREGAR TITULAR
        private void btnAgregarTitular_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(Interaction.InputBox("ingrese Dni del nuevo titular: ", "Agregando Titular"), out int nuevodni))
            {
                int index = banco.agregarUsuarioACaja(idCaja, nuevodni);
                switch (index)
                {
                    case 0:
                        MessageBox.Show("Se agrego el nuevo Titular", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        MessageBox.Show("No se encontró un usuario con dni nro " + nuevodni, "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2:
                        MessageBox.Show("No se encontró la caja de ahorro deseada", "Caja de ahorro no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 3:
                        MessageBox.Show("El usuario ya es el titular de esta caja", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 4:
                        MessageBox.Show("Ha ocurrido un error al intentar agregar un titular a la caja de ahorro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
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
            if (Int32.TryParse(Interaction.InputBox("ingrese Dni del titular a eliminar: ", "Eliminar Titular"), out int nuevodni))
            {
                int index = banco.eliminarUsuarioDeCaja(idCaja, nuevodni);
                switch (index)
                {
                    case 0:
                        MessageBox.Show("Se removió titular con dni nro " + nuevodni, "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        MessageBox.Show("No se encontró un usuario con dni nro " + nuevodni, "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2:
                        MessageBox.Show("No se encontró la caja de ahorro", "Caja de ahorro no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 3:
                        MessageBox.Show("No se ha podido eliminar el usuario de la caja ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 4:
                        MessageBox.Show("Ha ocurrido un error al intentar eliminar un titular a la caja de ahorro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
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
            if (!Int32.TryParse(Interaction.InputBox("Monto a depositar : ", "ingresar monto"), out int deposito) || deposito <= 0)
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int index = banco.depositar(idCaja, deposito);
                switch (index)
                {
                    case 0:
                        MessageBox.Show("Se depositó el monto con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        MessageBox.Show("No se encontró la caja de ahorro a la que desea depositar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                refreshDataCaja();
            }
        }
        //RETIRAR
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(Interaction.InputBox("Monto a retirar : ", "ingresar monto"), out int retiro) || retiro <= 0)
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int index = banco.retirar(idCaja, retiro);
                switch (index)
                {
                    case 0:
                        MessageBox.Show("Se retiró el monto con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        MessageBox.Show("No se encontró la caja de ahorro a la que desea depositar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2:
                        MessageBox.Show("El monto que desea retirar excede el saldo de la cuenta", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                refreshDataCaja();
            }
        }
        //TRANSFERIR
        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(Interaction.InputBox("Monto a transferir : ", "ingresar monto"), out int monto) || monto <= 0)
            {
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!Int32.TryParse(Interaction.InputBox("Ingrese el CBU de la cuenta destino : ", "ingresar CBU"), out int cbu))
                {
                    MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int index = banco.transferir(idCaja, cbu, monto);
                    switch (index)
                    {
                        case 0:
                            MessageBox.Show("Se tranfirió el monto con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 1:
                            MessageBox.Show("No se encontro la cuenta destino con el Nro de CBU " + cbu, "Cuenta inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 2:
                            MessageBox.Show("El monto que desea transferir supera el saldo de la cuenta", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 3:
                            MessageBox.Show("Error al intentar tranferir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    refreshDataCaja();
                }
            }
        }
        //DETALLES
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaElegida = dateTimePicker1.Value;
        }
        private void btnDetalles_Click(object sender, EventArgs e)
        {
            float.TryParse(montoText.Text, out float monto);
            string movs = "";
            if (cambioDetalle == true && cambioFecha == true && cambioMonto == true)
            {
                movs = "Movimientos por Fecha, Monto y Detalle\n";
                foreach (Movimiento movimiento in banco.buscarMovimiento(idCaja, fechaElegida, monto, detalleTxt.Text))
                {
                    movs = movs + movimiento.ToString() + "\n";
                }
            }
            else if (cambioDetalle == true && cambioFecha == false && cambioMonto == false)
            {
                movs = "Movimientos por Detalle\n";
                foreach (Movimiento movimiento in banco.buscarMovimiento(idCaja, detalleTxt.Text))
                {
                    movs = movs + movimiento.ToString() + "\n";
                }
            }
            else if (cambioFecha == true && cambioDetalle == false && cambioMonto == false)
            {
                movs = "Movimientos por Fecha\n";
                foreach (Movimiento movimiento in banco.buscarMovimiento(idCaja, fechaElegida))
                {
                    movs = movs + movimiento.ToString() + "\n";
                }
            }
            else if (cambioMonto == true && cambioDetalle == false && cambioFecha == false)
            {
                movs = "Movimientos por Monto \n";
                foreach (Movimiento movimiento in banco.buscarMovimiento(idCaja, monto))
                {
                    movs = movs + movimiento.ToString() + "\n";
                }
            }
            else if (cambioDetalle == true && cambioFecha == true && cambioMonto == false)
            {
                movs = "Movimientos por Fecha y Detalle\n";
                foreach (Movimiento movimiento in banco.buscarMovimiento(idCaja, detalleTxt.Text, fechaElegida))
                {
                    movs = movs + movimiento.ToString() + "\n";
                }
            }
            else if (cambioDetalle == true && cambioFecha == false && cambioMonto == true)
            {
                movs = "Movimientos por Detalle y Monto\n";
                foreach (Movimiento movimiento in banco.buscarMovimiento(idCaja, detalleTxt.Text, monto))
                {
                    movs = movs + movimiento.ToString() + "\n";
                }
            }
            else if (cambioDetalle == false && cambioFecha == true && cambioMonto == true)
            {
                movs = "Movimientos por Fecha y Monto\n";
                foreach (Movimiento movimiento in banco.buscarMovimiento(idCaja, fechaElegida, monto))
                {
                    movs = movs + movimiento.ToString() + "\n";
                }
            }
            else
            {
                movs = "Movimientos sin filtro 😀\n";
                foreach (Movimiento movimiento in banco.obtenerMovimientos(idCaja))
                {
                    movs = movs + movimiento.ToString() + "\n";
                }
            }
            MessageBox.Show(movs, "Movimientos", MessageBoxButtons.OK);
            movs = "";
            montoText.Text = "Monto";
            detalleTxt.Text = "Detalle";
            cambioMonto = false;
            cambioFecha = false;
            cambioDetalle = false;
        }

        private void montoText_TextChanged(object sender, EventArgs e)
        {
            cambioMonto = true;
        }

        private void detalleTxt_TextChanged(object sender, EventArgs e)
        {
            cambioDetalle = true;
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            cambioFecha = true;
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
            switch (result)
            {
                case 0:
                    MessageBox.Show("Se eliminó el plazo fijo con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    MessageBox.Show("No se encontró el plazo fijo que se desea eliminar", "Plazo fijo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("El plazo fijo todavía no esta pago", "Plazo fijo no se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("Operación Fallida", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            refreshDataPF();
            esconderBtns();
        }
        //LISTA CBU
        private void comboBoxPFCBU_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxPFCBU.SelectedIndex;
            string seleccion = comboBoxPFCBU.Items[index].ToString();
            Int32.TryParse(seleccion, out int cbu);
            if (!Int32.TryParse(Interaction.InputBox("ingrese el monto para crear el PF", "Monto Plazo fijo"), out int monto) && monto >= 0)
            {
                MessageBox.Show("Ingrese un monto válido", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                index = banco.crearPlazoFijo(cbu, monto);
                switch (index)
                {
                    case 0:
                        MessageBox.Show("Plazo Fijo creado con exito.", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        MessageBox.Show("El monto del plazo fijo debe ser mayor o igual a 1000", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2:
                        MessageBox.Show("No se encontró la caja de ahorro", "Caja de ahorro no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 3:
                        MessageBox.Show("La cuenta no posee los fondos suficientes.", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 4:
                        MessageBox.Show("Ha ocurrido un error al intentar crear el plazo fijo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            comboBoxPFCBU.Visible = false;
            refreshDataPF();
            refreshDataCaja();
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
                int index = banco.nuevoPago(nombre, monto);
                switch (index)
                {
                    case 0:
                        MessageBox.Show("Pago creado con éxito", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.refreshDataPagos();
                        break;
                    case 1:
                        MessageBox.Show("Error al intentar crear el pago", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
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
            int index = banco.quitarPago(idPago);
            switch (index)
            {
                case 0:
                    MessageBox.Show("Se ha eliminado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDataPagos();
                    break;
                case 1:
                    MessageBox.Show("No se encontró el pago que desea eliminar", "Error al buscar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("No se pudo borrar el pago de la base de datos", "Error al intentar eliminar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("El Pago necesita estar pagado😒", "Error al intentar eliminar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 4:
                    MessageBox.Show("Ha ocurrido un error al intentar eliminar el pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
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
            switch (result)
            {
                case 0:
                    MessageBox.Show("Se ha realizado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDataPagos();
                    refreshDataCaja();
                    break;
                case 1:
                    MessageBox.Show("No se encontró el pago que desea pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("El pago selecionado ya ha sido realizado", "Pago ya realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("El saldo disponible no es suficiente para realizar el pago", "Pago no realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 4:
                    MessageBox.Show("No se encontró el método de pago con el que desea pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        //LISTA DE TARJETAS
        private void comboBoxTarjetaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxTarjetaPago.SelectedIndex;
            string seleccion = comboBoxTarjetaPago.Items[index].ToString();
            Int32.TryParse(seleccion, out int numero);
            index = banco.pagarPago(idPago, numero);
            switch (index)
            {
                case 0:
                    MessageBox.Show("Se ha realizado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDataPagos();
                    refreshDataCaja();
                    refreshDataTarjetas();
                    break;
                case 1:
                    MessageBox.Show("No se encontró el pago que desea pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("El pago selecionado ya ha sido realizado", "Pago ya realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("El saldo disponible no es suficiente para realizar el pago", "Pago no realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 4:
                    MessageBox.Show("No se encontró el método de pago con el que desea pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
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
            switch (result)
            {
                case 0:
                    MessageBox.Show("Se ha dado de baja la tarjeta", "Operación exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    esconderBtns();
                    refreshDataTarjetas();
                    break;
                case 1:
                    MessageBox.Show("No se encontró la tarjeta deseada", "Tarjeta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("La tarjeta seleccionada todavía posee consumos sin pagar ", "No se pudo eliminar la tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show("Ha ocurrido un error al intentar eliminar la tarjeta (Nivel DB)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 4:
                    MessageBox.Show("Ha ocurrido un error al intentar eliminar la tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

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

            Int32.TryParse(seleccion, out int cbu);

            int result = banco.pagarTarjeta(idTarjeta, cbu);
            switch (result)
            {
                case 0:
                    MessageBox.Show("Se ha realizado el pago", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDataPagos();
                    refreshDataCaja();
                    refreshDataTarjetas();
                    break;
                case 1:
                    MessageBox.Show("No se ha encontrado la tarjeta de crédito seleccionada", "Tarjeta de crédito no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("No se ha encontrado la caja de ahorro", "Caja de ahorro no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("El saldo de la caja de ahorro es insuficiente para realizar este pago", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        //
        //
        //PESTAÑA USUARIOS
        //
        //
        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!Int32.TryParse(dataGridViewUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString(), out usuarioSeleccionado))
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
        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            int index = banco.desbloquearUsuario(usuarioSeleccionado);
            switch (index)
            {
                case 0:
                    MessageBox.Show("Se ha desbloqueado al usuario con éxito", "Operación exitosa 🤑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    MessageBox.Show("El usuario que desea desbloquear no se encontró", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("El usuario ya se encuentra desbloqueado", "El usuario esta desbloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("No se pudo guardar en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            refreshDataUsuarios();
        }
    }
}






