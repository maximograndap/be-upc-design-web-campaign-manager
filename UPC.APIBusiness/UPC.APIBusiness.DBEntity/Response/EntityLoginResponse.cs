using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityLoginResponse
    {
        public int idUsuario { get; set; }
        public string nombrePersona { get; set; }
        public string apellidoPersona { get; set; }
        public string numeroDocumento { get; set; }
        public string token { get; set; }
    }
}
