using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace IzradaWebFormsSajta.Account
{
    public partial class Order : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DzonijevSajt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {                
                try
                {

                    using (con)
                    {
                        con.Open();

                        PopDD();
                    }

                }
                catch (Exception e2)
                {
                    Label3.Text = "SERVER ERROR";
                    Label3.ForeColor = System.Drawing.Color.Red;
                    System.Diagnostics.Debug.WriteLine("Exception Message " + e2.Message);
                    System.Diagnostics.Debug.WriteLine("Stack Trace " + e2.StackTrace);
                }

            }
        }

        void Pop()
        {
            string query = "select * from Shipment";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        void PopDD()
        {
            string query = "select ename from equipmenttbl";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataValueField = "ename";
            DropDownList1.DataBind();
        }

        void InsertSh(int eid,int quant,int price)
        {
            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();
            SqlParameter p3 = new SqlParameter();
            p1.Value = eid;
            p2.Value=quant;
            p3.Value=price;

            p1.ParameterName = "@eid";
            p2.ParameterName = "@quant";
            p3.ParameterName = "@price";

            string query = "insert into Shipment(eid,equantity,eprice) values(@eid,@quant,@price)";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            sqlCommand.Parameters.Add(p1);
            sqlCommand.Parameters.Add(p2);
            sqlCommand.Parameters.Add(p3);

            sqlCommand.ExecuteNonQuery();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (con)
                    {
                        con.Open();

                        int eid = DropDownList1.SelectedIndex;
                        int quant = int.Parse(TextBox1.Text);
                        InsertSh(eid, quant, Cena());
                        Label4.Visible = true;
                        Pop();
                    }
                }
                else
                {
                    if (RequiredFieldValidator1.IsValid == false || RegularExpressionValidator1.IsValid == false)
                        TextBox1.CssClass += " alert-danger textbox-warning";
                    
                }

            }
            catch (Exception e2)
            {
                Label3.Text = "SERVER ERROR";
                Label3.ForeColor = System.Drawing.Color.Red;
                System.Diagnostics.Debug.WriteLine("Exception Message " + e2.Message);
                System.Diagnostics.Debug.WriteLine("Stack Trace " + e2.StackTrace);
            }
        }

        int Cena()
        {
            string query = "select ecost from equipmenttbl where eid='" + DropDownList1.SelectedIndex + "'";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            int cost = 0;
            if(dr.Read())
            {
                cost = int.Parse(dr[0].ToString());
            }
            int price=cost*int.Parse(TextBox1.Text);
            dr.Close();
            return price;            
        }
    }
}