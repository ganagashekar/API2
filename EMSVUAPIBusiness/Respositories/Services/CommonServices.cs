using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SpreadSheet= DocumentFormat.OpenXml.Spreadsheet;
using System.Threading.Tasks;
using System.IO;
using EMSVUAPIBusiness.Respositories.IServices;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using EMSVExtentions;
using System.Drawing;
using EMSVWPIDataContext;
using System.Linq;
using EMSVAPIModel.InuputModel;
using LinqKit;
using EMSVWPIDataContext.Entities;

namespace EMSVUAPIBusiness.Respositories.Services
{
    public class CommonServices : ICommonServices
    {
        private readonly DatabaseContext _dbContext;

       // public CommonServices(DatabaseContext dbContext)
             public CommonServices()
        {
            _dbContext = new DatabaseContext();
            //_dbContext = dbContext;
        }



        public Task<byte[]> ExportDataSet(DataTable ds, ReportRequestModel report)
        {
            int ColumnLength = ds.Columns.Count;
            string excelLetter = (ds.Columns.Count - 1).GetColumnName();
            byte[] excelbytearray = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (var package = new ExcelPackage(memoryStream))
                {
                    try
                    {
                        var ws = package.Workbook.Worksheets.Add(report.ReportType ?? string.Empty);
                        ws.Cells["A1"].Value = report.ReportTitle;
                        //ws.Cells[1, 1, 1, ColumnLength].Merge = true;
                        ws.Cells[1, 1, 2, ColumnLength].Merge = true;
                        ws.Cells[1, 1, 2, ColumnLength].Style.Font.Size = 20;
                        ws.Cells[1, 1, 2, ColumnLength].Style.Font.Bold = true;

                        ws.Cells["A3"].Value = report.SiteName ?? string.Empty;
                        ws.Cells[3, 1, 3, ColumnLength].Merge = true;
                        ws.Cells[3, 1, 3, ColumnLength].Style.Font.Bold = true;
                        // ws.Cells[3, 1, 1, ColumnLength].Merge = true;

                        ws.Cells["A4"].Value = report.ReportType ?? string.Empty;
                        ws.Cells[4, 1, 4, ColumnLength].Merge = true;
                        ws.Cells[4, 1, 4, ColumnLength].Style.Font.Bold = true;

                        ws.Cells["A5"].Value = string.Format("Report Created by {0} and requested user {1} on {2}", report.SiteCode ?? string.Empty, report.RequestedUser ?? string.Empty, DateTime.Now.ToString());
                        ws.Cells[5, 1, 5, ColumnLength].Merge = true;
                        ws.Cells[5, 1, 5, ColumnLength].Style.Font.Bold = true;

                        ws.Cells["A6"].Value = string.Format("Report Generated From {0} to {1}", report.FromDate.ToString(), report.ToDate.ToString());
                        ws.Cells[6, 1, 6, ColumnLength].Merge = true;
                        ws.Cells[6, 1, 6, ColumnLength].Style.Font.Bold = true;

                        ws.Cells[1, 1, 2, ColumnLength].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[3, 1, 6, ColumnLength].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //  ws.Cells[4, 1, 4, ColumnLength].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[1, 1, 2, ColumnLength].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[3, 1, 6, ColumnLength].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        // ws.Cells[4, 1, 4, ColumnLength].Style.Fill.PatternType = ExcelFillStyle.Solid;

                        ws.Cells[1, 1, 1, ColumnLength].Style.Fill.BackgroundColor.SetColor((System.Drawing.ColorTranslator.FromHtml("#D8E4BC")));
                        ws.Cells[3, 1, 6, ColumnLength].Style.Fill.BackgroundColor.SetColor((System.Drawing.ColorTranslator.FromHtml("#D8E4BC")));
                        //  ws.Cells[4, 1, 4, ColumnLength].Style.Fill.BackgroundColor.SetColor((System.Drawing.ColorTranslator.FromHtml("#D8E4BC")));



                        ws.Cells[7,1].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss AM/PM";
                        ws.Cells[7, 1].LoadFromDataTable(ds, true).AutoFitColumns();


                        ws.Cells.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                        ws.Cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                        ws.Cells.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                        ws.Cells.Style.Border.Right.Style = ExcelBorderStyle.Thick;

                        ws.Cells.Style.Border.Top.Color.SetColor(System.Drawing.Color.White);
                        ws.Cells.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.White);
                        ws.Cells.Style.Border.Left.Color.SetColor(System.Drawing.Color.White);
                        ws.Cells.Style.Border.Right.Color.SetColor(System.Drawing.Color.White);
                        var headerCell = ws.Cells["A7:" + excelLetter + "7"];
                        headerCell.Style.Fill.PatternType = ExcelFillStyle.Solid;

                        headerCell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#4CAEE3"));
                        var headerFont = headerCell.Style.Font;
                        headerFont.Bold = true;
                        headerFont.Color.SetColor(System.Drawing.Color.White);
                        int totalRow = ws.Dimension.End.Row;
                        int totalCol = ws.Dimension.End.Column;
                        using (ExcelRange rng = ws.Cells[8, 1, totalRow, totalCol])
                        {

                            rng.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                            rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                            rng.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                            rng.Style.Border.Right.Style = ExcelBorderStyle.Thick;

                            rng.Style.Border.Top.Color.SetColor(System.Drawing.Color.White);
                            rng.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.White);
                            rng.Style.Border.Left.Color.SetColor(System.Drawing.Color.White);
                            rng.Style.Border.Right.Color.SetColor(System.Drawing.Color.White);

                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.AliceBlue);

                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }



                    package.Save();
                }
                excelbytearray = memoryStream.ToArray();
            }
            return Task.FromResult(excelbytearray);
        }
    }
}
