using Microsoft.Data.SqlClient;
using System.Data;

namespace yom_web.Models
{
    public class iconmodel
    {
        public string icon { get; set; }
        public string title { get; set; }
        public string des { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=yom;User Id=sa;pwd=123;TrustServerCertificate=True");

        public int insert(string icon,string title, string des)
        {
            SqlCommand cmd = new SqlCommand("insert into icon(icon,title,des)values('" + icon + "','" + title + "','" + des + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();

        }
		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[icon] ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

        public int icon_delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[icon] where id=" + id, con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet update(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[icon] where id='" + id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int update_data(int id, string icon, string title, string discription)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[icon] set icon='" + icon + "',title='" + title + "',des='" + discription + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
