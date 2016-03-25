<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Editar_Equipo.aspx.vb" Inherits="PLWeb5_0.Editar_Equipo" %>

<asp:Content ID="Contenido_Head_Equipo_Editar" ContentPlaceHolderID="head" Runat="Server">
    <title>Inicio | ParaLideres.org</title>
</asp:Content>

<asp:Content ID="Contenido_Inicial_Equipo_Editar" ContentPlaceHolderID ="ContenidoInicial" runat="server">

    <div id="EditarEquipo" runat="server" visible="false">
        <table border="1" style="margin-left: 160px"  >
        <tr>
            <td>Nombre Equipo</td>
            <td class="style1">
                <asp:TextBox ID="txtNombreEquipo" runat="server" Width="305px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp N° ID de Equipo: 
                <asp:Label ID="LblID_equipo" runat="server" Text=""></asp:Label> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                N° de Equipo_usuario:&nbsp;
                <asp:Label ID="LblEquipo_Usuario" runat="server" Font-Bold="True" 
                    ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="BtnEditarEquipo" runat="server" Text="Editar Nombre" />
            </td>
        </tr>
       </table> 
    
    </div>
</asp:Content>

<asp:Content ID="Contenido_Central_Equipo_Editar" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
 
</asp:Content>
<asp:Content ID="Contenido_Final_Equipo_Editar" ContentPlaceHolderID="ContenidoFinal" Runat="Server">

</asp:Content>