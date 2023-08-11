<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aproduct.aspx.cs" Inherits="Automation.Aproduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="product1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
    </style>
</head>
<body style="height:560px; margin-top: 0px;">
      <section>
    <form id="form1" runat="server">
  


    <asp:Panel ID="Panel1" CssClass="customwidth" HorizontalAlign="center" runat="server">
    <br /><h2><u>ADD PRODUCT</u></h2><br />
        <asp:Label ID="Label1" runat="server" Text="Bike ID" CssClass="lblid"></asp:Label><asp:TextBox ID="txtbid" runat="server" CssClass="TextBox1" Enabled="false"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Bike Name" CssClass="lblname"></asp:Label><asp:TextBox ID="txtbname" runat="server" CssClass="TextBox2"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="Model" CssClass="lblmodel"></asp:Label><asp:TextBox ID="txtmodel" runat="server" CssClass="TextBox3"></asp:TextBox><br />
        <asp:Label ID="Label19" runat="server" Text="Color" CssClass="lblmodel"></asp:Label><asp:TextBox ID="txtcolor" runat="server" CssClass="TextBox3"></asp:TextBox><br />
        <asp:Label ID="Label5" runat="server" Text="Price" CssClass="lblprice"></asp:Label><asp:TextBox ID="txtprice" runat="server" CssClass="TextBox5"></asp:TextBox><br />
        <asp:Label ID="Label6" runat="server" Text="Quantity" CssClass="lblquan"></asp:Label><asp:TextBox ID="txtqty" runat="server" CssClass="TextBox6"></asp:TextBox><br />
       
        <asp:Label ID="Label8" runat="server" Text="Warranty in years" CssClass="lblwarr"></asp:Label><asp:TextBox ID="txtwarranty" runat="server" CssClass="TextBox8"></asp:TextBox><br />
         <asp:Label ID="Label7" runat="server" Text="Status" CssClass="lblreo"></asp:Label><asp:DropDownList runat="server" ID="dstat" width="117px" BackColor="LightGray" >
           <asp:ListItem Value="">--Select--</asp:ListItem>
             <asp:ListItem>InStock</asp:ListItem>
            <asp:ListItem>Outdated</asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        <asp:Button ID="btnsave1" runat="server" Text="Save" CssClass="btnsave1" OnClick="btnsave1_Click"/>
         <asp:Button ID="btnclr1" runat="server" Text="Clear" CssClass="btnclr1" OnClick="btnclr1_Click"/>
        <asp:Button ID="btnback1" runat="server" Text="Back" CssClass="btnback1" OnClick="btnback1_Click"/>

    </asp:Panel>

        <asp:Panel ID="Panel2" CssClass="customwidth1" HorizontalAlign="center" runat="server">
    <br /><h2><u>UPDATE STOCK DETAILS</u></h2><br />
        <asp:Label ID="Label9" runat="server" Text="Bike ID" CssClass="lblid2"></asp:Label><asp:DropDownList runat="server" ID="dlistid" width="117px" BackColor="LightGray" ></asp:DropDownList>
            <br />
        <asp:Label ID="Label12" runat="server" Text="Bike Name" CssClass="lblname2"></asp:Label><asp:TextBox ID="txtname2" runat="server" CssClass="TextBox10"></asp:TextBox><br />
        <asp:Label ID="Label13" runat="server" Text="Model" CssClass="lblmodel2"></asp:Label><asp:TextBox ID="txtmodel2" runat="server" CssClass="TextBox11"></asp:TextBox><br />
        <asp:Label ID="Label22" runat="server" Text="Color" CssClass="lblmodel2"></asp:Label><asp:TextBox ID="txtcolor2" runat="server" CssClass="TextBox11"></asp:TextBox><br />
        <asp:Label ID="Label15" runat="server" Text="Price" CssClass="lblprice2"></asp:Label><asp:TextBox ID="txtprice2" runat="server" CssClass="TextBox13"></asp:TextBox><br />
        <asp:Label ID="Label16" runat="server" Text="Quantity" CssClass="lblquan2"></asp:Label><asp:TextBox ID="txtqty2" runat="server" CssClass="TextBox14"></asp:TextBox><br />
        <asp:Label ID="Label18" runat="server" Text="Warranty(years)" CssClass="lblwarr2"></asp:Label><asp:TextBox ID="txtwarranty2" runat="server" CssClass="TextBox16"></asp:TextBox><br />
        <asp:Label ID="Label11" runat="server" Text="Status" CssClass="lblstat2"></asp:Label><asp:TextBox ID="txtstat" runat="server" CssClass="TextBox14"></asp:TextBox><br /><br /><br/>
        <asp:Button ID="btnupd2" runat="server" Text="Update" CssClass="btnupd2" OnClick="btnupd2_Click"/>
         <asp:Button ID="btnclr2" runat="server" Text="Clear" CssClass="btnclr2" OnClick="btnclr2_Click"/>
        <asp:Button ID="btndis2" runat="server" Text="Display" CssClass="btndis2" OnClick="btndis2_Click"/>
        <asp:Button ID="btncl2" runat="server" Text="Close" CssClass="btncl2" OnClick="btncl2_Click"/>
        

        </asp:Panel>
        
        <asp:Panel ID="Panel3" CssClass="customwidth2" HorizontalAlign="center" runat="server">
    <br /><h2><u>DELETE STOCK</u></h2><br /><br />
        <asp:Label ID="Label20" runat="server" Text="Item Name" CssClass="lblname3"></asp:Label><asp:DropDownList runat="server" ID="namelist3" width="124px"></asp:DropDownList>
            <br /><br />
        <asp:Label ID="Label21" runat="server" Text="Item ID" CssClass="lblid3"></asp:Label><asp:TextBox ID="txtbid3" runat="server" CssClass="TextBox17"></asp:TextBox><br /><br />
        <asp:Button ID="btndel3" runat="server" Text="Delete" CssClass="btndel3" OnClick="Button8_Click"/>
             <asp:Button ID="btndis3" runat="server" Text="Display" CssClass="btnclose3" OnClick="btndis3_Click" />
        <asp:Button ID="btncl3" runat="server" Text="Close" CssClass="btnclose3" OnClick="btncl3_Click" /></asp:Panel>
        
        <asp:Panel ID="Panel4" CssClass="buttonwidth" HorizontalAlign="center" runat="server">
     
        <asp:Button ID="btnadd" runat="server" Text="ADD PRODUCT" CssClass="btnadd" Height="27px" OnClick="btnadd_Click"/>
            <asp:Button ID="btnupd" runat="server" Text="UPDATE STOCK" CssClass="btnupd" OnClick="btnupd_Click" />

        <asp:Button ID="btndis" runat="server" Text="DISPLAY STOCK" CssClass="btndis" OnClick="btndis_Click" />
        <asp:Button ID="btndel" runat="server" Text="DELETE PRODUCT" CssClass="btndel" OnClick="btndel_Click"/>
        <asp:Button ID="btnback" runat="server" Text="BACK" CssClass="btnback" OnClick="btnback_Click"/></asp:Panel>

        <asp:Panel ID="Panel5" CssClass="customwidth4" HorizontalAlign="center" runat="server" ScrollBars="Horizontal"><br />
            <h2><u>DISPLAY STOCK</u></h2><br />
 <asp:Label ID="Label10" runat="server" Text="Item Name" CssClass="lblname3"></asp:Label><asp:DropDownList runat="server" ID="DropDownList1" width="124px"></asp:DropDownList> <br /><br />
            <asp:Button ID="btnsearch5" runat="server" Text="SEARCH" CssClass="btnclose5" OnClick="btnsearch5_Click"/><br /><br />
            <asp:GridView ID="GridView1" runat="server" backcolor="LightGray" AutoGenerateColumns ="False" DataKeyNames="bid" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="bid" HeaderText="bid" ReadOnly="True" SortExpression="bid" />
                    <asp:BoundField DataField="bname" HeaderText="bname" SortExpression="bname" />
                    <asp:BoundField DataField="model" HeaderText="model" SortExpression="model" />
                    <asp:BoundField DataField="color" HeaderText="color" SortExpression="color" />
                    <asp:BoundField DataField="bprice" HeaderText="bprice" SortExpression="bprice" />
                    <asp:BoundField DataField="sqty" HeaderText="sqty" SortExpression="sqty" />
                    <asp:BoundField DataField="warranty" HeaderText="warranty" SortExpression="warranty" />
                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bgroup3ConnectionString21 %>" SelectCommand="SELECT * FROM [stock]"></asp:SqlDataSource>
            <br /><br />
            
            <asp:GridView ID="GridView2" runat="server" BackColor="LightGray">
            </asp:GridView><br /><br />
            <asp:Button ID="btnclose5" runat="server" Text="CLOSE" CssClass="btnclose5" OnClick="btnclose5_Click"/>
            
            </asp:Panel>

       
    </form> </section></body>
</html>
