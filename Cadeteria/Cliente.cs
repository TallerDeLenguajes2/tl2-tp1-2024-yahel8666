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

    public Cliente(string nombre, string telefono, string direccion, string referencia)
    {
        this.nombre = nombre; 
        this.telefono = telefono; 
        this.direccion = direccion; 
        this.referencia = referencia; 
    }
    
} 