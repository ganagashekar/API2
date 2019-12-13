using System;

namespace EMSVAPIModel
{
    public class Param_Model
    {

        public long paramid { get; set; }
        public long confgid { get; set; }
        public string paramname { get; set; }
        public string paramunit { get; set; }
        public string paramminval { get; set; }
        public string parammaxval { get; set; }
        public int? threshholdval { get; set; }
        public int? paramposition { get; set; }
        public int? length { get; set; }

        public float paramValue { get; set; }
        public string StackName { set; get; }
        public DateTime creatts { get; set; }
        public DateTime updtts { get; set; }
    }
}
