using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_calib_cmd_setup", Schema = "dektos")]
    public class dl_calib_cmd_setup
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public System.Int64 calib_cmd_id{get;set;}
		public System.Int64 confg_id{get;set;}
		public System.String stack_name{get;set;}
		public System.String param_name{get;set;}
		public System.String ca_set_zero_cmd{get;set;}
		public System.String ca_set_zero_resp{get;set;}
		public System.String ca_set_zero_relay_open_cmd{get;set;}
		public System.String ca_set_zero_relay_open_resp{get;set;}
		public System.String ca_set_zero_relay_close_cmd{get;set;}
		public System.String ca_set_zero_relay_close_resp{get;set;}
		public System.String ca_read_prev_value_cmd{get;set;}
		public System.String ca_read_prev_value_res{get;set;}
		public System.String ca_real_gas_relay_open_cmd{get;set;}
		public System.String ca_real_gas_relay_open_resp{get;set;}
		public System.String ca_real_gas_relay_close_cmd{get;set;}
		public System.String ca_real_gas_relay_close_resp{get;set;}
		public System.String ca_set_new_value_cmd{get;set;}
		public System.String ca_set_new_value_resp{get;set;}
		public System.String ca_set_make_span_cmd{get;set;}
		public System.String ca_set_make_span_resp{get;set;}
		public System.DateTime creat_ts{get;set;}
		public System.String creat_usr{get;set;}
		public System.String updt_usr{get;set;}
		public System.DateTime updt_ts{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_calib_cmd_setup(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["calib_cmd_id"].GetType().ToString() != "System.DBNull") calib_cmd_id = (System.Int64)r["calib_cmd_id"];
		//	if(r["confg_id"].GetType().ToString() != "System.DBNull") confg_id = (System.Int64)r["confg_id"];
		//	if(r["stack_name"].GetType().ToString() != "System.DBNull") stack_name = (System.String)r["stack_name"];
		//	if(r["param_name"].GetType().ToString() != "System.DBNull") param_name = (System.String)r["param_name"];
		//	if(r["ca_set_zero_cmd"].GetType().ToString() != "System.DBNull") ca_set_zero_cmd = (System.String)r["ca_set_zero_cmd"];
		//	if(r["ca_set_zero_resp"].GetType().ToString() != "System.DBNull") ca_set_zero_resp = (System.String)r["ca_set_zero_resp"];
		//	if(r["ca_set_zero_relay_open_cmd"].GetType().ToString() != "System.DBNull") ca_set_zero_relay_open_cmd = (System.String)r["ca_set_zero_relay_open_cmd"];
		//	if(r["ca_set_zero_relay_open_resp"].GetType().ToString() != "System.DBNull") ca_set_zero_relay_open_resp = (System.String)r["ca_set_zero_relay_open_resp"];
		//	if(r["ca_set_zero_relay_close_cmd"].GetType().ToString() != "System.DBNull") ca_set_zero_relay_close_cmd = (System.String)r["ca_set_zero_relay_close_cmd"];
		//	if(r["ca_set_zero_relay_close_resp"].GetType().ToString() != "System.DBNull") ca_set_zero_relay_close_resp = (System.String)r["ca_set_zero_relay_close_resp"];
		//	if(r["ca_read_prev_value_cmd"].GetType().ToString() != "System.DBNull") ca_read_prev_value_cmd = (System.String)r["ca_read_prev_value_cmd"];
		//	if(r["ca_read_prev_value_res"].GetType().ToString() != "System.DBNull") ca_read_prev_value_res = (System.String)r["ca_read_prev_value_res"];
		//	if(r["ca_real_gas_relay_open_cmd"].GetType().ToString() != "System.DBNull") ca_real_gas_relay_open_cmd = (System.String)r["ca_real_gas_relay_open_cmd"];
		//	if(r["ca_real_gas_relay_open_resp"].GetType().ToString() != "System.DBNull") ca_real_gas_relay_open_resp = (System.String)r["ca_real_gas_relay_open_resp"];
		//	if(r["ca_real_gas_relay_close_cmd"].GetType().ToString() != "System.DBNull") ca_real_gas_relay_close_cmd = (System.String)r["ca_real_gas_relay_close_cmd"];
		//	if(r["ca_real_gas_relay_close_resp"].GetType().ToString() != "System.DBNull") ca_real_gas_relay_close_resp = (System.String)r["ca_real_gas_relay_close_resp"];
		//	if(r["ca_set_new_value_cmd"].GetType().ToString() != "System.DBNull") ca_set_new_value_cmd = (System.String)r["ca_set_new_value_cmd"];
		//	if(r["ca_set_new_value_resp"].GetType().ToString() != "System.DBNull") ca_set_new_value_resp = (System.String)r["ca_set_new_value_resp"];
		//	if(r["ca_set_make_span_cmd"].GetType().ToString() != "System.DBNull") ca_set_make_span_cmd = (System.String)r["ca_set_make_span_cmd"];
		//	if(r["ca_set_make_span_resp"].GetType().ToString() != "System.DBNull") ca_set_make_span_resp = (System.String)r["ca_set_make_span_resp"];
		//	if(r["creat_ts"].GetType().ToString() != "System.DBNull") creat_ts = (System.DateTime)r["creat_ts"];
		//	if(r["creat_usr"].GetType().ToString() != "System.DBNull") creat_usr = (System.String)r["creat_usr"];
		//	if(r["updt_usr"].GetType().ToString() != "System.DBNull") updt_usr = (System.String)r["updt_usr"];
		//	if(r["updt_ts"].GetType().ToString() != "System.DBNull") updt_ts = (System.DateTime)r["updt_ts"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_calib_cmd_setup> Query_dl_calib_cmd_setup(IDbConnection cn, String sql){
			List<dl_calib_cmd_setup> ret = new List<dl_calib_cmd_setup>();
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
					dl_calib_cmd_setup c = new dl_calib_cmd_setup(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
