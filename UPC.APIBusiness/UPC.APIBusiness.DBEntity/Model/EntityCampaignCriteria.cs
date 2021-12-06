using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCampaignCriteria
    {
        public int idCampania { get; set; }
        public string tipoOperadorLogico { get; set; }
        public string campoRegla { get; set; }
        public string tipoAgrupacionCampo { get; set; }
        public int idRegla { get; set; }
        public string valorRegla { get; set; }
        public string valorTipoOperador { get; set; }
        public string abreviaturaOperador { get; set; }
    }
}
