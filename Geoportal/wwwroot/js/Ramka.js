var wkt_geom = "POLYGON((-71.1776585052917 42.3902909739571, -71.1776820268866 42.3903701743239,-71.1776063012595 42.3903825660754, -71.1775826583081 42.3903033653531, -71.1776585052917 42.3902909739571))";
var geojson_options = {};
var wkt_format = new OpenLayers.Format.WKT();
var testFeature = wkt_format.read(wkt_geom);
var wkt_options = {};
var geojson_format = new OpenLayers.Format.GeoJSON(wkt_options);
var out = geojson_format.write(testFeature);

alert(out);
