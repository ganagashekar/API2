using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
   public class ConfigModel
    {
        public string stackName { set; get; }
        public string stackType { set; get; }
    }

    public class sitesModel
    {
        public long siteId { set; get; }
        public string siteName { set; get; }
    }

}
