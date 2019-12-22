using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_calibrations", Schema = "dektos")]
    public class dl_calibrations
    {
        [Key]
        public long calib_status_id { get; set; }
       
        public long confg_id { get; set; }
        [ForeignKey("confg_id")]
        public virtual dl_confg dl_confgs { get; set; }


        public string calib_name { get; set; }

        public string param_name { get; set; }
       
        public string calib_type { get; set; }

        public int? calib_zero_duriation { get; set; }

        public int? calib_span_duriation { get; set; }

        public string calib_zero_gas_name { get; set; }

        public string calib_zero_gas_unit { get; set; }

        public string calib_zero_gas_type { get; set; }

        public string calib_span_gas_name { get; set; }

        public string calib_span_gas_unit { get; set; }

        public string calib_span_gas_type { get; set; }

        public int? calib_zero_delay { get; set; }

        public int? calib_span_delay { get; set; }

        public string calib_frequency { get; set; }

        public TimeSpan? calib_frequency_time { get; set; }

        public DateTime? calib_stat_DateTime { get; set; }

        public DateTime? calib_end_DateTime { get; set; }

        public DateTime? ca_read_concentration_relay_open_ts { get; set; }

        public string ca_read_concentration_relay_open_stat_flag { get; set; }

        public DateTime? ca_set_zero_relay_open_ts { get; set; }

        public string ca_set_zero_relay_open_stat_flag { get; set; }

        public DateTime? ca_set_zero_ts { get; set; }

        public string ca_set_zero_stat_flag { get; set; }

        public DateTime? ca_set_zero_relay_close_ts { get; set; }

        public string ca_set_zero_relay_close_stat_flag { get; set; }

        public DateTime? ca_real_gas_relay_open_ts { get; set; }

        public string ca_real_gas_relay_open_stat_flag { get; set; }

        public DateTime? ca_read_prev_value_ts { get; set; }

        public string ca_read_prev_value_stat_flag { get; set; }

        public int? ca_set_new_zero_value { get; set; }

        public int? ca_set_new_span_value { get; set; }

        public DateTime? ca_set_new_value_ts { get; set; }

        public string ca_set_new_value_stat_flag { get; set; }

        public DateTime? ca_make_span_ts { get; set; }

        public string ca_make_span_stat_flag { get; set; }

        public DateTime? ca_real_gas_relay_close_ts { get; set; }

        public string ca_real_gas_relay_close_stat_flag { get; set; }

        public string ca_status_stat { get; set; }

        public DateTime? ca_status_stat_ts { get; set; }

        public string ca_status_stat_flag { get; set; }

        public DateTime? ca_read_concentration_relay_close_ts { get; set; }

        public string ca_read_concentration_relay_close_stat_flag { get; set; }

        public string creat_usr { get; set; }

        public DateTime? creat_ts { get; set; }

        public string updt_usr { get; set; }

        public DateTime? updt_ts { get; set; }

    }

}
