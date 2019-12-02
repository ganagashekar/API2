using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
   public class ApplicationLogsReqModel
    {
        public long logID { set; get; }
        public long confgID { set; get; }
        public string errorCode { set; get; }
        public DateTime createts { set; get; }

    }
}
