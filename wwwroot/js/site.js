// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
 var mymap = L.map('mapid').setView([55.75370903771494, 37.61981338262558], 12);

            L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
                maxZoom: 18,
                attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, ' +
                    '<a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
                    'Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
                id: 'mapbox.streets',
                accessToken: 'pk.eyJ1IjoiYmJyb29rMTU0IiwiYSI6ImNpcXN3dnJrdDAwMGNmd250bjhvZXpnbWsifQ.Nf9Zkfchos577IanoKMoYQ'
                }).addTo(mymap);
function Display() {



var  wkt_geom  = document.getElementById("Wkt_string").value;
if (wkt_geom==''){
alert("Введите значение");
}
var wicket = new Wkt.Wkt();
wicket.read(wkt_geom);
var geo_json_data=wicket.toJson();

var geo_json_layer=L.geoJSON(geo_json_data).addTo(mymap);
mymap.fitBounds(geo_json_layer.getBounds());







  };



