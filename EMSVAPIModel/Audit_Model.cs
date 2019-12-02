using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
    public class Audit_Model
    {
        public long auditID { get; set; }
        public long siteID { get; set; }
        public long confgID { get; set; }
        public string stack_name { get; set; }
        public string param_name { get; set; }
        // public float ParamVal { get; set; }
    }
}
