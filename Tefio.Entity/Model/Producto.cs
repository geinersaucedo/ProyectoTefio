using System;
using System.Collections.Generic;
using System.Text;

namespace Tefio.Entity.Model
{
    public class Producto
    {
        public String IdBodega { get; set; }
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public String NombreCategoria { get; set; }
        public String NombreProducto { get; set; }
        public String ImagenUrl { get; set; }
        public float Precio { get; set; }
        public float Descuento { get; set; }
        public bool Destacable { get; set; }
    }
}
