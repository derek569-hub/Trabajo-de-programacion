using System;
using TrabajoProgramacion2;
namespace TrabajoProgramacion2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inventario = new Inventario();
            Console.WriteLine("Bienvenido al sistema de gestión de inventario");

            while (true)
            {
                Console.WriteLine("\n--- Menú de Opciones ---");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Actualizar precio de producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Ver reporte resumido del inventario");
                Console.WriteLine("5. Contar y agrupar productos por precio");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("\nNombre del producto: ");
                        string nombre = Console.ReadLine();

                        double precio;
                        do
                        {
                            Console.Write("Precio: ");
                            if (!double.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                            {
                                Console.WriteLine("El precio debe ser un número positivo.");
                                precio = -1;
                            }
                        } while (precio <= 0);

                        inventario.AgregarProducto(new Producto(nombre, precio));
                        break;

                    case "2":
                        Console.Write("\nNombre del producto a actualizar: ");
                        nombre = Console.ReadLine();
                        Console.Write("Nuevo precio: ");
                        if (double.TryParse(Console.ReadLine(), out precio) && precio > 0)
                        {
                            inventario.ActualizarPrecio(nombre, precio);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido.");
                        }
                        break;

                    case "3":
                        Console.Write("\nNombre del producto a eliminar: ");
                        nombre = Console.ReadLine();
                        inventario.EliminarProducto(nombre);
                        break;

                    case "4":
                        inventario.MostrarReporteResumido();
                        break;

                    case "5":
                        inventario.ContarYAgruparProductosPorPrecio();
                        break;

                    case "6":
                        Console.WriteLine("Saliendo del sistema...");
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}


