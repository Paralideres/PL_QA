Imports Sistema.PL.Negocio
Imports Sistema.PL.Entidad

Partial Public Class Aceptar_o_Rechazar_Invitacion
    Inherits System.Web.UI.Page
    Dim liQS As Libreria.QueryString.QueryString
    Dim strHoy As String
    Dim strEmail As String
    Dim IdEquipo As Integer
    Dim strNombreEquipo As String
    Dim IdInvitacionEquipo As Integer
    Dim idUsuarioInvitador As Integer
    Dim parametro As String
    Dim strDia As String = agregaCeroaIzq(Now().Day.ToString)
    Dim strMes As String = agregaCeroaIzq(Now().Month.ToString)
    Dim strAnio As String = Now().Year.ToString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not IsPostBack Then
            parametro = Request.QueryString("action")
            liQS = New Libreria.QueryString.QueryString(parametro)

            strHoy = Convert.ToString(liQS.Item("Hoy"))
            strEmail = Convert.ToString(liQS.Item("Email"))
            IdEquipo = Convert.ToInt32(liQS.Item("ID_EQUIPO"))
            strNombreEquipo = Convert.ToString(liQS.Item("NOMBRE_EQUIPO"))
            IdInvitacionEquipo = Convert.ToInt32(liQS.Item("Id_Invitacion_a_Equipo"))
            idUsuarioInvitador = Convert.ToInt32(liQS.Item("ID_USUARIO_INVITADOR"))
            div_ACE_REC.Visible = True

            If strEmail.ToString().Length > 0 Then
                btnAceptar.Enabled = True
                btnRechazar.Enabled = True
                lblNombreEquipo.InnerHtml = strNombreEquipo

            Else
                btnAceptar.Enabled = False
                btnRechazar.Enabled = False

            End If
    
    


        End If

    End Sub

    Function agregaCeroaIzq(ByVal texto As String) As String
        Dim nuevotexto As String = ""
        If texto.Length = 1 Then
            nuevotexto = "0" & texto
        Else
            nuevotexto = texto
        End If
        Return nuevotexto
    End Function

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click
        Dim oInvEquipo As New InfoInvitacionEquipo()
        parametro = Request.QueryString("action")
        liQS = New Libreria.QueryString.QueryString(parametro)

        strHoy = Convert.ToString(liQS.Item("Hoy"))
        strEmail = Convert.ToString(liQS.Item("Email"))
        IdEquipo = Convert.ToInt32(liQS.Item("ID_EQUIPO"))
        strNombreEquipo = Convert.ToString(liQS.Item("NOMBRE_EQUIPO"))
        IdInvitacionEquipo = Convert.ToInt32(liQS.Item("Id_Invitacion_a_Equipo"))
        idUsuarioInvitador = Convert.ToInt32(liQS.Item("ID_USUARIO_INVITADOR"))
       
        oInvEquipo.ID_INVITACION_A_EQUIPO = IdInvitacionEquipo
        oInvEquipo.ID_USUARIO_INVITADOR = idUsuarioInvitador
        oInvEquipo.EMAIL_USUARIO_INVITADO = strEmail
        oInvEquipo.INV_ACEPTADA = "S"
        
        Dim resultado As Integer

        resultado = Sistema.PL.Negocio.NegEquipo.Aceptar_Invitacion_A_Equipo(oInvEquipo)
        btnAceptar.Enabled = False
        btnRechazar.Enabled = False
        cnt_contentGuardar.Visible = True
        div_ACE_REC.Visible = False

        If resultado > 0 Then
            MensajedelEnvio.InnerText = "Se acaba de aceptar la invitacion"
        Else
            MensajedelEnvio.InnerText = "Ocurrio un problema al intentar ser parte de este equipo"
        End If


    End Sub

    Protected Sub btnRechazar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRechazar.Click
        Dim oInvEquipo As New InfoInvitacionEquipo()

        parametro = Request.QueryString("action")
        liQS = New Libreria.QueryString.QueryString(parametro)

        strHoy = Convert.ToString(liQS.Item("Hoy"))
        strEmail = Convert.ToString(liQS.Item("Email"))
        IdEquipo = Convert.ToInt32(liQS.Item("ID_EQUIPO"))
        strNombreEquipo = Convert.ToString(liQS.Item("NOMBRE_EQUIPO"))
        IdInvitacionEquipo = Convert.ToInt32(liQS.Item("Id_Invitacion_a_Equipo"))
        idUsuarioInvitador = Convert.ToInt32(liQS.Item("ID_USUARIO_INVITADOR"))


        oInvEquipo.ID_INVITACION_A_EQUIPO = IdInvitacionEquipo
        oInvEquipo.ID_USUARIO_INVITADOR = idUsuarioInvitador
        oInvEquipo.EMAIL_USUARIO_INVITADO = strEmail
        oInvEquipo.INV_RECHAZADA= "S"

        Dim resultado As Integer

        resultado = Sistema.PL.Negocio.NegEquipo.Rechazar_Invitacion_A_Equipo(oInvEquipo)
        btnAceptar.Enabled = False
        btnRechazar.Enabled = False
        cnt_contentGuardar.Visible = True
        div_ACE_REC.Visible = False

        If resultado > 0 Then
            MensajedelEnvio.InnerText = "Se acaba de Rechazar la invitacion"
        Else
            MensajedelEnvio.InnerText = "Ocurrio un problema..."

        End If

    End Sub
End Class