using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_controller", Schema = "dektos")]
    public class dl_controller
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public System.String mac_id{get;set;}

		public System.String os_typ{get;set;}
		public System.String cpcb_url{get;set;}
		public System.String spcb_url{get;set;}
		public System.String license_key{get;set;}
		public System.DateTime updt_ts{get;set;}

        public long site_id { get; set; }
        [ForeignKey("site_id")]
        public virtual dl_site dl_sites { get; set; }

        public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_controller(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["mac_id"].GetType().ToString() != "System.DBNull") mac_id = (System.String)r["mac_id"];
		//	if(r["site_id"].GetType().ToString() != "System.DBNull") site_id = (System.String)r["site_id"];
		//	if(r["os_typ"].GetType().ToString() != "System.DBNull") os_typ = (System.String)r["os_typ"];
		//	if(r["cpcb_url"].GetType().ToString() != "System.DBNull") cpcb_url = (System.String)r["cpcb_url"];
		//	if(r["spcb_url"].GetType().ToString() != "System.DBNull") spcb_url = (System.String)r["spcb_url"];
		//	if(r["license_key"].GetType().ToString() != "System.DBNull") license_key = (System.String)r["license_key"];
		//	if(r["updt_ts"].GetType().ToString() != "System.DBNull") updt_ts = (System.DateTime)r["updt_ts"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_controller> Query_dl_controller(IDbConnection cn, String sql){
			List<dl_controller> ret = new List<dl_controller>();
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
					dl_controller c = new dl_controller(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
