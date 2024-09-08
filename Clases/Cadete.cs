namespace cadeteria; 

public class Cadete
{
    string nombre; 
    int id; 
    int edad;
    string telefono;
    string genero; 
    List<Pedido> listadoDePedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Id { get => id; set => id = value; }
    public int Edad { get => edad; set => edad = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string Genero { get => genero; set => genero = value; }
    public List<Pedido> ListadoDePedidos { get => listadoDePedidos; set => listadoDePedidos = value; }

    public Cadete(int id, string nombre, int edad, string telefono, string genero)
    {
        this.id = id;
        this.nombre = nombre;
        this.edad = edad; 
        this.telefono = telefono;
        this.genero = genero;
        listadoDePedidos = new List<Pedido>(); //inicializo en vacía
    }

    public void asignarPedido(Pedido pedido)
    {
        ListadoDePedidos.Add(pedido); 
    }

    public decimal totalJornal()
    {
        return ListadoDePedidos.Count*500; 
    }
    public decimal cantidadEnvios()
    {
        return ListadoDePedidos.Count; 
    }
}

