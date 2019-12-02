using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSVAPIModel.InuputModel
{
    public class ParamterRequestModel
    {
        public long SiteId { set; get; }
        public long StackId { set; get; }
        public long ParamId { set; get; }

        public bool IncludeAll { set; get; }
    }
}
