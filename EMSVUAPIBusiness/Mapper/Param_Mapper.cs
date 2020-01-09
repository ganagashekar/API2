using AutoMapper;
using EMSVAPIModel;
using EMSVExtentions;
using EMSVWPIDataContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVUAPIBusiness.Mapper
{
    public class Param_Mapper : Profile
    {

        public Param_Mapper()
        {

            CreateMap<dl_param, Param_Model>().ForMember(dest => dest.confgid, src => src.MapFrom(s => s.confg_id))
            .ForMember(dest => dest.creatts, src => src.MapFrom(s => s.creat_ts))
               .ForMember(dest => dest.paramid, src => src.MapFrom(s => s.param_id))
                  .ForMember(dest => dest.parammaxval, src => src.MapFrom(s => s.param_max_val))
            .ForMember(dest => dest.paramminval, src => src.MapFrom(s => s.param_min_val))
            .ForMember(dest => dest.threshholdval, src => src.MapFrom(s => s.threshhold_val))
            .ForMember(dest => dest.paramname, src => src.MapFrom(s => s.param_name))
            .ForMember(dest => dest.paramposition, src => src.MapFrom(s => s.param_position))
            .ForMember(dest => dest.paramunit, src => src.MapFrom(s => s.param_unit))
            .ForMember(dest => dest.StackName, src => src.MapFrom(s => s.dl_confgs.stack_name))
             .ForMember(dest => dest.paramValue, src => src.Ignore())
             .ForMember(dest => dest.paramposition, src => src.MapFrom(s => s.param_position))
              .ForMember(dest => dest.length, src => src.MapFrom(s => s.length))
                 .ForMember(dest => dest.updtts, src => src.MapFrom(s => s.updt_ts)).ReverseMap();




            CreateMap<Referencerecords, ReferenceRecordsModel>().ForMember(dest => dest.Id, src => src.MapFrom(s => s.Id))
         .ForMember(dest => dest.Name, src => src.MapFrom(s => s.Name))
            .ForMember(dest => dest.ReferenceRecordTyepId, src => src.MapFrom(s => s.ReferenceRecordTyepId));




            CreateMap<dl_usr, User_Model>().ForMember(dest => dest.UserId, src => src.MapFrom(s => s.usr_id))
          .ForMember(dest => dest.Creatts, src => src.MapFrom(s => s.creat_ts))
             .ForMember(dest => dest.UserName, src => src.MapFrom(s => s.usr_name))
                .ForMember(dest => dest.Validityts, src => src.MapFrom(s => s.validity_ts))
          .ForMember(dest => dest.SiteId, src => src.MapFrom(s => s.dl_vendor_sites.site_id))
          .ForMember(dest => dest.Updtts, src => src.MapFrom(s => s.updt_ts))
          .ForMember(dest => dest.Site, src => src.MapFrom(x => x.dl_vendor_sites.dl_Site))
          .ForMember(dest => dest.IsEnabled, src => src.MapFrom(s => s.is_enabled))
          .ForMember(dest => dest.vendorSiteId, src => src.MapFrom(s => s.vendor_site_id))
           .ForMember(dest => dest.roleId, src => src.MapFrom(s => s.userRoles.IsNotNull() ? s.userRoles.role_id : 0))
           .ForMember(dest => dest.roleName, src => src.MapFrom(s => s.userRoles.roles.IsNotNull() ? s.userRoles.roles.name : ""))
           .ForMember(dest => dest.UserPass, src => src.Ignore()).ReverseMap();






            CreateMap<dl_error_cd, error_Model>()
            .ForMember(dest => dest.errorcode, src => src.MapFrom(s => s.error_code))
            .ForMember(dest => dest.updt_ts, src => src.MapFrom(s => s.updt_ts))
            .ForMember(dest => dest.errordesc, src => src.MapFrom(s => s.error_desc)).ReverseMap();

            CreateMap<dl_controller, control_Model>()
            .ForMember(dest => dest.cpcbUrl, src => src.MapFrom(s => s.cpcb_url))
            .ForMember(dest => dest.licenseKey, src => src.MapFrom(s => s.license_key))
            .ForMember(dest => dest.macId, src => src.MapFrom(s => s.mac_id))
            .ForMember(dest => dest.osType, src => src.MapFrom(s => s.os_typ))
            .ForMember(dest => dest.SiteId, src => src.MapFrom(s => s.site_id))
            .ForMember(dest => dest.spcburl, src => src.MapFrom(s => s.spcb_url))
            .ForMember(dest => dest.updtts, src => src.MapFrom(s => s.updt_ts)).ReverseMap();

            CreateMap<dl_controller_bus, ControllerBus_Model>()
                    .ForMember(dest => dest.busId, src => src.MapFrom(s => s.bus_id))
                    .ForMember(dest => dest.SiteId, src => src.MapFrom(s => s.dl_controller.site_id))
                    .ForMember(dest => dest.macId, src => src.MapFrom(s => s.mac_id))
                    .ForMember(dest => dest.comPort, src => src.MapFrom(s => s.com_port))
                    .ForMember(dest => dest.baudrate, src => src.MapFrom(s => s.baud_rate))
                    .ForMember(dest => dest.timeOut, src => src.MapFrom(s => s.time_out))
                    .ForMember(dest => dest.startIndex, src => src.MapFrom(s => s.data_byte_stat_indx))
                    .ForMember(dest => dest.protocal, src => src.MapFrom(s => s.protocal))
                    .ForMember(dest => dest.updtts, src => src.MapFrom(s => s.updt_ts)).ReverseMap();

            CreateMap<dl_confg, Confg_Model>()
                   .ForMember(dest => dest.confgId, src => src.MapFrom(s => s.confg_id))
                   .ForMember(dest => dest.siteId, src => src.MapFrom(s => s.site_id))
                   .ForMember(dest => dest.busId, src => src.MapFrom(s => s.bus_id))

                   .ForMember(dest => dest.stack_name, src => src.MapFrom(s => s.stack_name))
                   .ForMember(dest => dest.stack_typ, src => src.MapFrom(s => s.stack_typ))
                    .ForMember(dest => dest.stack_status, src => src.MapFrom(s => s.stack_status))
                     .ForMember(dest => dest.input_format, src => src.MapFrom(s => s.input_format))
                      .ForMember(dest => dest.output_format, src => src.MapFrom(s => s.output_format))
                      .ForMember(dest => dest.slaveid, src => src.MapFrom(s => s.cnfg_slave_id))
                      .ForMember(dest => dest.holdingreg, src => src.MapFrom(s => s.cnfg_hold_reg))
                      .ForMember(dest => dest.firstreg, src => src.MapFrom(s => s.cnfg_reg_first))
                      .ForMember(dest => dest.displayoutputtype, src => src.MapFrom(s => s.disp_output_typ))
                   .ForMember(dest => dest.createts, src => src.MapFrom(s => s.creat_ts))
                      .ForMember(dest => dest.bytestoread, src => src.MapFrom(s => s.cnfg_reg_len))
                   .ForMember(dest => dest.inputstringtoread, src => src.MapFrom(s => s.cnfg_input_str))
                    .ForMember(dest => dest.updatets, src => src.MapFrom(s => s.updt_ts)).ReverseMap();

            CreateMap<dl_audit, Audit_Model>()
                .ForMember(dest => dest.auditID, src => src.MapFrom(s => s.audit_id))
                .ForMember(dest => dest.siteID, src => src.MapFrom(s => s.site_id))
                .ForMember(dest => dest.confgID, src => src.MapFrom(s => s.confg_id))
                .ForMember(dest => dest.stack_name, src => src.MapFrom(s => s.stack_name))
                .ForMember(dest => dest.param_name, src => src.MapFrom(s => s.param_name)).ReverseMap();

            CreateMap<dl_site, site_Model>()
                      .ForMember(dest => dest.siteId, src => src.MapFrom(s => s.site_id))
                     .ForMember(dest => dest.siteName, src => src.MapFrom(s => s.site_name))
                     .ForMember(dest => dest.site_cpcb_cd, src => src.MapFrom(s => s.site_cpcb_cd))
                     .ForMember(dest => dest.site_in_ganga_basin, src => src.MapFrom(s => s.site_in_ganga_basin))
                     .ForMember(dest => dest.site_city, src => src.MapFrom(s => s.site_city))
                     .ForMember(dest => dest.site_state, src => src.MapFrom(s => s.site_state))
                     .ForMember(dest => dest.updt_ts, src => src.MapFrom(s => s.updt_ts))
                      .ForMember(dest => dest.create_ts, src => src.MapFrom(s => s.creat_ts))
                      .ForMember(dest => dest.siteLogo, src => src.MapFrom(s => s.site_logo))
                      .ForMember(dest => dest.IndustryType, src => src.MapFrom(s => s.site_ind_type))
                      .ForMember(dest => dest.SiteLatitude, src => src.MapFrom(s => s.site_latitude))
                      .ForMember(dest => dest.SitePrimaryContactPhone, src => src.MapFrom(s => s.site_prmry_cnct_ph_num))
                      .ForMember(dest => dest.SiteSecondaryContactName, src => src.MapFrom(s => s.site_second_cnct_name))
                      .ForMember(dest => dest.SiteSecondaryContactEmail, src => src.MapFrom(s => s.site_second_cnct_email))
                      .ForMember(dest => dest.SitePrimaryContactName, src => src.MapFrom(s => s.site_prmry_cnct_name))
                      .ForMember(dest => dest.SitePrimaryContactEmail, src => src.MapFrom(s => s.site_prmry_cnct_email))
                      .ForMember(dest => dest.SiteSecondaryContactPhone, src => src.MapFrom(s => s.site_second_cnct_ph_num))
                      .ForMember(dest => dest.siteAddress1, src => src.MapFrom(s => s.site_addr_1))
                       .ForMember(dest => dest.siteAddress2, src => src.MapFrom(s => s.site_addr_2))
                       .ForMember(dest => dest.site_District, src => src.MapFrom(s => s.site_district))
                       .ForMember(dest => dest.sitePinCode, src => src.MapFrom(s => s.site_pin_cd))
                        .ForMember(dest => dest.SiteLongitude, src => src.MapFrom(s => s.site_longitude))
                       .ForMember(dest => dest.site_country, src => src.MapFrom(s => s.site_country)).ReverseMap();


            CreateMap<dl_calib_cmd_setup, Calibration_Model>()
                 .ForMember(dest => dest.confg_id, src => src.MapFrom(s => s.confg_id))
           // .ForMember(dest => dest.site_name, src => src.MapFrom(s => s.dl_sites.site))
           // .ForMember(dest => dest.site_id, src => src.MapFrom(s => s.dl_site.site_id))

           .ForMember(dest => dest.stack_name, src => src.MapFrom(s => s.stack_name))
           .ForMember(dest => dest.updtUsr, src => src.MapFrom(s => s.updt_usr))
           .ForMember(dest => dest.updtts, src => src.MapFrom(s => s.updt_ts))
           .ForMember(dest => dest.creat_ts, src => src.MapFrom(s => s.creat_ts))
            .ForMember(dest => dest.setZeroCmd, src => src.MapFrom(s => s.ca_set_zero_cmd))
             .ForMember(dest => dest.setZeroResp, src => src.MapFrom(s => s.ca_set_zero_resp))
              .ForMember(dest => dest.zeroRelayOpenCmd, src => src.MapFrom(s => s.ca_set_zero_relay_open_cmd))
               .ForMember(dest => dest.zeroRelayOpenResp, src => src.MapFrom(s => s.ca_set_zero_relay_open_resp))
                .ForMember(dest => dest.zeroRelayCloseCmd, src => src.MapFrom(s => s.ca_set_zero_relay_close_cmd))
                 .ForMember(dest => dest.zeroRelayCloseResp, src => src.MapFrom(s => s.ca_set_zero_relay_close_resp))
                  .ForMember(dest => dest.readPrevValueCmd, src => src.MapFrom(s => s.ca_read_prev_value_cmd))
                   .ForMember(dest => dest.readPrevValueRes, src => src.MapFrom(s => s.ca_read_prev_value_res))
                    .ForMember(dest => dest.realGasRelayOpenCmd, src => src.MapFrom(s => s.ca_real_gas_relay_open_cmd))
                     .ForMember(dest => dest.realGasRelayOpenResp, src => src.MapFrom(s => s.ca_real_gas_relay_open_resp))
                      .ForMember(dest => dest.realGasRelayCloseCmd, src => src.MapFrom(s => s.ca_real_gas_relay_close_cmd))
                       .ForMember(dest => dest.real_GasRelayCloseResp, src => src.MapFrom(s => s.ca_real_gas_relay_close_resp))
                        .ForMember(dest => dest.setNewValueCmd, src => src.MapFrom(s => s.ca_set_new_value_cmd))
                         .ForMember(dest => dest.setNewValueResp, src => src.MapFrom(s => s.ca_set_new_value_resp))
                          .ForMember(dest => dest.setMakeSpanCmd, src => src.MapFrom(s => s.ca_set_make_span_cmd))
                           .ForMember(dest => dest.setMakeSpanResp, src => src.MapFrom(s => s.ca_set_make_span_resp))


             .ForMember(dest => dest.param_name, src => src.MapFrom(s => s.param_name)).ReverseMap();



            CreateMap<dl_calibrations, Calib_Model>().ForMember(dest => dest.confgId, src => src.MapFrom(s => s.confg_id))
            .ForMember(dest => dest.stack_name, src => src.MapFrom(s => s.dl_confgs.stack_name))

          .ForMember(dest => dest.calibsetupid, src => src.MapFrom(s => s.calib_status_id))
           .ForMember(dest => dest.clib_name, src => src.MapFrom(s => s.calib_name))

          .ForMember(dest => dest.calib_start_date, src => src.MapFrom(s => s.calib_stat_DateTime))

          .ForMember(dest => dest.calib_end_date, src => src.MapFrom(s => s.calib_end_DateTime))

          .ForMember(dest => dest.calib_zero_gas_name, src => src.MapFrom(s => s.calib_zero_gas_name))

          .ForMember(dest => dest.calib_zero_gas_unit, src => src.MapFrom(s => s.calib_zero_gas_unit))

          .ForMember(dest => dest.calib_zero_gas_type, src => src.MapFrom(s => s.calib_zero_gas_type))
          .ForMember(dest => dest.ca_set_new_zero_value, src => src.MapFrom(s => s.ca_set_new_zero_value))
          .ForMember(dest => dest.calib_zero_duriation, src => src.MapFrom(s => s.calib_zero_duriation))
          .ForMember(dest => dest.calib_zero_delay, src => src.MapFrom(s => s.calib_zero_delay))

          .ForMember(dest => dest.calibtype, src => src.MapFrom(s => s.calib_type))
         .ForMember(dest => dest.siteId, src => src.MapFrom(s => s.dl_confgs.dl_site.site_id))
           .ForMember(dest => dest.siteName, src => src.MapFrom(s => s.dl_confgs.dl_site.site_name))

          .ForMember(dest => dest.paramname, src => src.MapFrom(s => s.param_name))
          .ForMember(dest => dest.create_ts, src => src.MapFrom(s => s.creat_ts))
            .ForMember(dest => dest.updtts, src => src.MapFrom(s => s.updt_ts))
             .ForMember(dest => dest.calib_span_gas_name, src => src.MapFrom(s => s.calib_span_gas_name))
             .ForMember(dest => dest.calib_span_gas_unit, src => src.MapFrom(s => s.calib_span_gas_unit))
                  .ForMember(dest => dest.calib_span_gas_type, src => src.MapFrom(s => s.calib_span_gas_type))
                   .ForMember(dest => dest.ca_set_new_span_value, src => src.MapFrom(s => s.ca_set_new_span_value))
                   .ForMember(dest => dest.calib_span_delay, src => src.MapFrom(s => s.calib_span_delay))
                   .ForMember(dest => dest.calib_span_duriation, src => src.MapFrom(s => s.calib_span_duriation)).ReverseMap();

            CreateMap<dl_log, ApplicationLogs_Model>()
                 .ForMember(dest => dest.logID, src => src.MapFrom(s => s.log_id))
                  .ForMember(dest => dest.confgID, src => src.MapFrom(s => s.confg_id))
                  .ForMember(dest => dest.errorCode, src => src.MapFrom(s => s.error_code))
                  .ForMember(dest => dest.createts, src => src.MapFrom(s => s.creat_ts)).ReverseMap();


            CreateMap<dl_camera, Cameras_Model>()
           .ForMember(dest => dest.camId, src => src.MapFrom(s => s.cam_id))
           .ForMember(dest => dest.confgId, src => src.MapFrom(s => s.confg_id))
           .ForMember(dest => dest.siteId, src => src.MapFrom(s => s.site_id))
           .ForMember(dest => dest.siteName, src => src.MapFrom(s => s.dl_site.site_name))
           .ForMember(dest => dest.stackName, src => src.MapFrom(s => s.stack_name))
           .ForMember(dest => dest.paramName, src => src.MapFrom(s => s.param_name))
           .ForMember(dest => dest.rtpsUrl, src => src.MapFrom(s => s.rtps_url))
           .ForMember(dest => dest.ipAddress, src => src.MapFrom(s => s.ip_address))
           .ForMember(dest => dest.camMake, src => src.MapFrom(s => s.cam_make))
           .ForMember(dest => dest.cam_model_no, src => src.MapFrom(s => s.cam_model_no))
           .ForMember(dest => dest.ptz, src => src.MapFrom(s => s.ptz))
          .ForMember(dest => dest.connectivity_typ, src => src.MapFrom(s => s.connectivity_typ))
           .ForMember(dest => dest.band_width, src => src.MapFrom(s => s.band_width))
           .ForMember(dest => dest.night_vision, src => src.MapFrom(s => s.night_vision))
           .ForMember(dest => dest.zoom, src => src.MapFrom(s => s.zoom))
           .ForMember(dest => dest.creat_usr, src => src.MapFrom(s => s.creat_usr))
           .ForMember(dest => dest.creat_ts, src => src.MapFrom(s => s.creat_ts))
           .ForMember(dest => dest.updt_ts, src => src.MapFrom(s => s.updt_ts)).ReverseMap();


        }
    }
}
