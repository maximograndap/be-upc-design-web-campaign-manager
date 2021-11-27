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
    }
}
