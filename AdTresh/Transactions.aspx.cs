using AdTresh.Data;
using AdTresh.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdTresh
{
    public partial class Contact : Page
    {
        string connection = DbConnection.ConnectionII();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionID"] == null)
                Response.Redirect("Default.aspx");
            // get Session ID and register user activity
            var SessionID = Convert.ToInt32(Session["SessionID"]);
            // register User Activity
            UserActivity.CaptureActivity(SessionID, DateTime.Now, "Transaction Page", "Visited/Page Reload");
        }


        protected void generateData_Click(object sender, EventArgs e)
        {
            // get data based on the value sent 
            OleDbDataAdapter da = null;
            //OleDbDataAdapter daRegular = null;
            //OleDbDataAdapter daOthers = null;
            DataTable dt = new DataTable();
           
            if (string.IsNullOrEmpty(memId.Value))
            {
               ClientScript.RegisterStartupScript(this.GetType(), "membererror", "memberError()", true);
            }
            else
            {
                // get the date value from the input field
                if (!string.IsNullOrEmpty(entrydate.Value))
                {
                    using (OleDbConnection conn = new OleDbConnection(connection))
                    {
                        try
                        {
                            // using the integer SQL Query here with the removal of some quotes to represent integer MembershipID.
                            da = new OleDbDataAdapter($"SELECT * FROM [qryReceiptsReguler] WHERE MembershipID="
                                + Convert.ToInt32(memId.Value) + " AND EntryDate='" + Convert.ToDateTime(entrydate.Value).ToString("dd-MM-yyyy") + "'", conn);

                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            { }
                        }
                        catch (Exception ex)
                        {

                        }
                     }
                }
                else
                {
                    var membershipID = Convert.ToInt32(memId.Value);
                    using (OleDbConnection conn = new OleDbConnection(connection))
                    {
                        try
                        {
                            // using the integer SQL Query here with the removal of some quotes to represent integer MembershipID.
                            da = new OleDbDataAdapter($"SELECT * FROM [tblMembershipMembers] WHERE MembershipID=" + membershipID + "", conn);
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                // Capture Session Data at login
                                firstName.Value = dt.Rows[0]["FirstName"].ToString();
                                lastName.Value = dt.Rows[0]["SurName"].ToString();
                                address.Value = dt.Rows[0]["ResidentialAddress"].ToString();
                                string statusX = dt.Rows[0]["Status"].ToString();
                                // Using switch case here for status 
                                switch (statusX)
                                {
                                    case "1":
                                        status.Value = "Baptized - Regular Standing";
                                        break;
                                    case "2":
                                        status.Value = "Baptized - Membership not here";
                                        break;
                                    case "3":
                                        status.Value = "Baptized - Suspended";
                                        break;
                                    case "4":
                                        status.Value = "Baptized - Disfellowshipped";
                                        break;
                                    case "5":
                                        status.Value = "Baptizmal - Preparatory";
                                        break;
                                    case "6":
                                        status.Value = "Unbaptized";
                                        break;
                                    default:
                                        status.Value = "Not Recorded";
                                        break;
                                }
                                phonenumber.Value = dt.Rows[0]["Phone1"].ToString();
                                email.Value = dt.Rows[0]["eMail"].ToString();
                            }
                        }
                        catch (Exception ex) { }
                    }
                }
           
            }
          
        }

        protected void saveTransaction_Click(object sender, EventArgs e)
        {
            var paymentDate = DateTime.Today.ToShortDateString();
            var entryDate = paymentDate;
            var membershipID =Convert.ToInt32(memId.Value);
            var titheX = Convert.ToInt32(tithe.Value);
            var offeringX = Convert.ToInt32(offering.Value);
            var account = 1000;
            var paymentType = paymenttype.Value;
            var amountX = Convert.ToInt32(amount.Value);
            var transactionDetails = remark.Value;



            // automatically prepopulate the form view 
            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                // get the query string to insert into the session table
                // use the back tick to wrap field names that has spaces such as Church Expense Offering.
                string queryReceiptCards = "INSERT INTO [tblTransactionsReceiptsCards](PaymentDate, EntryDate, MembershipID,Tithe, `Church Expense Offering`)" +
                    "VALUES(@PaymentDate, @EntryDate, @MembershipID, @Tithe, `@Church Expense Offering`)";
                //string queryReceiptOthers = "INSERT INTO [tblTransactionReceiptOthers](PaymentDate, EntryDate, MembershipID,Tithe, Church Expense Offering)" +
                //  "VALUES(@paymentDate, @entryDate, @membershipID, @titheX, @offeringX)";
              
               
                    string getIdQuery = "Select @@Identity";
                    int id;
                    using (OleDbCommand cmd = new OleDbCommand(queryReceiptCards))
                    {
                        cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                        cmd.Parameters.AddWithValue("@EntryDate", entryDate);
                        cmd.Parameters.AddWithValue("@MembershipID", membershipID);
                        cmd.Parameters.AddWithValue("@Tithe", titheX);
                        cmd.Parameters.AddWithValue("`@Church Expense Offering`", offeringX);
                        cmd.Connection = conn;
                        conn.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = getIdQuery;
                            id = (int)cmd.ExecuteScalar();
                            conn.Close();
                            
                            // record the other offerings.
                            if (amountX != 0)
                            {
                                // insert into tblTransactionReceiptsOthers
                                string queryReceiptOthers = "INSERT INTO [tblTransactionsReceiptsOthers](MembershipID,ReceiptNo, " +
                                    "PaymentDate, EntryDate,Account, Amount, PaymentType, TransactionDetails)" +
                                    "VALUES(@MembershipID, @ReceiptNo, @PaymentDate, @EntryDate, @Account, @Amount, @PaymentType, @TransactionDetails)";
                                
                                using (OleDbCommand cmdII = new OleDbCommand(queryReceiptOthers))
                                {
                                    cmdII.Parameters.AddWithValue("@MembershipID", membershipID);
                                    cmdII.Parameters.AddWithValue("@ReceiptNo", id);
                                    cmdII.Parameters.AddWithValue("@PaymentDate", paymentDate);
                                    cmdII.Parameters.AddWithValue("@EntryDate", entryDate);
                                    cmdII.Parameters.AddWithValue("@Account", account);
                                    cmdII.Parameters.AddWithValue("@Amount", amountX);
                                    cmdII.Parameters.AddWithValue("@PaymentType", paymentType);
                                    cmdII.Parameters.AddWithValue("@TransactionDetails", transactionDetails);
                                    cmdII.Connection = conn;
                                    conn.Open();

                                        try
                                        {
                                            cmdII.ExecuteNonQuery();
                                            cmdII.CommandText = getIdQuery;
                                            ClientScript.RegisterStartupScript(this.GetType(), "createdtwo", "accountCreatedtwo()", true);
                                            conn.Close();
                                            
                                            // Clear all input fields.
                                            ClearInputFields();
                                        }
                                        catch (Exception ex2)
                                        {

                                        }
                                }

                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "createdone", "accountCreatedone()", true);

                                // Clear all input fields.
                                ClearInputFields();
                            }
                          
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message.ToString();
                        }
                    }

                
            }
        }


        // Clear the input fields after saving into DB.
        public void ClearInputFields()
        {
            memId.Value = "";
            tithe.Value = "";
            offering.Value = "";
            paymenttype.Value = "";
            amount.Value = "";
            remark.Value = "";
        }

        protected void UpdateData_Click(object sender, EventArgs e)
        {

        }
    }
}