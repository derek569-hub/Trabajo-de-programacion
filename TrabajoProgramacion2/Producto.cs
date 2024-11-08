using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoProgramacion2
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Nombre},{Precio}";
        }

        public static Producto FromString(string data)
        {
            var parts = data.Split(',');
            return new Producto(parts[0], double.Parse(parts[1]));
        }
    }
}
    

