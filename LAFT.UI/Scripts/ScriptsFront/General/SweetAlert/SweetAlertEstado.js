function confirmarCambioEstado(idPersona, estadoActual) {
    let textoAccion = estadoActual ? "desactivar" : "activar";
    let textoConfirmacion = estadoActual ? "¿Está seguro de desactivar esta persona?" : "¿Está seguro de activar esta persona?";
    let textoConfirmar = estadoActual ? "Desactivar" : "Activar";
    let nuevoEstado = estadoActual ? false : true;

    // Mostrar la alerta de confirmación
    $("#llamarAMiEstado").on("click", function () {
        Swal.fire({
            title: textoConfirmacion,
            text: "¡Esta acción no se puede revertir!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: textoConfirmar
        }).then((result) => {
            if (result.isConfirmed) {
                // Si se confirma, cambiar el estado y enviar el formulario
                let formulario = document.getElementById("estadoForm_" + idPersona);
                // Actualizar el valor del estado antes de enviarlo
                formulario.querySelector('input[name="Estado"]').value = nuevoEstado;

                // Enviar el formulario
                formulario.submit();

                // Actualizar el texto del botón después de la acción
                let boton = document.querySelector('button[data-id="' + idPersona + '"]');
                boton.textContent = nuevoEstado ? "Desactivar" : "Activar";  // Cambiar texto del botón

                // Mostrar el mensaje de éxito
                Swal.fire(
                    textoConfirmar + " ¡Hecho!",
                    "El estado de la persona ha sido actualizado.",
                    "success"
                );
            }
        }
        );