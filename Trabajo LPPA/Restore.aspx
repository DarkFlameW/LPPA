<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="Trabajo_LPPA.Restore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Restore
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Restore</h1>
    <br />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" /> 
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Realizar Restore" OnClick="Button1_Click" />
    
</asp:Content>
