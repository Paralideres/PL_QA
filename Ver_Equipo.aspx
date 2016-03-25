<%@ Page Language="vb" MasterPageFile="~/Principal.master"  AutoEventWireup="false" CodeBehind="Ver_Equipo.aspx.vb" Inherits="PLWeb5_0.Ver_Equipo" %>

<asp:Content ID="Contenido_Head_Equipo_Ver" ContentPlaceHolderID="head" Runat="Server">
    <title>Inicio | ParaLideres.org</title>
   <link href="css/AdmEquipo.css" rel="stylesheet" type="text/css" />
    <link href="css/default.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Contenido_Inicial_Equipo_Ver" ContentPlaceHolderID ="ContenidoInicial" runat="server">
    
    <script src="scripts/AdmEquipo.js" type="text/javascript"></script>
    
    <div id="VerInfoEquipo" runat="server">
        <label id="LblTextoEquipo" runat="server"> </label>
        <label id="NombreEquipo"   style="color:Red; font-size:large" ></label>
        <br />
        <br />
        <label>Donde actualmente hay </label>
        <label id="CantidadUsuarios"  style="color:Blue; font-size:medium"> </label>
        <label> Usuarios</label>
   
    </div> 
     <br />
      <br />
       <br />   
    <div id="AdministrarEquipo" runat="server" visible="false">
        <input type="button" id="btn_ModificarEQ" class="link_btn_rounded"  value="Modificar" />
        <input type="button" id="btn_EliminarEQ"  class="link_btn_rounded"  value="Eliminar Equipo" />
        <input type="button" id="btn_DelegarEQ"  class="link_btn_rounded" value="Delegar Equipo" />
    </div>
    <br /> 
    <div>
        <input type="button" id="btn_VerUsuarios"  class="link_btn_rounded" value="Ver Usuarios" />
    </div>
     <div id="MiPopMod" style="display:none" >
        <div class="Contenido-PopUpMod">
            <div class="CerrarPopUpMod">
                <a href="#" id="MiCerrarMod">
                    <img src="images/close.png"/>
                </a>
            </div>
            <div id="CambioNombre" >
                <input id="txtNombre" type="text" value="" />
                <div style="width:350px">
                    <center>
                    <input type="button" id="btnGrabar" class="btn-action" value="Grabar"  />
                    </center>
                </div>
            </div>
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
                    <input type="button" id="btnDelegar" class="link_btn_rounded" value="Delegar"  />
                    </center>
                </div>
            </div>
        </div>
    </div>
    
     <div id="MiPopVerUsu" style="display:none" >
        <div class="Contenido-PopUpVerUsu">
            <div class="CerrarPopUpVerUsu">
                <a href="#" id="MiCerrarVerUsu">
                    <img src="images/close.png"/>
                </a>
            </div>
    
            <div id="DivVerUsuarios" >
                <div style="width:350px">
                
                    <table id="tbListadodeUsuarios" class="grid" width="100%" >
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
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>

<asp:Content ID="Contenido_Central_Equipo_Ver" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
 
</asp:Content>
<asp:Content ID="Contenido_Final_Equipo_Ver" ContentPlaceHolderID="ContenidoFinal" Runat="Server">

</asp:Content>