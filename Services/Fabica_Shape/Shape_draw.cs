using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services.Fabica_Shape
{
	public class Shape_draw : Shape
	{
		private string name;

		private string geometry;

		private string geometry_multiPolgon;

		private string geometry_multiLineString;

		private string geometry_multiPoint;

		private string dbconn;

		private string wkt_from_geojson;

		private string wkt_geometry_multiPolygon;

		private string wkt_geometry_multiLineString;

		private string wkt_geometry_multiPoint;

		private string wkt_geometry;

		private string wkt_geometry1;

		public Shape_draw(string name, string geometry_multiPolgon, string geometry_multiLineString,
			string geometry_multiPoint, string dbconn)

		{
			this.name = name;
			this.geometry_multiPolgon = geometry_multiPolgon;
			this.geometry_multiLineString = geometry_multiLineString;
			this.geometry_multiPoint = geometry_multiPoint;
			this.dbconn = dbconn;
		}

		public override string Add_shape()
		{
			string Cmr_Id;
			try
			{
				using (var conn = new NpgsqlConnection(dbconn))
				{
					conn.Open();
					using (var cmd = new NpgsqlCommand())
					{
						cmd.Connection = conn;
						if (!String.Equals(geometry_multiPolgon, "null"))
						{
							cmd.CommandText = "SELECT ST_AsText(ST_GeomFromGeoJSON(@geometry_multiPolgon)) As wkt;";
							cmd.Parameters.AddWithValue("geometry_multiPolgon", geometry_multiPolgon);
							wkt_geometry_multiPolygon = cmd.ExecuteScalar().ToString();
						}
						else
						{
							wkt_geometry_multiPolygon = "POLYGON EMPTY";
						}

						if (!String.Equals(geometry_multiLineString, "null"))
						{
							cmd.CommandText = "SELECT ST_AsText(ST_GeomFromGeoJSON(@geometry_multiLineString)) As wkt;";
							cmd.Parameters.AddWithValue("geometry_multiLineString", geometry_multiLineString);
							wkt_geometry_multiLineString = cmd.ExecuteScalar().ToString();
						}
						else
						{
							wkt_geometry_multiLineString = "LINESTRING EMPTY";
						}

						if (!String.Equals(geometry_multiPoint, "null"))
						{
							cmd.CommandText = "SELECT ST_AsText(ST_GeomFromGeoJSON(@geometry_multiPoint)) As wkt;";
							cmd.Parameters.AddWithValue("geometry_multiPoint", geometry_multiPoint);
							wkt_geometry_multiPoint = cmd.ExecuteScalar().ToString();
						}
						else
						{
							wkt_geometry_multiPoint = "POINT EMPTY";
						}

						cmd.CommandText =
							"SELECT ST_AsText(ST_Union(ST_GeomFromText(@wkt_geometry_multiPolygon), ST_GeomFromText(@wkt_geometry_multiLineString) ) )";

						cmd.Parameters.AddWithValue("wkt_geometry_multiPolygon", wkt_geometry_multiPolygon);
						cmd.Parameters.AddWithValue("wkt_geometry_multiLineString", wkt_geometry_multiLineString);
						wkt_geometry = cmd.ExecuteScalar().ToString();
						cmd.CommandText =
							"SELECT ST_AsText(ST_Union(ST_GeomFromText(@wkt_geometry_multiPoint), ST_GeomFromText(@wkt_geometry) ) )";
						cmd.Parameters.AddWithValue("wkt_geometry_multiPoint", wkt_geometry_multiPoint);
						cmd.Parameters.AddWithValue("wkt_geometry", wkt_geometry);
						wkt_geometry1 = cmd.ExecuteScalar().ToString();
						cmd.CommandText =
							"INSERT INTO data.cmr(cmr_ident,cmr_name, geom,date_make) VALUES ('2',@name, ST_GeomFromText(@wkt_geometry,4326),'now') RETURNING cmr_id;";
						cmd.Parameters.AddWithValue("@name", name);
						cmd.Parameters.AddWithValue("@wkt_geometry", wkt_geometry1);
						Cmr_Id = Convert.ToString(cmd.ExecuteScalar());
					}

					conn.Close();
				}
			}
			catch (Exception exception)
			{
				return (exception.Message);
			}

			return Cmr_Id;
		}
	}
}