    // Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



 //var mymap = L.map('mapid').setView([55.75370903771494, 37.61981338262558], 12);
var mymap = L.map('mapid').setView([46.505, -120.09], 4);
           
  //var watercolor=L.tileLayer('atlasName/{z}/{x}/{y}.png',
           //  {    maxZoom: 16  }).addTo(mymap);

var watercolor=L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
                maxZoom: 18,
                attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, ' +
                    '<a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
                    'Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
                id: 'mapbox.streets',
                accessToken: 'pk.eyJ1IjoiYmJyb29rMTU0IiwiYSI6ImNpcXN3dnJrdDAwMGNmd250bjhvZXpnbWsifQ.Nf9Zkfchos577IanoKMoYQ'
                }).addTo(mymap);

//var urlFilesrv_world = 'http://filesrv/geodbse/giswebservicese/service.php?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=world&STYLE=default&TILEMATRIXSET=GoogleMapsCompatible&TILEMATRIX={z}&TILEROW={x}&TILECOL={y}&FORMAT=image/png8';
//var settings = {
//    maxZoom: 17,
//    continuousWorld: true,
//    attribution: 'Sourced from LINZ. CC BY 4.0',
//    subdomains: 'abcd'
//};
//var basemaps = {
//    Filesrv_world: new L.TileLayer(urlFilesrv_world, settings)
//};

//L.control.layers(basemaps, {}, { position: 'topright', collapsed: true }).addTo(mymap);
//basemaps.Filesrv_world.addTo(mymap);
    


 








