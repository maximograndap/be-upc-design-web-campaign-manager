using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class GiftsEngineRepository : BaseRepository, IGiftsEngineRepository
    {
        public BaseResponse GetGiftsEngine(int idRegla)
        {
            var entityResponse = new BaseResponse();
            var listGiftsEngine = new List<EntityGiftsEngine>();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_OBSEQUIO_ENGINE";
                    var paramGift = new DynamicParameters();

                    paramGift.Add(
                        name: "@IDREGLA",
                        value: idRegla,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );

                    listGiftsEngine = dbConect.Query<EntityGiftsEngine>(
                        sql: sqlSP,
                        param: paramGift,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (listGiftsEngine.Count() > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = listGiftsEngine;
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
