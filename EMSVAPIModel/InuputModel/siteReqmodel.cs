using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
    public class siteReqmodel
    {
        public long SiteId { set; get; }
        public string SiteName { set; get; }
        public string site_cpcb_cd { set; get; }
        public string site_city { set; get; }
        public string site_state { set; get; }
        public string site_country { set; get; }
        public string updt_ts { set; get; }
        public String siteLogo { set; get; }
        public String IndustryType { set; get; }
        public String SitePrimaryContactName { set; get; }
        public String SitePrimaryContactPhone { set; get; }
        public String SitePrimaryContactEmail { set; get; }
        public String SiteSecondaryContactName { set; get; }
        public String SiteSecondaryContactPhone { set; get; }
        public String SiteSecondaryContactEmail { set; get; }
        public String SiteLatitude { set; get; }
        public String SiteLongitude { set; get; }
        public String siteAddress1 { set; get; }
        public String siteAddress2 { set; get; }
        public String sitePinCode { set; get; }
        public String site_District { set; get; }
        public string site_in_ganga_basin { set; get; }


    }
}
