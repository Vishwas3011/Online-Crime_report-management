using System;
using System.Collections.Generic;
using System.Linq;
ususing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace flightbooking
{
    public class DBConnection
    {
        public static string GetConnection
        {
            //String con = "Data Source=.\\sqlExpress;Initial Catalog=SalesDatabase;Integrated Security=True";
            //SqlConnection sqlCon = new SqlConnection(con);
            //return sqlCon;

            get{
                return "Data Source=.\\sqlExpress;Initial Catalog=SalesDatabase;Integrated Security=True";
               // return ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            }

            
        }
    }
}


