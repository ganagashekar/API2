using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EMSVAPIModel;
using EMSVAPIModel.InuputModel;
using EMSVU.API.Models;
using EMSVUAPIBusiness.Respositories.IServices;
using EMSVUAPIBusiness.Respositories.Services;

using Microsoft.Extensions.Logging;

namespace EMSVU.API.Controllers
{
    [RoutePrefix("api/v1/ReferenceRecords")]

    public class ReferenceRecordsController : ApiController
    {

        private readonly IReferenceRecords _referenceRecordsServcie;

        public ReferenceRecordsController()
        {
            _referenceRecordsServcie = new ReferenceRecordsServices();
        }

        [Route("GetReferenceRecords")]
        public async Task<HttpResponseMessage> GetReferenceRecords(int ReferenceTypeId, bool IncludeAll)
        {
            // // _logger?.LogDebug("'{0}' has been invoked", nameof(GetReferenceRecords));

            var response = new PagedResponse<ReferenceRecordsModel>();

            try
            {
                // Get the stock item by id
                var lstParameters = await _referenceRecordsServcie.GetReferenceRecords(ReferenceTypeId, IncludeAll);

                response.PageSize = lstParameters.Count;
                response.PageNumber = 1;
                response.Model = lstParameters.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                // // _logger?.LogInformation("The stock items have been retrieved successfully.");
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetReferenceRecords), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

        [Route("GetSites")]

        public async Task<HttpResponseMessage> GetSites(int SiteId, bool IncludeAll)
        {
            // // _logger?.LogDebug("'{0}' has been invoked", nameof(GetReferenceRecords));

            var response = new PagedResponse<ReferenceRecordsModel>();

            try
            {

                var lstParameters = await _referenceRecordsServcie.GetSites(SiteId, IncludeAll);
                if (lstParameters.Any())
                {
                    response.PageSize = lstParameters.Count;
                    response.PageNumber = 1;
                    response.Model = lstParameters.ToList();

                    response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                    // // _logger?.LogInformation("The stock items have been retrieved successfully.");
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetReferenceRecords), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }


        [Route("GetStacksBySite")]
        public async Task<HttpResponseMessage> GetStacksBySite(long SiteId, int StackId, bool IncludeAll)
        {
            // // _logger?.LogDebug("'{0}' has been invoked", nameof(GetReferenceRecords));

            var response = new PagedResponse<ReferenceRecordsModel>();

            try
            {
                // Get the stock item by id
                var lstParameters = await _referenceRecordsServcie.GetStacksBySite(SiteId, StackId, IncludeAll);

                if (lstParameters.Any())
                {
                    response.PageSize = lstParameters.Count;
                    response.PageNumber = 1;
                    response.Model = lstParameters.ToList();

                    response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                    // // _logger?.LogInformation("The stock items have been retrieved successfully.");
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetReferenceRecords), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

        [Route("GetStacks")]
        public async Task<HttpResponseMessage> GetStacks(int StackId, bool IncludeAll)
        {
            // // _logger?.LogDebug("'{0}' has been invoked", nameof(GetReferenceRecords));

            var response = new PagedResponse<ReferenceRecordsModel>();

            try
            {
                // Get the stock item by id
                var lstParameters = await _referenceRecordsServcie.GetStacks(StackId, IncludeAll);

                if (lstParameters.Any())
                {
                    response.PageSize = lstParameters.Count;
                    response.PageNumber = 1;
                    response.Model = lstParameters.ToList();

                    response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                    // // _logger?.LogInformation("The stock items have been retrieved successfully.");
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetReferenceRecords), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

        [HttpPost]
        [Route("GetParameterforStack")]
        public async Task<HttpResponseMessage> GetParameterforStack(ParamterRequestModel paramterRequest)
        {
            // // _logger?.LogDebug("'{0}' has been invoked", nameof(GetReferenceRecords));

            var response = new PagedResponse<ReferenceRecordsModel>();

            try
            {
                // Get the stock item by id
                var lstParameters = await _referenceRecordsServcie.GetParameterforStack(paramterRequest);

                if (lstParameters.Any())
                {
                    response.PageSize = lstParameters.Count;
                    response.PageNumber = 1;
                    response.Model = lstParameters.ToList();

                    response.Message = string.Format("Page {0} of {1}, Total of Paramters: {2}.", 1, 1, response.PageSize);

                    // // _logger?.LogInformation("The stock items have been retrieved successfully.");
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetReferenceRecords), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }


        [Route("Getconfigs")]
        public async Task<HttpResponseMessage> Getconfigs(long BusId, bool IncludeAll)
        {
            // _logger?.LogDebug("'{0}' has been invoked", nameof(GetReferenceRecords));

            var response = new PagedResponse<ReferenceRecordsModel>();

            try
            {
                // Get the stock item by id
                var lstconfigs = await _referenceRecordsServcie.Getconfigs(BusId, IncludeAll);

                if (lstconfigs.Any())
                {
                    response.PageSize = lstconfigs.Count;
                    response.PageNumber = 1;
                    response.Model = lstconfigs.ToList();

                    response.Message = string.Format("Page {0} of {1}, Total of configs: {2}.", 1, 1, response.PageSize);

                    // _logger?.LogInformation("The stock items have been retrieved successfully.");
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetReferenceRecords), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
        ////srikanth code
        //[Route("GetcontrollerBus")]
        //public async Task<HttpResponseMessage> GetcontrollersBus(long SiteId, bool IncludeAll)
        //{
        //    // _logger?.LogDebug("'{0}' has been invoked", nameof(GetReferenceRecords));

        //    var response = new PagedResponse<ReferenceRecordsModel>();

        //    try
        //    {
        //        // Get the stock item by id
        //        var lstcontbus = await _referenceRecordsServcie.GetcontrollerBuss(SiteId, IncludeAll);

        //        if (lstcontbus.Any())
        //        {
        //            response.PageSize = lstcontbus.Count;
        //            response.PageNumber = 1;
        //            response.Model = lstcontbus.ToList();

        //            response.Message = string.Format("Page {0} of {1}, Total of configs: {2}.", 1, 1, response.PageSize);

        //            // _logger?.LogInformation("The stock items have been retrieved successfully.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.DidError = true;
        //        response.ErrorMessage = "There was an internal error, please contact to technical support.";

        //        // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetReferenceRecords), ex);
        //    }

        //    return response.ToHttpResponse();

        //}
        [Route("GetCtrMacID")]
        public async Task<HttpResponseMessage> GetCtrMacID(string macId, bool IncludeAll)
        {


            var response = new PagedResponse<control_Model>();

            try
            {
                // Get the stock item by id
                var lstconfigs = await _referenceRecordsServcie.GetCtrMacID(macId, IncludeAll);

                if (lstconfigs.Any())
                {
                    response.PageSize = lstconfigs.Count;
                    response.PageNumber = 1;
                    response.Model = lstconfigs.ToList();

                    response.Message = string.Format("Page {0} of {1}, Total of configs: {2}.", 1, 1, response.PageSize);

                    // _logger?.LogInformation("The stock items have been retrieved successfully.");
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                // _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetReferenceRecords), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }




    }
}