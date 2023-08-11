using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Automation
{
    public class connect 
    {

        public SqlDataAdapter adp = new SqlDataAdapter();
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection con = new SqlConnection();
        public connect()
        {
            con.ConnectionString = "Data Source=LAPTOP-3JDAV98L\\SQLEXPRESS;Initial Catalog=bgroup3;Integrated Security=true";
            con.Open();
            cmd.Connection = con;
        }
    }
}
