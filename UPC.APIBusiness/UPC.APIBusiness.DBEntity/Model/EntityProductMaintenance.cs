using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProductMaintenance : EntityBase
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descProducto { get; set; }
        public decimal precioProducto { get; set; }
        public int idCategoriaProducto { get; set; }
    }
}
