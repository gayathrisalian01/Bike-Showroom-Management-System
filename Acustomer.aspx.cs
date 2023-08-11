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
    public partial class Acustomer : System.Web.UI.Page
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

        protected void btnadd4_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;

            try
            {
                c = new connect();
                int count;
                c.cmd.CommandText = "select count(*) from customer1";
                count = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
                txtcid1.Text = "CUST10" + count.ToString();
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

        protected void btnupd4_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            if (dlistcid.Items.Count == 0)
            {
                c = new connect();
                ds = new DataSet();
                c.cmd.CommandText = "select (cid) from customer1";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "cut");
                if (ds.Tables["cut"].Rows.Count > 0)
                {
                    dlistcid.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["cut"].Rows.Count; i++)
                    {
                        dlistcid.Items.Add(ds.Tables["cut"].Rows[i].ItemArray[0].ToString());
                    }
                }
            }


        }

        protected void btndis4_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = true;

            if (dlistcust.Items.Count == 0)
            {
                c = new connect();
                ds = new DataSet();
                c.cmd.CommandText = "select (custname) from customer1";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "ct");
                if (ds.Tables["ct"].Rows.Count > 0)
                {
                    dlistcust.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["ct"].Rows.Count; i++)
                    {
                        dlistcust.Items.Add(ds.Tables["ct"].Rows[i].ItemArray[0].ToString());
                    }
                }
            }

        }


        protected void btnclr1_Click(object sender, EventArgs e)
        {
            try
            {
                c = new connect();
                int count;
                c.cmd.CommandText = "select count(*) from customer1";
                count = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
                txtcid1.Text = "CUST10" + count.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                c.con.Close();
            }
            txtcname1.Text = "";
            txtcadd1.Text = "";
            txtcphone1.Text = "";
            txtcmail1.Text = "";
            txtreg1.Text = "";
            txtreg1.Text = "";
            Panel1.Visible = true;

        }

        protected void btnback1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void btnsave1_Click(object sender, EventArgs e)
        {
            if (txtcadd1.Text == "" || txtcid1.Text == "" || txtcmail1.Text == "" || txtcname1.Text == "" || txtcphone1.Text == "")
            {
                MessageBox.Show("Enter all the fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Panel1.Visible = true;
            }
            else
            {
                try
                {
                    c = new connect();
                    c.cmd.CommandText = "select * from customer1 where cid='" + txtcid1.Text + "'";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds, "cust");
                    if (ds.Tables["cust"].Rows.Count > 0)
                    {
                        MessageBox.Show("Record already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        c.cmd.CommandText = "insert into customer1 values(@cid,@custname,@custadd,@cphone,@cmail,@reg_no)";
                        c.cmd.Parameters.AddWithValue("@cid", txtcid1.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@custname", txtcname1.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@custadd", txtcadd1.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@cphone", Convert.ToInt64(txtcphone1.Text));
                        c.cmd.Parameters.AddWithValue("@cmail", txtcmail1.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@reg_no", txtreg1.Text.ToString());
                        c.cmd.ExecuteNonQuery();
                        MessageBox.Show("Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcname1.Text = "";
                        txtcadd1.Text = "";
                        txtcphone1.Text = "";
                        txtcmail1.Text = "";
                        txtreg1.Text = "";
                        Panel1.Visible = true;
                        try
                        {
                            c = new connect();
                            int count;
                            c.cmd.CommandText = "select count(*) from customer1";
                            count = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
                            txtcid1.Text = "CUST10" + count.ToString();
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

        protected void btnclr2_Click(object sender, EventArgs e)
        {
            txtcmail2.Text = "";
            txtcname2.Text = "";
            txtcadd2.Text = "";
            txtcphone2.Text = "";
            txtreg2.Text = "";
            dlistcid.SelectedIndex = 0;
            Panel2.Visible = true;
        }

        protected void btndis2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            c = new connect();
            ds = new DataSet();
            c.cmd.CommandText = "select * from customer1 where cid='" + dlistcid.SelectedItem + "'";
            if (dlistcid.SelectedItem.ToString() != "")
            {
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "cupd");
                if (Convert.ToString(ds.Tables["cupd"].Rows[0].ItemArray[5]) != "")
                {
                    txtcname2.Text = Convert.ToString(ds.Tables["cupd"].Rows[0].ItemArray[1]);
                    txtcadd2.Text = Convert.ToString(ds.Tables["cupd"].Rows[0].ItemArray[2]);
                    txtcphone2.Text = Convert.ToString(ds.Tables["cupd"].Rows[0].ItemArray[3]);
                    txtcmail2.Text = Convert.ToString(ds.Tables["cupd"].Rows[0].ItemArray[4]);
                    txtreg2.Text = Convert.ToString(ds.Tables["cupd"].Rows[0].ItemArray[5]);
                    c.cmd.ExecuteNonQuery();

                }
            }
            else
            {
                MessageBox.Show("Please select an ID", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected void btnupd2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;


            c = new connect();
            ds = new DataSet();
            if (txtcname2.Text != "" && txtcadd2.Text != "" && txtcphone2.Text != "" && txtcmail2.Text != "")
            {
                c.cmd.CommandText = "update customer1 set custname=@custname where cid='" + dlistcid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@custname", SqlDbType.NVarChar).Value = txtcname2.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update customer1 set custadd=@custadd where cid='" + dlistcid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@custadd", SqlDbType.NVarChar).Value = txtcadd2.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update customer1 set cphone=@cphone where cid='" + dlistcid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@cphone", SqlDbType.NVarChar).Value = txtcphone2.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update customer1 set cmail=@cmail where cid='" + dlistcid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@cmail", SqlDbType.NVarChar).Value = txtcmail2.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update customer1 set reg_no=@reg_no where cid='" + dlistcid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@reg_no", SqlDbType.NVarChar).Value = txtreg2.Text;
                c.cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Enter all the fields", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtcmail2.Text = "";
            txtcname2.Text = "";
            txtcadd2.Text = "";
            txtcphone2.Text = "";
            txtreg2.Text = "";
            dlistcid.SelectedIndex = 0;
            Panel2.Visible = true;
        }

        protected void btnback2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            txtcmail2.Text = "";
            txtcname2.Text = "";
            txtcadd2.Text = "";
            txtcphone2.Text = "";
            txtreg2.Text = "";
            dlistcid.SelectedIndex = 0;
        }

        protected void btnclose3_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            dlistcust.SelectedIndex = 0;
            GridView1.Visible = false;
            GridView2.Visible = false;
        }

        protected void btndis3_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            try
            {
                GridView2.Visible = false;
                GridView1.Visible = true;
                c = new connect();
                c.cmd.CommandText = "select * from customer1 where custname='" + dlistcust.SelectedItem.Text + "'";
                ds = new DataSet();
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "cust");
                if (ds.Tables["cust"].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables["cust"];
                    GridView1.DataBind();
                }
                else
                {
                    MessageBox.Show("No record found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        protected void btnback4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ahome.aspx");
        }
    }
}