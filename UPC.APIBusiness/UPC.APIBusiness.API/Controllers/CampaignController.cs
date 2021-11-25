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
    [Route("api/campaigns")]
    public class CampaignController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ICampaingRepository _CampaingRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CampaignRepository"></param>
        public CampaignController(ICampaingRepository CampaignRepository)
        {
            _CampaingRepository = CampaignRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcampaigns")]
        public ActionResult GetCampaings()
        {
            var returnCampaings = _CampaingRepository.GetCampaings();
            return Json(returnCampaings);
        }
    }
}
