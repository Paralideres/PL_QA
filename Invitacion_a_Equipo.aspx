<%@ Page Language="vb" MasterPageFile="~/Principal.master"  AutoEventWireup="false" CodeBehind="Invitacion_a_Equipo.aspx.vb" Inherits="PLWeb5_0.Invitacion_a_Equipo" %>


 <asp:Content ID="InvitacionGrupo_head" ContentPlaceHolderID="head" Runat="Server">
     <title>Invitación a Equipo | ParaLideres.org</title>
     <link href="css/easy-autocomplete.min.css" rel="stylesheet" type="text/css" />
     <link href="css/easy-autocomplete.themes.min.css" rel="stylesheet" type="text/css" /> 
     <link href="css/Invitacion.css" rel="stylesheet" type="text/css" />
     <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
     <script src="scripts/jquery.easy-autocomplete.min.js" type="text/javascript"></script>
     
       
        
    <script language="javascript" type="text/javascript">

     function validarFormulario() 
     {
        

         document.all("ErrorEmail").style.visibility = "hidden";
         document.all("ErrorEmailPersonalizado").style.visibility = "hidden";
         document.all("ErrorEmail").style.display = 'none';
         document.all("ErrorEmailPersonalizado").style.display = 'none';

        if (document.all(oEmail).value == '') {
             document.all("ErrorEmail").style.display = 'block';
             document.all("ErrorEmail").style.visibility = "visible";
             document.all("Email").focus();
             return false;
         }
         else if (validarEmail(document.all(oEmail).value) == false) {
             document.all("ErrorEmailPersonalizado").style.display = 'block';
             document.all("ErrorEmailPersonalizado").style.visibility = "visible";
             document.all("Email").focus();
             return false;
         }

     }


     function validarEmail(valor) {
         //alert(valor);
         if (/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/.test(valor)) {
             return (true)
         }
         else {
             return (false);
         }
     }

</script>

     
</asp:Content>
<asp:Content ID="InvitacionGrupo_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">

    <script src="scripts/InvitacionEquipo.js" type="text/javascript"></script>

    <div id="breadcrumb" class="breadcrumbs">
    	<a href="../Default.aspx">Inicio</a>&raquo;<a class="actual">
    	<label id="NombreTipoEnvio" runat="server">Invitar a Equipo</label></a>
    </div>
    
    <div id="central_content">
      <div id="cnt_content">

        <div id="cnt_contentMail" visible=true style="width:650px">
           <div>
                <div>
                <p>
                <label>Seleccione Equipo:</label> <br />
                <select id="cboEjemplo">
                  <option value="">Seleccione uno...</option>
                 </select>
             <label>Seleccione Opcion de Ingreso:</label>
                                <input type="radio" id="rdoemail" name="TipoIngreso" value="email" checked="checked" />Usar E-Mail
                                <input type="radio" id="rdolibreta"name="TipoIngreso" value="libreta" /> Mi Libreta
                            </p>
                </div>
           
                <table>
                 <tr>   
                    <td>
                         <div>
                            
                          </div>
                          <div id="usa_email">
                              <p>   
                                <label for="Email">*Email:</label> <br/>
                                <%--<input type="text" name="Email" id="Email" value=""  runat="server"  size=45 maxlength=100    title="Inserte la dirección de E-mail ( tucorreo@ejemplo.com )" /> <br />
                                --%>
                                <input type="text" name="Email" id="Email" value=""   size=45 maxlength=100    title="Inserte la dirección de E-mail ( tucorreo@ejemplo.com )" /> <br />
                                <label id="ErrorEmail"   style="visibility:hidden; color:Red">* Obligatorio</label>
                                <label id="ErrorEmailPersonalizado"   style="visibility:hidden; color:Red">* Direccion Email Incorrecta</label>
                              </p>
                          </div>
                          <div id="usa_libreta">
                              <p>
                                <label id="lblLibreta">Buscar en la Libreta:</label> <br/>
                                <input type="text" id="txtNombre" value="" size=45 />
                              </p>
                          </div>
                          
				            
<%--				            <div class="clsSalto"></div>
				            <label for="selLimite">Limitar la cantidad de elementos a </label>
				            <select id="selLimite">
					            <option value="0">sin l&iacute;mite</option>
				            </select>--%>
                    </td>
                  <td style="width:100px">
                    </td>
                    <td>
                        <div id="divControles">
                            <input type="button" value="Agregar" id="btnAgregar"  />
                                 <div class="clsSalto"></div>
                                <div id="divLista"></div>
				          </div>

                       
 <%--                       <div>
                            <ul id="lista1">
                            </ul>
                        </div>--%>
                    </td>
                 </tr>
                
                </table>


               
           
              <p>
         
               <input type="button" value="Invitar a usuario" id="btnInvitar"  class="link_btn_round_md"  onclick="return validarFormulario();"  />
             <h3><label id="MensajedelEnvio" ></label></h3>
              </p>
               <input type="hidden" id="num_eq" value="" />
               <input type="hidden" id="nom_eq" value="" />
              
          </div><!--Ends cnt_content -->
      </div>
      
      
      
    </div>
    
    
    
 
    </div>

    <%--   <div id="divContenedor">
			<div id="divEjemplo">
				

					
					
				
				

			</div>
		</div>--%> 

       
    
</asp:Content>
<asp:Content ID="InvitacionGrupo_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
    
</asp:Content>
<asp:Content ID="InvitacionGrupo_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>


