using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Automation
{
    public partial class forgotpassform2 : System.Web.UI.Page
    {
        connect c;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {    if (txtuser.Text == "" | txtnpass.Text == "" | txtcpass.Text == "")
            {
                MessageBox.Show("Enter all the fields");
            }
            else
            {


                try
                {
                    c = new connect();
                    c.cmd.CommandText = "update login set Password='" + txtcpass.Text + "' where Username='" + txtuser.Text + "'";
                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("Password changed successfully");
                    txtuser.Text = "";

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    c.con.Close();
                }

            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/forgotpassform.aspx");
        }

        protected void linksque_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/securityq.aspx");
        }
    }
}