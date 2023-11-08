using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliminar
{
    internal class Program
    {
        class Alumno
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Carnet { get; set; }
            public string phone { get; set; }

        }
        static List<Alumno> alumnoList = new List<Alumno>();
        {
            new Alumno 
            {
                Nombre = "Juan",
                Apellido = "Perez",
                Carnet = "123456",
                phone = "12345678"
            };

        }
        static void Main(string[] args)
        {
            Console.WriteLine(alumnoList);
            Console.ReadLine();
        }
    }
}
