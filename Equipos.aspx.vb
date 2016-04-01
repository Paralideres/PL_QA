Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports System.Web.Services

Partial Public Class Equipos
    Inherits System.Web.UI.Page
    Dim oUsuario As New InfoUsuario()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        oUsuario = Session("UsuarioConectado")
        'If oUsuario.Es_Administrador_Equipo = True Then
        '    CrearEquipo.Visible = False
        '    BtnCrearEquipo.Enabled = False
        '    Dim strMensaje As String
        '    strMensaje = "Hola, tu ya has creado un Equipo, solo puedes ser admnistrador de un Equipo!"
        '    Response.Write("<script language = 'javascript'>alert('" & strMensaje & "'); window.location.href = './Ver_Equipo.aspx'; </script>")
        '    'Response.Redirect("../Default.Aspx")
        'Else
        'BtnCrearEquipo.Enabled = True
        'CrearEquipo.Visible = True
        'End If

    End Sub

    'Protected Sub BtnIngresar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnIngresar.Click
    '    oUsuario = Usuario.TraerUsuario(txtEmail.Text.ToString(), txtClave.Text.ToString())
    '    If oUsuario.Encontrado Then
    '        LblUsuarioConectado.Text = oUsuario.IdUsuario
    '        'Equipos.Visible = True
    '        'Equipo.Visible = True
    '    End If
    'End Sub

    'Protected Sub BtnCrearEquipo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCrearEquipo.Click
    'Dim oEquipo As New InfoEquipo
    'oUsuario = Session("UsuarioConectado")

    'oEquipo.NOMBRE_EQUIPO = txtNombreEquipo.Text.ToString()
    'oEquipo.ID_USUARIO_ADMINISTRADOR = oUsuario.IdUsuario
    'oEquipo.ESTADO = "1"
    'oEquipo.USUARIO_CREACION = oUsuario.IdUsuario

    'Dim oNegEquipo As New NegEquipo

    'Dim intIdEquipo As Integer

    'intIdEquipo = NegEquipo.RegistrarEquipo(oEquipo)
    'LblID_equipo.Text = intIdEquipo

    'Dim oEquipoUsuario As New InfoEquipoUsuario

    'oEquipoUsuario.ID_USUARIO = oUsuario.IdUsuario
    'oEquipoUsuario.ID_EQUIPO = intIdEquipo
    'oEquipoUsuario.ES_ADMINISTRADOR = "S"
    'oEquipoUsuario.USUARIO_CREACION = oUsuario.IdUsuario

    'Dim intIdEquipoUsuario As Integer
    'intIdEquipoUsuario = NegEquipo.RegistrarEquipoUsuario(oEquipoUsuario)

    'LblEquipo_Usuario.Text = intIdEquipoUsuario

    'End Sub

    <WebMethod()> Public Shared Function DatosEquipo(ByVal Id_Equipo As Integer) As List(Of InfoEquipo)

        Dim Resultado As New List(Of InfoEquipo)

        Resultado = Sistema.PL.Negocio.NegEquipo.DatosDelEquipo(Id_Equipo)

        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ModificarEquipo(ByVal Id_Equipo As Integer, ByVal strNombre As String, ByVal strDescripcion As String) As String

        Dim Resultado As String
        Dim intResult As Integer
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = ""
        Else
            '20_02_2016 se deba pasar por parametro el id_equipo y luego asignarlo a alguna clase valida
            Dim oEquipo As New InfoEquipo
            oEquipo.ID_EQUIPO = Id_Equipo
            oEquipo.ID_USUARIO_ADMINISTRADOR = oUsuario.IdUsuario
            oEquipo.NOMBRE_EQUIPO = strNombre
            oEquipo.DESCRIPCION_EQUIPO = strDescripcion
            Try
                intResult = Sistema.PL.Negocio.NegEquipo.ModificarEquipo(oEquipo)

            Catch ex As Exception
                intResult = -1
                Resultado = "ERROR " & ex.Message

            End Try
            If intResult > 0 Then
                Resultado = "OK"
            Else
                Resultado = Resultado & " ERROR"
            End If

        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function EliminarEquipo(ByVal Id_Equipo As Integer) As String

        Dim Resultado As String
        Dim oUsuario As New InfoUsuario()
        Dim intResult As Integer

        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            Dim oEquipo As New InfoEquipo
            oEquipo.ID_EQUIPO = Id_Equipo
            oEquipo.ID_USUARIO_ADMINISTRADOR = oUsuario.IdUsuario
            Try
                intResult = Sistema.PL.Negocio.NegEquipo.EliminarEquipo(oEquipo)

            Catch ex As Exception
                intResult = -1
                Resultado = "ERROR " & ex.Message

            End Try
            If intResult > 0 Then
                Resultado = "OK"
            Else
                Resultado = Resultado & " ERROR"
            End If
          
           
        End If
        Return Resultado
    End Function
    <WebMethod()> Public Shared Function EliminarUsuarioEquipo(ByVal Id_UsuarioADM As Integer, ByVal Id_Usuario As Integer, ByVal Id_Equipo As Integer) As String

        Dim Resultado As String

        Try
            Resultado = Sistema.PL.Negocio.NegEquipo.Elimina_Usuario_del_Equipo(Id_UsuarioADM, Id_Usuario, Id_Equipo)
        Catch ex As Exception
            Resultado = "ERROR " & ex.Message

        End Try
        Return Resultado
    End Function
    <WebMethod()> Public Shared Function DelegarEquipo(ByVal Id_Equipo As Integer, ByVal ID_Usuario_nuevo As Integer) As Integer

        Dim Resultado As Integer
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 se debe pasar por parametro e id_equipo
            Resultado = Sistema.PL.Negocio.NegEquipo.DelegarEquipo(oUsuario.IdUsuario, ID_Usuario_nuevo, Id_Equipo)
        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ListadeUsuariodeEquipo(ByVal Id_Equipo As Integer) As List(Of InfoUsuarioEquipo)

        Dim Resultado As New List(Of InfoUsuarioEquipo)
       
        '20_02_2016 se debe pasar por parametro el id_equipo
        Resultado = Sistema.PL.Negocio.NegEquipo.Traer_Usuarios_Del_Equipo(Id_Equipo)


        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ListarEquipos() As List(Of InfoEquipoUsuario)

        Dim Resultado As New List(Of InfoEquipoUsuario)
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 
            Resultado = Sistema.PL.Negocio.NegEquipo.ObtieneEquiposDelUsuario(oUsuario.IdUsuario)

        End If
        Return Resultado
    End Function


    <WebMethod()> Public Shared Function GrabarEquipos(ByVal IdUser As Integer, ByVal strNombre As String, ByVal strDescripcion As String) As List(Of InfoEquipo)
        Dim oUsuario As New InfoUsuario()
        Dim oEquipo As New InfoEquipo
        Dim LEquipos As New List(Of InfoEquipo)
        Dim oEquipoUsuario As New InfoEquipoUsuario
        Dim intIdEquipo As Integer
        Dim intIdEquipoUsuario As Integer
        If IdUser > 0 Then
            oUsuario = Usuario.TraerUsuario_id(IdUser)
            'oUsuario = HttpContext.Current.Session("UsuarioConectado")
        Else
            oUsuario = Nothing

        End If
        
        If oUsuario Is Nothing Then
            oEquipo = Nothing
            LEquipos = Nothing
        Else
            oEquipo.NOMBRE_EQUIPO = strNombre.ToString()
            oEquipo.ID_USUARIO_ADMINISTRADOR = oUsuario.IdUsuario
            oEquipo.USUARIO_CREACION = oUsuario.IdUsuario
            oEquipo.DESCRIPCION_EQUIPO = strDescripcion
            oEquipo.ESTADO = "1"


            If NegEquipo.Existe_Nombre_Equipo(oUsuario.IdUsuario, strNombre.ToString()) = 0 Then 'significa que no existe ese nombre de equipo
                intIdEquipo = NegEquipo.CrearEquipo(oEquipo)
                oEquipo.ID_EQUIPO = intIdEquipo

                oEquipoUsuario.ID_USUARIO = oUsuario.IdUsuario
                oEquipoUsuario.ID_EQUIPO = intIdEquipo
                oEquipoUsuario.ES_ADMINISTRADOR = "S"
                oEquipoUsuario.USUARIO_CREACION = oUsuario.IdUsuario

                intIdEquipoUsuario = NegEquipo.RegistrarEquipoUsuario(oEquipoUsuario)

                LEquipos.Add(oEquipo)
            Else
                oEquipo.NOMBRE_EQUIPO = strNombre.ToString()
                oEquipo.ID_USUARIO_ADMINISTRADOR = oUsuario.IdUsuario
                oEquipo.USUARIO_CREACION = oUsuario.IdUsuario
                oEquipo.ESTADO = "1"
                oEquipo.ID_EQUIPO = -1 ' indica que no se puede crear el equipo porque el nombre ya existe
            End If
        End If
        Return LEquipos
    End Function
    <WebMethod()> Public Shared Function ObtenerIdUsuariodeSession() As Integer

        Dim Resultado As Integer
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = 0
        Else
            '20_02_2016 
            Resultado = oUsuario.IdUsuario

        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ListarInvitacionesPendientes() As List(Of InfoInvitacionEquipo)

        Dim Resultado As New List(Of InfoInvitacionEquipo)
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 
            Resultado = Sistema.PL.Negocio.NegEquipo.Listar_Invitaciones_Pendientes(oUsuario.IdUsuario)

        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ActualizarInvitacionPendiente(ByVal ID_INVITACION_A_EQUIPO As Integer, ByVal intTipo As Integer) As Integer

        Dim Resultado As Integer = 0
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016
            Dim oInvEquipo As New InfoInvitacionEquipo()
            oInvEquipo.ID_INVITACION_A_EQUIPO = ID_INVITACION_A_EQUIPO
            oInvEquipo.ID_USUARIO_INVITADO = oUsuario.IdUsuario
            If intTipo = 1 Then 'Acepta invitacion
                oInvEquipo.INV_ACEPTADA = "S"
                oInvEquipo.INV_RECHAZADA = "N"
            ElseIf intTipo = 2 Then 'Rechaza invitacion
                oInvEquipo.INV_ACEPTADA = "N"
                oInvEquipo.INV_RECHAZADA = "S"
            End If
            Resultado = Sistema.PL.Negocio.NegEquipo.Actualiza_Invitacion_Pendiente(oInvEquipo)
        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ListarConversaciones() As List(Of InfoEquipoRecursoProposito)

        Dim Resultado As New List(Of InfoEquipoRecursoProposito)
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 
            Resultado = Sistema.PL.Negocio.NegEquipo.Listar_Conversaciones(oUsuario.IdUsuario)

        End If
        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ArchivarConversacion(ByVal Id_Equipo_Recurso As Integer) As String

        Dim Resultado As String
        Dim oUsuario As New InfoUsuario()

        Try
            oUsuario = HttpContext.Current.Session("UsuarioConectado")
            If oUsuario Is Nothing Then
                Resultado = Nothing
            Else

                Resultado = Sistema.PL.Negocio.NegEquipo.Archivar_Conversacion(oUsuario.IdUsuario, Id_Equipo_Recurso)
            End If

        Catch ex As Exception
            Resultado = "ERROR " & ex.Message

        End Try
        Return Resultado
    End Function


End Class
