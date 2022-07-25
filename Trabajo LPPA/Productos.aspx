<%@ Page Title="" Language="C#" MasterPageFile="~/Clientes.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Trabajo_LPPA.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>
        Bienvenido! Elija el producto a comprar
    </h1>
    <br/>
    <br/>
     <div class="panel panel-default">
                        <div class="panel-heading">
                             Productos
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="GridView1_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField ="Nombre" HeaderText ="Nombre" />
                                            <asp:BoundField DataField ="Precio" HeaderText ="Precio"/>
                                            <asp:ButtonField ButtonType="Button" CommandName="Editar" HeaderText="Seleccionar producto" Text="Agregar al carrito" />
                                        </Columns>    
                                    </asp:GridView>
                                </table>
                            </div>
                         </div> 
        </div> 
</asp:Content>
