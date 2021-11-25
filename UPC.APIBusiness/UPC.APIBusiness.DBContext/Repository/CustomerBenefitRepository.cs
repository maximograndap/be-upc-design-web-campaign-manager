using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class CustomerBenefitRepository : BaseRepository, ICustomerBenefitRepository
    {
        public EntityCustomerBenefit GetCustomer(string doc)
        {
            var customer = new EntityCustomerBenefit();
            var giftsCustomer = new GiftsRepository();
            var bondsCustomer = new BondsRepository();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CLIENTE";
                    var paramDoc = new DynamicParameters();
                    paramDoc.Add(
                        name: "@NUMERODOCUMENTO",
                        value: doc,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input);

                    customer = dbConect.Query<EntityCustomerBenefit>(
                        sql: sqlSP,
                        param: paramDoc,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (customer != null)
                    {
                        customer.bonos = bondsCustomer.GetBonds(customer.numeroDocumento);
                        customer.obsequios = giftsCustomer.GetGifts(customer.numeroDocumento);
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return customer;
        }
    }
}
