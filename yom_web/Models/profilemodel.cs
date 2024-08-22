using Microsoft.Data.SqlClient;
using System.Data;

namespace yom_web.Models
{
	public class profilemodel
	{

		public IFormFile img { get; set; }
		public string title { get; set; }
		public string des { get; set; }

		SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=yom;User Id=sa;pwd=123;TrustServerCertificate=True");
		public int insert(string filename, string des, string title)
		{
			SqlCommand cmd = new SqlCommand("insert into profile(img,title,des)values('" + filename + "','" + des + "','" + title + "')", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[profile] ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}
		public int delete(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[profile] where id=" + id, con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}
		public DataSet update(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[profile] where id='" + id + "'", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}
		public int update_data(int id, string filename, string title, string discription)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[profile] set img='" + filename + "', des='" + discription + "',title ='" + title + "'  where id =" + id, con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}
	}
}
