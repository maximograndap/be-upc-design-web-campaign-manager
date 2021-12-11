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
    [Route("api/criteriaengine")]
    [ApiController]
    public class CriteriaEngineController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ICriteriaEngine _CriteriaEngine;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CriteriaEngine"></param>
        public CriteriaEngineController(ICriteriaEngine CriteriaEngine)
        {
            _CriteriaEngine = CriteriaEngine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcriteriaengine")]
        public ActionResult GetCriteriaEngine()
        {
            var returnCriteriaEngine = _CriteriaEngine.GetCriteriaEngine();
            return Json(returnCriteriaEngine);
        }
        
    }
}
