using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IzradaWebFormsSajta.Admin
{
    public partial class ChangeCatalogue : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DzonijevSajt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid) 
                {
                    lblOutput.ForeColor = System.Drawing.Color.DarkGreen;
                    lblOutput.Text = "Page Valid!";

                    string ename = TextBox1.Text.Trim();
                    string emanuf = TextBox2.Text.Trim();
                    string etype = TextBox3.Text.Trim();
                    int ecost = int.Parse(TextBox4.Text.Trim());


                    InsertEquipment(ename, emanuf, etype,ecost);

                    Response.Redirect("~/Admin/ChangeCatalogue", false);
                }
                else 
                {                    
                    if (RequiredFieldValidator1.IsValid == false)
                        TextBox1.CssClass += " alert-danger textbox-warning";
                    if (RequiredFieldValidator2.IsValid == false || RegularExpressionValidator1.IsValid == false)
                        TextBox2.CssClass += " alert-danger textbox-warning";
                    if (RequiredFieldValidator3.IsValid == false || RegularExpressionValidator2.IsValid == false)
                        TextBox3.CssClass += " alert-danger textbox-warning";
                    if (RequiredFieldValidator4.IsValid == false || RegularExpressionValidator3.IsValid == false)
                        TextBox4.CssClass += " alert-danger textbox-warning";

                    lblOutput.ForeColor = System.Drawing.Color.Red;
                    lblOutput.Text = "Page Invalid!";
                }

            }
            catch (Exception ex)
            {
                ErrorLabel.Text = "SERVER ERROR";
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                System.Diagnostics.Debug.WriteLine("Exception Message: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Stack Trace: " + ex.StackTrace);
            }
        }

        void InsertEquipment(string ename, string manufacturer, string etype, int ecost)
        {
            try
            {
                using (con)
                {
                    con.Open();

                    SqlParameter p1 = new SqlParameter();
                    SqlParameter p2 = new SqlParameter();
                    SqlParameter p3 = new SqlParameter();
                    SqlParameter p4 = new SqlParameter();

                    p1.Value = ename;
                    p2.Value = manufacturer;
                    p3.Value = etype;
                    p4.Value = ecost;

                    p1.ParameterName = "@Name";
                    p2.ParameterName = "@Manuf";
                    p3.ParameterName = "@Etype";
                    p4.ParameterName = "@Ecost";

                    string query = "INSERT INTO equipmenttbl (ename, emanufacturer, etype, ecost) " +
                                    "VALUES (@Name, @Manuf, @Etype, @Ecost)";

                    SqlCommand command = new SqlCommand(query, con);

                    command.Parameters.Add(p1);
                    command.Parameters.Add(p2);
                    command.Parameters.Add(p3);
                    command.Parameters.Add(p4);

                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                ErrorLabel.Text = "SERVER ERROR";
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                System.Diagnostics.Debug.WriteLine("Exception Message: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Stack Trace: " + ex.StackTrace);
            }
        }
    }
    
}