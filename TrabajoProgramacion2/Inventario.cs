using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoProgramacion2
{
    public  class Inventario
    {
        private List<Producto> productos = new List<Producto>();
        private const string FilePath = "inventario.txt";

        public Inventario()
        {
            CargarProductos();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
            GuardarProductos();
        }

        public void ActualizarPrecio(string nombre, double nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(precio => precio.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"El precio de '{producto.Nombre}' ha sido actualizado a {nuevoPrecio:C}.");
                GuardarProductos();
            }
            else
            {
                Console.WriteLine($"Producto '{nombre}' no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(precio => precio.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto '{producto.Nombre}' ha sido eliminado.");
                GuardarProductos();
            }
            else
            {
                Console.WriteLine($"Producto '{nombre}' no encontrado.");
            }
        }

        public void ContarYAgruparProductosPorPrecio()
        {
            var grupos = productos.GroupBy(p =>
            {
                if (p.Precio < 100) return "Menores de 100";
                if (p.Precio <= 500) return "Entre 100 y 500";
                return "Mayores de 500";
            });

            Console.WriteLine("\n--- Conteo de Productos por Rangos de Precio ---");
            foreach (var grupo in grupos)
            {
                Console.WriteLine($"{grupo.Key}: {grupo.Count()}");
            }
        }

        public void MostrarReporteResumido()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario.");
                return;
            }

            int totalProductos = productos.Count;
            double precioPromedio = productos.Average(p => p.Precio);
            var productoMasCaro = productos.OrderByDescending(p => p.Precio).First();
            var productoMasBarato = productos.OrderBy(p => p.Precio).First();

            Console.WriteLine("\n--- Reporte Resumido del Inventario ---");
            Console.WriteLine($"Número total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio de todos los productos: {precioPromedio:C}");
            Console.WriteLine($"Producto más caro: {productoMasCaro.Nombre} con precio {productoMasCaro.Precio:C}");
            Console.WriteLine($"Producto más barato: {productoMasBarato.Nombre} con precio {productoMasBarato.Precio:C}");
        }

        private void GuardarProductos()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var producto in productos)
                {
                    writer.WriteLine(producto);
                }
            }
        }

        private void CargarProductos()
        {
            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                productos = lines.Select(Producto.FromString).ToList();
            }
        }
    }


}

