using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class BondsRepository : BaseRepository, IBondsRepository
    {
        public List<EntityBonds> GetBonds(string doc)
        {
            var listBonds = new List<EntityBonds>();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CLIENTE_BONOS";
                    var paramDoc = new DynamicParameters();

                    paramDoc.Add(
                        name: "@NUMERODOCUMENTO",
                        value: doc,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input);

                    listBonds = dbConect.Query<EntityBonds>(
                        sql: sqlSP,
                        param: paramDoc,
                        commandType: CommandType.StoredProcedure
                        ).ToList();
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return listBonds;
        }
    }
}
