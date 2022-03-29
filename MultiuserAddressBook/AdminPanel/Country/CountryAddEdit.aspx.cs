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

public partial class MultiuserAddressBook_AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    
         #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                lblMessage.Text = "Edit Mode | CountryID = " + Request.QueryString["CountryID"].ToString();
                FillControl(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
         SqlString strUserID = SqlString.Null;
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
       // SqlString strUserID = SqlString.Null;
        String strErrorMessage = "";
        #region serverside Validation
        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Country Name<br />";

        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion serverside Validation
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            strCountryName = txtCountryName.Text.Trim();
            strCountryCode = txtCountryCode.Text.Trim();
            //strUserID = txtUserID.Text.Trim();
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
            //objCmd.Parameters.AddWithValue("@UserID", str);
            if (Request.QueryString["CountryID"] != null)
            {
                // Edit mode
                objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());
                objCmd.CommandText = "PR_Country_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/MultiuserAddressBook/AdminPanel/Country/CountryList.aspx", true);
            }
            else
            {
                // Add mode
                objCmd.CommandText = "PR_Country_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data Inserted Successfully";
                Response.Redirect("~/MultiuserAddressBook/AdminPanel/Country/CountryList.aspx", true);
                //txtCountryID.Text = "";
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                //txtCreationDate.Text = "";
                txtCountryName.Focus();
            }

            
            // strCountryID = txtCountryID.Text.Trim();
            
            // objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            
           
            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Button : Save


    #region FillControl
    private void FillControl(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByPK";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    //if (!objSDR["CreationDate"].Equals(DBNull.Value))
                    //{
                    //    txtCreationDate.Text = objSDR["CreationDate"].ToString().Trim();
                    //}
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CountryID = " + CountryID.ToString();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillControl
    }
