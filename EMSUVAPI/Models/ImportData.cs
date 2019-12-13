
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace EMSUVAPI.Models
{
    public class ImportData
    {


        public Int64 confg_id { get; set; }


        public string param_name { get; set; }


        public System.Single param_value { get; set; }

        public DateTime creat_ts { get; set; }

        public Int64 param_id { get; set; }
    }
}