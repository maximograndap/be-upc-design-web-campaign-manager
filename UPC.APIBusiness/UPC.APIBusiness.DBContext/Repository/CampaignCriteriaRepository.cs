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
        public List<EntityCampaignCriteria> GetCampaignCriteria(int idCampania)
        {
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
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return listCriteria;
        }
    }
}
