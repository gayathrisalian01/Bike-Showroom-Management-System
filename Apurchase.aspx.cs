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
    public partial class Apurchase : System.Web.UI.Page
    {
        connect c;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataSet ds1;
        decimal tp, gt, p;
        int q;

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Label7.Visible = false;

            Label23.Visible = false;

            txtwarranty.Visible = false;
            txtbname.Visible = false;
            btnok.Visible = false;

            c = new connect();
            ds = new DataSet();
            try
            {
                if (dlistsname.Items.Count == 0)
                {
                    c.cmd.CommandText = "select (sname) from supplier where status='Active'";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds, "sup");
                    if (ds.Tables["sup"].Rows.Count > 0)
                    {
                        dlistsname.Items.Add("--Select--");
                        for (int i = 0; i < ds.Tables["sup"].Rows.Count; i++)
                        {
                            dlistsname.Items.Add(ds.Tables["sup"].Rows[i].ItemArray[0].ToString());
                        }
                    }
                }



                if (!IsPostBack)
                {
                    Calendar1.Visible = false;

                }
                lbldate.Text = DateTime.Now.ToShortDateString();

                if ((String)Session["nextpur"] == "yes")
                {

                    txtpo.Text = (String)Session["purno"];
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
            txtbillno2.Enabled = false;
            txtdate2.Enabled = false;
            txtodate2.Enabled = false;
            txtsid.Enabled = false;
            txtsname.Enabled = false;

            txtdate2.Text = DateTime.Now.ToShortDateString();


        }
        protected void btnpurorder_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;

            c = new connect();
            ds = new DataSet();

            int count1;
            c.cmd.CommandText = "select count(*) from purorder";
            count1 = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
            lblpid.Text = count1.ToString();


            try
            {
                if (dlistsname.Items.Count == 0)
                {
                    c.cmd.CommandText = "select (sname) from supplier where status='Active'";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds, "sup");
                    if (ds.Tables["sup"].Rows.Count > 0)
                    {
                        dlistsname.Items.Add("--Select--");
                        for (int i = 0; i < ds.Tables["sup"].Rows.Count; i++)
                        {
                            dlistsname.Items.Add(ds.Tables["sup"].Rows[i].ItemArray[0].ToString());
                        }
                    }
                }
                if (dlistmodel.Items.Count == 0)
                {
                    c.cmd.CommandText = "select distinct(model) from stock ";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds, "sup1");
                    if (ds.Tables["sup1"].Rows.Count > 0)
                    {
                        dlistmodel.Items.Add("--Select--");
                        for (int i = 0; i < ds.Tables["sup1"].Rows.Count; i++)
                        {
                            dlistmodel.Items.Add(ds.Tables["sup1"].Rows[i].ItemArray[0].ToString());
                        }
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

            c.cmd.CommandText = "select max(pur_no) from purorder";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "pur");
            if (Convert.ToString(ds.Tables["pur"].Rows[0].ItemArray[0]) == "")
            {
                txtpo.Text = "P100";

            }
            else
            {
                if (ds.Tables["pur"].Rows.Count > 0)
                {
                    string s1 = Convert.ToString(ds.Tables["pur"].Rows[0].ItemArray[0]);
                    int n = Convert.ToInt16(s1.Length.ToString());
                    s1 = s1.Substring(1, n - 1);
                    int m = 1 + Convert.ToInt16(s1);
                    txtpo.Text = "P" + m.ToString();
                }
            }
        }

        protected void btnpurbill_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;

            c = new connect();
            ds = new DataSet();
            ds1 = new DataSet();

            int count;
            c.cmd.CommandText = "select count(*) from purbill";
            count = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
            txtbillno2.Text = "B10" + count.ToString();


            try
            {
                if (dlistono.Items.Count == 0)
                {
                    c.cmd.CommandText = "select distinct(pur_no) from purorder where status = 'incomplete'";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds, "pur");
                    if (ds.Tables["pur"].Rows.Count > 0)
                    {
                        dlistono.Items.Add("--Select--");
                        for (int i = 0; i < ds.Tables["pur"].Rows.Count; i++)
                        {
                            dlistono.Items.Add(ds.Tables["pur"].Rows[i].ItemArray[0].ToString());
                        }
                    }
                    else
                    {
                        dlistono.Items.Add("--Select--");
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

        protected void btnsave1_Click(object sender, EventArgs e)
        {

            try
            {
                c = new connect();
                c.cmd.CommandText = "insert into purorder values(@p_id,@pur_no,@sup_name,@sup_id,@item_id,@item_name,@quantity,@color,@or_date,@due_date,@status,@price)";
                c.cmd.Parameters.Clear();
                if (txtbid.Text != "" && dlistmodel.SelectedIndex.ToString() != "" && txtcolor.Text != "" && txtddate.Text != "" && txtodate.Text != "" && txtpo.Text != "" && txtprice.Text != "" && txtqty.Text != "" && txtid.Text != "")
                {
                    c.cmd.Parameters.Add("@p_id", SqlDbType.NVarChar).Value = lblpid.Text;
                    c.cmd.Parameters.Add("@pur_no", SqlDbType.NVarChar).Value = txtpo.Text;
                    c.cmd.Parameters.Add("@sup_name", SqlDbType.NVarChar).Value = dlistsname.SelectedItem.ToString();
                    c.cmd.Parameters.Add("@sup_id", SqlDbType.NVarChar).Value = txtid.Text;
                    c.cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = txtbid.Text;
                    c.cmd.Parameters.Add("@item_name", SqlDbType.NVarChar).Value = dlistmodel.SelectedItem.ToString();
                    c.cmd.Parameters.Add("@quantity", SqlDbType.SmallInt).Value = Convert.ToInt16(txtqty.Text);
                    c.cmd.Parameters.Add("@color", SqlDbType.NVarChar).Value = txtcolor.Text;
                    c.cmd.Parameters.Add("@or_date", SqlDbType.DateTime).Value = lbldate.Text;
                    c.cmd.Parameters.Add("@due_date", SqlDbType.DateTime).Value = txtddate.Text;
                    c.cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = "incomplete";
                    c.cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(txtprice.Text);
                    c.cmd.ExecuteNonQuery();

                    Session["purno"] = txtpo.Text;
                    Session["sname"] = dlistsname.SelectedItem.Text;
                    Session["sid"] = txtid.Text;
                    Session["itid"] = txtbid.Text;
                    Session["itname"] = dlistmodel.SelectedItem.Text;
                    Session["qty"] = txtqty.Text;
                    Session["clr"] = txtcolor.Text;
                    Session["odate"] = lbldate.Text;
                    Session["dudate"] = txtddate.Text;
                    Session["price"] = txtprice.Text;
                    Session["nextpur"] = "no";


                }

                else
                {
                    MessageBox.Show("Enter all fields", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            try
            {

                c = new connect();
                c.cmd.CommandText = "update stock set @sqty=@sqty where bid='" + txtbid.Text + "'";
                c.cmd.Parameters.Add("@sqty", SqlDbType.SmallInt).Value = Convert.ToInt16(txtqty.Text);
                c.cmd.ExecuteNonQuery();

                String title = "Matrix Auto Ventures";
                MessageBoxButtons button = MessageBoxButtons.YesNo;
                String message = "Add stock";
                DialogResult result = MessageBox.Show(message, title, button);
                if (result == DialogResult.Yes)
                {
                    Session["nextpur"] = "yes";


                    Panel1.Visible = true;
                    MessageBox.Show("Submitted");
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
            txtbid.Text = "";
            txtcolor.Text = "";
            txtddate.Text = "";
            txtid.Text = "";
            dlistmodel.SelectedIndex = 0;
            dlistsname.SelectedIndex = 0;
            txtodate.Text = "";
            txtpo.Text = "";
            txtprice.Text = "";
            txtqty.Text = "";
            c = new connect();
            int count1;
            c.cmd.CommandText = "select count(*) from purorder";
            count1 = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
            lblpid.Text = count1.ToString();
        }

        protected void dlistsname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                c = new connect();
                ds = new DataSet();
                c.cmd.CommandText = "select * from supplier where sname='" + dlistsname.SelectedItem + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "sup");
                if ((dlistsname.SelectedIndex) != 0)
                {
                    txtid.Text = Convert.ToString(ds.Tables["sup"].Rows[0].ItemArray[0]);
                    c.cmd.ExecuteNonQuery();

                }
                else
                {
                    MessageBox.Show("Please select supplier name", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;

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
            c = new connect();
            ds = new DataSet();
            Panel1.Visible = true;


            c.cmd.CommandText = "select max(pur_no) from purorder";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "pur");
            if (Convert.ToString(ds.Tables["pur"].Rows[0].ItemArray[0]) == "")
            {
                txtpo.Text = "P100";

            }
            else
            {
                if (ds.Tables["pur"].Rows.Count > 0)
                {
                    string s1 = Convert.ToString(ds.Tables["pur"].Rows[0].ItemArray[0]);
                    int n = Convert.ToInt16(s1.Length.ToString());
                    s1 = s1.Substring(1, n - 1);
                    int m = 1 + Convert.ToInt16(s1);
                    txtpo.Text = "P" + m.ToString();
                }
            }
            c.cmd.CommandText = "select * from supplier where sname='" + dlistsname.SelectedItem + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "sup");
            if ((dlistsname.SelectedIndex) != 0)
            {
                txtid.Text = Convert.ToString(ds.Tables["sup"].Rows[0].ItemArray[0]);
                c.cmd.ExecuteNonQuery();

            }
            int count2;
            c.cmd.CommandText = "select count(*) from stock";
            count2 = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
            txtbid.Text = "BK100" + count2.ToString();

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = Convert.ToDateTime(Calendar1.SelectedDate.ToString());
            DateTime dt3 = DateTime.Now.AddDays(15);
            if (dt2 <= dt1)
            {
                MessageBox.Show("We can't select date");
            }
            else if (dt2 > dt3)
            {
                MessageBox.Show("Due date must be within 15 days");

            }
            else
            {
                txtddate.Text = Calendar1.SelectedDate.ToShortDateString();
            }
            if (txtddate.Text == "")
            {
                Calendar1.Visible = true;
            }
            else
            {
                Calendar1.Visible = false;
            }
            txtodate.Text = DateTime.Now.ToShortDateString();
        }

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
            Panel1.Visible = true;
        }

        protected void txtddate_TextChanged(object sender, EventArgs e)
        {
            Calendar1.Visible = false;
        }

        protected void btndis1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            try
            {
                dispgrid.Visible = true;
                c = new connect();
                c.cmd.CommandText = "select * from purorder";
                ds = new DataSet();
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "pur");
                if (ds.Tables["pur"].Rows.Count > 0)
                {
                    dispgrid.DataSource = ds.Tables["pur"];
                    dispgrid.DataBind();
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

        protected void btnclr1_Click(object sender, EventArgs e)
        {
            txtbid.Text = "";
            txtcolor.Text = "";
            txtddate.Text = "";
            txtid.Text = "";
            dlistmodel.SelectedIndex = 0;
            dlistsname.SelectedIndex = 0;
            txtodate.Text = "";
            txtpo.Text = "";
            txtprice.Text = "";
            txtqty.Text = "";
            dispgrid.Visible = false;
            Panel1.Visible = true;
        }

        protected void btndis2_Click(object sender, EventArgs e)
        {
            c = new connect();
            ds = new DataSet();
            c.cmd.CommandText = "select * from purorder where pur_no = '" + dlistono.SelectedItem.ToString() + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "pur");
            if (ds.Tables["pur"].Rows.Count > 0)
            {
                txtodate2.Text = Convert.ToString(ds.Tables["pur"].Rows[0].ItemArray[9]);
                txtsid.Text = Convert.ToString(ds.Tables["pur"].Rows[0].ItemArray[3]);
                txtsname.Text = Convert.ToString(ds.Tables["pur"].Rows[0].ItemArray[2]);

            }
            else
            {

                MessageBox.Show("No record", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            c.cmd.CommandText = "select * from purorder where pur_no = '" + dlistono.SelectedItem.ToString() + "'and item_id = '" + dlistbid.SelectedItem.ToString() + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "pur1");
            if (ds.Tables["pur1"].Rows.Count > 0)
            {
                txt2.Text = Convert.ToString(ds.Tables["pur1"].Rows[0].ItemArray[5]);
                txt3.Text = Convert.ToString(ds.Tables["pur1"].Rows[0].ItemArray[6]);
                txt4.Text = Convert.ToString(ds.Tables["pur1"].Rows[0].ItemArray[7]);
                txt5.Text = Convert.ToString(ds.Tables["pur1"].Rows[0].ItemArray[11]);
            }
            q = Convert.ToInt32(txt3.Text);
            p = Convert.ToDecimal(txt5.Text);
            tp = Convert.ToDecimal(q * p);
            txt6.Text = Convert.ToString(tp);
            gt = Convert.ToDecimal(txttotal.Text + txt6.Text);
            txttotal.Text = Convert.ToString(gt);
            Panel2.Visible = true;
        }

        protected void btngen_Click(object sender, EventArgs e)
        {
            c = new connect();
            ds1 = new DataSet();
            Panel2.Visible = true;
            if (dlistono.SelectedIndex != 0)
            {
                if (dlistbid.Items.Count == 0)
                {
                    c.cmd.CommandText = "select item_id from purorder where pur_no= '" + dlistono.SelectedItem.Text + "'and status = 'incomplete'";
                    adp.SelectCommand = c.cmd;
                    adp.Fill(ds1, "pur1");
                    if (ds1.Tables["pur1"].Rows.Count > 0)
                    {
                        dlistbid.Items.Add("--Select--");
                        for (int i = 0; i < ds1.Tables["pur1"].Rows.Count; i++)
                        {

                            dlistbid.Items.Add(ds1.Tables["pur1"].Rows[i].ItemArray[0].ToString());
                        }
                    }
                    else
                    {
                        dlistbid.Items.Add("--Select--");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select order number!!", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected void btnback2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txtodate2.Text = "";
            txtsid.Text = "";
            txtsname.Text = "";
            txttotal.Text = "";
            dlistbid.SelectedIndex = 0;
            dlistono.SelectedIndex = 0;

        }

        protected void btnclr2_Click(object sender, EventArgs e)
        {
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txtodate2.Text = "";
            txtsid.Text = "";
            txtsname.Text = "";
            txttotal.Text = "";
            dlistbid.SelectedIndex = 0;
            dlistono.SelectedIndex = 0;
            Panel2.Visible = true;
        }

        protected void btnsub2_Click(object sender, EventArgs e)
        {
            c = new connect();
            ds = new DataSet();
            int qty3, qty4;
            Label7.Visible = false;
            Label23.Visible = false;
            txtwarranty.Visible = false;
            txtbname.Visible = false;
            btnok.Visible = false;
            c.cmd.CommandText = "insert into purbill values(@bill_no, @bill_date, @pur_no, @or_date, @sid, @sname, @item_id,@item_name,@color, @quantity, @price, @totol, @gtotol)";
            c.cmd.Parameters.Clear();

            if (txtodate2.Text != "" && txtsid.Text != "" && txtsname.Text != "" && txttotal.Text != "" && txtbillno2.Text != "" && txt6.Text != "" && txt5.Text != "" && txt4.Text != "" && txt3.Text != "" && txt2.Text != "" )
            {
                c.cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar).Value = txtbillno2.Text;
                c.cmd.Parameters.Add("@bill_date", SqlDbType.DateTime).Value = txtdate2.Text;
                c.cmd.Parameters.Add("@pur_no", SqlDbType.NVarChar).Value = dlistono.SelectedItem.ToString();
                c.cmd.Parameters.Add("@or_date", SqlDbType.DateTime).Value = txtodate2.Text;
                c.cmd.Parameters.Add("@sid", SqlDbType.NVarChar).Value = txtsid.Text;
                c.cmd.Parameters.Add("@sname", SqlDbType.NVarChar).Value = txtsname.Text;
                c.cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = dlistbid.SelectedItem.ToString();
                c.cmd.Parameters.Add("@item_name", SqlDbType.NVarChar).Value = txt2.Text;
                c.cmd.Parameters.Add("@color", SqlDbType.NVarChar).Value = txt4.Text;
                c.cmd.Parameters.Add("@quantity", SqlDbType.SmallInt).Value = Convert.ToInt16(txt3.Text);
                c.cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(txt5.Text);
                c.cmd.Parameters.Add("@totol", SqlDbType.Decimal).Value = txt6.Text;
                c.cmd.Parameters.Add("@gtotol", SqlDbType.Decimal).Value = Convert.ToDecimal(txttotal.Text);
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "select status from purorder where item_id = '" + dlistbid.SelectedItem.ToString() + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "pur");
                if (ds.Tables["pur"].Rows.Count > 0)
                {
                    c.cmd.CommandText = "update purorder set status = @status where item_id = '" + dlistbid.SelectedItem.ToString() + "'";
                    c.cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = "completed";
                    c.cmd.ExecuteNonQuery();
                }

                c.cmd.CommandText = "select sqty from stock where bprice= '" + txt5.Text + "' and color = '" + txt4.Text + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "stk2");
                if (ds.Tables["stk2"].Rows.Count > 0)
                {
                    qty3 = Convert.ToInt32(ds.Tables["stk2"].Rows[0].ItemArray[0]);
                    qty4 = qty3 + Convert.ToInt32(txt3.Text);
                    c.cmd.CommandText = "update stock set sqty=@sqty where bprice= '" + txt5.Text + "' and color = '" + txt4.Text + "'";
                    c.cmd.Parameters.Add("@sqty", SqlDbType.BigInt).Value = Convert.ToInt32(qty4);
                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock updated", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    
                    txt2.Text = "";
                    txt3.Text = "";
                    txt4.Text = "";
                    txt5.Text = "";
                    txt6.Text = "";
                    txtodate2.Text = "";
                    txtsid.Text = "";
                    txtsname.Text = "";
                    txttotal.Text = "";
                    dlistbid.SelectedIndex = 0;
                    dlistono.SelectedIndex = 0;
                    c = new connect();
                    int count1;
                    c.cmd.CommandText = "select count(*) from purbill";
                    count1 = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
                    txtbillno2.Text = "B10" + count1.ToString();

                }
                else
                {

                    Label7.Visible = true;
                    Label23.Visible = true;
                    txtwarranty.Visible = true;
                    txtbname.Visible = true;
                    btnok.Visible = true;
                }

               
            }
            else
            {
                MessageBox.Show("Enter all the fields", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            c = new connect();
            ds = new DataSet();
            c.cmd.CommandText = "select item_id from purorder where pur_no = '" + dlistono.SelectedItem.ToString() + "' and status = 'incomplete'";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "pur");
            if (ds.Tables["pur"].Rows.Count > 0)
            {
                
                txt2.Text = "";
                txt3.Text = "";
                txt4.Text = "";
                txt5.Text = "";
                txt6.Text = "";
                txtbillno2.Text = "";
                txtdate2.Text = "";
                txtodate2.Text = "";
                txtsid.Text = "";
                txtsname.Text = "";
                txttotal.Text = "";
                dlistbid.SelectedIndex = 0;
                dlistono.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Bill is generated", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Panel2.Visible = true;


            if (dlistono.Items.Count == 0)
            {
                c.cmd.CommandText = "select distinct(pur_no) from purorder where status = 'incomplete'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "pur");
                if (ds.Tables["pur"].Rows.Count > 0)
                {
                    dlistono.Items.Add("--Select--");
                    for (int i = 0; i < ds.Tables["pur"].Rows.Count; i++)
                    {
                        dlistono.Items.Add(ds.Tables["pur"].Rows[i].ItemArray[0].ToString());
                    }
                }
                else
                {
                    dlistono.Items.Add("--Select--");
                }
            }

            if (dlistbid.Items.Count == 0)
            {
                c.cmd.CommandText = "select item_id from purorder where pur_no= '" + dlistono.SelectedItem.Text + "'and status = 'incomplete'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds1, "pur1");
                if (ds1.Tables["pur1"].Rows.Count > 0)
                {
                    dlistbid.Items.Add("--Select--");
                    for (int i = 0; i < ds1.Tables["pur1"].Rows.Count; i++)
                    {

                        dlistbid.Items.Add(ds1.Tables["pur1"].Rows[i].ItemArray[0].ToString());
                    }
                }
                else
                {
                    dlistbid.Items.Add("--Select--");
                }
            }
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            c = new connect();
            if (txtodate2.Text != "" && txtsid.Text != "" && txtsname.Text != "" && txttotal.Text != "" && txtbillno2.Text != "" && txt6.Text != "" && txt5.Text != "" && txt4.Text != "" && txt3.Text != "" && txt2.Text != ""  && txtbname.Text != "" && txtwarranty.Text != "")
            {
                c.cmd.CommandText = "insert into stock values(@bid,@bname,@model,@color,@bprice,@sqty,@warranty,@status)";
                c.cmd.Parameters.Add("@bid", SqlDbType.NVarChar).Value = dlistbid.SelectedItem.ToString();
                c.cmd.Parameters.Add("@bname", SqlDbType.NVarChar).Value = txtbname.Text;
                c.cmd.Parameters.Add("@model", SqlDbType.NVarChar).Value = txt2.Text;
                c.cmd.Parameters.Add("@color", SqlDbType.NVarChar).Value = txt4.Text;
                c.cmd.Parameters.Add("@bprice", SqlDbType.BigInt).Value = Convert.ToInt64(txt5.Text);
                c.cmd.Parameters.Add("@sqty", SqlDbType.BigInt).Value = Convert.ToInt64(txt3.Text);
                c.cmd.Parameters.Add("@warranty", SqlDbType.NVarChar).Value = txtwarranty.Text;
                c.cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = "Active";
                c.cmd.ExecuteNonQuery();

                MessageBox.Show("Stock updated", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txtodate2.Text = "";
            txtsid.Text = "";
            txtsname.Text = "";
            txttotal.Text = "";
            dlistbid.SelectedIndex = 0;
            dlistono.SelectedIndex = 0;

            c = new connect();
            int count1;
            c.cmd.CommandText = "select count(*) from purbill";
            count1 = Convert.ToInt16(c.cmd.ExecuteScalar()) + 1;
            txtbillno2.Text = "B10" + count1.ToString();

        }

        protected void btndisplay_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            gd1.Visible = true;
            gd2.Visible = false;

            c = new connect();
            ds = new DataSet();
            if (DropDownList1.Items.Count == 0)
            {
                c.cmd.CommandText = "select (bill_no) from purbill";
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
            c.cmd.CommandText = "select * from purbill";
            ds1 = new DataSet();
            adp.SelectCommand = c.cmd;
            adp.Fill(ds1, "stk1");
            if (ds1.Tables["stk1"].Rows.Count > 0)
            {
                gd1.DataSource = ds1.Tables["stk1"];
                gd1.DataBind();
            }
            else
            {
                MessageBox.Show("No record found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        protected void btnsearch5_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            try
            {
                gd1.Visible = false;
                gd2.Visible = true;
                c = new connect();
                c.cmd.CommandText = "select * from purbill where bill_no='" + DropDownList1.SelectedItem.Text + "'";
                ds = new DataSet();
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "stk");
                if (ds.Tables["stk"].Rows.Count > 0)
                {
                    gd2.DataSource = ds.Tables["stk"];
                    gd2.DataBind();
                }
                else
                {
                    MessageBox.Show("No record found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gd1.Visible = true;
                    gd2.Visible = false;

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

        protected void btnclose3_Click(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = 0;
            Panel3.Visible = false;
            gd1.Visible = false;
            gd2.Visible = false;
        }

        protected void btnback1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            txtbid.Text = "";
            txtcolor.Text = "";
            txtddate.Text = "";
            txtid.Text = "";
            dlistmodel.SelectedIndex = 0;
            dlistsname.SelectedIndex = 0;
            txtodate.Text = "";
            txtpo.Text = "";
            txtprice.Text = "";
            txtqty.Text = "";
            dispgrid.Visible = false;
        }

        protected void btnback5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ahome.aspx");
        }
    }
}