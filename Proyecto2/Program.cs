using System;
using System.IO;

namespace Proyecto2
{
    internal class Program
    {
        private static string filePath = "Alumnos.txt";

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1. Ingresar");
                Console.WriteLine("2. Eliminar");
                Console.WriteLine("3. Modificar");
                Console.WriteLine("4. Ver listado de alumnos");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Ingrese una opcion");

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                    switch (opcion)
                    {
                        case 1:
                            Ingresar();
                            break;
                        case 2:
                            Eliminar();
                            break;
                        case 3:
                            Modificar();
                            break;
                        case 4:
                            LeerListado();
                            break;
                        case 5:
                            Console.WriteLine("Gracias por usar el programa");
                            break;
                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingrese un número válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }

            } while (opcion != 5);
        }

        static void Guardar(string nombre, string id, string punteo)
        {
            try
            {
                StreamWriter escribir = new StreamWriter(filePath, true);
                escribir.WriteLine(nombre + "," + id + "," + punteo);
                escribir.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al guardar datos: {ex.Message}");
            }
        }

        static void Leer()
        {
            try
            {
                StreamReader leer = new StreamReader(filePath, true);
                string linea = "";
                while (linea != null)
                {
                    linea = leer.ReadLine();
                    if (linea != null)
                    {
                        string[] datos = linea.Split(',');
                        Console.WriteLine("Nombre: " + datos[0]);
                        Console.WriteLine("ID: " + datos[1]);
                        Console.WriteLine("Punteo: " + datos[2]);
                        Console.WriteLine(" ");
                    }
                }
                leer.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer datos: {ex.Message}");
            }
        }

        static void Ingresar()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre del alumno");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el ID del alumno");
                string id = Console.ReadLine();
                Console.WriteLine("Ingrese el punteo del alumno");
                string punteo = Console.ReadLine();
                Console.WriteLine("");

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(punteo))
                {
                    Console.WriteLine("No puede dejar ningún campo vacío.");
                    Console.WriteLine("");
                    Ingresar();
                }
                else
                {
                    Guardar(nombre, id, punteo);
                    Console.WriteLine("Datos del alumno guardados con éxito.");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        static void Eliminar()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre del alumno que desea eliminar");
                string nombre = Console.ReadLine();
                string[] lineas = File.ReadAllLines(filePath);
                File.WriteAllText(filePath, "");

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');
                    if (datos[0] != nombre)
                    {
                        Guardar(datos[0], datos[1], datos[2]);
                    }
                }

                Console.WriteLine("Datos del alumno eliminados con éxito.");
                Console.WriteLine("");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al eliminar datos: {ex.Message}");
            }
        }

        static void Modificar()
        {
            try
            {
                Console.WriteLine("Ingrese el ID del alumno que desea modificar");
                string id = Console.ReadLine();
                string[] lineas = File.ReadAllLines(filePath);
                File.WriteAllText(filePath, "");

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');
                    if (datos[1] == id)
                    {
                        Console.WriteLine("Ingrese el nuevo ID del alumno");
                        string nuevoid = Console.ReadLine();
                        Console.WriteLine("Ingrese el nuevo nombre del alumno");
                        string nuevonombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el nuevo punteo del alumno");
                        string nuevopunteo = Console.ReadLine();
                        Console.WriteLine("");

                        Guardar(nuevonombre, nuevoid, nuevopunteo);
                    }
                    else
                    {
                        Guardar(datos[0], datos[1], datos[2]);
                    }
                }

                Console.WriteLine("Datos del alumno con ID " + id + " modificados con éxito.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al modificar datos: {ex.Message}");
            }
        }

        static void LeerListado()
        {
            try
            {
                StreamReader leer = new StreamReader(filePath);
                string linea = "";
                while (linea != null)
                {
                    linea = leer.ReadLine();
                    if (linea != null)
                    {
                        string[] datos = linea.Split(',');
                        Console.WriteLine("Nombre: " + datos[0]);
                        Console.WriteLine("ID: " + datos[1]);
                        Console.WriteLine("Punteo: " + datos[2]);
                        Console.WriteLine(" ");
                    }
                }
                leer.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer listado: {ex.Message}");
            }
        }
    }
}
