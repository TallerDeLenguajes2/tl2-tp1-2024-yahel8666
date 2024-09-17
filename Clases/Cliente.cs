namespace cadeteria; 

public class Cliente
{
    string nombre; 
    string telefono; 
    string direccion; 
    string referencia;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Referencia { get => referencia; set => referencia = value; }

    public Cliente()
    {

    }

    //aqui pido los datos correspondientes para despues pasarselos al constructor que devolverá el cliente ya cargado. 
    public Cliente CrearCliente()
    {
        Console.WriteLine("\n \t\t --DAR DE ALTA UN PEDIDO--\n");
        Console.WriteLine("\t\t NUEVO CLIENTE");
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
        this.Nombre = nombre; 
        this.Telefono = telefono; 
        this.Direccion = direccion; 
        this.Referencia = referencia; 
    }
    
} 