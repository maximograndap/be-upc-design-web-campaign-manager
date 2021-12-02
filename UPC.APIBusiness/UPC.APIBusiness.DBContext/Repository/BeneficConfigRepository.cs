using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class BeneficConfigRepository : BaseRepository, IBenefitConfigRepository
    {
        public BaseResponse InsertBenefitConfig(List<EntityBenefitConfig> ListBenefitConfig, int idRegla)
        {
            var entityResponse = new BaseResponse();
            var paramIns = new DynamicParameters();
            var numberOne = 1;

            var numItems = ListBenefitConfig.Count() - numberOne;

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSpInsBonoObs = @"SP_INSERT_REGLA_OBSEQUIO_BONO";

                    for (int n = 0; n <= numItems; n++)
                    {
                        paramIns.Add(
                            name: "@IDREGLA",
                            value: idRegla,
                            dbType: DbType.Int32,
                            direction: ParameterDirection.Input
                        );
                        paramIns.Add(
                            name: "@IDBENEFICIO",
                            value: ListBenefitConfig[n].idBeneficio,
                            dbType: DbType.String,
                            direction: ParameterDirection.Input
                            );
                        paramIns.Add(
                            name: "@IDPRODUCTO",
                            value: ListBenefitConfig[n].idProducto,
                            dbType: DbType.Int32,
                            direction: ParameterDirection.Input
                            );

                       dbConect.Query(
                            sql: sqlSpInsBonoObs,
                            param: paramIns,
                            commandType: CommandType.StoredProcedure
                            );
                    }

                    entityResponse.issuccess = true;
                    entityResponse.errorcode = "0";
                    entityResponse.errormessage = string.Empty;
                    entityResponse.data = null;
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
