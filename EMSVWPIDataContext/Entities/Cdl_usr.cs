using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_usr", Schema = "dektos")]
    public class dl_usr
    {
        [Key]
        public long usr_id { get; set; }

        [ForeignKey("usr_id")]
        public virtual dl_usr_roles userRoles { set; get; }
        public string usr_name { get; set; }
        public string pass { get; set; }
        public bool is_enabled { get; set; }
        public long vendor_site_id { get; set; }
        [ForeignKey("vendor_site_id")]
        public virtual dl_vendor_sites dl_vendor_sites { get; set; }
        public DateTime validity_ts { get; set; }
        public DateTime creat_ts { get; set; }
        public DateTime updt_ts { get; set; }



    }
}
