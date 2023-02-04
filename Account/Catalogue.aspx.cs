using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace IzradaWebFormsSajta.Account
{
    public partial class Catalogue : System.Web.UI.Page
    {
        SqlConnection sql = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DzonijevSajt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void Page_Load(object sender, EventArgs e)
        {
            Populate();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using(sql)
            {
                sql.Open();
                string search = TextBox1.Text;
                SearchLike(search);
            }
        }

        void Populate()
        {
            string query = "select * from equipmenttbl";
            SqlCommand command = new SqlCommand(query, sql);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        void SearchLike(string search)
        {
            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();

            p1.Value=search+"%";     
            p1.ParameterName = "@search";

            string query = "select * from equipmenttbl where ename like @search";
            SqlCommand command = new SqlCommand(query, sql);
            command.Parameters.Add(p1);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}