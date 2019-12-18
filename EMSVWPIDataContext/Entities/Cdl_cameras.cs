using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_camera", Schema = "dektos")]
    public class dl_camera
    {
        public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
        public object[] RawValues;             //  /

        [Key]
        public System.Int64 cam_id { get; set; }
        public System.Int64 confg_id { get; set; }
        public System.Int64 site_id { get; set; }
        [ForeignKey("site_id")]
        public virtual dl_site dl_site { get; set; }
        public System.String stack_name { get; set; }
        public System.String param_name { get; set; }
        public System.String rtps_url { get; set; }
        public System.String ip_address { get; set; }
        public System.String cam_make { get; set; }
        public System.String cam_model_no { get; set; }
        public string ptz { get; set; }
        public System.String connectivity_typ { get; set; }
        public System.String band_width { get; set; }
        public System.String night_vision { get; set; }
        public System.String zoom { get; set; }
        public System.String creat_usr { get; set; }
        public System.DateTime? creat_ts { get; set; }
        public System.DateTime? updt_ts { get; set; }


    }
}
