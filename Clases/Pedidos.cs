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
}
