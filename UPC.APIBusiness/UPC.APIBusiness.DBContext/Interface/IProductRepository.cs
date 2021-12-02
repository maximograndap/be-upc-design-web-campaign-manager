using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IProductRepository
    {
        BaseResponse GetAllProducts();
        BaseResponse GetActivesProducts();
        BaseResponse GetProduct(int idProducto);
        BaseResponse GetProductCategory();
        BaseResponse InsertProduct(EntityProductMaintenance product);
        BaseResponse UpdateProduct(EntityProductMaintenance product);
        BaseResponse DeleteProduct(int idProducto);
    }
}
