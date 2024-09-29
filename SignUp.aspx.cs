using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; // Required for database interaction
using System.Configuration; // Required for secure password storage (optional)
using System.Text.RegularExpressions; // For email validation

namespace ShareYourConcern
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFname.Text) && string.IsNullOrEmpty(txtPass.Text))
            {
                Response.Write("<script>alert('Please enter both username and password.');</script>");
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=GAMBHIRS\\SQLEXPRESS;initial catalog=ShareYourConcernDB;user id=sa;password=Tamish@2024;App=EntityFraimwork&quot;");
            con.Open();
            int active;
            if (bitCeased.Checked)
            {
                active = 1;
            }

            else
            {
                active = 0;
            }
            string insertQuery = "INSERT INTO USR_DTL VALUES(@USR_NAME,@PASSWORD,@EMAIL_ID,@PHONE_NO,@CEASED)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@USR_NAME", txtFname.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", txtPass.Text);
            cmd.Parameters.AddWithValue("@EMAIL_ID", txtEmail.Text);
            cmd.Parameters.AddWithValue("@PHONE_NO", txtPhone.Text);
            cmd.Parameters.AddWithValue("@CEASED", active);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Response.Write("<script type='text/javascript'>alert('registered successfully')</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('error in registration')</script>");
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}
