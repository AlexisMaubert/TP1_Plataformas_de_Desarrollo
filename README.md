******************************************************
*************App Home Banking*************************	
******************************************************
Al iniciar la aplicación muestra la ventana de iniciar
sesión, se puede ingresar con un usuario creado 
en el constructor del programa con email 1 y contraseña
1. De así quererlo se puede hacer click en un texto enlace
en la parte inferior del formulario para acceder a la 
ventana de registro.
En registro aparecen los campos a llenar con los datos
del usuario nuevo y 2 botones, registrarse y cancelar.
Al hacer click en cancelar se regresa a la pantalla de
login automáticamente. Al contrario al tocar el botón
de registrarse el programa pide que se llenen todos los
campos, que el dni sea un número, que tenga al menos 
7 digitos y que el mismo no esté ya registrado en el 
sistema, que el mail ingresado tenga el formato de mail
(*texto*@*texto*.com).
En la página del login el sistema da aviso si el dni 
ingresado no pertenece a un usuario, si el usuario esta 
bloqueado o si se ingreso mal la contraseña y los 
intentos restantes para ingresarla correctamente.
Una vez iniciada la sesión, el programa consta de 4 
pestañas: Cajas de ahorro, Plazos fijos (ni implementada
en esta entrega), pagos y tarjetas.
En cajas de ahorro muestra una lista de las cajas de ahorro,
 un botón para agregar una nueva que se creará con saldo 
en 0 y el boton de cerrar sesion. Al seleccionar una caja 
de la lista se mostraran al costado de la pantalla los 
botones de las acciones que se pueden realizar:
Borrar caja: Elimina la caja de ahorro siempre y cuando
tenga el saldo en 0.
Agregar Titular: Se despliega una ventana emergente que pide
ingresar un DNI para identificar a un usuario y agregarlo
de la caja de ahorro. El usuario tiene que estar registrado 
en el sistema.
Eliminar Titular: Se despliega una ventana emergente que pide
ingresar un DNI para identificar a un usuario y eliminarlo
de la caja de ahorro. El usuario tiene que estar registrado 
en el sistema. Si la caja de ahorro tiene un solo titular,
este no se puede eliminar.
Depositar: Se despliega una ventana emergente que pide
ingresar la cantidad para depositar.
Retirar: Se despliega una ventana emergente que pide
ingresar la cantidad para retirar.
Transferir:Se despliega una ventana emergente que pide
ingresar la cantidad para transferir, y otra ventana que
pide un numero de cbu de la cuenta destino.
Movimientos: Se despliega una ventana emergente que muestra
todos los movimientos.
Filtrar por movimientos: Se despliega una lista para seleccionar
cual será el criterio para filtrar los movimientos.
Pestaña de pagos:
Muestra una lista de pagos y un boton para agregar un nuevo pago.
Al seleccionar el pago se muestran 2 botones uno para eliminar el
pago que lo elimina si el pago fue realizado y otro boton que es 
pagar, que al seleccionarlo muestra 2 listas con los numeros de
cbu de sus cuentas en una y los numeros de sus tarjetas en otra 
para elegir como abonar el pago.
Pestaña tarjetas:
Muestra una lista de tarjetas de credito junto con un boton para
agregar una nueva( las tarjetas nuevas se agregan con limite de 20000)
al seleccionar una tarjeta se muestran 2 botonos: Eliminar tarjeta,
que elimina la tarjeta si los consumos estan en 0 y pagar tarjeta
que despliega una lista de CBU para seleccionar con cual hacer 
el pago.
