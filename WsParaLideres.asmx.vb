Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Sistema.PL.Entidad
Imports System.Web.Script.Serialization
Imports Sistema.PL.Filtros
Imports Sistema.PL.Negocio

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la siguiente línea.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WsParaLideres
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hola a todos"
    End Function

    <WebMethod()> Public Function TraerUsuario()

        'Dim strResultado As String
        Dim oUsuario As New InfoUsuario()
        Dim Usuario As New Usuario


        oUsuario = Usuario.TraerUsuario("kcoglezz@gmail.com", "1")
        ' strResultado = oUsuario.Nombre


        Dim js As New JavaScriptSerializer

        'Dim p1 As New Persona("Dani", "12345678J")

        Dim contentDisposition As String = " filename=prova.json"
        Context.Response.AddHeader("Content-Disposition", contentDisposition)
        Context.Response.ContentType = "application/json"
        Context.Response.Write(js.Serialize(oUsuario))
        Context.Response.End()

        'oUsuario = HttpContext.Current.Session("UsuarioConectado")
        'If oUsuario Is Nothing Then
        '    Resultado = 0
        'Else
        '    Dim oEquipoRecursoComentario As New InfoEquipoRecursoComentario()
        '    oEquipoRecursoComentario.ID_EQUIPO = oUsuario.ID_Equipo
        '    oEquipoRecursoComentario.ID_USUARIO_QUE_COMENTO = oUsuario.IdUsuario
        '    oEquipoRecursoComentario.COMENTARIO = Comentario.ToString()


        '    Resultado = 1 'Sistema.PL.Negocio.NegEquipo.RegistrarEquipoRecursoComentario(oEquipoRecursoComentario)
        'End If
        'Return strResultado
    End Function

    <WebMethod()> Public Function BuscarByFiltros(ByVal Anio As Integer, ByVal pagina As Integer)

        Dim olistaPreguntas As New List(Of InfoPregunta)
        Dim oFiltro As New FiltroPregunta

        oFiltro.Anio = Now.Year
        oFiltro.Numero = pagina
        olistaPreguntas = Sistema.PL.Negocio.Pregunta.BuscarByFiltros(oFiltro)
        Dim js As New JavaScriptSerializer

        'Dim p1 As New Persona("Dani", "12345678J")

        Dim contentDisposition As String = " filename=prova.json"
        Context.Response.AddHeader("Content-Disposition", contentDisposition)
        Context.Response.ContentType = "application/json"
        Context.Response.Write(js.Serialize(olistaPreguntas))
        Context.Response.End()


    End Function

    <WebMethod()> Public Function Es_Administrador_de_algun_Equipo(ByVal email As String, ByVal pass As String)


        Dim oUsuario As New InfoUsuario()
        'Dim Usuario As New Usuario
        Dim Es_Administrador As Integer = 0

        'oUsuario = HttpContext.Current.Session("UsuarioConectado")
        oUsuario = Usuario.TraerUsuario(email, pass)

        Es_Administrador = NegEquipo.Es_Administrador_de_algun_Equipo(oUsuario.IdUsuario)


        Dim js As New JavaScriptSerializer


        Dim contentDisposition As String = " filename=prova.json"
        Context.Response.AddHeader("Content-Disposition", contentDisposition)
        Context.Response.ContentType = "application/json"
        Context.Response.Write(js.Serialize(Es_Administrador))
        Context.Response.End()


    End Function

    <WebMethod()> Public Function Lista_Libreta_Usuarios(ByVal Id_Usuario_Admin As Integer)

        Dim oListaUsuarios As New List(Of InfoLibretaUsuarioEquipo)
        Dim js As New JavaScriptSerializer

        oListaUsuarios = Sistema.PL.Negocio.NegEquipo.Lista_Libreta_Usuarios_Del_Equipo(Id_Usuario_Admin)

        Dim contentDisposition As String = " filename=prova.json"
        Context.Response.AddHeader("Content-Disposition", contentDisposition)
        Context.Response.ContentType = "application/json"
        Context.Response.Write(js.Serialize(oListaUsuarios))
        Context.Response.End()
    End Function



    
End Class