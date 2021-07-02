using AdTresh.Data;
using AdTresh.Utilities;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdTresh
{
    public partial class Reports : System.Web.UI.Page
    {
        string connection = DbConnection.ConnectionII();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionID"] == null)
                Response.Redirect("Default.aspx");
            // get Session ID and register user activity
            var SessionID = Convert.ToInt32(Session["SessionID"]);
            // register User Activity
            UserActivity.CaptureActivity(SessionID, DateTime.Now, "Report Page", "Visited/Page Reload");

            var _today = DateTime.Today;
            DateTime date = new DateTime(2018, 12, 01);
            string strDate = date.ToString("d/MM/yyyy").Replace('-', '/');
            // var date2 = Convert.ToDateTime(strDate);
       
            
            //// Report Viewer
            //using (OleDbConnection conn = new OleDbConnection(connection))
            //{
            //    try
            //    {
            //        OleDbDataAdapter da = new OleDbDataAdapter($"SELECT * FROM [qryPrintSummary_Crosstab] WHERE PmtMonthName='May' AND mYear=2020"
            //         , conn);
            //        //OleDbDataAdapter da = new OleDbDataAdapter($"SELECT * FROM [qryPrintSummary_Crosstab] WHERE PaymentDate='16-01-2016' AND MembershipID='1116'"
            //        //, conn);

            //        DataSet dt = new DataSet();
            //        da.Fill(dt);
            //        ReportDocument rpt = new ReportDocument();
            //        rpt.Load(Server.MapPath("~/MonthlyReport.rpt"));
            //        rpt.SetDataSource(dt.Tables["Table"]);
            //        CrystalReportViewer1.ReportSource = rpt;
            //        rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Monthly Report");
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter da = null;
            DataSet dt = new DataSet();

            // Weekly Summary variable 
            var _weeklySummary = week.Value;
            // Simple Summary variable 
            var _simpleSummary = simpleSummary.Value; 

            //// Report Viewer
            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                try
                {
                    if (!string.IsNullOrEmpty(_weeklySummary))
                    {
                        da = new OleDbDataAdapter($"SELECT * FROM [qryPrintSummary_Crosstab] WHERE PaymentDate='" 
                            + Convert.ToDateTime(_weeklySummary).ToString("dd/MM/yyyy") + "'", conn);

                        da.Fill(dt);
                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(Server.MapPath("~/ReportTemplates/WeeklySummary.rpt"));
                        rpt.SetDataSource(dt.Tables["Table"]);
                        CrystalReportViewer1.ReportSource = rpt;
                        rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Weekly Summary Report");
                        week.Value = "";
                    }
                    else if(!string.IsNullOrEmpty(_simpleSummary))
                    {
                        da = new OleDbDataAdapter($"SELECT * FROM [qryPrintSummary_Crosstab] WHERE PaymentDate='" 
                            + Convert.ToDateTime(_simpleSummary).ToString("dd/MM/yyyy") + "'", conn);

                        da.Fill(dt);
                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(Server.MapPath("~/ReportTemplates/SimpleSummary.rpt"));
                        rpt.SetDataSource(dt.Tables["Table"]);
                        CrystalReportViewer1.ReportSource = rpt;
                        rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Simple Summary Report");
                        simpleSummary.Value = "";
                    }
                    else
                    {
                        // Monthly Report variables 
                        var _monthlyReport = month.Value.ToString();
                        var _yearlyReport = Convert.ToInt32(year.Value);

                        da = new OleDbDataAdapter($"SELECT * FROM [qryPrintSummary_Crosstab] WHERE PmtMonthName='"
                            + _monthlyReport + "' AND mYear= " + _yearlyReport + "", conn);

                        da.Fill(dt);
                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(Server.MapPath("~/ReportTemplates/MonthlyReport.rpt"));
                        rpt.SetDataSource(dt.Tables["Table"]);
                       // rpt.ParameterFields.Add(_monthlyReport);
                        CrystalReportViewer1.ReportSource = rpt;
                        rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Monthly Report");
                        month.Value = "";
                        year.Value = "";
                            
                    }

                }
                catch (Exception ex)
                {

                }
            }

        }
    }
}