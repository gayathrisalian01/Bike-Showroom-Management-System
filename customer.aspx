<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customer.aspx.cs" Inherits="Automation.customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="customer1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <section>
    <form id="form1" runat="server">
         <asp:Panel ID="Panel1" CssClass="customwidth" HorizontalAlign="center" runat="server">
    <br /><h2><u>ADD CUSTOMER</u></h2><br />
        <asp:Label ID="Label1" runat="server" Text="Customer ID" CssClass="lblcid"></asp:Label><asp:TextBox ID="txtcid1" runat="server" CssClass="TextBox1" Enabled="false"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Name" CssClass="lblcname"></asp:Label><asp:TextBox ID="txtcname1" runat="server" CssClass="TextBox3" ></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="Address" CssClass="lblcname"></asp:Label><asp:TextBox ID="txtcadd1" runat="server" CssClass="TextBox3" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Label ID="Label4" runat="server" Text="Phone" CssClass="lblcphone"></asp:Label><asp:TextBox ID="txtcphone1" runat="server" CssClass="TextBox4" TextMode="Phone" MaxLength="10"></asp:TextBox><br />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter number only" ControlToValidate="txtcphone1" ValidationExpression="^([7-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator><br />
        <asp:Label ID="Label5" runat="server" Text="Email" CssClass="lblcprice"></asp:Label><asp:TextBox ID="txtcmail1" runat="server" CssClass="TextBox5" TextMode="Email"></asp:TextBox><br />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid email id form!!" ControlToValidate="txtcmail1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />      
         <asp:Label ID="Label13" runat="server" Text="Register No" CssClass="lblcphone2" ></asp:Label><asp:TextBox ID="txtreg1" runat="server" CssClass="TextBox12"  ></asp:TextBox><br />
             <br /><br />
        <asp:Button ID="btnsave1" runat="server" Text="Save" CssClass="btnsave1" OnClick="btnsave1_Click"/>
         <asp:Button ID="btnclr1" runat="server" Text="Clear" CssClass="btnclr1" OnClick="btnclr1_Click"/>
        <asp:Button ID="btnback1" runat="server" Text="Back" CssClass="btnback1" OnClick="btnback1_Click"/>

    </asp:Panel>

        <asp:Panel ID="Panel2" CssClass="customwidth2" HorizontalAlign="center" runat="server" Width="600px"  >
    <br/><h2><u>UPDATE CUSTOMER DETAILS</u></h2><br />
        <asp:Label ID="Label6" runat="server" Text="Customer ID" CssClass="lblcid2"></asp:Label><asp:DropDownList runat="server" ID="dlistcid" width="117px" BackColor="LightGray" ></asp:DropDownList>
            <br />
        <asp:Label ID="Label7" runat="server" Text="Name" CssClass="lblcname2"></asp:Label><asp:TextBox ID="txtcname2" runat="server" CssClass="TextBox10"></asp:TextBox><br />
        <asp:Label ID="Label8" runat="server" Text="Address" CssClass="lblcadd2"></asp:Label><asp:TextBox ID="txtcadd2" runat="server" CssClass="TextBox11" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Label ID="Label9" runat="server" Text="Phone" CssClass="lblcphone2"></asp:Label><asp:TextBox ID="txtcphone2" runat="server" CssClass="TextBox12" TextMode="Phone"></asp:TextBox><br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter number only" ControlToValidate="txtcphone2" ValidationExpression="^([7-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator><br />
        <asp:Label ID="Label10" runat="server" Text="Email" CssClass="lblcmail2"></asp:Label><asp:TextBox ID="txtcmail2" runat="server" CssClass="TextBox13" TextMode="Email"></asp:TextBox><br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter valid email id form!!" ControlToValidate="txtcmail2" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
            <br/>
        <asp:Label ID="Label11" runat="server" Text="Register No" CssClass="lblcphone2"></asp:Label><asp:TextBox ID="txtreg2" runat="server" CssClass="TextBox12" ></asp:TextBox><br /><br />
            
        <asp:Button ID="btnupd2" runat="server" Text="Update" CssClass="btnupd2" OnClick="btnupd2_Click"/>
        <asp:Button ID="btnclr2" runat="server" Text="Clear" CssClass="btnclr2" OnClick="btnclr2_Click" />
        <asp:Button ID="btndis2" runat="server" Text="Display" CssClass="btndis2" OnClick="btndis2_Click" /> 
        <asp:Button ID="btnback2" runat="server" Text="Back" CssClass="btnclr2" OnClick="btnback2_Click" />
    </asp:Panel>
        
      
         <asp:Panel ID="Panel3" CssClass="customwidth3" HorizontalAlign="center" runat="server"><br />
            <h2><u>DISPLAY CUSTOMER</u></h2><br />
         <asp:Label ID="Label12" runat="server" Text="Customer Name" CssClass="lblcmail2"></asp:Label><asp:DropDownList runat="server" ID="dlistcust" width="124px" BackColor="LightGray"></asp:DropDownList> <br /><br />
             <asp:Button ID="btndis3" runat="server" Text="DISPLAY" CssClass="btnclose5" OnClick="btndis3_Click" /><br /><br /><br />
          &nbsp&nbsp&nbsp <asp:GridView ID="GridView2" runat="server" BackColor="LightGray" AutoGenerateColumns="False" DataKeyNames="cid" DataSourceID="SqlDataSource3">
                <Columns>
                    <asp:BoundField DataField="cid" HeaderText="cid" ReadOnly="True" SortExpression="cid" />
                    <asp:BoundField DataField="custname" HeaderText="custname" SortExpression="custname" />
                    <asp:BoundField DataField="custadd" HeaderText="custadd" SortExpression="custadd" />
                    <asp:BoundField DataField="cphone" HeaderText="cphone" SortExpression="cphone" />
                    <asp:BoundField DataField="cmail" HeaderText="cmail" SortExpression="cmail" />
                    <asp:BoundField DataField="reg_no" HeaderText="reg_no" SortExpression="reg_no" />
                </Columns>
            </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:bgroup3ConnectionString19 %>" SelectCommand="SELECT * FROM [customer1]"></asp:SqlDataSource>
             <br />
             <asp:GridView ID="GridView1" runat="server" BackColor="LightGray" >

             </asp:GridView><br /><br />
             
            <asp:Button ID="btnclose3" runat="server" Text="CLOSE" CssClass="btnclose5" OnClick="btnclose3_Click"/>
        </asp:Panel>

        <asp:Panel ID="Panel4" CssClass="buttonwidth" HorizontalAlign="center" runat="server">
            <br /><br />
        <asp:Button ID="btnadd4" runat="server" Text="ADD" CssClass="btnadd" Height="27px" OnClick="btnadd4_Click" />
            <br /><br /><br />
        <asp:Button ID="btnupd4" runat="server" Text="UPDATE" CssClass="btnup" OnClick="btnupd4_Click"  />
            <br /><br /><br />
        <asp:Button ID="btndis4" runat="server" Text="DISPLAY" CssClass="btndis" OnClick="btndis4_Click"  />
            <br /><br /><br />
        <asp:Button ID="btnback4" runat="server" Text="BACK" CssClass="btnback" OnClick="btnback4_Click"  />
        </asp:Panel>    

        
    </form></section>
</body>
</html>
