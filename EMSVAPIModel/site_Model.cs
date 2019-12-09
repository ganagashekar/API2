using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
    public class site_Model
    {
        public long siteId { get; set; }
        public string siteName { get; set; }
        public string site_cpcb_cd { get; set; }
        public string site_in_ganga_basin { get; set; }
        public string site_city { get; set; }
        public string site_state { get; set; }
        public string site_country { get; set; }
        public string updt_ts { get; set; }
        public String create_ts { get; set; }
        public String siteLogo { get; set; }
        public String IndustryType { get; set; }
        public String SitePrimaryContactName { get; set; }
        public String SitePrimaryContactPhone { get; set; }
        public String SitePrimaryContactEmail { get; set; }
        public String SiteSecondaryContactName { get; set; }
        public String SiteSecondaryContactPhone { get; set; }
        public String SiteSecondaryContactEmail { get; set; }
        public String SiteLatitude { get; set; }
        public String SiteLongitude { get; set; }
        public String siteAddress1 { get; set; }
        public String siteAddress2 { get; set; }
        public String sitePinCode { get; set; }
        public String site_District { get; set; }

    }
}
