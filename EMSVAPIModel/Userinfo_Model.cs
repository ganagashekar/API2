using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel
{
public class Userinfo_Model
    {
        public long userId { get; set; }
        public string userName { get; set; }
        public string PassWord { get; set; }
        public bool is_enabled { get; set; }
        public string Vendor_site_Id { set; get; }
        public DateTime validity_ts { get; set; }
        public DateTime create_ts { get; set; }
        public DateTime updt_ts { get; set; }
        public string StackName { get; set; }
        }
}
