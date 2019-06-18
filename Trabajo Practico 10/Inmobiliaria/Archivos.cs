using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria
{
    class Archivos
    {

        public const string ruta = @"C:\Users\Facundo\Desktop\Repositorio\tp-nro10-FacuCR\";

        public const string directorio = ruta + "ArchivoBase.csv";

        public const string direccion = ruta + @"ListaInmuebles.csv";

        public enum Domicilio { Rivadavia, Roca, Independencia, Colombres}

        public static void ArchivoBase(int cantidad, List<Inmuebles.Propiedad> inmuebles)
        {
            Random random = new Random();

            Inmuebles.Propiedad inmueble = new Inmuebles.Propiedad();

            int ale, ale2;

            using (FileStream fileStream = new FileStream(directorio, FileMode.Create))
            {
                 using (StreamWriter stream = new StreamWriter(fileStream))
                 {
                    stream.WriteLine("ID;T. De Prop.;T. De Op.;Tamanio;C. De Banios;C. De Hab.;Domicilio;Precio;Estado;V. del Inm.;");
                 }
            }
            

            using (FileStream file = new FileStream(directorio, FileMode.Append))
            {
                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    for (int i = 1; i <= cantidad; i++)
                    {
                        ale = random.Next(Enum.GetNames(typeof(Inmuebles.TipoDePropiedad)).Length);//Obtengo la cantidad de enums

                        ale2 = random.Next(Enum.GetNames(typeof(Domicilio)).Length);//obtengo un num aleatorio del enum

                        inmueble.Id = i;

                        inmueble.TDePropiedad = Enum.GetName(typeof(Inmuebles.TipoDePropiedad), ale);

                        inmueble.Domicilio = Enum.GetName(typeof(Domicilio), ale2);

                        inmuebles.Add(inmueble);

                        streamWriter.WriteLine("{0};{1};;;;;{2};;;", i, Enum.GetName(typeof(Inmuebles.TipoDePropiedad), ale), Enum.GetName(typeof(Domicilio), ale2));

                    }
                }
            }
        }



        public static void CompletarArchivo(List<Inmuebles.Propiedad> inmuebles)
        {
            Inmuebles.Propiedad inmueble;

            string estado;

            string[] lineas = File.ReadAllLines(directorio);//Guardo todas las lineas de texto en un arreglo

            for (int i = 0; i < lineas.Length - 1; i++)//Completo todas las lineas
            {
                inmueble = inmuebles[i];

                if (inmueble.Estado)
                {
                    estado = "Activo";
                }
                else
                {
                    estado = "Inactivo";
                }

                //No modifico la primera linea
                lineas[i + 1] = inmueble.Id.ToString() + ";" + inmueble.TDePropiedad + ";" + inmueble.TDeOperacion + ";" + inmueble.Tamanio + ";" + inmueble.CantidadDeBaños + ";" + inmueble.CantidadDeHabitaciones + ";" + inmueble.Domicilio + ";" + inmueble.Precio + ";" + estado + ";" + inmueble.ValorDelInmueble();
            }

            if (!File.Exists(direccion))
            {
                using (FileStream fileStream = new FileStream(direccion, FileMode.Create))
                {
                    
                }
            }

            File.WriteAllLines(direccion, lineas);


        }



        public static void CrearBackup()
        {
            string solDeDirec = SolicitarDireccion();//Almacena la unidad de disco seleccionada

            string directory = solDeDirec + @"BackUpPropiedades\";

            //Comprueba si existe la carpeta indicada, sino la crea
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            //Obtengo el nombre del archivo original y lo agrego a la nueva direccion
            directory += Path.GetFileName(direccion) + ".bk";

            if (File.Exists(direccion))
            {
                if (!File.Exists(directory))
                {
                    File.Copy(direccion, directory);//Copio el archivo original a la nueva ruta
                }
            }


        }


        static string SolicitarDireccion()
        {
            int seleccion, contador = 1;

            try
            {
                string[] direcciones = Directory.GetLogicalDrives();//Almacena todos los discos disponibles en el arreglo

                Console.WriteLine("=====Direcciones Para Seleccionar=====");

                foreach (string direccion in direcciones)
                {
                    Console.WriteLine(contador++ + ": " + direccion);
                }

                Console.WriteLine("Hay {0} direcciones seleccione un numero del 1 al {1}", direcciones.Length, direcciones.Length);

                seleccion = Convert.ToInt16(Console.ReadLine());

                return direcciones[seleccion - 1];
            }
            catch
            {
                Console.WriteLine("El proceso fallo!!!");

                return "error";
            }
        }

    }
}
