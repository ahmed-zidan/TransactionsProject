using ClosedXML.Excel;
using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// this page responsible for gitting an excel file of Super market sales
/// extracting all sheets from excel
/// show first ten rows in grid view
/// upload data to database
/// </summary>
public partial class Pages_Upload_UploadSuperMarketSales : System.Web.UI.Page
{

    //store all sheets in data table
    private static DataTableCollection tableCollection;
    protected void Page_Load(object sender, EventArgs e)
    {
        //clear all data from page when refresh page
        if (!IsPostBack)
        {
            ddlUpload.Items.Clear();
            FileUpload1 = null;
            grMarket.DataSource = null;
        }


    }




    //display selected sheet in grid view
    protected void ddlUpload_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            showGridView();

        }catch(Exception ex)
        {
            showMassge("Failed process");
        }
        


    }


    //show specific sheet in grid view
    private void showGridView()
    {
        //tableCollection is empty
        if (tableCollection.Count == 0)
        {
            showMassge("excel has no sheets");
            return;
        }


        DataTable dt;
        lblFiirstTenRows.Text = "First 10 Rows";
        //read slected index from drop down list and show it in grid
        if (ddlUpload.SelectedIndex>=0)
            dt = tableCollection[ddlUpload.SelectedIndex];
        else
            dt = tableCollection[0]; //default option

        
        grMarket.DataSource = First10Rows(dt); //gitting first ten rows and pass it to grid view
        grMarket.DataBind();
        btnUploadData.Visible = true; //user can now upload data



    }


    //return first 10 rows from DataTable
    private DataTable First10Rows(DataTable myData)
    {
        //temp table storing first ten rows
        DataTable dt = new DataTable();
        
        int i = 0;

        //store columns to temp table
        foreach (DataColumn dataCol in myData.Columns)
        {
            dt.Columns.Add(dataCol.ColumnName , dataCol.DataType);
        }

        //store first ten rows to temp table
        foreach (DataRow dataRow in myData.Rows)
        {

            dt.Rows.Add(dataRow.ItemArray);
            if (i++ > 10)
                break;

        }

        return dt;
    }


    //add sheets names in drop down list
    protected void btnShow_Click(object sender, EventArgs e)
    {
        //is file upload has file ?
        if (!FileUpload1.HasFile)
        {
            showMassge("please choose excel file!");
            return;
        }


        //is extension correct ? 
        if (!ValidateExtensionOfFile())
        {
            showMassge("please enter a valid extension (.xlsx)");
            return;
        }

        //read excel sheets file in table collection
        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(FileUpload1.PostedFile.InputStream))
        {
            //convert data to data sets
            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                // excel sheets has header in the first row
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

            });

            //store sheets in Data Table
            tableCollection = result.Tables;

            //clear drop down list
            ddlUpload.Items.Clear();


            //add sheet name to drop down list
            foreach (DataTable table in tableCollection)
            {
                ddlUpload.Items.Add(table.TableName);
                //gr.DataSource = table;
                //break;
            }
        }

        ddlUpload.DataBind();
        showGridView();


    }

    //validate extension of file to be xlsx
    private bool ValidateExtensionOfFile()
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                //getting extension of file
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                
                if (ext.ToLower() != ".xlsx")
                    return false;
            }

            return true;
        }catch(Exception ex)
        {
            showMassge("Failed process");
            return false;
        }
    }


    //show message in popup 
    private void showMassge(string message)
    {

        ScriptManager.RegisterStartupScript(this, this.GetType(), "shs", "ShowMassage('" + message + "')",true);
    }


    //upload data to database
    protected void btnUploadData_Click(object sender, EventArgs e)
    {
        try
        {
            //store only one sheet from table collection
            DataTable dt;

            // getting selected sheet
            if (ddlUpload.SelectedIndex >= 0)
                dt = tableCollection[ddlUpload.SelectedIndex];
            else dt = tableCollection[0]; //default sheet


            if (SuperMarketSalesTransactions.insertAllData(dt))
                showMassge("Data Uploaded Successfully to DataBase");
            else showMassge("Failed process");

        }
        catch(Exception ex)
        {
            showMassge("Failed process (invoice id already exists)");
            
        }

    }
}