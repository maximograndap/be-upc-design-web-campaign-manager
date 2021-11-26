using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class CustomerCampaignRepository : BaseRepository, ICustomerCampaignRepository
    {
        public BaseResponse GetCustomerCampaigns(string doc)
        {
            var entityResponse = new BaseResponse();
            var listCampaigns = new List<EntityCustomerCampaign>();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CLIENTE_CAMPANIAS";
                    var paramDoc = new DynamicParameters();
                    paramDoc.Add(
                        name: "@NUMERODOCUMENTO",
                        value: doc,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );

                    listCampaigns = dbConect.Query<EntityCustomerCampaign>(
                        sql: sqlSP,
                        param: paramDoc,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (listCampaigns.Count > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = listCampaigns;
                    }
                    else
                    {
                        entityResponse.issuccess = false;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                entityResponse.issuccess = false;
                entityResponse.errorcode = "-1";
                entityResponse.errormessage = ex.Message;
                entityResponse.data = null;
            }

            return entityResponse;
        }
    }
}
