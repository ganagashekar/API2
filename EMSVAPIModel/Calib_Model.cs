using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
    public class Calib_Model
    {
        public long confgId { get; set; }
        public string paramName { get; set; }
        public string calibtype { get; set; }
        public long calibduriation { get; set; }
        public DateTime create_ts { get; set; }
        public DateTime updtts { get; set; }
    }
}
