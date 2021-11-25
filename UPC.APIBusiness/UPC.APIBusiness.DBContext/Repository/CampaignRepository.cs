using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class CampaignRepository : BaseRepository, ICampaingRepository
    {
        public List<EntityCampaing> GetCampaings()
        {
            var listCampaigns = new List<EntityCampaing>();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CAMPANIAS";
                    listCampaigns = dbConect.Query<EntityCampaing>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                }
            }
            catch(Exception ex)
            {

            }

            return listCampaigns;
        }
    }
}
