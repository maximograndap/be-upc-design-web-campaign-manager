using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface ICampaignCriteriaRepository
    {
        BaseResponse GetCampaignCriteria(int idCampania);
    }
}
