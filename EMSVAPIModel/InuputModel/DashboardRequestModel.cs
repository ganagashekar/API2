using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
   public class DashboardRequestModel :ParamterRequestModel
    {

        public DateTime fromDate { set; get; }

        public long dataId { set; get; }

        public DateTime toDate { set; get; }
    }
}
