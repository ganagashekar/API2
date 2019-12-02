using EMSVAPIModel.Dasboard;
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
    public class DashboardServices : IDashboardServices
    {
        private readonly DatabaseContext _dbContext;

        //public DashboardServices(DatabaseContext dbContext)
        public DashboardServices()
        {
            //_dbContext = dbContext;
            _dbContext = new DatabaseContext();
        }



        public async Task<List<DashboardQuickDataModel>> GetDashboardQucikDataAsync(DashboardRequestModel paramterRequest)
        {

            List<DashboardQuickDataModel> dashboardQuickDataModels = new List<DashboardQuickDataModel>();


            try
            {
                var predicate = PredicateBuilder.New<dl_data_live>();
                if (!paramterRequest.SiteId.ToLongIsZero())
                {

                    predicate = predicate.And(p => p.dl_confg.site_id == (paramterRequest.SiteId));
                }

                if (!paramterRequest.StackId.ToLongIsZero())
                {
                    predicate = predicate.And(p => p.confg_id == paramterRequest.StackId);
                }

                if (!(predicate.Parameters.Count > 0))
                {
                    predicate = null;
                }

                var dl_data = _dbContext.dl_data_live
                         .Include(x => x.dl_confg).Include(x => x.dl_param).NullSafeWhere(predicate)
                    .GroupBy(x => new { x.param_name, x.confg_id })
                          .Select(x => new DashboardQuickDataModel
                          {
                              ParamName = x.Key.param_name,
                              ParamUnits = x.FirstOrDefault().dl_param.param_unit,
                              ParamValue = x.FirstOrDefault().param_value,
                              StackName = x.FirstOrDefault().dl_confg.stack_name,
                              RecordedDate = x.FirstOrDefault().creat_ts,
                              paramminvalue = x.FirstOrDefault().dl_param.param_min_val,
                              parammaxvalue = x.FirstOrDefault().dl_param.param_max_val,
                              configId = x.Key.confg_id,
                              Status = true,
                              IsGroupby = false,
                              ThreShholdValue = x.FirstOrDefault().dl_param.threshhold_val,
                              data_id = x.FirstOrDefault().data_id
                          }).ToList();

                var afterGrouping = dl_data.GroupBy(x => new { x.StackName, x.configId }).ToList();
                foreach (var items in afterGrouping)
                {
                    DashboardQuickDataModel dashboardQuickData = new DashboardQuickDataModel();
                    dashboardQuickData.configId = items.Key.configId;
                    dashboardQuickData.StackName = items.Key.StackName;
                    dashboardQuickData.IsGroupby = true;
                    dashboardQuickDataModels.Add(dashboardQuickData);
                    dashboardQuickDataModels.AddRange(items.AsEnumerable());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }



            return await Task.FromResult(dashboardQuickDataModels);

        }

        public async Task<DashboardQuickCounts> GetDashboardQuickCountsAsync(DashboardRequestModel paramterRequest)
        {
            DashboardQuickCounts dashboardQuickCounts = new DashboardQuickCounts();
            try
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
                var lstParams = _dbContext.dl_params.AsNoTracking().Include(x => x.dl_confgs).NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                dashboardQuickCounts.StackCount = lstParams.ToList().GroupBy(x => x.dl_confgs.confg_id).Count();
                dashboardQuickCounts.ParamCount = lstParams.Count();
                dashboardQuickCounts.ExceedenceCount = 10;
                dashboardQuickCounts.AlertCount = 100;

                return await Task.FromResult(dashboardQuickCounts);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
