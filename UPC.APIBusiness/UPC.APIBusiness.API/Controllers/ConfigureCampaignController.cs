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
    [Route("api/configurecampaign")]
    [ApiController]
    public class ConfigureCampaignController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IConfigureCampaignRepository _ConfigureCampaignRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConfigureCampaignRepository"></param>
        public ConfigureCampaignController(IConfigureCampaignRepository ConfigureCampaignRepository)
        {
            _ConfigureCampaignRepository = ConfigureCampaignRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configureCampaign"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insertconfigurecampaign")]
        public ActionResult InsertConfigureCampaign(EntityConfigureCampaign configureCampaign)
        {
            var returnInsConf = _ConfigureCampaignRepository.InsertConfigureCampaign(configureCampaign);
            return Json(returnInsConf);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getbenefits")]
        public ActionResult GetBenefits()
        {
            var returnBenefits = _ConfigureCampaignRepository.GetBenefits();
            return Json(returnBenefits);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcomparativeoperators")]
        public ActionResult GetComparativeOperator()
        {
            var returnComparativeOper = _ConfigureCampaignRepository.GetComparativeOperator();
            return Json(returnComparativeOper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getrulefields")]
        public ActionResult GetRuleFields()
        {
            var returnRuleFields = _ConfigureCampaignRepository.GetRuleFields();
            return Json(returnRuleFields);
        }

    }
}
