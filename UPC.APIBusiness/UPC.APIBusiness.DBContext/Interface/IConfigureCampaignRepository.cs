using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IConfigureCampaignRepository
    {
        BaseResponse InsertConfigureCampaign(EntityConfigureCampaign confCampaign);
        BaseResponse GetBenefits();
        BaseResponse GetRuleFields();
        BaseResponse GetComparativeOperator();
    }
}
