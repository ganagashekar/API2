using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSVWPIDataContext.Entities
{
    [Table("dl_site", Schema = "dektos")]
    public class dl_site
	{
		public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		public object[] RawValues;             //  /

        [Key]
        public long site_id{get;set;}
		public System.String site_name{get;set;}
		public System.String site_logo{get;set;}
		public System.String site_cpcb_cd{get;set;}
		public System.String site_ind_type{get;set;}
		public System.String site_in_ganga_basin{get;set;}
		public System.String site_prmry_cnct_name{get;set;}
		public System.String site_prmry_cnct_ph_num{get;set;}
		public System.String site_prmry_cnct_email{get;set;}
		public System.String site_second_cnct_name{get;set;}
		public System.String site_second_cnct_ph_num{get;set;}
		public System.String site_second_cnct_email{get;set;}
		public System.String site_latitude{get;set;}
		public System.String site_longitude{get;set;}
		public System.String site_addr_1{get;set;}
		public System.String site_addr_2{get;set;}
		public System.String site_pin_cd{get;set;}
		public System.String site_city{get;set;}
		public System.String site_district{get;set;}
		public System.String site_state{get;set;}
		public System.String site_country{get;set;}
		public System.DateTime creat_ts{get;set;}
		public System.DateTime updt_ts{get;set;}

		public object GetRaw(string field)
		{
			if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			return new object();
		}

		//public dl_site(IDataReader r, Dictionary<string, int> schema)
		//{
		//	Schema = schema;
		//	RawValues = new object[r.FieldCount];
		//	r.GetValues(RawValues);


		//	if(r["site_id"].GetType().ToString() != "System.DBNull") site_id = (System.String)r["site_id"];
		//	if(r["site_name"].GetType().ToString() != "System.DBNull") site_name = (System.String)r["site_name"];
		//	if(r["site_logo"].GetType().ToString() != "System.DBNull") site_logo = (System.String)r["site_logo"];
		//	if(r["site_cpcb_cd"].GetType().ToString() != "System.DBNull") site_cpcb_cd = (System.String)r["site_cpcb_cd"];
		//	if(r["site_ind_type"].GetType().ToString() != "System.DBNull") site_ind_type = (System.String)r["site_ind_type"];
		//	if(r["site_in_ganga_basin"].GetType().ToString() != "System.DBNull") site_in_ganga_basin = (System.String)r["site_in_ganga_basin"];
		//	if(r["site_prmry_cnct_name"].GetType().ToString() != "System.DBNull") site_prmry_cnct_name = (System.String)r["site_prmry_cnct_name"];
		//	if(r["site_prmry_cnct_ph_num"].GetType().ToString() != "System.DBNull") site_prmry_cnct_ph_num = (System.String)r["site_prmry_cnct_ph_num"];
		//	if(r["site_prmry_cnct_email"].GetType().ToString() != "System.DBNull") site_prmry_cnct_email = (System.String)r["site_prmry_cnct_email"];
		//	if(r["site_second_cnct_name"].GetType().ToString() != "System.DBNull") site_second_cnct_name = (System.String)r["site_second_cnct_name"];
		//	if(r["site_second_cnct_ph_num"].GetType().ToString() != "System.DBNull") site_second_cnct_ph_num = (System.String)r["site_second_cnct_ph_num"];
		//	if(r["site_second_cnct_email"].GetType().ToString() != "System.DBNull") site_second_cnct_email = (System.String)r["site_second_cnct_email"];
		//	if(r["site_latitude"].GetType().ToString() != "System.DBNull") site_latitude = (System.String)r["site_latitude"];
		//	if(r["site_longitude"].GetType().ToString() != "System.DBNull") site_longitude = (System.String)r["site_longitude"];
		//	if(r["site_addr_1"].GetType().ToString() != "System.DBNull") site_addr_1 = (System.String)r["site_addr_1"];
		//	if(r["site_addr_2"].GetType().ToString() != "System.DBNull") site_addr_2 = (System.String)r["site_addr_2"];
		//	if(r["site_pin_cd"].GetType().ToString() != "System.DBNull") site_pin_cd = (System.String)r["site_pin_cd"];
		//	if(r["site_city"].GetType().ToString() != "System.DBNull") site_city = (System.String)r["site_city"];
		//	if(r["site_district"].GetType().ToString() != "System.DBNull") site_district = (System.String)r["site_district"];
		//	if(r["site_state"].GetType().ToString() != "System.DBNull") site_state = (System.String)r["site_state"];
		//	if(r["site_country"].GetType().ToString() != "System.DBNull") site_country = (System.String)r["site_country"];
		//	if(r["creat_ts"].GetType().ToString() != "System.DBNull") creat_ts = (System.DateTime)r["creat_ts"];
		//	if(r["updt_ts"].GetType().ToString() != "System.DBNull") updt_ts = (System.DateTime)r["updt_ts"];

		//}

		//Access function: expects open connection, no error handling
		/*
		public List<dl_site> Query_dl_site(IDbConnection cn, String sql){
			List<dl_site> ret = new List<dl_site>();
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
					dl_site c = new dl_site(r,fields);
					ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}*/
	}
}
