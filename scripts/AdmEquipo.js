$(document).ready(function() {


    var NombredelEquipo = TraerNombreEquipo();
    //$('#NombreEquipo').val(NombredelEquipo);
    $('#NombreEquipo').html(NombredelEquipo);

    var TotalUsuario = CantidadUsuarios();
    $('#CantidadUsuarios').html(TotalUsuario);

    $('#btn_ModificarEQ').click(function() {
        $('#MiPopMod').fadeIn('slow');
        $('#CambioNombre').hide();
        $('#CambioNombre').show();
        $('#txtNombre').focus();
    });

    $('#MiCerrarMod').click(function() {
        $('#MiPopMod').fadeOut('slow');
        return false;
    });

    $('#btnGrabar').click(function() {
        //alert('Modificare Equipo');
        var resultado = ModificaEquipo();
        alert(resultado);
        if (resultado != "") {
            //var NombredelEquipo = TraerNombreEquipo();
            //alert(NombredelEquipo);
            $('#NombreEquipo').html(resultado);
            //$("#<%=NombreEquipo.ClientID%>").text(NombredelEquipo);

            //$('#NombreEquipo').val(NombredelEquipo);
            //alert("Se modificó con exito");
            $('#MiPopMod').fadeOut('slow');
        }
        else {

            $('#MiPopMod').fadeOut('slow');
        }
    });



    $('#btnDelegar').click(function() {

        var valor = $('input:radio[name=ListaDelegar]:checked').val();

        if (valor > 0) {
            DelegarEquipo(valor);

            $('#btn_ModificarEQ').hide();
            $('#btn_EliminarEQ').hide();
            $('#btn_DelegarEQ').hide();
            $('#MiPopDele').fadeOut('slow');

        }
        else {
            alert("Seleccione un Miembro del equipo!!!");
        }
    });





    $('#btn_EliminarEQ').click(function() {

        alert('Eliminare Equipo');
        var resultado = ElminarEquipo();
        if (resultado > 1) {
            alert("Se Eliminó con exito");

        }


    });

    $('#btn_DelegarEQ').click(function() {
        $('#MiPopDele').fadeIn('slow');
        //alert('Delegar Equipo');
        VerMiembros();
        //$('#MiCerrarDele').fadeOut('slow');

    });

    $('#btn_VerUsuarios').click(function() {
        $('#MiPopVerUsu').fadeIn('slow');
        VerUsuarios();

    });

    $('#MiCerrarVerUsu').click(function() {
        $('#MiPopVerUsu').fadeOut('slow');
        return false;
    });

    $('#MiCerrarDele').click(function() {
        $('#MiPopDele').fadeOut('slow');
        return false;
    });
});


function CantidadUsuarios() {
    var resultado;

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Ver_Equipo.aspx/CantidadUsuariosxEquipo",
        async: false,
        //data: dataToSend,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}



function VerUsuarios() {
    var resultado;
    //var contador = 1;

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Ver_Equipo.aspx/ListadeUsuariodeEquipo",
        async: false,
        //data: dataToSend,
        success: function(result) {
            $('#tbListadodeUsuarios td').remove();
            if (result.d[0] != null) {
                var grid = $('#tbListadodeUsuarios');
                $.each(result.d, function(index) {
                    var row = "<tr class=\"";
                    if (index % 2 == 0)
                        row += "gridRow";
                    else
                        row += "gridAltRow";

                    row += "\">";
                    row += "<td>"
                    row += "<span  <font style='font-size:small; font-weight:bold'>" + this.Nombre + "</font></span>";
                    row += "</td>";
                    row += "</tr>"
                    grid.find('> tbody').append(row);
                });
                grid.show();
            }
            else {
                $('#tbListadodeUsuarios').css('display', 'none');
            }
        }
    });
    return resultado;
}


function VerMiembros() {
    var resultado;
    //var contador = 1;

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Ver_Equipo.aspx/ListadeUsuariodeEquipo",
        async: false,
        //data: dataToSend,
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





function ModificaEquipo() {
    //alert('si')
    var resultado;
    var strNewNombre = $('#txtNombre').val();
    var dataToSend = "{'strNombre': '" + strNewNombre + "'}";
    //alert(dataToSend);


    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Ver_Equipo.aspx/ModificarEquipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}

function ElminarEquipo() {
    var resultado;

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Ver_Equipo.aspx/EliminarEquipo",
        async: false,
        //data: dataToSend,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}

function TraerNombreEquipo() {
    var resultado;

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Ver_Equipo.aspx/MostrarNombreEquipo",
        async: false,
        //data: dataToSend,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}

function DelegarEquipo(IdUsuarioNuevo) {
    var resultado;

    var dataToSend = "{'ID_Usuario_nuevo': " + IdUsuarioNuevo + "}";
    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "Ver_Equipo.aspx/DelegarEquipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            resultado = result.d;
            //alert(resultado);
        }
    });
    return resultado;
}

