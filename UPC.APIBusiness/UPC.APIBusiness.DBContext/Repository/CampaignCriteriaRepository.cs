using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;


namespace DBContext
{
    public class CampaignCriteriaRepository : BaseRepository, ICampaignCriteriaRepository
    {
        public BaseResponse GetCampaignCriteria(int idCampania)
        {
            var entityResponse = new BaseResponse();
            var listCriteria = new List<EntityCampaignCriteria>();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CRITERIA_ENGINE";
                    var paramCriteria = new DynamicParameters();

                    paramCriteria.Add(
                        name: "@IDCAMPANIA",
                        value: idCampania,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );

                    listCriteria = dbConect.Query<EntityCampaignCriteria>(
                        sql: sqlSP,
                        param: paramCriteria,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (listCriteria.Count() > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = listCriteria;
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
