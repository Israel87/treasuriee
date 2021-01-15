using AdTresh.Data;
using System;
using System.Data.OleDb;

namespace AdTresh.Utilities
{
    // Capture User activities by passing in parameters.
    public class UserActivity
    {
        public static bool CaptureActivity(int sessionID, DateTime logTime, string activity, string remark)
        {
            bool insertUserActivity = false;
            string connection = DbConnection.Connection();
            string query = "INSERT INTO [tblSysUserActivityLog](SessionID, LogTime, Activity, Remark) VALUES(@SessionID, @LogTime, @Activity, @Remark)";

            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                try
                {
                    using (OleDbCommand cmd = new OleDbCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@SessionID", sessionID);
                        cmd.Parameters.AddWithValue("@LogTime", logTime.ToString());
                        cmd.Parameters.AddWithValue("@Activity", activity);
                        cmd.Parameters.AddWithValue("@Remark", remark);
                        cmd.Connection = conn;
                        conn.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            insertUserActivity = true;
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message.ToString();
                        }

                    }
                }
                catch (Exception excpt)
                {
                    var mainError = excpt.Message.ToString();
                }
                return insertUserActivity;


            }



        }
    }
}