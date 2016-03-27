$(document).ready(function() {

    $('#usa_email').css('display', 'block');
    $('#usa_libreta').css('display', 'none');

    var EsAdm = esAdministrador();
    if (EsAdm > 0) {
        $('#cnt_contentMail').css('display', 'block');
        //MostrarEquipos();
        LlenarComboEquipos();
    }
    else {
        $('#cnt_contentMail').css('display', 'none');
    }


    //evento al hacer clic en el boton agregar
    $('#btnAgregar').click(function() {
        //alert("hola");
        //obtenemos el nombre digitado por el usuario, y el limite establecido
        //con la funcion parseInt() convertimos de texto a numero
        var tipo = 0;
        var texto = ""
        if ($('#rdoemail').is(':checked')) {
            texto = $("#Email").val(); ;
            tipo = 1;
        }
        if ($('#rdolibreta').is(':checked')) {
            texto = $("#txtNombre").val();
            tipo = 2;
        }
        //alert(texto);


        //        var $txtNombre = texto, iLimite = parseInt($('#selLimite').val());
        //        alert($txtNombre);
        //        //verificamos que el campo nombre no este vacio
        //        if ($.trim(texto) != '') {
        //            //variable para contener la lista html
        //            var $ulLista;
        //            //si la lista html no existe entonces la agregamos al dom
        if (!$('#divLista').find('ul').length) {
            //alert("0");
            $('#divLista').append('<ul/>');
            //alert("1");
        }
        //            //obtenemos una instancia de la lista
        $ulLista = $('#divLista').find('ul');
        //alert("2");

        //            //verificamos el limite de elementos
        //            if ($ulLista.find('li').length < iLimite || iLimite == 0) {
        //                //creamos el item que va a contener el nombre y el boton eliminar
        var liNuevoNombre = $('<li class="Usuarios" />').html('<a class="clsEliminarElemento">&nbsp;</a>' + $.trim(texto));
        //alert("3");
        //alert(liNuevoNombre);
        //                //verificamos la posicion en la que debemos agregar el nuevo elemento (inicio o final de la lista)
        //                //                if ($('#chkAgregarAlInicio').is(':checked')) {
        //                //                    //agregamos el elemento al inicio (con prepend)
        //                //                    $ulLista.prepend($liNuevoNombre);
        //                //                } else {
        //                //agregamos el elemento al final de la lista (con append)
        $ulLista.append(liNuevoNombre);
        //                //                }
        //                //no se pueden agregar mas elementos, debido al limite establecido
        //            } else {
        //                alert('No es posible agregar el elemento. Se permiten solamente ' + iLimite + '.');
        //            }
        //            //el campo nombre esta vacio
        //        } else {
        //            alert('Por favor, digite el nombre que desea agregar a la lista.')
        //        }
        //        //limpiamos el campo nombre y lo enfocamos
        //        //$txtNombre.val('').focus();

        //        if (tipo == 1) {
        //            $("#Email").val('').focus;
        //        }
        //        if (tipo == 2) {
        //            $("#txtNombre").val('').focus;
        //        }
    });

    $('.clsEliminarElemento').click(function() {
        //buscamos la lista
        var $ulLista = $('#divLista').find('ul');
        //buscamos el padre del boton (el tag li en el que se encuentra)
        var $liPadre = $($(this).parents().get(0));

        //eliminamos el elemento
        $liPadre.remove();
        //si la listaesta vacia entonces la eliminamos del dom
        if ($ulLista.find('li').length == 0) $ulLista.remove();
    });



    $("input[name=Equipos]").click(function() {
        var ids = "";
        var noms = "";

        //alert("ff");
        $("input:checkbox:checked").each(
        function() {
            //alert("El checkbox con valor " + $(this).val() + " está seleccionado");

            ids = ids + $(this).attr('id') + ";";
            noms = noms + $(this).val() + ";";


        }
    );

        //alert(ids);
        $('#num_eq').attr('value', ids);
        $('#nom_eq').attr('value', noms);


    });



    //    //hacer accion del boton ver equipos
    //    //al hacer cli se debe, mostrar los equipo que el usuario administra
    //    $('#btnSeleccionaEquipo').click(function() {
    //        $('#DivEquipos').fadeIn('slow');

    //    });

    //    $('#MiCerrar').click(function() {
    //        $('#DivEquipos').fadeOut('slow');
    //        return false;
    //    });

    $('#rdoemail').click(function() {
        $('#usa_email').css('display', 'block');
        $('#usa_libreta').css('display', 'none');
        $('#txtNombre').attr('value', '');
    });

    $('#rdolibreta').click(function() {
        $('#usa_email').css('display', 'none');
        $('#usa_libreta').css('display', 'block');
        $('#Email').attr('value', '');
        var id = ObtenerIdUsuario();
        var options = ObtieneLibreta(id);
        $("#txtNombre").easyAutocomplete(options);

    });

    $('#btnInvitar').click(function() {
        //$( "#cboEjemplo option:selected" ).text();
        var Equipo_id = $("#cboEjemplo option:selected").val();
        var Equipo_Nombre = $("#cboEjemplo option:selected").text();
        //alert(Equipo_id + ' - ' + Equipo_Nombre);
        $(".Usuarios").each(function() {
            var strNuevoUsuario = $(this).text();
            //alert(Equipo_id + ' - ' + Equipo_Nombre + ' - ' + strNuevoUsuario);
            var result = InvitarPorUsuario(strNuevoUsuario, Equipo_id, Equipo_Nombre);
            alert(result);



        });



        //        var strMail = $('#Email').val();
        //        var strIdsEquipos = $("#num_eq").val();
        //        var strNomsEquipos = $("#nom_eq").val();
        //        var strNombre = $("#txtNombre").val();

        //        //alert(strMail + ' - ' + strIdsEquipos + ' - ' + strNomsEquipos + ' - ' + strNombre);

        //        var result = Invitar(strMail, strNombre, strIdsEquipos, strNomsEquipos);


        //        $("#MensajedelEnvio").html(result);
        //        $('#num_eq').attr('value', '');
        //        $('#nom_eq').attr('value', '');
        //        $('#Email').attr('value', '');
        //        $('#txtNombre').attr('value', '');



        //        $("input:checkbox:checked").each(
        //            function() {
        //                $(this).checked = false;
        //            }
        //        );

    });





    //    $('#btnBuscar').click(function() {
    //        $('#DivBuscarUsuario').fadeIn('slow');
    //  
    //        var id = ObtenerIdUsuario();
    //        var options = {
    //            url: "http://localhost/PLWeb4_7/WsParaLideres.asmx/Lista_Libreta_Usuarios?Id_Usuario_Admin=" + id,

    //            getValue: "NOMBRE",

    //            list: {
    //                match: {
    //                    enabled: true
    //                }
    //            }
    //        };

    //        $("#txtNombre").easyAutocomplete(options);
    //    });


    //    $('#UsuarioCerrarMiCerrar').click(function() {
    //        $('#DivBuscarUsuario').fadeOut('slow');
    //        return false;
    //    });

    //MostrarEquiposdelAdm();

});

function esAdministrador() {
    var resultado;
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Invitacion_a_Equipo.aspx/Es_Administrador_de_algun_Equipo",
        async: false,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}

//getValue: "NOMBRE",

function ObtieneLibreta(id) {

    //url: "http://qa.paralideres.org/WsParaLideres.asmx/Lista_Libreta_Usuarios?Id_Usuario_Admin=" + id,
    var resultado = {
        url: "http://localhost/PLWeb5_0/WsParaLideres.asmx/Lista_Libreta_Usuarios?Id_Usuario_Admin=" + id,

        getValue: function(element) {
            return element.NOMBRE + '; ' + element.ID;
        },

        list: {
            match: {
                enabled: true
            }
        }
    };
    return resultado;

}

function ObtenerIdUsuario() {
    var resultado;
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Invitacion_a_Equipo.aspx/ObtenerIdUsuariodeSession",
        async: false,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}

function Invitar(strEmail, strNombres, strIdsEq, strNomsEQ) {
    var resultado;
    var dataToSend = "{'strMail': '" + strEmail + "', strNombre: '" + strNombres + "', strIdEquipos: '" + strIdsEq + "'" + ", strNombreEquipos: '" + strNomsEQ + "'}";
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Invitacion_a_Equipo.aspx/Invitar_Usuario",
        async: false,
        data: dataToSend,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}
function InvitarPorUsuario(strNuevoUsuario, IdEquipo, strNombreEquipo) {
    var resultado;
    var dataToSend = "{'strNombre': '" + strNuevoUsuario + "', Id_Equipo: '" + IdEquipo + "'" + ", strNombre_Equipo: '" + strNombreEquipo + "'}";
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Invitacion_a_Equipo.aspx/Invitar_x_Usuario",
        async: false,
        data: dataToSend,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}

function LlenarComboEquipos() {
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Invitacion_a_Equipo.aspx/ListarEquipos",
        async: false,
        success: function(result) {
            if (result.d[0] != null) {
                $.each(result.d, function(index) {
                    var option = $(document.createElement('option'));
                    option.text(this.NOMBRE_EQUIPO);
                    option.val(this.ID_EQUIPO);
                    $("#cboEjemplo").append(option);
                });
            }
            else {
                $("#dvAlerta > span").text("Error al llenar el combo");
            }
        }
    });
}



function MostrarEquipos() {
    var cantidadRegistros = 0;
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Invitacion_a_Equipo.aspx/CantidadEquipos",
        async: false,
        success: function(result) {
            cantidadRegistros = result.d;
        }
    });





    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Invitacion_a_Equipo.aspx/ListarEquipos",
        async: false,
        success: function(result) {
            $('#lista1 li').remove();
            $('#lista1 h3').remove();
            if (result.d[0] != null) {
                var grid = "";
                var contaLista1 = 0;
                $.each(result.d, function(index) {
                    var row = "";
                    if (this.TIPO == 1) {
                        grid = $('#lista1');
                        if (contaLista1 == 0) {
                            row = "<h3>Invitar al Equipo:</h3> <br/>";
                            contaLista1 = 1;
                        }
                        if (cantidadRegistros == 1) {
                            row += "<li>";
                            row += "<input type='checkbox' name='Equipos' disabled  checked id=" + this.ID_EQUIPO + " value=" + this.NOMBRE_EQUIPO + "/><span>  <font style='font-size:small; font-weight:bold'>" + this.NOMBRE_EQUIPO + "</font></span>";
                            row += "</li>";
                        }
                        else {
                            row += "<li>";
                            row += "<input type='checkbox' name='Equipos' id=" + this.ID_EQUIPO + " value=" + this.NOMBRE_EQUIPO + "/><span>  <font style='font-size:small; font-weight:bold'>" + this.NOMBRE_EQUIPO + "</font></span>";
                            row += "</li>";

                        }
                    }

                    grid.append(row);
                });



            }
            else {
                $('#lista1').css('display', 'none');
            }
        }
    });
}