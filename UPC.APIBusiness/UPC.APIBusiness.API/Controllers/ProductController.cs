using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProductRepository _ProductRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductRepository"></param>
        public ProductController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        [Produces ("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getactivesproducts")]
        public ActionResult GetActivesProducts()
        {
            var returnActivesProd = _ProductRepository.GetActivesProducts();
            return Json(returnActivesProd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getallproducts")]
        public ActionResult GetAllProducts()
        {
            var returnAllProducts = _ProductRepository.GetAllProducts();
            return Json(returnAllProducts);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProduct"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproduct")]
        public ActionResult GetProduct(int idProduct)
        {
            var returnProduct = _ProductRepository.GetProduct(idProduct);
            return Json(returnProduct);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproductcategory")]
        public ActionResult GetProductCategory()
        {
            var returnProductCategory = _ProductRepository.GetProductCategory();
            return Json(returnProductCategory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insertproduct")]
        public ActionResult InsertProduct(EntityProductMaintenance product)
        {
            var identityUser = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identityUser.Claims;

            var idUsuario = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;

            product.usuarioCreacion = idUsuario;

            var returnInsertProduct = _ProductRepository.InsertProduct(product);
            return Json(returnInsertProduct);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productMaintenance"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("updateproduct")]
        public ActionResult UpdateProduct(EntityProductMaintenance productMaintenance)
        {
            var identityUser = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identityUser.Claims;

            var idUsuario = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;

            productMaintenance.usuarioActualizacion = idUsuario;

            var returnUpdateProd = _ProductRepository.UpdateProduct(productMaintenance);
            return Json(returnUpdateProd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("deleteproduct")]
        public ActionResult DeleteProduct(int idProducto)
        {
            var returnDelProd = _ProductRepository.DeleteProduct(idProducto);
            return Json(returnDelProd);
        }
    }
}
