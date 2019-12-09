

using EMSVUAPIBusiness.Respositories.IServices;
using EMSVWPIDataContext;
using EMSVWPIDataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSVAPIModel;
using EMSVExtentions;
using EMSVAPIModel.InuputModel;
using LinqKit;
using System.Data.Entity;

namespace EMSVUAPIBusiness.Respositories.Services
{
    public class AdminServices : IAdminServices
    {

        private readonly DatabaseContext _dbContext;

        public AdminServices()
        {
            _dbContext = new DatabaseContext();
            //_dbContext = dbContext;
        }
        //public AdminServices(DatabaseContext dbContext)

        //{
        //    _dbContext =   dbContext;
        //}



        public async Task<List<ConfigModel>> GetConfigAsync(ParamterRequestModel configRequest)
        {
            try
            {
                var searchCriteria = new
                {
                    ConfigId = configRequest.StackId,
                    SiteId = configRequest.SiteId
                };

                var predicate = PredicateBuilder.New<dl_confg>();
                if (!configRequest.SiteId.ToLongIsZero())
                {
                    predicate = predicate.And(p => p.dl_site.site_id == (configRequest.SiteId));
                }

                if (!configRequest.StackId.ToLongIsZero())
                {
                    predicate = predicate.And(p => p.confg_id == configRequest.StackId);
                }
                else
                {
                    predicate = null;
                }

                var lstParams = _dbContext.dl_confgs.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                var Data = lstParams.Select(x => new ConfigModel { stackName = x.stack_name, stackType = x.stack_typ }).ToList();
                // var data=  lstParams.ToDestinationList<dl_confg, ConfigModel>();

                return await Task.FromResult(Data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Param_Model>> GetParametersAsync(ParamterRequestModel paramterRequest)
        {
            try
            {



                var searchCriteria = new
                {
                    ConfigId = paramterRequest.StackId,
                    SiteId = paramterRequest.SiteId
                };

                var predicate = PredicateBuilder.New<dl_param>();
                if (!paramterRequest.SiteId.ToLongIsZero())
                {

                    predicate = predicate.And(p => p.dl_confgs.site_id == (paramterRequest.SiteId));
                }

                if (!paramterRequest.StackId.ToLongIsZero())
                {
                    predicate = predicate.And(p => p.confg_id == paramterRequest.StackId);
                }
                else
                {
                    predicate = null;
                }





                var lstParams = _dbContext.dl_params.Include(x => x.dl_confgs).NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                return await Task.FromResult(lstParams.ToDestinationList<dl_param, Param_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<User_Model>> GetuserinfoAsync(userReqModel usrReq)
        {
            try
            {
                var predicate = PredicateBuilder.New<dl_usr>();
                predicate = null;
                var lstParams = _dbContext.dl_usrs.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                return await Task.FromResult(lstParams.ToDestinationList<dl_usr, User_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<long> SaveUserinfo(User_Model userReq)
        {
            try
            {
                var userinfoModel = await _dbContext.dl_usrs.FirstOrDefaultAsync(x => x.usr_id == userReq.UserId);
                if (userinfoModel.IsNull())
                {
                    userinfoModel = new dl_usr();
                    _dbContext.dl_usrs.Add(userinfoModel);
                    userinfoModel.updt_ts = DateTime.Now;
                }
                userinfoModel.usr_id = userReq.UserId;
                userinfoModel.usr_name = userReq.UserName;
                userinfoModel.pass = userReq.UserPass.Encrypt();
                userinfoModel.is_enabled = userReq.IsEnabled;
                // userinfoModel.vendor_site_id = userReq.VendorSiteId;
                userinfoModel.updt_ts = DateTime.Now;
                userinfoModel.creat_ts = DateTime.Now;
                _dbContext.SaveChanges();

                return userinfoModel.usr_id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<bool> DeleteUserinfo(long userId)
        {
            try
            {
                var userModel = await _dbContext.dl_usrs.FirstOrDefaultAsync(x => x.usr_id == userId);
                if (userModel.IsNotNull())
                {
                    _dbContext.dl_usrs.Remove(userModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<long> SaveParameterAsync(Param_Model paramReqModel)
        {
            try
            {
                var paramsModel = await _dbContext.dl_params.FirstOrDefaultAsync(x => x.param_id == paramReqModel.paramid);
                if (paramsModel.IsNull())
                {
                    paramsModel = new dl_param();
                    _dbContext.dl_params.Add(paramsModel);
                    paramsModel.creat_ts = DateTime.Now;
                }
                paramsModel.param_max_val = paramReqModel.parammaxval;
                paramsModel.param_min_val = paramReqModel.paramminval;
                paramsModel.param_name = paramReqModel.paramname;
                paramsModel.param_position = paramReqModel.paramposition;
                paramsModel.param_unit = paramReqModel.paramunit;
                paramsModel.threshhold_val = paramReqModel.threshholdval;
                paramsModel.updt_ts = DateTime.Now;
                paramsModel.confg_id = paramReqModel.confgid;
                _dbContext.SaveChanges();

                return paramsModel.param_id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<bool> DeleteParameter(long paramId)
        {
            try
            {
                var paramsModel = await _dbContext.dl_params.FirstOrDefaultAsync(x => x.param_id == paramId);
                if (paramsModel.IsNotNull())
                {
                    _dbContext.dl_params.Remove(paramsModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<error_Model>> GeterrorcodeAsync(errorRequest errRequest)
        {
            try
            {
                var predicate = PredicateBuilder.New<dl_error_cd>();
                predicate = null;
                var lsterror = _dbContext.dl_errors.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                return await Task.FromResult(lsterror.ToDestinationList<dl_error_cd, error_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> SaveErrorCodeAsync(error_Model errorReq)
        {
            try
            {
                var errorcodeModel = await _dbContext.dl_errors.FirstOrDefaultAsync(x => x.error_code == errorReq.errorcode);
                if (errorcodeModel.IsNull())
                {
                    errorcodeModel = new dl_error_cd();
                    _dbContext.dl_errors.Add(errorcodeModel);
                    errorcodeModel.updt_ts = DateTime.Now;
                }
                errorcodeModel.error_code = errorReq.errorcode;
                errorcodeModel.error_desc = errorReq.errordesc;
                errorcodeModel.updt_ts = DateTime.Now;
                _dbContext.SaveChanges();

                return errorcodeModel.error_code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteErrorCode(string errorcode)
        {
            try
            {
                var errorModel = await _dbContext.dl_errors.FirstOrDefaultAsync(x => x.error_code == errorcode);
                if (errorModel.IsNotNull())
                {
                    _dbContext.dl_errors.Remove(errorModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteControllerbus(int BusId)
        {
            try
            {
                var errorModel = await _dbContext.dl_controller_buss.FirstOrDefaultAsync(x => x.bus_id == BusId);
                if (errorModel.IsNotNull())
                {
                    _dbContext.dl_controller_buss.Remove(errorModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<long> saveControllerBus(ControllerBus_Model conBusReq)
        {
            try
            {
                var ConBusModel = await _dbContext.dl_controller_buss.FirstOrDefaultAsync(x => x.bus_id == conBusReq.busId);
                if (ConBusModel.IsNull())
                {
                    ConBusModel = new dl_controller_bus();
                    _dbContext.dl_controller_buss.Add(ConBusModel);
                    // ConBusModel.creat_ts = DateTime.Now;
                }
                ConBusModel.bus_id = conBusReq.busId;
                ConBusModel.mac_id = conBusReq.macId;
                ConBusModel.protocal = conBusReq.protocal;
                ConBusModel.com_port = conBusReq.comPort;
                ConBusModel.baud_rate = conBusReq.baudrate;
                ConBusModel.time_out = conBusReq.timeOut;
                ConBusModel.data_byte_stat_indx = conBusReq.startIndex;

                ConBusModel.updt_ts = DateTime.Now;
                _dbContext.SaveChanges();

                return ConBusModel.bus_id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<long> saveConfig(Confg_Model confReq)
        {
            try
            {
                var ConfigModel = await _dbContext.dl_confgs.FirstOrDefaultAsync(x => x.confg_id == confReq.confgId);
                if (ConfigModel.IsNull())
                {
                    ConfigModel = new dl_confg();
                    _dbContext.dl_confgs.Add(ConfigModel);
                    ConfigModel.creat_ts = DateTime.Now;
                }
                ConfigModel.confg_id = confReq.confgId;
                ConfigModel.site_id = confReq.siteId;
                ConfigModel.bus_id = confReq.busId;
                //ConfigModel.vendor = confReq.vendorID;
                ConfigModel.stack_name = confReq.stack_name;
                ConfigModel.stack_typ = confReq.stack_typ;
                ConfigModel.stack_status = confReq.stack_status;
                ConfigModel.input_format = confReq.input_format;
                ConfigModel.output_format = confReq.output_format;
                ConfigModel.cnfg_slave_id = confReq.slaveid;
                ConfigModel.cnfg_hold_reg = confReq.holdingreg;
                ConfigModel.cnfg_reg_first = confReq.firstreg;
                ConfigModel.disp_output_typ = confReq.displayoutputtype;
                ConfigModel.cnfg_reg_len = confReq.bytestoread;
                ConfigModel.cnfg_input_str = confReq.inputstringtoread;


                ConfigModel.creat_ts = DateTime.Now;
                _dbContext.SaveChanges();

                return ConfigModel.confg_id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<string> SaveController(control_Model MacID)
        {
            try
            {
                var ConModel = await _dbContext.dl_controllers.FirstOrDefaultAsync(x => x.mac_id == MacID.macId);
                if (ConModel.IsNull())
                {
                    ConModel = new dl_controller();
                    _dbContext.dl_controllers.Add(ConModel);
                    // ConModel.creat_ts = DateTime.Now;
                }
                ConModel.mac_id = MacID.macId;
                ConModel.site_id = MacID.SiteId;
                ConModel.os_typ = MacID.osType;
                ConModel.cpcb_url = MacID.cpcbUrl;
                ConModel.spcb_url = MacID.spcburl;
                ConModel.license_key = MacID.licenseKey;

                ConModel.updt_ts = DateTime.Now;
                _dbContext.SaveChanges();

                return ConModel.mac_id;
            }
            catch (Exception ex)
            {
                throw ex; ;
            }
        }
        public async Task<bool> DeleteApplicationLog(long logID)
        {
            try
            {
                var logModel = await _dbContext.dl_logs.FirstOrDefaultAsync(x => x.log_id == logID);
                if (logModel.IsNotNull())
                {
                    _dbContext.dl_logs.Remove(logModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Deletecalibration(long calib_cmd_id)
        {
            try
            {
                var logModel = await _dbContext.dl_calib_cmd_setups.FirstOrDefaultAsync(x => x.calib_cmd_id == calib_cmd_id);
                if (logModel.IsNotNull())
                {
                    _dbContext.dl_calib_cmd_setups.Remove(logModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<long> saveSite(site_Model siteID)
        {
            try
            {
                var siteModel = await _dbContext.dl_sites.FirstOrDefaultAsync(x => x.site_id == siteID.siteId);
                if (siteModel.IsNull())
                {
                    siteModel = new dl_site();
                    _dbContext.dl_sites.Add(siteModel);
                     siteModel.creat_ts = DateTime.Now;
                }
               
                siteModel.site_name = siteID.siteName;
                siteModel.site_cpcb_cd = siteID.site_cpcb_cd;
                siteModel.site_in_ganga_basin = siteID.site_in_ganga_basin;
                siteModel.site_city = siteID.site_city;
                siteModel.site_state = siteID.site_state;
                siteModel.site_country = siteID.site_country;
                siteModel.site_logo = siteID.siteLogo;
                siteModel.site_ind_type = siteID.IndustryType;
                siteModel.site_prmry_cnct_ph_num = siteID.SitePrimaryContactPhone;
                siteModel.site_second_cnct_name = siteID.SiteSecondaryContactName;
                siteModel.site_second_cnct_email = siteID.SiteSecondaryContactEmail;
                siteModel.site_latitude = siteID.SiteLatitude;
                siteModel.site_longitude = siteID.SiteLongitude;
                siteModel.site_prmry_cnct_name = siteID.SitePrimaryContactName;
                siteModel.site_prmry_cnct_email = siteID.SitePrimaryContactEmail;
                siteModel.site_second_cnct_ph_num = siteID.SiteSecondaryContactPhone;
                siteModel.site_addr_1 = siteID.siteAddress1;
                siteModel.site_addr_2 = siteID.siteAddress2;
                siteModel.site_district = siteID.site_District;
                siteModel.site_pin_cd = siteID.sitePinCode;

                siteModel.updt_ts = DateTime.Now;
                _dbContext.SaveChanges();

                return siteModel.site_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ApplicationLogs_Model>> GetApplicationLogsAsync(ApplicationLogsReqModel logreq)
        {
            try
            {
                var predicate = PredicateBuilder.New<dl_log>();
                predicate = null;
                var lstapplicationlogs = _dbContext.dl_logs.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                return await Task.FromResult(lstapplicationlogs.ToDestinationList<dl_log, ApplicationLogs_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Confg_Model>> ConfigAsync(ConfigReqModel configreq)
        {
            try
            {
                //var searchCriteria = new
                //{
                //    ConfigId = configreq.busID,
                //    SiteId = configreq.confgID
                //};

                var predicate = PredicateBuilder.New<dl_confg>();
                // predicate = null;
                if (!configreq.busID.ToLongIsZero())
                {
                    predicate = predicate.And(p => p.bus_id == configreq.busID);
                }
                else
                {
                    predicate = null;
                }
                var lstconfig = _dbContext.dl_confgs.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                return await Task.FromResult(lstconfig.ToDestinationList<dl_confg, Confg_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<long> saveApplicationLogs(ApplicationLogs_Model logModel)
        {
            try
            {
                var logsModel = await _dbContext.dl_logs.FirstOrDefaultAsync(x => x.log_id == logModel.logID);
                if (logsModel.IsNull())
                {
                    logsModel = new dl_log();
                    _dbContext.dl_logs.Add(logsModel);
                    //  logsModel.createts = DateTime.Now;
                }
                logsModel.log_id = logModel.logID;
                logsModel.confg_id = logModel.confgID;
                logsModel.error_code = logModel.errorCode;
                logsModel.creat_ts = DateTime.Now;

                _dbContext.SaveChanges();

                return logsModel.log_id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<bool> DeleteController(string MacId)
        {
            try
            {
                var controllerModel = await _dbContext.dl_controllers.FirstOrDefaultAsync(x => x.mac_id == MacId);
                if (controllerModel.IsNotNull())
                {
                    _dbContext.dl_controllers.Remove(controllerModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Deleteconfig(long confgId)
        {
            try
            {
                var controllerModel = await _dbContext.dl_confgs.FirstOrDefaultAsync(x => x.confg_id == confgId);
                if (controllerModel.IsNotNull())
                {
                    _dbContext.dl_confgs.Remove(controllerModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Deleteaudit(int AuditId)
        {
            try
            {
                var controllerModel = await _dbContext.dl_audits.FirstOrDefaultAsync(x => x.audit_id == AuditId);
                if (controllerModel.IsNotNull())
                {
                    _dbContext.dl_audits.Remove(controllerModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSite(long siteId)
        {
            try
            {
                var controllerModel = await _dbContext.dl_sites.FirstOrDefaultAsync(x => x.site_id == siteId);
                if (controllerModel.IsNotNull())
                {
                    _dbContext.dl_sites.Remove(controllerModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<control_Model>> GetcontrollerAsync(contrlRequestModel ctrRequest)
        {
            try
            {
                var searchCriteria = new
                {
                    SiteId = ctrRequest.SiteId
                };

                var predicate = PredicateBuilder.New<dl_controller>();
                if (!ctrRequest.SiteId.ToLongIsZero())
                {
                    predicate = predicate.And(p => p.site_id == ctrRequest.SiteId);
                }
                else
                {
                    predicate = null;
                }


                var lstParams = _dbContext.dl_controllers.Include(x => x.dl_sites).NullSafeWhere(predicate); ; //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();
                lstParams.ToDestinationList<dl_controller, control_Model>();
                return await Task.FromResult(lstParams.ToDestinationList<dl_controller, control_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<site_Model>> GetsiteAsync(siteReqmodel sitereq)
        {
            try
            {
                var predicate = PredicateBuilder.New<dl_site>();
                predicate = null;
                var lstsite = _dbContext.dl_sites.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                return await Task.FromResult(lstsite.ToDestinationList<dl_site, site_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ControllerBus_Model>> GetcontrollerBusAsync(ControllerBusReqModel ctrBusRequest)
        {
            try
            {
                var predicate = PredicateBuilder.New<dl_controller_bus>();
                if (!ctrBusRequest.macId.ToStringIsZero())
                {
                    predicate = predicate.And(p => p.mac_id == ctrBusRequest.macId);
                }
                else
                {
                    predicate = null;
                }
                predicate = null;

                var lstcontrollerbus = _dbContext.dl_controller_buss.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                return await Task.FromResult(lstcontrollerbus.ToDestinationList<dl_controller_bus, ControllerBus_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Confg_Model>> GetConfigAsync(ConfigReqModel configreq)
        {
            try
            {
                var predicate = PredicateBuilder.New<dl_confg>();
                predicate = null;
                var lstconfig = _dbContext.dl_confgs.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                return await Task.FromResult(lstconfig.ToDestinationList<dl_confg, Confg_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Audit_Model>> GetAuditAsync(AuditRequst_Model auditRequst)
        {
            try
            {
                var predicate = PredicateBuilder.New<dl_audit>();
                predicate = null;
                var lstAudit = _dbContext.dl_audits.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();
                                                                              //  var return= lstAudit.ToString().Select(< x=>new Audit_Model { AuditId = x.audit_id });

                return await Task.FromResult(lstAudit.ToDestinationList<dl_audit, Audit_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<Calibration_Model>> GetcalibrationsetupAsync(CalibrationReqModel calibRequest)
        {
            try
            {
                var predicate = PredicateBuilder.New<dl_calib_cmd_setup>();
                predicate = null;
                var lstcalib = _dbContext.dl_calib_cmd_setups.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();
                lstcalib.ToDestinationList<dl_calib_cmd_setup, Calibration_Model>();
                return await Task.FromResult(lstcalib.ToDestinationList<dl_calib_cmd_setup, Calibration_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<long> Savecalibrationsetup(Calibration_Model calibreq)
        {
            try
            {

                var CalibModel = await _dbContext.dl_calib_cmd_setups.FirstOrDefaultAsync(x => x.confg_id == calibreq.confg_id);
                if (CalibModel.IsNull())
                {
                    CalibModel = new dl_calib_cmd_setup();
                    _dbContext.dl_calib_cmd_setups.Add(CalibModel);
                    CalibModel.creat_ts = DateTime.Now;
                }
                CalibModel.confg_id = calibreq.confg_id;
                //CalibModel.dl_site.site_id = calibreq.site_id;
                CalibModel.stack_name = calibreq.stack_name;
                CalibModel.param_name = calibreq.param_name;
                CalibModel.ca_set_zero_relay_open_cmd = calibreq.zeroRelayOpenCmd;
                //ConfigModel.vendor = confReq.vendorID;
                CalibModel.ca_set_zero_relay_open_resp = calibreq.zeroRelayOpenResp;
                CalibModel.ca_set_zero_cmd = calibreq.setZeroCmd;
                CalibModel.ca_set_zero_resp = calibreq.setZeroResp;
                CalibModel.ca_set_zero_relay_close_cmd = calibreq.zeroRelayCloseCmd;
                CalibModel.ca_set_zero_relay_close_resp = calibreq.zeroRelayCloseResp;
                CalibModel.ca_read_prev_value_cmd = calibreq.readPrevValueCmd;
                CalibModel.ca_read_prev_value_res = calibreq.readPrevValueRes;
                CalibModel.ca_real_gas_relay_open_cmd = calibreq.realGasRelayOpenCmd;
                CalibModel.ca_real_gas_relay_open_resp = calibreq.realGasRelayOpenResp;
                CalibModel.ca_real_gas_relay_close_cmd = calibreq.realGasRelayCloseCmd;
                CalibModel.ca_real_gas_relay_close_resp = calibreq.real_GasRelayCloseResp;
                CalibModel.ca_set_new_value_cmd = calibreq.setNewValueCmd;
                CalibModel.ca_set_new_value_resp = calibreq.setNewValueResp;
                CalibModel.ca_set_make_span_cmd = calibreq.setMakeSpanCmd;
                CalibModel.ca_set_make_span_resp = calibreq.setMakeSpanResp;


                CalibModel.updt_ts = DateTime.Now;
                _dbContext.SaveChanges();

                return CalibModel.confg_id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<List<Calib_Model>> GetCalibReportAsync(CalibReqModel calibRequest)
        {
            try
            {
                var predicate = PredicateBuilder.New<dl_calibration>();
                predicate = null;
                var lstcalib = _dbContext.dl_calibrations.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                return await Task.FromResult(lstcalib.ToDestinationList<dl_calibration, Calib_Model>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<sitesModel>> Getsitescalib(CalibReqModel calibRequest)
        {
            try
            {
                //var searchCriteria = new
                //{
                //    ConfigId = calibRequest.StackId,
                //    SiteId = calibRequest.SiteId
                //};

                var predicate = PredicateBuilder.New<dl_site>();
                //if (!calibRequest.siteId.ToLongIsZero())
                //{
                //    predicate = predicate.And(p => p.dl_site.site_id == (calibRequest.SiteId));
                //}

                //if (!calibRequest.StackId.ToLongIsZero())
                //{
                //    predicate = predicate.And(p => p.confg_id == calibRequest.StackId);
                //}
                //else
                //{
                //    predicate = null;
                //}
                predicate = null;

                var lstParams = _dbContext.dl_sites.NullSafeWhere(predicate); //.Where(x => paramterRequest.StackId != 0 && x.confg_id == paramterRequest.StackId && paramterRequest.SiteId != 0 && x.dl_confg.site_id == paramterRequest.SiteId.ToString()).ToList();

                var Data = lstParams.Select(x => new sitesModel { siteName = x.site_name, siteId = x.site_id }).ToList();
                // var data=  lstParams.ToDestinationList<dl_site, sitesModel>();

                return await Task.FromResult(Data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<bool> Deletecalibreport(long calibsetupid)
        {
            try
            {
                var calibModel = await _dbContext.dl_calibrations.FirstOrDefaultAsync(x => x.calib_status_id == calibsetupid);
                if (calibModel.IsNotNull())
                {
                    _dbContext.dl_calibrations.Remove(calibModel);
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
