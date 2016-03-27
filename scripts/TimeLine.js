$(document).ready(function() {
    VerTimeLineEquipo();

//    $('img').click(function() {
//        var id = this.id;
//        var n = id.indexOf("&");
//        var num_p = id.substring(0, n);
//        var num_eq = id.substring(n + 1);
//        $('#num_pag').attr('value', num_p);
//        $('#num_eq').attr('value', num_eq);
//        var numero_pagina = $("#num_pag").val();
//        var numero_equipo = $("#num_eq").val();
//        //alert('numero_pagina ' + numero_pagina);
//        $('#MiPopUpCom').fadeIn('slow');
//        MostrarResenaCreada(numero_pagina, numero_equipo);
//        $('#MuestraComentarios').hide();
//        $('#MuestraComentarios').show();
//        $('#Comentario').focus();
//    });

    $("img").live('click', function() {
        var id = this.id;
        var n = id.indexOf("&");
        var num_p = id.substring(0, n);
        var num_eq = id.substring(n + 1);
        $('#num_pag').attr('value', num_p);
        $('#num_eq').attr('value', num_eq);
        var numero_pagina = $("#num_pag").val();
        var numero_equipo = $("#num_eq").val();
        //alert('numero_pagina ' + numero_pagina);
        $('#MiPopUpCom').fadeIn('slow');
        MostrarResenaCreada(numero_pagina, numero_equipo);
        $('#MuestraComentarios').hide();
        $('#MuestraComentarios').show();
        $('#Comentario').focus();
    });


    $('#MiCerrarCom').click(function() {
    $('#MiPopUpCom').fadeOut('slow');
    VerTimeLineEquipo();
        return false;
    });


    $('#btnComentar').click(function() {
        var numero_pagina = $("#num_pag").val();
        var numero_equipo = $("#num_eq").val();
        var nombreComentario = '#Comentario_' + numero_pagina + '&' + numero_equipo;
        //alert(numero_pagina);
        var Resena = $('#Comentario').val();
        var resultado;
        if (Resena != '') {
            var vExiste = Existe_Recurso(numero_equipo, numero_pagina);
            //alert(vExiste);
            var arr = vExiste.split('|');
            if (arr[0] == 1) {
                $('#num_eq_rec').attr('value', arr[1]);
            }
            var Equipo_Recurso_Id = $('#num_eq_rec').val();
            GrabarComentario(numero_pagina, numero_equipo, Equipo_Recurso_Id);
            resultado = TraeCantidadComentarios(numero_pagina, numero_equipo);
            //alert(resultado);
            if (resultado > 0) {
//                if (resultado == 1) {
//                    alert('1');
//                    $(nombreComentario).html(resultado);
//                    
//                }
//                else if (resultado > 1) {
//                    alert('>1'); 
//                    $(nombreComentario).html(resultado);
//                    
//                }
                //$('#MiPopUpCom').fadeIn('slow');
                $('#MiPopUpCom').hide();
                MostrarResenaCreada(numero_pagina, numero_equipo);
                $('#MiPopUpCom').fadeIn('slow');
                $('#Comentario').val('');
                $('#Comentario').focus();
            }
        }
        else {
            alert('debe escribir un comentario');
            $('#Comentario').focus();
        }
    });


});


function Existe_Recurso(EquipoId, PageId) {
    var resultado = '0|0';
    var dataToSend = "{'ID_Equipo': " + EquipoId + ", 'ID_PAGINA': " + PageId + "}";

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "VerArticulo.aspx/Existe_Recurso_En_Equipo",
        async: false,
        data: dataToSend,
        success: function(result) {
            if (result.d[0] != null) {
                $.each(result.d, function(index) {
                    var vExisteRecursoCompartido = this.EXISTE_RECURSO_COMPARTIDO;
                    var vIdEquipoRecurso = this.ID_EQUIPO_RECURSO;
                    var vdatos = vExisteRecursoCompartido + "|" + vIdEquipoRecurso;
                    //alert(vdatos);
                    resultado = vdatos;
                });
            }
        }
    });
    //alert(resultado);
    return resultado;
}

function VerTimeLineEquipo() {
    var resultado;
    //var contador = 1;

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "TimeLine_Equipo.aspx/ListaTimeLineEquipo",
        async: false,
        //data: dataToSend,
        success: function(result) {
            $('#tbTimeLine td').remove();
            if (result.d[0] != null) {
                var grid = $('#tbTimeLine');
                $.each(result.d, function(index) {
                    var row = "<tr>"
                    //                    var row = "<tr class=\"";
                    //                    if (index % 2 == 0)
                    //                        row += "gridRow";
                    //                    else
                    //                        row += "gridAltRow";
                    //                    row += "\">";
                    //style='width:300px'
                    row += "<td >"
                    row += "<span  <font style='font-size:small; font-weight:bold'>" + this.NOMBRE_EQUIPO + "</font></span>";
                    row += "</td>";
                    row += "<td >"
                    row += "<span  <font style='font-size:small; font-weight:bold'>" + this.ARTICULO + "</font></span>";
                    row += "</td>";
                    row += "<td >"
                    row += "<span >  <font style='font-size:xx-small'> <img src='images/Comentar.jpg'  id=" + this.PAGE_ID + "&" + this.ID_EQUIPO + " alt='Comentarios del Recurso' title='Comentarios del Recurso' onmouseover=this.style.cursor='hand'  /> <label id='Comentario_" + this.PAGE_ID + "&" + this.ID_EQUIPO + "' >" + this.CANTIDAD_COMENTARIOS + " </label></font></span>";
                    row += "</td>";
                    row += "<td >"
                    row += "<span >  <font style='font-size:xx-small'>" + this.FECHA_ULTIMO_POST + "</font></span>";
                    row += "</td>";
                    row += "</tr>"
                    grid.find('> tbody').append(row);
                });
                grid.show();
            }
            else {
                $('#tbTimeLine').css('display', 'none');
            }
        }
    });
    return resultado;
}

function MostrarResenaCreada(Idp, IdEq) {
    var resultado;
    var Tipo = 'T';

    //var dataToSend = "{'IdPagina': " + Idp + "}";
    //var dataToSend = "{'IdPagina': " + Idp + ", Tipo: '" + Tipo + "'}";
    var dataToSend = "{'IdPagina': " + Idp + ", IdEquipo: " + IdEq + ", Tipo: '" + Tipo + "'}";

    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "TimeLine_Equipo.aspx/ObtenerResenaComentarios",
        async: false,
        data: dataToSend,
        success: function(result) {
            $('#tbResultadoResenaComentarios div').remove();
            if (result.d[0] != null) {
                var grid = $('#tbResultadoResenaComentarios');
                $.each(result.d, function(index) {
                    var row = "<div>";
                        row += "<dl>";
                        row += "<dt>";
                        if (this.FOTOAUTOR == '') {
                            row += "<img  src='./assets/imgs/authors/author_md.jpg' </img>";
                        }
                        else {
                            row += "<img width='50px' height='70px'  src='http://www.paralideres.org/images/" + this.FOTOAUTOR + "'</img>";
                        }
                        row += "<span > &nbsp; <font style='font-size:xx-small'>" + this.USUARIO + "</font></span>";
                        row += "</dt>";
                        row += "<dd>";
                        row += "<span  <font style='font-size:small; font-weight:bold'>" + this.RESENA_COMENTARIO + "</font></span>";
                        row += "<br />";
                        row += "<span >  <font style='font-size:xx-small'>" + this.FECHA_APORTE + "</font></span>";
                        row += "</dd>";
                        row += "</dl>";
                        row += "<br />";
                        row += "</div>";
                    grid.find('> tbody').append(row);
                });
                grid.show();

            }
            else {
                $('#tbResultadoResenaComentarios').css('display', 'none');

            }
        }
    });
    return resultado;

}

function GrabarComentario(Idp, IdEq, IdEqRec) {
    var resultado;
    var Cantidad = 1;
    var Resena = $('#Comentario').val();
    var Tipo = 'C';

    //var dataToSend = "{'IdPagina': " + Idp + ", Comentario: '" + Resena + "'" + ", Tipo: '" + Tipo + "'}";
    //var dataToSend = "{'IdPagina': " + Idp + ", IdEquipo: " + IdEq + ", Comentario: '" + Resena + "'" + ", Tipo: '" + Tipo + "'," + " IdEquipo: " + IdEqRec + "}";
    var dataToSend = "{'IdPagina': " + Idp + ", IdEquipo: " + IdEq + ", Comentario: '" + Resena + "'" + ", Tipo: '" + Tipo + "'" + ", IdEquipoRecurso: '" + IdEqRec + "'}";
    ////url: "TimeLine_Equipo.aspx/GuardarComentario",
        
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "VerArticulo.aspx/GuardarComentario",
        async: false,
        data: dataToSend,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}

function TraeCantidadComentarios(Idp, IdEq) {
    var resultado;
    var dataToSend = "{'IdPagina': " + Idp + ", IdEquipo: " + IdEq + "}";
    //alert('dataToSend');
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "TimeLine_Equipo.aspx/ObtenerCantidadComentarios",
        async: false,
        data: dataToSend,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;

}

