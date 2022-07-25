<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarProducto.aspx.cs" Inherits="Trabajo_LPPA.ModificarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Modificar Producto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TecnoSolConnectionString2 %>" SelectCommand="SELECT [CodProd], [Nombre], [Imagen], [Precio], [Categoria] FROM [Producto]"></asp:SqlDataSource>
        Modificar Producto</h1>
    <br />
    <table>
        <tr>
            <th>Codigo:</th>
            <th><asp:TextBox ID="TxtCodigo" runat="server"></asp:TextBox></th>
            
        </tr>
        <tr>
            <th>Nombre:</th>
            <th><asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox></th>
            
        </tr>
        <tr>
            <th>Imagen:</th>
            <th><asp:TextBox ID="TxtImagen" runat="server"></asp:TextBox></th>
            
        </tr>
        <tr>
            <th>Precio:</th>
            <th><asp:TextBox ID="TxtPrecio" AutoCompleteType="Disabled" runat="server"></asp:TextBox></th>
            
        </tr>
        <tr>
            <th>Categoria:</th>
            <th><asp:TextBox ID="TxtCategoria" runat="server"></asp:TextBox></th>
            
        </tr>
        <tr>
            <th>
            <asp:Button ID="Guardar" runat="server" CssClass="btn btn-primary" Text="Modificar Producto" OnClick="Guardar_Click" />
            </th>
        </tr>
        
    </table>
    <br />
    <div class="panel panel-default">
                        <div class="panel-heading">
                             Productos
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="table">
                                        <Columns>
                                            <asp:BoundField DataField ="CodProd" HeaderText ="Codigo"/>
                                            <asp:BoundField DataField ="Nombre" HeaderText ="Nombre"/>
                                            <asp:BoundField DataField ="Imagen" HeaderText ="Precio"/>
                                            <asp:BoundField DataField ="Precio" HeaderText ="Precio"/>
                                            <asp:BoundField DataField ="Categoria" HeaderText ="Categoria"/>
                                            <asp:ButtonField ButtonType="Button" CommandName="Editar" HeaderText="Modificar Producto" Text="Seleccionar Producto" />
                                        </Columns>    
                                    </asp:GridView>

                                    

                                </table>
                            </div>
                         </div> 
        </div> 


</asp:Content>
