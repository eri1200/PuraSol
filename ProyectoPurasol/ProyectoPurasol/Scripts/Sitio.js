function Confirmar(avg) {
    event.preventDefault();
    alertify.confirm("Desea eliminar el registro?.",
        function (e) {
            if (e) {
                window.location = avg.href
                return true;
            } else {
                return false;
            }
        });
}
//$(function () {
//    $("#Provincia").change(function () {
//        var provincia = $(this).val();
//        var canton = $("#Canton");
//        var serviceURL = '/Cliente/CargaCantones';
//        $.ajax({
//            cache: false,
//            type: "GET",
//            url: serviceURL,
//            contentType: "application/json; charset=utf-8",
//            data: { "provincia": provincia },
//            dataType: "json",
//            success: function (data) {
//                canton.html('');
//                $.each(data, function (id, opcion) {
//                    canton.append($('<option></option>').val(opcion.id).html(opcion.descripcion));
//                });

//            },
//            error: function (xhr, ajaxOptions, thrownError) {
//                alert('Error al generar traer los cantones');

//            }
//        });

//        cargarDistritos();

//    });
//});

//$(function () {
//    $("#cantonss").change(function () {
//        var provincia = $("#Provincia").val();
//        var canton = $(this).val();
//        var distrito = $("#Distrito");
//        var serviceURL = '/Cliente/CargaDistritos';
//        $.ajax({
//            cache: false,
//            type: "GET",
//            url: serviceURL,
//            contentType: "application/json; charset=utf-8",
//            data: { "provincia": provincia, "canton": canton },
//            dataType: "json",
//            success: function (data) {
//                distrito.html('');
//                $.each(data, function (id, opcion) {
//                    distrito.append($('<option></option>').val(opcion.id).html(opcion.descripcion));
//                });

//            },
//            error: function (xhr, ajaxOptions, thrownError) {
//                alert('Error al generar traer los Distritos');

//            }
//        });
//    });
//});

//function cargarDistritos() {
//    var provincia = $("#Provincia").val();
//    var canton = 1;
//    var distrito = $("#Distrito");
//    var serviceURL = '/Cliente/CargaDistritos';
//    $.ajax({
//        cache: false,
//        type: "GET",
//        url: serviceURL,
//        contentType: "application/json; charset=utf-8",
//        data: { "provincia": provincia, "canton": canton },
//        dataType: "json",
//        success: function (data) {
//            distrito.html('');
//            $.each(data, function (id, opcion) {
//                distrito.append($('<option></option>').val(opcion.id).html(opcion.descripcion));
//            });

//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            alert('Error al generar traer los Distritos');

//        }
//    });

//}