using cadeteria;

string rutaCadetes = @"Archivos\datosCadetes.csv";
string rutaCadeteria = @"Archivos\datosCadeteria.csv";

var menu = new Menu();
var manejoArchivos = new ManejoArchivos();
var pedido = new Pedido();
var cliente = new Cliente();

List<Cadete> listaCadetes = manejoArchivos.obtenerCadetes(rutaCadetes);
var cadeteria = manejoArchivos.CargarCadeteria(rutaCadeteria, listaCadetes);
List<Pedido> listaPedidosPendientes = new List<Pedido>();

cadeteria.presentacionCadeteria();
int opcion;
do
{
    menu.mostrarMenu();
    opcion = menu.LeerYValidarOpcion(7);
    int opcionIterar;
    switch (opcion)
    {
        case 1:
            int nroPedido = 1000;
            do
            {
                Cliente nuevoCliente = cliente.CrearCliente();
                Pedido nuevoPedido = pedido.nuevoPedido(cliente, nroPedido);
                listaPedidosPendientes.Add(nuevoPedido);
                nroPedido++;
                Console.WriteLine("¿Quiere cargar otro pedido? \n 1) Sí \n 2) No");
                opcionIterar = menu.LeerYValidarOpcion(2);
            } while (opcionIterar == 1);
            break;
        case 2:
            do
            {
                cadeteria.asignarPedidoACadete(listaCadetes, listaPedidosPendientes);
                mostrarListaCadetes();
                Console.WriteLine("¿Quiere asignar otro pedido? \n 1) Sí \n 2) No");
                opcionIterar = menu.LeerYValidarOpcion(2);
            } while (opcionIterar == 1);
            break;

        case 3:
            do
            {
                cadeteria.CambiarEstadoPedido(listaCadetes, listaPedidosPendientes);
                Console.WriteLine("¿Quiere cambiar el estado de otro pedido? \n 1) Sí \n 2) No");
                opcionIterar = menu.LeerYValidarOpcion(2);
            } while (opcionIterar == 1);
            break;
        case 4:
            do
            {
                cadeteria.reasignarPedidos(listaCadetes);
                Console.WriteLine("¿Quiere reasignar otro pedido? \n 1) Sí \n 2) No");
                opcionIterar = menu.LeerYValidarOpcion(2);
            } while (opcionIterar == 1);
            break;
        case 5: 
            cadeteria.MostrarInforme(listaCadetes); 
            break;
        case 6: 
        mostrarListaCadetes();
        break;
    }
} while (opcion != 7);

void mostrarListaCadetes()
{
    Console.WriteLine("\n \t\t --LISTADO DE CADETES--\n");
    foreach (Cadete cadete in listaCadetes)
    {
        Console.WriteLine($" \t ID: {cadete.Id} | NOMBRE: {cadete.Nombre} | PEDIDOS: ");
        if (cadete.ListadoDePedidos.Count > 0)
        {
            foreach (Pedido pedido in cadete.ListadoDePedidos)
            {
                Console.WriteLine($"\t\t \n Pedido ID: {pedido.Nro} | Estado: {pedido.Estado} | Cliente: {pedido.Cliente.Nombre} \n");
            }
        }
        else
        {
            Console.WriteLine("\t\t No tiene pedidos asignados.\n");
        }
    }
}

