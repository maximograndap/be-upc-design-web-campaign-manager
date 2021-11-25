using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class GiftsRepository : BaseRepository, IGiftsRepository
    {
        public List<EntityGifts> GetGifts(string doc)
        {
            var listGifts = new List<EntityGifts>();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CLIENTE_OBSEQUIOS";
                    var paramDoc = new DynamicParameters();
                    paramDoc.Add(
                        name: "@NUMERODOCUMENTO",
                        value: doc,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input);

                    listGifts = dbConect.Query<EntityGifts>(
                        sql: sqlSP,
                        param: paramDoc,
                        commandType: CommandType.StoredProcedure
                        ).ToList();
                }

            }
            catch (Exception ex)
            {

            }

            return listGifts;
        }
    }
}
