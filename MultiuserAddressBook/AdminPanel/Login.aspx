<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="MultiuserAddressBook_AdminPanel_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="row">
            <div class="col-md-12 text-center">
                <h1>Existing User Login To Address Book</h1>
            </div>
        </div>
         <div class="row">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                User Name
            </div>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="txtUserNameLogin" CssClass="form-control"/><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Password
            </div>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control"/><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                
            </div>
            <div class="col-md-6">
                <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-primary btn-sm" OnClick="btnLogin_Click" />
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-12 text-center">
                <h1>Register YourSelf</h1><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                UserName
            </div>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" /><br /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Password
            </div>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="txtPasswordRegister" CssClass="form-control" /><br /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Display Name
            </div>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="txtDisplayName" CssClass="form-control" /><br /><br />
            </div>
            </div>
        <div class="row">
            <div class="col-md-2">
                Mobile No
            </div>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" /><br /><br />
            </div>
            </div>
        <div class="row">
            <div class="col-md-2">
                Email
            </div>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" /><br /><br />
            </div>
            </div>
         <div class="row">
            <div class="col-md-2">
                
            </div>
            <div class="col-md-6">
                <asp:Button runat="server" ID="Register" Text="Register" CssClass="btn btn-primary btn-sm" OnClick="Register_Click"  />
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
