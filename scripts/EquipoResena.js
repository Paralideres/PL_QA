var Idp = ObtenerValorParametroUrl('Idp');
var CantidadResena = ObtenerValorParametroUrl('CantidadResenaEquipo');
var CantidadComentario = ObtenerValorParametroUrl('CantidadComentarioEquipo');


$(document).ready(function() {
    $('#img_compartir').click(function() {
        $('#divEquipos').show();
    });

    LlenarComboEquipos();

    $('#MiCerrarEquipo').click(function() {
        $('#divEquipos').fadeOut('slow');
        return false;
    });

    $('select').on('change', function() {
        var idEquipo = this.value;
        $('#num_eq').attr('value', idEquipo);
        //alert(idEquipo);

        if (idEquipo > 0) {
            var vExiste = Existe_Recurso(idEquipo, Idp);
            //alert(vExiste);
            var arr = vExiste.split('|');
            if (arr[0] == 0) {
                VerComentarios(Idp, idEquipo);
                //despliega la ventana para crear el proposito del porque compartir este recurso(Inicia conversacion)
                $('#num_eq_rec').attr('value', arr[1]);
                $('#LblComentario').html("Ingrese el Proposito por el cual quiere compartir este recurso:")
                //ocultar boton para ver comentarios, porque no existen
                $('#MiPopUp').show();
                $('#Resena').focus();
            }
            else if (arr[0] == 1) {
                //despliega ventana para crear un comentario sobre una conversacion ya creada para el grupo
                $('#num_eq_rec').attr('value', arr[1]);
                //mostrar boton para ver comentarios
                VerComentarios(Idp, idEquipo);
                $('#LblComentario').html("Ingrese un Comentario:")
                $('#MiPopUp').show();
                $('#Resena').focus();
            }


        }
    });

    $('#MiCerrar').click(function() {
        $('#MiPopUp').fadeOut('slow');
        return false;
    });

    $('#btnCompartirInicial').click(function() {

        //alert('hola');
        //var Equipo_Id = $('input[type=radio][name=ListaEquipo]:checked').attr('id');
        var Equipo_Id = $('#num_eq').val();
        var Equipo_Recurso_Id = $('#num_eq_rec').val();
        var Texto = $('#Resena').val();
        var Tipo = "";
        if (Equipo_Recurso_Id == 0) {
            Tipo = "R";
        }
        else if (Equipo_Recurso_Id > 0) {
            Tipo = "C";
        }
        //alert(Equipo_Id + '-' + Equipo_Recurso_Id + '-' + Texto + '-' + Tipo);
        if (Equipo_Id > 0) {
            var resultado = GuardarComentario(Equipo_Id, Equipo_Recurso_Id, Texto, Tipo);
            //alert(resultado);
            if (resultado > 1 && Equipo_Recurso_Id == 0) {
                alert("Su Reseña se acaba de Guardar");
                $('#Resena').attr('value', '');
                $('#MiPopUp').fadeOut('slow');
                VerComentarios(Idp, Equipo_Id);
                $('#MiPopUp').show();
                
            }
            else if (resultado > 1 && Equipo_Recurso_Id > 0) {
                alert("Su Comentario se acaba de Guardar");
                $('#Resena').attr('value', '');
                $('#MiPopUp').fadeOut('slow');
                VerComentarios(Idp, Equipo_Id);
                $('#MiPopUp').show();
            }
        }
        else {
            alert("No ha seleccionado Equipo");
        }
    });



});



function ObtenerValorParametroUrl(parametro) {
    hu = window.location.search.substring(1);
    gy = hu.split("&");
    for (i = 0; i < gy.length; i++) {
        ft = gy[i].split("=");
        if (ft[0] == parametro) {
            return ft[1];
        }
    }
}

function LlenarComboEquipos() {
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "VerArticulo.aspx/ListarEquipos",
        async: false,
        success: function(result) {
            if (result.d[0] != null) {
                $.each(result.d, function(index) {
                    var option = $(document.createElement('option'));
                    option.text(this.NOMBRE_EQUIPO);
                    option.val(this.ID_EQUIPO);
                    $("#cboEquipos").append(option);
                });
            }
            else {
                $("#dvAlerta > span").text("Error al llenar el combo");
            }
        }
    });
}



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






function GuardarComentario(Equipo_ID, Equipo_Recurso_Id, Texto, Tipo) {
    var resultado;
    var dataToSend = "{'IdPagina': " + Idp + ", IdEquipo: " + Equipo_ID + ", Comentario: '" + Texto + "'" + ", Tipo: '" + Tipo + "'" + ", IdEquipoRecurso: '" + Equipo_Recurso_Id + "'}";
    //alert(dataToSend);
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






function TraeCantidadComentarios() {
    var resultado;
    var Tipo = 'R';
    var dataToSend = "{'IdPagina': " + Idp + "}";
    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "VerArticulo.aspx/ObtenerCantidadComentarios",
        async: false,
        data: dataToSend,
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}


function VerComentarios(Idp, IdEq) {
    var resultado;
    var Tipo = 'T';
    var MaxComentarios = 3;

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


