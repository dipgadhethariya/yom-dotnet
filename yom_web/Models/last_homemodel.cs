using Microsoft.Data.SqlClient;
using System.Data;

namespace yom_web.Models
{
	public class last_homemodel
	{
		public IFormFile img { get; set; }
		public string title { get; set; }
		public string name { get; set; }
		public string date { get; set; }
		public string category { get; set; }
		public string des { get; set; }

		SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=yom;User Id=sa;pwd=123;TrustServerCertificate=True");

		public int insert(string filename, string title, string name,string date,string category,string des)
		{
			SqlCommand cmd = new SqlCommand("insert into last_home(img,title,name,date,category,des)values('" + filename + "','" + title + "','" + name + "','" + date + "','" + category + "','" + des + "')", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[last_home] ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}
		public int delete(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[last_home] where id=" + id, con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}
		public DataSet update(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[last_home] where id='" + id + "'", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}
		public int update_data(int id, string filename, string title, string name, string date, string category, string des)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[last_home] set img='" + filename + "', title='" + title + "',name='" + name + "',date='" + date + "',category='" + category+ "',des='" + des+ "'  where id =" + id, con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}
	}
}
