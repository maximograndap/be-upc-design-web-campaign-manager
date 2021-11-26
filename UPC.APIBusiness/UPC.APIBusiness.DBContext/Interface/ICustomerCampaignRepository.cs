using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface ICustomerCampaignRepository
    {
        BaseResponse GetCustomerCampaigns(string doc);
    }
}
