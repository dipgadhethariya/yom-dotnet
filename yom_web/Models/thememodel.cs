using Microsoft.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace yom_web.Models
{
    public class thememodel
    {
        public string title { get; set; }
        public string lorem { get; set; }
        public string des { get; set; }
        public IFormFile img { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=yom;User Id=sa;pwd=123;TrustServerCertificate=True");

        public int insert(string title,string lorem, string des, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into theme(title,lorem,des,img)values('" + title + "','" + lorem + "','" + des + "','" + filename + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[theme] ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[theme] where id=" + id, con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet update(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[theme] where id='" + id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int update_data(int id, string title,string lorem, string discription, string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[theme] set title ='" + title + "', lorem ='" + lorem + "',des='" + discription + "',img='" + filename + "'  where id =" + id, con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
