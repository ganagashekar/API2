using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
   public class Calibration_Model
    {
        public long calib_cmd_id { get; set; }
        public long confg_id { get; set; }
       // public long site_id { get; set; }
       // public string site_name { get; set; }
        public string stack_name { get; set; }
        public string param_name { get; set; }
        public string updtUsr { get; set; }
        public DateTime updtts { get; set; }
        public DateTime creat_ts { get; set; }

        public string setZeroCmd { get; set; }
        public string setZeroResp { get; set; }
        public string zeroRelayOpenCmd { get; set; }
        public string zeroRelayOpenResp { get; set; }
        public string zeroRelayCloseCmd { get; set; }
        public string zeroRelayCloseResp { get; set; }
        public string readPrevValueCmd { get; set; }
        public string readPrevValueRes { get; set; }
        public string realGasRelayOpenCmd { get; set; }
        public string realGasRelayOpenResp { get; set; }
        public string realGasRelayCloseCmd { get; set; }
        public string real_GasRelayCloseResp { get; set; }
        public string setNewValueCmd { get; set; }
        public string setNewValueResp { get; set; }
        public string setMakeSpanCmd { get; set; }
        public string setMakeSpanResp { get; set; }

    }
}
