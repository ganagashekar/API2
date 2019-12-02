using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_data", Schema = "dektos")]
    public class dl_data
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public System.Int64 data_id{get;set;}
		public System.Int64 confg_id{get;set;}
        [ForeignKey("confg_id")]
        public virtual dl_confg dl_confg { get; set; }
        public System.String param_name{get;set;}

        public long param_id { get; set; }
        [ForeignKey("param_id")]
        public virtual dl_param dl_param { get; set; }

        public System.Single param_value{get;set;}
		public System.String process_flag{get;set;}
		public System.DateTime creat_ts{get;set;}
		public System.DateTime received_ts{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

        #region Commentted
        //public dl_data(IDataReader r, Dictionary<string, int> schema)
        //{
        //	Schema = schema;
        //	RawValues = new object[r.FieldCount];
        //	r.GetValues(RawValues);


        //	if(r["data_id"].GetType().ToString() != "System.DBNull") data_id = (System.Int64)r["data_id"];
        //	if(r["confg_id"].GetType().ToString() != "System.DBNull") confg_id = (System.Int64)r["confg_id"];
        //	if(r["param_name"].GetType().ToString() != "System.DBNull") param_name = (System.String)r["param_name"];
        //	if(r["param_value"].GetType().ToString() != "System.DBNull") param_value = (System.Single)r["param_value"];
        //	if(r["process_flag"].GetType().ToString() != "System.DBNull") process_flag = (System.String)r["process_flag"];
        //	if(r["creat_ts"].GetType().ToString() != "System.DBNull") creat_ts = (System.DateTime)r["creat_ts"];
        //	if(r["received_ts"].GetType().ToString() != "System.DBNull") received_ts = (System.DateTime)r["received_ts"];

        //}

        //Access function: expects open connection, no error handling
        /*
		public List<dl_data> Query_dl_data(IDbConnection cn, String sql){
			List<dl_data> ret = new List<dl_data>();
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
					dl_data c = new dl_data(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/

        #endregion
    }
}
