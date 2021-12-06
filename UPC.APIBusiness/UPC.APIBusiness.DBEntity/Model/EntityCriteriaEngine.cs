using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCriteriaEngine
    {
        public int idCampania { get; set; }
        public string nombreCampania { get; set; }
        public int idRegla { get; set; }
        public List<EntityCampaignCriteria> criterios { get; set; }
        public List<EntityBondsEngine> bonos { get; set; }
        public List<EntityGiftsEngine> obsequios { get; set; }
    }
}
