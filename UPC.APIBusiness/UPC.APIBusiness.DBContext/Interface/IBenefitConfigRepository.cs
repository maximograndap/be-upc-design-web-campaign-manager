using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IBenefitConfigRepository
    {
        BaseResponse InsertBenefitConfig(List<EntityBenefitConfig> ListBenefitConfig, int idRegla);
    }
}
