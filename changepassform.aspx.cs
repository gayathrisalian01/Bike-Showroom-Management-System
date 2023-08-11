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
    public partial class changepassform : System.Web.UI.Page
    {
        connect c;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" || txtopass.Text == "" || txtnpass.Text ==
"" || txtcpass.Text == "")
            {
                MessageBox.Show("Enter all the fields", "Message",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtopass.Text == txtnpass.Text)
            {
                MessageBox.Show("Old and New password should not be same",
               "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtnpass.Text != txtcpass.Text)
            {
                MessageBox.Show("New and confirm password does not match",
               "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                c = new connect();
                c.cmd.CommandText = "select * from login where Username='" +
               txtuser.Text + "'and Password='" + txtopass.Text + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "pass");
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    if (txtopass.Text != txtnpass.Text)
                    {
                        if (txtnpass.Text == txtcpass.Text)
                        {
                            c.cmd.CommandText = "update login set Password='" +
                           txtcpass.Text + "'where Username='" + txtuser.Text + "'";
                            int i = c.cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Password has been changed",
                               "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Response.Redirect("~/Alogin.aspx");
                            }
                            else
                            {
                                MessageBox.Show("Enter the correct values",
                               "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Old password does not match", "Message",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Alogin.aspx");
        }

        protected void linksque_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/securityq2.aspx");
        }
    }   
    }