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
            var entityReponse = new BaseResponse();

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
                        entityReponse.issuccess = true;
                        entityReponse.errorcode = "0";
                        entityReponse.errormessage = String.Empty;
                        entityReponse.data = new {
                            id = idCampania,
                            nombreCampania = campaign.nombreCampania
                        };
                    }
                    else
                    {
                        entityReponse.issuccess = false;
                        entityReponse.errorcode = "0";
                        entityReponse.errormessage = String.Empty;
                        entityReponse.data = null;
                    }
                }
            }
            catch(Exception ex)
            {
                entityReponse.issuccess = false;
                entityReponse.errorcode = "-1";
                entityReponse.errormessage = ex.Message;
                entityReponse.data = null;
            }

            return entityReponse;
        }
    }
}
