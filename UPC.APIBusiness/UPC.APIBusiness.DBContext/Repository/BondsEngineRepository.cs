using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class BondsEngineRepository : BaseRepository, IBondsEngineRepository
    {
        public BaseResponse GetBondsEngine(int idRegla)
        {
            var entityResponse = new BaseResponse();
            var listBonds = new List<EntityBondsEngine>();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP= @"SP_LISTA_BONOS_ENGINE";
                    var paramBonds = new DynamicParameters();

                    paramBonds.Add(
                        name: "@IDREGLA",
                        value: idRegla,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );

                    listBonds = dbConect.Query<EntityBondsEngine>(
                        sql: sqlSP,
                        param: paramBonds,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (listBonds.Count() > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = listBonds;
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
