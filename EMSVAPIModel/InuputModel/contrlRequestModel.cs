using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
    public class contrlRequestModel
    {
        public string macId { set; get; }
        public long SiteId { set; get; }
        public string osType { set; get; }
        public string cpcbUrl { set; get; }
        public string spcburl { set; get; }
        public string licenseKey { set; get; }
        public DateTime Updtts { set; get; }
    }
}
