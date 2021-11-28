using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class CampaignRepository : BaseRepository, ICampaingRepository
    {
        public BaseResponse GetCampaing(int idCampania)
        {
            var entityResponse = new BaseResponse();
            var campaign = new EntityCampaing();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CAMPANIA";
                    var paramId = new DynamicParameters();
                    paramId.Add(
                        name: "@IDCAMPANIA",
                        value: idCampania,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );

                    campaign = dbConect.Query<EntityCampaing>(
                        sql: sqlSP,
                        param: paramId,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();
                }

                if (campaign != null)
                {
                    entityResponse.issuccess = true;
                    entityResponse.errorcode = "0";
                    entityResponse.errormessage = String.Empty;
                    entityResponse.data = campaign;
                }
                else
                {
                    entityResponse.issuccess = false;
                    entityResponse.errorcode = "0";
                    entityResponse.errormessage = String.Empty;
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

        public BaseResponse GetCampaingsActives()
        {
            var entityResponse = new BaseResponse();
            var listCampaigns = new List<EntityCampaing>();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CAMPANIAS_ACTIVAS";
                    listCampaigns = dbConect.Query<EntityCampaing>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (listCampaigns.Count > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = listCampaigns;
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

        public BaseResponse GetCampaingsAll()
        {
            var entityResponse = new BaseResponse();
            var listCampaignsAll = new List<EntityCampaing>();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CAMPANIAS_TODAS";
                    listCampaignsAll = dbConect.Query<EntityCampaing>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();
                }

                if (listCampaignsAll.Count > 0)
                {
                    entityResponse.issuccess = true;
                    entityResponse.errorcode = "0";
                    entityResponse.errormessage = String.Empty;
                    entityResponse.data = listCampaignsAll;
                }
                else
                {
                    entityResponse.issuccess = true;
                    entityResponse.errorcode = "0";
                    entityResponse.errormessage = String.Empty;
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

        public BaseResponse InsertCampaign(EntityCampaignMaintenance campaign)
        {
            var entityResponse = new BaseResponse();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_INSERT_CAMPANIA";
                    var paramsInsert = new DynamicParameters();

                    paramsInsert.Add(
                        name: "@NOMBRECAMPANIA",
                        value: campaign.nombreCampania,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramsInsert.Add(
                        name: "@DESCCAMPANIA",
                        value: campaign.descCampania,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramsInsert.Add(
                        name: "@FECHAINICIO",
                        value: campaign.fechaInicio,
                        dbType: DbType.DateTime,
                        direction: ParameterDirection.Input
                        );
                    paramsInsert.Add(
                        name: "@FECHAFIN",
                        value: campaign.fechaFin,
                        dbType: DbType.DateTime,
                        direction: ParameterDirection.Input
                        );
                    paramsInsert.Add(
                        name: "@IDTIPOCAMPANIA",
                        value: campaign.idTipoCampania,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );
                    paramsInsert.Add(
                        name: "@IDTIPOBENEFICIO",
                        value: campaign.idTipoBeneficio,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );
                    paramsInsert.Add(
                        name: "@IDCAMPANIA",
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Output
                        );

                    dbConect.Query(
                        sql: sqlSP,
                        param: paramsInsert,
                        commandType: CommandType.StoredProcedure
                        );

                    int idCampania = paramsInsert.Get<int>(
                        "@IDCAMPANIA"
                        );

                    if (idCampania > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = new {
                            id = idCampania,
                            nombreCampania = campaign.nombreCampania
                        };
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

        public BaseResponse UpdateCampaign(EntityCampaignMaintenance campaign)
        {
            var entityResponse = new BaseResponse();
            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_UPDATE_CAMPANIA";
                    var paramUpd = new DynamicParameters();

                    paramUpd.Add(
                        name: "@IDCAMPANIA",
                        value: campaign.idCampania,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@NOMBRECAMPANIA",
                        value: campaign.nombreCampania,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@DESCCAMPANIA",
                        value: campaign.descCampania,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@FECHAINICIO",
                        value: campaign.fechaInicio,
                        dbType: DbType.DateTime,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@FECHAFIN",
                        value: campaign.fechaFin,
                        dbType: DbType.DateTime,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@IDTIPOCAMPANIA",
                        value: campaign.idTipoCampania,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@IDTIPOBENEFICIO",
                        value: campaign.idTipoBeneficio,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@INDICADORACT",
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Output
                        );

                    dbConect.Query(
                        sql: sqlSP,
                        param: paramUpd,
                        commandType: CommandType.StoredProcedure
                        );

                    int indicadorUpd = paramUpd.Get<int>(
                        "@INDICADORACT"
                        );

                    if (indicadorUpd.Equals(0))
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = new {
                            indicadorActualizacion = indicadorUpd,
                            mensajeActualizacion = "Se actualizo correctamente"
                        };
                    }
                    else
                    {
                        entityResponse.issuccess = false;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = new
                        {
                            indicadorActualizacion = indicadorUpd,
                            mensajeActualizacion = "No se actualizo, los valores ingresados son los mismos a los actuales o ID de campaña no existe",

                        };
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
