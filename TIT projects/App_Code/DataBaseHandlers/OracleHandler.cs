using System;
using System.Collections.Generic;

using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;

/// <summary>
/// this class handle all transactions between app and oracle database
/// </summary>
public class OracleHandler
{

    private static string TNS = "Data Source=(DESCRIPTION =" +
        "(ADDRESS = (PROTOCOL = TCP)(HOST = desktop-kdjj2g8)(PORT = 1521))" +
        "(CONNECT_DATA =" +
        "(SERVER = DEDICATED)" +
        "(SERVICE_NAME = orcl)));" +
        "User Id= system;Password=orcl";


    private static OracleConnection con;
    private static OracleCommand cmd;
    private static OracleDataAdapter reader;
    public OracleHandler()
    {
    }

    public static OracleConnection openConnection()
    {
        con = new OracleConnection(TNS);
        con.Open();
        return con;
    }

    public static void closeConnection()
    {
        con.Close();
    }

    public static void insert(string query)
    {
        try
        {
            var con = openConnection();
            cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();
            closeConnection();
        }catch(Exception ex)
        {
            throw ex;
        }
    }
}