using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
    public class CalibReqModel
    {
        public long confgId { set; get; }
        public string paramName { set; get; }
        public string calibtype { set; get; }
        public long calibduriation { set; get; }
        public DateTime create_ts { set; get; }
        public DateTime updtts { set; get; }
    }
}
