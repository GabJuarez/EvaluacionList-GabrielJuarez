using System;
using System.Collections.Generic;


class Program
{
    static List<string> palabrasIngles = new List<string>();
    static List<string> palabrasEspanol = new List<string>();
    static void crearDiccionario()
    {
        Console.WriteLine("Diccionario de Ingles y Español (5 palabras) ");
        Console.WriteLine();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Ingrese la palabra {i + 1} en ingles:  ");
            string palabrasInglesInput = Console.ReadLine();
            palabrasIngles.Add(palabrasInglesInput);

            Console.WriteLine("Ingrese la traduccion de la palabra: ");
            String palabrasEspanolInput = Console.ReadLine();
            palabrasEspanol.Add(palabrasEspanolInput);
            Console.WriteLine();
        }
    }

    static void traducir()
    {
        string palabrat;

        do
        {
            Console.WriteLine("Ingrese la palabra a traducir (O 's' para salir del programa)");
            palabrat = Console.ReadLine();

            if(palabrat.ToLower() == "s")
            {
                break;
            }

            //indice para las traducciones

            int ind = palabrasIngles.IndexOf(palabrat);

            if (ind != -1)
            {
                Console.WriteLine($"La traduccion de {palabrat} es {palabrasEspanol[ind]}");
                Thread.Sleep(5000);
                Console.Clear();

            }
            else
            {
                Console.WriteLine($"La palabra '{palabrat}' no se encuentra en el diccionario");
            }
        } while (true);
    }

    static void Main()
    {
        crearDiccionario();
        Console.Clear();
        traducir();
    }
}