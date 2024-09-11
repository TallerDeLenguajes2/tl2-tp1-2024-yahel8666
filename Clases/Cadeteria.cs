namespace cadeteria; 

public class Cadeteria
{
    string nombre; 
    string telefono; 
    public List<Cadete> listaDeCadetes;

    public Cadeteria(string nombre, string telefono, List<Cadete> listaDeCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listaDeCadetes = listaDeCadetes;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    //Es mas para ver si se cargaron bien los datos del archivo ;) 
    public void presentacionCadeteria ()
    {
        Console.WriteLine($"\t BIENVENIDOS A '{nombre}' \n");
    }

    public void asignarPedidoACadete(List<Cadete> cadetes, List<Pedido> pedidosPendientes)
    {
        mostrarCadetes(cadetes);
        Console.WriteLine("\n \t --ASIGNAR PEDIDO A CADETE--");
        Console.WriteLine("Ingrese el id del pedido:");
        int idPedido = int.Parse(Console.ReadLine()); 
        Console.WriteLine("Ingrese el id del cadete: "); 
        int idCadete = int.Parse(Console.ReadLine()); 

        /*Busco en la  lista de pedidos pendientes el pedido y lo guardo en una 
        variable (ya se que no es aconsejable, dejenme), despues busco al cadete 
        que quiero y le mando ese pedido que encontré*/ 
    
        Pedido pedidoAsignar = null; 
        for (int j = 0; j < pedidosPendientes.Count; j++)
        {
            if (pedidosPendientes[j].Nro==idPedido)
            {
                pedidoAsignar = pedidosPendientes[j]; 
                break; 
            }
        }

        for (int i = 0; i < cadetes.Count; i++)
        {
            if (cadetes[i].Id==idCadete)
            {
                cadetes[i].asignarPedido(pedidoAsignar); 
                break; 
            }
        }
        /*Ya se lo mandé al cadete, por lo tanto lo quito de pendientes
        pedidosPendientes.Remove(pedidoAsignar); */
    }

    public void CambiarEstadoPedido(List<Cadete> cadetes, List<Pedido> pedidos)
    {
        Console.WriteLine("\n \t --CAMBIAR ESTADO DEL PEDIDO--");
        mostrarIdPedidos(pedidos); 
        Console.WriteLine("Ingrese el id del pedido:");
        int idPedido = int.Parse(Console.ReadLine()); 

        /*Como no sé que cadete tiene el pedido que necesito, debo recorrer todas
        las listas de todos los cadetes hasta encontrarlo :P, voy a buscar la manera
        de optimizarlo después */
        foreach (Cadete cadete in cadetes)
        {       
            for (int i = 0; i < cadete.ListadoDePedidos.Count; i++)
            {
                if (cadete.ListadoDePedidos[i].Nro==idPedido)
                {
                    cadete.ListadoDePedidos[i].CambiarEstado();
                    break;
                }
            }
        }
    }

    private void mostrarCadetes(List<Cadete> cadetes)
    {
        
        Console.WriteLine("\n \t --ID DE LOS CADETES:-- ");
        foreach (Cadete cadete in cadetes)
        {
            Console.WriteLine($"{cadete.Nombre} ID: {cadete.Id}");
        }
    }

    public void mostrarIdPedidos(List<Pedido> pedidos)
    {
        Console.WriteLine("\n ID DE LOS PEDIDOS");
        foreach (Pedido pedido in pedidos)
        {
            Console.WriteLine($"Pedido de: {pedido.Cliente.Nombre}, ID: ");
        }
    }
}

