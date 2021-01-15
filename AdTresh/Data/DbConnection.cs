using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdTresh.Data
{
    public class DbConnection
    {
        public static string Connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["treasuriee"].ConnectionString;
            return cs;
        }
        public static string ConnectionII()
        {
            string cs = ConfigurationManager.ConnectionStrings["treasurieeII"].ConnectionString;
            return cs;
        }
    }
}