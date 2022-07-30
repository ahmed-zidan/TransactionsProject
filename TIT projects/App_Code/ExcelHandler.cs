using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using ExcelDataReader;

using ClosedXML.Excel;


/// <summary>
/// Summary description for ExcelHandler
/// </summary>
public class ExcelHandler
{
    public ExcelHandler()
    {

    }


    public static void generateExcelFile(DataTable dt, string path)
    {
        FileInfo fileInfo = new FileInfo(@path);

        //for making synchronizaton in momory and prevent all program to be stucked
        //await 
        saveExcelFile(dt, fileInfo);
    }

    private static void saveExcelFile(DataTable dt, FileInfo fileInfo)
    {
        //delete sheet if exists
        DeleteIfFileExists(fileInfo);


        var package = new OfficeOpenXml.ExcelPackage(fileInfo);

        //create sheet inside excel file
        var ws = package.Workbook.Worksheets.Add("MainSheet");

        //start from first row first column
        var range = ws.Cells["A1"].LoadFromDataTable(dt, true);
        range.AutoFitColumns(); //table has header

        //format header
        ws.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;//center headers
        ws.Row(1).Style.Font.Bold = true;

        //await

        package.SaveAsync();
    }



    //download excel file
    /*
     * in the page method you shoud write Response
     */
    public static void DownloadExcelFile(DataTable dt)
    {




    }


    private static void DeleteIfFileExists(FileInfo fileInfo)
    {
        if (fileInfo.Exists)
            fileInfo.Delete();
    }


    //upload sheets from excel to data table collection
    public static DataTableCollection UploadFromExcel(string path)
    {
        try
        {

            DataTableCollection tableCollection; //contain all sheets from selected exel

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                //read data from excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    //convert data to data sets
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        // excel sheets has header in the first row
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                    });


                    //store sheets in Data Table
                    tableCollection = result.Tables;

                    return tableCollection;
                }
            }

        }

        catch (Exception ex)
        {
            throw ex;
        }
    }


    //get excel file and return sheets in data table collection
    public static DataTableCollection getSheetsFromExcel(Stream file)
    {
        try
        {
            DataTableCollection dataTableCollection;
            // open stream with excel
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(file);

            //read excel sheets and store it in dataset
            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                // excel sheets has header in the first row
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

            });

            //transefere data to data table collection
            dataTableCollection = result.Tables;

            return dataTableCollection;
        }
        catch (ApplicationException ex)
        {
            throw ex;

        }



    }
}