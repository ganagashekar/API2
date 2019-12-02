using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_data_historicaldata", Schema = "dektos")]
    public class dl_data_Historical
    {

        public Dictionary<string, int> Schema;
        public object[] RawValues;

        [Key]
        public System.Int64 data_id { get; set; }
        public System.Int64 confg_id { get; set; }
        [ForeignKey("confg_id")]
        public virtual dl_confg dl_confg { get; set; }
        public System.String param_name { get; set; }

        public long param_id { get; set; }
        [ForeignKey("param_id")]
        public virtual dl_param dl_param { get; set; }

        public System.Single param_value { get; set; }
        public System.String process_flag { get; set; }
        public System.DateTime creat_ts { get; set; }
        public System.DateTime received_ts { get; set; }

        public object GetRaw(string field)
        {
            if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
            return new object();
        }
    }
}
