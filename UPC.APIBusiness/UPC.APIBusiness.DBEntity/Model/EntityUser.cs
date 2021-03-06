using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
        public int idUsuario { get; set; }
        public int idPersona { get; set; }
        public string nombrePersona { get; set; }
        public string apellidoPersona { get; set; }
        public string numeroDocumento { get; set; }
        public string nombreUsuario { get; set; }
        public string password { get; set; }
    }
}
