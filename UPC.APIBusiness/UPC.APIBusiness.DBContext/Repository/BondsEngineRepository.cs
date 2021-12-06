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
        public List<EntityBondsEngine> GetBondsEngine(int idRegla)
        {
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
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return listBonds;
        }
    }
}
