using System;
using System.Runtime.Serialization;

namespace EMSVAPIModel.Dasboard
{
    [DataContract]
    public class DashboardParamModel
    {

        [DataMember(Name = "Stack Name")]
        public string stackName { set; get; }

        [DataMember(Name = "Parameter Name")]
        public string paramname { get; set; }

        [DataMember(Name = "Parameter Units")]
        public string paramunit { get; set; }

        [DataMember(Name = "Limit")]
        public string paramRange { get; set; }

        [DataMember(Name = "Threshold")]
        public int? threshholdval { get; set; }



        [DataMember(Name = "Created Date")]
        public DateTime CreatedDate { set; get; }
    }

    [DataContract]
    public class DashboardExceedence
    {
        [DataMember(Name = "Stack Name")]
        public string stackName { set; get; }

        [DataMember(Name = "Name")]
        public string paramname { get; set; }



        [DataMember(Name = "Value")]
        public float paramValue { set; get; }

        [DataMember(Name = "Created Date")]
        public DateTime CreatedDate { set; get; }
    }
}
