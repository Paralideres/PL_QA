Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports System.Web.Services

Partial Public Class Ver_Equipo
    Inherits System.Web.UI.Page
    Dim oUsuario As New InfoUsuario()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        oUsuario = Session("UsuarioConectado")
        ' se debe cambiar esta pagina 20_02_2016
        '' '' ''If oUsuario.Es_Administrador_Equipo = True Then
        '' '' ''    VerInfoEquipo.Visible = True
        '' '' ''    LblTextoEquipo.Visible = True
        '' '' ''    LblTextoEquipo.InnerText = "Tu Administras el Equipo :"
        '' '' ''    AdministrarEquipo.Visible = True

        '' '' ''    'NombreEquipo.InnerText = oUsuario.Nombre_Equipo.ToString()
        '' '' ''    'CantidadUsuarios.InnerText = oUsuario.Cantidad_Usuarios
        '' '' ''Else
        '' '' ''    VerInfoEquipo.Visible = True
        '' '' ''    LblTextoEquipo.Visible = True
        '' '' ''    LblTextoEquipo.InnerText = "Tu estas en el Equipo :"
        '' '' ''    AdministrarEquipo.Visible = False
        '' '' ''    'Dim strMensaje As String
        '' '' ''    'strMensaje = "Hola, tu todavia no has creado un Equipo, Cuando Crees un Equipo, aqui podras ver el nombre y la cantidad de usuarios"
        '' '' ''    'Response.Write("<script language = 'javascript'>alert('" & strMensaje & "'); window.location.href = './Default.aspx'; </script>")
        '' '' ''End If

    End Sub

    <WebMethod()> Public Shared Function MostrarNombreEquipo() As String

        Dim Resultado As String
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 s debe pasar por parametro el id_equipo
            Resultado = Nothing 'Sistema.PL.Negocio.NegEquipo.MostrarNombreEquipo(oUsuario.ID_Equipo)
        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ModificarEquipo(ByVal strNombre As String) As String

        Dim Resultado As String
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = ""
        Else
            '20_02_2016 se deba pasar por parametro el id_equipo y luego asignarlo a alguna clase valida
            'Sistema.PL.Negocio.NegEquipo.CambiarNombreDelEquipo(oUsuario.IdUsuario, oUsuario.ID_Equipo, strNombre.ToString())
            Resultado = "" 'strNombre
            'oUsuario.Nombre_Equipo = strNombre
        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function EliminarEquipo() As Integer

        Dim Resultado As Integer
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 se debe pasar por parametro el id_equipo
            Resultado = Nothing 'Sistema.PL.Negocio.NegEquipo.EliminarEquipo(oUsuario.IdUsuario, oUsuario.ID_Equipo)
        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function CantidadUsuariosxEquipo() As Integer

        Dim Resultado As Integer
        Dim oListResultado As New List(Of InfoUsuarioEquipo)
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = 0
        Else
            '20_02_2016 se debe pasar por parametro el id_equipo
            'oListResultado = Sistema.PL.Negocio.NegEquipo.Traer_Usuarios_Del_Equipo(oUsuario.ID_Equipo)
            Resultado = 0 'oListResultado.Count
        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ListadeUsuariodeEquipo() As List(Of InfoUsuarioEquipo)

        Dim Resultado As New List(Of InfoUsuarioEquipo)
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 se debe pasar por parametro el id_equipo
            Resultado = Nothing 'Sistema.PL.Negocio.NegEquipo.Traer_Usuarios_Del_Equipo(oUsuario.ID_Equipo)

        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function DelegarEquipo(ByVal ID_Usuario_nuevo) As Integer

        Dim Resultado As Integer
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 se debe pasar por parametro e id_equipo
            Resultado = Nothing 'Sistema.PL.Negocio.NegEquipo.DelegarEquipo(oUsuario.IdUsuario, ID_Usuario_nuevo, oUsuario.ID_Equipo)
        End If
        Return Resultado
    End Function


End Class