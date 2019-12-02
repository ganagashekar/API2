using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_vendor_sites", Schema = "dektos")]
    public class dl_vendor_sites
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /
        [Key]
        public long vendor_siteid { set; get; }

        public long vendor_id{get;set;}
        [ForeignKey("vendor_id")]
        public virtual dl_vendor dl_param { get; set; }

        public long site_id{get;set;}
        [ForeignKey("site_id")]
        public virtual dl_site dl_Site { get; set; }

        public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_vendor_sites(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["vendor_id"].GetType().ToString() != "System.DBNull") vendor_id = (System.String)r["vendor_id"];
		//	if(r["site_id"].GetType().ToString() != "System.DBNull") site_id = (System.String)r["site_id"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_vendor_sites> Query_dl_vendor_sites(IDbConnection cn, String sql){
			List<dl_vendor_sites> ret = new List<dl_vendor_sites>();
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
					dl_vendor_sites c = new dl_vendor_sites(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
