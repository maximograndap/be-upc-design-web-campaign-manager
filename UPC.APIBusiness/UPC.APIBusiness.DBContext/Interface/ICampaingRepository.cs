using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface ICampaingRepository
    {
        BaseResponse GetCampaingsActives();
        BaseResponse GetCampaingsAll();
        BaseResponse GetCampaing(int idCampania);
        BaseResponse InsertCampaign(EntityCampaignMaintenance campaign);
        BaseResponse UpdateCampaign(EntityCampaignMaintenance campaign);
        BaseResponse DeleteCampaign(int idCampaign);
        BaseResponse GetBenefitType();
        BaseResponse GetCampaignType();
    }
}
