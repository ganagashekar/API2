using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
    public class control_Model
    {

        public string MacId { get; set; }
        public long  SiteId { get; set; }
        public string osType { get; set; }
        public string cpcbUrl { get; set; }
        public string spcburl { get; set; }
        public string licenseKey { get; set; }
        public DateTime updtts { get; set; }
    }
}
