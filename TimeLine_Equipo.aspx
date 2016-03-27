<%@ Page Language="vb"  MasterPageFile="~/Principal.master"  AutoEventWireup="false" CodeBehind="TimeLine_Equipo.aspx.vb" Inherits="PLWeb5_0.TimeLine_Equipo" %>



<asp:Content ID="Contenido_Head_Equipo_TimeLine" ContentPlaceHolderID="head" Runat="Server">
    <title>Inicio | ParaLideres.org</title>
    
    <link href="css/Timeline.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Contenido_Inicial_Equipo_TimeLine" ContentPlaceHolderID ="ContenidoInicial" runat="server">
<script src="scripts/TimeLine.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Contenido_Central_Equipo_TimeLine" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
 
<div id="central_content">
<input type="hidden" id="num_pag" name="num_pag_hid" value="" />

<input type="hidden" id="num_eq" name="num_eq_hid" value="" />

<div id="cnt_content">


        <div id="DivVerTimeLine" >
                <div style="width:550px">
                
                    <table id="tbTimeLine"  width="100%" >
                        <thead>
                            <tr>
                                <th  >
                                     Equipo
                                </th>
                                <th  >
                                     Articulo
                                </th>
                                <th >
                                     Comentarios
                                </th>
                                <th >
                                     Fecha 
                                </th>
                                
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table> 
                </div>
            </div>
            
      <div id="MiPopUpCom" style="display:none; overflow-y: scroll">
        <div class="Contenido-PopUpCom">
            <div class="CerrarPopUpCom">
                <a href="#" id="MiCerrarCom">
                    <img src="images/close.png"/>
                </a>
            </div>
            <div id="MuestraComentarios">
                <div id="ResenaInicial">
                    <table id="tbResultadoResenaComentarios" class="grid" width="100%" >
                    <tbody>
                    </tbody>
                </table>    
                </div>
                <div id="ComentariosAnteriores">
                    
                </div>
                <label>Comentario:</label> <br />
                <textarea id="Comentario" name="comment" style="width:350px; height:70px"  ></textarea> <br />
                <div style="width:350px">
                    <center>
                    <input type="button" id="btnComentar" value="Comentar"  />
                    </center>
                  
                   <%-- <input id="PageId" name="PageId" type="hidden" visible="false" value=""  />--%>
                </div>
            </div>

        </div>
      </div>
</div>
 <input type="hidden" id="num_eq_rec" name="num_eq_rec_hid" value="" />
 </div>
</asp:Content>
<asp:Content ID="Contenido_Final_Equipo_TimeLine" ContentPlaceHolderID="ContenidoFinal" Runat="Server">

</asp:Content>