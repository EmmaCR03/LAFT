$(document).ready(function () {
    $("#abrirModal").click(function () {
        // Hacemos la solicitud AJAX
        $.ajax({
            url: '/ActividadesPersona/ObtenerListaDeActividadesFinancieras',  // Ruta de la acción del controlador
            data: { IdActividadFinanciera: 1 },
            type: 'GET',
            success: function (response) {
                // Inyecta el contenido al modal
                $('#myModal .modal-body').html(response);

                // Abre el modal
                $('#myModal').modal("show");
            },
            error: function (xhr, status, error) {
                alert("Hubo un error al cargar el modal.");
            }
        });
    });

});
