﻿using EMSVAPIModel.Dasboard;
using EMSVAPIModel.InuputModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace EMSVUAPIBusiness.Respositories.IServices
{
   public interface IDashboardServices
    {
        Task<DashboardQuickCounts> GetDashboardQuickCountsAsync(DashboardRequestModel paramterRequest);

        Task<List<DashboardQuickDataModel>> GetDashboardQucikDataAsync(DashboardRequestModel Request);

        Task<DataTable> GetDashboardChartDayData(DashboardRequestModel paramterRequest);
       Task<DataTable> GetCalibrationreport(DashboardRequestModel requestModel);
    }
}
