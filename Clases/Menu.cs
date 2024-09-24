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
        Console.WriteLine("6) Salir ");
    }

    public int LeerYValidarOpcion(int max)
    {
        int numero;
        Console.WriteLine($"Por favor, ingrese una opción entre 1 y {max}:");
        do
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out numero) && numero >= 1 && numero <= max)
            {
                return numero;
            }
            else
            {
                Console.WriteLine($"Opción no válida. Por favor ingrese un número del 1 al {max}.");
            }
        } while (true); //sigue en el bucle hasta que se ingrese una opción válida
    }
}
