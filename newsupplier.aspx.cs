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
    public partial class newsupplier : System.Web.UI.Page
    {
        connect c;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //int r = 0;
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel4.Visible = false;
                Panel5.Visible = false;
            }
            
           

        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;

            try
            {
                c = new connect();
                int count;
                c.cmd.CommandText = "select count(*) from supplier";
                count = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
                txtsid.Text = "SU10" + count.ToString();
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

        protected void btndel_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = false;

            if (namelist.Items.Count == 0)
            {
                c = new connect();
                ds = new DataSet();
                c.cmd.CommandText = "select (sname) from supplier where status='Active'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "su1");
                if (ds.Tables["su1"].Rows.Count > 0)
                {
                    namelist.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["su1"].Rows.Count; i++)
                    {
                        namelist.Items.Add(ds.Tables["su1"].Rows[i].ItemArray[0].ToString());
                    }
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtsid.Text == "" || txtsname.Text == "" || txtaddress.Text == "" || txtphone.Text == "" || txtemail.Text == "" || txtbank.Text == "" || txtaccno.Text == "" || txtifcs.Text == "" || txtbranch.Text == "")
            {

                MessageBox.Show("Enter all the fields", "Message",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtphone.Text.Length > 10 || txtphone.Text.Length < 10)
            {
                MessageBox.Show("Incorrect Phone number value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    c = new connect();
                    c.cmd.CommandText = "select * from supplier where sid='" + txtsid.Text + "'";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds, "chk");
                    if (ds.Tables["chk"].Rows.Count > 0)
                    {
                        MessageBox.Show("Record already exists", "Message",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        c.cmd.CommandText = "insert into supplier values(@sid,@sname,@sadd,@spno,@semail,@bank,@accno,@ifcs,@branch,@status)";
                        c.cmd.Parameters.AddWithValue("@sid", txtsid.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@sname", txtsname.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@sadd", txtaddress.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@spno", Convert.ToInt64(txtphone.Text));
                        c.cmd.Parameters.AddWithValue("@semail", txtemail.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@bank", txtbank.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@accno", Convert.ToInt64(txtaccno.Text));
                        c.cmd.Parameters.AddWithValue("@ifcs",txtifcs.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@branch",txtbranch.Text.ToString());
                        c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Active";

                        c.cmd.ExecuteNonQuery();
                        MessageBox.Show("Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        txtsname.Text = "";
                        txtaddress.Text = "";
                        txtbank.Text = "";
                        txtphone.Text = "";
                        txtemail.Text = "";
                        txtaccno.Text = "";
                        txtifcs.Text = "";
                        txtbranch.Text = "";
                        ddlst.SelectedIndex = 0;
                        try
                        {
                            c = new connect();
                            int count;
                            c.cmd.CommandText = "select count(*) from supplier";
                            count = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
                            txtsid.Text = "SU10" + count.ToString();
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            txtsname.Text = "";
            txtaddress.Text = "";
            txtbank.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
            txtaccno.Text = "";
            txtifcs.Text = "";
            txtbranch.Text = "";
            ddlst.SelectedIndex = 0;
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ehome.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            namelist.SelectedIndex = 0;
            txtid.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            
            txtsname.Text = "";
            txtaddress.Text = "";
            txtbank.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
            txtaccno.Text = "";
            txtifcs.Text = "";
            txtbranch.Text = "";
            ddlst.SelectedIndex=0;

        }
        

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                c = new connect();
                c.cmd.CommandText = "select * from supplier where sname='" +namelist.SelectedItem.Text + "'and sid='" + txtid.Text + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "del");
                if (ds.Tables["del"].Rows.Count > 0)
                {
                    c.cmd.CommandText = "update supplier set status=@st where sname='" + namelist.SelectedItem.Text +"'";
                    c.cmd.Parameters.Add("@st", SqlDbType.VarChar).Value = "Inactive";
                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("Record set to inactive", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                c.con.Close();
            }
            txtid.Text = "";
            namelist.SelectedIndex = 0;
        }

        protected void btndis_Click1(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel4.Visible = true;
            Panel2.Visible = false;
            Panel5.Visible = false;
            GridView1.Visible = true;
            GridView2.Visible = false;

            if (DropDownList1.Items.Count == 0)
            {
                c = new connect();
                ds = new DataSet();
                c.cmd.CommandText = "select (sname) from supplier";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "su");
                if (ds.Tables["su"].Rows.Count > 0)
                {
                    DropDownList1.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["su"].Rows.Count; i++)
                    {
                        DropDownList1.Items.Add(ds.Tables["su"].Rows[i].ItemArray[0].ToString());
                    }
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Panel4.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
            DropDownList1.SelectedIndex = 0;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView2.Visible = true;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel5.Visible = true;
            Panel2.Visible = false;
            Panel4.Visible = false;

            c = new connect();
            ds = new DataSet();
            if (dlistid.Items.Count == 0)
            {
                c.cmd.CommandText = "select (sid) from supplier";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "ct");
                if (ds.Tables["ct"].Rows.Count > 0)
                {
                    dlistid.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["ct"].Rows.Count; i++)
                    {
                        dlistid.Items.Add(ds.Tables["ct"].Rows[i].ItemArray[0].ToString());
                    }
                }
            }
        }

        protected void btncl5_Click(object sender, EventArgs e)
        {
            Panel5.Visible = false;
            txtsname5.Text = "";
            txtadd5.Text = "";
            txtbname5.Text = "";
            txtbranch5.Text = "";
            txtcode5.Text = "";
            txtmail5.Text = "";
            txtpno5.Text = "";
            txtstat5.Text = "";
            txtacc5.Text = "";
            dlistid.SelectedIndex = 0;
        }

        protected void btnclr5_Click(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            txtsname5.Text = "";
            txtadd5.Text = "";
            txtbname5.Text = "";
            txtbranch5.Text = "";
            txtcode5.Text = "";
            txtmail5.Text = "";
            txtpno5.Text = "";
            txtstat5.Text = "";
            txtacc5.Text = "";
            dlistid.SelectedIndex = 0;


        }

        protected void btndis5_Click(object sender, EventArgs e)
        {

            Panel5.Visible = true;
            c = new connect();
            ds = new DataSet();
            c.cmd.CommandText = "select * from supplier where sid='" + dlistid.SelectedItem + "'";
            if (dlistid.SelectedItem.ToString() != "")
            {
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "supd");
                if (Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[9]) != "")
                {
                    txtsname5.Text = Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[1]);
                    txtadd5.Text = Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[2]);
                    txtpno5.Text = Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[3]);
                    txtmail5.Text = Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[4]);
                    txtbname5.Text = Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[5]);
                    txtacc5.Text = Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[6]);
                    txtcode5.Text = Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[7]);
                    txtbranch5.Text = Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[8]);
                    txtstat5.Text = Convert.ToString(ds.Tables["supd"].Rows[0].ItemArray[9]);
                    c.cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please select an ID", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        protected void btnupd5_Click(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            c = new connect();
            ds = new DataSet();

            if (txtsname5.Text != "" && txtadd5.Text != "" && txtpno5.Text != "" && txtmail5.Text != "" && txtbname5.Text != "" && txtacc5.Text != ""&&txtcode5.Text!=""&&txtbranch5.Text!=""&&txtstat5.Text!="")
            {
                c.cmd.CommandText = "update supplier set sname=@sname where sid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@sname", SqlDbType.NVarChar).Value = txtsname5.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update supplier set sadd=@sadd where sid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@sadd", SqlDbType.NVarChar).Value =txtadd5.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update supplier set spno=@spno where sid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@spno", SqlDbType.NVarChar).Value = txtpno5.Text ;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update supplier set semail=@semail where sid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@semail", SqlDbType.NVarChar).Value = txtmail5.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update supplier set bank=@bank where sid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@bank", SqlDbType.NVarChar).Value = txtbname5.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update supplier set accno=@accno where sid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@accno", SqlDbType.NVarChar).Value = txtacc5.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update supplier set ifsc=@ifsc where sid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@ifsc", SqlDbType.NVarChar).Value = txtcode5.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update supplier set branch=@branch where sid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@branch", SqlDbType.NVarChar).Value =txtbranch5.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update supplier set status=@status where sid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = txtstat5.Text;
                c.cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsname5.Text = "";
                txtadd5.Text = "";
                txtbname5.Text = "";
                txtbranch5.Text = "";
                txtcode5.Text = "";
                txtmail5.Text = "";
                txtpno5.Text = "";
                txtstat5.Text = "";
                txtacc5.Text = "";
                dlistid.SelectedIndex = 0;
                

            }
            else
            {
                MessageBox.Show("Enter all the fields", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            c = new connect();
            ds = new DataSet();
            c.cmd.CommandText = "select sid from supplier where sname='" + namelist.SelectedItem + "'";
            if(namelist.SelectedItem.ToString()!="")
            {
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "dis");
                adp.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    txtid.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("Error", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an supplier name", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Panel4.Visible = true;
            try
            {
                GridView1.Visible = false;
                GridView2.Visible = true;
                c = new connect();
                c.cmd.CommandText = "select * from supplier where sname='" + DropDownList1.SelectedItem.Text + "'";
                ds = new DataSet();
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "sp");
                if (ds.Tables["sp"].Rows.Count > 0)
                {
                    GridView2.DataSource = ds.Tables["sp"];
                    GridView2.DataBind();
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

        
    }
}