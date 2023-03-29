using DjunPro;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DjunWCMS
{
    public partial class InfoPage : System.Web.UI.Page
    {
        static string id;
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStrings"].ConnectionString);



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"].Equals("secretary"))
                {
                    txtPassword.Visible = false;
                    txtUsername.Visible = false;  
                }
                id = Request.QueryString["id"];
                if (id != null)
                {
                    txtName.Text = id;
                    GetInfoInDatabaseWithId(id);
                }
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // The id already null befor its call..for an edit action.
            if(id == string.Empty) 
            {
                if (Request.QueryString["type"].Equals("secretary"))
                {
                    AddNewPatientInfo();
                }
                else
                {
                    AddNewInfo();
                }
                 
            }
            else
            {
                Edit();
                Response.Redirect("AdminPage.aspx");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
            }

        }

        void Edit() 
        {

            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE account SET account_name = @name, account_dob = @dob, account_notes = @notes, account_phone = @phone WHERE  account_id = @id";
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@dob", clDob.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@notes", txtNoteView.Text);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();

            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Inserted correctly");
            }

            con.Close();

        }

        public void EditPatientProfile()
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStrings"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "";

        }

        public void AddNewInfo()
        {
            try
            {
                // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStrings"].ConnectionString);
                string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [user] (user_name, user_password) VALUES (@username, @password)";
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                con.Open();


                if (cmd.ExecuteNonQuery() > 0)
                {
                    int id;
                    // add in user table
                    cmd.CommandText = "SELECT user_id FROM [user] WHERE user_name = @username";

                    id = (int)cmd.ExecuteScalar();
                    cmd.CommandText = "INSERT INTO account (account_user_id, account_name, account_type, account_notes, account_creation_date) VALUES (@user_id, @name, @type, @notes, @date)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = id.ToString();
                    cmd.Parameters.AddWithValue("@name", Utils.dataScrubbing(txtName.Text));
                    cmd.Parameters.AddWithValue("@type", ddlType.SelectedIndex);
                    cmd.Parameters.AddWithValue("@notes", txtNoteView.Text);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                }
                con.Close();
                //updateList("");
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }

        }


        public void AddNewPatientInfo()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = " INSERT INTO [account] (account_user_id, account_name, account_type, account_notes, account_creation_date, account_phone) VALUES (@name, @type, @notes, @date, @phone)";
            con.Open(); 
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@type", txtType.Text);
            cmd.Parameters.AddWithValue("@notes", txtNotes.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("MM/dd/aaaa"));

            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("Inserted successfully");
            }

        }

        public void GetInfoInDatabaseWithId(string id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT  user_name, account_name, account_dob, account_phone, account_type, account_notes, account_creation_date FROM [user], account WHERE user_id = account_user_id AND account_id = @id ";
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Fill the view account panel

                txtAccountId.Text = id.ToString();
                txtUsername.Text = reader.GetValue(0).ToString();
                txtName.Text = reader.GetValue(1).ToString();
                clDob.Text = reader.GetValue(2).ToString();
                txtPhone.Text = reader.GetValue(3).ToString();


                if (reader.GetInt32(4).Equals("0"))
                {
                    ddlType.Text = "Secretary";
                }
                else
                {
                    txtType.Text = "Doctor";
                }

                txtNoteView.Text = reader.GetValue(5).ToString();
                txtCreate.Text = reader.GetValue(6).ToString();
            }

            con.Close();
        }
    }
}