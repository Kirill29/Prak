using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Geoportal.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.AspNetCore.Authentication;

using Serilog;
using Serilog.Events;
using Serilog.Core;
using Microsoft.AspNetCore.Authorization;
using Geoportal.Controllers;
using Geoportal.Services;
using System.Security.Claims;
//using Microsoft.AspNetCore.Http.Internal;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geoportal.Controllers
{
    //file transfer controller
    public class FileController : Controller
    {
        private readonly ISave_Files _save_files;
        private readonly IHostingEnvironment _appEnvironment;
        private IConnectionString _connectionString;
        
        //database context
        private iContext _db;
        //path to logs_files
        string path_to_log;
        Serilog.Core.Logger log;
        string file_name;

        static private List<string> files_names = new List<string>();
        static public List<string> Files_path { get; set; } = new List<string>();
        static string path_to_directory;
        static public List<long> files_size = new List<long>();
        static public List<long?> files_Files_DemandArchiveErsNr = new List<long?>();
        static long? demand_ArchiveErsNr;
       static  List<FilesCmr> filesCmrs = new List<FilesCmr>();
        static public string Cmr_Id { get; set; }
        static public string cmr_name_value1 { get; set; }

        static string login;
        static string password;
        [Authorize]
        public IActionResult Index(string button)
        {
           
            //ViewBag.FilesID = files_Files_DemandArchiveErsNr;
            //ViewData["Path"] = path_to_directory;
            //ViewData["ID"] = demand_ArchiveErsNr;
            if (!string.IsNullOrEmpty(button))
            {
                
                return Content ("it is alive");
            }
            return View(filesCmrs);
        }


        [Authorize]
        public IActionResult Send()
        {
           
          
            var userEmail = User.FindFirst(ClaimTypes.Name).Value;
          

           
            return View();
        }

     
        [HttpPost]
        public async Task<IActionResult> Add_files(IFormFileCollection File_col)
        {
            filesCmrs.Clear();
            filesCmrs = await _save_files.Save_files(File_col, User.FindFirst(ClaimTypes.Name).Value);
          
            return RedirectToAction("Index");

        }
        
            
    
          
        public async Task<IActionResult> Save_filescmr(int Cmr_id,string Switch_shape)
    {
           
            foreach (var file_cmr in filesCmrs)  {
                file_cmr.FilesCmrId = Cmr_id;
               _db.FilesCmrs.Add(file_cmr);
                await _db.SaveChangesAsync();
            }
            switch (Switch_shape)
            {
                case "WKT":
                    return RedirectToAction("Ramka_Added_WKT","Ramka",new { cmr_Id = Cmr_id});
                  
                case "SHP":
                    return RedirectToAction("Ramka_Added_SHP", "Ramka", new { cmr_Id = Cmr_id });
                   
                default:
                    return Content("Error");
            }

        }

       

        public FileController(IHostingEnvironment appEnviroment, iContext context,ISave_Files save_Files,IConnectionString connectionString)
        {
             path_to_log = Path.Combine("logs", "log.txt");
             log = new LoggerConfiguration()
               .MinimumLevel.Debug()
           .WriteTo.Console()
           .WriteTo.File(path_to_log, rollingInterval: RollingInterval.Day)
           .CreateLogger();
            _appEnvironment = appEnviroment;
            _db = context;
            _save_files = save_Files;
            _connectionString = connectionString;
        }



    }
   
}