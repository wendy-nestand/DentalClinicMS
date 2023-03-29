using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DjunWCMS
{
    public partial class SecretaryPage : System.Web.UI.Page
    {
        static string type = "Patient";
        static string table = "account";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView(table);
            }

        }
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void BindGridView(string table)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"SELECT *  FROM {table} WHERE account_type=2", conn);
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


        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void linkAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("InfoPage.aspx?type=secretary");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        //protected void gvDetails_PageIndexChanging(object sender, GridViewCommandEventArgs e)
        //{

        //}

        protected void gvEdit(object sender, GridViewEditEventArgs e)
        {
            // Redirecting patient info for editing 
            GridView1.EditIndex = e.NewEditIndex;
            Label txtAccountId = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblAccountId");
            Label txtAccountType = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblAccountType");
            Response.Write(txtAccountId.Text);
            Response.Redirect($"InfoPage.aspx?id={txtAccountId.Text}&type=secretary&accountType={txtAccountType.Text}");

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Delete patient record in database 
        }

        protected void btnPatientProfile_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT *  FROM account WHERE account_type=2", conn);
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

        protected void btnReservation_Click(object sender, EventArgs e)
        {
            table = "reservation";
            BindGridView(table);
        }
    }
}