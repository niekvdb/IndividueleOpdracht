<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Producten.aspx.cs" Inherits="Individuele_Opdracht.Producten" %>

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
    <link href="Producten.css" rel="stylesheet" />

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
                            <li>
                            <asp:HyperLink href="Registreren.aspx" ID="RegMenu" runat="server">Registreren</asp:HyperLink></li>
                
                            <li class="active"><a href="Producten.aspx">Producten</a></li>
                             <li>
                                <asp:HyperLink href="Login.aspx" ID="LoginMenu" runat="server">Login</asp:HyperLink></li>
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>

        </div>
<div class="container">
            <h1>Alle Producten</h1>
            <p>Voeg hier uw Producten toe </p>
            <div class="lead2">
                <asp:TextBox ID="TextBox2" runat="server" Width="100px" Height="30px" > </asp:TextBox>   
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="Btn_Zoek" runat="server" Text="Zoek" Width="100px" OnClick="Btn_Zoek_Click"  />                                                
                       <asp:TextBox ID="TextBox1" runat="server" Width="600px" Height="200px" TextMode="MultiLine" >                                                    
                           </asp:TextBox>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="Btn_Review" runat="server" Enabled="false" Text="PlaatsReview" OnClick="Btn_Review_Click"  />
                 <asp:TextBox  ID="Tbox_Review_titel" runat="server" Text="Titel"  />
                 <asp:TextBox  ID="Tbox_Review_Reactie" runat="server" Text="Review"  />
                <asp:TextBox  ID="Tbox_Review_score" runat="server" Text="Score"  />
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="Btn_PlaatsVraag" runat="server" Enabled="false" Text="PlaatsVraag" OnClick="Btn_PlaatsVraag_Click"  />
                 <asp:TextBox  ID="Tbox_Vraag_titel" runat="server" Text="Titel"  />
                 <asp:TextBox  ID="Tbox_Vraag_Vraag" runat="server" Text="Vraag"  />
                </div>
            <!-- Listbox -->
            <div class="lead">
                <asp:ListBox ID="lbox_Rentables" runat="server" >
                  
                </asp:ListBox>
            </div>


            <!--Add Item Button -->
            <div class="form-register">
                 <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="btn_Refresh" runat="server" Text="Toon Producten" OnClick="btn_Refresh_Click" />
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="btn_AddItem" runat="server" Text="Voeg toe" OnClick="btn_AddItem_Click" />
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="btn_ShowINfo" runat="server" Text="Laat informatie zien" OnClick="btn_ShowINfo_Click" />
            </div>
            <!-- Item -->
            <div class="row">
                <div class="col-md-4" runat="server" id="div1">
                    <asp:TextBox ID="txt_Chosen1" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                    <asp:Label ID="Label10" runat="server" Text="€"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
                </div>
                <div class="remove">
                    <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="Remove1" runat="server" Text="X" Height="45px" Width="45px" OnClick="Remove1_Click" />
                </div>
            </div>
            <!-- Item -->
            <div class="row">
                <div class="col-md-4" runat="server" id="div2">
                    <asp:TextBox ID="txt_Chosen2" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                    <asp:Label ID="Label9" runat="server" Text="€"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
                </div>
                <div class="remove">
                    <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="Remove2" runat="server" Text="X" Height="45px" Width="45px" OnClick="Remove2_Click" />
                </div>
            </div>
            <!-- Item -->
            <div class="row">
                <div class="col-md-4" runat="server" id="div3">
                    <asp:TextBox ID="txt_Chosen3" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="€"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                </div>
                <div class="remove">
                    <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="Remove3" runat="server" Text="X" Height="45px" Width="45px" OnClick="Remove3_Click" />
                </div>
            </div>
            <!-- Item -->
            <div class="row">
                <div class="col-md-4" runat="server" id="div4">
                    <asp:TextBox ID="txt_Chosen4" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" Text="€"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="0"></asp:Label>
                </div>
                <div class="remove">
                    <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="Remove4" runat="server" Text="X" Height="45px" Width="45px" OnClick="Remove4_Click" />
                </div>
            </div>
            <!-- Item -->
            <div class="row">
                <div class="col-md-4" runat="server" id="div5">
                    <asp:TextBox ID="txt_Chosen5" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                     <asp:Label ID="Label6" runat="server" Text="€"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text="0"></asp:Label>
                </div>
                <div class="remove">
                    <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="Remove5" runat="server" Text="X" Height="45px" Width="45px" OnClick="Remove5_Click" />
                </div>
            </div>

            <div class="label">
                <asp:Label ID="Label11" runat="server" Text="Totaal: €"></asp:Label>
                <asp:Label ID="Totaal" runat="server" Text="0"></asp:Label>
            </div>
            <!--Finish Button -->
            <div class="form-register">
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="btn_Finish" runat="server" Text="Bevestig" OnClick="btn_Finish_Click" />
            </div>
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
