using System;
using System.IO;

namespace Eliminar1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("Ingrese 1 para ingresar datos de un estudiante");
                Console.WriteLine("Ingrese 2 para eliminar datos de un estudiante");
                Console.WriteLine("Ingrese 3 para ver los datos de los estudiantes");
                Console.WriteLine("Ingrese 4 para salir");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        IngresarDatos();
                        break;
                    case 2:
                        EliminarDatos();
                        break;
                    case 3:
                        Lista();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            } while (opcion != 4);
        }

        public static void IngresarDatos()
        {
            Console.WriteLine("Ingrese datos del estudiante");
            Console.WriteLine("______________________________________________");
            Console.WriteLine("Ingrese el ID del estudiante: ");
            Console.WriteLine("Ingrese nombre del estudiante: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese edad del estudiante: ");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese nota del estudiante: ");
            int nota = Convert.ToInt32(Console.ReadLine());
            string datos = $"{nombre} {edad} {nota}";


            GuardarDatos(datos);
        }

        public static void GuardarDatos(string datos)
        {
            string filePath = "Estudiante.txt";

            using (StreamWriter archivo = new StreamWriter(filePath, true))
            {
                archivo.WriteLine(datos);
            }

            Console.WriteLine("Datos guardados con éxito.");
        }

        public static void EliminarDatos()
        {
            Lista();
            Console.WriteLine("Ingrese el nombre del estudiante a eliminar: ");
            string nombreEliminar = Console.ReadLine();
            string filePath = "Estudiante.txt";

            string[] lines = File.ReadAllLines(filePath);
            File.WriteAllText(filePath, "");

            foreach (string line in lines)
            {
                string[] partes = line.Split(' ');
                string nombre = partes[0];

                if (nombre != nombreEliminar)
                {
                    GuardarDatos(line);
                }
            }

            Console.WriteLine("Datos del estudiante eliminados con éxito.");
        }

        public static void Lista()
        {
            string filePath = "Estudiante.txt";
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
