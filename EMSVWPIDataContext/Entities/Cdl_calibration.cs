using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_calibration", Schema = "dektos")]
    public class dl_calibration
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
		public System.Int64 calib_status_id{get;set;}
		public System.Int64 confg_id{get;set;}
        [ForeignKey("confg_id")]
        public virtual dl_confg dl_sites { get; set; }
        public System.String calib_name{get;set;}
		public System.String param_name{get;set;}
		public System.String calib_type{get;set;}
		public System.Int32 calib_duriation{get;set;}
		public System.DateTime? calib_stat_DateTime{get;set;}
		public System.DateTime? calib_end_DateTime{get;set;}
		public System.DateTime? ca_set_zero_ts{get;set;}
		public System.String ca_set_zero_stat_flag{get;set;}
		public System.DateTime? ca_set_zero_relay_open_ts{get;set;}
		public System.String ca_set_zero_relay_open_stat_flag{get;set;}
		public System.DateTime? ca_set_zero_relay_close_ts{get;set;}
		public System.String ca_set_zero_relay_close_stat_flag{get;set;}
		public System.DateTime? ca_real_gas_relay_open_ts{get;set;}
		public System.String ca_real_gas_relay_open_stat_flag{get;set;}
		public System.DateTime? ca_real_gas_relay_close_ts{get;set;}
		public System.String ca_real_gas_relay_close_stat_flag{get;set;}
		public System.DateTime? ca_read_prev_value_ts{get;set;}
		public System.String ca_read_prev_value_stat_flag{get;set;}
		public System.Single? calib_set_new_value{get;set;}
		public System.DateTime? ca_set_new_value_ts{get;set;}
		public System.String ca_set_new_value_stat_flag{get;set;}
		public System.DateTime? ca_make_span_ts{get;set;}
		public System.String ca_make_span_stat_flag{get;set;}
		public System.DateTime? creat_ts{get;set;}
		public System.String creat_usr{get;set;}
		public System.String updt_usr{get;set;}
		public System.DateTime? updt_ts{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_calibration(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["calib_status_id"].GetType().ToString() != "System.DBNull") calib_status_id = (System.Int64)r["calib_status_id"];
		//	if(r["confg_id"].GetType().ToString() != "System.DBNull") confg_id = (System.Int64)r["confg_id"];
		//	if(r["calib_name"].GetType().ToString() != "System.DBNull") calib_name = (System.String)r["calib_name"];
		//	if(r["param_name"].GetType().ToString() != "System.DBNull") param_name = (System.String)r["param_name"];
		//	if(r["calib_type"].GetType().ToString() != "System.DBNull") calib_type = (System.String)r["calib_type"];
		//	if(r["calib_duriation"].GetType().ToString() != "System.DBNull") calib_duriation = (System.Int32)r["calib_duriation"];
		//	if(r["calib_stat_DateTime"].GetType().ToString() != "System.DBNull") calib_stat_DateTime = (System.DateTime)r["calib_stat_DateTime"];
		//	if(r["calib_end_DateTime"].GetType().ToString() != "System.DBNull") calib_end_DateTime = (System.DateTime)r["calib_end_DateTime"];
		//	if(r["ca_set_zero_ts"].GetType().ToString() != "System.DBNull") ca_set_zero_ts = (System.DateTime)r["ca_set_zero_ts"];
		//	if(r["ca_set_zero_stat_flag"].GetType().ToString() != "System.DBNull") ca_set_zero_stat_flag = (System.String)r["ca_set_zero_stat_flag"];
		//	if(r["ca_set_zero_relay_open_ts"].GetType().ToString() != "System.DBNull") ca_set_zero_relay_open_ts = (System.DateTime)r["ca_set_zero_relay_open_ts"];
		//	if(r["ca_set_zero_relay_open_stat_flag"].GetType().ToString() != "System.DBNull") ca_set_zero_relay_open_stat_flag = (System.String)r["ca_set_zero_relay_open_stat_flag"];
		//	if(r["ca_set_zero_relay_close_ts"].GetType().ToString() != "System.DBNull") ca_set_zero_relay_close_ts = (System.DateTime)r["ca_set_zero_relay_close_ts"];
		//	if(r["ca_set_zero_relay_close_stat_flag"].GetType().ToString() != "System.DBNull") ca_set_zero_relay_close_stat_flag = (System.String)r["ca_set_zero_relay_close_stat_flag"];
		//	if(r["ca_real_gas_relay_open_ts"].GetType().ToString() != "System.DBNull") ca_real_gas_relay_open_ts = (System.DateTime)r["ca_real_gas_relay_open_ts"];
		//	if(r["ca_real_gas_relay_open_stat_flag"].GetType().ToString() != "System.DBNull") ca_real_gas_relay_open_stat_flag = (System.String)r["ca_real_gas_relay_open_stat_flag"];
		//	if(r["ca_real_gas_relay_close_ts"].GetType().ToString() != "System.DBNull") ca_real_gas_relay_close_ts = (System.DateTime)r["ca_real_gas_relay_close_ts"];
		//	if(r["ca_real_gas_relay_close_stat_flag"].GetType().ToString() != "System.DBNull") ca_real_gas_relay_close_stat_flag = (System.String)r["ca_real_gas_relay_close_stat_flag"];
		//	if(r["ca_read_prev_value_ts"].GetType().ToString() != "System.DBNull") ca_read_prev_value_ts = (System.DateTime)r["ca_read_prev_value_ts"];
		//	if(r["ca_read_prev_value_stat_flag"].GetType().ToString() != "System.DBNull") ca_read_prev_value_stat_flag = (System.String)r["ca_read_prev_value_stat_flag"];
		//	if(r["calib_set_new_value"].GetType().ToString() != "System.DBNull") calib_set_new_value = (System.Single)r["calib_set_new_value"];
		//	if(r["ca_set_new_value_ts"].GetType().ToString() != "System.DBNull") ca_set_new_value_ts = (System.DateTime)r["ca_set_new_value_ts"];
		//	if(r["ca_set_new_value_stat_flag"].GetType().ToString() != "System.DBNull") ca_set_new_value_stat_flag = (System.String)r["ca_set_new_value_stat_flag"];
		//	if(r["ca_make_span_ts"].GetType().ToString() != "System.DBNull") ca_make_span_ts = (System.DateTime)r["ca_make_span_ts"];
		//	if(r["ca_make_span_stat_flag"].GetType().ToString() != "System.DBNull") ca_make_span_stat_flag = (System.String)r["ca_make_span_stat_flag"];
		//	if(r["creat_ts"].GetType().ToString() != "System.DBNull") creat_ts = (System.DateTime)r["creat_ts"];
		//	if(r["creat_usr"].GetType().ToString() != "System.DBNull") creat_usr = (System.String)r["creat_usr"];
		//	if(r["updt_usr"].GetType().ToString() != "System.DBNull") updt_usr = (System.String)r["updt_usr"];
		//	if(r["updt_ts"].GetType().ToString() != "System.DBNull") updt_ts = (System.DateTime)r["updt_ts"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_calibration> Query_dl_calibration(IDbConnection cn, String sql){
			List<dl_calibration> ret = new List<dl_calibration>();
			IDbCommand cmd = cn.CreateCommand();
			cmd.CommandText = sql;
			using(IDataReader r = cmd.ExecuteReader()){
				DataTable schemaTable = r.GetSchemaTable();
				Dictionary<string, int> fields = new Dictionary<string, int>();
				int i = 0;
				foreach (DataRow row in schemaTable.Rows)
				{
					try{fields.Add(row["ColumnName"].ToString(), i);}
					catch (Exception e)
					{
						// in case ambiguous column names use SELECT news.id AS newsId, user.id AS userId
						// we will default to ColumnName_1 for convience...
						try{fields.Add(row["ColumnName"].ToString() + "_1", i);}
						catch (Exception ex) { //there is a limit to my patience but we could while(1) j++ }
						}
					}
					i++;
				}
				while(r.Read()){
					dl_calibration c = new dl_calibration(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
