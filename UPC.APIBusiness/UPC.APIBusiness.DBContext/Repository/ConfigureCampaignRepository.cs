using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class ConfigureCampaignRepository : BaseRepository, IConfigureCampaignRepository
    {
        public BaseResponse GetBenefits()
        {
            var entityResponse = new BaseResponse();
            var listBenefits = new List<EntityBenefit>();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_BENEFICIOS";

                    listBenefits = dbConect.Query<EntityBenefit>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (listBenefits.Count() > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = listBenefits;
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

        public BaseResponse GetComparativeOperator()
        {
            var entityResponse = new BaseResponse();
            var listComparativeOperators = new List<EntityComparativeOperator>();

            try
            {
                using (var dbconect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_OPERADOR_COMPARATIVO";

                    listComparativeOperators = dbconect.Query<EntityComparativeOperator>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (listComparativeOperators.Count() > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = string.Empty;
                        entityResponse.data = listComparativeOperators;
                    }
                    else
                    {
                        entityResponse.issuccess = false;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = string.Empty;
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

        public BaseResponse GetRuleFields()
        {
            var entityResponse = new BaseResponse();
            var listRulesFields = new List<EntityRuleField>();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CAMPO_REGLA";

                    listRulesFields = dbConect.Query<EntityRuleField>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (listRulesFields.Count() > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = string.Empty;
                        entityResponse.data = listRulesFields;
                    }
                    else
                    {
                        entityResponse.issuccess = false;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = string.Empty;
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

        public BaseResponse InsertConfigureCampaign(EntityConfigureCampaign confCampaign)
        {
            var entityResponse = new BaseResponse();
            var benefitConfig = new BeneficConfigRepository();
            var criteria = new CriteriaRepository();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_INSERT_REGLA";
                    var paramIns = new DynamicParameters();

                    paramIns.Add(
                        name: "@NOMBREREGLA",
                        value: confCampaign.nombreRegla,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramIns.Add(
                        name: "@DESCREGLA",
                        value: confCampaign.descRegla,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramIns.Add(
                        name: "@IDREGLA",
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Output
                        );

                    dbConect.Query(
                        sql: sqlSP,
                        param: paramIns,
                        commandType: CommandType.StoredProcedure
                        );

                    var idRegla = paramIns.Get<int>(
                        "@IDREGLA"
                        );

                    if (idRegla > 0)
                    {
                        var listBenefits = confCampaign.beneficios;
                        var listCriterias = confCampaign.criterios;
                        var baseBenefitConf = benefitConfig.InsertBenefitConfig(listBenefits, idRegla);
                        var baseCriteria = criteria.InsertCriteria(listCriterias, idRegla, confCampaign.idCampania);

                        if (baseBenefitConf.issuccess & baseCriteria.issuccess)
                        {
                            entityResponse.issuccess = true;
                            entityResponse.errorcode = "0";
                            entityResponse.errormessage = string.Empty;
                            entityResponse.data = null;
                        }
                        else
                        {
                            entityResponse.issuccess = false;
                            entityResponse.errorcode = "-1";
                            entityResponse.errormessage = "ErrorInsertBeneficios: " + baseBenefitConf.errormessage + " | ErrorInsertCriterios: " + baseCriteria.errormessage;
                            entityResponse.data = null;
                        }
                    }
                    else
                    {
                        entityResponse.issuccess = false;
                        entityResponse.errorcode = "-1";
                        entityResponse.errormessage = string.Empty;
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
