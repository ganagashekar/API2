using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
    public class Calib_Model
    {
        public long calibsetupid { get; set; }
        public string clib_name { get; set; }

        public string stack_name { get; set; }

        public long confgId { get; set; }
        public string paramname { get; set; }
        public string calibtype { get; set; }

        public DateTime create_ts { get; set; }
        public DateTime updtts { get; set; }

        public DateTime calib_start_date { get; set; }
        public DateTime calib_end_date { get; set; }
        public string calib_zero_gas_name { get; set; }
        public string calib_zero_gas_unit { get; set; }
        public string calib_zero_gas_type { get; set; }
        public int? ca_set_new_zero_value { get; set; }
        public int? calib_zero_duriation { get; set; }
        public int? calib_zero_delay { get; set; }

        public string calib_span_gas_name { get; set; }

        public string calib_span_gas_unit { get; set; }

        public string calib_span_gas_type { get; set; }
        public int? calib_span_delay { get; set; }
        public int? calib_span_duriation { get; set; }
        public int? ca_set_new_span_value { get; set; }

        public long siteId { get; set;  }
       public string siteName { set; get; }




       
    }
}
