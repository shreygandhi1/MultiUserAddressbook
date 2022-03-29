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

public partial class MultiuserAddressBook_AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["ContactCategoryID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactCategoryID = " + Request.QueryString["ContactCategoryID"].ToString();
                FillControl(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }
        }
    }
     protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
        objConn.Open();
        //SqlInt32 strCityID = SqlInt32.Null;
        SqlString strContactCategoryID = SqlString.Null;
        SqlString strContactCategoryName = SqlString.Null;
        //SqlString strCreationDate = SqlString.Null;
        #region ServerSide Validation
        String strErrorMessage = "";
       
        //if (txtContactCategoryID.Text.Trim() == "")
        //{
        //    strErrorMessage += "Enter Contact CategoryID<br />";
        //}
        if (txtContactCategoryName.Text.Trim() == "")
        {
            strErrorMessage += "Enter Contact Category Name<br />";
        }
        //if (txtCreationDate.Text.Trim() == "")
        //{
        //    strErrorMessage += "Enter Creation Date<br />";
        //}
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion ServerSide Validation
       
        try
        {
            
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            
            // strContactCategoryID = txtContactCategoryID.Text.Trim();
            strContactCategoryName = txtContactCategoryName.Text.Trim();
           // strCreationDate = txtCreationDate.Text.Trim();
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
            //objCmd.Parameters.AddWithValue("@CreationDate", strCreationDate);
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                #region Update Record
                // edit mode
                objCmd.Parameters.AddWithValue("@ContactCategoryID", Request.QueryString["ContactCategoryID"].ToString().Trim());
                objCmd.CommandText = "PR_ContactCategory_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/MultiuserAddressBook/Adminpanel/ContactCategory/ContactCategoryList.aspx", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                // Add mode
               // objCmd.Parameters.AddWithValue("@CreationDate", strCreationDate);
                objCmd.CommandText = "PR_ContactCategory_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data Inserted Successfully";
               // txtContactCategoryID.Text = "";
                txtContactCategoryName.Text = "";
                //txtCreationDate.Text = "";
                // txtContactCategoryID.Focus();
                #endregion Insert Record
            }
            
            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            
                objConn.Close();
        }

    }
     private void FillControl(SqlInt32 ContactCategoryID)
     {
         SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
         try
         {
             if (objConn.State != ConnectionState.Open)
                 objConn.Open();
             SqlCommand objCmd = objConn.CreateCommand();
             objCmd.CommandType = CommandType.StoredProcedure;
             objCmd.CommandText = "PR_ContactCategory_SelectByPK";
             objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());
             objCmd.Parameters.AddWithValue("@UserID",Session["UserID"]);
             SqlDataReader objSDR = objCmd.ExecuteReader();
             if (objSDR.HasRows)
             {
                 while (objSDR.Read())
                 {

                     if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                     {
                         // txtContactCategoryID.Text = objSDR["ContactCategoryID"].ToString().Trim();
                         txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                         //txtCreationDate.Text = objSDR["CreationDate"].ToString().Trim();
                     }
                     break;
                 }
             }
             else
             {
                 lblMessage.Text = "No Data available for the ContactCategoryID = " + ContactCategoryID.ToString();

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
}