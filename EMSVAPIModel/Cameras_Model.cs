using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSVAPIModel
{
    public class Cameras_Model
    {
        public long camId { get; set; }
        public long confgId { get; set; }
        public long siteId { get; set; }
        public string siteName { get; set; }
        public String stackName { get; set; }
        public String paramName { get; set; }
        public String rtpsUrl { get; set; }
        public String ipAddress { get; set; }
        public String camMake { get; set; }
        public String cam_model_no { get; set; }
        public string ptz { get; set; }
        public String connectivity_typ { get; set; }
        public String band_width { get; set; }
        public String night_vision { get; set; }
        public String zoom { get; set; }
        public String creat_usr { get; set; }
        public DateTime creat_ts { get; set; }
        public DateTime updt_ts { get; set; }

    }
}
