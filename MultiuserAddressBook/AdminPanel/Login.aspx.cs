using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MultiuserAddressBook_AdminPanel_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        #endregion Local Variable

        #region ServerSide Validation
        String strErrorMessage="";
        if (txtUserNameLogin.Text.Trim() == "")
        {
            strErrorMessage += "- Enter UserName <br />";
        }
        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Password <br />" + strErrorMessage;
            return;
        }
        #endregion SererSide Validation

        #region Assign the Value
        if (txtUserNameLogin.Text.Trim() != "")
        {
            strUserName = txtUserNameLogin.Text.Trim();
        }
        if (txtPassword.Text.Trim() != "")
        {
            strPassword = txtPassword.Text.Trim();
        }

        #endregion Assign the Value


        #region User Validation
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByUserNamePassword";
            objCmd.Parameters.AddWithValue("@UserName", strUserName);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if(objSDR.HasRows)
            {
                lblMessage.Text = "Valid User";

                while (objSDR.Read())
                {
                    if (!objSDR["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }
                Response.Redirect("~/MultiuserAddressBook/AdminPanel/Default.aspx", true);
            }
            else
            {
                lblMessage.Text = "Either Username or Password is not Valid";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            
        }

        objConn.Close();

    }
        #endregion User Validation
    #region register
    protected void Register_Click(object sender, EventArgs e)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        #region Local varable
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strDisplayName = SqlString.Null;
        SqlString strMobileNo = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        #endregion Local varable
        #region ServerSide Validation
        String strErrorMessage1 = "";
        if (txtUserName.Text.Trim() == "")
        {
            strErrorMessage1 += "Enter UserName<br />";
        }
        if (txtPasswordRegister.Text.Trim() == "")
        {
            strErrorMessage1 += "Enter Password<br />";
        }
        if (txtDisplayName.Text.Trim() == "")
        {
            strErrorMessage1 += "Enter Display Name<br />";
        }
        if (txtMobileNo.Text.Trim() == "")
        {
            strErrorMessage1 += "Enter Mobile No<br />";
        }
        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage1 += "Enter Email<br />";
            return;
        }
        #region gather information
        if (txtUserName.Text.Trim() != "")
        {
            strUserName = txtUserName.Text.Trim();
        }
        if (txtPasswordRegister.Text.Trim() != "") 
        {
            strPassword = txtPasswordRegister.Text.Trim();
        }
        if (txtDisplayName.Text.Trim() != "") 
        {
            strDisplayName = txtDisplayName.Text.Trim();
        }
        if (txtMobileNo.Text.Trim() != "") 
        {
            strMobileNo = txtMobileNo.Text.Trim();
        }
        if (txtEmail.Text.Trim() != "") 
        {
            strEmail = txtEmail.Text.Trim();
        }
        #endregion gather information
        #endregion ServerSide Validation
        #region set connection and command
        if (objConn.State != ConnectionState.Open)
            objConn.Open();
        SqlCommand objcmd = objConn.CreateCommand();
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.Parameters.AddWithValue("@UserName", strUserName);
        objcmd.Parameters.AddWithValue("@Password", strPassword);
        objcmd.Parameters.AddWithValue("@DisplayName", strDisplayName);
        objcmd.Parameters.AddWithValue("@MobileNo", strMobileNo);
        objcmd.Parameters.AddWithValue("@Email", strEmail);
        #endregion set connecion and command
        #region InsertUser
        objcmd.CommandText = "[dbo].[PR_User_Insert]";
        objcmd.ExecuteNonQuery();
        txtUserName.Text = "";
        txtPasswordRegister.Text = "";
        txtDisplayName.Text = "";
        txtMobileNo.Text = "";
        txtEmail.Text = "";
        #endregion InsertUser
        objConn.Close();
    }
}
    #endregion register
        
