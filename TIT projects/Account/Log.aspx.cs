using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Log : System.Web.UI.Page
{
    string connstr = "Data Source=DESKTOP-KDJJ2G8;Initial Catalog=TIT;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            clearText();
            clearSession();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sss", "changeLogIN('Login')", true);

        }


    }


    void clearText()
    {

        txtPasword.Text = "";
        txtUsername.Text = "";
    }

    void clearSession()
    {
        Session["userName"] = null;
        Session["password"] = null;
        Session["id"] = null;
    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        try
        {
            var con = DBHandler.openConnection(connstr);

            if (hasAccess(con))
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "bu1", "ShowMassage('please enter correct Username or Passoword')", true) ;
            }

            con.Close();
        }catch(Exception ex)
        {
            throw ex;
        }

    }

    private bool hasAccess(SqlConnection con)
    {
        try
        {
            string userName = txtUsername.Text;
            string Pass = txtPasword.Text;

            DataTable dt = getPass(con);

            if (dt.Rows.Count > 0)
            {
                //is password exists ?
                if (dt.Rows[0][0].ToString() == Pass)
                {
                    //store user information
                    Session["userName"] = userName;
                    Session["password"] = Pass;
                    Session["id"] = dt.Rows[0][1];
                    return true;
                }
            }

            return false;

        }catch(Exception ex)
        {
            throw ex;
        }
    }

    //select password from and id from Account table
    private DataTable getPass(SqlConnection con)
    {
        try
        {
            DataTable dt = new DataTable();
            string cmd = "select Password,Id from UserAccount where UserName =" + "'" + txtUsername.Text + "'";

            //execute select command
            SqlDataAdapter command = new SqlDataAdapter(cmd, con);
            //fill datatable
            command.Fill(dt);
            return dt;

        }catch(Exception ex)
        {
            throw ex;
        }
    }
}