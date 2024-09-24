namespace cadeteria; 
public enum Estado
{
    Entregado, 
    Pendiente,
}

public class Pedido
{
    int nro; 
    string obs;
    Estado estado;
    Cliente cliente; 

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }

    public Pedido()
    {

    }
    
    public Pedido NuevoPedido(int nro)
    {
        Console.WriteLine("\n \t\t --DAR DE ALTA UN PEDIDO--\n");

        //pido los datos correspondientes al pedido: 
        Console.WriteLine("Ingrese alguna observacion sobre el pedido: ");
        string obs = Console.ReadLine(); 
        estado = Estado.Pendiente; 
        
        //pido los datos correspondientes al cliente, para mandarselos al constructor Pedido
        Console.WriteLine("Ingrese el nombre del cliente");
        string nombre = Console.ReadLine(); 
        Console.WriteLine("Ingrese el telefono del cliente");
        string telefono = Console.ReadLine(); 
        Console.WriteLine("Ingrese la direccion del cliente"); 
        string direccion = Console.ReadLine();
        Console.WriteLine("Ingrese algunos datos de referencia de direccion del cliente"); 
        string referencia = Console.ReadLine(); 
        return new Pedido(nro, obs, estado, nombre, telefono, direccion, referencia); 
    }

    private Pedido(int nro, string obs, Estado estado, string nombre, string telefono, string direccion, string referencia)
    {
        this.nro = nro; 
        this.obs = obs;  
        this.estado = estado; 

        //creo cliente dentro del constructor Pedido (asociacion de composición)
        cliente = new Cliente(nombre, telefono, direccion, referencia); 
    }

    public void CambiarEstado()
    {
        estado = Estado.Entregado; 
    }
}
