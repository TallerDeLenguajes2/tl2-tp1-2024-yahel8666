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
}

