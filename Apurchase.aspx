<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apurchase.aspx.cs" Inherits="Automation.Apurchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="purchaseorder1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
        .btnimg {
            margin-top: 11px;
        }
        
    </style>
</head>
<body style="height:560px; margin-top: 0px;">
      <section>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" CssClass="customwidth" HorizontalAlign="center" runat="server" ScrollBars="Horizontal" ><br />
            
            <asp:Label ID="Label29" runat="server" CssClass="lbldate" Text="Date" /><asp:Label ID="lbldate" runat="server" Text="lbl" CssClass="lbldate1" Enabled="false"/><br />
            <asp:Label ID="Label6" runat="server" CssClass="lbldate" Text="Purchase ID" /><asp:Label ID="lblpid" runat="server" Text="lbl" CssClass="lbldate1" Enabled="false" /><br /><br />
  <h2><u>PURCHASE ORDER</u></h2>
        <asp:Label ID="Label1" runat="server" Text="Purchase Order No" CssClass="lblPorder"></asp:Label><asp:TextBox ID="txtpo" runat="server" CssClass="TextBox1" Enabled="false"></asp:TextBox><br />
        <asp:Label ID="Label4" runat="server" Text="Supplier Name" CssClass="lblsname"></asp:Label><asp:DropDownList runat="server" ID="dlistsname" width="124px" OnSelectedIndexChanged="dlistsname_SelectedIndexChanged">
        </asp:DropDownList><br />
        <asp:Label ID="Label2" runat="server" Text="supplier ID" CssClass="lblodate"></asp:Label><asp:TextBox ID="txtid" runat="server" CssClass="TextBox3" Enabled="false"></asp:TextBox> <br />
         <br />  <center><asp:Button ID="Button1" runat="server" Text="Generate sid" CssClass="btnnext1" OnClick="Button1_Click"/></center> 
 <br /><h2><u>PURCHASE ORDER DETAILS</u></h2><br />
       <asp:Label ID="Label10" runat="server" Text="Bike ID" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtbid" runat="server" CssClass="TextBox3" Enabled="false"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="Order Date" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtodate" runat="server" CssClass="TextBox3"></asp:TextBox><br />
        <asp:Label ID="Label9" runat="server" Text="Due Date" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtddate" runat="server" CssClass="TextBox3" OnTextChanged="txtddate_TextChanged"></asp:TextBox>
            <asp:ImageButton ID="imgbtn" runat="server" src="icons8-calendar-48.png" CssClass="btnimg" Height="24px" Width="27px" OnClick="imgbtn_Click" /><br />
                <asp:Label ID="Label11" runat="server" Text="Bike Name" CssClass="lblddate"></asp:Label><asp:DropDownList runat="server" ID="dlistmodel" width="124px">
                
            </asp:DropDownList><br />
          <asp:Label ID="Label12" runat="server" Text="Color" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtcolor" runat="server" CssClass="TextBox3"></asp:TextBox><br />
        <asp:Label ID="Label13" runat="server" Text="Quantity" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtqty" runat="server" CssClass="TextBox3"></asp:TextBox><br />
        <asp:Label ID="Label8" runat="server" Text="Price" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtprice" runat="server" CssClass="TextBox3"></asp:TextBox><br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <br />        
   <asp:GridView ID="dispgrid" runat="server" BackColor="#CCCCCC"></asp:GridView>/><br />
            
          
           
        <asp:Button ID="btnsave1" runat="server" Text="Order" CssClass="btnnext1" OnClick="btnsave1_Click"/>
            <asp:Button ID="btnclr1" runat="server" Text="Clear" CssClass="btnnext1" OnClick="btnclr1_Click"/>
            <asp:Button ID="btndis1" runat="server" Text="Display" CssClass="btnnext1" OnClick="btndis1_Click"/>
            
            <asp:Button ID="btnback1" runat="server" Text="Back" CssClass="btnnext1" OnClick="btnback1_Click"/>
          <br /><br />
            
          </asp:Panel>
            
         <asp:Panel ID="Panel2" CssClass="customwidth1" HorizontalAlign="center" runat="server" ScrollBars="Horizontal">
            <br /><br />
              <br /><h2><u>PURCHASE BILL</u></h2><br />
                    <asp:Label ID="Label14" runat="server" Text="Purchase Bill No" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtbillno2" runat="server" CssClass="TextBox3"></asp:TextBox><br />
                    <asp:Label ID="Label15" runat="server" Text="Bill Date" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtdate2" runat="server" CssClass="TextBox3"></asp:TextBox><br />
                    <asp:Label ID="Label17" runat="server" Text="Order No" CssClass="lblddate"></asp:Label><asp:DropDownList runat="server" ID="dlistono" width="124px"></asp:DropDownList><br /><br />
                     <asp:Button ID="btngen" runat="server" Text="Generate Bikeid" CssClass="btngen" OnClick="btngen_Click" /><br /><br />
                    <asp:Label ID="Label18" runat="server" Text="Order Date" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtodate2" runat="server" CssClass="TextBox3"></asp:TextBox><br />
                    <asp:Label ID="Label16" runat="server" Text="Bike ID" CssClass="lblsname"></asp:Label><asp:DropDownList runat="server" ID="dlistbid" width="124px"></asp:DropDownList><br />
                    <asp:Label ID="Label19" runat="server" Text="Supplier Id" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtsid" runat="server" CssClass="TextBox3"></asp:TextBox><br />
                    <asp:Label ID="Label20" runat="server" Text="Supplier Name" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtsname" runat="server" CssClass="TextBox3"></asp:TextBox><br /><br /><br />
                    <asp:Label ID="Label21" runat="server" Text="Grand Total" CssClass="lblddate"></asp:Label><asp:TextBox ID="txttotal" runat="server" CssClass="TextBox3" Enabled="false"></asp:TextBox><br />
            <br /><br />
             <asp:Button ID="btnsub2" runat="server" Text="Submit" CssClass="btnnext1" OnClick="btnsub2_Click" />
            <asp:Button ID="btnclr2" runat="server" Text="Clear" CssClass="btnnext1" OnClick="btnclr2_Click" />
            <asp:Button ID="btndis2" runat="server" Text="Display" CssClass="btnnext1" OnClick="btndis2_Click" />
            <asp:Button ID="btnback2" runat="server" Text="Back" CssClass="btnnext1" OnClick="btnback2_Click"/><br />
             <asp:TextBox ID="txt2" runat="server" Visible="false" ></asp:TextBox>
             <asp:TextBox ID="txt3" runat="server"  Visible="false"></asp:TextBox>
             <asp:TextBox ID="txt4" runat="server"  Visible="false"></asp:TextBox>
             <asp:TextBox ID="txt5" runat="server" Visible="false" ></asp:TextBox>
             <asp:TextBox ID="txt6" runat="server" Visible="false" ></asp:TextBox>

             <asp:Label ID="Label7" runat="server" Text="Bike name" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtbname" runat="server" CssClass="TextBox3"></asp:TextBox><br />
             <asp:Label ID="Label23" runat="server" Text="Warranty" CssClass="lblddate"></asp:Label><asp:TextBox ID="txtwarranty" runat="server" CssClass="TextBox3"></asp:TextBox><br />
             <asp:Button ID="btnok" runat="server" Text="OK" CssClass="btnnext1" OnClick="btnok_Click" />


        </asp:Panel>
        
         <asp:Panel ID="Panel3" CssClass="customwidth3" HorizontalAlign="center" runat="server" ScrollBars="Horizontal"><br />
                 <h2><u>DISPLAY BILL</u></h2><br />
        <asp:Label ID="Label22" runat="server" Text="Bill number" CssClass="lblddate"></asp:Label><asp:DropDownList runat="server" ID="DropDownList1" width="124px"></asp:DropDownList> <br /><br />
            <asp:Button ID="btnsearch5" runat="server" Text="Search" CssClass="btnnext1" OnClick="btnsearch5_Click" /><br /><br />
             <asp:GridView ID="gd1" runat="server" BackColor="LightGray" >
             </asp:GridView>
             <asp:GridView ID="gd2" runat="server" BackColor="LightGray"></asp:GridView>
              <asp:Button ID="btnclose3" runat="server" Text="Close" CssClass="btnnext1" OnClick="btnclose3_Click" /><br /><br />
         </asp:Panel><br />
        
             
       
                                               
            <asp:Panel ID="Panel5" CssClass="buttonwidth" HorizontalAlign="center" runat="server">
            <br /><br />
        <asp:Button ID="btnpurorder" runat="server" Text="PURCHASE ORDER" CssClass="btnporder1" Height="27px" OnClick="btnpurorder_Click"/>
            <br /><br /><br />
          
          
        <asp:Button ID="btnpurbill" runat="server" Text="PURCHASE BILL" CssClass="btnnextp1" OnClick="btnpurbill_Click"  />
            <br /><br /><br />
                <asp:Button ID="btndisplay" runat="server" Text="Display Bill" CssClass="btnnextp1" OnClick="btndisplay_Click"   />
            <br /><br /><br />
        <asp:Button ID="btnback5" runat="server" Text="BACK" CssClass="btnback1" OnClick="btnback5_Click" /></asp:Panel>      
        <div>
        </div>
    </form></section>
</body>
</html>

