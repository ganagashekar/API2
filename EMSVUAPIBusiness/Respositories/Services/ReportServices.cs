using EMSVAPIModel.InuputModel;
using EMSVAPIModel.ResponseModels.Reports;
using EMSVExtentions;
using EMSVUAPIBusiness.Mapper;
using EMSVUAPIBusiness.Respositories.IServices;
using EMSVWPIDataContext;
using EMSVWPIDataContext.Entities;
using LinqKit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace EMSVUAPIBusiness.Respositories.Services
{
    public class ReportServices : IReportsServices
    {
        private readonly DatabaseContext _dbContext;

        public ReportServices()

        {
            _dbContext = new DatabaseContext();
        }

        public DataTable AddStackNameUnits(DataTable Dt, ReportRequestModel report)
        {
            var predicate = PredicateBuilder.New<dl_param>();
            var oldPredicate = predicate;

            if (!report.ParamId.ToLongIsZero())
            {
                predicate = predicate.And(p => p.param_id == report.ParamId);
            }
            if (!report.SiteId.ToLongIsZero())
            {

                predicate = predicate.And(p => p.dl_confgs.site_id == (report.SiteId));
            }

            if (!report.StackId.ToLongIsZero())
            {
                predicate = predicate.And(p => p.confg_id == report.StackId);
            }
            if (!(predicate.Parameters.Count > 0))
            {
                predicate = null;
            }

            var lstParams = _dbContext.dl_params.AsNoTracking().Include(x => x.dl_confgs).NullSafeWhere(predicate).ToList(); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();


            foreach (DataColumn col in Dt.Columns)
            {
                var parametersModel = lstParams.FirstOrDefault(x => x.param_name == col.ColumnName);
                if (parametersModel != null)
                    col.ColumnName = (report.IsExport ? (parametersModel.dl_confgs.IsNotNull() ? parametersModel.dl_confgs.stack_name : string.Empty) : string.Empty) + " " + parametersModel.param_name + " ( " + parametersModel.param_unit.Replace('/', '/') + " )";
            }
            return Dt;
        }
        public async Task<DataTable> GetLiveReport(ReportRequestModel reportRequestModel)
            {
            DataTable ds = new DataTable();
            SqlConnection connection = null;
            try
            {
                lock (ds)
                {
                    // _dbContext.Database.AutoTransactionsEnabled = false;
                    connection = new SqlConnection(_dbContext.Database.Connection.ConnectionString.ToString());
                    //Create Command
                    using (SqlCommand cmd = new SqlCommand("GetLiveReport", connection))
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_siteId", reportRequestModel.SiteId);
                        cmd.Parameters.AddWithValue("@_configId", reportRequestModel.StackId);
                        cmd.Parameters.AddWithValue("@_paramid", reportRequestModel.ParamId);
                        cmd.Parameters.AddWithValue("@_FromDate", reportRequestModel.FromDate);
                        cmd.Parameters.AddWithValue("@_Todate", reportRequestModel.ToDate);
                        cmd.Parameters.AddWithValue("@_time", reportRequestModel.TimePeriod);

                        cmd.Parameters.AddWithValue("@_isExport", reportRequestModel.IsExport);
                        cmd.Parameters.AddWithValue("@_Limit", reportRequestModel.StartIndex);
                        cmd.Parameters.AddWithValue("@_offset", reportRequestModel.EndIndex);


                        var dataReader = cmd.ExecuteReader();

                        ds.Load(dataReader);
                        //SqlDataAdapter sda = new SqlDataAdapter(cmd);

                        //sda.Fill(ds);

                        ////Create a data reader and Execute the command

                        connection.Close();

                    }
                }


                DataTable dt = AddStackNameUnits(ds, reportRequestModel);
                return await Task.FromResult(dt);
            }
            catch (Exception ex)
            {

                return null;
                connection.Close();
            }
            finally
            {
                ds = null;
            }
        }


        public async Task<DataTable> GetAverageReport(ReportRequestModel reportRequestModel)
        {
            DataSet ds = new DataSet();
            MySqlConnection connection = null;
            try
            {
                lock (ds)
                {
                  //  _dbContext.Database.AutoTransactionsEnabled = false;
                    connection = new MySqlConnection(_dbContext.Database.Connection.ConnectionString);
                    //Create Command
                    using (MySqlCommand cmd = new MySqlCommand("GetAverageTimeReport", connection))
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_siteId", reportRequestModel.SiteId);
                        cmd.Parameters.AddWithValue("@_configId", reportRequestModel.StackId);
                        cmd.Parameters.AddWithValue("@_paramid", reportRequestModel.ParamId);
                        cmd.Parameters.AddWithValue("@_FromDate", reportRequestModel.FromDate);
                        cmd.Parameters.AddWithValue("@_Todate", reportRequestModel.ToDate);
                        cmd.Parameters.AddWithValue("@_time", reportRequestModel.TimePeriod);

                        cmd.Parameters.AddWithValue("@_isExport", reportRequestModel.IsExport);
                        cmd.Parameters.AddWithValue("@_Limit", reportRequestModel.StartIndex);
                        cmd.Parameters.AddWithValue("@_offset", reportRequestModel.EndIndex);

                        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                        sda.Fill(ds);

                        //Create a data reader and Execute the command

                        connection.Close();

                    }
                }


                DataTable dt = AddStackNameUnits(ds.Tables[0], reportRequestModel);
                return await Task.FromResult(dt);
            }
            catch (Exception ex)
            {

                return null;
                connection.Close();
            }
            finally
            {
                ds = null;
            }
        }

        public async Task<DataTable> GetExceedenceReport(ReportRequestModel reportRequestModel)
        {
            DataSet ds = new DataSet();
            #region Comment

            //var predicate = PredicateBuilder.New<dl_data>();
            //var predicate1 = PredicateBuilder.New<dl_data_Historical>();
            //if (!reportRequestModel.StackId.ToLongIsZero())
            //{
            //    predicate = predicate.And(p => p.confg_id == reportRequestModel.StackId);
            //    predicate1 = predicate1.And(p => p.confg_id == reportRequestModel.StackId);
            //}
            //if (!reportRequestModel.SiteId.ToLongIsZero())
            //{
            //    predicate1 = predicate1.And(p => p.dl_confg.site_id == (reportRequestModel.SiteId.ToString()));
            //    predicate = predicate.And(p => p.dl_confg.site_id == (reportRequestModel.SiteId.ToString()));
            //}
            //if (!reportRequestModel.ParamId.ToLongIsZero())
            //{
            //    predicate1 = predicate1.And(p => p.confg_id == reportRequestModel.ParamId);
            //    predicate = predicate.And(p => p.confg_id == reportRequestModel.ParamId);
            //}
            //predicate1 = predicate1.And(p => p.param_value > p.dl_param.threshhold_val);
            //predicate = predicate.And(p => p.param_value > p.dl_param.threshhold_val);

            //predicate1 = predicate1.And(p => p.creat_ts >= reportRequestModel.FromDate && p.creat_ts <= reportRequestModel.ToDate);
            //predicate = predicate.And(p => p.creat_ts >= reportRequestModel.FromDate && p.creat_ts <= reportRequestModel.ToDate);



            //IQueryable<dl_data> a =  _dbContext.dl_data.Include(x => x.dl_confg).Include(x => x.dl_param).AsNoTracking().NullSafeWhere(predicate);
            //IQueryable<dl_data> b = _dbContext.dl_data_Historical.Include(x => x.dl_confg).Include(x => x.dl_param).AsNoTracking().NullSafeWhere(predicate1).Select(
            //    x => new dl_data
            //    {

            //        confg_id = x.confg_id,
            //        data_id = x.data_id,
            //        dl_param = x.dl_param,
            //        param_id = x.param_id,
            //        creat_ts = x.creat_ts,
            //        param_name = x.param_name,
            //        dl_confg = x.dl_confg,
            //        param_value = x.param_value,
            //        process_flag = x.process_flag,
            //        received_ts = x.received_ts

            //    });

            //var union = a.Union(b);
            //var result = union.ToList().Select( x=> new ExceedenceReport {

            //    Description="",
            //    ParamName=x.dl_param.param_name,
            //    ParamUnits=x.dl_param.param_unit,
            //    ParamValue=x.param_value,
            //    RecordedDate=x.creat_ts,
            //    StackName=x.dl_confg.stack_name
            //});

            //return await Task.FromResult(result.ToList());

            #endregion


            MySqlConnection connection = null;
            try
            {
                lock (ds)
                {
                    // _dbContext.Database.AutoTransactionsEnabled = false;
                    connection = new MySqlConnection(_dbContext.Database.Connection.ConnectionString);
                    //Create Command
                    using (MySqlCommand cmd = new MySqlCommand("GetExcedenceReport", connection))
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_siteId", reportRequestModel.SiteId);
                        cmd.Parameters.AddWithValue("@_configId", reportRequestModel.StackId);
                        cmd.Parameters.AddWithValue("@_paramid", reportRequestModel.ParamId);
                        cmd.Parameters.AddWithValue("@_FromDate", reportRequestModel.FromDate);
                        cmd.Parameters.AddWithValue("@_Todate", reportRequestModel.ToDate);
                        cmd.Parameters.AddWithValue("@_time", reportRequestModel.TimePeriod);

                        cmd.Parameters.AddWithValue("@_isExport", reportRequestModel.IsExport);
                        cmd.Parameters.AddWithValue("@_Limit", reportRequestModel.StartIndex);
                        cmd.Parameters.AddWithValue("@_offset", reportRequestModel.EndIndex);

                        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                        sda.Fill(ds);
                        //MySqlDataReader dataReader = cmd.ExecuteReader();
                        //exceedenceReports = dataReader.DataReaderMapToList<ExceedenceReport>();


                        connection.Close();

                    }
                }
                return await Task.FromResult(ds.Tables[0]);
            }
            catch (Exception ex)
            {

                return null;
                connection.Close();
            }
            finally
            {
                ds = null;
            }
        }
    }
}
