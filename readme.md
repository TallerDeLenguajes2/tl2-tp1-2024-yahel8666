# Taller II - TP 1 
## 1. ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
La relación entre Pedido y Cliente es de composición, lo que implica que la existencia del Cliente está ligada al Pedido. Si se elimina un Pedido, el Cliente asociado también debe ser eliminado. De manera similar, la relación entre Cadetería y Cadete es también de composición. Por otro lado, la relación entre Cadete y Pedido es de agregación, ya que los Cadetes pueden existir sin estar necesariamente vinculados a un Pedido, y si un Cadete es eliminado, los Pedidos pueden seguir existiendo.


## 2. ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
Metodos para la clase Cadetería: AgregarCadete (incorpora un empleado nuevo), EliminarCadete, verPedidosPendientes (muestra todos los pedidos que todavía no han sido asignados a ningun cadete) y AsignarPedido (asigna un pedido a un cadete)

Metodos para la clase Cadete: AceptarPedido, RechazarPedido. 

## 3. Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados. 

