<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Equipos.aspx.vb" Inherits="PLWeb5_0.Equipos" %>


<asp:Content ID="Contenido_Head_Equipo_Crear" ContentPlaceHolderID="head" Runat="Server">
    <title>Inicio | ParaLideres.org</title>
    <link href="css/Equipos.css" rel="stylesheet" type="text/css" />
    <%--<link href="css/default.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>

<asp:Content ID="Contenido_Inicial_Equipo_Crear" ContentPlaceHolderID ="ContenidoInicial" runat="server">

    <script src="scripts/Equipos.js" type="text/javascript"></script>
   
  



</asp:Content>
<asp:Content ID="Contenido_Central_Equipo_Crear" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
 <div id="central_content">
     <div id="cnt_content">
 
   <div id="AdmEquipos"  style="width:410px">
            <table id="ListadoEquipos" class="grid" width="100%" >
                <thead>
                    <tr>
                        <th style="width:10px">
                        </th>
                        <th style="width:200px" >
                         Equipos
                        </th>
                        <th style="width:50px">
                         Usuarios
                        </th>
                        <th style="width:50px">
                            Tipo
                        </th>
                        <th colspan="2" style="width:150px">
                       
                        
                        </th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table> 
            
             </div>
             
             <div>
             
             <input type="button" id="btnCrearEq" class="link_btn_rounded"  value="Crear Equipo" />
             <input type="button" id="btnIrEquipo" class="link_btn_rounded"  value="Ir a Equipo" />
             <input type="button" id="btnInvitaciones" class="link_btn_rounded"  value="Inv. Pendientes" />
             <input type="button" id="btnConversaciones" class="link_btn_rounded"  value="Conversaciones" />
              
             <input type="hidden" id="num_eq" name="num_eq_hid" value="" />
             </div>
   
   <br />
   <br />
   <br />
   <br />
   
    <div id="MiCrearEquipo" style="display:none">
        <div class="Contenido-CrearEquipo">
            <div class="CerrarCrearEquipo">
                <a href="#" id="MiCerrarCreaEquipo">
                    <img src="images/close.png"/>
                </a>
            </div>
            <table border="1" style="margin-left: 100px"  >
                <tr>
                    <td>
                        <p>
                        <label>
                        Nombre de Equipo: 
                        </label><br />
                            <input type="text" id="txtNombreEquipo" value=""  style="width:350px"/>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>
                        <label>
                            Descripcion del Equipos:
                        </label><br />
                        <input type="text" id="txtDescripcionEquipo" value=""  style="width:350px"/>
                        </p>
                    </td>
                </tr>
                <tr>
                <td>
                    <br />
                    <p>
                </td>
                </tr>
                <tr>
                    <td align="center">
                        <input type="button" id="btn_Crear" class="link_btn_rounded"  value="Grabar" />
                    </td>
                </tr>
            </table> 
        </div>
    </div>

     <div id="MiMostrarEquipo" style="display:none">
        <div class="Contenido-MostrarEquipo">
            <div class="CerrarMostrarEquipo">
                <a href="#" id="MiCerrarMostrarEquipo">
                    <img src="images/close.png"/>
                </a>
            </div>
           <table >
            <tr>
                <td>
                     <table  >
                        <tr>
                            <td>
                                <p>
                                <label>
                                Nombre de Equipo: 
                                </label><br />
                                    <label id="lblNombre"  style="width:350px; font-weight:bold" ></label>
                                    <input type="text" id="txtnombre" value="" style="width:350px"/>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                <label>
                                    Descripcion del Equipo:
                                </label><br />
                                 <label id="lblDescripcion"  style="width:350px; font-weight:bold" ></label>
                                <input type="text" id="txtdescripcion" value=""  style="width:350px"/>
                                </p>
                            </td>
                        </tr>
                        <tr>
                        <td>
                        <input type="button" id="btnGrabar" class="link_btn_rounded"  value="Grabar" visible="false" />
                        </td>
                        </tr>
                   </table> 
                </td>
                 <td >
                    <input type="button" id="btnModificar" class="link_btn_rounded"  value="Modificar" />
                    <br/>
                    <input type="button" id="btnEliminar" class="link_btn_rounded"  value="Eliminar" />
                    <br/>
                    <input type="button" id="btnDelegar" class="link_btn_rounded"  value="Delegar" />
                    <br/>
                    <input type="button" id="btnEliminarUs" class="link_btn_rounded"  value="Eliminar Usuario" />
                    
                </td>
            </tr>

        </table>
       </div>
    </div>

 <div id="MiPopDele" style="display:none" >
        <div class="Contenido-PopUpDele">
            <div class="CerrarPopUpDele">
                <a href="#" id="MiCerrarDele">
                    <img src="images/close.png"/>
                </a>
            </div>
            <div id="Delegar" >
                <div style="width:350px">
                    <table id="tbListadoUsuarios" class="grid" width="100%" >
                        <thead>
                            <tr>
                                <th >
                                     Nombre
                                </th>
                                <th> Es Administrador </th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table> 
                    <br /> 
                    <center>
                    <input type="button" id="btnGuardar" class="link_btn_rounded" value="Delegar"  />
                    </center>
                </div>
            </div>
        </div>
    </div>

   <div id="MiPopEliminarUS" style="display:none" >
        <div class="Contenido-PopUpEliminarUS">
            <div class="CerrarPopUpEliminarUS">
                <a href="#" id="MiCerrarEliminarUS">
                    <img src="images/close.png"/>
                </a>
            </div>
            <div id="EliminarUs" >
                <div style="width:350px">
                    <table id="tbListadoUS" class="grid" width="100%" >
                        <thead>
                            <tr>
                                <th >
                                     Nombre
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table> 
                    <br /> 
                    <center>
                    <input type="button" id="btnEliminarUsuario" class="link_btn_rounded" value="Grabar"  />
                    </center>
                </div>
            </div>
        </div>
    </div>

<div id="MiPopUpPendientes" style="display:none" >
        <div class="Contenido-PopUpPendientes">
            <div class="CerrarPopUpPendientes">
                <a href="#" id="MiCerrarPendientes">
                    <img src="images/close.png"/>
                </a>
            </div>
            <div id="Pendientes" >
                <div style="width:450px">
                    <table id="tbPendientes" class="grid" width="100%" >
                        <thead>
                            <tr>
                                <th >
                                    Estos equipos esperan tu respuesta:
                                </th>
                                <th>
                                    Fecha de Invitación
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table> 
                    <center>
                    <input type="button" class="link_btn_rounded" id="btnAceptarInv" value="Aceptar" />
                    <input type="button" class="link_btn_rounded" id="btnRechazarInv" value="Rechazar" />
                    </center>
                </div>
            </div>
        </div>
    </div>
    
    
     </div>
     
 </div>
 
 
 
</asp:Content>
<asp:Content ID="Contenido_Final_Equipo_Crear" ContentPlaceHolderID="ContenidoFinal" Runat="Server">

</asp:Content>




