using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityBondsEngine
    {
        public int idRegla { get; set; }
        public string idBono { get; set; }
        public string nombreBono { get; set; }
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string flgEfectivo { get; set; }
        public string abreviaturaDescuento { get; set; }
        public decimal valorDescuento { get; set; }
    }
}
