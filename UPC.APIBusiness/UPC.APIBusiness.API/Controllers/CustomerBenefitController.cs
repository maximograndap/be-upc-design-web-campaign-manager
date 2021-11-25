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
    [Route("api/customerbenefit")]
    public class CustomerBenefitController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ICustomerBenefitRepository _CustomerBenefitRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerBenefitRepository"></param>
        public CustomerBenefitController(ICustomerBenefitRepository CustomerBenefitRepository)
        {
            _CustomerBenefitRepository = CustomerBenefitRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcustomerbenefit")]
        public ActionResult GetCustomer(string doc)
        {
            var returnCustomerBenefit = _CustomerBenefitRepository.GetCustomer(doc);

            return Json(returnCustomerBenefit);
        }
    }
}
