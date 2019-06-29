using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services
{
    public class Shape_SHP:Shape
    {

        private string name;
        private string geometry;
        private string dbconn;
        private string wkt_from_geojson;

        public Shape_SHP(string name, string geom,string dbconn)
        : base(name,geom,dbconn)
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
                        cmd.CommandText = "SELECT ST_AsText(ST_GeomFromGeoJSON('" + geometry+ "')) As wkt;";
                        wkt_from_geojson = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = "INSERT INTO data.cmr(cmr_ident,cmr_name, geom,date_make) VALUES ('2','" + name + "', ST_GeomFromText('" + wkt_from_geojson + "',4326),'now') RETURNING cmr_id;";
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
