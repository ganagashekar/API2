using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("Referencerecordtypes", Schema = "dektos")]
    public class Referencerecordtypes
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public System.Int64 Id{get;set;}
		public System.String Name{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public Referencerecordtypes(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["Id"].GetType().ToString() != "System.DBNull") Id = (System.Int64)r["Id"];
		//	if(r["Name"].GetType().ToString() != "System.DBNull") Name = (System.String)r["Name"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<Creferencerecordtypes> Query_referencerecordtypes(IDbConnection cn, String sql){
			List<Creferencerecordtypes> ret = new List<Creferencerecordtypes>();
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
					Creferencerecordtypes c = new Creferencerecordtypes(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
