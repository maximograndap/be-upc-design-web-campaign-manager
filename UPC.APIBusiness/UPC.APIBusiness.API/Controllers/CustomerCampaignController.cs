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
    [Route("api/customercampaigns")]
    public class CustomerCampaignController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ICustomerCampaignRepository _CustomerCampaignRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerCampaignRepository"></param>
        public CustomerCampaignController(ICustomerCampaignRepository CustomerCampaignRepository)
        {
            _CustomerCampaignRepository = CustomerCampaignRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcustomercampaigns")]
        public ActionResult GetCustomerCampaigns(string doc)
        {
            var returncustomerCampaigns = _CustomerCampaignRepository.GetCustomerCampaigns(doc);

            return Json(returncustomerCampaigns);
        }
    }
}
