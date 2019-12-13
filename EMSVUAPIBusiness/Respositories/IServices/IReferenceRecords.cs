using EMSVAPIModel;
using EMSVAPIModel.InuputModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMSVUAPIBusiness.Respositories.IServices
{
   public interface IReferenceRecords
    {

        Task<List<ReferenceRecordsModel>> GetReferenceRecords(int ReferenceTypeId, bool IncludeAll);
        Task<List<ReferenceRecordsModel>> GetStacksBySite(long SiteId,long StackId, bool IncludeAll);

        Task<List<ReferenceRecordsModel>> GetStacks(long StackId, bool IncludeAll);
        Task<List<ReferenceRecordsModel>> GetSites(long StackId, bool IncludeAll);
        Task<List<ReferenceRecordsModel>> GetParameterforStack(ParamterRequestModel paramterRequest);
      
        Task<List<ReferenceRecordsModel>> Getconfigs(long BusId, bool IncludeAll);
        Task<List<control_Model>> GetCtrMacID(string macID, bool IncludeAll);
        Task<List<ReferenceRecordsModel>> Getparamcalib(long paramId, bool IncludeAll);
    }
}
