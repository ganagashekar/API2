using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
    public class AuditRequst_Model
    {
        public long AuditId { set; get; }
        public long SiteId { set; get; }
        public long ConfigId { set; get; }
        public string StackName { set; get; }
        public string ParamName { set; get; }
        public float ParamVal { set; get; }
    }
}
