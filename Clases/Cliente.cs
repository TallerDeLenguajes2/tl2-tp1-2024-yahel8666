namespace cadeteria; 

public class Cliente
{
    string nombre; 
    string telefono; 
    string direccion; 
    string referencia; 

    public Cliente()
    {

    }

    //aqui pido los datos correspondientes para despues pasarselos al constructor que devolverá el cliente ya cargado. 
    public Cliente CrearCliente()
    {
        Console.WriteLine("Ingrese el nombre del cliente");
        string nombre = Console.ReadLine(); 
        Console.WriteLine("Ingrese el telefono del cliente");
        string telefono = Console.ReadLine(); 
        Console.WriteLine("Ingrese la direccion del cliente"); 
        string direccion = Console.ReadLine();
        Console.WriteLine("Ingrese algunos datos de referencia de direccion del cliente"); 
        string referencia = Console.ReadLine();

        return new Cliente(nombre, telefono, direccion, referencia);  
         
    }

    //mi constructor con parametros, privado porque solo es llamado dentro del metodo CrearCliente: 
    private Cliente(string nombre, string telefono, string direccion, string referencia)
    {
        this.nombre = nombre; 
        this.telefono = telefono; 
        this.direccion = direccion; 
        this.referencia = referencia; 
    }
    
} 