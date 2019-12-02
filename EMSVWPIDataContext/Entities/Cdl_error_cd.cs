using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{

    [Table("dl_error_cd", Schema = "dektos")]
    public class dl_error_cd
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public System.String error_code{get;set;}
		public System.String error_desc{get;set;}
		public System.DateTime creat_ts{get;set;}
		public System.DateTime updt_ts{get;set;}
		public System.String last_updt_usr{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_error_cd(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["error_code"].GetType().ToString() != "System.DBNull") error_code = (System.String)r["error_code"];
		//	if(r["error_desc"].GetType().ToString() != "System.DBNull") error_desc = (System.String)r["error_desc"];
		//	if(r["creat_ts"].GetType().ToString() != "System.DBNull") creat_ts = (System.DateTime)r["creat_ts"];
		//	if(r["updt_ts"].GetType().ToString() != "System.DBNull") updt_ts = (System.DateTime)r["updt_ts"];
		//	if(r["last_updt_usr"].GetType().ToString() != "System.DBNull") last_updt_usr = (System.String)r["last_updt_usr"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_error_cd> Query_dl_error_cd(IDbConnection cn, String sql){
			List<dl_error_cd> ret = new List<dl_error_cd>();
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
					dl_error_cd c = new dl_error_cd(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
