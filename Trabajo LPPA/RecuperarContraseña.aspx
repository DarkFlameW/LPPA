<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="Trabajo_LPPA.RecuperarContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cambio contraseña</title>
    <link href="Estilos.css" rel="stylesheet" />
</head>
<body class="login body_body">
    <div class="loginbox">
         <h2>Cambio contraseña</h2>
        <form id="form1" runat="server">
            <asp:Label Text="Mail" CssClass="lblnick" runat="server" />
            <asp:TextBox ID="TxtMail" runat="server" placeholder="Ingrese mail" CssClass="txtnick" AutoCompleteType="Disabled" ></asp:TextBox>
            <asp:Label Text="Contraseña generada" CssClass="lblpass" runat="server" />  
            <asp:TextBox ID="TxtContraseñaGenerada" runat="server" placeholder="Ingrese Contraseña" AutoCompleteType="Disabled" EnableViewState="False" TextMode="Password" CssClass="txtpass"></asp:TextBox>
            <asp:Label Text="Contraseña nueva" CssClass="lblnick" runat="server" />
            <asp:TextBox ID="TxtContraseñaNueva" runat="server" placeholder="Ingrese nueva contraseña" CssClass="txtnick" AutoCompleteType="Disabled" ></asp:TextBox>
            <asp:Button ID="BtnIngresar" runat="server" Text="Cambiar contraseña" CssClass="btningresar" OnClick="BtnIngresar_Click" />
        </form>       
     </div>
</body>
</html>
