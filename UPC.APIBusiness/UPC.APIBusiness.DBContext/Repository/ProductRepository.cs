using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public BaseResponse DeleteProduct(int idProducto)
        {
            var entityResponse = new BaseResponse();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_DELETE_PRODUCTO";
                    var paramDel = new DynamicParameters();

                    paramDel.Add(
                        name: "@IDPRODUCTO",
                        value: idProducto,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );
                    paramDel.Add(
                        name: "@INDICADORDEL",
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Output
                        );

                    dbConect.Query(
                        sql: sqlSP,
                        param: paramDel,
                        commandType: CommandType.StoredProcedure
                        );

                    var indicadorDel = paramDel.Get<int>(
                        "@INDICADORDEL"
                        );

                    if (indicadorDel.Equals(0))
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = string.Empty;
                        entityResponse.data = new {
                            indicadorBorrado = indicadorDel,
                            mensajeBorrado = "El producto se ha desactivado correctamente"
                        };
                    }
                    else
                    {
                        entityResponse.issuccess = false;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = new {
                            indicadorBorrado = indicadorDel,
                            mensajeBorrado = "El producto no se ha desactivado correctamente o ya se encontraba desactivado"
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

        public BaseResponse GetActivesProducts()
        {
            var entityResponse = new BaseResponse();
            var listActivesProducts = new List<EntityProduct>();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_ACTIVE_PRODUCTOS";

                    listActivesProducts = dbConect.Query<EntityProduct>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();
                }

                if (listActivesProducts.Count > 0)
                {
                    entityResponse.issuccess = true;
                    entityResponse.errorcode = "0";
                    entityResponse.errormessage = String.Empty;
                    entityResponse.data = listActivesProducts;
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

        public BaseResponse GetAllProducts()
        {
            var entityResponse = new BaseResponse();
            var listAllProducts = new List<EntityProduct>();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_ALL_PRODUCTOS";

                    listAllProducts = dbConect.Query<EntityProduct>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();
                }

                if (listAllProducts.Count > 0)
                {
                    entityResponse.issuccess = true;
                    entityResponse.errorcode = "0";
                    entityResponse.errormessage = String.Empty;
                    entityResponse.data = listAllProducts;
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
                entityResponse.errorcode = "0";
                entityResponse.errormessage = ex.Message;
                entityResponse.data = null;
            }

            return entityResponse;
        }

        public BaseResponse GetProduct(int idProducto)
        {
            var entityResponse = new BaseResponse();
            var product = new EntityProduct();

            try
            {
                using (var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_OBTIENE_PRODUCTO";
                    var paramProd = new DynamicParameters();

                    paramProd.Add(
                        name: "@IDPRODUCTO",
                        value: idProducto,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );

                    product = dbConect.Query<EntityProduct>(
                        sql: sqlSP,
                        param: paramProd,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (product != null)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = product;
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

        public BaseResponse GetProductCategory()
        {
            var entityResponse = new BaseResponse();
            var listProductCategory = new List<EntityProductCategory>();

            try
            {
                using(var dbconect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_LISTA_CATEGORIA_PRODUCTO";
                    listProductCategory = dbconect.Query<EntityProductCategory>(
                        sql: sqlSP,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (listProductCategory.Count > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = listProductCategory;
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

        public BaseResponse InsertProduct(EntityProductMaintenance product)
        {
            var entityResponse = new BaseResponse();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_INSERT_PRODUCTO";
                    var paramIns = new DynamicParameters();

                    paramIns.Add(
                        name: "@NOMBREPRODUCTO",
                        value: product.nombreProducto,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramIns.Add(
                        name: "@DESCPRODUCTO",
                        value: product.descProducto,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramIns.Add(
                        name: "@PRECIOPRODUCTO",
                        value: product.precioProducto,
                        dbType: DbType.Decimal,
                        direction: ParameterDirection.Input
                        );
                    paramIns.Add(
                        name: "@IDCATEGORIAPRODUCTO",
                        value: product.idCategoriaProducto,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );
                    paramIns.Add(
                        name: "@IDPRODUCTO",
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Output
                        );

                    dbConect.Query(
                        sql: sqlSP,
                        param: paramIns,
                        commandType: CommandType.StoredProcedure
                        );

                    var idProducto = paramIns.Get<int>(
                        "@IDPRODUCTO"
                        );

                    if (idProducto > 0)
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = String.Empty;
                        entityResponse.data = new
                        {
                            id = idProducto,
                            nombreCampania = product.nombreProducto
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

        public BaseResponse UpdateProduct(EntityProductMaintenance product)
        {
            var entityResponse = new BaseResponse();

            try
            {
                using(var dbConect = GetSqlConnection())
                {
                    const string sqlSP = @"SP_UPDATE_PRODUCTO";
                    var paramUpd = new DynamicParameters();

                    paramUpd.Add(
                        name: "@IDPRODUCTO",
                        value: product.idProducto,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@NOMBREPRODUCTO",
                        value: product.nombreProducto,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@DESCPRODUCTO",
                        value: product.descProducto,
                        dbType: DbType.String,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@PRECIOPRODUCTO",
                        value: product.precioProducto,
                        dbType: DbType.Decimal,
                        direction: ParameterDirection.Input
                        );
                    paramUpd.Add(
                        name: "@IDCATEGORIAPRODUCTO",
                        value: product.idCategoriaProducto,
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

                    var indicadorAct = paramUpd.Get<int>(
                        "@INDICADORACT"
                        );

                    if (indicadorAct.Equals(0))
                    {
                        entityResponse.issuccess = true;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = string.Empty;
                        entityResponse.data = new {
                            indicadorAct = indicadorAct,
                            mensajeActualizacion = "Producto actualizado correctamente"
                        };
                    }
                    else
                    {
                        entityResponse.issuccess = false;
                        entityResponse.errorcode = "0";
                        entityResponse.errormessage = string.Empty;
                        entityResponse.data = new {
                            indicadorAct = indicadorAct,
                            mensajeActualizacion = "No se actualizo, los valores ingresados son los mismos a los actuales o ID de producto no existe"
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
