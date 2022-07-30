using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Report_SuperMarketSalesReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            clear();
        }


    }

    private void clear()
    {
        ddlShow.SelectedIndex = 0;
        txtFrom.Text = "";
        txtTo.Text = "";
    }


    //download excel file
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (!isInputsEntered())
            {
                return;
            }


            DataTable dt = getTable();

            downloadTable(dt);
            


        }catch(Exception ex)
        {
            showMessage("Failed process");
        }

    }

    //download excel file
    private void downloadTable(DataTable dt)
    {
        //create excel file
        using (XLWorkbook wb = new XLWorkbook())
        {
            //create sheet with name 
            wb.Worksheets.Add(dt, "SuperMarketSales");
            Response.Clear(); //clear all file in response
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            
            Response.AddHeader("content-disposition", "attachment;filename=SuperMarketSales.xlsx");
            
            //store excel file in memory
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);

                //Download file
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }


    //get desired table
    private DataTable getTable()
    {
        DataTable dt = new DataTable();
        string from = txtFrom.Text;  //'2019-01-01'

        string to = txtTo.Text;   //'2019-01-02'
        switch (ddlShow.SelectedIndex)
        {
            case 0:
                {
                    dt = SuperMarketSalesTransactions.selectBranch("All", from, to);
                    break;
                }

            case 1:
                {
                    dt = SuperMarketSalesTransactions.selectBranch("A", from, to);
                    break;
                }

            case 2:
                {
                    dt = SuperMarketSalesTransactions.selectBranch("B", from, to);
                    break;
                }


            case 3:
                {
                    dt = SuperMarketSalesTransactions.selectBranch("C", from, to);
                    break;
                }

            default:
                break;

        }

        return dt;


    }


    //check all data entered
    private bool isInputsEntered()
    {
        if(txtFrom.Text == "")
        {
            showMessage("please enter from date");
            return false;
        }

        if(txtTo.Text == "")
        {
            showMessage("please enter to date");
            return false;
        }

        return true;

    }

    private void showMessage(string message)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "showMessage('" + message + "')", true);
    }

}