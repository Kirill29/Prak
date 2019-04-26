    // Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



 var mymap = L.map('mapid').setView([55.75370903771494, 37.61981338262558], 12);

           
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
                

function loadFile() {
var myJSON;

var postData;
    input = document.getElementById('fileinput');
    if (!input.files[0]) {
         alert( "Please select a file before clicking 'Load'");
    }
    else {
        file = input.files[0];

        fr = new FileReader();
        fr.onload = receiveBinary;
        fr.readAsArrayBuffer(file);
    }
    function receiveBinary() {
        result = fr.result
        var shpfile = new L.Shapefile(result);
        shpfile.on("data:loaded", function (e){

            mymap.fitBounds(shpfile.getBounds());
            var shp_bounds=shpfile.getBounds();
       var  shp_Json=shpfile.toGeoJSON();
        myJSON = JSON.stringify(shp_Json);
            //console.log(shp_Json);
       console.log(shp_bounds.toGeoJSON());
});
        shpfile.addTo(mymap);


    





};






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



var xml = "example";
function Display_shp() {

$.ajax({
         url: "/File/Add_shp/",
        type: "POST",
 //************************************
data: {
                         xml: "j"
                                  },
 //************************************
        
        success: function (result) {
            console.log(xml);
        }
    });

};
