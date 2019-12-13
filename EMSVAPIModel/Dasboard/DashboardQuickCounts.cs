using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.Dasboard
{
    public class DashboardQuickCounts
    {
        public int StackCount { set; get; }
        public int ParamCount { set; get; }
        public int ExceedenceCount { set; get; }
        public int AlertCount { set; get; }

        public List<DashboardExceedence> exceedence { set; get; }
        public List<DashboardExceedence> alarms { set; get; }

         public List<DashboardParamModel> paramters{ set; get; }
        public List<ConfigModel> stations { set; get; }


    }
}
