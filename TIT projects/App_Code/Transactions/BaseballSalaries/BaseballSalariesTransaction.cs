using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Z.Dapper.Plus;

/// <summary>
/// Summary description for BaseballSalariesTransaction
/// </summary>
public class BaseballSalariesTransaction
{
    public BaseballSalariesTransaction()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //insert baseball salaries into database "Oracle database"
    public static bool insert(DataTable dt)
    {
        try
        {
            var con = OracleHandler.openConnection();

            insertBaseballData(dt);

            //IDbConnection dbConnection = con;

            //dbConnection.BulkInsert(baseballsalaries);
            con.Close();//close connection

            return true;
        }
        catch(Exception ex)
        {
            throw ex;
        }

        return true;
    }

    private static void insertBaseballData(DataTable dt)
    {

        try
        {
            char c = '\'';
           
            for(int i = 0; i < dt.Rows.Count; i++)
            {

                string query = "insert into baseballsalaries (player , team , position , salary) values('" + (dt.Rows[i][0].ToString().Replace(c , ' ')) + "','" + dt.Rows[i][1].ToString() + "','" +
                     dt.Rows[i][2].ToString() + "','" + dt.Rows[i][3].ToString() + "')";

                OracleHandler.insert(query);
                /*baseballSalaries.Player = dt.Rows[i][0].ToString();
                baseballSalaries.Team = dt.Rows[i][1].ToString();
                baseballSalaries.Position = dt.Rows[i][2].ToString();
                baseballSalaries.Salary = dt.Rows[i][3].ToString();
                baseballsalaries.Add(baseballSalaries);*/
            }

           
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}