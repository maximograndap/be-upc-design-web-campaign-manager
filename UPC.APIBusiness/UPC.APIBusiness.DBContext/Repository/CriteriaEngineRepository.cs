using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class CriteriaEngineRepository : BaseRepository, ICriteriaEngine
    {
        public BaseResponse GetCriteriaEngine()
        {
            var entityResponse = new BaseResponse();
            var campaignCriteria = new CampaignCriteriaRepository();
            var giftsEngine = new GiftsEngineRepository();
            var bondsEngine = new BondsEngineRepository();
            var listCampaign = new List<EntityCriteriaEngine>();
            var numberOne = 1;

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CAMPANIA_ENGINE";

                    listCampaign = dbConect.Query<EntityCriteriaEngine>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    var items = listCampaign.Count() - numberOne;

                    for (int n = 0; n <= items; n++)
                    {
                        listCampaign[n].criterios = campaignCriteria.GetCampaignCriteria(listCampaign[n].idCampania);
                        listCampaign[n].bonos = bondsEngine.GetBondsEngine(listCampaign[n].idRegla);
                        listCampaign[n].obsequios = giftsEngine.GetGiftsEngine(listCampaign[n].idRegla);
                    }
                }
            }
            catch(Exception ex)
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
