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
            var responseCriteria = new BaseResponse();
            var responseBonds = new BaseResponse();
            var responseGifts = new BaseResponse();

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

                    if (listCampaign.Count() > 0)
                    {
                        for (int n = 0; n <= items; n++)
                        {
                            responseCriteria = campaignCriteria.GetCampaignCriteria(listCampaign[n].idCampania);
                            responseBonds = bondsEngine.GetBondsEngine(listCampaign[n].idRegla);
                            responseGifts = giftsEngine.GetGiftsEngine(listCampaign[n].idRegla);
                            listCampaign[n].criterios = responseCriteria.data as List<EntityCampaignCriteria>;
                            listCampaign[n].bonos = responseBonds.data as List<EntityBondsEngine>;
                            listCampaign[n].obsequios = responseGifts.data as List<EntityGiftsEngine>;
                        }

                        if (responseCriteria.issuccess & responseBonds.issuccess & responseGifts.issuccess)
                        {
                            entityResponse.issuccess = true;
                            entityResponse.errorcode = "0";
                            entityResponse.errormessage = string.Empty;
                            entityResponse.data = listCampaign;
                        }
                        else
                        {
                            entityResponse.issuccess = false;
                            entityResponse.errorcode = "-1";
                            entityResponse.errormessage = "ErrorCriteriaCampaign: " + responseCriteria.errormessage + " | " +
                                                          "ErrorBondsCriteria: " + responseBonds.errormessage + " | " +
                                                          "ErrorGiftsCriteria: " + responseGifts.errormessage;
                            entityResponse.data = null;
                        }
                    }
                    else
                    {
                        entityResponse.issuccess = false;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = string.Empty;
                        entityResponse.data = null;
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
