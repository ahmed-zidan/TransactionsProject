using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Z.Dapper.Plus;

/// <summary>
/// this class is responsible for doing all transactions between server and database 
/// manage SuperMarketSales table only
/// </summary>
public class SuperMarketSalesTransactions
{
    public SuperMarketSalesTransactions()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //string connection 
    private static string strConn = "Data Source=DESKTOP-KDJJ2G8;Initial Catalog=TIT;Integrated Security=True";


    //responsible for extracting data from DataTable and pushing it to database
    public static bool insertAllData(DataTable dt)
    {
        try
        {
            //store data in list of SuperMarketSales
            List<SuperMarketSales> superMarketSales = getSuperMarketSales(dt);

            //no data in superMarketSales
            if (superMarketSales == null)
                return false;
            
            //open connection
            var con = DBHandler.openConnection(strConn);

            IDbConnection dbConnection = con;

            //push all data to database
            dbConnection.BulkInsert(superMarketSales);

            con.Close();//close connection

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    //get list of SuperMarketSales
    private static List<SuperMarketSales> getSuperMarketSales(DataTable dt)
    {
        try
        {
            //check if table is what we want 
            if (!isDesiredTable(dt) || dt == null)
            {
                return null;
            }

            //list all rows from table in DataTable
            List<SuperMarketSales> superMarketSales = new List<SuperMarketSales>();
            
            //store one row
            SuperMarketSales super;


            //loop on all rows and store them in superMarketSales
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                super = new SuperMarketSales();
                super.Invoice_ID = dt.Rows[i]["Invoice ID"].ToString();
                super.Branch = dt.Rows[i]["Branch"].ToString();
                super.City = dt.Rows[i]["City"].ToString();
                super.Customer_Type = dt.Rows[i]["Customer type"].ToString();
                super.Gender = dt.Rows[i]["Gender"].ToString();
                super.Product_Line = dt.Rows[i]["Product line"].ToString();
                super.Unit_Price = Convert.ToDouble(dt.Rows[i]["Unit price"]);
                super.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                super.Tax_5 = Convert.ToDouble(dt.Rows[i]["Tax 5%"]);
                super.Total = Convert.ToDouble(dt.Rows[i]["Total"]);
                super.Date = dt.Rows[i]["Date"].ToString();
                super.Time = dt.Rows[i]["Time"].ToString();
                super.Payment = dt.Rows[i]["Payment"].ToString();
                super.Cogs = Convert.ToDouble(dt.Rows[i]["cogs"]);
                super.Gross_Margin_Percentage = Convert.ToDouble(dt.Rows[i]["gross margin percentage"]);
                super.Gross_Income = Convert.ToDouble(dt.Rows[i]["gross income"]);
                super.Rating = Convert.ToDouble(dt.Rows[i]["Rating"]);

                superMarketSales.Add(super); //add row to superMarketSales

            }

            return superMarketSales;


        }catch(Exception ex)
        {
            return null;
        }



    }


    //desired table has 17 columns
    private static bool isDesiredTable(DataTable dt)
    {
        if (dt.Columns.Count != 17)
            return false;

        return true;
    }


    //select data where branch is all
    public static DataTable selectBranch(string branch,string from , string to)
    {
        DataTable dt;
        string command = "select* from SuperMarketSales where CAST(date as date) between '" + from+"' and '"+to+"' ";
        if (branch.ToLower() == "all")
        {
            dt = DBHandler.select(command , strConn);
        }
        else
        {
            command += "and Branch= '" + branch + "'";
            dt = DBHandler.select(command, strConn);
        }

        return dt;

    }


}