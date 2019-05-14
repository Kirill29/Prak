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
            console.log(shpfile.toGeoJSON());
            var shp_bounds=shpfile.getBounds();
             //var  shp_Json=shpfile.toGeoJSON();
            myJSON = shpfile.toGeoJSON();
            postData=shpfile.toGeoJSON();
          //console.log(shpfile.toGeoJSON());
          //console.log(  JSON.stringify(postData));
var sum = turf.polygon([[
[],
[],
[],
[]
]], {});
            
            

            //если каждый полигон по отдельности рубить
            //var summ;

            //for (var j = 0; j< shpfile.toGeoJSON().features.length-1; j++) {

            //    var union;
            //   // var proba = L.geoJSON(shpfile.toGeoJSON().features[j].geometry).addTo(mymap);
            //    console.log(shpfile.toGeoJSON().features[j].geometry);
            //    var polygon_array = shpfile.toGeoJSON().features[j].geometry.coordinates[0];
            //    var points = [];
            //    var points1 = [];
            //    var max_el = -1;
            //    var max_el1 = -1;
            //    console.log(max_el);
            //    console.log(max_el1);
            //    var size = 100; //размер подмассива
            //    var subarray = []; //массив в который будет выведен результат.
            //    for (var i = 0; i < Math.ceil(polygon_array.length / size); i++) {
            //        max_el = -1;
            //        max_el1 = -1;
            //        subarray[i] = polygon_array.slice((i * size), (i * size) + size);
            //        for (var j = 0; j < subarray[i].length - 1; j = j + 1) {
            //            if ((subarray[i][j][0] > max_el) || (subarray[i][j][1] > max_el1)) {

            //                max_el = subarray[i][j][0];
            //                max_el1 = subarray[i][j][1];

            //            }

            //        }
            //        points.push(max_el);
            //        points1.push(max_el1);
            //        console.log(subarray[i][0][0]);
            //    }
            //    console.log(subarray);

            //    console.log(points);
            //    console.log(points1);
            //    var arr1 = new Array(1);
            //    arr1[0] = new Array(points.length);//Создание массива на 3 элемента
            //    for (var i = 0; i < points.length - 1; i++) {
            //        arr1[0][i] = new Array(2); //вставл. в первый элемент массив на 2 элемента
            //        arr1[0][i][0] = points[i];
            //        arr1[0][i][1] = points1[i];
            //    }

            //    var st = " ";
            //    for (var i = 0; i < points.length - 1; i++) {
            //        st = st + points[i] + " " + points1[i] + ",";
            //    }
               


            //    summ = summ + st;
               
            //}
            //var wkt_string = "Polygon(" + summ + "),4326)";
            //var wicket = new Wkt.Wkt();
            //wicket.read(wkt_string);
            //var geo_json_data = wicket.toJson();

            //var geo_json_layer = L.geoJSON(geo_json_data).addTo(mymap);
            //mymap.fitBounds(geo_json_layer.getBounds());



//console.log(JSON.stringify(try1));
//console.log(JSON.stringify(try2));
var try1;
var try2;
var combine;
            var union;
            //var proba = L.geoJSON(shpfile.toGeoJSON().features[0].geometry).addTo(mymap);
            //console.log(shpfile.toGeoJSON().features[0].geometry);
            //var polygon_array = shpfile.toGeoJSON().features[0].geometry.coordinates[0];
           

            //var size = parseInt(polygon_array.length / 100);

            //console.log(size);
            //var points = [];
            //var points1 = [];
            //var max_el = -1;
            //var max_el1 = -1;
            //console.log(max_el);
            //console.log(max_el1);
            //var size = 100; //размер подмассива
            //var subarray = []; //массив в который будет выведен результат.
            //for (var i = 0; i < Math.ceil(polygon_array.length / size); i++) {
            //    max_el = -1;
            //    max_el1= -1;
            //    subarray[i] = polygon_array.slice((i * size), (i * size) + size);
            //    for (var j = 0; j < subarray[i].length-1; j = j + 1) {
            //        if ((subarray[i][j][0] > max_el) || (subarray[i][j][1] > max_el1)) {

            //            max_el = subarray[i][j][0];
            //            max_el1 = subarray[i][j][1];

            //        }

            //    }
            //    points.push(max_el);
            //    points1.push(max_el1);
            //    console.log(subarray[i][0][0]);
            //}
            //console.log(subarray);
            
            //      console.log(points);
            //console.log(points1);
            //var arr1 = new Array(1);
            //arr1[0] = new Array(points.length);//Создание массива на 3 элемента
            //for (var i = 0; i < points.length-1 ; i++) {
            //    arr1[0][i] = new Array(2); //вставл. в первый элемент массив на 2 элемента
            //    arr1[0][i][0] = points[i];
            //    arr1[0][i][1] = points1[i];
            //}
            
            //var st = " ";
            //for (var i = 0; i < points.length - 1; i++) {
            //    st = st + points[i] + " " + points1[i] + ",";
            //}
            //var wkt_string = "Polygon(" + st + "),4326)";
            //var wicket = new Wkt.Wkt();
            //wicket.read(wkt_string);
            //var geo_json_data = wicket.toJson();

            //var geo_json_layer = L.geoJSON(geo_json_data).addTo(mymap);
            //mymap.fitBounds(geo_json_layer.getBounds());

           













           






                


       














for (var i =0  ; i<shpfile.toGeoJSON().features.length-1 ; i++) {

    try1 = shpfile.toGeoJSON().features[i].geometry.type;

  try2=shpfile.toGeoJSON().features[i].geometry.coordinates;

  combine=turf.polygon(try2,{});
  sum = turf.union(sum,combine);

            }

           // var proba = L.geoJSON(sum).addTo(mymap);
            // mymap.fitBounds(proba);
            sum.geometry.addTo(mymap);
            mymap.fitBounds(sum.getBounds());
            console.log(sum.geometry);
            var t = new Array(1);
            //var polygon_array = sum.geometry.coordinates[0];
            //var polygon_array = new Array(1);
            var polygon_array = sum.geometry.coordinates;
            console.log(polygon_array);

            var size = parseInt(polygon_array.length / 100);

            console.log(size);
            var points = [];
            var points1 = [];
            var max_el = -1;
            var max_el1 = -1;
            console.log(max_el);
            console.log(max_el1);
            var size = 100; //размер подмассива
            var subarray = []; //массив в который будет выведен результат.
            for (var i = 0; i < Math.ceil(polygon_array.length / size); i++) {
                max_el = -1;
                max_el1= -1;
                subarray[i] = polygon_array.slice((i * size), (i * size) + size);
                for (var j = 0; j < subarray[i].length-1; j = j + 1) {
                    if ((subarray[i][j][0] > max_el) || (subarray[i][j][1] > max_el1)) {

                        max_el = subarray[i][j][0];
                        max_el1 = subarray[i][j][1];

                    }

                }
                points.push(max_el);
                points1.push(max_el1);
                console.log(subarray[i][0][0]);
            }
            console.log(subarray);

                  console.log(points);
            console.log(points1);
            var arr1 = new Array(1);
            arr1[0] = new Array(points.length);//Создание массива на 3 элемента
            for (var i = 0; i < points.length-1 ; i++) {
                arr1[0][i] = new Array(2); //вставл. в первый элемент массив на 2 элемента
                arr1[0][i][0] = points[i];
                arr1[0][i][1] = points1[i];
            }

            var st = "";
            for (var i = 0; i < points.length - 2; i++) {
                st = st + points[i] + " " + points1[i] + ",";
            }
            st = st + points[points.length - 1] + " " + points1[points.length - 1]+","+points[0]+" "+points1[0];
            var wkt_string2 = "Polygon("+ st + "),4326)";
            var wkt_string1 = "POLYGON((" + st +"))";
            var wicket = new Wkt.Wkt();
            wicket.read(wkt_string2);
            var geo_json_data = wicket.toJson();

           // var geo_json_layer = L.geoJSON(geo_json_data).addTo(mymap);
            mymap.fitBounds(geo_json_layer.getBounds());





            console.log("vot sum");
            console.log(sum);
           



//var try5=sum.geometry.coordinates;
//var try6=sum.geometry.type;
//var tosend=turf.polygon(try5,{});       
//console.log(tosend.getBounds());
//console.log(tosend);
$.ajax({
         url: "/File/Add_shp/",
        type: "POST",
 //************************************
data: {
        xml: wkt_string1
                                  },
 //************************************
        
        success: function (result) {
            console.log(wkt_string1);
        }
    });







    });

 



        
        //shpfile.addTo(mymap);
        



    





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
  // console.log(try2);
  combine=turf.polygon(try2,{});
  union = turf.union(sum,combine);

}


//console.log(union1.features[0].geometry);

//var union = turf.union(poly1, poly2);
//L.geoJSON(poly1).addTo(mymap);
//L.geoJSON(poly2).addTo(mymap);
//var uniont=L.geoJSON(union).addTo(mymap);
//console.log("Summ:");
//console.log(union);
      // mymap.fitBounds(uniont.getBounds());



