using Microsoft.Data.SqlClient;
using System.Data;

namespace yom_web.Models
{
    public class adminmodel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=yom;User Id=sa;pwd=123;TrustServerCertificate=True");



        public DataSet select(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[adminlogin] where email='" + email + "' and password='" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

    }
}
