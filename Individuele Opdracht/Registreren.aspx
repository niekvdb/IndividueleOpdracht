<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registreren.aspx.cs" Inherits="Individuele_Opdracht.Registreren" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="shortcut icon" href="/assets/ico/favicon.ico" />

    <title>Kieskeurig</title>
     <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <!-- Custom styles for this page -->
    <link href="Registreren.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <!-- Fixed navbar -->
        <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                        <a class="navbar-brand" href="Default.aspx">Kieskeurig</a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li class="active"><a href="Registreren.aspx">Registreren</a></li>
                            <li><a href="Producten.aspx">Producten</a></li>
                             <li>
                                <asp:HyperLink href="Login.aspx" ID="LoginMenu" runat="server">Login</asp:HyperLink></li>
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
        </div>
        <div class="container">
            <div class="form-signin">
                <h2 class="form-signin-heading">Meld hier aan</h2>
                <asp:TextBox CssClass="form-control" ID="tb_voornaam" runat="server" placeholder="Email" type="text" required="required" />
                <asp:TextBox CssClass="form-control" ID="tb_pw" runat="server" type="password" placeholder="Wachtwoord" required="required" />
                <label class="checkbox">
                    <asp:CheckBox ID="cb_remember" runat="server" />
                    Onthoud mij
                </label>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="Submit" Text="Meld aan" runat="server" OnClick="Submit_Click" />
            </div>
            <div class="form-signin">
                <asp:Panel CssClass="form-control alert alert-danger" ID="InvalidLogin" runat="server" Visible="false">
                    <asp:Label ID="InvalidLoginText" runat="server" Text="Error" />
                </asp:Panel>
            </div>
        </div>
    </form>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
