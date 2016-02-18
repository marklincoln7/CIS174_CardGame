<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Membership.aspx.cs" Inherits="Joey_Wilhelms_Project_Membership.Membership" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />

    <link href="css/main.css" rel="stylesheet" type="text/css" />


    <title></title>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnProceed">
    <div class="container">
        <header><h1>Membership</h1></header>
        <section>
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
            <label for="txtBoxPassword">
                Password <span class="lblWarning">*</span>
            </label>
            <asp:RequiredFieldValidator 
                ID="reqValPassword" 
                CssClass="lblWarning" 
                runat="server" 
                ControlToValidate="txtBoxPassword" 
                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>

                   <asp:CustomValidator 
                ID="custValInvalidPassword" 
                runat="server" 
                ErrorMessage="Your password was too weak"
                CssClass="lblWarning"
                Display="Dynamic"
                ControlToValidate="txtBoxPassword"
                OnServerValidate="CustValPassword_ServerValidate" 
                ></asp:CustomValidator>
       
            <asp:TextBox 
                CssClass="col-sm-12, form-control" 
                ID="txtBoxPassword" 
                runat="server" MaxLength="20" TabIndex="4"
                TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>

            <label for="txtBoxVPassword">
                Verify Password <span class="lblWarning">*</span>
            </label>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                CssClass="lblWarning" ErrorMessage="Passwords must match" ControlToCompare="txtBoxPassword" 
                ControlToValidate="txtBoxVPassword" EnableClientScript="true"></asp:CompareValidator>
            <asp:TextBox 
                CssClass="col-sm-12, form-control" 
                ID="txtBoxVPassword" 
                runat="server" MaxLength="20" TabIndex="5" TextMode="Password" AutoCompleteType="Disabled" CausesValidation="True"></asp:TextBox>
            <br />
       
            <asp:Button 
                runat="server" 
                CssClass="btn btn-warning col-sm-2 btnStyle" 
                Text="Return" ID="btnReturn" 
                CausesValidation="False" 
                PostBackUrl="~/Login.aspx" TabIndex="7"/><!--Postbackurl property for return-->
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="System.Data.SqlServerCe.4.0"></asp:SqlDataSource>
    </form>
</body>
</html>
