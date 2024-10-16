using System;
using System.Collections.Generic;

class Programa
{    static double CalcularAreaTriangulo(double baseTriangulo, double altura)
    {
        return (baseTriangulo * altura) / 2;
    }

    static void MostrarResultados(List<double> resultadosAreas)
    {
        Console.WriteLine("\nHistorial de áreas calculadas:");
        for (int i = 0; i < resultadosAreas.Count; i++)
        {
            Console.WriteLine($"Triángulo {i + 1}: Área = {resultadosAreas[i]}");
        }
    }

    static void Main(string[] args)
    {
        List<double> resultadosAreas = new List<double>();
        string continuar;

        do
        {
            try
            {
                Console.Write("Ingresa la base del triángulo: ");
                double baseTriangulo = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingresa la altura del triángulo: ");
                double altura = Convert.ToDouble(Console.ReadLine());

                if (baseTriangulo <= 0 || altura <= 0)
                {
                    Console.WriteLine("La base y la altura deben ser mayores a 0");
                }
                else
                {
                    double area = CalcularAreaTriangulo(baseTriangulo, altura);

                    resultadosAreas.Add(area);

                    Console.WriteLine($"El área del triángulo con base {baseTriangulo} y altura {altura} es: {area}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, ingresa valores numéricos válidos.");
            }

            Console.Write("¿Quieres calcular el área de otro triángulo? (s/n): ");
            continuar = Console.ReadLine();
            Console.WriteLine();

        } while (continuar.ToLower() == "s");

        MostrarResultados(resultadosAreas);
    }
}
