using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ch09Cart
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MarinaConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string query = " SELECT * from Customer where Firstname ='" + fname.Text + "' and Lastname='" + lname.Text + "'";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter dataReader = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataReader.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    Session["ID"] = dt.Rows[0]["ID"].ToString();
                    Session["Firstname"] = fname.Text;
                    Response.Redirect("~/Register.aspx");
                    //lblError.Text = Session["ID"].ToString();
                }
                else
                {
                    lblError.Text = "Invalid Username or Password";
                }

            }
        }
    }
}