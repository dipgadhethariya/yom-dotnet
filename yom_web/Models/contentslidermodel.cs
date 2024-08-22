using Microsoft.Data.SqlClient;
using System.Data;

namespace yom_web.Models
{
    public class contentslidermodel
    {
        public string des { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=yom;User Id=sa;pwd=123;TrustServerCertificate=True");

        public int insert(string des, string name, string city,string country)
        {
            SqlCommand cmd = new SqlCommand("insert into contentslider(des,name,city,country)values('" + des + "','" + name + "','" + city + "','"+ country +"')", con);
            con.Open();

            return cmd.ExecuteNonQuery();

        }
        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[contentslider] ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int content_delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[contentslider] where id=" + id, con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet update(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[contentslider] where id='" + id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int update_data(int id, string des, string name, string city, string country)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[contentslider] set des='" + des + "',name='" + name+ "',city='" + city + "',country='" + country + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
