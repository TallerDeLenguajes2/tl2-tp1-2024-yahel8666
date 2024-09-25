namespace cadeteria;

public class Cadeteria
{
    string nombre;
    string telefono;
    List<Cadete> listaDeCadetes;
    List<Pedido> pedidosPendientes;

    public Cadeteria() //Constructor sin parámetros necesario para la deserialización
    {
        pedidosPendientes = new List<Pedido>();
        listaDeCadetes = new List<Cadete>();
    }

    //a este constructor lo uso en el AccesoCSV
    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listaDeCadetes = new List<Cadete>();
        pedidosPendientes = new List<Pedido>();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaDeCadetes { get => listaDeCadetes; set => listaDeCadetes = value; }
    public List<Pedido> PedidosPendientes { get => pedidosPendientes; set => pedidosPendientes = value; }

    //______________________________________________________________________________________________//

    public void AsignarPedidoACadete()
    {
        Console.WriteLine("\n \t ASIGNAR PEDIDO A CADETE ");
        if (pedidosPendientes == null || pedidosPendientes.Count == 0)
        {
            Console.WriteLine("\n \t No hay pedidos pendientes para asignar\n");
            return;
        }
        mostrarListaPedidos();
        mostrarCadetes();

        int idPedido;
        Console.WriteLine("Ingrese el id del pedido:");
        while (!int.TryParse(Console.ReadLine(), out idPedido))
        {
            Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero válido para el id del pedido:");
        }

        int idCadete;
        Console.WriteLine("Ingrese el id del cadete:");
        while (!int.TryParse(Console.ReadLine(), out idCadete))
        {
            Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero válido para el id del cadete:");
        }

        Cadete cadeteSeleccionado = ListaDeCadetes.FirstOrDefault(c => c.Id == idCadete);
        Pedido pedidoSeleccionado = pedidosPendientes.FirstOrDefault(p => p.Nro == idPedido);
        if (cadeteSeleccionado != null && pedidoSeleccionado != null)
        {
            cadeteSeleccionado.asignarPedido(pedidoSeleccionado);
            Console.WriteLine($"El {pedidoSeleccionado.Nro} ha sido asignado a {cadeteSeleccionado.Nombre}.");
            pedidosPendientes.Remove(pedidoSeleccionado);
        }
        else
        {
            Console.WriteLine("No fue posible realizar la asignacion");
        }
    }

    public void CambiarEstadoPedido()
    {
        Console.WriteLine("\n \t\t CAMBIAR ESTADO DEL PEDIDO: \n");
        foreach (Cadete cadete in listaDeCadetes)
        {
            Console.WriteLine($"Pedidos del cadete: {cadete.Nombre}:");
            if (cadete.ListadoDePedidos == null || cadete.ListadoDePedidos.Count == 0)
            {
                Console.WriteLine("No tiene pedidos asignados todavía \n");
            }
            else
            {
                foreach (Pedido pedido in cadete.ListadoDePedidos)
                {
                    Console.WriteLine($"Pedido con id: {pedido.Nro}");
                }
                Console.WriteLine("\n");
            }
        }

        Console.WriteLine("Ingrese el id del pedido:");
        int idPedido = int.Parse(Console.ReadLine());

        var pedidoEncontrado = listaDeCadetes
            .SelectMany(c => c.ListadoDePedidos)  // Aplana la lista de pedidos de todos los cadetes
            .FirstOrDefault(p => p.Nro == idPedido);

        if (pedidoEncontrado != null)
        {
            pedidoEncontrado.CambiarEstado();
            Console.WriteLine($"El pedido con id {pedidoEncontrado.Nro} cambio de estado exitosamente");
        }
        else
        {
            Console.WriteLine("Pedido no encontrado.");
        }
    }
    public void ReasignarPedidos()
    {
        Console.WriteLine("\n \t\t --REASIGNAR PEDIDOS--\n");

        Console.WriteLine("Ingrese el ID del pedido:");
        int idPedido = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del cadete al que se le asignará el pedido:");
        int idCadeteNuevo = int.Parse(Console.ReadLine());

        Cadete cadeteNuevo = listaDeCadetes.FirstOrDefault(c => c.Id == idCadeteNuevo);
        if (cadeteNuevo == null)
        {
            Console.WriteLine("El cadete con ID {0} no fue encontrado.", idCadeteNuevo);
            return;
        }

        Pedido pedidoParaReasignar = null;
        Cadete cadeteActual = null;

        foreach (var cadete in listaDeCadetes)
        {
            // Buscar el pedido dentro de cada cadete
            pedidoParaReasignar = cadete.ListadoDePedidos.FirstOrDefault(p => p.Nro == idPedido);
            if (pedidoParaReasignar != null)
            {
                cadeteActual = cadete; //Guardo el cadete que tiene el pedido
                break; // Salir del bucle si se encuentra el pedido
            }
        }
        if (pedidoParaReasignar == null)
        {
            Console.WriteLine("El pedido con ID {0} no fue encontrado en ninguna lista de cadetes.", idPedido);
            return;
        } else 
        {
            cadeteActual.ListadoDePedidos.Remove(pedidoParaReasignar);
            cadeteNuevo.ListadoDePedidos.Add(pedidoParaReasignar);
            Console.WriteLine("Pedido {0} asignado a {1} con exito.", idPedido, cadeteNuevo.Nombre);
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
        int promedio = 0;
        for (int i = 0; i < cadetes.Count; i++)
        {
            promedio += cadetes[i].cantidadEnvios();
        }
        return promedio / cadetes.Count;
    }
    private float calcularMontoTotal(List<Cadete> cadetes)
    {
        float promedio = 0;
        for (int i = 0; i < cadetes.Count; i++)
        {
            promedio += cadetes[i].totalJornal();
        }
        return promedio / cadetes.Count;
    }

    private void mostrarListaPedidos()
    {
        Console.WriteLine("\n--Lista de pedidos pendientes-- \n");
        for (int i = 0; i < pedidosPendientes.Count; i++)
        {
            Console.WriteLine($"Pedido con id: {pedidosPendientes[i].Nro}");
        }
        Console.WriteLine("\n");
    }
    private void mostrarCadetes()
    {
        Console.WriteLine("--Lista de Cadetes-- \n");
        for (int i = 0; i < listaDeCadetes.Count; i++)
        {
            Console.WriteLine($"Cadete {listaDeCadetes[i].Nombre}, id: {listaDeCadetes[i].Id}");
        }
    }
}

