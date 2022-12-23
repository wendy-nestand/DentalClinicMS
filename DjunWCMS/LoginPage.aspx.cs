using DjunPro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DjunWCMS
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
           
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT user_id FROM [user] WHERE user_name=@username AND user_password=@password";
            cmd.Parameters.AddWithValue("@username", tbUser.Text);
            cmd.Parameters.AddWithValue("@password", tbPass.Text); // Utils.Hash encrypt the password 
            con.Open();
            var result = cmd.ExecuteScalar();
            con.Close();

            if (result != null)
            {
                //Authentication succeed
                if (tbUser.Text == "admin")
                {
                    
                    Response.Redirect("AdminPage.aspx");
                    
                }
                else
                {
                    con.Open();
                    cmd.CommandText = "SELECT  account_id, account_type FROM account WHERE  account_user_id = @user_id";
                    cmd.Parameters.AddWithValue("@user_id", result.ToString());
                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {
                        int account_id = reader.GetInt32(0);
                        int account_type = reader.GetInt32(1);


                        con.Close();

                        if (account_type == 0)
                        {
                            //Secretary Panel
                            Response.Redirect("SecretaryPage.aspx");
                           

                        }
                        if (account_type == 1)
                        {
                            // Doctor Panel
                            Response.Redirect("DoctorPage.aspx");

                        }
                        if (account_type == 2)
                        {
                            // admin Panel
                            Response.Redirect("AdminPage.aspx");

                        }
                    }
                }
            }
            else
            {
                //Authentication Failed
            }




        }
    }
}