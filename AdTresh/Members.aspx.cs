﻿using AdTresh.Data;
using AdTresh.Utilities;
using System;
using System.Data;
using System.Data.OleDb;

namespace AdTresh
{
    public partial class Members : System.Web.UI.Page
    {
        private string connection = DbConnection.ConnectionII();
        private int pageSize = 5;
        //private int lastRecord = 0;

        OleDbDataAdapter da = null;
        DataTable dt = new DataTable();
        DataSet dataSet = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SessionID"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                // get Session ID and register user activity
                var SessionID = Convert.ToInt32(Session["SessionID"].ToString());
                // register User Activity
                UserActivity.CaptureActivity(SessionID, DateTime.Now, "Member Page", "Visited/Page Reload");


                // Auto populate the member details here.
                using (OleDbConnection conn = new OleDbConnection(connection))
                {

                    try
                    {

                        da = new OleDbDataAdapter($"SELECT TOP " + pageSize + " * FROM [tblMembershipMembers]  ORDER BY MembershipID ", conn);

                        da.Fill(dataSet, "Members");
                        var lastRecord = Convert.ToInt32(dataSet.Tables["Members"].Rows[pageSize - 1]["MembershipID"].ToString());
                        Session["LastRecord"] = lastRecord;

                        if (dataSet.Tables["Members"].Rows.Count > 0)
                        {
                            string html = "";
                            foreach (DataRow item in dataSet.Tables["Members"].Rows)
                            {
                                var _sex = item["Sex"].ToString() == "1" ? "Male" : "Female";
                                html += "<td>" + item["MembershipID"] + "</td><td>" + item["FirstName"] + "</td><td>" + item["SurName"] + "</td><td>" + _sex + "</td></tr>";
                                t_body.InnerHtml = html;
                            }

                        }
                        else
                        {
                            t_body.InnerHtml = "No record found.";
                        }

                    }
                    catch (Exception)
                    {

                    }

                }
            }
          

        }

        protected void saveTransaction_Click(object sender, EventArgs e)
        {
            var _surname = surname.Value;
            var _sex = sex.Value;
            var _phonenumber = phonenumber.Value;
            var _firstname = firstname.Value;
            var _maritalstatus = maritalstatus.Value;
            var _email = email.Value;
            var _othernames = othernames.Value;
            var _residentialaddress = residentialaddress.Value;

            var result = "";

            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                var value = "SELECT max(MembershipID) as Result FROM [tblMembershipMembers]";
                using (OleDbCommand cmd = new OleDbCommand(value, conn))
                {
                    conn.Open();
                    try
                    {
                        // Get the highest number 
                        cmd.CommandType = CommandType.Text;
                        OleDbDataReader _value = cmd.ExecuteReader();
                        if (_value.HasRows)
                        {
                            while (_value.Read())
                            {
                                result = _value[0].ToString();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        var _exception = ex.Message.ToString();
                    }
                }
                try
                {
                    string query = "Insert into [tblMembershipMembers] (MembershipID, SurName, FirstName, OtherNames, Sex, MaritalStatus, eMail, ResidentialAddress, GSM1)" +
                    "values (@MembershipID, @SurName, @FirstName, @OtherNames, @Sex, @MaritalStatus, @eMail, @ResidentialAddress, @GSM1)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Do the insert here 
                        cmd.Parameters.AddWithValue("@MembershipID", Convert.ToInt32(result) + 1);
                        cmd.Parameters.AddWithValue("@SurName", _surname);
                        cmd.Parameters.AddWithValue("@FirstName", _firstname);
                        cmd.Parameters.AddWithValue("@OtherNames", _othernames);
                        cmd.Parameters.AddWithValue("@Sex", Convert.ToByte(_sex));
                        cmd.Parameters.AddWithValue("@MaritalStatus", Convert.ToByte(_maritalstatus));
                        cmd.Parameters.AddWithValue("@eMail", _email);
                        cmd.Parameters.AddWithValue("@ResidentialAddress", _residentialaddress);
                        cmd.Parameters.AddWithValue("@GSM1", _phonenumber);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            ClientScript.RegisterStartupScript(this.GetType(), "createmember", "createMember()", true);
                            ClearInputFields();


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

            }

        }

        // Clear form fields after saving
        public void ClearInputFields()
        {
            surname.Value = "";
            sex.Value = "";
            phonenumber.Value = "";
            firstname.Value = "";
            maritalstatus.Value = "";
            email.Value = "";
            othernames.Value = "";
            residentialaddress.Value = "";
        }

        protected void Previous_Click(object sender, EventArgs e)
        {
            string html = "";
            string _norecord = "No Record";

            using (OleDbConnection conn = new OleDbConnection(connection))
            {

                try
                {
                    var _lastRecord = Session["lastRecord"];
                    da = new OleDbDataAdapter($"SELECT TOP " + pageSize + " * FROM [tblMembershipMembers] WHERE MembershipID < " + _lastRecord + " ORDER BY MembershipID DESC", conn);
                   // dataSet.Tables["Members"].Rows.Clear();
                    da.Fill(dataSet, "Members");
                    Session.Remove("LastRecord");
                    // var lastRecord = Convert.ToInt32(dataSet.Tables["Members"].Rows[pageSize - 1]["MembershipID"].ToString());
                    var lastRecord = Convert.ToInt32(_lastRecord) - pageSize;
                    Session["LastRecord"] = lastRecord;

                    if (dataSet.Tables["Members"].Rows.Count > 0)
                    {
                    
                        foreach (DataRow item in dataSet.Tables["Members"].Rows)
                        {
                            var _sex = item["Sex"].ToString() == "1" ? "Male" : "Female";
                            html += "<td>" + item["MembershipID"] + "</td><td>" + item["FirstName"] + "</td><td>" + item["SurName"] + "</td><td>" + _sex + "</td></tr>";
                            t_body.InnerHtml = html;
                        }

                    }
                    else
                    {
                        html += "<td>" + _norecord + "</td></tr>";
                        t_body.InnerHtml = "No record found.";
                    }

                }
                catch (Exception ex)
                {

                }

            }

        }

        protected void Next_Click(object sender, EventArgs e)
        {
       

            using (OleDbConnection conn = new OleDbConnection(connection))
            {

                try
                {
                    var _lastRecord = Session["LastRecord"];
                    da = new OleDbDataAdapter($"SELECT TOP " + pageSize + " * FROM [tblMembershipMembers] WHERE MembershipID > " + _lastRecord + " ORDER BY MembershipID", conn);
                   // dataSet.Tables["Members"].Rows.Clear();
                    da.Fill(dataSet, "Members");
                    Session.Remove("LastRecord");
                    
                    var lastRecord = Convert.ToInt32(dataSet.Tables["Members"].Rows[pageSize - 1]["MembershipID"].ToString());
               
                    Session["LastRecord"] = lastRecord;


                    if (dataSet.Tables["Members"].Rows.Count > 0)
                    {
                        string html = "";
                        foreach (DataRow item in dataSet.Tables["Members"].Rows)
                        {
                            var _sex = item["Sex"].ToString() == "1" ? "Male" : "Female";
                            html += "<td>" + item["MembershipID"] + "</td><td>" + item["FirstName"] + "</td><td>" + item["SurName"] + "</td><td>" + _sex + "</td></tr>";
                            t_body.InnerHtml = html;
                        }

                    }
                    else
                    {
                        t_body.InnerHtml = "No record found.";
                    }

                }
                catch (Exception ex)
                {

                }

            }

        }
    }
}
