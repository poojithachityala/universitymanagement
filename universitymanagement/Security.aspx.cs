using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace universitymanagement
{
    public partial class Security : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string strcon = "Data Source=universitymanagementsystem.database.windows.net;uid=project;pwd=project123;database=universitymanagementsystem";
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand com = new SqlCommand("CUser", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("username", txtName.Text);
            SqlParameter p2 = new SqlParameter("password", txtPwd.Text);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            con.Open();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                lblMsg.Text = "Registration successful.";
                lblMsg.Visible = true;
            }
            else
            {
                lblMsg.Text = "Invalid username or password.";
                lblMsg.Visible = true;
            }

        }
    }
}