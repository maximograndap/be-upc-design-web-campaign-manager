using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCampaignType : EntityBase
    {
        public int idTipoCampania { get; set; }
        public string nombreTipoCampania { get; set; }
        public string descTipoCampania { get; set; }
    }
}
