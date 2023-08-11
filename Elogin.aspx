<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Elogin.aspx.cs" Inherits="Automation.Elogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="elogin.css" rel="stylesheet" />
</head>
<body>
      <div  class="loginbox2">
          <img src="adminclip.png" alt="alternate text" class="user"/>
      
        <h2>Log In Here</h2>
        <br />
        <form id="form1" runat="server">
            <br />
            
            <br />
            <asp:TextBox ID="txtuser" CssClass="txtuser" runat="server" placeholder="username"></asp:TextBox>
            <br />
           
            <asp:TextBox ID="txtpass" CssClass="txtpass" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtpass" ErrorMessage="Password must contain 8 digits,atleast 1 uppercase letter,1 lowercase letter and 1 number!!" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8}$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="btnsign"  CssClass="btnsign" runat="server" Text="Sign In" OnClick="btnsign_Click" />
            <asp:Button ID="btnback"  CssClass="btnsign" runat="server" Text="Back" OnClick="btnback_Click" /><br />
            <asp:LinkButton ID="lbtnforget" CssClass="lbtnforget" runat="server" OnClick="lbtnforget_Click">Forget   Password</asp:LinkButton>
        
        
    </form>
        </div>
</body>
</html>
