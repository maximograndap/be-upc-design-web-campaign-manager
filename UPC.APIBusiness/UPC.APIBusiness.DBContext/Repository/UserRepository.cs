using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public BaseResponse Login(EntityLoginUser login)
        {
            var entityResponse = new BaseResponse();
            var loginResponse = new EntityLoginResponse();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_USUARIO";
                    var paramLogin = new DynamicParameters();

                    paramLogin.Add(
                        name: "@USUARIO",
                        value: login.nombreUsuario,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramLogin.Add(
                        name: "@PASSWORD",
                        value: login.password,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );

                    loginResponse = dbConect.Query<EntityLoginResponse>(
                        sql: sqlSP,
                        param: paramLogin,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();
                }

                if (loginResponse != null)
                {
                    entityResponse.issuccess = true;
                    entityResponse.errorcode = "0";
                    entityResponse.errormessage = string.Empty;
                    entityResponse.data = loginResponse;
                }
                else
                {
                    entityResponse.issuccess = false;
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
