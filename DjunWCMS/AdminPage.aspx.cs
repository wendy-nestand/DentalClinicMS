using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DjunPro;

namespace DjunWCMS
{
    public partial class AdminPage : System.Web.UI.Page
    {
        //private SqlConnection conn = new SqlConnection("Data Source= DESKTOP-GBQB9HI\\MSSQLSERVER1; Integrated Security=true;Initial Catalog= DCD; uid=''; Password=''; ");
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGridview();
            }
            
        }

        protected void BindGridview()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT account_id, account_name, account_phone, account_creation_date FROM account", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    //WriteErrorMessageToLabel(" No data found !!!", false);
                }
                conn.Close();
               // lblPagePos.Text = "You are in page " + (gvDetails.PageIndex + 1).ToString() + " of " + gvDetails.PageCount;
            }
            catch (Exception ex)
            {
                //WriteErrorMessageToLabel("Error...!!! Check your connection " + ex.Message, false);
            }
        }


        protected void Link_Click(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;  // get the link button which trigger the event
            GridViewRow row = (GridViewRow)linkbutton.NamingContainer; // get the GridViewRow that contains the linkbutton
            txtUsename.Text = row.Cells[0].Text;  // get the first cell value of the row
                                                // if you want to get controls in templatefield , just use row.FindControl
           // lblmonth.Text = linkbutton.CommandArgument;
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#myModal').modal()", true);//show the modal
        }


        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Get back write the empty input error
            if (e.CommandName.Equals("AddNew"))
            {
                //LinkButton linkbutton = (LinkButton)sender;  // get the link button which trigger the event
                //GridViewRow row = (GridViewRow)linkbutton.NamingContainer; // get the GridViewRow that contains the linkbutton
                //txtUsename.Text = row.Cells[0].Text;  // get the first cell value of the row
                // if you want to get controls in templatefield , just use row.FindControl
                // lblmonth.Text = linkbutton.CommandArgument;
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#myModal').modal()", true);//show the modal

                TextBox txtUsername = (TextBox)GridView1.FooterRow.FindControl("txtUserName");
                TextBox txtName = (TextBox)GridView1.FooterRow.FindControl("txtName");
                TextBox txtPhone = (TextBox)GridView1.FooterRow.FindControl("txtPhone");
                TextBox txtNotes = (TextBox)GridView1.FooterRow.FindControl("txtNotes");
               
            }
        }

        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridview();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            TextBox txtUsername = (TextBox)GridView1.FooterRow.FindControl("txtUserName");
            TextBox txtName = (TextBox)GridView1.FooterRow.FindControl("txtName");
            TextBox txtPhone = (TextBox)GridView1.FooterRow.FindControl("txtPhone");
            TextBox txtNotes = (TextBox)GridView1.FooterRow.FindControl("txtNotes");
            TextBox txtPassword = (TextBox)GridView1.FooterRow.FindControl("txtPassword");

            

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO [user] (user_name, user_password) VALUES (@username, @password)";
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", Utils.hashPass(txtPassword.Text));
            con.Open();
            //

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
                cmd.Parameters.AddWithValue("@type", );
                cmd.Parameters.AddWithValue("@notes", txtNoteAcc.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);


            }
            


            con.Close();
        }

        protected void link_Click1(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;  // get the link button which trigger the event
            GridViewRow row = (GridViewRow)linkbutton.NamingContainer; // get the GridViewRow that contains the linkbutton
            txtUsename.Text = row.Cells[0].Text;  // get the first cell value of the row
                                                  // if you want to get controls in templatefield , just use row.FindControl
                                                  // lblmonth.Text = linkbutton.CommandArgument;
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#myModal').modal()", true);//show the modal

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        protected void linkAdd_Click(object sender, EventArgs e)
        {

        }
    }
}