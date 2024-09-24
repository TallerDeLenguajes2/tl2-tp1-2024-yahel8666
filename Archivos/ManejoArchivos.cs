namespace cadeteria;

public class ManejoArchivos
{
    public bool Existe(string ruta)
    {
        return File.Exists(ruta);
    }

    public List<Cadete> obtenerCadetes(string rutaCadetes)
    {
        List<Cadete> listaCadetes = new List<Cadete>();
        string[] lineas = File.ReadAllLines(rutaCadetes); //devuelve un array con TODAS las lineas 

        //salto la primera linea (linea[0]) porque es el encabezado :P
        for (int i = 1; i < lineas.Length; i++) 
        {
            var datos = lineas[i].Split(','); //separo cada linea del array en datos individuales.
            string nombre = datos[0];
            int id = int.Parse(datos[1]);
            int edad = int.Parse(datos[2]);
            string telefono = datos[3];
            string genero = datos[4];

            var cadete = new Cadete(id, nombre, edad, telefono, genero);
            listaCadetes.Add(cadete);
        }
        return listaCadetes;
    }

    /* 
    OTRO METODO, que me lee secuencialmente cada linea, ideal para archivos muy pesados. 
    public List<Cadete> LeerCadetes(string rutaCadetes)
    {
        List<Cadete> listaCadetes = new List<Cadete>();
        if (!Existe(rutaCadetes))
        { 
            return listaCadetes;     
        }

        using (var archivoOpen = new FileStream(rutaCadetes, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                string linea;
                while ((linea = strReader.ReadLine()) != null) //acá lee cada linea del archivo
                {
                    var datos = linea.Split(';');
                    if (datos.Length >= 4) 
                    {
                        // var cadete = new Cadete( bla bla bla);
                        // listaCadetes.Add(cadete);
                    }
                    else
                    {
                        Console.WriteLine($"Línea inválida en el archivo: {linea}");
                    }
                }
            }
        }
        return listaCadetes;
    }
    */


    public Cadeteria CargarCadeteria(string rutaCadeteria, List<Cadete> listaCadetes)
    {
        /*necesito inicializarla en null, porque si la inicializo dentro
        del "for" (cuando la quiera crear con los parametros) esto no se va a reflejar afuera" 
        */ 
        Cadeteria cadeteria = null; 
        string[] lineas = File.ReadAllLines(rutaCadeteria);
        
        //salto de nuevo el encabezado
        for (int i = 1; i < lineas.Length; i++)
        {
            var datos = lineas[i].Split(',');
            string nombre = datos[0];
            string telefono = datos[1]; 

            cadeteria = new Cadeteria(nombre, telefono, listaCadetes);
        }
        return cadeteria; 
    }
}    