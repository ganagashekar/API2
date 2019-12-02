using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
    public class Confg_Model
    {
        public long confgID { get; set; }
        public long siteID { get; set; }
        public long busID { get; set; }
        //public string vendorID { get; set; }
        public string stack_name { get; set; }
       public string stack_status { get; set; }

        public string stack_typ { get; set; }
        public DateTime createts { get; set; }
        public DateTime updatets { get; set; }
        public string input_format { get; set; }
        public string output_format { get; set; }
        public Int32 slaveid { get; set; }
        public Int32 holdingreg { get; set; }
        public Int32 firstreg { get; set; }
        public string displayoutputtype { get; set; }
        public Int32 bytestoread { get; set; }
        public string inputstringtoread { get; set; }
    }
}

