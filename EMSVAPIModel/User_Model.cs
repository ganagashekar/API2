using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
    public class User_Model
    {

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public bool IsEnabled { get; set; }
        public long SiteId { get; set; }
        public long vendorSiteId { get; set; }
        public DateTime Validityts { get; set; }
        public DateTime Creatts { get; set; }
        public DateTime Updtts { get; set; }
        public site_Model Site { set; get; }
        public long roleId { set; get; }
        public string roleName { set; get; }



    }
}
