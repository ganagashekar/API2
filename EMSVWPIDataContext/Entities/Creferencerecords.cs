using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("Referencerecords", Schema = "dektos")]
    public class Referencerecords
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public long Id{get;set;}
		public System.String Name{get;set;}
		public System.Int64 ReferenceRecordTyepId{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public Referencerecords(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["Id"].GetType().ToString() != "System.DBNull") Id = (System.Int32)r["Id"];
		//	if(r["Name"].GetType().ToString() != "System.DBNull") Name = (System.String)r["Name"];
		//	if(r["ReferenceRecordTyepId"].GetType().ToString() != "System.DBNull") ReferenceRecordTyepId = (System.Int64)r["ReferenceRecordTyepId"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<Creferencerecords> Query_referencerecords(IDbConnection cn, String sql){
			List<Creferencerecords> ret = new List<Creferencerecords>();
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
					Creferencerecords c = new Creferencerecords(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
