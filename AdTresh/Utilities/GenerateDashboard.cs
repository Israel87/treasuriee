using AdTresh.Data;
using System;
using System.Data.OleDb;

namespace AdTresh.Utilities
{
    public class GenerateDashboard
    {
        string connection = DbConnection.ConnectionII();

        int currentYear = DateTime.Today.Year;
        string testMonth = "December";

        public string getMonth()
        {
            string _activeMonth = "";
            int currentMonth = DateTime.Today.Month;
            switch (currentMonth)
            {
                case 1:
                    _activeMonth = "January";
                    break;
                case 2:
                    _activeMonth = "February";
                    break;
                case 3:
                    _activeMonth = "March";
                    break;
                case 4:
                    _activeMonth = "April";
                    break;
                case 5:
                    _activeMonth = "May";
                    break;
                case 6:
                    _activeMonth = "June";
                    break;
                case 7:
                    _activeMonth = "July";
                    break;
                case 8:
                    _activeMonth = "August";
                    break;
                case 9:
                    _activeMonth = "September";
                    break;
                case 10:
                    _activeMonth = "October";
                    break;
                case 11:
                    _activeMonth = "November";
                    break;
                case 12:
                    _activeMonth = "December";
                    break;
                default:
                    _activeMonth = "January";
                    break;
            }
            return _activeMonth;
        }



        public int GetTotalTithe()
        {
            string _currentMonth = getMonth();
            OleDbConnection conn = new OleDbConnection(connection);
            string query = $"SELECT SUM(Tithe) FROM [qryPrintSummary_Crosstab] WHERE PmtMonthName='" + testMonth + "' AND mYear = " + 2020 + "";
            OleDbCommand command = new OleDbCommand(query, conn);
            conn.Open();
            int total = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return total;

        }

        public int GetTotalOffering()
        {
            string _currentMonth = getMonth();
            OleDbConnection conn = new OleDbConnection(connection);
            string query = $"SELECT SUM(`Church Expense Offering`) FROM [qryPrintSummary_Crosstab] WHERE PmtMonthName='" + testMonth + "' AND mYear = " + 2020 + "";
            OleDbCommand command = new OleDbCommand(query, conn);
            conn.Open();
            int total = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return total;

        }

        public int GetTotalSpecialProject()
        {
            string _currentMonth = getMonth();
            OleDbConnection conn = new OleDbConnection(connection);
            string query = $"SELECT SUM(`Special Project`) FROM [qryPrintSummary_Crosstab] WHERE PmtMonthName='" + testMonth + "' AND mYear = " + 2020 + "";
            OleDbCommand command = new OleDbCommand(query, conn);
            conn.Open();
            int total = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return total;

        }
    }
}
