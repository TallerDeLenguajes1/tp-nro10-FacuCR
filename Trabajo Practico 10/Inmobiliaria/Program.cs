using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria
{
    class Program
    {

        static void Main(string[] args)
        {

            List<Inmuebles.Propiedad> inmuebles = new List<Inmuebles.Propiedad>();

            Inmuebles.Propiedad inmueble = new Inmuebles.Propiedad();

            int cantidad;

            Console.WriteLine("Ingrese la cantidad de inmuebles");

            cantidad = Convert.ToInt16(Console.ReadLine());

            Archivos.ArchivoBase(cantidad, inmuebles);

            Inmuebles.CompletarDatos(inmuebles, cantidad);

            Archivos.CompletarArchivo(inmuebles);

            Archivos.CrearBackup();

        }
    }
}
