using EMSVAPIModel;
using EMSVAPIModel.InuputModel;
using EMSVExtentions;
using EMSVUAPIBusiness.Respositories.IServices;
using EMSVWPIDataContext;
using EMSVWPIDataContext.Entities;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace EMSVUAPIBusiness.Respositories.Services
{
    public class ReferenceRecordsServices : IReferenceRecords
    {

        private readonly DatabaseContext _dbContext;

        //public ReferenceRecordsServices(DatabaseContext dbContext)
        public ReferenceRecordsServices()
        {
            //_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            _dbContext = new DatabaseContext();
        }
        public async Task<List<ReferenceRecordsModel>> GetReferenceRecords(int ReferenceTypeId, bool IncludeAll)
        {
            var referencerecords = _dbContext.Referencerecords.Where(types => types.ReferenceRecordTyepId == ReferenceTypeId).ToList();
            if (referencerecords.Any())
            {
                AddAllTOReferenceRecords(ref referencerecords);
                return await Task.FromResult(referencerecords.ToDestinationList<Referencerecords, ReferenceRecordsModel>());
            }
            return await Task.FromResult<List<ReferenceRecordsModel>>(null);
        }

        public void AddAllTOReferenceRecords(ref List<Referencerecords> referencerecords)
        {
            referencerecords.Insert(0, new Referencerecords { Name = "All", Id = 0 });
        }

        public async Task<List<ReferenceRecordsModel>> GetStacksBySite(long SiteId, long StackId, bool IncludeAll)
        {
            var dl_confgs = _dbContext.dl_confgs.Where(types => (SiteId == 0 ? true : types.site_id == SiteId) && StackId == 0 ? true : types.confg_id == StackId).ToList();
            var referencerecords = dl_confgs.Select(x => new Referencerecords { Id = x.confg_id, Name = x.stack_name }).ToList();
            if (IncludeAll)
            {
                AddAllTOReferenceRecords(ref referencerecords);
                return await Task.FromResult(referencerecords.ToDestinationList<Referencerecords, ReferenceRecordsModel>());
            }
            return await Task.FromResult<List<ReferenceRecordsModel>>(null);
        }


        public async Task<List<ReferenceRecordsModel>> GetStacks(long StackId, bool IncludeAll)
        {
            var dl_confgs = _dbContext.dl_confgs.Where(types => StackId == 0 ? true : types.confg_id == StackId).ToList();
            var referencerecords = dl_confgs.Select(x => new Referencerecords { Id = x.confg_id, Name = x.stack_name }).ToList();
            if (referencerecords.Any())
            {
                AddAllTOReferenceRecords(ref referencerecords);
                return await Task.FromResult(referencerecords.ToDestinationList<Referencerecords, ReferenceRecordsModel>());
            }
            return await Task.FromResult<List<ReferenceRecordsModel>>(null);
        }
        public async Task<List<ReferenceRecordsModel>> GetSites(long SiteId, bool IncludeAll)
        {
            var dl_sites = _dbContext.dl_sites.Where(types => SiteId == 0 ? true : types.site_id == SiteId).ToList();
            var referencerecords = dl_sites.Select(x => new Referencerecords { Id = Convert.ToInt64(x.site_id), Name = x.site_name }).ToList();
            if (referencerecords.Any() && SiteId == 0)
            {
                AddAllTOReferenceRecords(ref referencerecords);

            }
            return await Task.FromResult(referencerecords.ToDestinationList<Referencerecords, ReferenceRecordsModel>());
        }

        public async Task<List<Param_Model>> Getparamcalib(string paramname, bool IncludeAll)
        {
            var dl_param = _dbContext.dl_params.Where(types => string.IsNullOrEmpty(paramname) ? true : types.param_name == paramname).ToList();
            var referencerecords = dl_param.Select(x => new Param_Model { paramname = x.param_name }).ToList();
            if (referencerecords.Any())
            {
                //    AddAllTOReferenceRecords(ref referencerecords);

            }
            return await Task.FromResult(referencerecords);
        }
        public async Task<List<ReferenceRecordsModel>> GetParameterforStack(ParamterRequestModel paramterRequest)
        {


            var predicate = PredicateBuilder.New<dl_param>();
            if (!paramterRequest.SiteId.ToLongIsZero())
            {

                predicate = predicate.And(p => p.dl_confgs.site_id == (paramterRequest.SiteId));
            }

            if (!paramterRequest.StackId.ToLongIsZero())
            {
                predicate = predicate.And(p => p.confg_id == paramterRequest.StackId);
            }
            if (!(predicate.Parameters.Count > 0))
            {
                predicate = null;
            }
            var lstParams = _dbContext.dl_params.Include(x => x.dl_confgs).NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();
            var result = lstParams.ToList().Select(x => new Referencerecords { Id = Convert.ToInt64(x.param_id), Name = x.param_name }).ToList();
            if (paramterRequest.IncludeAll)
                AddAllTOReferenceRecords(ref result);
            return await Task.FromResult(result.ToDestinationList<Referencerecords, ReferenceRecordsModel>());
        }

        //srikanth code
        public async Task<List<ReferenceRecordsModel>> Getconfigs(long BusId, bool IncludeAll)
        {
            var dl_confgs = _dbContext.dl_controller_buss.Where(types => BusId == 0 ? true : types.bus_id == BusId).ToList();
            var referencerecords = dl_confgs.Select(x => new Referencerecords { Id = x.bus_id }).ToList();
            if (referencerecords.Any())
            {
                AddAllTOReferenceRecords(ref referencerecords);
                return await Task.FromResult(referencerecords.ToDestinationList<Referencerecords, ReferenceRecordsModel>());
            }
            return await Task.FromResult<List<ReferenceRecordsModel>>(null);
        }



        public async Task<List<control_Model>> GetCtrMacID(string macId, bool IncludeAll)
        {
            var dl_controller = _dbContext.dl_controllers.Include(x => x.dl_sites).Where(types => string.IsNullOrEmpty(macId) ? true : types.mac_id == macId).ToList();
            var referencerecords = dl_controller.Select(x => new control_Model { macId = x.mac_id }).ToList();
            if (referencerecords.Any())
            {
                // AddAllTOReferenceRecords(ref referencerecords);
                /* return await Task.FromResult(referencerecords.ToDestinationList<Referencerecords, ReferenceRecordsModel>());*/
            }
            return await Task.FromResult(referencerecords);
        }



    }
}
