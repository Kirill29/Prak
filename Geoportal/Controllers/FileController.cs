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
//using Microsoft.AspNetCore.Http.Internal;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geoportal.Controllers
{

    public class FileController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        // GET: /<controller>/
        private iContext _db;
        static private List<string> files_names = new List<string>();

         static public List<string> Files_path { get; set; } = new List<string>();

        static List<string> files_size = new List<string>();
        public string Cmr_Id { get; set; }

        public JsonResult UploadFile(IList<IFormFile> files)
        {
            return Json(new { state = 0, message = string.Empty });
        }

        public IActionResult Ramka()
        {
            return View();
        }
      


    
    [HttpGet]
        public async Task<IActionResult> Index()
        {

            var d = _db.DemandArchiveErss.ToList();
            var m = d[d.Count - 1];
            ViewData["ID"] = m.DemandArchiveErsNr;
            _db.SaveChanges();

            return View(await _db.DemandArchiveErss.ToListAsync());
        }

        public IActionResult Create()
        {

            return View();
        }


        //EDIT
        public async Task<IActionResult> Edit(long id)

        {

            var item = await _db.DemandArchiveErss.FindAsync(id);
            if (item == null)
            {
                return Content("Null");
            }

            return View(item);
        }



      //DELETE 
        public async Task<IActionResult> OnPostDeleteAsync(long id)
        {
            var item = await _db.DemandArchiveErss.FindAsync(id);
            if (item != null)
            {
                _db.DemandArchiveErss.Remove(item);
                await _db.SaveChangesAsync();
            }
           
            return RedirectToAction("Index");
        }


        [RequestSizeLimit(1_000_000_000)]
        [HttpPost]
        public async Task<IActionResult> Add_files(IFormFileCollection File_col)
        {
            Files_path.Clear();
            files_names.Clear();
            files_size.Clear();
            //LOAD FROM CONFIG.TXT
            DemandArchiveErs DAE=new DemandArchiveErs();

            string path_Root = _appEnvironment.WebRootPath;
            StreamReader objReader = new StreamReader(path_Root+"/Config.txt");
            string line;
            line = objReader.ReadLine();
            char ch = '=';
            int index = line.IndexOf(ch);
            if (Int32.TryParse(line.Substring(index + 1), out int j)){
                DAE.WorkstationsNr = j;
            }
            else
            {
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
                return Content("Wrong sim");
            }


            _db.DemandArchiveErss.Add(DAE);
            await _db.SaveChangesAsync();



            if ((File_col == null) || (File_col.Count == 0))  {return Content("Files are not selected");}

            foreach (var file in File_col)

            {
                FilesDemandArchiveErs FDE = new FilesDemandArchiveErs();
                files_names.Add(file.FileName);



                //string path_Root = _appEnvironment.WebRootPath;
                string path_to_file = path_Root + "//Files//" + file.FileName;
                Files_path.Add(path_to_file);
                FDE.PathFileName = path_to_file;
                
                //FDE.DemandArchiveErsNr=
                FileStream fstream = null;
                try
                { 
                     fstream = new FileStream(path_to_file, FileMode.OpenOrCreate);
                     await file.CopyToAsync(fstream);
                     }
                     catch (Exception ex)
                            {

                            }
                            finally
                            {
                                 if (fstream != null){fstream.Close();}

                            }


                FDE.DemandArchiveErsNr = DAE.DemandArchiveErsNr;
                _db.FilesDemandArchiveErss.Add(FDE);
                //ViewData["Id"] = DAE.DemandArchiveErsNr;
                await _db.SaveChangesAsync();


            }
           



          
           
            return RedirectToAction("Index");
            //return Content(DAE.DemandArchiveErsNr.ToString());

        }

        public async Task<IActionResult> Add(string WKT_string)
        {
            //string w = "POLYGON((-71.1776585052917 42.3902909739571, -71.1776820268866 42.3903701743239,-71.1776063012595 42.3903825660754, -71.1775826583081 42.3903033653531, -71.1776585052917 42.3902909739571))";
            Cmr_Id = "";

            var connString = "Host=localhost;Database=i;Username=postgres;Password=0-0-0-";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();


                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    //cmd.CommandText = "INSERT INTO data.cmr(cmr_ident,cmr_name, geom) VALUES ('2', 'lol', ST_GeomFromText('LINESTRING(-71.160281 42.258729,-71.160837 42.259113,-71.161144 42.25932)'));";
                    // cmd.Parameters.AddWithValue("p", "{0}, {1}, ST_GeomFromText({2},4326)");
                    cmd.CommandText = "INSERT INTO data.cmr(cmr_ident,cmr_name, geom) VALUES ('2', 'now', ST_GeomFromText('" + WKT_string + "',4326)) RETURNING cmr_id;";
                    //cmd.ExecuteReader();
                    Cmr_Id = Convert.ToString(cmd.ExecuteScalar());

                }
                conn.Close();

            }
            var i = 0;
            if (Files_path.Count() == 0)
            {
                return Content("список пуст");
            }
            foreach (var path in Files_path)
            {
                FilesCmr filesCmr = new FilesCmr();
                filesCmr.CmrId = Convert.ToInt32(Cmr_Id);
            filesCmr.RootDir = path;
            filesCmr.FileName = files_names[i++];
            _db.FilesCmrs.Add(filesCmr);
            await _db.SaveChangesAsync();
            }

            return RedirectToAction("Ramka");
        }









        public FileController(IHostingEnvironment appEnviroment, iContext context)
        {
            _appEnvironment = appEnviroment;
            _db = context;
        }



    }  
}