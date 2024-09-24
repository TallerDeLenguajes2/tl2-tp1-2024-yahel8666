namespace cadeteria;
public class Navegacion {
    public static void Continuar()
    {
        Console.WriteLine("Presione una tecla para volver al menu");
        Console.ReadKey();
    }

    public static int preguntarRepeticion()
    {
        int opcionIterar;
        Console.WriteLine("¿Quiere asignar otro pedido? \n 1) Sí \n 2) No");
        opcionIterar = Menu.LeerYValidarOpcion(2);
        return opcionIterar;
    }
}
