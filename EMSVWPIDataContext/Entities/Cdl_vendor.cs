using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_vendor", Schema = "dektos")]
    public class dl_vendor
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public long vendor_id{get;set;}
		public System.String vendor_name{get;set;}
		public System.String cnct_ph_num{get;set;}
		public System.String cnct_email{get;set;}
		public System.DateTime creat_ts{get;set;}
		public System.DateTime updt_ts{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_vendor(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["vendor_id"].GetType().ToString() != "System.DBNull") vendor_id = (System.String)r["vendor_id"];
		//	if(r["vendor_name"].GetType().ToString() != "System.DBNull") vendor_name = (System.String)r["vendor_name"];
		//	if(r["cnct_ph_num"].GetType().ToString() != "System.DBNull") cnct_ph_num = (System.String)r["cnct_ph_num"];
		//	if(r["cnct_email"].GetType().ToString() != "System.DBNull") cnct_email = (System.String)r["cnct_email"];
		//	if(r["creat_ts"].GetType().ToString() != "System.DBNull") creat_ts = (System.DateTime)r["creat_ts"];
		//	if(r["updt_ts"].GetType().ToString() != "System.DBNull") updt_ts = (System.DateTime)r["updt_ts"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_vendor> Query_dl_vendor(IDbConnection cn, String sql){
			List<dl_vendor> ret = new List<dl_vendor>();
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
					dl_vendor c = new dl_vendor(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
