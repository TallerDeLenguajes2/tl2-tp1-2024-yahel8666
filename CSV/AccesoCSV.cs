namespace cadeteria;

public class AccesoCSV : AccesoDatos 
{
    public override Cadeteria LeerCadeteria(string ruta)
    {
        Cadeteria cadeteria = null; 
        string[] lineas;

        try
        {
            lineas = File.ReadAllLines(ruta);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo de cadetería: {ex.Message}");
            return null;
        }

        var datos = lineas[0].Split(',');
        if (datos.Length < 2) 
        {
            Console.WriteLine("Datos de cadetería incompletos.");
            return null;
        }

        string nombre = datos[0];
        string telefono = datos[1]; 
        cadeteria = new Cadeteria(nombre, telefono);
        return cadeteria;
    }

    public override List<Cadete> ObtenerCadetes(string ruta)
    {
        List<Cadete> listaCadetes = new List<Cadete>();
        string[] lineas;
        try
        {
            lineas = File.ReadAllLines(ruta);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo de cadetes: {ex.Message}");
            return listaCadetes; // Retornar lista vacía en caso de error
        }

        for (int i = 0; i < lineas.Length; i++) 
        {
            var datos = lineas[i].Split(','); 

            if (datos.Length < 5) // Validar que hay suficientes datos
            {
                Console.WriteLine($"Línea inválida en cadetes: {lineas[i]}");
                continue; // Saltar a la siguiente línea
            }
            string nombre = datos[0];
            int id;
            int edad;
            string telefono = datos[3];
            string genero = datos[4];

            // Validar la conversión de ID y edad
            if (!int.TryParse(datos[1], out id))
            {
                Console.WriteLine($"ID inválido en cadete: {lineas[i]}");
                continue;
            }

            if (!int.TryParse(datos[2], out edad))
            {
                Console.WriteLine($"Edad inválida en cadete: {lineas[i]}");
                continue;
            }

            var cadete = new Cadete(id, nombre, edad, telefono, genero);
            listaCadetes.Add(cadete);
        }
        return listaCadetes;
    }
}
