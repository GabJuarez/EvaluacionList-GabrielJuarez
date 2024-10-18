using System;
using System.Collections.Generic;

class Inventario
{
    class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }

    static List<Producto> productos = new List<Producto>();

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("\nMenú de Inventario:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Consultar producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto();
                    break;
                case 2:
                    EliminarProducto();
                    break;
                case 3:
                    ModificarProducto();
                    break;
                case 4:
                    ConsultarProducto();
                    break;
                case 5:
                    MostrarProductos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, por favor intente de nuevo.");
                    break;
            }
        } while (opcion != 6);
    }

    static void AgregarProducto()
    {
        Console.Write("Ingrese el código del producto: ");
        int codigo = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la cantidad del producto: ");
        int cantidad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el precio del producto: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        productos.Add(new Producto { Codigo = codigo, Nombre = nombre, Cantidad = cantidad, Precio = precio });
        Console.WriteLine("Producto agregado exitosamente");
    }

    static void EliminarProducto()
    {
        Console.Write("Ingrese el código del producto a eliminar: ");
        int codigo = int.Parse(Console.ReadLine());

        Producto producto = productos.Find(p => p.Codigo == codigo);
        if (producto != null)
        {
            productos.Remove(producto);
            Console.WriteLine("Producto eliminado.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ModificarProducto()
    {
        Console.Write("Ingrese el código del producto a modificar: ");
        int codigo = int.Parse(Console.ReadLine());

        Producto producto = productos.Find(p => p.Codigo == codigo);
        if (producto != null)
        {
            Console.Write("Ingrese el nuevo nombre del producto: ");
            producto.Nombre = Console.ReadLine();
            Console.Write("Ingrese la nueva cantidad del producto: ");
            producto.Cantidad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nuevo precio del producto: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Producto modificado");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }
    static void ConsultarProducto()
    {
        Console.Write("Ingrese el código del producto a consultar: ");
        int codigo = int.Parse(Console.ReadLine());

        Producto producto = productos.Find(p => p.Codigo == codigo);
        if (producto != null)
        {
            Console.WriteLine($"Código: {producto.Codigo}, Nombre: {producto.Nombre}, Cantidad: {producto.Cantidad}, Precio: {producto.Precio:C}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void MostrarProductos()
    {
        if (productos.Count > 0)
        {
            Console.WriteLine("\nLista de productos:");
            foreach (var p in productos)
            {
                Console.WriteLine($"Código: {p.Codigo}, Nombre: {p.Nombre}, Cantidad: {p.Cantidad}, Precio: {p.Precio:C}");
            }
        }
        else
        {
            Console.WriteLine("No hay productos en el inventario");
        }
    }
}
