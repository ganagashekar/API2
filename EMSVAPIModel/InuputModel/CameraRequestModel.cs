using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSVAPIModel.InuputModel
{
    public class CameraRequestModel
    {
        public long camId { set; get; }
        public long confgId { set; get; }
        public long siteId { set; get; }
        public string siteName { set; get; }
        public String stackName { set; get; }
        public String paramName { set; get; }
        public String rtpsUrl { set; get; }
        public String ipAddress { set; get; }
        public String camMake { set; get; }

        public string creat_usr { set; get; }
        public DateTime create_ts { set; get; }
        public DateTime updtts { set; get; }
    }
}
