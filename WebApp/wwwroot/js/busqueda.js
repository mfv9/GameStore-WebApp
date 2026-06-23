document.addEventListener("DOMContentLoaded", function () {

    const buscador = document.getElementById("buscador");

    buscador.addEventListener("keyup", function () {

        let texto = this.value;

        // 👇 SI ESTÁ VACÍO → volver a listar todo
        if (texto.trim() === "") {

            fetch('/VideoJuego/ListaCompleta') // o Index parcial
                .then(r => r.text())
                .then(html => {
                    document.getElementById("resultados").innerHTML = html;
                });

            return;
        }

        // 👇 búsqueda normal
        fetch(urlBuscar + '?criterio=' + encodeURIComponent(texto))
            .then(r => r.text())
            .then(html => {
                document.getElementById("resultados").innerHTML = html;
            });

    });

});