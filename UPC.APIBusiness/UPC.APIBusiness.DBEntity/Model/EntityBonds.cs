using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityBonds
    {
        public string idBono { get; set; }
        public string descBono { get; set; }
        public DateTime fechaAplicacion { get; set; }
        public decimal montoBruto { get; set; }
        public string numeroComprobante { get; set; }
        public decimal descuento { get; set; }
    }
}
