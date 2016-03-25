$(document).ready(function() {

    $("#enviar-btn").click(function() {

        GuardarComentarios();
        return false;
    });
});


function GuardarComentarios() {
    //alert('2');
    var resultado;

    var Comentario = $('#comment').val();

    //alert('3');
    //var dataToSend = "{'IdPagina': " + Idp + "}";
    var dataToSend = "{'IdPagina': " + Idp + ", Comentario: '" + Comentario + "'}";

    //data: 'foo=' + bar + '&calibri=' + nolibri,

    alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "VerArticulo.aspx/GuardarComentario",
        async: false,
        //data: '{ IdPagina: \'' + Idp + '\', Comentario: \'' + Resena + '\'}',
        data: dataToSend,
        //data: { elemento1: valorSelect1, elemento2: valorSelect2 },
        success: function(result) {
            resultado = result.d;
            //alert(resultado);
        }
    });
    return resultado;
}