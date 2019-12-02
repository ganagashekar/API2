using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_controller_bus", Schema = "dektos")]
    public class dl_controller_bus
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public System.Int64 bus_id{get;set;}
		public System.String mac_id{get;set;}
		public System.String com_port{get;set;}
		public System.Int64 baud_rate{get;set;}
		public System.Int32 time_out{get;set;}
		public System.Int32 data_byte_stat_indx{get;set;}
		public System.String protocal{get;set;}
		public System.DateTime updt_ts{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_controller_bus(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["bus_id"].GetType().ToString() != "System.DBNull") bus_id = (System.Int64)r["bus_id"];
		//	if(r["mac_id"].GetType().ToString() != "System.DBNull") mac_id = (System.String)r["mac_id"];
		//	if(r["com_port"].GetType().ToString() != "System.DBNull") com_port = (System.String)r["com_port"];
		//	if(r["baud_rate"].GetType().ToString() != "System.DBNull") baud_rate = (System.Int64)r["baud_rate"];
		//	if(r["time_out"].GetType().ToString() != "System.DBNull") time_out = (System.Int32)r["time_out"];
		//	if(r["data_byte_stat_indx"].GetType().ToString() != "System.DBNull") data_byte_stat_indx = (System.Int32)r["data_byte_stat_indx"];
		//	if(r["protocal"].GetType().ToString() != "System.DBNull") protocal = (System.String)r["protocal"];
		//	if(r["updt_ts"].GetType().ToString() != "System.DBNull") updt_ts = (System.DateTime)r["updt_ts"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_controller_bus> Query_dl_controller_bus(IDbConnection cn, String sql){
			List<dl_controller_bus> ret = new List<dl_controller_bus>();
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
					dl_controller_bus c = new dl_controller_bus(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
