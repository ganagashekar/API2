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
using System.Data;
using EMSVAPIModel;

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

        public async Task<DataTable> GetDashboardChartDayData(DashboardRequestModel paramterRequest)
        {
            var ReportServices = new ReportServices();
            ReportRequestModel inModel = new ReportRequestModel();
            inModel.SiteId = paramterRequest.SiteId;
            inModel.StackId = paramterRequest.StackId;
            inModel.ParamId = paramterRequest.ParamId;


            return await ReportServices.GetAverageReport(inModel);
        }

        public async Task<List<DashboardQuickDataModel>> GetDashboardQucikDataAsync(DashboardRequestModel paramterRequest)
        {

            List<DashboardQuickDataModel> dashboardQuickDataModels = new List<DashboardQuickDataModel>();


            try
            {
                var predicate = PredicateBuilder.New<dl_data_live>();
                var oldPredicate = predicate;
                if (!paramterRequest.SiteId.ToLongIsZero())
                {

                    predicate = predicate.And(p => p.dl_confg.site_id == (paramterRequest.SiteId));
                }

                if (!paramterRequest.StackId.ToLongIsZero())
                {
                    predicate = predicate.And(p => p.confg_id == paramterRequest.StackId);
                    predicate = predicate.And(p => p.dl_param.confg_id == paramterRequest.StackId);

                }

                if (oldPredicate == predicate)
                {
                    predicate = null;
                }

                var dl_data = _dbContext.dl_data_live
                         .Include(x => x.dl_confg).Include(x => x.dl_param).NullSafeWhere(predicate)
                    .GroupBy(x => new { x.param_name, x.confg_id })
                          .Select(x => new DashboardQuickDataModel
                          {
                              ParamName = x.Key.param_name,
                              paramId=x.FirstOrDefault().param_id.Value,
                              ParamUnits = x.FirstOrDefault().dl_param.param_unit,
                              ParamValue = x.FirstOrDefault().param_value,
                              StackName = x.FirstOrDefault().dl_confg.stack_name,
                              RecordedDate = x.FirstOrDefault().creat_ts,
                              paramminvalue = x.FirstOrDefault().dl_param.param_min_val,
                              parammaxvalue = x.FirstOrDefault().dl_param.param_max_val,
                              configId = x.Key.confg_id,
                              Limit=x.FirstOrDefault().dl_param.param_min_val + " - " + x.FirstOrDefault().dl_param.param_max_val,
                              Status = true,
                              IsGroupby = false,
                              color_code = x.FirstOrDefault().dl_confg.color_code,
                              ThreShholdValue = x.FirstOrDefault().dl_param.threshhold_val,
                              data_id = x.FirstOrDefault().data_id,
                              ChartSeriesName = x.FirstOrDefault().dl_confg.stack_name + "-" + x.Key.param_name + "-" + "  ( " + x.FirstOrDefault().dl_param.param_unit + " )"
                          }).ToList();

                var afterGrouping = dl_data.GroupBy(x => new { x.StackName, x.configId }).ToList();
                foreach (var items in afterGrouping)
                {
                    DashboardQuickDataModel dashboardQuickData = new DashboardQuickDataModel();
                    dashboardQuickData.configId = items.Key.configId;
                    dashboardQuickData.StackName = items.Key.StackName;
                    dashboardQuickData.color_code = items.FirstOrDefault().color_code;
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

        public async Task<DataTable> GetCalibReportAsync(DashboardRequestModel paramterRequest)
        {
            var ReportServices = new ReportServices();
            ReportRequestModel inModel = new ReportRequestModel();
            inModel.SiteId = paramterRequest.SiteId;
            inModel.StackId = paramterRequest.StackId;
            inModel.ParamId = paramterRequest.ParamId;


            return await ReportServices.GetAverageReport(inModel);
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
                var lstParams = _dbContext.dl_params.AsNoTracking().Include(x => x.dl_confgs).NullSafeWhere(predicate);
                var AddDays = DateTime.Now.AddDays(0).Date;
                var dldatacount = (from x in _dbContext.dl_data.Include(x => x.dl_param)
                                   where x.creat_ts >= AddDays && (x.dl_confg.site_id== (paramterRequest.SiteId)|| (paramterRequest.SiteId)==0) && x.dl_param != null && x.param_value > x.dl_param.threshhold_val
                                   select new DashboardExceedence
                                   {
                                       stackName = x.dl_confg.stack_name,
                                       paramname = x.dl_param.param_name,
                                       paramValue = x.param_value,
                                       //ravi code
                                       paramunit = x.dl_param.param_unit,
                                       threshholdval = x.dl_param.threshhold_val,
                                       //end code
                                       CreatedDate = x.creat_ts
                                   }).ToList();

                var dlhistoricalcount = (
                    from y in _dbContext.dl_data_Historical.Include(x => x.dl_param)
                    where y.creat_ts >= AddDays && y.dl_param != null && y.param_value > y.dl_param.threshhold_val
                    select new DashboardExceedence
                    {
                        stackName = y.dl_confg.stack_name,
                        paramname = y.dl_param.param_name,
                        paramValue = y.param_value,
                        CreatedDate = y.creat_ts,
                         //ravi code for excedence popup
                        paramunit = y.dl_param.param_unit,
                        threshholdval = y.dl_param.threshhold_val,
                    }).ToList();
                 dlhistoricalcount.AddRange(dldatacount);
                var AlarmCount = (from x in _dbContext.dl_audits
                                  where x.creat_ts >= AddDays
                                  && (x.site_id == (paramterRequest.SiteId) || (paramterRequest.SiteId) == 0)
                                  select new DashboardExceedence
                                  {
                                      paramname = x.param_name,
                                      paramValue = x.param_val,
                                      CreatedDate = x.creat_ts
                                  }).ToList();

                var configs = lstParams.ToList().GroupBy(x => x.dl_confgs.confg_id).ToList()
                    .Select(x => new ConfigModel { stackName = x.FirstOrDefault().dl_confgs.stack_name,
                    status = x.FirstOrDefault().dl_confgs.stack_status,stackType=x.FirstOrDefault().dl_confgs.stack_typ }).ToList();

                dashboardQuickCounts.StackCount = lstParams.ToList().GroupBy(x => x.dl_confgs.confg_id).Count();
                dashboardQuickCounts.ParamCount = lstParams.Count();
                dashboardQuickCounts.ExceedenceCount = dlhistoricalcount.Count();
                dashboardQuickCounts.AlertCount = AlarmCount.Count();
                dashboardQuickCounts.alarms = AlarmCount;
                dashboardQuickCounts.exceedence = dlhistoricalcount;
                dashboardQuickCounts.stations = configs;
                dashboardQuickCounts.paramters = lstParams.Select(y=> new DashboardParamModel
                {
                    stackName = y.dl_confgs.stack_name,
                    paramname = y.param_name,
                    paramRange=y.param_min_val + " - " + y.param_max_val,
                    paramunit = y.param_unit,
                    threshholdval=y.threshhold_val,
                    CreatedDate = y.creat_ts
                }).ToList();



                return await Task.FromResult(dashboardQuickCounts);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
