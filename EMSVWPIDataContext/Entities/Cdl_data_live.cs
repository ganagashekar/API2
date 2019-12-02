using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_data_live", Schema = "dektos")]
    public class dl_data_live
    {

        [Key]
        public System.Int64 data_id { get; set; }
        public System.Int64 confg_id { get; set; }
        [ForeignKey("confg_id")]
        public virtual dl_confg dl_confg { get; set; }
        public System.String param_name { get; set; }

        public long? param_id { get; set; }
        [ForeignKey("param_id")]
        public virtual dl_param dl_param { get; set; }

        public System.Single? param_value { get; set; }

        public System.DateTime creat_ts { get; set; }

    }
}
