<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auser.aspx.cs" Inherits="Automation.Auser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Auser.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
    </style>
</head>
<body style="height:560px; margin-top: 0px;">
      <section>
    <form id="form1" runat="server">
  
        <asp:Panel ID="Panel1" CssClass="customwidth" HorizontalAlign="center" runat="server">
    <br /><h2><u>CREATE USER</u></h2><br /><br />
        <asp:Label ID="Label20" runat="server" Text="Username" CssClass="lbluname"></asp:Label><asp:TextBox ID="txtuname1" runat="server" CssClass="txtuname"></asp:TextBox><br />
         <asp:Label ID="Label1" runat="server" Text="Password" CssClass="lblpass"></asp:Label><asp:TextBox ID="txtpass1" runat="server" CssClass="txtpass"></asp:TextBox><br />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtpass1" ErrorMessage="Password must contain 8 digits,atleast 1 uppercase letter,1 lowercase letter and 1 number!!" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8}$"></asp:RegularExpressionValidator>
        <br /><br />
        <asp:Button ID="btncreate" runat="server" Text="Create User" CssClass="btndel3" OnClick="btncreate_Click" />
        <asp:Button ID="btnclr" runat="server" Text="Clear" CssClass="btnclose3" OnClick="btnclr_Click"  />
        <asp:Button ID="btncl" runat="server" Text="Close" CssClass="btnclose3" OnClick="btncl_Click"  />
        </asp:Panel>

         <asp:Panel ID="Panel2" CssClass="customwidth" HorizontalAlign="center" runat="server">
    <br /><h2><u>BLOCK USER</u></h2><br /><br />
        <asp:Label ID="Label2" runat="server" Text="Employee Name" CssClass="lbluname"></asp:Label> <asp:DropDownList runat="server" ID="emplist1" width="124px" backcolor="LightGray"></asp:DropDownList>
             <br /><br />
             <asp:Button ID="btnblock" runat="server" Text="Block" CssClass="btnclose3" OnClick="btnblock_Click"  />
        <asp:Button ID="btnexit" runat="server" Text="Close" CssClass="btnclose3" OnClick="btnexit_Click"  />
             </asp:Panel>

        <asp:Panel ID="Panel3" CssClass="customwidth" HorizontalAlign="center" runat="server">
    <br /><h2><u>UNBLOCK USER</u></h2><br /><br />
        <asp:Label ID="Label3" runat="server" Text="Employee Name" CssClass="lbluname"></asp:Label> <asp:DropDownList runat="server" ID="emplist2" width="124px" BackColor="LightGray"></asp:DropDownList>
             <br /><br />
             <asp:Button ID="Button1" runat="server" Text="Unblock" CssClass="btnclose3" OnClick="Button1_Click"  />
        <asp:Button ID="Button2" runat="server" Text="Close" CssClass="btnclose3" OnClick="Button2_Click"  />
             </asp:Panel>
        
        <asp:Panel ID="Panel4" CssClass="buttonwidth" HorizontalAlign="center" runat="server">
            <asp:Button ID="btnupd" runat="server" Text="CREATE" CssClass="btnupd" OnClick="btnupd_Click" />
         <asp:Button ID="btndis" runat="server" Text="BLOCK" CssClass="btndis" OnClick="btndis_Click"  />
        <asp:Button ID="btndel" runat="server" Text="UNBLOCK" CssClass="btndel" OnClick="btndel_Click" />
            <asp:Button ID="btnsq" runat="server" Text="SECURITY QUES" CssClass="btndel" OnClick="btnsq_Click" />
        <asp:Button ID="btnback" runat="server" Text="BACK" CssClass="btnback" OnClick="btnback_Click" />
        </asp:Panel>
        <div>
        </div>
    </form>
          </section>
</body>
</html>
