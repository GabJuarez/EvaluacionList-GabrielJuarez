using System;
using System.Collections.Generic;
using System.Linq;

class Estudiante
{
    public string Nombre { get; set; }
    public List<double> Calificaciones { get; set; }

    public Estudiante(string nombre, List<double> calificaciones)
    {
        Nombre = nombre;
        Calificaciones = calificaciones;
    }
}

class Programa
{
    static void AgregarEstudiante(List<Estudiante> estudiantes, string nombre, List<double> calificaciones)
    {
        Estudiante nuevoEstudiante = new Estudiante(nombre, calificaciones);
        estudiantes.Add(nuevoEstudiante);
    }

    static double CalcularPromedio(List<double> calificaciones)
    {
        return calificaciones.Average();
    }

    static void DeterminarMejorPeorEstudiante(List<Estudiante> estudiantes)
    {
        Estudiante mejorEstudiante = estudiantes.OrderByDescending(e => CalcularPromedio(e.Calificaciones)).First();
        Estudiante peorEstudiante = estudiantes.OrderBy(e => CalcularPromedio(e.Calificaciones)).First();

        Console.WriteLine($"El estudiante con el promedio más alto es: {mejorEstudiante.Nombre} con un promedio de {CalcularPromedio(mejorEstudiante.Calificaciones):0.00}");
        Console.WriteLine($"El estudiante con el promedio más bajo es: {peorEstudiante.Nombre} con un promedio de {CalcularPromedio(peorEstudiante.Calificaciones):0.00}");
    }

    static void Main(string[] args)
    {
        List<Estudiante> estudiantes = new List<Estudiante>();

        string continuar;
        do
        {
            Console.Write("Ingresa el nombre del estudiante: ");
            string nombre = Console.ReadLine();

            List<double> calificaciones = new List<double>();
            Console.WriteLine("Ingresa las calificaciones del estudiante (separadas por espacios): ");
            string[] calificacionesInput = Console.ReadLine().Split(' ');

            foreach (var calificacion in calificacionesInput)
            {
                try
                {
                    calificaciones.Add(Convert.ToDouble(calificacion));
                }
                catch (FormatException)
                {
                    Console.WriteLine($"El valor '{calificacion}' no es una calificación válida.");
                }
            }

            AgregarEstudiante(estudiantes, nombre, calificaciones);

            Console.Write("¿Quieres agregar otro estudiante? (s/n): ");
            continuar = Console.ReadLine();

        } while (continuar.ToLower() == "s");

        DeterminarMejorPeorEstudiante(estudiantes);
    }
}
