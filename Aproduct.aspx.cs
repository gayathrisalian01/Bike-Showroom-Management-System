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
    public partial class Aproduct : System.Web.UI.Page
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
            Panel5.Visible = false;


        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel5.Visible = false;

            try
            {
                c = new connect();
                int count;
                c.cmd.CommandText = "select count(*) from stock";
                count = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
                txtbid.Text = "BK100" + count.ToString();
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

        protected void btnupd_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel5.Visible = false;
            c = new connect();
            ds = new DataSet();
            if (dlistid.Items.Count == 0)
            {
                c.cmd.CommandText = "select (bid) from stock";
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

        protected void btndis_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel5.Visible = true;
            GridView1.Visible = true;
            c = new connect();
            ds = new DataSet();
            if (DropDownList1.Items.Count == 0)
            {
                c.cmd.CommandText = "select (model) from stock";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "ct");
                if (ds.Tables["ct"].Rows.Count > 0)
                {
                    DropDownList1.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["ct"].Rows.Count; i++)
                    {
                        DropDownList1.Items.Add(ds.Tables["ct"].Rows[i].ItemArray[0].ToString());
                    }
                }
            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Panel5.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel1.Visible = false;

            if (namelist3.Items.Count == 0)
            {
                c = new connect();
                ds = new DataSet();
                c.cmd.CommandText = "select bname from stock where status = 'Instock'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "st");
                if (ds.Tables["st"].Rows.Count > 0)
                {
                    namelist3.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["st"].Rows.Count; i++)
                    {
                        namelist3.Items.Add(ds.Tables["st"].Rows[i].ItemArray[0].ToString());
                    }
                }
            }
        }

        protected void btnsave1_Click(object sender, EventArgs e)
        {
            if (txtbid.Text == "" || txtbname.Text == "" || txtcolor.Text == "" || txtmodel.Text == "" || txtprice.Text == "" || txtqty.Text == "" || txtwarranty.Text == "")
            {
                MessageBox.Show("Enter all the fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    c = new connect();
                    c.cmd.CommandText = "select * from stock where bid='" + txtbid.Text + "'";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds, "stk");
                    if (ds.Tables["stk"].Rows.Count > 0)
                    {
                        MessageBox.Show("Record already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        c.cmd.CommandText = "insert into stock values(@bid,@bname,@model,@color,@price,@sqty,@warranty,@status)";
                        c.cmd.Parameters.AddWithValue("@bid", txtbid.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@bname", txtbname.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@model", txtmodel.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@color", txtcolor.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@price", Convert.ToInt64(txtprice.Text));
                        c.cmd.Parameters.AddWithValue("@sqty", Convert.ToInt64(txtqty.Text));
                        c.cmd.Parameters.AddWithValue("@warranty", txtwarranty.Text.ToString());
                        c.cmd.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = "InStock";
                        c.cmd.ExecuteNonQuery();
                        MessageBox.Show("Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtbname.Text = "";
                        txtcolor.Text = "";
                        txtmodel.Text = "";
                        txtprice.Text = "";
                        txtqty.Text = "";
                        txtwarranty.Text = "";
                        dstat.SelectedIndex = 0;

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
            Panel1.Visible = true;
        }

        protected void btnclr1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            txtbname.Text = "";
            txtcolor.Text = "";
            txtmodel.Text = "";
            txtprice.Text = "";
            txtqty.Text = "";
            txtwarranty.Text = "";

        }

        protected void btnback1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            
            txtbname.Text = "";
            txtcolor.Text = "";
            txtmodel.Text = "";
            txtprice.Text = "";
            txtqty.Text = "";
            txtwarranty.Text = "";
        }

        protected void btndis2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            c = new connect();
            ds = new DataSet();
            c.cmd.CommandText = "select * from stock where bid='" + dlistid.SelectedItem + "'";
            if (dlistid.SelectedItem.ToString() != "")
            {
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "bupd");
                if (Convert.ToString(ds.Tables["bupd"].Rows[0].ItemArray[7]) != "")
                {
                    txtname2.Text = Convert.ToString(ds.Tables["bupd"].Rows[0].ItemArray[1]);
                    txtmodel2.Text = Convert.ToString(ds.Tables["bupd"].Rows[0].ItemArray[2]);
                    txtcolor2.Text = Convert.ToString(ds.Tables["bupd"].Rows[0].ItemArray[3]);
                    txtprice2.Text = Convert.ToString(ds.Tables["bupd"].Rows[0].ItemArray[4]);
                    txtqty2.Text = Convert.ToString(ds.Tables["bupd"].Rows[0].ItemArray[5]);
                    txtwarranty2.Text = Convert.ToString(ds.Tables["bupd"].Rows[0].ItemArray[6]);
                    txtstat.Text = Convert.ToString(ds.Tables["bupd"].Rows[0].ItemArray[7]);
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
            if (txtname2.Text != "" && txtmodel2.Text != "" && txtcolor2.Text != "" && txtprice2.Text != "" && txtqty2.Text != "" && txtwarranty2.Text != "" && txtstat.Text != "")
            {
                c.cmd.CommandText = "update stock set bname=@bname where bid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@bname", SqlDbType.NVarChar).Value = txtname2.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update stock set model=@model where bid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@model", SqlDbType.NVarChar).Value = txtmodel2.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update stock set color=@color where bid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@color", SqlDbType.NVarChar).Value = txtcolor2.Text;
                c.cmd.ExecuteNonQuery();



                c.cmd.CommandText = "update stock set bprice=@bprice where bid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@bprice", SqlDbType.NVarChar).Value = txtprice2.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update stock set bname=@qty where bid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@qty", SqlDbType.NVarChar).Value = txtqty2.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update stock set warranty=@warranty where bid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@warranty", SqlDbType.NVarChar).Value = txtwarranty2.Text;
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "update stock set status=@status where bid='" + dlistid.SelectedItem.ToString() + "'";
                c.cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = txtstat.Text;
                c.cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Enter all the fields", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtname2.Text = "";
            txtmodel2.Text = "";
            txtcolor2.Text = "";
            txtprice2.Text = "";
            txtqty2.Text = "";
            txtwarranty2.Text = "";
            txtstat.Text = "";
            dlistid.SelectedIndex = 0;
        }

        protected void btnclr2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            txtname2.Text = "";
            txtmodel2.Text = "";
            txtcolor2.Text = "";
            txtprice2.Text = "";
            txtqty2.Text = "";
            txtwarranty2.Text = "";
            txtstat.Text = "";
            dlistid.SelectedIndex = 0;
        }

        protected void btncl2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            txtname2.Text = "";
            txtmodel2.Text = "";
            txtcolor2.Text = "";
            txtprice2.Text = "";
            txtqty2.Text = "";
            txtwarranty2.Text = "";
            txtstat.Text = "";
            dlistid.SelectedIndex = 0;
        }





        protected void btncl3_Click(object sender, EventArgs e)
        {

            Panel3.Visible = false;
            txtbid3.Text = "";
            namelist3.SelectedIndex = 0;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            try
            {
                c = new connect();
                c.cmd.CommandText = "select * from stock where bname='" + namelist3.SelectedItem.Text + "'and bid='" + txtbid3.Text + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "del");
                if (ds.Tables["del"].Rows.Count > 0)
                {
                    c.cmd.CommandText = "update stock set status=@st where bname = '" + namelist3.SelectedItem.Text + "'";
                    c.cmd.Parameters.Add("@st", SqlDbType.NVarChar).Value = "Outdated";
                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("Record set to outdated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No Record ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtbid3.Text = "";
            namelist3.SelectedIndex = 0;
        }

        protected void btndis3_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            c = new connect();
            ds = new DataSet();
            c.cmd.CommandText = "select bid from stock where bname='" + namelist3.SelectedItem + "'";
            if (namelist3.SelectedItem.ToString() != "")
            {
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "dis");
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtbid3.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("Error", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a bike name", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected void btnsearch5_Click(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            try
            {
                GridView1.Visible = false;
                GridView2.Visible = true;
                c = new connect();
                c.cmd.CommandText = "select * from stock where bname='" + DropDownList1.SelectedItem.Text + "'";
                ds = new DataSet();
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "stk");
                if (ds.Tables["stk"].Rows.Count > 0)
                {
                    GridView2.DataSource = ds.Tables["stk"];
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

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ahome.aspx");
        }

        protected void btnclose5_Click(object sender, EventArgs e)
        {
            Panel5.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
            DropDownList1.SelectedIndex = 0;
        }
    }
}