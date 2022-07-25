<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Trabajo_LPPA.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
    <link href="tecno s l.png" rel="icon" type="image/gif">
    <link rel="stylesheet" href="bootstrap-4.1.3-dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/fixed.css"/>
<style>
.body_body{
    overflow-x: hidden;
    font-family: sans-serif;
    color: #505962;
}

/*---Navbar --*/
.navbar{
    text-transform: uppercase;
    font-weight: 500;
    font-size: 1rem;
    letter-spacing: .1rem;
    background: rgba(0,0,0,0.6)!important;
}

.navbar-brand img{
    height: 2.5rem;
}

.navbar-nav li{
    padding-right: .7rem;
}

.navbar-dark .navbar-nav .nav-link {
    color: white;
    padding-top: .8rem;
}

.navbar-dark .navbar-nav .nav-link.active,
.navbar-dark .navbar-nav .nav-link:hover{
    color: #87CEFA;
}

/*--- Background: ---*/
.home-inner{
    background-image: url('fondopantalla.jpg');
}

.caption{
    width: 100%;
    max-width: 100%;
    position: absolute;
    top: 45%;
    z-index: 1;
    /*text-transform: uppercase;*/
}

.caption h1{
    font-size: 6.5em;
    font-weight: 600;
    letter-spacing: .3rem;
    padding-bottom: 1rem;
    font-family: sans-serif;
}

p{
    font-size:2em;
}
</style>
</head>
<body class="body_body" data-spy="scroll" data-target="#navbarNav"> 
    <div id="Home">
        <form id="form1" runat="server">
        <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
            <a class="navbar-brand" href="#"><img src="tecno s l.png"></a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" 
            data-target="#navbarResponsive">
                <span class="navbar-toggler-icon"></span>
            </button> 

            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="#Home">Inicio</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#Quienes">Quienes Somos</a>
                    </li>
                    <li class="nav-item" style="float:right">
                        <a class="nav-link" href="Login.aspx">Iniciar Sesion</a>
                    </li>
                </ul>
            </div>
        </nav>
            <div class="landing">
               <div class="home-wrap">
                   <div class="home-inner">
                   </div>
               </div>
            </div>   

            <div class="caption text-center">
               <h1>BIENVENIDO</h1>
            </div>
             </form>
        </div>   
    
        <div id="Quienes">
            <div class="col-12 narrow text-center">
                <h1 style="font-size:3em">QUIENES SOMOS
                </h1>
                <p>Tecnosol es una empresa situada en Lomas de Zamora, que ha dado su servicio a clientes de zona sur desde 2015. El nombre de la empresa se debe a la unión de las palabras Soluciones Tecnológicas. Nos especializamos en la venta de hardware para computadoras.</p>
            </div>
        </div>       
</body>
</html>
