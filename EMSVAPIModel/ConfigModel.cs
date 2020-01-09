using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EMSVAPIModel
{
    [DataContract]
   public class ConfigModel
    {
        [DataMember(Name = "Stack Name")]
        public string stackName { set; get; }

        [DataMember(Name = "Stack Type")]
        public string stackType { set; get; }

        [DataMember(Name = "Status")]

        public string  status { get; set; }
    }

    public class sitesModel
    {
        public long siteId { set; get; }
        public string siteName { set; get; }
    }

}
