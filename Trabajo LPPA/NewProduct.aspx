<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NewProduct.aspx.cs" Inherits="Trabajo_LPPA.NewProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Nuevo Producto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Nuevo Producto</h1>
    <br />
    <table>
        <tr>
            <th>Codigo:</th>
            <th><asp:TextBox ID="TxtCodigo" AutoCompleteType="Disabled" runat="server"></asp:TextBox></th>
            
        </tr>

        <tr>
            <th>Nombre:</th>
            <th><asp:TextBox ID="TxtNombre" AutoCompleteType="Disabled" runat="server"></asp:TextBox></th>
            
        </tr>
        <tr>
            <th>Imagen:</th>
            <th><asp:FileUpload ID="Imagen" AutoCompleteType="Disabled" runat="server"></asp:FileUpload></th>  
        </tr>
        <tr>
            <th>Precio:</th>
            <th><asp:TextBox ID="TxtPrecio" AutoCompleteType="Disabled" runat="server"></asp:TextBox></th>
            
        </tr>
        <tr>
            <th>Categoria:</th>
            <th><asp:TextBox ID="TxtCategoria" AutoCompleteType="Disabled" runat="server"></asp:TextBox></th>
            
        </tr>
        <tr>
            <th>
            <asp:Button ID="Guardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="Guardar_Click" />
            </th>
        </tr>
        
    </table>

</asp:Content>
