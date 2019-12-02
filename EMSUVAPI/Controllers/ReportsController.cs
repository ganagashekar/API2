using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using EMSVAPIModel.InuputModel;
using EMSVAPIModel.ResponseModels.Reports;
using EMSVU.API.Models;
using EMSVUAPIBusiness.Respositories.IServices;
using EMSVUAPIBusiness.Respositories.Services;

using Microsoft.Extensions.Logging;

namespace EMSVU.API.Controllers
{
    [RoutePrefix("api/v1/Reports")]
    public class ReportsController : ApiController
    {

        private readonly ILogger<ReportsController> _logger;

        public IReportsServices _ReportServices;
        public ICommonServices _commonServices;

        public ReportsController()
        {
          
            _ReportServices = new  ReportServices();
            _commonServices = new CommonServices();
        }


        [Route("FetchAverageReports")]
        [HttpPost]
        public async Task<HttpResponseMessage> FetchAverageReports(ReportRequestModel reportRequestModel)
        {
            var response = new SingleResponse<DataTable>();
            //DataSet dsData = new DataSet();
            //DataTable dtTable = new DataTable();
            //dtTable.Columns.Add(new DataColumn("Field1"));
            //dtTable.Columns.Add(new DataColumn("Field2"));
            //dtTable.Rows.Add("Value1","2");
            //dtTable.Rows.Add("Value2","3");
            //dtTable.Rows.Add("Value3","4");

            //dsData.Tables.Add(dtTable);


            response.Model = await _ReportServices.GetAverageReport(reportRequestModel);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [Route("ExportAverageReport")]
        [HttpPost]
        public async Task<HttpResponseMessage> ExportAverageReport(ReportRequestModel reportRequestModel)
        {
           // var response = new SingleResponse<byte[]>();

            DataTable dt = await _ReportServices.GetAverageReport(reportRequestModel);


            byte[] exportbyte = await _commonServices.ExportDataSet(dt, reportRequestModel);
            return Request.CreateResponse(HttpStatusCode.OK,exportbyte, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");


        }




        [Route("FetchLiveReports")]
        [HttpPost]
        public async Task<HttpResponseMessage> FetchLiveReports(ReportRequestModel reportRequestModel)
        {
            var response = new SingleResponse<DataTable>();



            response.Model = await _ReportServices.GetLiveReport(reportRequestModel);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [Route("ExportLiveReport")]
        [HttpPost]
        public async Task<HttpResponseMessage> ExportLiveReport(ReportRequestModel reportRequestModel)
        {
            DataTable dt = await _ReportServices.GetLiveReport(reportRequestModel);
            byte[] exportbyte = await _commonServices.ExportDataSet(dt, reportRequestModel);
            // return File(exportbyte, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            return Request.CreateResponse(HttpStatusCode.OK, exportbyte, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Route("GetExceedenceReport")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetExceedenceReport(ReportRequestModel reportRequestModel)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(GetExceedenceReport));
            var response = new SingleResponse<DataTable>();
            try
            {
                response.Model = await _ReportServices.GetExceedenceReport(reportRequestModel);
                if (response.Model.Columns.Count == 1 || response.Model == null)
                {
                    response.Model = new DataTable();
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetExceedenceReport), ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}