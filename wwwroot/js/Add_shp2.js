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
             //var  shp_Json=shpfile.toGeoJSON();
            myJSON = JSON.stringify(shp_bounds.toGeoJSON());
            postData=shpfile.toGeoJSON();

});

 var  shp_Json=shpfile.toGeoJSON();
var mygeo={ "type": "Polygon", 
    "coordinates": [
        [[35, 10], [45, 45], [15, 40], [10, 20], [35, 10]], 
        [[20, 30], [35, 35], [30, 20], [20, 30]]
    ]
};
var mygeo1=JSON.stringify(shp_Json);
console.log(shp_Json);



$.ajax({
         url: "/File/Add_shp/",
        type: "POST",
 //************************************
data: {
                         xml: mygeo1
                                  },
 //************************************
        
        success: function (result) {
            console.log(shp_Json);
        }
    });




           shpfile.addTo(mymap);


    





};
};




