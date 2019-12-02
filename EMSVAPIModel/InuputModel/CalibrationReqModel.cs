using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
   public class CalibrationReqModel
    {
        public long confg_id { set; get; }
      //  public long site_id { set; get; }
      //  public string site_name { set; get; }
      
        public string stack_name { set; get; }
        public string param_name { set; get; }
        public string updtUsr { set; get; }
        public DateTime updtts { set; get; }
        public DateTime creat_ts { set; get; }

        public string setZeroCmd { set; get; }
        public string setZeroResp { set; get; }
        public string zeroRelayOpenCmd { set; get; }
        public string zeroRelayOpenResp { set; get; }
        public string zeroRelayCloseCmd { set; get; }
        public string zeroRelayCloseResp { set; get; }
        public string readPrevValueCmd { set; get; }
        public string readPrevValueRes { set; get; }
        public string realGasRelayOpenCmd { set; get; }
        public string realGasRelayOpenResp { set; get; }
        public string realGasRelayCloseCmd { set; get; }
        public string real_GasRelayCloseResp { set; get; }
        public string setNewValueCmd { set; get; }
        public string setNewValueResp { set; get; }
        public string setMakeSpanCmd { set; get; }
        public string setMakeSpanResp { set; get; }
    }
}
