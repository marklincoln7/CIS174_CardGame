<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Joey_Wilhelms_Project_Membership.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />

    <script src="scripts/jquery-2.2.0.min.js" type="text/javascript"></script>
    <script src="scripts/bootstrap.min.js" type="text/javascript"></script>

    <script>src="//html5shiv.googlecode.com/svn/trunk/html5.js"</script>

    <title></title>
</head>
<body id="loginBody">
    <form id="form1" runat="server" defaultbutton="btnLogin">
            <div class="container col-sm-4 pagination-centered" id="login">
            <header>
                <h1>G_Login</h1>
            </header>
            <section>
                <div class="container-fluid" id="UserInputArea">
                    <label>User Name</label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBoxEmail" 
                        ErrorMessage="Required" CssClass="lblWarning" ValidationGroup="mainGroup"></asp:RequiredFieldValidator>
                    <asp:TextBox CssClass="col-sm-12, form-control" ID="txtBoxEmail" runat="server" 
                        MaxLength="50"></asp:TextBox>
                   <!--Group-->

                    <label>Password</label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBoxPassword" 
                        ErrorMessage="Required" CssClass="lblWarning" ValidationGroup="mainGroup"></asp:RequiredFieldValidator>
                    <asp:TextBox CssClass="col-sm-12, form-control" ID="txtBoxPassword" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                    
                    <label>I forgot my <a href="#">password</a></label>

                    <div class="row"><br /></div><!--Spacing-->
                    
                    <asp:Button  runat="server" CssClass="btn btn-primary col-sm-2 btnStyle" Text="Login" ID="btnLogin" OnClick="btnLogin_Click" ValidationGroup="mainGroup"/>

                    <label id="passwordLink">Not a Member? <a href="Membership.aspx">Create</a></label>  

                    <div class="row"><br /></div><!--Spacing-->
                </div>
                <div class="push">
                    <aside id="WarningPanel">      
                        <asp:Label runat="server" visible="false" ID="lblLoginError" 
                         CssClass="lblWarning">Something's amiss, check your login credentials</asp:Label>  
                    </aside>
                </div>

                <footer class="modal-footer" id="footer">
                    <span id="footerContent">&copy 2016, CIS174 Card Game Team.</span>
                </footer>
            </section>
        </div>     
    </form>
</body>
</html>
