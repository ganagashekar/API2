using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
    public class ApplicationLogs_Model
    {
        public long logID { get; set; }
        public long confgID { get; set; }
        public string errorCode { get; set; }
        public DateTime createts { get; set; }

    }
}
