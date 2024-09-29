using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data.SqlClient; 
using System.Configuration; 
using System.Data;
using System.Drawing;

namespace ShareYourConcern
{
    public partial class ConcernPage : System.Web.UI.Page
    {
        private string GetConnectionString()
        {
            return "data source=GAMBHIRS\\SQLEXPRESS;initial catalog=ShareYourConcernDB;user id=sa;password=Tamish@2024;App=EntityFraimwork&quot;";
        }
        
        //protected void ChkDisableDetails_CheckedChanged(object sender, EventArgs e)
        //{
        //    // Enable/disable input fields based on checkbox state
        //    //txtName.Enabled = !ChkDisableDetails.Checked;
        //    //txtEmail.Enabled = !ChkDisableDetails.Checked;
        //    //txtEmpId.Enabled = !ChkDisableDetails.Checked;
        //    //txtPhone.Enabled = !ChkDisableDetails.Checked;

            
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
           Thread.Sleep(1000);
            if (Session["USR_PKID"] != null)
            {
                string connectionString = GetConnectionString(); // Replace with your actual connection string
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string searchQuery = "SELECT USR_PKID, EMP_CODE, USR_NAME, EMAIL_ID, PHONE_NO "
                                        + "FROM USR_DTL "
                                        + "WHERE ISNULL(USR_PKID,0) =  @USR_PKID ";

                    DataSet ds=new DataSet();
                    SqlCommand cmd = new SqlCommand(searchQuery, con);
                    cmd.Parameters.AddWithValue("@USR_PKID", Session["USR_PKID"]);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);                    
                    adapter.Fill(ds, "USR_DTL");
                    if (ds.Tables[0].Rows.Count >0)
                    {
                        txtEmpId.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                        txtName.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                        txtPhone.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");                        
                    }


                    //SqlDataReader reader = cmd.ExecuteReader();
                    //searchResultsGrid.DataSource = reader;
                    //searchResultsGrid.DataBind();
                    //if reader.
                    //reader.Close(); // Close the SqlDataReader
                    con.Close();
                }
            }
            else
            {
            }
            //if (Session["LoggedInUser"] == null)
            //{
            //    // User not logged in, redirect to login page
            //    Response.Redirect("Login.aspx");
            //    return;
            //}

            //string username = Session["LoggedInUser"].ToString();
            //string connectionString = GetConnectionString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Input validation (optional but recommended)
            if (string.IsNullOrEmpty(txtConcern.Text))
            {
                Response.Write("<script>alert('Please fill in all required fields.');</script>");
                return;
            }

            string connectionString = GetConnectionString(); // Replace with your actual connection string
            string usr_name = txtName.Text;
            string email_id = txtEmail.Text;
            string emp_Id = txtEmpId.Text;
            string phone_No = txtPhone.Text;
            string concern = txtConcern.Text;
            DateTime currentDate = DateTime.Now;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string insertQuery = "INSERT INTO ConcernMaster (DATE,USR_NAME, EMAIL_ID, EMP_CODE, PHONE_NO, CONCERN) VALUES (@date,@usr_name, @email_id, @emp_Id, @phone_No, @concern)";
                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@DATE", currentDate);
                    cmd.Parameters.AddWithValue("@usr_name", usr_name);
                    cmd.Parameters.AddWithValue("@email_id", email_id);
                    cmd.Parameters.AddWithValue("@emp_Id", emp_Id);
                    cmd.Parameters.AddWithValue("@phone_No", phone_No);
                    cmd.Parameters.AddWithValue("@concern", concern);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Concern submitted successfully!');</script>");
                        // Clear the form after successful submission (optional)
                        txtName.Text = "";
                        txtEmail.Text = "";
                        txtEmpId.Text = "";
                        txtPhone.Text = "";
                        txtConcern.Text = "";
                    }
                    else
                    {
                        Response.Write("<script>alert('An error occurred while submitting concern. Please try again.');</script>");
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL errors gracefully (log the error, display user-friendly message)
                Response.Write("<script>alert('An error occurred: ' + ex.Message);</script>");
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("FirstPage.aspx");

        }
       
        protected void Next_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchConcerns.aspx");
        }
        protected void Usr_Login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}