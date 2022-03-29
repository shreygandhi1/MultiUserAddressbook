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

public partial class MultiuserAddressBook_AdminPanel_City_StateAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDown();
            if (Request.QueryString["CityID"] != null)
            {
                lblmessage.Text = "Edit Mode | CityID = " + Request.QueryString["CityID"].ToString();
                FillControl(Convert.ToInt32(Request.QueryString["CityID"]));
            }
            else
            {
                lblmessage.Text = "Add Mode";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        //SqlString strCreationDate = SqlString.Null;
        String strErrorMessage = "";
        if (ddlState.SelectedIndex == 0)
        {
            strErrorMessage += "Enter State<br />";
        }
        if (txtCityName.Text.Trim() == "")
        {
            strErrorMessage += "Enter City Name<br />";
        }
        if (txtSTDCode.Text.Trim() == "")
        {
            strErrorMessage += "Enter STDCode<br />";
        }
        if (txtPinCode.Text.Trim() == "")
        {
            strErrorMessage += "Enter PinCode<br />";
        }
        //if (txtCreationDate.Text.Trim() == "")
        //{
        //    strErrorMessage += "Enter CreationDate<br />";
        //}
        if (strErrorMessage != "")
        {
            lblmessage.Text = strErrorMessage;
            return;
        }
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {

            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            strStateID = Convert.ToInt32(ddlState.SelectedValue);
            strCityName = txtCityName.Text.Trim();
            strSTDCode = txtSTDCode.Text.Trim();
            strPinCode = txtPinCode.Text.Trim();
            //strCreationDate = txtCreationDate.Text.Trim();
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
            //objCmd.Parameters.AddWithValue("@CreationDate", strCreationDate);
            if (Request.QueryString["CityID"] != null)
            {
                // Edit Mode
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
                objCmd.CommandText = "PR_City_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/MultiuserAddressBook/Adminpanel/City/CityList.aspx");
            }
            else
            {
                // Add Mode
                objCmd.CommandText = "PR_City_Insert";
                objCmd.ExecuteNonQuery();
                lblmessage.Text = "Data Inserted Successfully";
                txtCityName.Text = "";
                txtSTDCode.Text = "";
                txtPinCode.Text = "";
               // txtCreationDate.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    protected void FillDropDown()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownList]";

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlState.DataSource = objSDR;
                ddlState.DataValueField = "StateID";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
            }

            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
            objConn.Close();

        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    private void FillControl(SqlInt32 CityID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectByPK";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {

                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                        //txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                        //txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                        //txtCreationDate.Text = objSDR["CreationDate"].ToString().Trim();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    //if (!objSDR["CreationDate"].Equals(DBNull.Value))
                    //{
                    //    txtCreationDate.Text = objSDR["CreationDate"].ToString().Trim();
                    //}

                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblmessage.Text = "No Data available for the CityID = " + CityID.ToString();

            }
        }

        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
}