using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
    public class ConfigReqModel
    {
        public long confgID { set; get; }
        public string siteID { set; get; }
        public long busID { set; get; }
        public string vendorID { set; get; }
        public string stack_status { set; get; }
        public long holdingreg { set; get; }
        public Int32 bytestoread { set; get;  }
        public string inputstringtoread { set; get;  }
    }
}
