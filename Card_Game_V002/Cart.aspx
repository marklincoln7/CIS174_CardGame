<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Joey_Wilhelms_Project_Membership.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />

    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <title>G_Amigo_Cart</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <header><h1>Cart</h1></header>
        <section>


            <br />

            <asp:Button CssClass="btn btn-primary" ID="btnBack" runat="server" text="Back" PostBackUrl="~/MainForm.aspx"/>
        </section>
    </div>
    </form>
</body>
</html>
