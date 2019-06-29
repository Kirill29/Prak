using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Geoportal.Controllers;
using Geoportal.Services;
using Geoportal.Models;


namespace Geoportal.Controllers
{
    public class RamkaController : Controller
    {
        private IConnectionString _connectionString;
        public RamkaController(IConnectionString connection)
        {
            _connectionString = connection;
        }
       
        [Authorize]
        public IActionResult Ramka(string button)
        {
            
            return View();
        }



        [Authorize]
        public IActionResult Add_WKT(string WKT_string, string cmr_name_value)

        {
            int Cmr_Id;
            string id_or_exception;
           // var connString = "Host=localhost;Database=i;Username=" + AccountController.current_user + "; Password=" + AccountController.current_user_password + ";";
            Create_shape creator = new Create_shape_WKT();
            Shape shape_wkt = creator.Create(cmr_name_value, WKT_string, _connectionString.GetConnectionString());
            id_or_exception = shape_wkt.Add_shape();
            if (!(int.TryParse(id_or_exception, out Cmr_Id)))
            {
                return Content(id_or_exception);
            }
            return RedirectToAction("Save_filescmr","File", new { cmr_Id = Cmr_Id, Switch_shape = "SHP" });
        }

        [Authorize]
        public IActionResult Add_SHP(string geometry, string cmr_name_value_shp)

        {
            int Cmr_Id;
            string id_or_exception;
            //var connString = "Host=localhost;Database=i;Username=" + AccountController.current_user + "; Password=" + AccountController.current_user_password + ";";
            Create_shape creator = new Create_shape_SHP();
            Shape shape_shp = creator.Create(cmr_name_value_shp, geometry, _connectionString.GetConnectionString());
            id_or_exception = shape_shp.Add_shape();
            if (!(int.TryParse(id_or_exception, out Cmr_Id)))
            {
                return Content(id_or_exception);
            }
            return RedirectToAction("Save_filescmr", "File", new { cmr_Id = Cmr_Id , Switch_shape ="WKT"});

        }


        [Authorize]
        public IActionResult Ramka_Added_WKT(int cmr_Id)
        {
           ViewData["Cmr_id"] = cmr_Id;
            return View();
        }
        [Authorize]
        public IActionResult Ramka_Added_SHP(int cmr_Id)
        {
            ViewData["Cmr_id"] = cmr_Id;
            return View();
        }














    }





}

