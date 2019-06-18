using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria
{
    class Inmuebles
    {

        public enum TipoDeOperacion { Venta, Alquiler }

        public enum TipoDePropiedad { Departamento, Casa, Duplex, Penthhouse, Terreno }

        public struct Propiedad
        {
            int id;

            string tDePropiedad;

            string tDeOperacion;

            float tamanio;

            int cantidadDeBaños;

            int cantidadDeHabitaciones;

            string domicilio;

            double precio;

            bool estado;

            public int Id { get => id; set => id = value; }
            public float Tamanio { get => tamanio; set => tamanio = value; }
            public int CantidadDeBaños { get => cantidadDeBaños; set => cantidadDeBaños = value; }
            public int CantidadDeHabitaciones { get => cantidadDeHabitaciones; set => cantidadDeHabitaciones = value; }
            public string Domicilio { get => domicilio; set => domicilio = value; }
            public double Precio { get => precio; set => precio = value; }
            public bool Estado { get => estado; set => estado = value; }
            public string TDePropiedad { get => tDePropiedad; set => tDePropiedad = value; }
            public string TDeOperacion { get => tDeOperacion; set => tDeOperacion = value; }


            public double ValorDelInmueble()
            {

                double valor, iva = 0.21, alquiler = 0.2, costos = 0.05;
                int costoDeTransferencia = 10000;

                if (tDeOperacion == TipoDeOperacion.Venta.ToString())
                {
                    valor = (double)precio + (precio * iva) + costoDeTransferencia;

                    return valor;
                }
                else
                {
                    valor = (double)(precio * alquiler) + (precio * costos);

                    return valor;
                }
            }

        }

        public static void CompletarDatos(List<Inmuebles.Propiedad> inmuebles, int cantidad)
        {
            Random random = new Random();

            int ale; double ale2;

            for (int i = 0; i < cantidad; i++)
            {
                Inmuebles.Propiedad copia = inmuebles[i];//Obtengo la copia de la lista

                //Asigno los valores que faltan en la copia

                ale = random.Next(Enum.GetNames(typeof(Inmuebles.TipoDeOperacion)).Length);//Obtengo un numero aleatorio de la cantidad de enums que tengof dhttu

                copia.TDeOperacion = Enum.GetName(typeof(Inmuebles.TipoDeOperacion), ale);

                ale = random.Next(100, 500);

                copia.Tamanio = ale;

                ale = random.Next(1, 4);

                copia.CantidadDeBaños = ale;

                ale = random.Next(1, 4);

                copia.CantidadDeHabitaciones = ale;

                ale2 = random.Next(100000, 5000000);

                copia.Precio = ale2;

                ale = random.Next(2);

                if (ale == 1)
                {
                    copia.Estado = true;
                }
                else
                {
                    copia.Estado = false;
                }

                inmuebles[i] = copia;//Guardo la copia en el nodo original
            }
        }

    }
}
