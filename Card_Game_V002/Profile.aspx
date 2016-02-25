<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Card_Game_V002.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />

    <link href="css/main.css" rel="stylesheet" type="text/css" />

    <title>G_Amigo/Profile</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <header>Profile</header>
        <section class="container-fluid">
              <label for="txtBoxFName">
                First Name <span class="lblWarning">*</span>
            </label>
            <asp:RequiredFieldValidator 
                ID="reqValFName" 
                CssClass="lblWarning" 
                runat="server" 
                ControlToValidate="txtBoxFName" 
                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator 
                ID="regexValFName"
                CssClass="lblWarning" 
                runat="server" 
                ErrorMessage="Only letters please" 
                ValidationExpression="^[a-zA-Z]{0,20}$"
                ControlToValidate="txtBoxFName"
                Display="Dynamic">
            </asp:RegularExpressionValidator>
            
<asp:TextBox CssClass="col-sm-12, form-control" ID="txtBoxFName" runat="server" 
                MaxLength="20" OnTextChanged="txtBoxFName_TextChanged"  TabIndex="1" AutoCompleteType="Disabled"></asp:TextBox>
            <label for="txtBoxLName">
                Last Name <span class="lblWarning">*</span> 
            </label>
            <asp:RequiredFieldValidator 
                ID="reqValLName" 
                CssClass="lblWarning" 
                runat="server" 
                ControlToValidate="txtBoxLName" 
                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator 
                ID="regexValLName"
                CssClass="lblWarning" 
                runat="server" 
                ErrorMessage="Only letters please" 
                ValidationExpression="^[a-zA-Z]{0,20}$"
                ControlToValidate="txtBoxLName"
                Display="Dynamic">
            </asp:RegularExpressionValidator>
            
            <asp:TextBox 
                CssClass="col-sm-12, form-control" 
                ID="txtBoxLName" 
                runat="server" MaxLength="20" TabIndex="2" 
                OnTextChanged="txtBoxLName_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>

            <label for="txtBoxEmail">
                Email Address <span class="lblWarning">*</span> 
            </label>
            <asp:RequiredFieldValidator 
                ID="reqValEmail" 
                CssClass="lblWarning" 
                runat="server" 
                ControlToValidate="txtBoxEmail" 
                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            
            <asp:CustomValidator 
                ID="custValDuplicateEmail" 
                runat="server" 
                ErrorMessage="Email already exists on file"
                CssClass="lblWarning"
                Display="Dynamic"
                ControlToValidate="txtBoxEmail"
                OnServerValidate="custValDuplicateEmail_ServerValidate">
            </asp:CustomValidator>

            <asp:TextBox 
                CssClass="col-sm-12, form-control" 
                ID="txtBoxEmail" 
                runat="server" MaxLength="50" TabIndex="3" TextMode="Email" AutoCompleteType="Disabled"></asp:TextBox>
         

          
            <br />
       
            <asp:Button 
                runat="server" 
                CssClass="btn btn-warning col-sm-2 btnStyle" 
                Text="Return" ID="btnReturn" 
                CausesValidation="False" 
                PostBackUrl="~/Login.aspx" TabIndex="7" OnClick="btnReturn_Click"/><!--Postbackurl property for return-->
            <asp:Button 
                runat="server" 
                CssClass="btn btn-primary col-sm-2 btnStyle" 
                Text="Proceed" 
                ID="btnProceed" 
                OnClick="btnProceed_Click" TabIndex="6" />

            <div class="row"></div>

            <asp:Label runat="server" ID="lblWarningDatabase" CssClass="lblWarning" 
                Visible="false">It's nothing you did... try it again or come back after we have serviced the issue</asp:Label>

            <div class="row"><br /></div>

            <div class="row"><br /></div>
        </section>
    </div>
    </form>
</body>
</html>
