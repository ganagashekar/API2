using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
   public class ReportRequestModel
    {
        public ReportRequestModel()
        {
            StackId = 0;
            SiteId = 0;
            ParamId = 0;
            FromDate = DateTime.Now.Date.AddHours(0).AddMinutes(0).AddSeconds(0).AddDays(0);
            ToDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddDays(0);
            TimePeriod = 0;
            IsExport = false;
            StartIndex = 0;
            EndIndex = 0;


        }
        public long StackId { set; get; }
        public long SiteId { set; get; }

        public long ParamId { set; get; }
        public DateTime FromDate { set; get; }

        public DateTime ToDate { set; get; }

        public int TimePeriod { set; get; }

        public bool IsExport { set; get; }

        public int StartIndex { set; get; }

        public int EndIndex { set; get; }

        public string ReportType { set; get; }
        public string  SiteName { set; get; }
        public string SiteCode { set; get; }

        public string RequestedUser { set; get; }
        public string ReportTitle { set; get; }
    }
}
