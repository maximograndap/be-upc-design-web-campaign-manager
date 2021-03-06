using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProduct : EntityBase
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descProducto { get; set; }
        public decimal precioProducto { get; set; }
        public int idCategoriaProducto { get; set; }
        public string nombreCategoriaProducto { get; set; }
        public string indicadorAplicacion { get; set; }
    }
}
