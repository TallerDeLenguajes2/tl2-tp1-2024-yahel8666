namespace cadeteria;

public class ManejoArchivos
{
    public List<Cadete> obtenerCadetes(string rutaCadetes)
    {
        List<Cadete> listaCadetes = new List<Cadete>();
        string[] lineas = File.ReadAllLines(rutaCadetes);

        //aca salteo la primera linea (linea[0]) porque es el encabezado :P
        for (int i = 1; i < lineas.Length; i++)
        {
            var datos = lineas[i].Split(',');
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

    public Cadeteria CargarCadeteria(string rutaCadeteria, List<Cadete> listaCadetes)
    {
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