using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_param", Schema = "dektos")]
    public class dl_param
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public long param_id { get; set; }
        public long? confg_id { get; set; }
        [ForeignKey("confg_id")]
        public virtual dl_confg dl_confgs { get; set; }
        public string param_name { get; set; }
        public string param_unit { get; set; }
        public string param_min_val { get; set; }
        public string param_max_val { get; set; }
        public int? threshhold_val { get; set; }
        public int? param_position { get; set; }
        public int? length { get; set; }
        public DateTime creat_ts { get; set; }
        public DateTime updt_ts { get; set; }

  //      public object GetRaw(string field)
		//{
		//	if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
		//	return new object();
		//}

		//public dl_param(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["param_id"].GetType().ToString() != "System.DBNull") param_id = (System.Int64)r["param_id"];
		//	if(r["confg_id"].GetType().ToString() != "System.DBNull") confg_id = (System.Int64)r["confg_id"];
		//	if(r["param_name"].GetType().ToString() != "System.DBNull") param_name = (System.String)r["param_name"];
		//	if(r["param_unit"].GetType().ToString() != "System.DBNull") param_unit = (System.String)r["param_unit"];
		//	if(r["param_min_val"].GetType().ToString() != "System.DBNull") param_min_val = (System.String)r["param_min_val"];
		//	if(r["param_max_val"].GetType().ToString() != "System.DBNull") param_max_val = (System.String)r["param_max_val"];
		//	if(r["threshhold_val"].GetType().ToString() != "System.DBNull") threshhold_val = (System.Int32)r["threshhold_val"];
		//	if(r["param_position"].GetType().ToString() != "System.DBNull") param_position = (System.Int32)r["param_position"];
		//	if(r["length"].GetType().ToString() != "System.DBNull") length = (System.Int32)r["length"];
		//	if(r["creat_ts"].GetType().ToString() != "System.DBNull") creat_ts = (System.DateTime)r["creat_ts"];
		//	if(r["updt_ts"].GetType().ToString() != "System.DBNull") updt_ts = (System.DateTime)r["updt_ts"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_param> Query_dl_param(IDbConnection cn, String sql){
			List<dl_param> ret = new List<dl_param>();
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
					dl_param c = new dl_param(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
