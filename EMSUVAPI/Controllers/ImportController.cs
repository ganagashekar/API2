using ChoETL;
using EMSUVAPI.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EMSUVAPI.Controllers
{
    public class ImportController : ApiController
    {


        [HttpPost, Route("api/upload")]
        public async Task<IHttpActionResult> Upload(string CompanyId)
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var buffer = await file.ReadAsByteArrayAsync();

                var createfolder = System.Web.Hosting.HostingEnvironment.MapPath(Path.Combine("~/Attachments/", CompanyId));
                if (!Directory.Exists(createfolder))
                {
                    System.IO.Directory.CreateDirectory(createfolder);
                }
                string SavedFileName = createfolder + "//" + filename;
                File.WriteAllBytes(SavedFileName, buffer);

                ImportData(SavedFileName);
                //DataTable data = new DataTable();
                //BinaryFormatter bformatter = new BinaryFormatter();
                //MemoryStream stream = new MemoryStream();
                //stream = new MemoryStream(buffer);
                //data = (DataTable)bformatter.Deserialize(stream);
                //stream.Close();
                //Do whatever you want with filename and its binary data.
            }

            return Ok();
        }

        static void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=ProductHost;Initial Catalog=yourDB;Integrated Security=SSPI;"))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.DestinationTableName = "Your table name";
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);
                }
            }
        }

        //    public void ImportToServer()
        //    {
        //        var dataReader = new CsvDataReader(filePath,
        //new List<TypeCode>(5)
        //{
        //        TypeCode.String,
        //        TypeCode.Decimal,
        //        TypeCode.String,
        //        TypeCode.Boolean,
        //        TypeCode.DateTime
        //});

        //        bulkCopyUtility.BulkCopy("TableName", dataReader);
        //    }


        //public void ImportTableFromFile(string FilePath)
        //{
        // //   using (var fileStream = new FileStream(filenameSql, FileMode.Open, FileAccess.Read))
        //    using (var streamReader = new CsvDataReader(FilePath))
        //    {
        //        string connectionstring = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        //        //var externalTransaction = _transaction != null ? _transaction.Transaction : null;
        //        //var executeQuery = _sqlServer.ExecuteQuery("select top 1 * from " + table, _transaction);
        //        using (var bc = new SqlBulkCopy(connectionstring, SqlBulkCopyOptions.TableLock))
        //        {

        //            bc.BatchSize = 10000;
        //            bc.BulkCopyTimeout = 6000; //10 Minutes
        //            bc.DestinationTableName = table;

        //            IDataReader dt = new CsvDataReader(streamReader);
        //            bc.WriteToServer(dt);
        //            bc.Close();
        //        }
        //    }
        //}

        public void ImportData(string FilePath)
        {
            try
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
                // string connectionstring = @"#YOUR DB ConnectionString#";
                using (SqlBulkCopy bcp = new SqlBulkCopy(connectionstring))
                {


                    using (var p = new ChoCSVReader<ImportData>(FilePath).WithFirstLineHeader())
                    {
                        var data = p.AsDataReader();

                      //  var datsa = p.AsDataTable();
                        bcp.DestinationTableName = "dektos.dl_data";
                        bcp.ColumnMappings.Add("confg_id", "confg_id");
                        bcp.ColumnMappings.Add("param_name", "param_name");
                        bcp.ColumnMappings.Add("param_value", "param_value");
                        bcp.ColumnMappings.Add("creat_ts", "creat_ts");
                        bcp.ColumnMappings.Add("param_id", "param_id");
                        bcp.EnableStreaming = true;
                        bcp.BatchSize = 10000;
                        bcp.BulkCopyTimeout = 0;
                        bcp.NotifyAfter = 100;
                        //bcp.SqlRowsCopied += delegate (object sender, SqlRowsCopiedEventArgs e)
                        //{
                        //    Console.WriteLine(e.RowsCopied.ToString("#,##0") + " rows copied.");
                        //};
                        bcp.WriteToServer(p.AsDataTable());
                        bcp.Close();
                     }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
