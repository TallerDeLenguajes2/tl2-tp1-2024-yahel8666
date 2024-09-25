

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace cadeteria;
public class AccesoJSON : AccesoDatos
{
    public override Cadeteria LeerCadeteria(string ruta)
    {
        // Verificar si el archivo existe
        if (!Existe(ruta)) 
        {
            throw new FileNotFoundException("El archivo no se encontró", ruta);
        }

        // Leer el contenido del archivo JSON
        string json = File.ReadAllText(ruta);

        // Deserializar el JSON a una única Cadeteria
        Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(json);

        // Asignar la lista de cadetes a la cadetería
        // if (cadeteria != null)
        // {
        //     cadeteria.ListaDeCadetes = listaCadetes;
        // }
        // else
        // {
        //     throw new InvalidDataException("No se pudo deserializar la cadetería.");
        // }

        return cadeteria;
    }

    public override List<Cadete> ObtenerCadetes(string ruta)
    {
        // Verificar si el archivo existe
        if (!Existe(ruta)) 
        {
            throw new FileNotFoundException("El archivo no se encontró", ruta);
        }

        // Leer el contenido del archivo JSON
        string json = File.ReadAllText(ruta);

        // Deserializar el JSON a una lista de Cadete
        return JsonSerializer.Deserialize<List<Cadete>>(json);
    }
}
