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
using CampaignManager.APIBusiness.API.Security;

namespace UPC.Business.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(EntityLoginUser login)
        {
            var returnLogin = _UserRepository.Login(login);

            if (returnLogin.data != null)
            {
                var loginResponse = returnLogin.data as EntityLoginResponse;
                var idUser = loginResponse.idUsuario.ToString();
                var documentUser = loginResponse.numeroDocumento;

                var tokenGenerate = JsonConvert.DeserializeObject<AccessToken>(
                    await new Authentication().GenerateToken(documentUser, idUser)
                    ).access_token;

                loginResponse.token = tokenGenerate;
                returnLogin.data = loginResponse;
            }

            return Json(returnLogin);
        }
    }
}