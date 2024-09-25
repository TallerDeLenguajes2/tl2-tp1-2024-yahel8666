using cadeteria;

string datosCadeteria;
string datosCadetes;
AccesoDatos manejoDatos = null;
Cadeteria cadeteria=null;
List<Cadete> listaCadetes = null;  

MenuArchivos.MostrarOpcionesAcceso();
int opcionArchivo = Menu.LeerYValidarOpcion(2);

switch (opcionArchivo)
{
    case 1:
        manejoDatos = new AccesoCSV();
        datosCadeteria = @"CSV/datosCadeteria.csv"; 
        datosCadetes = @"CSV/datosCadetes.csv";
        break; 
    case 2: 
        manejoDatos = new AccesoJSON(); 
        datosCadeteria = @"Json/datosCadeteria.json"; 
        datosCadetes = @"Json/datosCadetes.json";
    break;
    default:
        return; 
}

if (!manejoDatos.Existe(datosCadeteria) && !manejoDatos.Existe(datosCadetes))
{
    Console.WriteLine("No existen los datos en el sistema");
    return;
} 
else {
    listaCadetes = manejoDatos.ObtenerCadetes(datosCadetes);
    cadeteria = manejoDatos.LeerCadeteria(datosCadeteria); 
    cadeteria.ListaDeCadetes = listaCadetes;

    var pedido = new Pedido();
    int idPedido = 1;
    int opcion;
    do
    {
        Menu.mostrarMenu(cadeteria.Nombre); //no me gusta 
        opcion = Menu.LeerYValidarOpcion(6);
        switch (opcion)
        {
            case 1:
                var nuevoPedido = pedido.NuevoPedido(idPedido);
                cadeteria.PedidosPendientes.Add(nuevoPedido);
                idPedido++;
                Navegacion.Continuar();
            break;
            case 2: 
                cadeteria.AsignarPedidoACadete();
                Navegacion.Continuar();
            break;
            case 3: 
                cadeteria.CambiarEstadoPedido();
                Navegacion.Continuar();
            break;
            case 4: 
                cadeteria.ReasignarPedidos();
                Navegacion.Continuar();
            break;
            case 5: 
                cadeteria.MostrarInforme(); 
                Navegacion.Continuar(); 
            break;
        }
    } while(opcion!=6);
}
