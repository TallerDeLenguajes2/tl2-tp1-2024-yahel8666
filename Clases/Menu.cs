namespace cadeteria;

public class Menu
{
    public void mostrarMenu()
    {
        Console.WriteLine("\n \t --Menú de Gestión de Pedidos--");
        Console.WriteLine("1) Dar de alta pedidos");
        Console.WriteLine("2) Asignar pedidos a cadetes");
        Console.WriteLine("3) Cambiar estado del pedido");
        Console.WriteLine("4) Reasignar pedido a otro cadete");
        Console.WriteLine("5) Mostrar resumen del día");
        Console.WriteLine("6) Mostrar listado de cadetes");
        Console.WriteLine("7) Salir ");

    }

    public int LeerYValidarOpcion(int max )
    {
        bool valida = false;
        int numero; 
        Console.WriteLine("Por favor, ingrese una opcion: ");
        do
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out numero) && numero >= 1 && numero <= max)
            {
                valida=true; 
            }
            else
            {
                valida=false;
                Console.WriteLine($"Opción no válida. Por favor ingresa un número del 1 al {max}.");
            }
        } while (!valida);
        return numero;
    }
}
