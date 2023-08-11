<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asupplier.aspx.cs" Inherits="Automation.Asupplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="newsuppliercss.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
        
    </style>
</head>
<body style="height:549px">
    <section>
    <form id="form1" runat="server">
       <asp:Panel ID="Panel1" CssClass="customwidth" HorizontalAlign="center" runat="server">
    <br /><h2>ENTER NEW SUPPLIER DETAILS</h2><br /><br />
        <asp:Label ID="Label1" runat="server" Text="Supplier ID" CssClass="lblid"></asp:Label><asp:TextBox ID="txtsid" runat="server" CssClass="TextBox1" Enabled="false"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Name" CssClass="lblname"></asp:Label><asp:TextBox ID="txtsname" runat="server" CssClass="TextBox2"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="Address" CssClass="lbladd"></asp:Label><asp:TextBox ID="txtaddress" runat="server" CssClass="TextBox3"></asp:TextBox><br />
        <asp:Label ID="Label4" runat="server" Text="Phone" CssClass="lblphone"></asp:Label><asp:TextBox ID="txtphone" runat="server" CssClass="TextBox4" MaxLength="10"></asp:TextBox><br />
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter number only" ControlToValidate="txtphone" ValidationExpression="^([7-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator><br />
        <asp:Label ID="Label5" runat="server" Text="Email" CssClass="lblmail"></asp:Label><asp:TextBox ID="txtemail" runat="server" CssClass="TextBox5"></asp:TextBox><br />
     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter valid email id form!!" ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />

           <asp:Label ID="Label6" runat="server" Text="Bank Name" CssClass="lblbank"></asp:Label><asp:TextBox ID="txtbank" runat="server" CssClass="TextBox6"></asp:TextBox><br />
        <asp:Label ID="Label7" runat="server" Text="Account No" CssClass="lblacc"></asp:Label><asp:TextBox ID="txtaccno" runat="server" CssClass="TextBox7" MaxLength="13" ></asp:TextBox><br />
        <asp:Label ID="Label8" runat="server" Text="IFSC Code" CssClass="lblcode"></asp:Label><asp:TextBox ID="txtifcs" runat="server" CssClass="TextBox8"></asp:TextBox><br />
        <asp:Label ID="Label9" runat="server" Text="Branch Name" CssClass="lblbranch"></asp:Label><asp:TextBox ID="txtbranch" runat="server" CssClass="TextBox9"></asp:TextBox><br />
     <asp:Label ID="Label12" runat="server" Text="Status" CssClass="lblstatus"></asp:Label><asp:DropDownList runat="server" ID="ddlst" Width="117px" BackColor="LightGray">
               <asp:ListItem>--select--</asp:ListItem>
               <asp:ListItem>Active</asp:ListItem>
               <asp:ListItem>Inactive</asp:ListItem>
           </asp:DropDownList> <br /><br />
           <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btnsave1" OnClick="Button1_Click"/><asp:Button ID="Button5" runat="server" Text="Clear" CssClass="btnclr1" OnClick="Button5_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Back" CssClass="btnback1" OnClick="Button2_Click" /></asp:Panel>
        
        <asp:Panel ID="Panel2" CssClass="customwidth2" HorizontalAlign="center" runat="server">
    <br /><h2>DELETE SUPPLIER</h2><br /><br />
        <asp:Label ID="Label10" runat="server" Text="Supplier Name" CssClass="lblid"></asp:Label><asp:DropDownList runat="server" ID="namelist" Width="117px" BackColor="LightGray"></asp:DropDownList>
            <br />
        <asp:Label ID="Label11" runat="server" Text="Supplier ID" CssClass="lblname"></asp:Label><asp:TextBox ID="txtid" runat="server" CssClass="TextBox10" ></asp:TextBox><br /><br />
        <asp:Button ID="Button3" runat="server" Text="Delete" CssClass="btndel2" OnClick="Button3_Click"/>
             <asp:Button ID="Button9" runat="server" Text="Display" CssClass="btndel2" OnClick="Button9_Click" />
        <asp:Button ID="Button4" runat="server" Text="Back" CssClass="btnback2" OnClick="Button4_Click"/></asp:Panel>
        
        <asp:Panel ID="Panel3" CssClass="buttonwidth" runat="server" >
        
        <asp:Button ID="btnnew" runat="server" Text="New" CssClass="btnnew3" OnClick="btnnew_Click"  /><br />
        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="btnnew3" OnClick="btnupdate_Click"  /><br />
        <asp:Button ID="btndis" runat="server" Text="Display" CssClass="btndis3" OnClick="btndis_Click1" /><br />
        <asp:Button ID="btndel" runat="server" Text="Delete" CssClass="btndel3" OnClick="btndel_Click"/><br />
        <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btnback3" OnClick="btnback_Click"/></asp:Panel>

        <asp:Panel ID="Panel4" CssClass="gridwidth" runat="server" ><br />
           <h2>SUPPLIER LIST</h2><br />
             <asp:Label ID="Label13" runat="server" Text="Supplier Name" CssClass="lblname4"></asp:Label><asp:DropDownList runat="server" ID="DropDownList1" width="117px" BackColor="LightGray" ></asp:DropDownList> <br />
            <br /><asp:Button ID="btnsearch" runat="server" Text ="search" CssClass="btnser" OnClick="btnsearch_Click" /><br /><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="sid" DataSourceID="SqlDataSource2" ForeColor="Black"> 
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="sid" HeaderText="sid" ReadOnly="True" SortExpression="sid" />
                    <asp:BoundField DataField="sname" HeaderText="sname" SortExpression="sname" />
                    <asp:BoundField DataField="sadd" HeaderText="sadd" SortExpression="sadd" />
                    <asp:BoundField DataField="spno" HeaderText="spno" SortExpression="spno" />
                    <asp:BoundField DataField="semail" HeaderText="semail" SortExpression="semail" />
                    <asp:BoundField DataField="bank" HeaderText="bank" SortExpression="bank" />
                    <asp:BoundField DataField="accno" HeaderText="accno" SortExpression="accno" />
                    <asp:BoundField DataField="ifsc" HeaderText="ifsc" SortExpression="ifsc" />
                    <asp:BoundField DataField="branch" HeaderText="branch" SortExpression="branch" />
                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
             </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bgroup3ConnectionString2 %>" SelectCommand="SELECT * FROM [supplier]"></asp:SqlDataSource>
             <br />
            <asp:GridView ID="GridView2" runat="server"  BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black"></asp:GridView><br /><br />
<asp:Button ID="Button6" runat="server" Text="Back" CssClass="btnback4" OnClick="Button6_Click"/>
       

        </asp:Panel>

         <asp:Panel ID="Panel5" CssClass="customwidth1" HorizontalAlign="center" runat="server">
         <br /><h2><u>UPDATE STOCK DETAILS</u></h2><br />
        <asp:Label ID="Label14" runat="server" Text="Bike ID" CssClass="lblid5"></asp:Label><asp:DropDownList runat="server" ID="dlistid" width="117px" BackColor="LightGray"></asp:DropDownList>
             <br />
        <asp:Label ID="Label15" runat="server" Text="Name" CssClass="lblname"></asp:Label><asp:TextBox ID="txtsname5" runat="server" CssClass="TextBox2"></asp:TextBox><br />
        <asp:Label ID="Label16" runat="server" Text="Address" CssClass="lbladd"></asp:Label><asp:TextBox ID="txtadd5" runat="server" CssClass="TextBox3"></asp:TextBox><br />
        <asp:Label ID="Label17" runat="server" Text="Phone" CssClass="lblphone"></asp:Label><asp:TextBox ID="txtpno5" runat="server" CssClass="TextBox4"></asp:TextBox><br />
        <asp:Label ID="Label18" runat="server" Text="Email" CssClass="lblmail"></asp:Label><asp:TextBox ID="txtmail5" runat="server" CssClass="TextBox5"></asp:TextBox><br />
        <asp:Label ID="Label19" runat="server" Text="Bank Name" CssClass="lblbank"></asp:Label><asp:TextBox ID="txtbname5" runat="server" CssClass="TextBox6"></asp:TextBox><br />
        <asp:Label ID="Label20" runat="server" Text="Account No" CssClass="lblacc"></asp:Label><asp:TextBox ID="txtacc5" runat="server" CssClass="TextBox7"></asp:TextBox><br />
        <asp:Label ID="Label21" runat="server" Text="IFSC Code" CssClass="lblcode"></asp:Label><asp:TextBox ID="txtcode5" runat="server" CssClass="TextBox8"></asp:TextBox><br />
        <asp:Label ID="Label22" runat="server" Text="Branch Name" CssClass="lblbranch"></asp:Label><asp:TextBox ID="txtbranch5" runat="server" CssClass="TextBox9"></asp:TextBox><br />
        <asp:Label ID="Label23" runat="server" Text="Status" CssClass="lblstatus5"></asp:Label><asp:TextBox ID="txtstat5" runat="server" CssClass="TextBox9"></asp:TextBox><br /><br /><br/>
        <asp:Button ID="btnupd5" runat="server" Text="Update" CssClass="btnupd5" OnClick="btnupd5_Click" />
         <asp:Button ID="btnclr5" runat="server" Text="Clear" CssClass="btnclr5" OnClick="btnclr5_Click" />
        <asp:Button ID="btndis5" runat="server" Text="Display" CssClass="btndis5" OnClick="btndis5_Click" />
        <asp:Button ID="btncl5" runat="server" Text="Close" CssClass="btncl5" OnClick="btncl5_Click" />
        </asp:Panel>

    </form>
        </section>
</body>
</html>

