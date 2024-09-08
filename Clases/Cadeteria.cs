namespace cadeteria; 

public class Cadeteria
{
    string nombre; 
    string telefono; 
    public List<Cadete> listaDeCadetes;

    public Cadeteria(string nombre, string telefono, List<Cadete> listaDeCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listaDeCadetes = listaDeCadetes;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    //Es mas para ver si lee bien los datos del archivo ;) 
    public void MostrarDatosCadeteria()
    {
        Console.WriteLine($"\t BIENVENIDOS A '{nombre}' \n");
    }
  
}

