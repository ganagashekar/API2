using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
    public class ControllerBus_Model
    {
        public int busId { get; set; }
        public long SiteId { get; set; }
        public string macId { get; set; }
        public string comPort { get; set; }
        public long baudrate { get; set; }
        public int timeOut { get; set; }
        public int startIndex { get; set; }
        public string protocal { get; set; }
        public string updtts { get; set; }
    }
}
