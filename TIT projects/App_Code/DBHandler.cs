using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// handle all process in database
/// as Delete insert Select
/// </summary>
public class DBHandler
{

    private static SqlConnection sqlCon;
    private static SqlCommand sqlCom;
    private static SqlDataAdapter sqlDataAdapter; //used for read data and execute stored procedures

    public DBHandler()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //insert table into database
    public static void insert(DataTable dt, string tableName, string strCon)
    {
        /*dt -- data to be inserted
         * strCommand -- command used in sqlCommand
         * strCon -- database conncetion 
         */

        try
        {
            //open connection
            var con = openConnection(strCon);


            //select row by row and insert it into database 
            foreach (DataRow row in dt.Rows)
            {
                string cmd = "insert into " + tableName + " values(";
                int i;
                for (i = 0; i < row.ItemArray.Length - 1; i++)
                {
                    cmd += row.ItemArray[i] + ",";
                }
                cmd += row.ItemArray[i] + ");";

                sqlCom = new SqlCommand(cmd, con);
                sqlCom.ExecuteNonQuery();
            }

            closeConnection(con);

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public static void closeConnection(SqlConnection con)
    {
        try
        {
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static SqlConnection openConnection(string strCon)
    {
        try
        {
            sqlCon = new SqlConnection(strCon);

            return sqlCon;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    //select data from database based on command and connection string
    public static DataTable select(string cmd , string con)
    {
        DataTable dt = new DataTable();
        var connection = openConnection(con);

        sqlDataAdapter = new SqlDataAdapter(cmd, connection);

        sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
        sqlDataAdapter.Fill(dt);
        
        connection.Close();
        return dt;
    }




}