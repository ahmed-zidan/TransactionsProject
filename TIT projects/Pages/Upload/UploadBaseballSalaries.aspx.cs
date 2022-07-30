using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Upload_UploadBaseballSalaries : System.Web.UI.Page
{

    static DataTableCollection dataTableCollection;
    protected void Page_Load(object sender, EventArgs e)
    {
        //page not refreshed
        if (!IsPostBack)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "sss", "showBasketballSalariesPopUp()", false);

        }


    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        
        ScriptManager.RegisterStartupScript(this, this.GetType(),"sss", "showBasketballSalariesPopUp()", true);
    }


    //show sheets in drop down list
    protected void btnShowSheets_Click(object sender, EventArgs e)
    {
        try
        {
            OracleHandler.openConnection();
            clearData();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sss", "showBasketballSalariesPopUp()", true);
            //no file
            if (!flUpload.HasFiles == true)
            {
                showMessage("please select file");
                return;
            }
            //valiadte extension file
            if (!ValidateExtensionOfFile())
            {
                showMessage("please enter a valid extension (.xlsx)");
                return;
            }


            //get sheets from excel
            dataTableCollection = ExcelHandler.getSheetsFromExcel(flUpload.PostedFile.InputStream);


            fillDropDownList();

            return;
        }
        catch (Exception ex)
        {

            showMessage("error in system");
            
        }



    }

    private void clearData()
    {
        ddlSheets.Items.Clear();
    }

    //validate extension of file
    private bool ValidateExtensionOfFile()
    {
        try
        {
            //get extension
            string ext = System.IO.Path.GetExtension(flUpload.FileName);

            if (ext.ToLower() != ".xlsx")
            {
                return false;
            }

            
            return true;



        }
        catch
        {
            showMessage("system error");
            return false;
        }
    }

    //show names of tables in drop down list
    private void fillDropDownList()
    {
        foreach(DataTable dt in dataTableCollection)
        {
            ddlSheets.Items.Add(dt.TableName);
        }

    }


    //fill table Collection with  sheets 

    //show message in popup
    private void showMessage(string message)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "sss", "ShowMassage('" + message + "')", true);
    }


    //select sheet and display it in grid view
    protected void select_button(object sender, EventArgs e)
    {
        try
        {
            int idx = (ddlSheets.SelectedIndex > 0) ? ddlSheets.SelectedIndex : 0;

            DataTable dt = dataTableCollection[0];
            OracleHandler.openConnection();

            BaseballSalariesTransaction.insert(dt);

        }
        catch
        {
            showMessage("system error");
        }

    }

}