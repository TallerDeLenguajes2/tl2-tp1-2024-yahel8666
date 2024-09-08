using cadeteria;

string rutaCadetes = @"Archivos\datosCadetes.csv";
string rutaCadeteria = @"Archivos\datosCadeteria.csv";

var menu = new Menu(); 

var manejoArchivos = new ManejoArchivos(); 
List <Cadete> listaCadetes = manejoArchivos.obtenerCadetes(rutaCadetes);
var cadeteria = manejoArchivos.CargarCadeteria(rutaCadeteria, listaCadetes);

cadeteria.MostrarDatosCadeteria();
menu.mostrarMenu(); 
int opcion = menu.LeerYValidarOpcion();








