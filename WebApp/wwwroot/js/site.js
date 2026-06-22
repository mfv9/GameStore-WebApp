// MENSAJE CARRITO
window.onload = function () {

    const mensaje = document.getElementById("mensaje");

    if (mensaje) {

        setTimeout(function () {

            mensaje.style.opacity = "0";

            setTimeout(function () {
                mensaje.remove();
            }, 1300);

        }, 5000);

    }

};

//CHECKBOXS DELETE

function mostrarBoton() {
    const checks = document.querySelectorAll(".checkCliente");
    const boton = document.getElementById("btnBorrar");

    const haySeleccionados = [...checks].some(c => c.checked);

    if (haySeleccionados) {
        boton.hidden = false;
    } else {
        boton.hidden = true;
    }
}