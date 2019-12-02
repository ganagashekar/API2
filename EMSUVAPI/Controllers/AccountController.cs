using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EMSVUAPIBusiness.Respositories.IServices;
using EMSVUAPIBusiness.Respositories.Services;
using Microsoft.Extensions.Logging;
using EMSVU.API.Models;
using EMSVExtentions;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using EMSVAPIModel;

namespace EMSUVAPI.Controllers
{

    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {

     //   private readonly ILogger<AccountController> _logger;

        public IAccountServices _accountServices;

        public AccountController()
        {
            _accountServices = new AccountServices();


        }

        //public AccountController(ILogger<AccountController> logger, IAccountServices accountServices)
        //{
        //    _logger = logger;
        //    _accountServices = accountServices;
        //}



       [HttpGet, Route("ValidateUser")]
        public async Task<HttpResponseMessage> ValidateUser(string UserName, string Password)
        {
           // _logger?.LogDebug("'{0}' has been invoked", nameof(ValidateUser));

            var response = new SingleResponse<User_Model>();

            try
            {
                // Get the stock item by id
                var userInfo = await _accountServices.ValidateUser(UserName, Password);
                if (userInfo.IsNotNull())
                {
                    response.Model = userInfo;
                    response.Message = string.Format("LoggedIn Successfully");

                //    _logger?.LogInformation("LoggedIn Successfully.");
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else

                response.Message = string.Format("Please Enter Valid UserName or password");
                return Request.CreateResponse(HttpStatusCode.Unauthorized, response);

            }
            catch (Exception ex)
            {

                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
               // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(ValidateUser), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}