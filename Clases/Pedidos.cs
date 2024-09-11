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
    Cliente cliente; 
    Estado estado;

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }

    public Pedido()
    {

    }
    
    public Pedido nuevoPedido(Cliente cliente, int nro)
    {
        Console.WriteLine("Ingrese alguna observacion sobre el pedido: ");
        string obs = Console.ReadLine(); 

        estado = Estado.Pendiente; //inicializo. 

        return new Pedido(nro, obs, cliente, estado); 
    }

    private Pedido(int nro, string obs, Cliente cliente, Estado estado)
    {
        this.nro = nro; 
        this.obs = obs; 
        this.Cliente = cliente; 
        this.estado = estado; 
    }

    public void CambiarEstado()
    {
        estado = Estado.Entregado; 
    }
}
