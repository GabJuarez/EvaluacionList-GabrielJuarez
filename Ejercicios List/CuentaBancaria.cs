using System;
using System.Collections.Generic;

class ProgramaCuentaBancaria
{
    static void Main()
    {
        decimal saldo = 0; 
        List<string> transacciones = new List<string>(); 

        while (true)
        {
            Console.WriteLine("\nMenú de opciones:");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Mostrar historial de transacciones");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: 
                    Console.WriteLine($"Su saldo actual es: {saldo:C}");
                    break;

                case 2: 
                    Console.Write("Ingrese la cantidad a depositar: ");
                    decimal deposito = decimal.Parse(Console.ReadLine());
                    saldo += deposito;
                    transacciones.Add($"Depósito: +{deposito:C} - Saldo: {saldo:C}");
                    Console.WriteLine($"Ha depositado {deposito:C}. Su nuevo saldo es: {saldo:C}");
                    break;

                case 3: 
                    Console.Write("Ingrese la cantidad a retirar: ");
                    decimal retiro = decimal.Parse(Console.ReadLine());

                    if (retiro <= saldo)
                    {
                        saldo -= retiro;
                        transacciones.Add($"Retiro: -{retiro:C} - Saldo: {saldo:C}");
                        Console.WriteLine($"Ha retirado {retiro:C}. Su nuevo saldo es: {saldo:C}");
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente para realizar el retiro.");
                    }
                    break;

                case 4:
                    Console.WriteLine("\nHistorial de transacciones:");
                    if (transacciones.Count == 0)
                    {
                        Console.WriteLine("No hay transacciones registradas.");
                    }
                    else
                    {
                        foreach (var transaccion in transacciones)
                        {
                            Console.WriteLine(transaccion);
                        }
                    }
                    break;

                case 5: // Salir
                    Console.WriteLine("Gracias por usar el sistema de gestión bancaria");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}
