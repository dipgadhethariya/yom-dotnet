using Microsoft.Data.SqlClient;
using System.Data;

namespace yom_web.Models
{
    public class slidermodel
    {
        public string title { get; set; }
        public string des { get; set; }
        public IFormFile img { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=yom;User Id=sa;pwd=123;TrustServerCertificate=True");


        public int insert(string title, string des, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into add_slider(title,des,img)values('" + title + "','" + des + "','" + filename + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[add_slider] ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}
        public int delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[add_slider] where id=" + id, con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet update(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[add_slider] where id='" + id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int update_data(int id, string title, string discription,string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[add_slider] set title='" + title+ "',des='" + discription + "',img='" + filename + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
