using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShareYourConcern
{
    public partial class SearchConcerns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SearchById.Text) && string.IsNullOrEmpty(SearchByName.Text) && string.IsNullOrEmpty(SearchByFromDate.Text) && string.IsNullOrEmpty(SearchByToDate.Text) && string.IsNullOrEmpty(SearchByEmail.Text) && string.IsNullOrEmpty(SearchByPhone.Text) && string.IsNullOrEmpty(SearchByEmpId.Text))
                {
                    Response.Write("<script>alert('Please enter a search term.');</script>");
                    return;
                }
                //DateTime fromDate;
                //if (!DateTime.TryParseExact(SearchByFromDate.Text, "dd-MMM-yyyy", null, System.Globalization.DateTimeStyles.None, out fromDate))
                //{
                //    Response.Write("<script>alert('Invalid From Date format. Please use DD-MMM-YYYY.');</script>");
                //    return;
                //}

                //// Validate To Date format
                //DateTime toDate;
                //if (!DateTime.TryParseExact(SearchByToDate.Text, "dd-MMM-yyyy", null, System.Globalization.DateTimeStyles.None, out toDate))
                //{
                //    Response.Write("<script>alert('Invalid To Date format. Please use DD-MMM-YYYY.');</script>");
                //    return;
                //}

                //string searchTermById = "'%" + SearchById.Text + "%'";
                //string searchTermByName = "'%" + SearchByName.Text + "%'";
                //string searchTermByFromDate = "'" + Convert.ToDateTime(SearchByFromDate.Text).ToString("dd-MMM-yyyy") + "'";
                //string searchTermByToDate = "'" + Convert.ToDateTime(SearchByToDate.Text).ToString("dd-MMM-yyyy") + "'";
                //string searchTermByEmail = "'%" + SearchByEmail.Text + "%'";
                //string searchTermByEmpId = "'%" + SearchByEmpId.Text + "%'";
                //string searchTermByPhone = "'%" + SearchByPhone.Text + "%'";

                string searchTermById = "";
                string searchTermByName = "";
                string searchTermByFromDate = "";
                string searchTermByToDate = "";
                string searchTermByEmail = "";
                string searchTermByEmpId = "";
                string searchTermByPhone = "";

                string strWhereClause = " WHERE ";

                if (string.IsNullOrEmpty(SearchById.Text))
                {

                }
                else
                {
                    if (strWhereClause == " WHERE ")
                    {
                        strWhereClause = strWhereClause + " ISNULL(usr_PKID, 0) LIKE '%" + SearchById.Text + "%'";
                    }
                    else
                    {
                        strWhereClause = strWhereClause + " OR ISNULL(usr_PKID, 0) LIKE '%" + SearchById.Text + "%'";
                    }                    
                }
                if (string.IsNullOrEmpty(SearchByName.Text))
                {

                }
                else
                {
                    if (strWhereClause == " WHERE ")
                    {
                        strWhereClause = strWhereClause + " ISNULL(usr_name,'') LIKE '%" + SearchByName.Text + "%'";
                    }
                    else
                    {
                        strWhereClause = strWhereClause + " OR ISNULL(usr_name,'') LIKE '%" + SearchByName.Text + "%'";
                    }
                }
                if (string.IsNullOrEmpty(SearchByEmpId.Text))
                {

                }
                else
                {
                    if (strWhereClause == " WHERE ")
                    {
                        strWhereClause = strWhereClause + " ISNULL(Emp_Code,'') LIKE '%" + SearchByEmpId.Text + "%'";
                    }
                    else
                    {
                        strWhereClause = strWhereClause + " OR ISNULL(Emp_Code,'') LIKE '%" + SearchByEmpId.Text + "%'";
                    }
                }
                if (string.IsNullOrEmpty(SearchByEmail.Text))
                {

                }
                else
                {
                    if (strWhereClause == " WHERE ")
                    {
                        strWhereClause = strWhereClause + " ISNULL(email_id,'') LIKE '%" + SearchByEmail.Text + "%'";
                    }
                    else
                    {
                        strWhereClause = strWhereClause + " OR ISNULL(email_id,'') LIKE '%" + SearchByEmail.Text + "%'";
                    }
                }
                if (string.IsNullOrEmpty(SearchByPhone.Text))
                {

                }
                else
                {
                    if (strWhereClause == " WHERE ")
                    {
                        strWhereClause = strWhereClause + " ISNULL(PHONE_NO,'') LIKE '%" + SearchByPhone.Text + "%'";
                    }
                    else
                    {
                        strWhereClause = strWhereClause + " OR ISNULL(PHONE_NO,'') LIKE '%" + SearchByPhone.Text + "%'";
                    }
                }
                //if (string.IsNullOrEmpty(SearchById.Text))
                //{

                //}
                //else
                //{

                //}
                //if (string.IsNullOrEmpty(SearchById.Text))
                //{

                //}
                //else
                //{

                //}
                //if (string.IsNullOrEmpty(searchTermById)|| string.IsNullOrEmpty(searchTermByName) || string.IsNullOrEmpty(searchTermByFromDate) || string.IsNullOrEmpty(searchTermByToDate) || string.IsNullOrEmpty(searchTermByEmail) || string.IsNullOrEmpty(searchTermByEmpId) || string.IsNullOrEmpty(searchTermByPhone))
                //{
                //    Response.Write("<script>alert('Please enter a search term.');</script>");
                //    return;
                //}
                //DateTime fromDate;
                //if (!DateTime.TryParseExact(SearchByFromDate.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fromDate))
                //{
                //    Response.Write("<script>alert('Invalid From Date format. Please use YYYY-MM-DD.');</script>");
                //    return;
                //}

                //// Validate To Date format
                //DateTime toDate;
                //if (!DateTime.TryParseExact(SearchByToDate.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out toDate))
                //{
                //    Response.Write("<script>alert('Invalid To Date format. Please use YYYY-MM-DD.');</script>");
                //    return;
                //}



                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    con.Open();

                    //// Build dynamic search query based on user input
                    //// ... existing code to get search terms ...

                    //string searchQuery = "SELECT usr_PKID, DATE, USR_NAME,EMP_CODE, Concern "
                    //                    + "FROM ConcernMaster "
                    //                    + "WHERE ISNULL(usr_PKID,0) LIKE @searchTermById "
                    //                    + "OR ISNULL(Date,GETDATE()) Between @searchTermByFromDate AND @searchTermByToDate "
                    //                    + "OR ISNULL(usr_name,'') LIKE @searchTermByName "
                    //                    + "OR ISNULL(email_id,'') LIKE @searchTermByEmail "
                    //                    + "OR ISNULL(emp_code,'') LIKE @searchTermByEmpId "
                    //                    + "OR ISNULL(phone_no,0) LIKE @searchTermByPhone";
                    string searchQuery = "";
                    if (strWhereClause==" WHERE ")
                    {
                        searchQuery = "SELECT usr_PKID, DATE, USR_NAME,EMP_CODE, Concern FROM ConcernMaster";
                    }
                    else
                    {
                        searchQuery = "SELECT usr_PKID, DATE, USR_NAME,EMP_CODE, Concern FROM ConcernMaster " + strWhereClause +"";
                    }
                    //string searchQuery = "SELECT usr_PKID, DATE, USR_NAME,EMP_CODE, Concern "
                    //                    + "FROM ConcernMaster "
                    //                    + "WHERE ISNULL(usr_PKID,0) LIKE @searchTermById "
                    //                    + "OR ISNULL(Date,GETDATE()) Between @searchTermByFromDate AND @searchTermByToDate "
                    //                    + "OR ISNULL(usr_name,'') LIKE @searchTermByName "
                    //                    + "OR ISNULL(email_id,'') LIKE @searchTermByEmail "
                    //                    + "OR ISNULL(emp_code,'') LIKE @searchTermByEmpId "
                    //                    + "OR ISNULL(phone_no,0) LIKE @searchTermByPhone";

                    SqlCommand cmd = new SqlCommand(searchQuery, con);

                    //cmd.Parameters.AddWithValue("@searchTermById", searchTermById);
                    //cmd.Parameters.AddWithValue("@searchTermByName", searchTermByName);
                    //cmd.Parameters.AddWithValue("@searchTermByFromDate", searchTermByFromDate);
                    //cmd.Parameters.AddWithValue("@searchTermByToDate", searchTermByToDate);
                    //cmd.Parameters.AddWithValue("@searchTermByEmail", searchTermByEmail);
                    //cmd.Parameters.AddWithValue("@searchTermByEmpId", searchTermByEmpId);
                    //cmd.Parameters.AddWithValue("@searchTermByPhone", searchTermByPhone);

                    // ... remaining code to execute the query ...

                    // Execute the query and populate the GridView
                    SqlDataReader reader = cmd.ExecuteReader();
                    searchResultsGrid.DataSource = reader;
                    searchResultsGrid.DataBind();
                    reader.Close(); // Close the SqlDataReader

                    // Check for empty results and display a message
                    if (searchResultsGrid.Rows.Count == 0)
                    {
                        noResultsLabel.Visible = true;
                    }
                    else
                    {
                        searchResultsGrid.Visible = true;
                        noResultsLabel.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred: ' + ex.Message);</script>");
            }
        }

        private string GetConnectionString()
        {
            // Replace with your actual connection string details without the password
            //return "Data Source=GAMBHIRS\\SQLEXPRESS;database=ShareYourConcernDB;uid=ShareYourConcernDB;pwd=Tamish@2024;Integrated Security=True;TrustServerCertificate=True";
            return "data source=GAMBHIRS\\SQLEXPRESS;initial catalog=ShareYourConcernDB;user id=sa;password=Tamish@2024;App=EntityFraimwork&quot;";
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConcernPage.aspx");
        }
    }
}
