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
using Serilog;
using Serilog.Events;
using Serilog.Core;
//using Microsoft.AspNetCore.Http.Internal;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geoportal.Controllers
{

    public class FileController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        // GET: /<controller>/
        private iContext _db;
        string path_to_log;
        Serilog.Core.Logger log;
        string file_name;

        static private List<string> files_names = new List<string>();

         static public List<string> Files_path { get; set; } = new List<string>();
        static string path_to_directory;
        static public List<long> files_size = new List<long>();
        static public List<long?> files_Files_DemandArchiveErsNr = new List<long?>();
        static long? demand_ArchiveErsNr;
        static public string Cmr_Id { get; set; }




        public IActionResult Ramka()
        {
            log.Information("Page adding shape");
            Log.CloseAndFlush();
            return View();
        }
      


    
    
        public  IActionResult Index()
        {

            ViewBag.FilesID = files_Files_DemandArchiveErsNr;
            ViewData["Path"] = path_to_directory;
            ViewData["ID"] = demand_ArchiveErsNr;
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }




        [RequestSizeLimit(1_000_000_000)]
        [HttpPost]
        public async Task<IActionResult> Add_files(IFormFileCollection File_col)
        {

            Files_path.Clear();
            files_names.Clear();
            files_size.Clear();
            files_Files_DemandArchiveErsNr.Clear();
            demand_ArchiveErsNr = 0;
            long file_size;
            string path_to_file;
            //LOAD FROM CONFIG.TXT
            DemandArchiveErs DAE=new DemandArchiveErs();

            string path_Root = _appEnvironment.WebRootPath;
           
            string name_data =DateTime.Now.ToString("_dd_MM_yyyy_(hh_mm_ss)");
            path_to_directory = Path.Combine(path_Root, name_data);

            if (!Directory.Exists(path_to_directory))
            {
                Directory.CreateDirectory(path_to_directory);

            }
            log.Information("Create Directory :"+ path_to_directory);
            string path_Config = Path.Combine(path_Root, "Config.txt");
            log.Information("Reading data from :" + path_Config);
            StreamReader objReader = new StreamReader(path_Config);
           
            string line;
            line = objReader.ReadLine();
            char ch = '=';
            int index = line.IndexOf(ch);
            if (Int32.TryParse(line.Substring(index + 1), out int j)){
                DAE.WorkstationsNr = j;
            }
            else
            {
                log.Error("Wrong data in Config.txt");
                return Content("Wrong sim");
            }

            line = objReader.ReadLine();
             ch = '=';
             index = line.IndexOf(ch);
            if (Int32.TryParse(line.Substring(index + 1), out int t))
            {
                DAE.RegionTypesNr = t;
            }
            else
            {
                log.Error("Wrong data in Config.txt");
                return Content("Wrong sim");
            }

            line = objReader.ReadLine();
            ch = '=';
            index = line.IndexOf(ch);
            if (Int32.TryParse(line.Substring(index + 1), out int m))
            {
                DAE.ConfirmDeleteAfterArchive = m;
            }
            else
            {
                log.Error("Wrong data in Config.txt");
                return Content("Wrong sim");
            }


            _db.DemandArchiveErss.Add(DAE);
            log.Information("Add data from file to DemandArchiveErs");

            await _db.SaveChangesAsync();



            if ((File_col == null) || (File_col.Count == 0))  {
                log.Error("Files are not selected");
            return Content("Files are not selected");
            }

            foreach (var file in File_col)

            {
                FilesDemandArchiveErs FDE = new FilesDemandArchiveErs();
                file_name = Path.GetFileName(file.FileName);
                files_names.Add(file_name);
                log.Information("Reading file: " + file_name);



                log.Information("Path directory :" + path_to_directory);
                path_to_file = Path.Combine(path_to_directory, file_name);
                log.Information($"   Rooted: {Path.IsPathRooted(file_name)}");
              

                Files_path.Add(path_to_file);
                
                FDE.PathFileName = path_to_file;
                
               
                FileStream fstream = null;
                try
                { 
                     fstream = new FileStream(path_to_file, FileMode.Create);
                     await file.CopyToAsync(fstream);
                     }
                     catch (IOException ioException)
                            {
                    log.Error("Fail to send file");
                       return Content( $"IO Error: {ioException.Message}");
                       }
                            finally
                            {
                                 if (fstream != null){fstream.Close();}
                    log.Information("File has been sent " + "Path :" + path_to_file);

                            }

                //нахожу размер файла загруженного
                file_size =new  System.IO.FileInfo(path_to_file).Length;
                files_size.Add(file_size);
                FDE.FileSizeInBytes = file_size;


                FDE.DemandArchiveErsNr = DAE.DemandArchiveErsNr;
                _db.FilesDemandArchiveErss.Add(FDE);
                await _db.SaveChangesAsync();

                demand_ArchiveErsNr = DAE.DemandArchiveErsNr;
                log.Information("Add data to FilesDemandArchiveErs  DemandArchiveErsNr: " + demand_ArchiveErsNr);
                files_Files_DemandArchiveErsNr.Add(FDE.FilesDemandArchiveErsNr);
                log.Information("Add data to FilesDemandArchiveErs  Files_DemandArchiveErsNr: " + FDE.FilesDemandArchiveErsNr);

            }





           
            return RedirectToAction("Index");


        }









        public async Task<IActionResult> Add(string WKT_string,string cmr_name_value)
        {
            string w = "POLYGON((-71.1776585052917 42.3902909739571, -71.1776820268866 42.3903701743239,-71.1776063012595 42.3903825660754, -71.1775826583081 42.3903033653531, -71.1776585052917 42.3902909739571))";
            WKT_string = w;
            if ((cmr_name_value == null))
            {
                return Content("Неверное название рамки");
            }

            Cmr_Id = "";
            try
            {


                var connString = "Host=localhost;Database=i;Username=postgres;Password=0-0-0-";

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();


                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        //cmd.CommandText = "INSERT INTO data.cmr(cmr_ident,cmr_name, geom) VALUES ('2', 'lol', ST_GeomFromText('LINESTRING(-71.160281 42.258729,-71.160837 42.259113,-71.161144 42.25932)'));";
                        // cmd.Parameters.AddWithValue("p", "{0}, {1}, ST_GeomFromText({2},4326)");
                        cmd.CommandText = "INSERT INTO data.cmr(cmr_ident,cmr_name, geom,date_make) VALUES ('2','" + cmr_name_value+"', ST_GeomFromText('" + WKT_string + "',4326),'now') RETURNING cmr_id;";
                        //cmd.ExecuteReader();
                        Cmr_Id = Convert.ToString(cmd.ExecuteScalar());

                    }
                    conn.Close();

                }
            }
            catch (Exception exception)

            {

                log.Error(exception.Message);
                return Content(exception.Message); }





            var i = 0;
            var j = 0;
            var h = 0;
           
            foreach (var path in Files_path)
            {
                FilesCmr filesCmr = new FilesCmr();
                filesCmr.CmrId = Convert.ToInt32(Cmr_Id);
                filesCmr.RootDir = path;
                filesCmr.FileName = files_names[i++];
                filesCmr.DemandArchiveErsNr = demand_ArchiveErsNr;
                filesCmr.FilesDemandArchiveNr = files_Files_DemandArchiveErsNr[j++];
                filesCmr.FileSize = files_size[h++].ToString();
               _db.FilesCmrs.Add(filesCmr);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Ramka_Added_WKT");

        }


        public IActionResult  Ramka_Added_WKT()
        {
            ViewData["Cmr_id"] = Cmr_Id;
            return View();
        }






        [HttpPost]
        public IActionResult Add_shp(string xml)
        {
            log.Information("shape "+ xml.ToString());
            return Content(xml.ToString());
        }



        public FileController(IHostingEnvironment appEnviroment, iContext context)
        {
             path_to_log = Path.Combine("logs", "log.txt");
             log = new LoggerConfiguration()
               .MinimumLevel.Debug()
           .WriteTo.Console()
           .WriteTo.File(path_to_log, rollingInterval: RollingInterval.Day)
           .CreateLogger();
            _appEnvironment = appEnviroment;
            _db = context;
        }



    }
   
}