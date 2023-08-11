<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newhome.aspx.cs" Inherits="Automation.newhome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="newhome.css" rel="stylesheet" />
</head>
<body>
    <section>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" CssClass="customwidth" HorizontalAlign="center" runat="server">
        
        <div id="menu">
            <ul>
                <li><a href="newsupplier.aspx">SUPPLIER</a>
                 </li>  
                    
                <li><a href="product.aspx">
                    PRODUCT</a>
                </li>

                <li><a href="customer.aspx">CUSTOMER</a>
                </li>

                <li><a href="a">SALES</a>
                </li>

                <li><a href="purchaseorder.aspx">PURCHASE</a>
                </li>
            </ul>
        </div></asp:Panel>
    </form>
</section>
</body>
</html>
