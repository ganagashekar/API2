using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.ResponseModels.Reports
{
   public  class ExceedenceReport
    {
        public string StackName { set; get; }
        public string ParamName { set; get; }
        public string ParamUnits { set; get; }
        public DateTime RecordedDate { set; get; }
        public double ParamValue { set; get; }
        public string Description { set; get; }
    }
}
