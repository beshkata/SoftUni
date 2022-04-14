// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function map(latitude, longitude) {
    const map = L.map('map', {
        center: [latitude, longitude],
        zoom: 15
    });

    const basemaps = {
        StreetView: L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { attribution: 'map data: &copy; <a href="https://openstreetmap.org/copyright">OpenStreetMap</a> contributors, <a href="http://viewfinderpanoramas.org">SRTM</a>' }),
        Topography: L.tileLayer.wms('https://{s}.tile.opentopomap.org/{z}/{x}/{y}.png', { attribution: 'map style: &copy; <a href="https://opentopomap.org">OpenTopoMap</a> (<a href="https://creativecommons.org/licenses/by-sa/3.0/">CC-BY-SA</a>)' }),
    };
    L.control.layers(basemaps).addTo(map);
    basemaps.StreetView.addTo(map);
    const marker1 = L.marker([latitude, longitude]).addTo(map);
}

function galeria() {
    Galleria.loadTheme('https://cdnjs.cloudflare.com/ajax/libs/galleria/1.6.1/themes/twelve/galleria.twelve.min.js');
    Galleria.run('.galleria');
}
