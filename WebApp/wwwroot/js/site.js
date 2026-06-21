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