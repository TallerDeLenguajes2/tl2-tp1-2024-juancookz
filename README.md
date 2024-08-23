## Cadeteria
 1)
 - La relación de Cadetes con Cadeteria seria por composición, ya que la existencia de los cadetes estaría englobada adentro de una cadeteria
 - La relacion de Pedidos con Cadete seria por asociacion, ya que queremos que en caso de que un cadete no pueda entregar un pedido, este pueda ser reasignado a otro.
 - La relación de Cliente con Pedido debe ser por composición, ya que no nos interesa guardar los datos del cliente, por lo tanto cuando este pedido se complete y se elimine, con el cliente debería suceder lo mismo.
 2)
 La clase **Cadeteria** debería tener los siguientes métodos:
 - *TomarPedido*(). Aquí se cargarían los datos del pedido, incluidos los del cliente, estos se guardarían en una lista de pedidos a asignar.
 - *AsignarPedido*(). Aqui podremos elegir un pedido de la lista de pedidos pendientes a asignacion y elegiremos un cadete el cual lo llevara a cabo.
 - *CambiarEstadoPedido*(). Este nos va a permitir a traves de una lista de pedidos en curso, modificar el estado del mismo.
 - *ReasignarPedido*(). A traves de la lista de pedidos en curso y si es que el pedido todavia no ha salido, nos permite reasignar el pedido a otro cadete.

 La clase **Cadete** deberia tener los siguientes metodos.
 
 - *JornalACobrar*(). A traves de ListadoPedidos y en base a los que esten marcados como completados, se haria el calculo de lo que cobraria por la jornada de trabajo.
 - RecibirPedido(). Este metodo nos permite acceder al propio ListadoPedidos y poder agregarlo a la lista.
 - EliminarPedido(). Este metodo nos permite, en caso de querer reasignar un pedido, eliminarlo de la lista del cadete para asi poder asignarselo a otro.
 3)
 Para **Cadeteria**
 - Nombre. **Publico**
 - Telefono. **Publico**
 - ListadoPedidosAsignar. **Privado**
 - ListadoPedidosEnCurso. **Privado**
 - ListadoCadetes. **Privado**
 - TomarPedido(). **Publico**
 - AsignarPedido(). **Publico**
 - CambiarEstadoPedido(). **Publico**
 - ReasignarPedido(). **Publico**

 Para **Cadete**
 - Id. **Publico**
 - Nombre. **Publico**
 - Direccion. **Publico**
 - Telefono. **Publico**
 - ListadoPedidos. **Privado**