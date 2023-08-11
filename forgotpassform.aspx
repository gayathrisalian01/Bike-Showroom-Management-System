<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassform.aspx.cs" Inherits="Automation.forgotpassform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="forgotpasssheet.css" rel="stylesheet" />
</head>
<body>
    <div class="forgotpbox1">
        <img src="adminclip.png" alt="alternate text" class="user"/>
        <br />
        <h2>Forgot Password</h2>
        <br />
        <form id="form2" runat="server">
            <br />
<br />
            <asp:TextBox ID="txtuser" CssClass="txtuser" runat="server" placeholder="Username"></asp:TextBox>
            <br />
            <asp:DropDownList ID="qlist" CssClass="qlist" runat="server" >
                <asp:ListItem Value="What is your birth place?">What is your birth place?</asp:ListItem>
                <asp:ListItem Value="What is your first school?">What is your first school?</asp:ListItem>
                <asp:ListItem Value="What is your first school?">What is  your blood group?</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:TextBox ID="txtans" CssClass="txtans" runat="server" placeholder="Answer"></asp:TextBox>
            <br />
            <asp:Button ID="btnsubmit" CssClass="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"/>
            <br />
                  <asp:Button ID="Button1" CssClass="btnback" runat="server" Text="Back" OnClick="Button1_Click"/>
            <br />

        </form>
    </div>
   
</body>
</html>
