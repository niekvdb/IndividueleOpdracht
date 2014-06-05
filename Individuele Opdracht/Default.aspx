<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Individuele_Opdracht.WebForm1" %>

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
    <link href="Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                            <li><a href="Producten.aspx">Producten</a></li>
                            <li>
                                <asp:HyperLink href="Login.aspx" ID="LoginMenu" runat="server">Login</asp:HyperLink></li>
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
 </div>
         <!-- Carousel
    ================================================== -->
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="item active">
                        <img data-src="holder.js/900x500/auto/#777:#7a7a7a/text:First slide" alt="First slide">
                        <div class="container">
                            <div class="carousel-caption">
                                <h1>Welkom op Kieskeurig!</h1>
                                <p>De vergelijksite van Nederland. Bekijk hier al de producten die u maar wilt en vergelijk ze met andere producten van dezelfde soort</p>
                                <p><a class="btn btn-lg btn-primary" href="Registreren.aspx" role="button">Meld u nu aan!</a></p>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <img data-src="holder.js/900x500/auto/#666:#6a6a6a/text:Second slide" alt="Second slide">
                        <div class="container">
                            <div class="carousel-caption">
                                <h1>Begin nu met vergelijken en klik bovenaan op Producten</h1>
                                <p>Vind u een product leuk? Dan aarzel niet en bestel bij de goedkoopste webshop</p>
                                <p><a class="btn btn-lg btn-primary" href="Registreren.aspx" role="button">Meld u nu aan!</a></p>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <img data-src="holder.js/900x500/auto/#555:#5a5a5a/text:Third slide" alt="Third slide">
                        <div class="container">
                            <div class="carousel-caption">
                                <h1>One more for good measure.</h1>
                                <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                                <p><a class="btn btn-lg btn-primary" href="Registreren.aspx" role="button">Browse gallery</a></p>
                            </div>
                        </div>
                    </div>
                </div>
                <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a>
                <a class="right carousel-control" href="#myCarousel" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
            </div>
            <!-- /.carousel -->



    </div>
    </form>
     <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
