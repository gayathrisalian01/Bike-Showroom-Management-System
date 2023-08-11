<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepassform.aspx.cs" Inherits="Automation.changepassform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="changepassstylesheet.css" rel="stylesheet" />
</head>
<body>
   
       
                  <div  class="changepbox1">
          <img src="adminclip.png" alt="alternate text" class="user"/>
      <br />
        <h2>Change Password</h2>
        <br />
        <form id="form2" runat="server">
            <asp:TextBox ID="txtuser" CssClass="txtuser" runat="server" placeholder="Username"></asp:TextBox>
            <br />
           <asp:TextBox ID="txtopass" CssClass="txtopass" runat="server" placeholder="Old Password" TextMode="Password"></asp:TextBox>
            <br />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtopass" ErrorMessage="Password must contain 8 digits,atleast 1 uppercase letter,1 lowercase letter and 1 number!!" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8}$"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="txtnpass" CssClass="txtnpass" runat="server" placeholder="New Password" TextMode="Password" MaxLength="8"  ></asp:TextBox>
            <br />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtnpass" ErrorMessage="Password must contain 8 digits,atleast 1 uppercase letter,1 lowercase letter and 1 number!!" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8}$"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="txtcpass" CssClass="txtcpass" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
            <br />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtcpass" ErrorMessage="Password must contain 8 digits,atleast 1 uppercase letter,1 lowercase letter and 1 number!!" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8}$"></asp:RegularExpressionValidator>
            <asp:Button ID="btnsave"  CssClass="btnsave" runat="server" Text="Save and Continue" OnClick="btnsave_Click" />
            <br />
             <asp:Button ID="btncancel"  CssClass="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
            <asp:LinkButton ID="linksque" runat="server" OnClick="linksque_Click">Change Sequrity Question</asp:LinkButton>
        
          </form>

        </div>
  
</body>
</html>
