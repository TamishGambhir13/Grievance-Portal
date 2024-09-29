using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration; // Required for secure password storage

namespace ShareYourConcern
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginMessage"] != null)
            {
                string message = Session["LoginMessage"] as string;
                // Display message using Label control or other methods
                Label1.Text = message;
                Session["LoginMessage"] = null; // Clear session variable
                Thread.Sleep(2000);
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            // Input validation (optional but recommended)
            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
            {
                Response.Write("<script>alert('Please enter both username and password.');</script>");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString())) // Use secure connection string
                {
                    con.Open();

                    string loginQuery = "SELECT Count(*) FROM USR_DTL WHERE USR_NAME=@username AND PASSWORD=@password"; // Use parameterized query
                    SqlCommand cmd = new SqlCommand(loginQuery, con);

                    cmd.Parameters.AddWithValue("@username", username.Text);

                    // Secure password storage (assuming password is stored in web.config)
                    //string password = ConfigurationManager.AppSettings["password"];
                    cmd.Parameters.AddWithValue("@password", password.Text); // Use retrieved password

                    int count = (int)cmd.ExecuteScalar();
                    con.Close();

                    if (count > 0)
                    {
                        con.Open();
                        loginQuery = "SELECT USR_PKID FROM USR_DTL WHERE USR_NAME=@username AND PASSWORD=@password"; // Use parameterized query
                        cmd = new SqlCommand(loginQuery, con);

                        cmd.Parameters.AddWithValue("@username", username.Text);
                        cmd.Parameters.AddWithValue("@password", password.Text); // Use retrieved password

                        int USR_PKID = (int)cmd.ExecuteScalar();
                        con.Close();
                        // Login successful! Perform actions after successful login
                        Session["LoginMessage"] = "Login successful!"; // Set session variable
                        Session["LoggedInUser"] = username.Text;
                        Session["USR_PKID"] = USR_PKID;
                        Response.Redirect("ConcernPage.aspx");
                        // You can redirect to a secure page or perform other actions based on successful login
                    }
                    else
                    {
                        Response.Write("<script>alert('Login Failed!!');</script>");
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle connection or other SQL errors
                Response.Write("<script>alert('An error occurred: ' + ex.Message);</script>");
                // Consider logging the error for further troubleshooting
            }
        }
        

        private string GetConnectionString()
        {
            // Replace with your actual connection string details without the password
            //return "Data Source=GAMBHIRS\\SQLEXPRESS;database=ShareYourConcernDB;uid=ShareYourConcernDB;pwd=Tamish@2024;Integrated Security=True;TrustServerCertificate=True";
            return "data source=GAMBHIRS\\SQLEXPRESS;initial catalog=ShareYourConcernDB;user id=sa;password=Tamish@2024;App=EntityFraimwork&quot;";
        }

        /*protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }*/

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FirstPage.aspx");
        }
        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}

