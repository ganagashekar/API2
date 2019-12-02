using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_confg", Schema = "dektos")]
    public class dl_confg
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public System.Int64 confg_id{get;set;}
		public long site_id{get;set;}
        [ForeignKey("site_id")]
        public virtual dl_site dl_site { get; set; }
        public System.Int64 bus_id{get;set;}

		public System.String stack_name{get;set;}
		public System.String stack_typ{get;set;}
		public System.Int32? cnfg_slave_id{get;set;}
		public System.Int32? cnfg_hold_reg{get;set;}
		public System.Int32? cnfg_reg_first{get;set;}
		public System.Int32? cnfg_reg_len{get;set;}
		public System.Int32? cnfg_stop_bit{get;set;}
		public System.String cnfg_parity{get;set;}
		public System.String stack_status{get;set;}
		public System.String stack_status_reason{get;set;}
		public System.String updt_usr{get;set;}
		public System.String input_format{get;set;}
		public System.String cnfg_input_str{get;set;}
		public System.String output_format{get;set;}
		public System.String disp_output_typ{get;set;}
		public System.DateTime creat_ts{get;set;}
		public System.DateTime updt_ts{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_confg(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["confg_id"].GetType().ToString() != "System.DBNull") confg_id = (System.Int64)r["confg_id"];
		//	if(r["site_id"].GetType().ToString() != "System.DBNull") site_id = (System.String)r["site_id"];
		//	if(r["bus_id"].GetType().ToString() != "System.DBNull") bus_id = (System.Int64)r["bus_id"];
		//	if(r["vendor_id"].GetType().ToString() != "System.DBNull") vendor_id = (System.String)r["vendor_id"];
		//	if(r["stack_name"].GetType().ToString() != "System.DBNull") stack_name = (System.String)r["stack_name"];
		//	if(r["stack_typ"].GetType().ToString() != "System.DBNull") stack_typ = (System.String)r["stack_typ"];
		//	if(r["cnfg_slave_id"].GetType().ToString() != "System.DBNull") cnfg_slave_id = (System.Int32)r["cnfg_slave_id"];
		//	if(r["cnfg_hold_reg"].GetType().ToString() != "System.DBNull") cnfg_hold_reg = (System.Int32)r["cnfg_hold_reg"];
		//	if(r["cnfg_reg_first"].GetType().ToString() != "System.DBNull") cnfg_reg_first = (System.Int32)r["cnfg_reg_first"];
		//	if(r["cnfg_reg_len"].GetType().ToString() != "System.DBNull") cnfg_reg_len = (System.Int32)r["cnfg_reg_len"];
		//	if(r["cnfg_stop_bit"].GetType().ToString() != "System.DBNull") cnfg_stop_bit = (System.Int32)r["cnfg_stop_bit"];
		//	if(r["cnfg_parity"].GetType().ToString() != "System.DBNull") cnfg_parity = (System.String)r["cnfg_parity"];
		//	if(r["stack_status"].GetType().ToString() != "System.DBNull") stack_status = (System.String)r["stack_status"];
		//	if(r["stack_status_reason"].GetType().ToString() != "System.DBNull") stack_status_reason = (System.String)r["stack_status_reason"];
		//	if(r["updt_usr"].GetType().ToString() != "System.DBNull") updt_usr = (System.String)r["updt_usr"];
		//	if(r["input_format"].GetType().ToString() != "System.DBNull") input_format = (System.String)r["input_format"];
		//	if(r["cnfg_input_str"].GetType().ToString() != "System.DBNull") cnfg_input_str = (System.String)r["cnfg_input_str"];
		//	if(r["output_format"].GetType().ToString() != "System.DBNull") output_format = (System.String)r["output_format"];
		//	if(r["disp_output_typ"].GetType().ToString() != "System.DBNull") disp_output_typ = (System.String)r["disp_output_typ"];
		//	if(r["creat_ts"].GetType().ToString() != "System.DBNull") creat_ts = (System.DateTime)r["creat_ts"];
		//	if(r["updt_ts"].GetType().ToString() != "System.DBNull") updt_ts = (System.DateTime)r["updt_ts"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_confg> Query_dl_confg(IDbConnection cn, String sql){
			List<dl_confg> ret = new List<dl_confg>();
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
					dl_confg c = new dl_confg(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
