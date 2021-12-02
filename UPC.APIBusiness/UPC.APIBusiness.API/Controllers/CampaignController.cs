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
    [ApiController]
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
        [Route("getcampaignsactives")]
        public ActionResult GetCampaings()
        {
            var returnCampaings = _CampaingRepository.GetCampaingsActives();
            return Json(returnCampaings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcampaignsall")]
        public ActionResult GetCampaingsAll()
        {
            var returnCampaingsAll = _CampaingRepository.GetCampaingsAll();
            return Json(returnCampaingsAll);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcampaign")]
        public ActionResult GetCampaign(int idCampania)
        {
            var returnCampaign = _CampaingRepository.GetCampaing(idCampania);
            return Json(returnCampaign);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insertcampaign")]
        public ActionResult InsertCampaign(EntityCampaignMaintenance campaign)
        {
            var returnInsert = _CampaingRepository.InsertCampaign(campaign);
            return Json(returnInsert);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("updatecampaign")]
        public ActionResult UpdateCampaign(EntityCampaignMaintenance campaign)
        {
            var returnUpd = _CampaingRepository.UpdateCampaign(campaign);
            return Json(returnUpd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCampaign"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("deletecampaign")]
        public ActionResult DeleteCampaign(int idCampaign)
        {
            var returnDel = _CampaingRepository.DeleteCampaign(idCampaign);
            return Json(returnDel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getbenefittype")]
        public ActionResult GetBenefitType()
        {
            var returnBenefitType = _CampaingRepository.GetBenefitType();
            return Json(returnBenefitType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcampaigntype")]
        public ActionResult GetCampaignType()
        {
            var returnCampaignType = _CampaingRepository.GetCampaignType();
            return Json(returnCampaignType);
        }
    }
}
