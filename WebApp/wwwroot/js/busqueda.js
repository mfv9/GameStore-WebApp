document.getElementById("buscador").addEventListener("keyup", function () {

    let texto = this.value;

    console.log(texto);

    fetch('/VideoJuego/BuscarJuegos?criterio=' + encodeURIComponent(texto))
        .then(response => response.text())
        .then(html => {
            console.log(html);
            document.getElementById("resultados").innerHTML = html;
        });
});