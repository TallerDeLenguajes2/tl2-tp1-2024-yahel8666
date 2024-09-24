using cadeteria;

string carpeta = @"Archivos\" ;
string rutaCadetes = carpeta + "datosCadetes.csv";
string rutaCadeteria = carpeta + "datosCadeteria.csv";

var manejoArchivos = new ManejoArchivos();

if (!manejoArchivos.Existe(rutaCadeteria) && !manejoArchivos.Existe(rutaCadetes))
{
    Console.WriteLine("No se encontraron los datos"); 
    return;
} else
{
    var pedido = new Pedido();
    var listaCadetes = manejoArchivos.obtenerCadetes(rutaCadetes);
    var cadeteria = manejoArchivos.CargarCadeteria(rutaCadeteria, listaCadetes);
    var listaPedidosPendientes = new List<Pedido>();

    int opcion;
    int nroPedido = 1;
    do
    {
        Menu.mostrarMenu(cadeteria.Nombre); //no me gusta 
        opcion = Menu.LeerYValidarOpcion(6);
        int opcionIterar;
        switch (opcion)
        {
            case 1:
                do
                {
                    Pedido nuevoPedido = pedido.NuevoPedido(nroPedido);
                    listaPedidosPendientes.Add(nuevoPedido);
                    nroPedido++;
                    opcionIterar = Navegacion.preguntarRepeticion();
                } while (opcionIterar == 1);
                Navegacion.Continuar(); 
                break;
            case 2:
                do
                {
                    cadeteria.asignarPedidoACadete(listaPedidosPendientes);
                    opcionIterar = Navegacion.preguntarRepeticion();
                } while (opcionIterar == 1);
                Navegacion.Continuar(); 
                break;
            case 3:
                do
                {
                    cadeteria.CambiarEstadoPedido(listaPedidosPendientes);
                    opcionIterar = Navegacion.preguntarRepeticion();
                } while (opcionIterar == 1);
                Navegacion.Continuar();
                break;
            case 4:
                do
                {
                    cadeteria.reasignarPedidos();
                    opcionIterar = Navegacion.preguntarRepeticion();
                } while (opcionIterar == 1);
                Navegacion.Continuar();
                break;
            case 5: 
                cadeteria.MostrarInforme(); 
                Navegacion.Continuar(); 
            break;
        }
    } while (opcion != 6);
}

