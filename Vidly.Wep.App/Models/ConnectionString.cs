//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace Vidly.Wep.App.Models
//{
//    public class ConnectionString
//    {
//        public static string Connection()
//        {
//            var builder = new SqlConnectionStringBuilder()
//            {
//                DataSource = @".\SQLEXPRESS",
//                IntegratedSecurity = true,
//                InitialCatalog = "VidlyDatabase",
//                ApplicationName = "Vidly Application"
//            };
//            return builder.ConnectionString;

//        }
//    }
//}