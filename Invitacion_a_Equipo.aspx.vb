Imports Sistema.PL.Entidad
Imports Libreria.QueryString
Imports System.IO
Imports Sistema.PL.Negocio
Imports System.Web.Services

Partial Public Class Invitacion_a_Equipo
    Inherits System.Web.UI.Page

    Dim oEquipoUsuario As New InfoEquipoUsuario()
    Dim oInvitacionEquipo As New InfoInvitacionEquipo
    Dim oUsuario As New InfoUsuario()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim oUsuario As New InfoUsuario()
        oUsuario = Session("UsuarioConectado")
        If oUsuario.Encontrado = True Then

            'oEquipoUsuario = NegEquipo.esDuenoEquipo(oUsuario)

            'IdLblNombreEquipo.InnerText = oEquipoUsuario.NOMBRE_EQUIPO.ToString()

            'oUsuario.
        Else

        End If

        If (Not IsPostBack) Then




        End If


    End Sub


    'Protected Sub btnRegistro_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegistro.Click
    '    Dim strTexto As String = ""
    '    Dim EmailAdmin As New InfoAdminEmails()
    '    Dim oEmail As New InfoEnvioMail
    '    Dim strUrl As String
    '    Dim project_path As String = System.Configuration.ConfigurationManager.AppSettings("ProjectPath_equipos")
    '    oEmail.De = EmailAdmin.EmailSupportAccount
    '    oEmail.Para = Email.Value

    '    oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("Invitacion_a_Equipo_DespliegueNombreAuto")
    '    oEmail.Asunto = "Quieres Ser Parte de mi Equipo?" 'System.Configuration.ConfigurationManager.AppSettings("OlvidoContra_Asunto_CorreoAuto")
    '    strUrl = "http://" & HttpContext.Current.Request.ServerVariables("HTTP_HOST")

    '    strTexto = strTexto & " Paso 1 "


    '    Dim valores As Dictionary(Of String, String) = New Dictionary(Of String, String)

    '    Dim strDia As String = agregaCeroaIzq(Now().Day.ToString)
    '    Dim strMes As String = agregaCeroaIzq(Now().Month.ToString)
    '    Dim strAnio As String = Now().Year.ToString

    '    strTexto = strTexto & " Paso 2 "
    '    valores.Add("Hoy", strAnio & strMes & strDia)
    '    valores.Add("Email", Email.Value.ToString())
    '    valores.Add("ID_EQUIPO", oEquipoUsuario.ID_EQUIPO.ToString())
    '    valores.Add("NOMBRE_EQUIPO", oEquipoUsuario.NOMBRE_EQUIPO.ToString())

    '    oInvitacionEquipo.ID_USUARIO_INVITADOR = oEquipoUsuario.ID_USUARIO
    '    oInvitacionEquipo.ID_EQUIPO = oEquipoUsuario.ID_EQUIPO
    '    oInvitacionEquipo.USUARIO_CREACION = oEquipoUsuario.ID_USUARIO
    '    oInvitacionEquipo.EMAIL_USUARIO_INVITADO = Email.Value.ToString()
    '    oInvitacionEquipo.INV_ENVIADA = "S"

    '    Dim Id_Invitacion_a_Equipo As Integer
    '    If NegEquipo.Es_Administrador_de_este_Equipo(oUsuario.IdUsuario, oEquipoUsuario.ID_EQUIPO) = 1 Then
    '        Id_Invitacion_a_Equipo = Sistema.PL.Negocio.NegEquipo.RegistrarInvitacion_A_Equipo(oInvitacionEquipo)
    '    Else
    '        'solo crea una invitacion en estado pendiente para que mas tarde sea aprobada y enviada por administrador del equipo
    '        oInvitacionEquipo.INV_ENVIADA = "N"
    '        oInvitacionEquipo.ENVIADO_A_ADMINISTRADOR = "S"
    '        oInvitacionEquipo.ESTADO = "1" 'Pendiente de revision por el admin
    '        Id_Invitacion_a_Equipo = Sistema.PL.Negocio.NegEquipo.RegistrarInvitacion_Pendiente(oInvitacionEquipo)
    '    End If
    '    Id_Invitacion_a_Equipo = Sistema.PL.Negocio.NegEquipo.RegistrarInvitacion_A_Equipo(oInvitacionEquipo)
    '    valores.Add("Id_Invitacion_a_Equipo", Id_Invitacion_a_Equipo.ToString())
    '    valores.Add("ID_USUARIO_INVITADOR", oInvitacionEquipo.ID_USUARIO_INVITADOR.ToString())

    '    Dim strUrlActivar As String = ""
    '    strTexto = strTexto & " Paso 3 "
    '    Try
    '        Dim QS = New QueryString(valores)
    '        strTexto = strTexto & " Paso 4 "
    '        strUrlActivar = strUrl & project_path & "Aceptar_o_RechazarEquipo.aspx?action=" & QS.QSEncriptada.ToString
    '        strTexto = strTexto & " Paso 5 "
    '        Dim strOlvidoCMailRespuestaEnvio As String = System.Configuration.ConfigurationManager.AppSettings("OlvidoCMailRespuestaEnvio")
    '        Dim fp As StreamReader
    '        Dim strLinea As String = " "
    '        Dim strmailContenido As String = ""
    '        Try
    '            fp = File.OpenText(Server.MapPath(".\") & "EstructuraInvitacionaGrupo.htm")

    '            While Not strLinea Is Nothing
    '                strLinea = fp.ReadLine()
    '                If strLinea.IndexOf("Usuario:") > 0 Then
    '                    strmailContenido = strmailContenido & strLinea
    '                    strmailContenido = strmailContenido & "<label> " & oUsuario.Nombre.ToString() & " </label> <br/>"
    '                ElseIf strLinea.IndexOf("Equipo:") > 0 Then
    '                    strmailContenido = strmailContenido & strLinea
    '                    strmailContenido = strmailContenido & "<label> " & oEquipoUsuario.NOMBRE_EQUIPO.ToString() & " </label> <br/>"
    '                ElseIf strLinea.IndexOf("link:") > 0 Then
    '                    strmailContenido = strmailContenido & strLinea
    '                    strmailContenido = strmailContenido & "<a href=" & strUrlActivar & " target='_blank'> " & strUrlActivar & " </a> <br/>"

    '                    'oEquipoUsuario.NOMBRE_EQUIPO.ToString()
    '                Else
    '                    strmailContenido = strmailContenido & strLinea
    '                End If


    '            End While
    '            fp.Close()
    '        Catch err As Exception
    '        End Try
    '        strTexto = strTexto & " Paso 6 "
    '        oEmail.Contenido = strmailContenido
    '        Try
    '            strTexto = strTexto & " Paso 7 "


    '            'aqui se debe preguntar si es dueño de este equipo,

    '            '20_2_2016 ''If oUsuario.Es_Administrador_Equipo = True Then
    '            ' ''    'solo si es administrador del equipo envia el email 
    '            ' ''    Sistema.PL.Negocio.EMail.Enviar(oEmail)
    '            ' ''End If






    '            strTexto = strTexto & " Paso 8 "
    '            MensajedelEnvio.InnerText = strOlvidoCMailRespuestaEnvio
    '            cnt_contentGuardar.Visible = True
    '            'cnt_contentMail.Visible = False
    '            Dim strmensaje As String = "Si Envió Email para ser parte de un Equipo "
    '            Dim oLog As New InfoLog()
    '            oLog.Descripcion = strmensaje & ", Datos :para " & oEmail.Para & ", " & oEmail.Asunto
    '            oLog.Error = 7
    '            oLog.Url = "EnvioEmail.aspx"
    '            strTexto = strTexto & " Paso 9 "
    '            AdminLog.RegistrarLog(oLog)
    '            strTexto = strTexto & " Paso 10 "
    '        Catch ex As Exception
    '            Dim strmensaje As String = "No Envió Email para ser parte de un Equipo "
    '            Dim oLog As New InfoLog()
    '            oLog.Descripcion = strmensaje & ", " & ex.Message & ", Datos :para " & oEmail.Para & ", " & oEmail.Asunto
    '            oLog.Error = 8
    '            oLog.Url = "EnvioEmail.aspx"
    '            strTexto = strTexto & " Paso 11 "
    '            AdminLog.RegistrarLog(oLog)
    '            strTexto = strTexto & " Paso 12 "
    '        End Try

    '        'Response.Write(strTexto.ToString)
    '    Catch ex As Exception
    '        MensajedelEnvio.InnerText = "Error al tratar de enviar E-mail"
    '    End Try

    'End Sub

    'Function agregaCeroaIzq(ByVal texto As String) As String
    '    Dim nuevotexto As String = ""
    '    If texto.Length = 1 Then
    '        nuevotexto = "0" & texto
    '    Else
    '        nuevotexto = texto
    '    End If
    '    Return nuevotexto
    'End Function


    <WebMethod()> Public Shared Function Es_Administrador_de_algun_Equipo() As Integer

        Dim Resultado As Integer
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = 0
        Else
            Resultado = Sistema.PL.Negocio.NegEquipo.Es_Administrador_de_algun_Equipo(oUsuario.IdUsuario)
        End If
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

    <WebMethod()> Public Shared Function CantidadEquipos() As Integer

        Dim Resultado As Integer
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 
            Resultado = Sistema.PL.Negocio.NegEquipo.ObtieneEquiposDelUsuario(oUsuario.IdUsuario).Count
        End If
        Return Resultado
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

    <WebMethod()> Public Shared Function agregaCeroaIzq(ByVal texto As String) As String
        Dim nuevotexto As String = ""
        If texto.Length = 1 Then
            nuevotexto = "0" & texto
        Else
            nuevotexto = texto
        End If
        Return nuevotexto
    End Function
    <WebMethod()> Public Shared Function Invitar_Usuario(ByVal strMail As String, ByVal strNombre As String, ByVal strIdEquipos As String, ByVal strNombreEquipos As String) As String
        Dim strResultado As String
        Dim strTexto As String = ""
        Dim EmailAdmin As New InfoAdminEmails()
        Dim oEmail As New InfoEnvioMail
        Dim strUrl As String
        Dim project_path As String = System.Configuration.ConfigurationManager.AppSettings("ProjectPath_equipos")
        Dim strOlvidoCMailRespuestaEnvio As String = System.Configuration.ConfigurationManager.AppSettings("OlvidoCMailRespuestaEnvio")

        oEmail.De = EmailAdmin.EmailSupportAccount
        oEmail.Para = strMail
        oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("Invitacion_a_Equipo_DespliegueNombreAuto")
        oEmail.Asunto = "Quieres Ser Parte de mi Equipo?" 'System.Configuration.ConfigurationManager.AppSettings("OlvidoContra_Asunto_CorreoAuto")
        strUrl = "http://" & HttpContext.Current.Request.ServerVariables("HTTP_HOST")

        strTexto = strTexto & " Paso 1 "

        Dim strDia As String = agregaCeroaIzq(Now().Day.ToString)
        Dim strMes As String = agregaCeroaIzq(Now().Month.ToString)
        Dim strAnio As String = Now().Year.ToString
        Dim oUsuario As New InfoUsuario()
        oUsuario = HttpContext.Current.Session("UsuarioConectado")





        Dim strListadoEquipos As String = strIdEquipos.Replace("/", "")

        Dim ListadoEquipo As String() = strListadoEquipos.Split(";")

        Dim strListadoNomEquipos As String = strNombreEquipos.Replace("/", "")
        Dim ListadoNomEquipo As String() = strListadoNomEquipos.Split(";")

        strTexto = strTexto & " Paso 2 "
        Dim Id_Invitacion_a_Equipo As Integer
        Dim intContador As Integer = 0
        Dim strUrlActivar As String = ""
        For Each strElemento As String In ListadoEquipo 'recorre listado de equipos
            If strElemento <> "" Then
                Dim valores As Dictionary(Of String, String) = New Dictionary(Of String, String)
                valores.Add("Hoy", strAnio & strMes & strDia)
                valores.Add("Email", strMail)
                valores.Add("ID_EQUIPO", strElemento.ToString())
                valores.Add("NOMBRE_EQUIPO", ListadoNomEquipo(intContador).ToString())
                Dim oInvitacionEquipo As New InfoInvitacionEquipo

                oInvitacionEquipo.ID_USUARIO_INVITADOR = oUsuario.IdUsuario
                oInvitacionEquipo.ID_EQUIPO = Convert.ToInt32(strElemento.ToString())
                oInvitacionEquipo.USUARIO_CREACION = oUsuario.IdUsuario
                oInvitacionEquipo.EMAIL_USUARIO_INVITADO = strMail.ToString()
                oInvitacionEquipo.INV_ENVIADA = "S"


                Id_Invitacion_a_Equipo = Sistema.PL.Negocio.NegEquipo.RegistrarInvitacion_A_Equipo(oInvitacionEquipo)
                valores.Add("Id_Invitacion_a_Equipo", Id_Invitacion_a_Equipo.ToString())
                valores.Add("ID_USUARIO_INVITADOR", oUsuario.IdUsuario.ToString())

                strUrlActivar = ""


                strTexto = strTexto & " Paso 3 "

                Try
                    Dim QS = New QueryString(valores)
                    strTexto = strTexto & " Paso 4 "
                    strUrlActivar = strUrl & project_path & "Aceptar_o_RechazarEquipo.aspx?action=" & QS.QSEncriptada.ToString
                    strTexto = strTexto & " Paso 5 "
                    Dim fp As StreamReader
                    Dim strLinea As String = " "
                    Dim strmailContenido As String = ""
                    Try
                        fp = File.OpenText(System.Web.HttpContext.Current.Server.MapPath(".\") & "EstructuraInvitacionaGrupo.htm")

                        While Not strLinea Is Nothing
                            strLinea = fp.ReadLine()
                            If strLinea.IndexOf("Usuario:") > 0 Then
                                strmailContenido = strmailContenido & strLinea
                                strmailContenido = strmailContenido & "<label> " & oUsuario.Nombre.ToString() & " </label> <br/>"
                            ElseIf strLinea.IndexOf("Equipo:") > 0 Then
                                strmailContenido = strmailContenido & strLinea
                                strmailContenido = strmailContenido & "<label> " & ListadoNomEquipo(intContador).ToString() & " </label> <br/>"
                            ElseIf strLinea.IndexOf("link:") > 0 Then
                                strmailContenido = strmailContenido & strLinea
                                strmailContenido = strmailContenido & "<a href=" & strUrlActivar & " target='_blank'> " & strUrlActivar & " </a> <br/>"
                            Else
                                strmailContenido = strmailContenido & strLinea
                            End If
                        End While
                        fp.Close()
                    Catch err As Exception
                    End Try
                    strTexto = strTexto & " Paso 6 "
                    oEmail.Contenido = strmailContenido
                    'Try
                    '    strTexto = strTexto & " Paso 7 "
                    Sistema.PL.Negocio.EMail.Enviar(oEmail)
                    '    strTexto = strTexto & " Paso 8 "
                    '    strResultado = strOlvidoCMailRespuestaEnvio
                    '    Dim strmensaje As String = "Si Envió Email para ser parte de un Equipo "
                    '    Dim oLog As New InfoLog()
                    '    oLog.Descripcion = strmensaje & ", Datos :para " & oEmail.Para & ", " & oEmail.Asunto
                    '    oLog.Error = 7
                    '    oLog.Url = "EnvioEmail.aspx"
                    '    strTexto = strTexto & " Paso 9 "
                    '    'AdminLog.RegistrarLog(oLog)
                    '    strTexto = strTexto & " Paso 10 "
                    'Catch ex As Exception
                    '    Dim strmensaje As String = "No Envió Email para ser parte de un Equipo "
                    '    Dim oLog As New InfoLog()
                    '    oLog.Descripcion = strmensaje & ", " & ex.Message & ", Datos :para " & oEmail.Para & ", " & oEmail.Asunto
                    '    oLog.Error = 8
                    '    oLog.Url = "EnvioEmail.aspx"
                    '    strTexto = strTexto & " Paso 11 "
                    '    'AdminLog.RegistrarLog(oLog)
                    '    strTexto = strTexto & " Paso 12 "
                    'End Try
                Catch ex As Exception
                    strResultado = "Error al tratar de enviar E-mail - " & ex.Message
                End Try
            End If
            intContador = intContador + 1
        Next
        If intContador > 1 Then
            intContador = intContador - 1
        End If

        If intContador = 1 Then
            strResultado = "Se envió " & Convert.ToString(intContador) & " Correo al Email " & strMail
        ElseIf intContador > 1 Then
            strResultado = "Se enviaron " & Convert.ToString(intContador) & " Correos al Email " & strMail 'strOlvidoCMailRespuestaEnvio
        End If


        Return strResultado
    End Function
    <WebMethod()> Public Shared Function Invitar_x_Usuario(ByVal strNombre As String, ByVal Id_Equipo As Integer, ByVal strNombre_Equipo As String) As String
        Dim strResultado As String
        Dim strTexto As String = ""
        Dim EmailAdmin As New InfoAdminEmails()
        Dim oEmail As New InfoEnvioMail
        Dim strUrl As String
        Dim strMail As String
        Dim intIdUsuario As Integer
        Dim intResultadoIdUsuarioExiste As Integer
        Dim intIdUsuarioInvitado_esta_en_PL As Integer = 0
        Dim oUsuarioPL As New InfoUsuario
        Dim project_path As String = System.Configuration.ConfigurationManager.AppSettings("ProjectPath_equipos")
        Dim strOlvidoCMailRespuestaEnvio As String = System.Configuration.ConfigurationManager.AppSettings("OlvidoCMailRespuestaEnvio")

        Dim ExisteArroba As Integer = strNombre.IndexOf("@")

        If ExisteArroba > 0 Then
            strMail = strNombre
            intResultadoIdUsuarioExiste = Sistema.PL.Negocio.NegEquipo.Obtiene_IdUsuario_x_Email(strMail)
            If intResultadoIdUsuarioExiste > 0 Then
                intIdUsuarioInvitado_esta_en_PL = intResultadoIdUsuarioExiste
            End If
        Else
            Dim strDatos As String()
            strDatos = strNombre.Split(";")
            intIdUsuario = Convert.ToInt32(strDatos(1))
            'busca por el id, el mail del usaurio registrado en PL
            oUsuarioPL = Sistema.PL.Negocio.Usuario.Trae_Datos_Basicos_del_Usuario_id(intIdUsuario)
            strMail = oUsuarioPL.Email.ToString()
            intIdUsuarioInvitado_esta_en_PL = intIdUsuario

            If strMail = "" Then
                strResultado = "ERROR no tiene E-MAIL"
                Return strResultado
                Exit Function
            End If
        End If


        oEmail.De = EmailAdmin.EmailSupportAccount
        oEmail.Para = strMail
        oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("Invitacion_a_Equipo_DespliegueNombreAuto")
        oEmail.Asunto = "Quieres Ser Parte de mi Equipo?" 'System.Configuration.ConfigurationManager.AppSettings("OlvidoContra_Asunto_CorreoAuto")
        strUrl = "http://" & HttpContext.Current.Request.ServerVariables("HTTP_HOST")

        strTexto = strTexto & " Paso 1 "

        Dim strDia As String = agregaCeroaIzq(Now().Day.ToString)
        Dim strMes As String = agregaCeroaIzq(Now().Month.ToString)
        Dim strAnio As String = Now().Year.ToString
        Dim oUsuario As New InfoUsuario()
        oUsuario = HttpContext.Current.Session("UsuarioConectado")


        strTexto = strTexto & " Paso 2 "
        Dim Id_Invitacion_a_Equipo As Integer
        Dim intContador As Integer = 0
        Dim strUrlActivar As String = ""

        Dim valores As Dictionary(Of String, String) = New Dictionary(Of String, String)
        valores.Add("Hoy", strAnio & strMes & strDia)
        valores.Add("Email", strMail)
        valores.Add("ID_EQUIPO", Id_Equipo.ToString())
        valores.Add("NOMBRE_EQUIPO", strNombre_Equipo.ToString())
        Dim oInvitacionEquipo As New InfoInvitacionEquipo

        oInvitacionEquipo.ID_USUARIO_INVITADOR = oUsuario.IdUsuario
        oInvitacionEquipo.ID_EQUIPO = Convert.ToInt32(Id_Equipo.ToString())
        oInvitacionEquipo.USUARIO_CREACION = oUsuario.IdUsuario
        oInvitacionEquipo.EMAIL_USUARIO_INVITADO = strMail.ToString()
        oInvitacionEquipo.INV_ENVIADA = "S"
        oInvitacionEquipo.ID_USUARIO_INVITADO = intIdUsuarioInvitado_esta_en_PL


        Id_Invitacion_a_Equipo = Sistema.PL.Negocio.NegEquipo.RegistrarInvitacion_A_Equipo(oInvitacionEquipo)
        valores.Add("Id_Invitacion_a_Equipo", Id_Invitacion_a_Equipo.ToString())
        valores.Add("ID_USUARIO_INVITADOR", oUsuario.IdUsuario.ToString())

        strUrlActivar = ""


        strTexto = strTexto & " Paso 3 "

        Try
            Dim QS = New QueryString(valores)
            strTexto = strTexto & " Paso 4 "
            strUrlActivar = strUrl & project_path & "Aceptar_o_RechazarEquipo.aspx?action=" & QS.QSEncriptada.ToString
            strTexto = strTexto & " Paso 5 "
            Dim fp As StreamReader
            Dim strLinea As String = " "
            Dim strmailContenido As String = ""
            Try
                fp = File.OpenText(System.Web.HttpContext.Current.Server.MapPath(".\") & "EstructuraInvitacionaGrupo.htm")

                While Not strLinea Is Nothing
                    strLinea = fp.ReadLine()
                    If strLinea.IndexOf("Usuario:") > 0 Then
                        strmailContenido = strmailContenido & strLinea
                        strmailContenido = strmailContenido & "<label> " & oUsuario.Nombre.ToString() & " </label> <br/>"
                    ElseIf strLinea.IndexOf("Equipo:") > 0 Then
                        strmailContenido = strmailContenido & strLinea
                        strmailContenido = strmailContenido & "<label> " & strNombre_Equipo.ToString() & " </label> <br/>"
                    ElseIf strLinea.IndexOf("link:") > 0 Then
                        strmailContenido = strmailContenido & strLinea
                        strmailContenido = strmailContenido & "<a href=" & strUrlActivar & " target='_blank'> " & strUrlActivar & " </a> <br/>"
                    Else
                        strmailContenido = strmailContenido & strLinea
                    End If
                End While
                fp.Close()
            Catch err As Exception
            End Try
            strTexto = strTexto & " Paso 6 "
            oEmail.Contenido = strmailContenido
            Sistema.PL.Negocio.EMail.Enviar(oEmail)
            strResultado = "OK"

        Catch ex As Exception
            strResultado = "Error al tratar de enviar E-mail - " & ex.Message
        End Try



        Return strResultado
    End Function
End Class