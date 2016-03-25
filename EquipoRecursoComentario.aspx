<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EquipoRecursoComentario.aspx.vb" Inherits="PLWeb5_0.EquipoRecursoComentario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Comentarios</title>
    <link href="css/StyleComentarios.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="scripts/jquery-ui-1.8.6.min.js"></script>

    <script src="scripts/Comentarios.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">

  <%--  Nombre:<br/>
    <input type="text" id="name" name="name" size="40" /><br/><br/>--%>
    <div>
    Comentario:<br/>
    <textarea name="comment" id="comment" rows="6" cols="65"></textarea>
    <br/><br/>
    <div style="margin-left: 480px;">
    <input name="submit" type="submit" value="enviar" id="enviar-btn" /></div>
    </div>
    
    </form>
</body>
</html>
