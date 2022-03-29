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

public partial class MultiuserAddressBook_AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownListCountry();

            FillDropDownListState();
            FillDropDownListCity();
            FillDropDownListContactCategory();
            if (Request.QueryString["ContactID"] != null)
            {
                lblmessage.Text = "Edit Mode | ContactID = " + Request.QueryString["ContactID"].ToString();
                FillControl(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
            else
            {
                lblmessage.Text = "Add Mode";
            }


        }
    }
    #region Button: Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlInt32 strContactID = SqlInt32.Null;
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlString strBirthDate = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFaceBookID = SqlString.Null;
        SqlString strLinkedINID = SqlString.Null;
        //SqlString strCreationDate = SqlString.Null;
        string strErrorMesage = "";
        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMesage += "Enter Country<br />";
        }
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMesage += "Enter State<br />";
        }
        if (ddlCityID.SelectedIndex == 0)
        {
            strErrorMesage += "Enter City<br />";
        }
        if (ddlContactCategoryID.SelectedIndex == 0)
        {
            strErrorMesage += "Enter Contact Category<br />";
        }
        if (txtContactName.Text.Trim() == "")
        {
            strErrorMesage += "Enter Contact Name<br />";
        }
        if (txtContactNo.Text.Trim() == "")
        {
            strErrorMesage += "Enter Contact no<br />";
        }
        if (txtWhatsappNo.Text.Trim() == "")
        {
            strErrorMesage += "Enter Whatsapp no<br />";
        }
        if (txtBirthDate.Text.Trim() == "")
        {
            strErrorMesage += "Enter Birth Date<br />";
        }
        if (txtEmail.Text.Trim() == "")
        {
            strErrorMesage += "Enter Email<br />";
        }
        if (txtAge.Text.Trim() == "")
        {
            strErrorMesage += "Enter Age<br />";
        }
        if (txtAddress.Text.Trim() == "")
        {
            strErrorMesage += "Enter Address<br />";
        }
        if (txtBloodGroup.Text.Trim() == "")
        {
            strErrorMesage += "Enter Blood Group<br />";
        }
        if (txtFaceBookID.Text.Trim() == "")
        {
            strErrorMesage += "Enter FaceBookID<br />";
        }
        if (txtLinkedINID.Text.Trim() == "")
        {
            strErrorMesage += "Enter LinkedIN ID<br />";
            return;
        }
        //if (txtCreationDate.Text.Trim() == "")
        //{
        //    strErrorMesage += "Enter Creation Date";
        //}
        
    #endregion LoadEvent

        #region Gather Information
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            String ContactPhotoPath = "";
            if (FuContactPhotoPath.HasFile)
            {
                ContactPhotoPath = "~/UserContent/" + FuContactPhotoPath.FileName.ToString().Trim();
                FuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));
            }
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            strCityID = Convert.ToInt32(ddlCityID.SelectedValue);
            strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
            strContactName = txtContactName.Text.Trim();
            strContactNo = txtContactNo.Text.Trim();
            strWhatsAppNo = txtWhatsappNo.Text.Trim();
            strBirthDate = txtBirthDate.Text.Trim();
            strEmail = txtEmail.Text.Trim();
            strAge = txtAge.Text.Trim();
            strAddress = txtAddress.Text.Trim();
            strBloodGroup = txtBloodGroup.Text.Trim();
            strFaceBookID = txtFaceBookID.Text.Trim();
            strLinkedINID = txtLinkedINID.Text.Trim();
            //strCreationDate = txtCreationDate.Text.Trim();
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objCmd.Parameters.AddWithValue("@WhatsappNo", strWhatsAppNo);
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@FaceBookID", strFaceBookID);
            objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedINID);
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", ContactPhotoPath);
        #endregion Gather Information

            #region edit Mode
            if (Request.QueryString["ContactID"] != null)
            {
                // edit mode
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"]);
                objCmd.CommandText = "PR_Contact_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/MultiuserAddressBook/AdminPanel/Contact/ContactList.aspx");
            }
            #endregion edit Mode

            #region Add Mode
            else
            {
                // Add mode
                objCmd.CommandText = "PR_Contact_Insert";
                objCmd.ExecuteNonQuery();

                ddlCountryID.SelectedIndex = 0;
                ddlStateID.SelectedIndex = 0;
                ddlCityID.SelectedIndex = 0;
                ddlContactCategoryID.SelectedIndex = 0;
                txtContactName.Text = "";
                txtContactNo.Text = "";
                txtWhatsappNo.Text = "";
                txtBirthDate.Text = "";
                txtEmail.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtBloodGroup.Text = "";
                txtFaceBookID.Text = "";
                txtLinkedINID.Text = "";
                //txtCreationDate.Text = "";
                lblmessage.Text = "Data Inserted Sucessfully";
            }
            #endregion Add Mode
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
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
    #region FillDropDownListCountry
    private void FillDropDownListCountry()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();
            }
            ddlCountryID.Items.Insert(0, new ListItem("select Country", "-1"));
            objConn.Close();
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
    #endregion FillDropDownListCountry
    #region FillDropDownListState
    private void FillDropDownListState()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();
            }
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            objConn.Close();
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
    #endregion FillDropDownListState
    #region FillDropDownListCity
    private void FillDropDownListCity()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectForDropDown";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlCityID.DataSource = objSDR;
                ddlCityID.DataValueField = "CityID";
                ddlCityID.DataTextField = "CityName";
                ddlCityID.DataBind();
            }
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
            objConn.Close();
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
    #endregion FillDropDownListCity
    #region FillDropDownListContactCategory
    private void FillDropDownListContactCategory()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlContactCategoryID.DataSource = objSDR;
                ddlContactCategoryID.DataValueField = "ContactCategoryID";
                ddlContactCategoryID.DataTextField = "ContactCategoryName";
                ddlContactCategoryID.DataBind();
            }
            ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
            objConn.Close();
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
    #endregion FillDropDownListContactCategory
    #region FillControl
    private void FillControl(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByPK";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {

                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    {
                        ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }
                    if (!objSDR["WhatsappNo"].Equals(DBNull.Value))
                    {
                        txtWhatsappNo.Text = objSDR["WhatsappNo"].ToString().Trim();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        txtBirthDate.Text = objSDR["BirthDate"].ToString().Trim();
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                    }
                    if (!objSDR["FaceBookID"].Equals(DBNull.Value))
                    {
                        txtFaceBookID.Text = objSDR["FaceBookID"].ToString().Trim();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        txtLinkedINID.Text = objSDR["LinkedINID"].ToString().Trim();
                    }
                    if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                    {
                        imgContactPhotoPath.ImageUrl = objSDR["ContactPhotoPath"].ToString().Trim();
                    }
                    break;
                }
            }
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
    #endregion FillControl
}