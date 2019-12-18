using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EMSVAPIModel.Dasboard;
using EMSVAPIModel.InuputModel;
using EMSVU.API.Models;
using EMSVUAPIBusiness.Respositories.IServices;
using EMSVUAPIBusiness.Respositories.Services;

namespace EMSVU.API.Controllers
{
    [RoutePrefix("api/v1/Dashboard")]

    public class DashboardController : ApiController
    {


        public IDashboardServices _dashboardServices;


        public DashboardController()
        {


            _dashboardServices = new DashboardServices();
        }


        [HttpPost]
        [Route("GetDashboardQuickCounts")]
        public async Task<HttpResponseMessage> GetDashboardQuickCountsAsync(DashboardRequestModel requestModel)
        {


            var response = new SingleResponse<DashboardQuickCounts>();

            DashboardQuickCounts dashboardQuickCounts = new DashboardQuickCounts();
            try
            {
                // Get the stock item by id
                dashboardQuickCounts = await _dashboardServices.GetDashboardQuickCountsAsync(requestModel);



                response.Model = dashboardQuickCounts;

                response.Message = "The Data items have been retrieved successfully.";





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpPost]
        [Route("GetDashboardQuickDataChartAsync")]

        public async Task<HttpResponseMessage> GetDashboardQuickDataChartAsync(DashboardRequestModel requestModel)
        {
            var response = new PagedResponse<DashboardQuickDataModel>();

            //requestModel.fromDate = DateTime.Now.AddDays(-4);
            //requestModel.toDate = DateTime.Now.AddDays(-2);

            List<DashboardQuickDataModel> lstParameters = new List<DashboardQuickDataModel>();
            try
            {

                response.DataTable = await _dashboardServices.GetDashboardChartDayData(requestModel);
                response.PageSize = lstParameters.Count;
                response.PageNumber = 1;
                response.Model = lstParameters.ToList();
                response.Message = string.Format("Page {0} of {1}, Total of Data: {2}.", 1, 1, response.PageSize);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("GetDashboardQuickData")]
        public async Task<HttpResponseMessage> GetDashboardQuickDataAsync(DashboardRequestModel requestModel)
        {


            var response = new PagedResponse<DashboardQuickDataModel>();

            List<DashboardQuickDataModel> lstParameters = new List<DashboardQuickDataModel>();
            try
            {
                // Get the stock item by id
                lstParameters = await _dashboardServices.GetDashboardQucikDataAsync(requestModel);
                if (requestModel.IsFirst)
                {
                    response.DataTable = await _dashboardServices.GetDashboardChartDayData(requestModel);
                }
                response.PageSize = lstParameters.Count;
                response.PageNumber = 1;
                response.Model = lstParameters.ToList();

                response.Message = string.Format("Page {0} of {1}, Total of Data: {2}.", 1, 1, response.PageSize);





            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("GetCalibrationreport")]

        public async Task<HttpResponseMessage> GetCalibrationreport(DashboardRequestModel requestModel)
        {
            var response = new PagedResponse<DashboardQuickDataModel>();

            requestModel.fromDate = DateTime.Now.AddDays(-4);
            requestModel.toDate = DateTime.Now.AddDays(-2);

            List<DashboardQuickDataModel> lstParameters = new List<DashboardQuickDataModel>();
            try
            {

                response.DataTable = await _dashboardServices.GetCalibrationreport(requestModel);
                response.PageSize = lstParameters.Count;
                response.PageNumber = 1;
                response.Model = lstParameters.ToList();
                response.Message = string.Format("Page {0} of {1}, Total of Data: {2}.", 1, 1, response.PageSize);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";


            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}