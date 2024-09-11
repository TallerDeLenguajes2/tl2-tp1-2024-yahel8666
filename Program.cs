using cadeteria;

string rutaCadetes = @"Archivos\datosCadetes.csv";
string rutaCadeteria = @"Archivos\datosCadeteria.csv";

var menu = new Menu();
var manejoArchivos = new ManejoArchivos();
var pedido = new Pedido();
var cliente = new Cliente();

List<Cadete> listaCadetes = manejoArchivos.obtenerCadetes(rutaCadetes);
var cadeteria = manejoArchivos.CargarCadeteria(rutaCadeteria, listaCadetes);

cadeteria.presentacionCadeteria();
menu.mostrarMenu();
int opcion = menu.LeerYValidarOpcion(6);

int nroPedido = 1000;
List<Pedido> listaPedidosPendientes = new List<Pedido>();

switch (opcion)
{
    case 1:
        int cargarOtroPedido;
        do
        {
            Cliente nuevoCliente = cliente.CrearCliente();
            Pedido nuevoPedido = pedido.nuevoPedido(cliente, nroPedido);
            listaPedidosPendientes.Add(nuevoPedido);
            nroPedido++;
            Console.WriteLine("Quiere cargar otro pedido? \n 1) Si \n 2) No");
            cargarOtroPedido = menu.LeerYValidarOpcion(2); 
        } while (cargarOtroPedido==1);
    break;
    case 2: 
        cadeteria.asignarPedidoACadete(listaCadetes, listaPedidosPendientes);
    break; 
}














