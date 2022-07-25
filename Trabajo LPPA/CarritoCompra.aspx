<%@ Page Title="" Language="C#" MasterPageFile="~/Clientes.Master" AutoEventWireup="true" CodeBehind="CarritoCompra.aspx.cs" Inherits="Trabajo_LPPA.CarritoCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Carrito Compra
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="panel panel-default">
                        <div class="panel-heading">
                             Carrito Compra
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example"> 
                                    <asp:DataGrid runat="server" ID="listaProductos" CssClass="table"></asp:DataGrid>
                                </table>
                            </div>
                         </div> 
        </div> 
    <br />
    <br />
    <asp:Button OnClick="btnComprar_Click" CssClass="btn btn-primary" runat="server" ID="btnComprar" Text="Comprar" />
</asp:Content>
