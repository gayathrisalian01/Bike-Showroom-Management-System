using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Automation
{
    public partial class forgotpassform : System.Web.UI.Page
    {
        connect c;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {
                c = new connect();
                c.cmd.CommandText = "select * from login where Sans='" + txtans.Text + "' and Username = '" + txtuser.Text + "' and flag = 'Open'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "log");
                if (ds.Tables["log"].Rows.Count > 0)
                {
                    Response.Redirect("~/forgotpassform2.aspx");
                }
                else
                {
                    MessageBox.Show("Security details doesn't match");
                    txtuser.Text = "";
                    txtans.Text = "";
                   
                 }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Elogin.aspx");
        }

        
    }
}