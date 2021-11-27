using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCampaing : EntityBase
    {
        public int idCampania { get; set; }
        public string nombreCampania { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string nombreTipoCampania { get; set; }
        public string nombreBeneficio { get; set; }
    }
}
