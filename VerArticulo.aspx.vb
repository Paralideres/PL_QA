﻿Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports System.Web.Services
Imports Sistema.PL.Filtros

Partial Public Class VerArticulo
    Inherits System.Web.UI.Page
    Dim strPathFile As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("DDescargasFiles"))
    Dim strPathImagenAuthor As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("PathImagenAuthor"))
    Dim strimagenAuthorporDefecto As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("imagenAuthorporDefecto"))
    Dim strExt_Tipo_Archivos As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("Ext_Tipo_Archivos"))
    Dim IdAuthor As Integer
    Dim oUsuario As New InfoUsuario()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then

            Dim oPagina As New InfoPagina
            Dim oPaginaRecurso As New InfoPaginaEquipo
            Dim IdPagina As Integer
            Dim IdPaginaListaAutor As Integer
            Dim strEstrellaOn As String = "<a href='#votar'><img src='assets/imgs/gral/rating_star_on.jpg' title='Valor de Estrella' /></a>"
            Dim strEstrellaOff As String = "<a href='#votar'><img src='assets/imgs/gral/rating_star_off.jpg' title='Valor de Estrella' /></a>"

            IdPagina = Request.QueryString("Idp").ToString()
            Session("Idp") = IdPagina

            Try
                IdPaginaListaAutor = Request.QueryString("pag").ToString()
            Catch ex As Exception
                IdPaginaListaAutor = 1
            End Try

            oPagina = Pagina.TraerPagina(IdPagina)
            Session("CantidadResenaEquipo") = 0
            Session("CantidadComentarioEquipo") = 0

            oUsuario = New InfoUsuario()
            oUsuario = Session("UsuarioConectado")
            
            If oUsuario Is Nothing Then
                imagenCompartirenEQ.Visible = False

            Else
                If oUsuario.Esta_En_Equipo = True Then
                    '20_02_2016'oPaginaRecurso = NegEquipo.ObtieneDatosRecursoEquipo(oPagina.Id_Pagina, oUsuario.ID_Equipo)
                    imagenCompartirenEQ.Visible = True
                    'imagenComentarios.Visible = False
                    ' el usuario esta en algun equipo
                    'ahora lo que hay que saber si 
                    ' este recurso ya fue compartido o no en el o los equipos donde el usuario esta
                    ' puede existir 3 casos
                    ' caso 1, que el usuario esta en un solo equipo y este recurso no se ha compartido
                    ' en este caso se debe habilitar el boton compartir
                    ' caso 2, el usuario esta en un solo equipo y este recurso ya se compartio en el equipo
                    ' en este caso no se debe habilitar el boton compartir
                    ' caso 3, el usuario esta en mas de 1 equipo, ejemplo 3, en ninguno se ha compartido el recurso
                    ' en este caso, se debe habilitar el boton compartir 
                    ' caso 4, el usuario esta en mas de 1 equipo, ejemplo 3, y este recurso se compartio en 1 equipo y en los otros no se ha compartido
                    ' en este caso, se debe habilitar el botn compartir.
                    ' para los casos donde se debe habilitar el boton compartir, la lista de equipos que se deben
                    ' mostrar solo deben ser de equipos que donde nunca se a compartido este recurso,
                    ' por ejemplo de 3 equipos, si en 1 equipo ya se compartio este recurso, 
                    ' el listado de equipos, solo se deben mostrar 2 en el jquery

                    ' entonces la funcion aqui para mostrar o no el boton deberia ser
                    ' consultando si este recurso ya esta comparatido en todos los q¿equipos del usuario
                    ' si la respuesta es si entonces no se muestra
                    'si la respeusta es no entonces se muestra y se lista los equipos 
                    'donde falta que se comparta
                    'Dim oListadoEquiposSinResena = New List(Of InfoEquipo)
                    'oListadoEquiposSinResena = NegEquipo.ObtieneListadoEquiposSinResena(oUsuario.IdUsuario, oPagina.Id_Pagina)


                    'If oListadoEquiposSinResena.Count > 0 Then
                    'imagenCompartirenEQ.Visible = True
                    'Else
                    'imagenCompartirenEQ.Visible = False
                    'End If


                    'If oPaginaRecurso.EXISTE_RESENA = 0 Then
                    '    imagenCompartirenEQ.Visible = True
                    'ElseIf oPaginaRecurso.EXISTE_RESENA > 0 Then
                    '    imagenComentarios.Visible = True
                    '    If oPaginaRecurso.EXISTE_COMENTARIO = 0 Then
                    '        NumeroComentarios.InnerText = "No hay Comentarios, Se El primero!"
                    '    ElseIf oPaginaRecurso.EXISTE_COMENTARIO = 1 Then
                    '        NumeroComentarios.InnerText = oPaginaRecurso.EXISTE_COMENTARIO.ToString & " Comentario..."
                    '    ElseIf oPaginaRecurso.EXISTE_COMENTARIO > 1 Then
                    '        NumeroComentarios.InnerText = oPaginaRecurso.EXISTE_COMENTARIO.ToString & " Comentarios..."
                    '    End If
                    'End If



                    'Session("CantidadResenaEquipo") = oPaginaRecurso.EXISTE_RESENA
                    'Session("CantidadComentarioEquipo") = oPaginaRecurso.EXISTE_COMENTARIO



                Else
                    imagenCompartirenEQ.Visible = False
            End If

            End If



            IdAuthor = oPagina.Id_User.ToString()

            Dim strTitulo As String = oPagina.TituloPagina.ToString()
            If strTitulo.Length > 43 Then
                lblNombre.Style.Add("font-size", "large")
                lblNombre.Style.Add("font-weight", "bold")
                lblNombre.InnerHtml = oPagina.TituloPagina





            Else
                lblNombre.Style.Add("font-size", "x-large")
                lblNombre.Style.Add("font-weight", "bold")
                lblNombre.InnerHtml = oPagina.TituloPagina
            End If
            lblNombre.InnerHtml = oPagina.TituloPagina

            TituloArticulo.InnerHtml = oPagina.TituloPagina & " | ParaLideres.org"

            If oPagina.Id_SeccionOrigen > 0 Then
                lblSigno1.Visible = True
                lblSigno2.Visible = True
                ahref_Origen.InnerHtml = oPagina.NombreSeccionPadre.ToString
                ahref_SubSeccion.InnerHtml = oPagina.NombreSeccionActual.ToString
                ahref_SubSeccion.HRef = "Secciones.aspx?Ide=" & oPagina.Id_Seccion.ToString & "&Pag=1"
                ahref_Origen.HRef = "Secciones.aspx?Ide=" & oPagina.Id_SeccionPadre.ToString & "&Pag=1"
            ElseIf oPagina.Id_SeccionOrigen = 0 Then
                lblSigno1.Visible = True
                lblSigno2.Visible = False
                ahref_Origen.Visible = False
                ahref_SubSeccion.Visible = True
                ahref_SubSeccion.InnerHtml = oPagina.NombreSeccionActual.ToString
            End If



            NombreAutorHref.InnerHtml = oPagina.NombreAutor
            NombreAutorHref.HRef = "./Profile.aspx?Id_Autor=" & oPagina.Id_User
            LblFecha.InnerHtml = oPagina.FechaPosteada.ToString("dd-MM-yyyy")

            Lst_delAutor.HRef = "Lista_MasDelAutor.aspx?Idp=" & IdPagina & "&Ida=" & IdAuthor.ToString() & "&Pag=" & IdPaginaListaAutor

            Dim strExtensionImagen() As String
            imagenDescargaDoc.Visible = False
            imagenDescargaPdf.Visible = False
            'img_VistaPrevia.Visible = False
            imagenDescargaPpt.Visible = False

            DivArticulo.Visible = False
            DivContenido.Visible = False

            'divResumen.Visible = False
            'LblResena.Visible = False




            Dim ContieneArchivo As Boolean = False

            If oPagina.NombreImagen.Length > 0 Then
                strExtensionImagen = oPagina.NombreImagen.Split(".")
                hdnFile.Value = oPagina.NombreImagen
                If strExtensionImagen(0) <> "n/a" And strExtensionImagen(0) <> "" Then

                    If strExtensionImagen(1).Substring(0, 1) = "d" Then 'busca archivos doc o docx
                        imagenDescargaDoc.Visible = True
                        imagenDescargaPdf.Visible = False
                        imagenDescargaOtro.Visible = False
                        imagenDescargaPpt.Visible = False
                        hdnFile.Value = strPathFile & oPagina.NombreImagen.ToString() '"pic_6521.pdf"
                        ContieneArchivo = True
                    ElseIf strExtensionImagen(1).Substring(0, 2) = "pd" Then 'busca archivos pdf
                        imagenDescargaDoc.Visible = False
                        imagenDescargaPdf.Visible = True
                        imagenDescargaOtro.Visible = False
                        imagenDescargaPpt.Visible = False
                        hdnFile.Value = strPathFile & oPagina.NombreImagen.ToString()
                        ContieneArchivo = True
                    ElseIf strExtensionImagen(1).Substring(0, 2) = "pp" Then 'busca archivos ppt
                        imagenDescargaDoc.Visible = False
                        imagenDescargaPdf.Visible = False
                        imagenDescargaPpt.Visible = True
                        imagenDescargaOtro.Visible = False
                        hdnFile.Value = strPathFile & oPagina.NombreImagen.ToString()
                        ContieneArchivo = True
                    Else
                        'es por que no es ni PDF ni Doc, ni Ppt
                        Dim strSplitTipos As String()

                        strSplitTipos = strExt_Tipo_Archivos.Split(",")
                        'busca si el tipo de archivo puede existir en la configuracion conocida webconfig
                        For Each strElemento As String In strSplitTipos
                            If (strExtensionImagen(1) = strElemento Or UCase(strExtensionImagen(1)) = UCase(strElemento)) Then
                                imagenDescargaDoc.Visible = False
                                imagenDescargaPdf.Visible = False
                                imagenDescargaPpt.Visible = False
                                imagenDescargaOtro.Visible = True
                                hdnFile.Value = strPathFile & oPagina.NombreImagen.ToString() '"pic_6530.pdf"
                                ContieneArchivo = True
                                Exit For
                            End If
                        Next

                    End If



                End If

                'img_VistaPrevia.Disabled = False
            End If

            If ContieneArchivo Then

                'divResumen.Visible = True
                'LblResena.Visible = False
                'comments.Visible = True
                LblResena.InnerHtml = oPagina.Reseña
                DivArticulo.Visible = True
                Iframe_Articulo.Attributes("src") = "http://docs.google.com/viewer?url=http%3A%2F%2Fparalideres.org%2Ffiles%2F" & oPagina.NombreImagen.ToString() & "&embedded=true"

            Else

                'divResumen.Visible = True
                'LblResena.Visible = True
                'comments.Visible = False
                LblResena.InnerHtml = oPagina.Reseña
                DivContenido.Visible = True
                DivContenido.InnerHtml = ReplaceCR(oPagina.Contenido)
            End If



            If oPagina.FotoAutho.ToString <> "" Then
                ImgAutor.Src = strPathImagenAuthor & oPagina.FotoAutho.ToString
            Else
                ImgAutor.Src = strimagenAuthorporDefecto.ToString
            End If


            Dim strEtiquetas() As String
            Dim strlinkEtiquetas As String
            Dim strHtmlEtiquetasCompleto As String = ""
            Dim intX As Integer = 0
            If oPagina.Etiquetas.Length > 0 Then
                strEtiquetas = oPagina.Etiquetas.Split(" ")
                For intX = 0 To strEtiquetas.Length - 1
                    strlinkEtiquetas = "<a  onclick=IraEtiqueta('" + strEtiquetas(intX) + "') title='tag title'  onmouseover=this.style.cursor='hand'>" & strEtiquetas(intX) & "</a>"
                    If intX = (strEtiquetas.Length - 1) Then
                        strHtmlEtiquetasCompleto = strHtmlEtiquetasCompleto & strlinkEtiquetas
                    Else
                        strHtmlEtiquetasCompleto = strHtmlEtiquetasCompleto & strlinkEtiquetas & ", "
                    End If

                Next
                pEtiquetas.InnerHtml = "Etiquetas: " & strHtmlEtiquetasCompleto

            End If
        End If




    End Sub


    Public Function ReplaceCR(ByVal ps_string As String) As String

        'ps_string = HttpContext.Current.Server.HtmlDecode(ps_string)
        ps_string = Replace(ps_string, Chr(13), "<br>")

        Return ps_string

    End Function

    Sub descarga(ByVal filepath As String, ByVal filename As String)

        Response.Clear()
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", ("attachment; filename=" + filename))
        Response.Flush()
        Response.WriteFile(filepath)
        Response.End()
    End Sub

    <WebMethod()> Public Shared Function ValorEstrellas(ByVal IdPagina As Integer) As Integer
        Dim oPagina As New InfoPagina
        oPagina = Pagina.TraerPagina(IdPagina)
        Return oPagina.Estrellas
    End Function





    <WebMethod()> Public Shared Function ObtieneValorUsuarioSession() As Integer
        Dim Resultado As Integer
        Dim oUsuario As New InfoUsuario()

        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = 0
        Else
            Resultado = oUsuario.IdUsuario
        End If
        Return Resultado

    End Function

    'var dataToSend = "{'IdPagina': " + Idp + ", 'IdUser': " + ValorUsuario + ", 'Valor': " + valor + "}";
    '<WebMethod()> Public Shared Function ValorarArticulo(ByVal oPagina As FiltroPagina) As Integer

    <WebMethod()> Public Shared Function ValorarArticulo(ByVal IdPagina As Integer, ByVal IdUser As Integer, ByVal Valor As Integer) As Integer
        Dim Resultado As Integer
        Dim oVotar As New InfoVotar
        oVotar.IdPagina = IdPagina
        oVotar.IdUser = IdUser
        oVotar.Valor = Valor
        oVotar.IpAdress = HttpContext.Current.Request.UserHostAddress

        If Valor >= 3 Then
            oVotar.MeGusta = 1
            oVotar.NoMeGusta = 0
        Else
            oVotar.MeGusta = 0
            oVotar.NoMeGusta = 1
        End If

        Dim ExisteVoto As New Integer
        ExisteVoto = Sistema.PL.Negocio.Votar.ExisteVotacion(oVotar)
        If ExisteVoto = 1 Then
            Resultado = Votar.ModificarVotacion(oVotar)
        Else
            Resultado = Votar.RegistrarVotacion(oVotar)
        End If

        Return Resultado
    End Function

    <WebMethod()> Public Shared Function ValorarArticulo2(ByVal oPagina As Object) As Integer
        Dim Resultado As Integer
        Dim oVotar As New InfoVotar
        oVotar.IdPagina = oPagina.IdPagina
        oVotar.IdUser = oPagina.IdUser
        oVotar.Valor = oPagina.Votacion
        oVotar.IpAdress = HttpContext.Current.Request.UserHostAddress

            
        If oPagina.Votacion >= 3 Then
            oVotar.MeGusta = 1
            oVotar.NoMeGusta = 0
        Else
            oVotar.MeGusta = 0
            oVotar.NoMeGusta = 1
        End If

        Dim ExisteVoto As New Integer
        ExisteVoto = Sistema.PL.Negocio.Votar.ExisteVotacion(oVotar)
        If ExisteVoto = 1 Then
            Resultado = Votar.ModificarVotacion(oVotar)
        Else
            Resultado = Votar.RegistrarVotacion(oVotar)
        End If

        Return Resultado
    End Function







    'Protected Sub btnNoMeGusta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNoMeGusta.Click
    '    'Dim oVotar As New InfoVotar

    '    'Dim ExisteVoto As New Integer
    '    'oVotar.IpAdress = Request.UserHostAddress()
    '    'oVotar.IdPagina = Convert.ToInt32(Request.QueryString("Idp").ToString())
    '    'oVotar.MeGusta = 0
    '    'oVotar.NoMeGusta = 1
    '    'ExisteVoto = Sistema.PL.Negocio.Votar.ExisteVotacionIpPaginaNoMegusta(oVotar)
    '    'If ExisteVoto = 1 Then
    '    '    Sistema.PL.Negocio.Votar.ModificarVotacion(oVotar)
    '    'Else
    '    '    Sistema.PL.Negocio.Votar.RegistrarVotacion(oVotar)
    '    'End If

    'End Sub

    'Protected Sub btnMeGusta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnMeGusta.Click
    '    'Dim oVotar As New InfoVotar
    '    'Dim ExisteVoto As New Integer
    '    'oVotar.IpAdress = Request.UserHostAddress()
    '    'oVotar.IdPagina = Convert.ToInt32(Request.QueryString("Idp").ToString())
    '    'oVotar.MeGusta = 1
    '    'oVotar.NoMeGusta = 0

    '    'ExisteVoto = Sistema.PL.Negocio.Votar.ExisteVotacionIpPaginaNoMegusta(oVotar)
    '    'If ExisteVoto = 1 Then
    '    '    Sistema.PL.Negocio.Votar.ModificarVotacion(oVotar)
    '    'Else
    '    '    Sistema.PL.Negocio.Votar.RegistrarVotacion(oVotar)
    '    'End If

    'End Sub

    <WebMethod()> Public Shared Function RegistarDescargaRecurso(ByVal IdPagina As Integer, ByVal Valor As Integer) As Integer
        Dim Resultado As Integer
        Dim oRecurso As New InfoPaginaDescarga
        Dim oUsuario As New InfoUsuario()

        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            oRecurso.Id_Usuario = 0
        Else
            oRecurso.Id_Usuario = oUsuario.IdUsuario
        End If
        oRecurso.Id_Pagina = IdPagina
        oRecurso.Valor = Valor
        oRecurso.IpAddress = HttpContext.Current.Request.UserHostAddress

        Resultado = Sistema.PL.Negocio.Pagina.RegistrarRecursoDescarga(oRecurso)
        
        Return Resultado
    End Function




    <WebMethod()> Public Shared Function Descargas(ByVal IdPagina As Integer) As Integer
        Dim Resultado As Integer
        Resultado = Sistema.PL.Negocio.Pagina.CantidadDeDescargadeRecurso(IdPagina)
        Return Resultado
    End Function


    <WebMethod()> Public Shared Function GuardarComentario(ByVal IdPagina As Integer, ByVal IdEquipo As Integer, ByVal Comentario As String, ByVal Tipo As String, ByVal IdEquipoRecurso As Integer) As Integer

        Dim Resultado As Integer
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = 0
        Else
            If IdEquipoRecurso = 0 Then
                Dim oEquipoRecurso As New InfoEquipoRecurso()
                oEquipoRecurso.ID_EQUIPO = IdEquipo
                oEquipoRecurso.ID_USUARIO_QUE_COMPARTIO = oUsuario.IdUsuario
                oEquipoRecurso.PAGE_ID = IdPagina
                oEquipoRecurso.RESENA_RECURSO = Comentario.ToString()
                oEquipoRecurso.TIPO = Tipo.ToString()
                oEquipoRecurso.ESTADO_CONVERSACION = 1
                Resultado = Sistema.PL.Negocio.NegEquipo.RegistrarEquipoRecurso(oEquipoRecurso)
            ElseIf IdEquipoRecurso > 0 Then
                Dim oEquipoRecursoComentario As New InfoEquipoRecursoComentario()
                oEquipoRecursoComentario.ID_EQUIPO = IdEquipo
                oEquipoRecursoComentario.ID_USUARIO_QUE_COMENTO = oUsuario.IdUsuario
                oEquipoRecursoComentario.PAGE_ID = IdPagina
                oEquipoRecursoComentario.COMENTARIO = Comentario.ToString()
                oEquipoRecursoComentario.TIPO = Tipo.ToString()
                oEquipoRecursoComentario.ID_EQUIPO_RECURSO = IdEquipoRecurso
                Resultado = Sistema.PL.Negocio.NegEquipo.RegistrarEquipoRecursoComentario(oEquipoRecursoComentario)
            End If


        End If
        Return Resultado
    End Function



    <WebMethod()> Public Shared Function ObtenerResenaComentarios(ByVal IdPagina As Integer, ByVal Tipo As String) As List(Of InfoResenaComentarios)

        Dim Resultado As New List(Of InfoResenaComentarios)

        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            'se deb pasar por parametro el equipo
            Resultado = Nothing '20_02_2016 Sistema.PL.Negocio.NegEquipo.ObtieneResenaComentarios(IdPagina, oUsuario.ID_Equipo, Tipo)
        End If
        Return Resultado
    End Function
    <WebMethod()> Public Shared Function ObtenerCantidadComentarios(ByVal IdPagina As Integer) As Integer

        Dim Result As Integer
        Dim Resultado As New InfoPaginaEquipo

        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Result = 0
        Else
            ''Se debe pasar por parametr el id_equipo
            'Resultado = 0 ' 20_02_2016 Sistema.PL.Negocio.NegEquipo.ObtieneDatosRecursoEquipo(IdPagina, oUsuario.ID_Equipo)
            Result = 0 'Resultado.EXISTE_RESENA + Resultado.EXISTE_COMENTARIO

        End If
        Return Result
    End Function
    <WebMethod()> Public Shared Function ListarEquipos(ByVal IdPagina As Integer) As List(Of InfoEquipo)

        Dim Resultado As New List(Of InfoEquipo)
        Dim oUsuario As New InfoUsuario()


        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            '20_02_2016 
            Resultado = Sistema.PL.Negocio.NegEquipo.ObtieneListadoEquiposSinResena(oUsuario.IdUsuario, IdPagina)

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
    <WebMethod()> Public Shared Function Existe_Recurso_En_Equipo(ByVal ID_Equipo As Integer, ByVal ID_PAGINA As Integer) As List(Of InfoEquipoRecursoCompartido)

        Dim Resultado As New List(Of InfoEquipoRecursoCompartido)
        Dim oUsuario As New InfoUsuario()
        oUsuario = HttpContext.Current.Session("UsuarioConectado")
        If oUsuario Is Nothing Then
            Resultado = Nothing
        Else
            Dim oEquipoRecurso As New InfoEquipoRecurso()
            oEquipoRecurso.ID_EQUIPO = ID_Equipo
            oEquipoRecurso.PAGE_ID = ID_PAGINA
            '20_02_2016 
            Resultado = Sistema.PL.Negocio.NegEquipo.Existe_Recurso_Compartido(oEquipoRecurso)

        End If
        Return Resultado
    End Function

End Class
