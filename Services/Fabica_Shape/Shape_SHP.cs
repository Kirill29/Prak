using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services
{//класс для сохранения SHP рамки
    public class Shape_SHP:Shape
    {

        private string name;
        private string geometry;
        private string dbconn;
        private string wkt_from_geojson;

        public Shape_SHP(string name, string geom,string dbconn)
       
        {
            this.name = name;
            this.geometry = geom;
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
                       cmd.CommandText = "SELECT ST_AsText(ST_GeomFromGeoJSON(@geometry)) As wkt;";

                        cmd.Parameters.AddWithValue("geometry",geometry);
                        wkt_from_geojson = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = "INSERT INTO data.cmr(cmr_ident,cmr_name, geom,date_make) VALUES ('2',@name, ST_GeomFromText(@wkt_from_geojson,4326),'now') RETURNING cmr_id;";
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@wkt_from_geojson", wkt_from_geojson);
                        Cmr_Id = Convert.ToString(cmd.ExecuteScalar());

                    }
                    conn.Close();

                }
            }
            catch (Exception exception)

            {

               
                return (exception.Message);
            }
            return  Cmr_Id;
        }
    }
}
