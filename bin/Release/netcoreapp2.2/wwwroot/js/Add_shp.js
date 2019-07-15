function loadFile() {
    input = document.getElementById('fileinput');
    if (!input.files[0]) {
         alert( "Пожалуйста,выберете файл!");
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
            var sum = turf.polygon([[
[],
[],
[],
[]
]], {});
            
        
var try1;
var try2;
var combine;
            

for (var i =0  ; i<shpfile.toGeoJSON().features.length-1 ; i++) {

    try1 = shpfile.toGeoJSON().features[i].geometry.type;

  try2=shpfile.toGeoJSON().features[i].geometry.coordinates;

  combine=turf.polygon(try2,{});
  sum = turf.union(sum,combine);

            }
            var tosend;
           
         
            if (sum.geometry.type == "Polygon") {
                var options = { tolerance: 0.1, highQuality: false };
            var simplified = turf.simplify(sum, options);

                tosend = JSON.stringify(simplified.geometry);
           var m= L.geoJSON(simplified).addTo(mymap);
            mymap.fitBounds(m.getBounds());
               
            } else {
                tosend = JSON.stringify(sum.geometry);
                 var t=  L.geoJSON(sum).addTo(mymap);
                mymap.fitBounds(t.getBounds());
            }
            if (tosend == "") {
                alert("Строка на сервер пустая!")
            }

            document.getElementById('geo').value = tosend;
            $(document).ready(function () {
                //function will be called on button click having id btnsave
                $("#btnSave").click(function () {  
            $.ajax({
                url: "/File/Add_shp/",
                type: "POST",
                //************************************
                data: {
                    xml: tosend
                },
                //************************************

                success: function (result) {
                    console.log(tosend);
                }
            });
                });
            });  



    });



    };
   
};






