using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityBase
    {
        public string flgEstado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string usuarioActualizacion { get; set; }
    }
}
