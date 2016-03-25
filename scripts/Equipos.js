$(document).ready(function() {

    ListarEquipos();




    $('#MiCerrarCreaEquipo').click(function() {
        $('#MiCrearEquipo').fadeOut('slow');
        return false;
    });

    $('#MiCerrarMostrarEquipo').click(function() {
        ListarEquipos();
        $('#MiMostrarEquipo').fadeOut('slow');
        return false;
    });

    $('#btnCrearEq').click(function() {
        $('#MiCrearEquipo').fadeIn('slow');
    });

    $('#btnIrEquipo').click(function() {
        var Equipo_Id = $('input[type=radio][name=Equipos]:checked').attr('id');
        var valor = $('input:radio[name=Equipos]:checked').val();
        var res = valor.replace("/", "");
        valor = res;
        //alert(valor);
        if (valor == 1) {
            //alert(Equipo_Id);
            if (Equipo_Id > 0) {
                //buscar nombre y descripcion del equipo
                //alert("antes de funcion");
                MostrarDatosdelEquipo(Equipo_Id);
                //alert("despues de funcion");
                //habilitar lo label y ocultar los inputext
                //llenar con datos los label
                $('#lblNombre').show();
                $('#lblDescripcion').show();

                $('#txtnombre').hide();
                $('#txtdescripcion').hide();
                $('#btnGrabar').hide();

                $('#MiMostrarEquipo').fadeIn('slow');
                return true;
            }
            else {
                alert("No ha seleccionado Equipo");
            }

        }
        else {
            alert("Tu no Administras este equipo");
        }


    });


    $('#btnModificar').click(function() {
        $('#lblNombre').hide();
        $('#lblDescripcion').hide();
        $('#txtnombre').show();
        $('#txtdescripcion').show();
        $('#btnGrabar').show();
    });

    $('#btnEliminar').click(function() {
        var strNewNombre = $('#txtnombre').val();
        var Equipo_Id = $('input[type=radio][name=Equipos]:checked').attr('id');
        if (Equipo_Id > 0) {
            var confirm1 = confirm('esta seguro que desea eliminar el equipo: ' + strNewNombre);
            if (confirm1) {
                var resultado = EliminaEquipo(Equipo_Id);
                //alert(resultado);
                ListarEquipos();
                $('#MiMostrarEquipo').fadeOut('slow');
            }
            else {
            }
        }
        else {
            alert("No ha seleccionado Equipo");
        }
    });
    $('#btnDelegar').click(function() {
        var Equipo_Id = $('input[type=radio][name=Equipos]:checked').attr('id');
        if (Equipo_Id > 0) {
            VerMiembros(Equipo_Id);
            $('#MiPopDele').fadeIn('slow');
        }
        else {
            alert("No ha seleccionado Equipo");
        }

    });

    $('#MiCerrarDele').click(function() {
        $('#MiPopDele').fadeOut('slow');
        return false;
    });

    $('#btnGuardar').click(function() {
        var Equipo_Id = $('input[type=radio][name=Equipos]:checked').attr('id');
        if (Equipo_Id > 0) {
            var valor = $('input:radio[name=ListaDelegar]:checked').val();
            if (valor > 0) {
                DelegarEquipo(Equipo_Id, valor);
                $('#btnModificar').hide();
                $('#btnEliminar').hide();
                $('#btnDelegar').hide();
                $('#btnEliminarUs').hide();


                $('#MiPopDele').fadeOut('slow');
                $('#MiMostrarEquipo').fadeOut('slow');
                ListarEquipos();
            }
            else {
                alert("Seleccione un Miembro del equipo!!!");
            }
        }
        else {
            alert("No ha seleccionado Equipo");
        }

    });


    $('#btnGrabar').click(function() {
        var Equipo_Id = $('input[type=radio][name=Equipos]:checked').attr('id');
        var strNewNombre = $('#txtnombre').val();
        var strNewDescripcion = $('#txtdescripcion').val();
        if (Equipo_Id > 0) {
            var resultado = ModificaEquipo(Equipo_Id, strNewNombre, strNewDescripcion);
            //alert(resultado);
            if (resultado != "") {
                $('#lblNombre').html(strNewNombre);
                $('#lblDescripcion').html(strNewDescripcion);
                $('#lblNombre').show();
                $('#lblDescripcion').show();

                $('#txtnombre').hide();
                $('#txtdescripcion').hide();
                $('#btnGrabar').hide();
            }
            else {
            }
        }
        else {
            alert("No ha seleccionado Equipo");
        }
    });

    $('#btn_Crear').click(function() {
        var strNewNombre = $('#txtNombreEquipo').val();
        var strNewDescripcion = $('#txtDescripcionEquipo').val();
        //        //alert(strNewNombre);
        var resultado = GrabarEquipo(strNewNombre, strNewDescripcion);
        if (resultado > 0) {
            ListarEquipos();
        }
        else {
            if (resultado == -1) {
                alert("El nombre de Equipos:" + strNewNombre + " ya existe en nuestra base de datos, intenta con otro nombre");
            }
            else {
                alert("Hubo en error al tratar de Crear el equipo");
            }
        }

    });


    $('#btnEliminarUs').click(function() {
        var Equipo_Id = $('input[type=radio][name=Equipos]:checked').attr('id');
        if (Equipo_Id > 0) {
            VerUsuarioaEliminar(Equipo_Id);
            $('#MiPopEliminarUS').fadeIn('slow');
        }
        else {
            alert("No ha seleccionado Equipo");
        }

    });

    $('#MiCerrarEliminarUS').click(function() {
        $('#MiPopEliminarUS').fadeOut('slow');
        return false;
    });

    $('#btnEliminarUsuario').click(function() {
        var Equipo_Id = $('input[type=radio][name=Equipos]:checked').attr('id');
        EliminaUsEquipo();
        //alert("fin");
        //$('#MiPopEliminarUS').fadeOut('slow');
        VerUsuarioaEliminar(Equipo_Id);

        //$('#MiPopEliminarUS').fadeIn('slow');

    });

    $('#btnInvitaciones').click(function() {
        $('#MiPopUpPendientes').fadeIn('slow');
        VerListadoPendiente();

    });

    $('#MiCerrarPendientes').click(function() {
        $('#MiPopUpPendientes').fadeOut('slow');
        return false;
    });

    //    $("button").click(function() {
    //        alert($(this).attr('id'));
    //        alert(this.id); // or alert($(this).attr('id'));
    //    });

    $('#btnAceptarInv').click(function() {
        //alert("1");
        var InvitacionEquipo_Id = $('input[type=radio][name=InvitacionEquipos]:checked').attr('id');
        //alert("2");
        //alert(InvitacionEquipo_Id);
        if (InvitacionEquipo_Id > 0) {
            ActualizaInvitacion(InvitacionEquipo_Id, 1);
            alert("Acepta Invitacion");
            $('#MiPopUpPendientes').fadeOut('slow');
            VerListadoPendiente();
            $('#MiPopUpPendientes').fadeIn('slow');
        }
        else {
            alert("no ha seleccionado Equipo");
        }

    });

    $('#btnRechazarInv').click(function() {
        var InvitacionEquipo_Id = $('input[type=radio][name=InvitacionEquipos]:checked').attr('id');
        if (InvitacionEquipo_Id > 0) {
            //Funcion Rechazar Invitacion
            ActualizaInvitacion(InvitacionEquipo_Id, 2)
            alert("Rechazar Invitacion");
            VerListadoPendiente();

        }
        else {
            alert("no ha seleccionado Equipo");
        }
    });

    $('#btnConversaciones').click(function() {
    //aqui listar todas las conversaciones
       // y dentro de ellas ir seleccionando las que quieran cerrar
 
    });
    


});

function ObtenerIdUsuario() {
    var resultado;
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/ObtenerIdUsuariodeSession",
        async: false,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}

function ModificaEquipo(Equipo_id, strNewNombre, strNewDesc) {
    var resultado;
    var dataToSend = "{'Id_Equipo': " + Equipo_id + ", strNombre: '" + strNewNombre + "'" + ", strDescripcion: '" + strNewDesc + "'}";
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/ModificarEquipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            alert(result.d)
            resultado = result.d;
        }
    });
    return resultado;
}

function EliminaEquipo(Equipo_id) {
    var resultado;
    var dataToSend = "{'Id_Equipo': " + Equipo_id + "}";
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/EliminarEquipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            alert(result.d)
            resultado = result.d;
        }
    });
    return resultado;
}

function EliminaUsEquipo() {
    var resultado;
    var Eq_Id = $('input[type=radio][name=Equipos]:checked').attr('id');
    var valor = $('input:radio[name=ListaUsuarioEL]:checked').val();
    //var IdUsuario = $('input[type=radio][name=ListaUsuarioEL]:checked').attr('id');
    var IdUsuarioADM = ObtenerIdUsuario();

    //var dataToSend = "{'Id_Equipo': " + Equipo_id + "}";
    //alert(IdUsuarioADM + ", " + valor + ", " + Eq_Id);

    //var dataToSend = "{'Id_UsuarioADM': " + IdUsuarioADM + ", 'Id_Usuario': " + IdUsuario + ", 'Id_Equipo': " + Equipo_id + "}";

    //var dataToSend = "{'Id_UsuarioADM': " + IdUsuarioADM + ", 'Id_Usuario': " + valor + ", 'Id_Equipo': 324345464647474747}";
    var dataToSend = "{'Id_UsuarioADM': " + IdUsuarioADM + ", 'Id_Usuario': " + valor + ", 'Id_Equipo': " + Eq_Id + "}";

    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/EliminarUsuarioEquipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            //alert(result.d)
            resultado = result.d;
        }
    });
    return resultado;
}


function DelegarEquipo(Equipo_id, IdUsuarioNuevo) {
    var resultado;

    //var dataToSend = "{'ID_Usuario_nuevo': " + IdUsuarioNuevo + "}";

    var dataToSend = "{'Id_Equipo': " + Equipo_id + ", 'ID_Usuario_nuevo': " + IdUsuarioNuevo + "}";
    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/DelegarEquipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            resultado = result.d;
            //alert(resultado);
        }
    });
    return resultado;
}

function VerMiembros(Equipo_Id) {
    var resultado;
    var dataToSend = "{'Id_Equipo': " + Equipo_Id + "}";

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/ListadeUsuariodeEquipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            $('#tbListadoUsuarios td').remove();
            if (result.d[0] != null) {
                var grid = $('#tbListadoUsuarios');
                $.each(result.d, function(index) {
                    var row = "<tr class=\"";
                    if (index % 2 == 0)
                        row += "gridRow";
                    else
                        row += "gridAltRow";

                    row += "\">";
                    if (this.Es_Adm == 'S') {
                        row += "<td>"
                        row += "<span  <font style='font-size:small; font-weight:bold'>" + this.Nombre + "</font></span>";
                        row += "</td>";
                    }
                    else {
                        row += "<td>"
                        row += "<input  type='radio' name='ListaDelegar' id='" + this.IdUsuario + "' value=" + this.IdUsuario + " /> <span  <font style='font-size:small; font-weight:bold'>" + this.Nombre + "</font></span>";
                        row += "</td>";

                    }
                    row += "<td>"
                    row += "<span >  <font style='font-size:xx-small'>" + this.Es_Adm + "</font></span>";
                    row += "</td>";
                    row += "</tr>"
                    grid.find('> tbody').append(row);
                });
                grid.show();
            }
            else {
                $('#tbListadoUsuarios').css('display', 'none');
            }
        }
    });
    return resultado;
}

function VerUsuarioaEliminar(Equipo_Id) {
    var resultado;
    var dataToSend = "{'Id_Equipo': " + Equipo_Id + "}";

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/ListadeUsuariodeEquipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            $('#tbListadoUS td').remove();
            if (result.d[0] != null) {
                var grid = $('#tbListadoUS');
                $.each(result.d, function(index) {
                    var row = "<tr class=\"";
                    if (index % 2 == 0)
                        row += "gridRow";
                    else
                        row += "gridAltRow";

                    row += "\">";
                    if (this.Es_Adm == 'S') {
                        row += "<td>"
                        row += "<span  <font style='font-size:small; font-weight:bold'>" + this.Nombre + "</font></span>";
                        row += "</td>";
                    }
                    else {
                        row += "<td>"
                        row += "<input  type='radio' name='ListaUsuarioEL' id=" + this.IdUsuario + " value=" + this.IdUsuario + " /> <span  <font style='font-size:small; font-weight:bold'>" + this.Nombre + "</font></span>";
                        row += "</td>";

                    }
                    row += "</tr>"
                    grid.find('> tbody').append(row);
                });
                grid.show();
            }
            else {
                $('#tbListadoUS').css('display', 'none');
            }
        }
    });
    return resultado;
}


function MostrarDatosdelEquipo(Equipo_Id) {
    var dataToSend = "{'Id_Equipo': " + Equipo_Id + "}";
    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/DatosEquipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            // alert(result.d);
            // alert(result.d[NOMBRE_EQUIPO]);
            if (result.d[0] != null) {
                $.each(result.d, function(index) {
                    $('#lblNombre').html(this.NOMBRE_EQUIPO);
                    $('#lblDescripcion').html(this.DESCRIPCION_EQUIPO);
                    $('#txtnombre').attr('value', this.NOMBRE_EQUIPO);
                    $('#txtdescripcion').attr('value', this.DESCRIPCION_EQUIPO);
                });
            }
            else {

            }
        }
    });
}


function ListarEquipos() {
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/ListarEquipos",
        async: false,
        success: function(result) {
            $('#ListadoEquipos td').remove();
            if (result.d[0] != null) {
                var grid = "";
                var row = "";
                $.each(result.d, function(index) {
                    row = "<tr>";
                    grid = $('#ListadoEquipos');
                    row += "<td>";
                    row += "<input type='radio' name='Equipos' id=" + this.ID_EQUIPO + " value=" + this.TIPO + " />";
                    row += "</td>";
                    row += "<td>";
                    row += "<span><font style='font-size:small; font-weight:bold'>" + this.NOMBRE_EQUIPO + "</font></span>";
                    row += "</td>";
                    row += "<td>";
                    row += "<span><a href='www.google.cl' >" + this.CANTIDAD_USUARIOS + "</a></span>";
                    row += "</td>";

                    if (this.TIPO == 1) {
                        row += "<td>";
                        row += "<label> Administras </label>";
                        row += "</td>";
                    }
                    else {
                        row += "<td>";
                        row += "<label> Participas </label>";
                        row += "</td>";

                    }
                    //                        row += "<img src='images/Eliminar.png'  id='img_Eliminar_" + this.ID_EQUIPO + "' alt='Eliminar Equipo' title='Eliminar Equipo' visible='true'/>";
                    //                        row += "</td>";
                    //                        row += "<td>";
                    //                        row += "<img src='images/Delegar.png'  id='img_Delegar_" + this.ID_EQUIPO + "' alt='Delegar Equipo' title='Delegar Equipo' visible='true'/>";
                    //                        row += "</td>";
                    //                    }
                    //                    else {
                    //                        row += "<td colspan='3'>";
                    //                        row += "</td>";
                    //                    }
                    grid.find('> tbody').append(row);
                });
                grid.show();
            }
            else {
                $('#ListadoEquipos').css('display', 'none');
            }
        }
    });
}





function GrabarEquipo(strNombrenuevo, strNewDesc) {
    var resultado;
    var IdUsuario = ObtenerIdUsuario();
    //var dataToSend = "{'strNombre': '" + strNombrenuevo + "'}";
    var dataToSend = "{'IdUser': " + IdUsuario + ", strNombre: '" + strNombrenuevo + "'" + ", strDescripcion: '" + strNewDesc + "'}";
    //alert(dataToSend);

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/GrabarEquipos",
        async: false,
        data: dataToSend,
        success: function(result) {
            //alert(result.d[0].ID_EQUIPO);
            if (result.d != null) {
                $.each(result.d, function(index) {
                    //alert(this.ID_EQUIPO)
                    ////
                    resultado = this.ID_EQUIPO
                });
            }
            else {

            }
        }

    });
    return resultado;
}

function VerListadoPendiente() {
    var resultado;
    //var dataToSend = "{'Id_Equipo': " + Equipo_Id + "}";

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/ListarInvitacionesPendientes",
        async: false,
        //data: dataToSend,
        success: function(result) {
            $('#tbPendientes td').remove();
            if (result.d[0] != null) {
                var grid = $('#tbPendientes');
                $.each(result.d, function(index) {
                    var row = "<tr class=\"";
                    if (index % 2 == 0)
                        row += "gridRow";
                    else
                        row += "gridAltRow";

                    row += "\">";

                    row += "<td>"
                    row += "<input type='radio' name='InvitacionEquipos' id=" + this.ID_INVITACION_A_EQUIPO + " value=" + this.ID_EQUIPO + " />";
                    row += " <span>" + this.NOMBRE_EQUIPO + "</span>";
                    row += "</td>";
                    row += "<td>"
                    row += " <span>" + this.FECHA_INV_ENVIADA + "</span>";
                    row += "</td>";
                    //row += "<td>"
                    //row += " <input type='button' class='link_btn_rounded' id='btnAceptarInv' value='Aceptar'  />";
                    //row += " <input type='button' class='link_btn_rounded' id='btnRechazarInv' value='Rechazar'  />";
                             //<input type="button" class="link_btn_rounded" id="btnEliminarUsuario"  value="Grabar"  />
                    //row += "<button type='button' id=" + this.ID_INVITACION_A_EQUIPO + ">Aceptar</button>"
                    //row += "<button type='button' id=" + this.ID_INVITACION_A_EQUIPO + ">Rechazar</button>"
                    //row += "</td>";


                    row += "</tr>"
                    grid.find('> tbody').append(row);
                });
                grid.show();
            }
            else {
                $('#tbPendientes').css('display', 'none');
            }
        }
    });
    return resultado;
}


function ActualizaInvitacion(InvEquipo_id, Tipo) {
    var resultado;
    var dataToSend = "{'ID_INVITACION_A_EQUIPO': " + InvEquipo_id + ", 'intTipo': " + Tipo + "}";
    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Equipos.aspx/ActualizarInvitacionPendiente",
        async: false,
        data: dataToSend,
        success: function(result) {
            resultado = result.d;
            //alert(resultado);
        }
    });
    return resultado;
}



//function MostrarEquipos() {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        url: "Crear_Equipo.aspx/ListarEquipos",
//        async: false,
//        //data: dataToSend,
//        success: function(result) {
//            //alert(result);
//            $('#lista1 li').remove();
//            $('#lista2 li').remove();
//            $('#lista1 h3').remove();
//            $('#lista2 h3').remove();
//            if (result.d[0] != null) {
//                var grid = "";
//                var row = "";
//                var contaLista1 = 0;
//                var contaLista2 = 0;
//                $.each(result.d, function(index) {
//                    row = "";
//                    if (this.TIPO == 1) {
//                        grid = $('#lista1');
//                        if (contaLista1 == 0) {
//                            row = "<h3>Administras a:</h3> <br/>";
//                            contaLista1 = 1;
//                        }
//                    }
//                    else {
//                        grid = $('#lista2');
//                        if (contaLista2 == 0) {
//                            row = "<h3>Participas en:</h3> <br/>";
//                            contaLista2 = 1;
//                        }
//                    }


//                    row += "<li>"
//                    row += "<span  <font style='font-size:small; font-weight:bold'>" + this.NOMBRE_EQUIPO + "</font></span>";
//                    row += "</li>";
//                    //row += "</tr>"
//                    //alert(row);
//                    //$('#lista1').append(row);
//                    grid.append(row);
//                    //grid.find('> tbody').append(row);
//                });
//                //grid.show();
//            }
//            else {
//                $('#lista1').css('display', 'none');
//                $('#lista2').css('display', 'none');
//            }
//        }
//    });
//}


//function MostrarEquiposLuegodeGrabar() {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        url: "Crear_Equipo.aspx/ListarEquipos",
//        async: false,
//        //data: dataToSend,
//        success: function(result) {
//            //alert(result);
//            $('#lista1 li').remove();
//            $('#lista2 li').remove();
//            if (result.d[0] != null) {
//                var grid = "";
//                var row = "";
//                var contaLista1 = 0;
//                var contaLista2 = 0;
//                $.each(result.d, function(index) {
//                    row += "<li>"
//                    row += "<span  <font style='font-size:small; font-weight:bold'>" + this.NOMBRE_EQUIPO + "</font></span>";
//                    row += "</li>";
//                    grid.append(row);

//                });
//                //grid.show();
//            }
//            else {
//                $('#lista1').css('display', 'none');
//                $('#lista2').css('display', 'none');
//            }
//        }
//    });
//}