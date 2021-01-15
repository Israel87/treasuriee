using AdTresh.Data;
using AdTresh.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdTresh
{
    public partial class _Default : Page
    {
        string connection = DbConnection.Connection();

 
        protected void Page_Load(object sender, EventArgs e)
        {}

        protected void submit_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                try
                {
                    OleDbDataAdapter da = new OleDbDataAdapter($" Select* from [tblSysUserList] Where UserName =" +
                        $" 'Treasuriee' and UserPassword = '" + inputPassword.Value + "'", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        // Capture Session Data at login
                        Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                        int UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                       
                        DateTime date = DateTime.Now;
                        // get the query string to insert into the session table
                        string insertQuery = "INSERT INTO [tblSysSessionLog](UserID, SessionTimeIn, SessionTimeout, NormalLogout)" +
                            "VALUES(@UserID, @SessionTimeIn, @SessionTimeout, @NormalLogout)";

                        // get the autonumber of the inserted row
                        string getIdQuery = "Select @@Identity";
                        using (OleDbCommand cmd = new OleDbCommand(insertQuery))
                        {
                            cmd.Parameters.AddWithValue("@UserID", UserID);
                            cmd.Parameters.AddWithValue("@SessionTimeIn", DateTime.Now.ToString());
                            cmd.Parameters.AddWithValue("@SessionTimeout", DateTime.Now.ToString());
                            cmd.Parameters.AddWithValue("@NormalLogout", false);
                            cmd.Connection = conn;
                            conn.Open();
                            try
                            {
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = getIdQuery;
                                int id = (int)cmd.ExecuteScalar();
                                Session["SessionID"] = id;
                                conn.Close();
                                bool userActivity = UserActivity.CaptureActivity(id, DateTime.Now, "Login Page", "Visited");
                                Response.Redirect("Dashboard.aspx");
                            }
                            catch (Exception ex)
                            {
                                var error = ex.Message.ToString();
                            }
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "login", "loginAlert()", true);
                    }
                }
                catch (Exception excpt)
                {
                    var mainError = excpt.Message.ToString();
                }

            }
       }
    }
}