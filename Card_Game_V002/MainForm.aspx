<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Joey_Wilhelms_Project_Membership.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/Bootstrap_Slate.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-2.2.0.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>

    <title>G_Amigo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <header><h1>G_Amigo</h1></header>
        <section>

<!--BEGINNING OF NAV BAR CODE -->
<nav class="navbar navbar-default">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#">Home</a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li class="active"><a href="#">Link <span class="sr-only">(current)</span></a></li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Play Game <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#">Black Jack</a></li>
            <li><a href="#">Texas Hold Em'</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="#">Separated link</a></li>
          </ul>
        </li>
      </ul>
      <ul class="nav navbar-nav navbar-right">
        <li><asp:Button ID="btnCart" runat="server" Text="Cart" CssClass="btn btn-primary" OnClick="btnCart_Click" /></li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">My Profile <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#">Trophies</a></li>
              <li><a href="#">Edit Profile</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="Login.aspx">Sign out</a></li>
          </ul>
        </li>
      </ul>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
<!--END OF NAV BAR CODE -->


<!--BEGINNING OF CAROUSEL CODE -->
<div id="myCarousel" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <!--<li data-target="#myCarousel" data-slide-to="2"></li>
    <li data-target="#myCarousel" data-slide-to="3"></li> -->
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="images/blackjack.jpe" alt="Blackjack"/>
      <div class="carousel-caption">
        <h3>BLACKJACK</h3>
        <p>Challenge yourself. Play now!.</p>
      </div>
    </div>

    <div class="item">
      <img src="images/cards.jpe" alt="Cards"/>
      <!-- <div class="carousel-caption">
        <h3>Big</h3>
        <p>smaller</p>
      </div> -->
    </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
</div>
<!--END OF CAROUSEL CODE -->

<!--BEGINNING OF FOOTER CODE 


    Possibly add footer here


<!--END OF FOOTER CODE -->
        </section>
    </div>
    </form>
</body>
</html>
