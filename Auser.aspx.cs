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
    public partial class Auser : System.Web.UI.Page
    {
        connect c;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;

        }

        protected void btnupd_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            txtuname1.Text = "";
            txtpass1.Text = "";
        }

        protected void btndis_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            c = new connect();
            ds = new DataSet();
            if (emplist1.Items.Count == 0)
            {
                c.cmd.CommandText = "select (Username) from login where flag='open'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "ct");
                if (ds.Tables["ct"].Rows.Count > 0)
                {
                    emplist1.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["ct"].Rows.Count; i++)
                    {
                        emplist1.Items.Add(ds.Tables["ct"].Rows[i].ItemArray[0].ToString());
                    }
                }
            }


        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            c = new connect();
            ds = new DataSet();

            if (emplist2.Items.Count == 0)
            {
                c.cmd.CommandText = "select (Username) from login where flag='Locked'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "ct1");
                if (ds.Tables["ct1"].Rows.Count > 0)
                {
                    emplist2.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["ct1"].Rows.Count; i++)
                    {
                        emplist2.Items.Add(ds.Tables["ct1"].Rows[i].ItemArray[0].ToString());
                    }
                }
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ahome.aspx");
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            try
            {
                c = new connect();
                c.cmd.CommandText = "select * from login where Username='" + txtuname1.Text + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "check");
                adp.Fill(dt);
                if (txtuname1.Text != "" && txtpass1.Text != "")
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Account already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        c.cmd.CommandText = "insert into login(Username, Password, flag) values(@User, @Pass, @flg)";
                        c.cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = txtuname1.Text;
                        c.cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txtpass1.Text;
                        c.cmd.Parameters.Add("@flg", SqlDbType.VarChar).Value = "Open";
                        c.cmd.ExecuteNonQuery();
                        MessageBox.Show("Account created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtpass1.Text = "";
                        txtuname1.Text = "";


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
            Panel1.Visible = true;
        }

        protected void btnclr_Click(object sender, EventArgs e)
        {
            txtuname1.Text = "";
            txtpass1.Text = "";
            Panel1.Visible = true;
        }

        protected void btncl_Click(object sender, EventArgs e)
        {
            txtpass1.Text = "";
            txtuname1.Text = "";
            Panel1.Visible = false;
        }

        protected void btnblock_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            if (emplist1.SelectedIndex == 0)
            {
                MessageBox.Show("Select the username to be blocked", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    c = new connect();
                    c.cmd.CommandText = "select * from login where Username='" + emplist1.SelectedItem.Text + "'";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds);
                    String flg;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        flg = ds.Tables[0].Rows[0]["flag"].ToString();
                        if (flg == "Locked")
                        {
                            MessageBox.Show("Account is already blocked", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            c.cmd.CommandText = "update login set flag='Locked'  where Username = '" + emplist1.SelectedItem.Text + "'";
                            c.cmd.ExecuteNonQuery();
                            MessageBox.Show("Account blocked successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Account does not exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Panel2.Visible = true;
                emplist1.SelectedIndex = 0;


            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            emplist1.SelectedIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (emplist2.SelectedIndex == 0)
            {
                MessageBox.Show("Select the username to be blocked", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    c = new connect();
                    c.cmd.CommandText = "select * from login where Username='" + emplist2.SelectedItem.Text + "'";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds);
                    String flg;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        flg = ds.Tables[0].Rows[0]["flag"].ToString();
                        if (flg == "Open")
                        {
                            MessageBox.Show("Account is already unblocked", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            c.cmd.CommandText = "update login set flag='Open'  where Username = '" + emplist2.SelectedItem.Text + "'";
                            c.cmd.ExecuteNonQuery();
                            MessageBox.Show("Account unblocked successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Account does not exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Panel3.Visible = true;
            emplist2.SelectedIndex = 0;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            emplist2.SelectedIndex = 0;
        }

        protected void btnsq_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/securityq3.aspx");
        }
    }
}