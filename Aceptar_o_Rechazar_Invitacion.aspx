<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Aceptar_o_Rechazar_Invitacion.aspx.vb" Inherits="PLWeb5_0.Aceptar_o_Rechazar_Invitacion" %>

 <asp:Content ID="AceptarRechazar_head" ContentPlaceHolderID="head" Runat="Server">
        <title>Invitación a Grupo | ParaLideres.org</title>

</asp:Content>
<asp:Content ID="AceptarRechazar_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	<a href="../Default.aspx">Inicio</a>&raquo;<a class="actual">
    	<label id="NombreTipoEnvio" runat="server">Invitación a Grupo</label></a>
    </div>
    <div id="central_content">
      <div id="cnt_content">
    	    <div id="cnt_contentGuardar" runat="Server" visible=false>
              <h3><label id="MensajedelEnvio" runat="server"></label>!</h3>
            </div> 
         <div id="cnt_contentMail" runat="Server" visible=true>
              <div class="reg_fields_box" id="div_ACE_REC" runat="Server" visible="false">
                  <label> Nombre del Equipo:
                  </label>
                     <label ID="lblNombreEquipo" runat="server" style="color:Blue"></label>
                    <br />
                    <p></p>
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar ser Parte"  CssClass ="link_btn_round_md"  />  
                    <asp:Button ID="btnRechazar" runat="server" Text="Rechazo ser Parte"  CssClass ="link_btn_round_md"  />
                
                </div>
               </div>
         </div>
  </div>
</asp:Content>
<asp:Content ID="AceptarRechazar_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">

</asp:Content>
<asp:Content ID="AceptarRechazar" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>
