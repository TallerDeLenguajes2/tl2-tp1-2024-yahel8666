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

    public void asignarPedidoACadete( List<Pedido> pedidosPendientes)
    {
        Console.WriteLine("\n \t ASIGNAR PEDIDO A CADETE ");
        if (pedidosPendientes == null || pedidosPendientes.Count == 0)
        {
            Console.WriteLine("\n \t No hay pedidos pendientes para asignar\n");
            return;
        } 
       
        mostrarListaPedidos(pedidosPendientes);
        mostrarCadetes();
    
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
            for (int i = 0; i < listaDeCadetes.Count; i++)
            {
                if (listaDeCadetes[i].Id == idCadete)
                {
                    cadeteNuevo = listaDeCadetes[i];
                    break;
                }
            } 
            if (cadeteNuevo==null)
            {
                Console.WriteLine("No se pudo encontrar al cadete con ese id"); 
            } else
            {
                cadeteNuevo.asignarPedido(pedidoAsignar);
                Console.WriteLine($"Pedido asignado con exito al cadete: {cadeteNuevo.Nombre}");
                pedidosPendientes.Remove(pedidoAsignar); 
            }
        }
    }

    public void CambiarEstadoPedido( List<Pedido> pedidos)
    {
        if (pedidos == null || pedidos.Count == 0)
        {
            Console.WriteLine("\n \t No hay pedidos pendientes para asignar\n");
            return;
        } 
        Console.WriteLine("\n \t\t CAMBIAR ESTADO DEL PEDIDO: \n");
        mostrarListaPedidos(pedidos);
        Console.WriteLine("Ingrese el id del pedido:");
        int idPedido = int.Parse(Console.ReadLine());

        /*Como no sé que cadete tiene el pedido que necesito, debo recorrer todas
        las listas de todos los cadetes hasta encontrarlo :P, voy a buscar la manera
        de optimizarlo después */

        foreach (Cadete cadete in listaDeCadetes)
        {
            for (int i = 0; i < cadete.ListadoDePedidos.Count; i++)
            {
                if (cadete.ListadoDePedidos[i].Nro == idPedido)
                {
                    cadete.ListadoDePedidos[i].CambiarEstado();
                    Console.WriteLine("Estado cambiado con exito ;) ");
                    break;
                }
            }
        }
    }
    public void reasignarPedidos()
    {
        Console.WriteLine("\n \t\t --REASIGNAR PEDIDOS--\n");
        Console.WriteLine("Ingrese el ID del pedido:");
        int idPedido = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el ID del cadete al que se le asignará el pedido:");
        int idCadeteNuevo = int.Parse(Console.ReadLine());

        Pedido pedidoParaReasignar = null;
        /*Primero verifico que el cadete al le quiero asignar el pedido exista */
        Cadete cadeteNuevo = null;
        foreach (Cadete cadete in listaDeCadetes)
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
            return; 
        }
        else
        {
            //Si existe, buscamos el pedido
            foreach (Cadete cadete in listaDeCadetes)
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

    public void MostrarInforme()
    {
        Console.WriteLine("\n \t\t INFORME TOTAL \n");

        Console.WriteLine("\t --CANTIDAD ENVIOS Y MONTO DE CADA CADETE --\n");
        foreach (Cadete cadete in listaDeCadetes)
        {    
            Console.WriteLine($" \t Cadete id: {cadete.Id} | Cantidad envios: {cadete.cantidadEnvios()}");
            Console.WriteLine($" \t Cadete id: {cadete.Id} | Jornal: {cadete.totalJornal()} \n");
        }

        Console.WriteLine("\t --PROMEDIO DE ENVIOS --");
        Console.WriteLine($"\t {calcularPromedio(listaDeCadetes)}");

        Console.WriteLine("\t --MONTO TOTAL RECAUDADO --");
        Console.WriteLine($"\t {calcularMontoTotal(listaDeCadetes)}");
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

    private void mostrarListaPedidos(List<Pedido> pedidosPendientes)
    {
        Console.WriteLine("\t --Lista de pedidos-- \n");
        for (int i = 0; i < pedidosPendientes.Count; i++)
        {
            Console.WriteLine($"Pedido numero: {i}, id: {pedidosPendientes[i].Nro}");
        }
        Console.WriteLine("\n");
    }
    private void mostrarCadetes()
    {
        Console.WriteLine("\t --Lista de Cadetes-- \n");
        for (int i = 0; i < listaDeCadetes.Count; i++)
        {
            Console.WriteLine($"Cadete {listaDeCadetes[i].Nombre}, id: {listaDeCadetes[i].Id} \n");
        }
    }
}

