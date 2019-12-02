using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_audit", Schema = "dektos")]
    public class dl_audit
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
		public System.Int64 audit_id{get;set;}
		public System.String site_id{get;set;}
		public System.Int64 confg_id{get;set;}
		public System.String stack_name{get;set;}
		public System.String param_name{get;set;}
		public System.Single param_val{get;set;}
		public System.String audit_reason{get;set;}
		public System.DateTime param_prod_time{get;set;}
		public System.DateTime creat_ts{get;set;}
		public System.String email_ind{get;set;}
		public System.String sms_ind{get;set;}
		public System.String ack_msg{get;set;}
		public System.DateTime ack_ts{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_audit(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["audit_id"].GetType().ToString() != "System.DBNull") audit_id = (System.Int64)r["audit_id"];
		//	if(r["site_id"].GetType().ToString() != "System.DBNull") site_id = (System.String)r["site_id"];
		//	if(r["confg_id"].GetType().ToString() != "System.DBNull") confg_id = (System.Int64)r["confg_id"];
		//	if(r["stack_name"].GetType().ToString() != "System.DBNull") stack_name = (System.String)r["stack_name"];
		//	if(r["param_name"].GetType().ToString() != "System.DBNull") param_name = (System.String)r["param_name"];
		//	if(r["param_val"].GetType().ToString() != "System.DBNull") param_val = (System.Single)r["param_val"];
		//	if(r["audit_reason"].GetType().ToString() != "System.DBNull") audit_reason = (System.String)r["audit_reason"];
		//	if(r["param_prod_time"].GetType().ToString() != "System.DBNull") param_prod_time = (System.DateTime)r["param_prod_time"];
		//	if(r["creat_ts"].GetType().ToString() != "System.DBNull") creat_ts = (System.DateTime)r["creat_ts"];
		//	if(r["email_ind"].GetType().ToString() != "System.DBNull") email_ind = (System.String)r["email_ind"];
		//	if(r["sms_ind"].GetType().ToString() != "System.DBNull") sms_ind = (System.String)r["sms_ind"];
		//	if(r["ack_msg"].GetType().ToString() != "System.DBNull") ack_msg = (System.String)r["ack_msg"];
		//	if(r["ack_ts"].GetType().ToString() != "System.DBNull") ack_ts = (System.DateTime)r["ack_ts"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_audit> Query_dl_audit(IDbConnection cn, String sql){
			List<dl_audit> ret = new List<dl_audit>();
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
					dl_audit c = new dl_audit(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
