<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Trabajo_LPPA.Bitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Bitacora
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="panel panel-default">
                        <div class="panel-heading">
                             Bitácora
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table">
                                        <Columns>
                                            <asp:BoundField DataField ="NickUsuario" HeaderText ="Nick"/>
                                            <asp:BoundField DataField ="Fecha" HeaderText ="Fecha"/>
                                            <asp:BoundField DataField ="Descripcion" HeaderText ="Descripcion"/>
                                            <asp:BoundField DataField ="Criticidad" HeaderText ="Criticidad"/>
                                        </Columns>    
                                    </asp:GridView>

                                </table>
                            </div>
                         </div> 
        </div> 
</asp:Content>
