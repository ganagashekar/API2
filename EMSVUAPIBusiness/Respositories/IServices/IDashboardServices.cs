using EMSVAPIModel.Dasboard;
using EMSVAPIModel.InuputModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EMSVUAPIBusiness.Respositories.IServices
{
   public interface IDashboardServices
    {
        Task<DashboardQuickCounts> GetDashboardQuickCountsAsync(DashboardRequestModel paramterRequest);

        Task<List<DashboardQuickDataModel>> GetDashboardQucikDataAsync(DashboardRequestModel Request);

        Task<DataTable> GetDashboardChartDayData(DashboardRequestModel paramterRequest);
        Task<DataTable> GetCalibReportAsync(DashboardRequestModel paramterRequest);
    }
}
