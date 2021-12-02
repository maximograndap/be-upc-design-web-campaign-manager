using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityConfigureCampaign
    {
        public int idCampania { get; set; }
        public string nombreRegla { get; set; }
        public string descRegla { get; set; }
        public List<EntityCriteria> criterios { get; set; }
        public List<EntityBenefitConfig> beneficios { get; set; }
    }
}
