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
        public List<EntityGiftsEngine> GetGiftsEngine(int idRegla)
        {
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
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return listGiftsEngine;
        }
    }
}
