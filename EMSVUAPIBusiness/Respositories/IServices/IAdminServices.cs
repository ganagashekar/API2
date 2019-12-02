using EMSVAPIModel;
using EMSVAPIModel.InuputModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMSVUAPIBusiness.Respositories.IServices
{
   public interface IAdminServices
    {
        Task<List<Param_Model>> GetParametersAsync(ParamterRequestModel paramterRequest);
        Task<List<ConfigModel>> GetConfigAsync(ParamterRequestModel configRequest);
        Task<long> SaveParameterAsync(Param_Model paramModel);
        Task<bool> DeleteParameter(long paramId);
        Task<List<error_Model>> GeterrorcodeAsync(errorRequest errRequest);
        Task<string> SaveErrorCodeAsync(error_Model errorcodeModel);
        Task<long> saveControllerBus(ControllerBus_Model conBusReq);
        Task<long> saveApplicationLogs(ApplicationLogs_Model logModel);
        Task<long> saveConfig(Confg_Model confReq);
        Task<long> saveSite(site_Model siteID);
        Task<bool> DeleteErrorCode(string errorcode);
        Task<bool> DeleteController(string MacId);
        Task<bool> DeleteControllerbus(int BusId);
        Task<bool> Deleteconfig(int confgID);
        Task<bool> Deleteaudit(int AuditId);
        Task<bool> DeleteSite(long SiteId);
        Task<bool> Deletecalibration(long calib_cmd_id);
        Task<List<control_Model>> GetcontrollerAsync(contrlRequestModel ctrRequest);
        Task<List<ControllerBus_Model>> GetcontrollerBusAsync(ControllerBusReqModel ctrBusRequest);
        Task<List<Confg_Model>> ConfigAsync(ConfigReqModel configreq);
        Task<List<Audit_Model>> GetAuditAsync(AuditRequst_Model auditRequst);
        Task<List<site_Model>> GetsiteAsync(siteReqmodel sitereq);
        Task<List<User_Model>> GetuserinfoAsync(userReqModel usrReq);
        Task<long> SaveUserinfo(User_Model userModel);
        Task<bool> DeleteUserinfo(long userId);
        Task<bool> DeleteApplicationLog(long logID);
        Task<string> SaveController(control_Model MacID);
        Task<List<ApplicationLogs_Model>> GetApplicationLogsAsync(ApplicationLogsReqModel logreq);
        Task<List<Calibration_Model>> GetcalibrationAsync(CalibrationReqModel calibRequest);
        Task<long> SaveCalibration(Calibration_Model calibreq);
        Task<List<Calib_Model>> GetCalibReportAsync(CalibReqModel calibRequest);
    }
}
