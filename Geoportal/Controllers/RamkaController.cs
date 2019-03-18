using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geoportal.Controllers
{
    public class RamkaController : Controller
    {
        // GET: /<controller>/
        public IActionResult Ramka()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(string WKT_string)
        {
                //string w = "POLYGON((-71.1776585052917 42.3902909739571, -71.1776820268866 42.3903701743239,-71.1776063012595 42.3903825660754, -71.1775826583081 42.3903033653531, -71.1776585052917 42.3902909739571))";
           

           var connString = "Host=localhost;Database=i;Username=testuser;Password=0-0-0-";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Insert some data
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    //cmd.CommandText = "INSERT INTO data.cmr(cmr_ident,cmr_name, geom) VALUES ('2', 'lol', ST_GeomFromText('LINESTRING(-71.160281 42.258729,-71.160837 42.259113,-71.161144 42.25932)'));";
                    // cmd.Parameters.AddWithValue("p", "{0}, {1}, ST_GeomFromText({2},4326)");
                    cmd.CommandText = "INSERT INTO data.cmr(cmr_ident,cmr_name, geom) VALUES ('2', 'now', ST_GeomFromText('"+ WKT_string + "',4326));";
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Ramka"); 

            }
        }
    }
}
