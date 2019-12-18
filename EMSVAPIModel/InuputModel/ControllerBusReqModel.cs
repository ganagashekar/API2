using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
    public class ControllerBusReqModel
    {
        public long SiteId { get; set; }
        public long busId { set; get; }
        public string macId { set; get; }
    }
}
