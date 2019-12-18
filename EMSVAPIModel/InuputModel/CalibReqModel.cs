using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
    public class CalibReqModel
    {
        public long calibsetupid { set; get;  }
        public string clib_name { set; get; }

        public string stack_name { set; get; }

        public long confgId { set; get; }
        public string paramname { set; get; }
        public string calibtype { set; get; }

        public DateTime create_ts  {set; get; }
        public DateTime updtts { set; get; }

        public DateTime calib_start_date { set; get; }
        public DateTime calib_end_date { set; get; }
        public string calib_zero_gas_name { set; get; }
        public string calib_zero_gas_unit { set; get; }
        public string calib_zero_gas_type { set; get; }
        public int? ca_set_new_zero_value { set; get; }
        public int? calib_zero_duriation { set; get; }
        public int? calib_zero_delay { set; get; }

        public string calib_span_gas_name {set; get; }

        public string calib_span_gas_unit { set; get; }

        public string calib_span_gas_type { set; get; }
        public int? calib_span_delay { set; get; }
        public int? calib_span_duriation { set; get; }
        public int? ca_set_new_span_value { set; get; }

        public long siteId { set; get; }
        public string siteName { set; get; }




    }
}
