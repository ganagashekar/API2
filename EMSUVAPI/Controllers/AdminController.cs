using EMSVAPIModel;
using EMSVAPIModel.InuputModel;
using EMSVExtentions;
using EMSVU.API.Models;
using EMSVUAPIBusiness.Respositories.IServices;
using EMSVUAPIBusiness.Respositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EMSUVAPI.Controllers
{




    [System.Web.Http.RoutePrefix("api/v1/Admin")]
    public class AdminController : ApiController
    {


        public IAdminServices _adminServices;

        public IAccountServices _accountServices;
        public AdminController()
        {

            _adminServices = new AdminServices();
            _accountServices = new AccountServices();
        }




        [HttpPost]
        [Route("GetParametersAsync")]
        public async Task<HttpResponseMessage> GetParametersAsync(ParamterRequestModel paramterRequest)
        {


            var response = new PagedResponse<Param_Model>();

            List<Param_Model> lstParameters = new List<Param_Model>();
            try
            {
                // Get the stock item by id
                lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                response.PageSize = lstParameters.Count;
                response.PageNumber = 1;
                response.Model = lstParameters.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet, Route("Login")]
        public async Task<HttpResponseMessage> ValidateUser(string UserName, string Password)
        {


            var response = new SingleResponse<User_Model>();

            try
            {
                // Get the stock item by id
                var userInfo = await _accountServices.ValidateUser(UserName, Password);
                if (userInfo.IsNotNull())
                {
                    response.Model = userInfo;
                    response.Message = string.Format("LoggedIn Successfully");


                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                    response.Message = string.Format("Please Enter Valid UserName or password");
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }




        [HttpPost]
        [Route("GetConfigAsync")]
        public async Task<HttpResponseMessage> GetConfigAsync(ParamterRequestModel ConfigRequest)
        {


            var response = new PagedResponse<ConfigModel>();

            List<ConfigModel> lstconfigs = new List<ConfigModel>();
            //Sateesh Ganga
            //Sateesh Gangareddy
            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                lstconfigs = await _adminServices.GetConfigAsync(ConfigRequest);

                response.PageSize = lstconfigs.Count;
                response.PageNumber = 1;
                response.Model = lstconfigs.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("GetuserinfoAsync")]
        public async Task<HttpResponseMessage> GetuserinfoAsync(userReqModel usrReq)
        {


            var response = new PagedResponse<User_Model>();

            List<User_Model> lstParameters = new List<User_Model>();
            try
            {
                // Get the stock item by id
                lstParameters = await _adminServices.GetuserinfoAsync(usrReq);

                response.PageSize = lstParameters.Count;
                response.PageNumber = 1;
                response.Model = lstParameters.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpPost]
        [Route("SaveUserinfo")]
        public async Task<HttpResponseMessage> SaveUserinfo(User_Model userModel)
        {



            var response = new SingleResponse<long>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                long userId = await _adminServices.SaveUserinfo(userModel);


                response.Model = userId;
                if (userId > 0)
                    response.Message = string.Format("Userinfo details saved .");
                else
                    response.Message = string.Format("Userinfo saving failed or ErrorCode already exists");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpDelete]
        [Route("DeleteUserinfo")]
        public async Task<HttpResponseMessage> DeleteUserinfo(long userId)
        {


            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.DeleteUserinfo(userId);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("user Row Deleted successfully.");
                else
                    response.Message = string.Format("user Deleting  failed or Please check references again");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpPost]
        [Route("SaveParameterAsync")]
        public async Task<HttpResponseMessage> SaveParameterAsync(Param_Model paramModel)
        {



            var response = new SingleResponse<long>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                long param_Id = await _adminServices.SaveParameterAsync(paramModel);


                response.Model = param_Id;
                if (param_Id > 0)
                    response.Message = string.Format("Parameter saved successfully.");
                else
                    response.Message = string.Format("Parameter saving failed or Parameter already exists");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("DeleteParameter")]
        public async Task<HttpResponseMessage> DeleteParameter(long paramId)
        {


            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.DeleteParameter(paramId);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("Parameter Deleted successfully.");
                else
                    response.Message = string.Format("Parameter Deleting  failed or Please check references again");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpDelete]
        [Route("DeleteErrorCode")]
        public async Task<HttpResponseMessage> DeleteErrorCode(string errorcode)
        {


            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.DeleteErrorCode(errorcode);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("Errorcode Deleted successfully.");
                else
                    response.Message = string.Format("ErrorCode Deleting  failed or Please check references again");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpDelete]
        [Route("DeleteController")]
        public async Task<HttpResponseMessage> DeleteController(string MacId)
        {


            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.DeleteController(MacId);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("Controller Deleted successfully.");
                else
                    response.Message = string.Format("Controller Deleting  failed or Please check references again");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }



        [HttpDelete]
        [Route("DeleteControllerbus")]
        public async Task<HttpResponseMessage> DeleteControllerbus(int BusId)
        {


            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.DeleteControllerbus(BusId);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("Controller bus Deleted successfully.");
                else
                    response.Message = string.Format("Controller bus Deleting  failed or Please check references again");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("Deleteconfig")]
        public async Task<HttpResponseMessage> Deleteconfig(long confgId)
        {


            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.Deleteconfig(confgId);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("Config Deleted successfully.");
                else
                    response.Message = string.Format("Config Deleting  failed or Please check references again");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("Deleteaudit")]
        public async Task<HttpResponseMessage> Deleteaudit(int AuditId)
        {


            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.Deleteaudit(AuditId);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("Audit Deleted successfully.");
                else
                    response.Message = string.Format("Audit Deleting  failed or Please check references again");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("DeleteSite")]
        public async Task<HttpResponseMessage> DeleteSite(long siteId)
        {


            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.DeleteSite(siteId);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("Site Deleted successfully.");
                else
                    response.Message = string.Format("Site Deleting  failed or Please check references again");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("GeterrorcodeAsync")]
        public async Task<HttpResponseMessage> GeterrorcodeAsync(errorRequest errRequest)
        {


            var response = new PagedResponse<error_Model>();
            List<error_Model> lsterror = new List<error_Model>();
            try
            {
                // Get the stock item by id
                lsterror = await _adminServices.GeterrorcodeAsync(errRequest);

                response.PageSize = lsterror.Count;
                response.PageNumber = 1;
                response.Model = lsterror.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("SaveErrorCodeAsync")]
        public async Task<HttpResponseMessage> SaveErrorCodeAsync(error_Model errorModel)
        {



            var response = new SingleResponse<string>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                string error_code = await _adminServices.SaveErrorCodeAsync(errorModel);


                response.Model = error_code;
                if (error_code.IsNull())
                    response.Message = string.Format("ErrorCode saved .");
                else
                    response.Message = string.Format("ErrorCode saving failed or ErrorCode already exists");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("saveControllerBus")]
        public async Task<HttpResponseMessage> saveControllerBus(ControllerBus_Model contBusReq)
        {



            var response = new SingleResponse<long>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                long cntID = await _adminServices.saveControllerBus(contBusReq);


                response.Model = cntID;
                if (cntID > 0)
                    response.Message = string.Format("controllerBus details saved .");
                else
                    response.Message = string.Format("Controllerbus saving failed or ErrorCode already exists");





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("saveSite")]
        public async Task<HttpResponseMessage> saveSite(site_Model siteID)
        {



            var response = new SingleResponse<long>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                long SitesID = await _adminServices.saveSite(siteID);


                response.Model = SitesID;
                if (SitesID.IsNotNull())
                    response.Message = string.Format("site details saved .");
                else
                    response.Message = string.Format("site saving failed or ErrorCode already exists");

                // _logger?.LogInformation("The Site saved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(saveSite), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("GetApplicationLogsAsync")]
        public async Task<HttpResponseMessage> GetApplicationLogsAsync(ApplicationLogsReqModel logreq)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(GetApplicationLogsAsync));

            var response = new PagedResponse<ApplicationLogs_Model>();

            List<ApplicationLogs_Model> lstapplicationlogs = new List<ApplicationLogs_Model>();
            try
            {
                // Get the stock item by id
                lstapplicationlogs = await _adminServices.GetApplicationLogsAsync(logreq);

                response.PageSize = lstapplicationlogs.Count;
                response.PageNumber = 1;
                response.Model = lstapplicationlogs.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                // _logger?.LogInformation("The stock items have been retrieved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetApplicationLogsAsync), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("saveApplicationLogs")]
        public async Task<HttpResponseMessage> saveApplicationLogs(ApplicationLogs_Model logModel)
        {

            // _logger?.LogDebug("'{0}' has been invoked", nameof(saveApplicationLogs));

            var response = new SingleResponse<long>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                long logID = await _adminServices.saveApplicationLogs(logModel);


                response.Model = logID;
                if (logID > 0)
                    response.Message = string.Format("logs details saved .");
                else
                    response.Message = string.Format("logs saving failed or ErrorCode already exists");

                // _logger?.LogInformation("The Userinfo saved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(saveApplicationLogs), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("GetcontrollerAsync")]
        public async Task<HttpResponseMessage> GetcontrollerAsync(contrlRequestModel ctrRequest)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(GetcontrollerAsync));

            var response = new PagedResponse<control_Model>();

            List<control_Model> lstParameters = new List<control_Model>();
            try
            {
                // Get the stock item by id
                lstParameters = await _adminServices.GetcontrollerAsync(ctrRequest);

                response.PageSize = lstParameters.Count;
                response.PageNumber = 1;
                response.Model = lstParameters.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                // _logger?.LogInformation("The stock items have been retrieved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetParametersAsync), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("GetcontrollerBusAsync")]
        public async Task<HttpResponseMessage> GetcontrollerBusAsync(ControllerBusReqModel busreq)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(GetcontrollerBusAsync));

            var response = new PagedResponse<ControllerBus_Model>();

            List<ControllerBus_Model> lstcontrollerbus = new List<ControllerBus_Model>();
            try
            {
                // Get the stock item by id
                lstcontrollerbus = await _adminServices.GetcontrollerBusAsync(busreq);

                response.PageSize = lstcontrollerbus.Count;
                response.PageNumber = 1;
                response.Model = lstcontrollerbus.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                // _logger?.LogInformation("The stock items have been retrieved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetcontrollerBusAsync), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("ConfigAsync")]
        public async Task<HttpResponseMessage> ConfigAsync(ConfigReqModel configreq)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(ConfigAsync));

            var response = new PagedResponse<Confg_Model>();

            List<Confg_Model> lstapplicationlogs = new List<Confg_Model>();
            try
            {
                // Get the stock item by id
                lstapplicationlogs = await _adminServices.ConfigAsync(configreq);

                response.PageSize = lstapplicationlogs.Count;
                response.PageNumber = 1;
                response.Model = lstapplicationlogs.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                // _logger?.LogInformation("The stock items have been retrieved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(ConfigAsync), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("saveConfig")]
        public async Task<HttpResponseMessage> saveConfig(Confg_Model confReq)
        {

            // _logger?.LogDebug("'{0}' has been invoked", nameof(saveConfig));

            var response = new SingleResponse<long>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                long ConfigID = await _adminServices.saveConfig(confReq);


                response.Model = ConfigID;
                if (ConfigID > 0)
                    response.Message = string.Format("Config details saved .");
                else
                    response.Message = string.Format("Config saving failed or ErrorCode already exists");

                // _logger?.LogInformation("The Config saved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(saveConfig), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("SaveController")]
        public async Task<HttpResponseMessage> SaveController(control_Model MacID)
        {

            // _logger?.LogDebug("'{0}' has been invoked", nameof(SaveController));

            var response = new SingleResponse<string>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                string ConID = await _adminServices.SaveController(MacID);


                response.Model = ConID;
                if (ConID.IsNull())
                    response.Message = string.Format("Controller details saved .");
                else
                    response.Message = string.Format("Controller saving failed or ErrorCode already exists");

                // _logger?.LogInformation("The Controller saved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(SaveController), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpDelete]
        [Route("DeleteApplicationLog")]
        public async Task<HttpResponseMessage> DeleteApplicationLog(long logID)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(DeleteApplicationLog));

            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.DeleteApplicationLog(logID);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("log Row Deleted successfully.");
                else
                    response.Message = string.Format("log Deleting  failed or Please check references again");

                // _logger?.LogInformation(response.Message);



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(DeleteApplicationLog), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpPost]
        [Route("GetAuditAsync")]
        public async Task<HttpResponseMessage> GetAuditAsync(AuditRequst_Model aditRequest)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(GetAuditAsync));

            var response = new PagedResponse<Audit_Model>();

            List<Audit_Model> lstAudit = new List<Audit_Model>();
            try
            {
                // Get the stock item by id
                lstAudit = await _adminServices.GetAuditAsync(aditRequest);

                response.PageSize = lstAudit.Count;
                response.PageNumber = 1;
                response.Model = lstAudit.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                // _logger?.LogInformation("The stock items have been retrieved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetAuditAsync), ex);
            }


            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("GetsiteAsync")]
        public async Task<HttpResponseMessage> GetsiteAsync(siteReqmodel sitereq)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(GetsiteAsync));

            var response = new PagedResponse<site_Model>();

            List<site_Model> lstsite = new List<site_Model>();
            try
            {
                // Get the stock item by id
                lstsite = await _adminServices.GetsiteAsync(sitereq);

                response.PageSize = lstsite.Count;
                response.PageNumber = 1;
                response.Model = lstsite.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                // _logger?.LogInformation("The stock items have been retrieved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetsiteAsync), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("GetcalibrationsetupAsync")]
        public async Task<HttpResponseMessage> GetcalibrationsetupAsync(CalibrationReqModel calibRequest)
        {


            var response = new PagedResponse<Calibration_Model>();

            List<Calibration_Model> lstcalib = new List<Calibration_Model>();
            try
            {
                // Get the stock item by id
                lstcalib = await _adminServices.GetcalibrationsetupAsync(calibRequest);

                response.PageSize = lstcalib.Count;
                response.PageNumber = 1;
                response.Model = lstcalib.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("Savecalibrationsetup")]
        public async Task<HttpResponseMessage> Savecalibrationsetup(Calibration_Model calibreq)
        {



            var response = new SingleResponse<long>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                long ConfigID = await _adminServices.Savecalibrationsetup(calibreq);


                response.Model = ConfigID;
                if (ConfigID > 0)
                    response.Message = string.Format("Calibration details saved .");
                else
                    response.Message = string.Format("Calibration saving failed or Calibration already exists");




            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        //srikanth code
        [HttpPost]
        [Route("GetCalibReportAsync")]
        public async Task<HttpResponseMessage> GetCalibReportAsync(CalibReqModel calibRequest)
        {


            var response = new PagedResponse<Calib_Model>();

            List<Calib_Model> lstcalib = new List<Calib_Model>();
            try
            {
                // Get the stock item by id
                lstcalib = await _adminServices.GetCalibReportAsync(calibRequest);

                response.PageSize = lstcalib.Count;
                response.PageNumber = 1;
                response.Model = lstcalib.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpDelete]
        [Route("Deletecalibreport")]
        public async Task<HttpResponseMessage> Deletecalibreport(long calibsetupid)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(DeleteApplicationLog));

            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.Deletecalibreport(calibsetupid);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("log Row Deleted successfully.");
                else
                    response.Message = string.Format("log Deleting  failed or Please check references again");

                // _logger?.LogInformation(response.Message);



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(DeleteApplicationLog), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("Savecalibreport")]
        public async Task<HttpResponseMessage> Savecalibreport(Calib_Model calibreq)
        {



            var response = new SingleResponse<long>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                long ConfigID = await _adminServices.Savecalibreport(calibreq);


                response.Model = ConfigID;
                if (ConfigID > 0)
                    response.Message = string.Format("Calibration details saved .");
                else
                    response.Message = string.Format("Calibration saving failed or Calibration already exists");




            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("Deletecamera")]
        public async Task<HttpResponseMessage> Deletecamera(long cam_id)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(DeleteApplicationLog));

            var response = new SingleResponse<bool>();
            try
            {
                bool IsDeleted = await _adminServices.Deletecamera(cam_id);


                response.Model = IsDeleted;
                if (IsDeleted)
                    response.Message = string.Format("Camera Row Deleted successfully.");
                else
                    response.Message = string.Format("Camera Deleting  failed or Please check references again");

                // _logger?.LogInformation(response.Message);



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(DeleteApplicationLog), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("GetcameraAsync")]
        public async Task<HttpResponseMessage> GetcameraAsync(CameraRequestModel cameraRequest)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(GetcontrollerAsync));

            var response = new PagedResponse<Cameras_Model>();

            List<Cameras_Model> lstParameters = new List<Cameras_Model>();
            try
            {
                // Get the stock item by id
                lstParameters = await _adminServices.GetcameraAsync(cameraRequest);

                response.PageNumber = 1;
                response.Model = lstParameters.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                // _logger?.LogInformation("The stock items have been retrieved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetParametersAsync), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("savecamera")]
        public async Task<HttpResponseMessage> savecamera(Cameras_Model camreq)
        {

            // _logger?.LogDebug("'{0}' has been invoked", nameof(saveConfig));

            var response = new SingleResponse<long>();


            try
            {
                // Get the stock item by id
                //lstParameters = await _adminServices.GetParametersAsync(paramterRequest);

                long CamId = await _adminServices.savecamera(camreq);


                response.Model = CamId;
                if (CamId > 0)
                    response.Message = string.Format("Camera details saved .");
                else
                    response.Message = string.Format("Camera saving failed or ErrorCode already exists");

                // _logger?.LogInformation("The Config saved successfully.");



            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(saveConfig), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


    }
}
