using EMSVAPIModel.InuputModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EMSVUAPIBusiness.Respositories.IServices
{
    public interface ICommonServices
    {
        Task<byte[]> ExportDataSet(DataTable ds, ReportRequestModel reportRequestModel);
    }
}
