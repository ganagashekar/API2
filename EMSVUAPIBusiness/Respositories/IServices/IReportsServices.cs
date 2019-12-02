using EMSVAPIModel.InuputModel;
using EMSVAPIModel.ResponseModels.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EMSVUAPIBusiness.Respositories.IServices
{
  public  interface IReportsServices
    {
        Task<DataTable> GetLiveReport(ReportRequestModel reportRequestModel);

        Task<DataTable> GetAverageReport(ReportRequestModel reportRequestModel);
        Task<DataTable> GetExceedenceReport(ReportRequestModel reportRequestModel);
    }
}
