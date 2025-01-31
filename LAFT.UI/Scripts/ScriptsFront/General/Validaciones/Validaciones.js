$(document).ready(function () {
    $("#basic-form").validate({
        rules: {
            IdentificacionPersona: {
                required: true,
                maxlength: 30

            },
            TipoIdentificacion: {
                required: true,
                number: true,
                max: 1
            },
            NombrePersona: {
                required: true,
                maxlength: 100
            },
            PrimerApellidoPersona: {
                required: true,
                maxlength: 100
            },
            SegundoApellidoPersona: {
                required: true,
                maxlength: 100
            },
            Telefono: {
                required: true,
                maxlength: 20
            },
            CorreoElectronico: {
                required: true,
                email: true

            },
            Direccion: {
                required: true,
                maxlength: 500
            },
            EstadoDeRiesgo: {
                required: true,
                maxlength: 1
            }
        }
    });
});