using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCriteria
    {
        public string tipoOperadorLogico { get; set; }
        public int idCampoRegla { get; set; }
        public string valorRegla { get; set; }
        public int idTipoOperador { get; set; }
    }
}
