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

            //mymap.fitBounds(shpfile.getBounds());

            var shp_bounds=shpfile.getBounds();
             //var  shp_Json=shpfile.toGeoJSON();
            myJSON = shpfile.toGeoJSON();
            postData=shpfile.toGeoJSON();
console.log(shpfile.toGeoJSON());
          console.log(  JSON.stringify(postData));
var sum = turf.polygon([[
[],
[],
[],
[]

]], {});


//console.log(JSON.stringify(try1));
//console.log(JSON.stringify(try2));
var try1;
var try2;
var combine;
var union;


for (var i =0  ; i<shpfile.toGeoJSON().features.length ; i++) {

  try1= shpfile.toGeoJSON().features[i].geometry.type;
  try2=shpfile.toGeoJSON().features[i].geometry.coordinates;
  combine=turf.polygon(try2,{});
console.log(sum);
  sum = turf.union(sum,combine);

}
var uniont=L.geoJSON(sum).addTo(mymap);
var uniont=L.geoJSON(sum).addTo(mymap);
var uniont=L.geoJSON(sum).addTo(mymap);
var uniont=L.geoJSON(sum).addTo(mymap);
var uniont=L.geoJSON(sum).addTo(mymap);
var uniont=L.geoJSON(sum).addTo(mymap);
var uniont=L.geoJSON(sum).addTo(mymap);
var uniont=L.geoJSON(sum).addTo(mymap);
var uniont=L.geoJSON(sum).addTo(mymap);
//console.log(union);
mymap.fitBounds(uniont.getBounds());
console.log(uniont.getBounds());
console.log(JSON.stringify(uniont.getBounds()));

var try5=sum.geometry.coordinates;
var try6=sum.geometry.type;
var tosend=turf.polygon(try5,{});       
console.log(tosend.getBounds());
console.log(tosend);
$.ajax({
         url: "/File/Add_shp/",
        type: "POST",
 //************************************
data: {
              xml: JSON.stringify(tosend)
                                  },
 //************************************
        
        success: function (result) {
            console.log(JSON.stringify(tosend));
        }
    });







    });

 




           shpfile.addTo(mymap);



    





};
};

var poly1 = turf.polygon([[
    [-82.574787, 35.594087],
    [-82.574787, 35.615581],
    [-82.545261, 35.615581],
    [-82.545261, 35.594087],
    [-82.574787, 35.594087]
]], {"fill": "#0f0"});
var poly2 = turf.polygon([[
    [-82.560024, 35.585153],
    [-82.560024, 35.602602],
    [-82.52964, 35.602602],
    [-82.52964, 35.585153],
    [-82.560024, 35.585153]
]], {"fill": "#00f"});

var union1={ "type": "FeatureCollection",
    "features": [
      { "type": "Feature",
        "geometry": {"type": "Polygon", "coordinates": [[
    [-82.574787, 35.594087],
    [-82.574787, 35.615581],
    [-82.545261, 35.615581],
    [-82.545261, 35.594087],
    [-82.574787, 35.594087]
     ]]},

       },
      { "type": "Feature",
        "geometry": {
          "type": "Polygon",
          "coordinates": [[
    [-82.560024, 35.585153],
    [-82.560024, 35.602602],
    [-82.52964, 35.602602],
    [-82.52964, 35.585153],
    [-82.560024, 35.585153]
]]



          },
        
        }
]
     };

var sum = turf.polygon([[
[],
[],
[],
[]

]], {});


//console.log(JSON.stringify(try1));
//console.log(JSON.stringify(try2));
var try1;
var try2;
var combine;
var union;
for (var i =0  ; i<union1.features.length-1; i++) {

  try1= union1.features[i].geometry.type;
  try2=union1.features[i].geometry.coordinates;
console.log(try2);
  combine=turf.polygon(try2,{});
  union = turf.union(sum,combine);

}


//console.log(union1.features[0].geometry);

//var union = turf.union(poly1, poly2);
//L.geoJSON(poly1).addTo(mymap);
//L.geoJSON(poly2).addTo(mymap);
//var uniont=L.geoJSON(union).addTo(mymap);
console.log(union);
      // mymap.fitBounds(uniont.getBounds());



