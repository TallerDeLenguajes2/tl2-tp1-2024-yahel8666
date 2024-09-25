namespace  cadeteria; 

public abstract class AccesoDatos 
{
    public bool Existe(string ruta)
    {
        return File.Exists(ruta);
    }
    public abstract Cadeteria LeerCadeteria(string ruta);
    public abstract List<Cadete> ObtenerCadetes(string ruta);
}