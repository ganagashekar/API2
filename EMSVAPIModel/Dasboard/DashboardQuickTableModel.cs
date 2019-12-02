using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.Dasboard
{
    public class DashboardQuickDataModel
    {
        public string StackName { set; get; }
        public string ParamName { set; get; }
        public string ParamUnits { set; get; }
        public DateTime RecordedDate { set; get; }
        public double? ParamValue { set; get; }
        public int? ThreShholdValue { set; get; }
        public long  data_id { set; get; }
         public string paramminvalue { set; get; }
        public string parammaxvalue { set; get; }

        public long configId { set; get; }

        public bool IsGroupby { set; get; }
        public bool Status { set; get; }
    }
}
