using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class CriteriaRepository : BaseRepository, ICriteriaRepository
    {
        public BaseResponse InsertCriteria(List<EntityCriteria> ListCriteria, int idRegla, int idCampania)
        {
            var entityResponse = new BaseResponse();
            var paramIns = new DynamicParameters();
            var numberOne = 1;

            var numItems = ListCriteria.Count() - numberOne;

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_INSERT_CAMPANIA_CRITERIO";

                    for (int n = 0; n <= numItems; n++)
                    {
                        paramIns.Add(
                            name: "@IDCAMPANIA",
                            value: idCampania,
                            dbType: DbType.Int32,
                            direction: ParameterDirection.Input
                            );
                        paramIns.Add(
                            name: "@IDREGLA",
                            value: idRegla,
                            dbType: DbType.Int32,
                            direction: ParameterDirection.Input
                            );
                        paramIns.Add(
                            name: "@TIPOOPERADORLOGICO",
                            value: ListCriteria[n].tipoOperadorLogico,
                            dbType: DbType.String,
                            direction: ParameterDirection.Input
                            );
                        paramIns.Add(
                            name: "@IDCAMPOREGLA",
                            value: ListCriteria[n].idCampoRegla,
                            dbType: DbType.Int32,
                            direction: ParameterDirection.Input
                            );
                        paramIns.Add(
                            name: "@VALORREGLA",
                            value: ListCriteria[n].valorRegla,
                            dbType: DbType.String,
                            direction: ParameterDirection.Input
                            );
                        paramIns.Add(
                            name: "@IDTIPOOPERADOR",
                            value: ListCriteria[n].idTipoOperador,
                            dbType: DbType.Int32,
                            direction: ParameterDirection.Input
                            );

                        dbConect.Query(
                            sql: sqlSP,
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
