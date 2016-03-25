Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports System.Web.Services

Partial Public Class TimeLine_Equipo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    <WebMethod()> Public Shared Function ListaTimeLineEquipo() As List(Of InfoTimeLineEquipo)

        Dim Resultado As New List(Of InfoTimeLineEquipo)

        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            Resultado = Sistema.PL.Negocio.NegEquipo.ListaTimeLineTodoslosEquipos(oUsuario.IdUsuario)
        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ListaTimeLineTodoslosEquipos() As List(Of InfoTimeLineEquipo)

        Dim Resultado As New List(Of InfoTimeLineEquipo)

        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            Resultado = Sistema.PL.Negocio.NegEquipo.ListaTimeLineTodoslosEquipos(oUsuario.IdUsuario)
        End If
        Return Resultado
    End Function
    <WebMethod()> Public Shared Function ObtenerResenaComentarios(ByVal IdPagina As Integer, ByVal IdEquipo As Integer, ByVal Tipo As String) As List(Of InfoResenaComentarios)

        Dim Resultado As New List(Of InfoResenaComentarios)

        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            'se deb pasar por parametro el equipo
            Resultado = Sistema.PL.Negocio.NegEquipo.ObtieneResenaComentarios(IdPagina, IdEquipo, Tipo)
        End If
        Return Resultado
    End Function

    '<WebMethod()> Public Shared Function GuardarComentario(ByVal IdPagina As Integer, ByVal IdEquipo As Integer, ByVal Comentario As String, ByVal Tipo As String) As Integer

    '    Dim Resultado As Integer
    '    Dim oUsuario As New InfoUsuario()


    '    oUsuario = HttpContext.Current.Session("UsuarioConectado")
    '    If oUsuario Is Nothing Then
    '        Resultado = 0
    '    Else
    '        Dim oEquipoRecurso As New InfoEquipoRecurso()
    '        oEquipoRecurso.ID_EQUIPO = IdEquipo
    '        oEquipoRecurso.ID_USUARIO_QUE_COMPARTIO = oUsuario.IdUsuario
    '        oEquipoRecurso.PAGE_ID = IdPagina
    '        oEquipoRecurso.RESENA_RECURSO = Comentario.ToString()
    '        oEquipoRecurso.TIPO = Tipo.ToString()


    '        Resultado = Sistema.PL.Negocio.NegEquipo.RegistrarEquipoRecurso(oEquipoRecurso)
    '    End If
    '    Return Resultado
    'End Function
    <WebMethod()> Public Shared Function ObtenerCantidadComentarios(ByVal IdPagina As Integer, ByVal IdEquipo As Integer) As Integer

        Dim Result As Integer
        Dim Resultado As New InfoPaginaEquipo

        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Result = 0
        Else
            ''Se debe pasar por parametr el id_equipo
            Resultado = Sistema.PL.Negocio.NegEquipo.ObtieneDatosRecursoEquipo(IdPagina, IdEquipo)
            Result = Resultado.EXISTE_RESENA + Resultado.EXISTE_COMENTARIO

        End If
        Return Result
    End Function

End Class