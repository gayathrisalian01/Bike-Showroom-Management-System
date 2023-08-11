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
    public partial class WebForm1 : System.Web.UI.Page
    {
        connect c;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnforget_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/changepassform.aspx");
        }

        protected void btnsign_Click(object sender, EventArgs e)
        {
            try
            {
                c = new connect();
                ds = new DataSet();
                if (txtuser.Text != "" || txtpass.Text != "")
                {
                    if (txtuser.Text == "admin")
                    {
                        c.cmd.CommandText = "select * from login where Username='" +
                       txtuser.Text + "'and Password='" + txtpass.Text + "'";
                        adp.SelectCommand = c.cmd;
                        adp.Fill(ds, "admn");
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Login successfull", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Response.Redirect("~/screen.aspx");
                        }
                        else if (txtuser.Text == "" || txtpass.Text == "")
                        {
                            MessageBox.Show("Enter all the fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Only Admin can login here", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtuser.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Enter all the fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/welcome.aspx");
        }
    }



}
                
