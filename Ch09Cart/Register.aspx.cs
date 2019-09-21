using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ch09Cart
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            if (fnameTextBox.Text != "" && lnameTextBox.Text != "" && phoneTextBox.Text != "" && cityTextBox.Text != "")
            {
                String CS = ConfigurationManager.ConnectionStrings["MarinaConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(CS))
                {
                    string query = "INSERT INTO Customer(FirstName,LastName,Phone,City) VALUES(@FirstName,@LastName,@Phone,@city)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@FirstName", fnameTextBox.Text);
                    cmd.Parameters.AddWithValue("@LastName", lnameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Phone", phoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@City", cityTextBox.Text);
                    cmd.ExecuteNonQuery();
                    lblError.Text = "Registration Successfull";
                    lblError.ForeColor = Color.Green;

                }
            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "All field are Mandatory";
            }
        }
    }
}