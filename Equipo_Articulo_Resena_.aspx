<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Equipo_Articulo_Resena_.aspx.vb" Inherits="PLWeb5_0.Equipo_Articulo_Resena_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<link href="css/PopUp2.css" rel="stylesheet" type="text/css" />


<link type="text/css" media="screen" rel="stylesheet" href="assets/css/pl_theme/jquery-ui-1.9.0.custom.min.css" />


<script src="assets/js/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript" src="assets/js/jquery-ui.js"></script>
<script src="assets/js/guiders.min.js" type="text/javascript"></script>
<script src="assets/js/jquery.cookie.min.js" type="text/javascript"></script>
<script src="assets/js/jquery.bxslider.min.js" type="text/javascript"></script>
<script src="assets/js/init.js" type="text/javascript" language="javascript"></script>


    <script src="scripts/EquipoResena.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    
    <img src="images/Compartir.png"  id="img_compartir" alt="Compartir con Equipo" title="Compartir con Equipo" visible="true"  />
                             
    <div id="popup" style="display:none">
        <div class="content-popup">
            <div class="close">
                <a href="#" id="close">
                    <img src="images/close.png"/>
                </a>
            </div>
            <div id="MuestraResena">
                <label>Escriba alguna Reseña del articulo que quieres compartir</label> <br />
                <textarea id="Resena" name="comment" style="width:350px; height:70px"  ></textarea> <br />
                <div style="width:350px">
                    <center>
                    <input type="button" value="Compartir"  />
                    </center>
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </div>
    </form>
</body>
</html>
