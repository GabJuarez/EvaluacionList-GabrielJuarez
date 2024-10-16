using System;
using System.Collections.Generic;

class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre, double precio, int cantidad)
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }

    public double ValorTotal()
    {
        return Precio * Cantidad;
    }
}

class ProgramaInventario
{
    static void AgregarProducto(List<Producto> inventario, string nombre, double precio, int cantidad)
    {
        Producto nuevoProducto = new Producto(nombre, precio, cantidad);
        inventario.Add(nuevoProducto);
        Console.WriteLine($"Producto {nombre} añadido al inventario.");
    }

    static void ActualizarStock(List<Producto> inventario, string nombre, int nuevaCantidad)
    {
        foreach (Producto producto in inventario)
        {
            if (producto.Nombre.ToLower() == nombre.ToLower())
            {
                producto.Cantidad = nuevaCantidad;
                Console.WriteLine($"El stock del producto {nombre} ha sido actualizado a {nuevaCantidad}.");
                return;
            }
        }
        Console.WriteLine($"Producto {nombre} no encontrado en el inventario.");
    }

    static double CalcularValorTotal(List<Producto> inventario)
    {
        double valorTotal = 0;
        foreach (Producto producto in inventario)
        {
            valorTotal += producto.ValorTotal();
        }
        return valorTotal;
    }

    static void MostrarInventario(List<Producto> inventario)
    {
        Console.WriteLine("\nInventario actual:");
        foreach (Producto producto in inventario)
        {
            Console.WriteLine($"Producto: {producto.Nombre}, Precio: {producto.Precio}, Cantidad en stock: {producto.Cantidad}, Valor total: {producto.ValorTotal()}");
        }
    }

    static void Main(string[] args)
    {
        List<Producto> inventario = new List<Producto>();
        string continuar;

        do
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Añadir un nuevo producto.");
            Console.WriteLine("2. Actualizar la cantidad en stock de un producto.");
            Console.WriteLine("3. Calcular el valor total del inventario.");
            Console.WriteLine("4. Mostrar inventario.");
            Console.WriteLine("5. Salir.");

            Console.Write("Selecciona una opción (1-5): ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingresa el nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingresa el precio del producto: ");
                    double precio = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Ingresa la cantidad del producto: ");
                    int cantidad = Convert.ToInt32(Console.ReadLine());
                    AgregarProducto(inventario, nombre, precio, cantidad);
                    break;

                case 2:
                    Console.Write("Ingresa el nombre del producto para actualizar el stock: ");
                    string nombreProducto = Console.ReadLine();
                    Console.Write("Ingresa la nueva cantidad: ");
                    int nuevaCantidad = Convert.ToInt32(Console.ReadLine());
                    ActualizarStock(inventario, nombreProducto, nuevaCantidad);
                    break;

                case 3:
                    double valorTotal = CalcularValorTotal(inventario);
                    Console.WriteLine($"El valor total del inventario es: {valorTotal}");
                    break;

                case 4:
                    MostrarInventario(inventario);
                    break;

                case 5:
                    Console.WriteLine("Saliendo del programa.");
                    continuar = "n";
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.Write("\n¿Quieres realizar otra operación? (s/n): ");
            continuar = Console.ReadLine();

        } while (continuar.ToLower() == "s");
    }
}
