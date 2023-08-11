<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alogin.aspx.cs" Inherits="Automation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <div  class="loginbox">
        <img src="adminclip.png" alt="alternate text" class="user" />
      
        <h2>Log In Here</h2>
        <br />
        <form id="form1" runat="server">
            <br />
            <asp:TextBox ID="txtuser" CssClass="txtuser" runat="server" placeholder="Enter username"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtpass" CssClass="txtpass" runat="server" placeholder="*********" MaxLength="8" TextMode="Password"></asp:TextBox>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtpass" ErrorMessage="Password must contain 8 digits,atleast 1 uppercase letter,1 lowercase letter and 1 number!!" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8}$"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnsign"  CssClass="btnsign" runat="server" Text="Sign In" OnClick="btnsign_Click" />
            <br />
            <asp:Button ID="btnback"  CssClass="btnsign" runat="server" Text="back" OnClick="btnback_Click" />
            <asp:LinkButton ID="lbtnforget" CssClass="lbtnforget" runat="server" OnClick="lbtnforget_Click">Change Password</asp:LinkButton><br /><br />
            
        
        
    </form>
        </div>
</body>
</html>
