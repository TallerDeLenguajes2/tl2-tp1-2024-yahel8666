# Taller II - TP 1 
## 1. ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
La relación entre Pedido y Cliente es de composición, lo que implica que la existencia del Cliente está ligada al Pedido. Si se elimina un Pedido, el Cliente asociado también debe ser eliminado. 

La relación entre Cadete y Pedido es de agregación, lo que significa que los Cadetes pueden existir de manera independiente a los Pedidos. Si un Cadete es eliminado, los Pedidos no se ven afectados y pueden continuar existiendo por su cuenta.

## 2. ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
Metodos para la clase Cadetería: AgregarCadete (incorpora un empleado nuevo), EliminarCadete, verPedidosPendientes (muestra todos los pedidos que todavía no han sido asignados a ningun cadete) y AsignarPedido (asigna un pedido a un cadete)

Metodos para la clase Cadete: AceptarPedido, RechazarPedido. 



## 3. Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados. 

