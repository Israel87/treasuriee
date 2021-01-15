using AdTresh.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdTresh
{
    public partial class About : Page
    {
        GenerateDashboard generateDashboard = new GenerateDashboard();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionID"] == null)
                Response.Redirect("Default.aspx");
            // get Session ID and register user activity
            var SessionID = Convert.ToInt32(Session["SessionID"]);
            // register User Activity
            UserActivity.CaptureActivity(SessionID, DateTime.Now, "Dashboard Page", "Visited/Page Reload");

            // get values for the dashboard 
            var _titheAmount = Convert.ToDecimal(generateDashboard.GetTotalTithe());
            var _totalExpenseOffering = generateDashboard.GetTotalOffering();
            var _totalSpecialProject = generateDashboard.GetTotalSpecialProject();

            // generate the appropriate percentages and values.
            // 40% of Church Offering
            var _fortyPercent = Convert.ToDecimal(0.4 * _totalExpenseOffering);
            var _tenPercent = Convert.ToDecimal(0.1 * _totalExpenseOffering);
            // repeat sum total of all tithe : _titheAmount.
            var _totalDuetoConference = Convert.ToDecimal(_titheAmount + _fortyPercent);

            sumtithe.Text = _titheAmount.ToString("#,##0.00");
            totaldue.Text = _totalDuetoConference.ToString("#,##0.00");
            tenper.Text = _tenPercent.ToString("#,##0.00");
            fortyper.Text = _fortyPercent.ToString("#,##0.00");

            // Card values
            totaltithe.Text = _titheAmount.ToString("#,##0.00");
            expenseoffering.Text = _totalExpenseOffering.ToString("#,##0.00");
            specialprojcts.Text = _totalSpecialProject.ToString("#,##0.00");

        }
    }
}