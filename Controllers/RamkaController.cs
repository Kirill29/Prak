using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Geoportal.Services;
using Geoportal.Services.Logging;
using Geoportal.Services.Fabica_Shape;

namespace Geoportal.Controllers
{
	//контроллер для сохранения геопространственной привязки
	public class RamkaController : Controller
	{
		private readonly IConnectionString _connectionString;

		private readonly ILogger_custom _logger;

		public RamkaController(IConnectionString connection, ILogger_custom logger)
		{
			_connectionString = connection;
			_logger = logger;
		}

		//вью для добавления WKT или SHP рамки
		[Authorize]
		public IActionResult Ramka()
		{
			return View();
		}

		//вью для добавления нариованной рамки
		[Authorize]
		public IActionResult Ramka_Draw()
		{
			return View();
		}

		[Authorize]
		public IActionResult Add_Draw(string geometry_multiPolgon, string cmr_name_value_draw,
			string geometry_multiLineString, string geometry_multiPoint)
		{
			int Cmr_Id;
			//переменная для записи ID добавленной записи или записи ошибки
			string id_or_exception;
			Create_shape creator = new Create_shape_draw();
			var conn = "Host = localhost; Database = i; Username = user3; Password = 0-0-0-";
			// Shape shape_draw = creator.Create(cmr_name_value_draw, geometry, _connectionString.GetConnectionString());
			Shape shape_draw = creator.Create(cmr_name_value_draw, geometry_multiPolgon, geometry_multiLineString,
				geometry_multiPoint, conn);
			id_or_exception = shape_draw.Add_shape();
			//проверяем,если целое число -ID,все хорошо.Если не число-ошибка;
			if (!(int.TryParse(id_or_exception, out Cmr_Id)))
			{
				_logger.LogError($"Error while adding drawded shape {id_or_exception}");
				return Content(id_or_exception);
			}

			_logger.LogInfo($"Drawded Shape Added ID: {Cmr_Id} , Name: {cmr_name_value_draw} ");
			return RedirectToAction("Save_filescmr", "File", new {cmr_Id = Cmr_Id, Switch_shape = "Draw"});
		}

		[Authorize]
		public IActionResult Add_WKT(string WKT_string, string cmr_name_value)

		{
			int Cmr_Id;
			//переменная для записи ID добавленной записи или записи ошибки
			string id_or_exception;

			Create_shape creator = new Create_shape_WKT();
			Shape shape_wkt = creator.Create(cmr_name_value, WKT_string, _connectionString.GetConnectionString());
			id_or_exception = shape_wkt.Add_shape();
			//проверяем,если целое число -ID,все хорошо.Если не число-ошибка;
			if (!(int.TryParse(id_or_exception, out Cmr_Id)))
			{
				_logger.LogError($"Error while adding Wkt_shape {id_or_exception}");
				return Content(id_or_exception);
			}

			_logger.LogInfo($"WKT Shape Added ID: {Cmr_Id} , Name: {cmr_name_value} ");
			return RedirectToAction("Save_filescmr", "File", new {cmr_Id = Cmr_Id, Switch_shape = "WKT"});
		}

		[Authorize]
		public IActionResult Add_SHP(string geometry, string cmr_name_value_shp)

		{
			int Cmr_Id;
			string id_or_exception;
			Create_shape creator = new Create_shape_SHP();
			Shape shape_shp = creator.Create(cmr_name_value_shp, geometry, _connectionString.GetConnectionString());
			id_or_exception = shape_shp.Add_shape();
			if (!(int.TryParse(id_or_exception, out Cmr_Id)))
			{
				_logger.LogError($"Error while adding SHP_shape {id_or_exception}");
				return Content(id_or_exception);
			}

			_logger.LogInfo($"SHP Shape Added ID: {Cmr_Id} , Name: {cmr_name_value_shp} ");
			return RedirectToAction("Save_filescmr", "File", new {cmr_Id = Cmr_Id, Switch_shape = "SHP"});
		}


		[Authorize]
		public IActionResult Ramka_Added_WKT(int cmr_Id)
		{
			ViewData["Cmr_id"] = cmr_Id;
			return View();
		}

		[Authorize]
		public IActionResult Ramka_Added_Draw(int cmr_Id)
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