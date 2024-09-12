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
    public void presentacionCadeteria()
    {
        Console.Clear();
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
            if (pedidosPendientes[j].Nro == idPedido)
            {
                pedidoAsignar = pedidosPendientes[j];
                break;
            }
        } 
        if (pedidoAsignar==null)
        {
            Console.WriteLine("Pedido no encontrado");
            return; 
        } else
        {
            Cadete cadeteNuevo=null; 
            for (int i = 0; i < cadetes.Count; i++)
            {
                if (cadetes[i].Id == idCadete)
                {
                    cadeteNuevo = cadetes[i];
                    break;
                }
            } 
            if (cadeteNuevo==null)
            {
                Console.WriteLine("No se pudo encontrar al cadete con ese id"); 
            } else
            {
                cadeteNuevo.asignarPedido(pedidoAsignar);
                // Ya se lo mandé al cadete, por lo tanto lo quito de pendientes
                pedidosPendientes.Remove(pedidoAsignar); 
            }
        }
    }

    public void CambiarEstadoPedido(List<Cadete> cadetes, List<Pedido> pedidos)
    {
        Console.WriteLine("\n \t\t --CAMBIAR ESTADO DEL PEDIDO--\n");
        Console.WriteLine("Ingrese el id del pedido:");
        int idPedido = int.Parse(Console.ReadLine());

        /*Como no sé que cadete tiene el pedido que necesito, debo recorrer todas
        las listas de todos los cadetes hasta encontrarlo :P, voy a buscar la manera
        de optimizarlo después */

        foreach (Cadete cadete in cadetes)
        {
            for (int i = 0; i < cadete.ListadoDePedidos.Count; i++)
            {
                if (cadete.ListadoDePedidos[i].Nro == idPedido)
                {
                    cadete.ListadoDePedidos[i].CambiarEstado();

                    break;
                }
            }
        }
    }
    public void reasignarPedidos(List<Cadete> cadetes)
    {
        Console.WriteLine("\n \t\t --REASIGNAR PEDIDOS--\n");
        Console.WriteLine("Ingrese el ID del pedido:");
        int idPedido = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del cadete al que se le asignará el pedido:");
        int idCadeteNuevo = int.Parse(Console.ReadLine());

        Pedido pedidoParaReasignar = null;

        /*Primero verifico que el cadete al que le quiero asignar el pedido exista */
        Cadete cadeteNuevo = null;
        foreach (Cadete cadete in cadetes)
        {
            if (cadete.Id == idCadeteNuevo)
            {
                cadeteNuevo = cadete;
                break;
            }
        }
        if (cadeteNuevo == null)
        {
            Console.WriteLine("El cadete con ID {0} no fue encontrado.", idCadeteNuevo);
        }
        else
        {
            //Si existe, buscamos el pedido
            foreach (Cadete cadete in cadetes)
            {
                for (int i = 0; i < cadete.ListadoDePedidos.Count; i++)
                {
                    if (cadete.ListadoDePedidos[i].Nro == idPedido)
                    {
                        pedidoParaReasignar = cadete.ListadoDePedidos[i];
                        cadete.ListadoDePedidos.Remove(pedidoParaReasignar); //lo sacamos de la lista en donde está
                        cadeteNuevo.asignarPedido(pedidoParaReasignar);
                        Console.WriteLine("El pedido {0} ha sido reasignado al cadete {1}.", idPedido, cadeteNuevo.Id);
                        break;
                    }
                }
            }
            if (pedidoParaReasignar == null)
            {
                Console.WriteLine("El pedido con ID {0} no fue encontrado.", idPedido);
            }
        }
    }

    public void MostrarInforme(List <Cadete> cadetes)
    {
        Console.WriteLine("\n \t\t --INFORME TOTAL--\n");

        Console.WriteLine("\t --CANTIDAD ENVIOS Y MONTO DE CADA CADETE --\n");
        foreach (Cadete cadete in cadetes)
        {    
            Console.WriteLine($" \t Cadete id: {cadete.Id} | Cantidad envios: {cadete.cantidadEnvios()}");
            Console.WriteLine($" \t Cadete id: {cadete.Id} | Jornal: {cadete.totalJornal()} \n");
        }

        Console.WriteLine("\t --PROMEDIO DE ENVIOS --");
        Console.WriteLine($"\t {calcularPromedio(cadetes)}");

        Console.WriteLine("\t --MONTO TOTAL RECAUDADO --");
        Console.WriteLine($"\t {calcularMontoTotal(cadetes)}");
    }

    private int calcularPromedio(List<Cadete> cadetes)
    {
        int promedio=0;  
        for (int i = 0; i < cadetes.Count; i++)
        {
            promedio += cadetes[i].cantidadEnvios();
        }
        return promedio / cadetes.Count;
    }
    private float calcularMontoTotal(List<Cadete> cadetes)
    {
        float promedio=0;  
        for (int i = 0; i < cadetes.Count; i++)
        {
            promedio += cadetes[i].totalJornal();
        }
        return promedio / cadetes.Count;        
    }
}

