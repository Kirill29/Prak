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
//using Microsoft.AspNetCore.Http.Internal;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geoportal.Controllers
{

    public class FileController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        // GET: /<controller>/
        private iContext _db;

        public JsonResult UploadFile(IList<IFormFile> files)
        {
            return Json(new { state = 0, message = string.Empty });
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var d = _db.DemandArchiveErss.ToList();
            var m = d[d.Count - 1];
            ViewData["ID"] = m.DemandArchiveErsNr;

            //Linq измение данных -выкидывает строчку в начало
            //var t = (from p in _db.DemandArchiveErss
            //         where p.DemandArchiveErsNr == 83576
            //         select p).FirstOrDefault();
            //t.Status = 3333333;



            _db.SaveChanges();
            //return View();

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
        public async Task<IActionResult> Create( IFormFileCollection File_col)
        {
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














            if ((File_col == null) || (File_col.Count == 0))  {return Content("Files are not selected");}

            foreach (var file in File_col)
            {

                //string path_Root = _appEnvironment.WebRootPath;
                string path_to_Images = path_Root + "//Files//" + file.FileName;
                FileStream fstream = null;
                try
                { 
                     fstream = new FileStream(path_to_Images, FileMode.OpenOrCreate);
                     await file.CopyToAsync(fstream);
                     }
                     catch (Exception ex)
                            {

                            }
                            finally
                            {
                                 if (fstream != null){fstream.Close();}

                            }


            }



            _db.DemandArchiveErss.Add(DAE);
            ViewData["Id"] = DAE.DemandArchiveErsNr;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }


        public FileController(IHostingEnvironment appEnviroment, iContext context)
        {
            _appEnvironment = appEnviroment;
            _db = context;
        }












        //    //Загрузка файлов
        //    [HttpPost]
        //    public async Task<IActionResult> Upload_File(IFormFileCollection File_col)
        //    {

        //        foreach (var file in File_col)
        //        {
        //            if ((file == null) || (file.Length == 0)) return Content("File is not selected");
        //            string path_Root = _appEnvironment.WebRootPath;
        //            string path_to_Images = path_Root + "//Files//" + file.FileName;
        //            //string path_to_Images = "Macintosh HD// Users // kirill // shared";
        //            //try
        //            //{
        //            //List<IFormFile> fl = new List<IFormFile>();
        //            using (var stream = new FileStream(path_to_Images, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //                //stream.Dispose();

        //            }

        //            //}
        //            //catch (Exception ex)
        //            //{
        //            //  return Content(ex.Message);
        //            //}
        //        //    FileStream fstream = null;
        //        //    try
        //        //    {
        //        //        fstream = new FileStream(path_to_Images, FileMode.OpenOrCreate);
        //        //        // операции с потоком
        //        //    }
        //        //    catch (Exception ex)
        //        //    {

        //        //    }
        //        //    finally
        //        //    {
        //        //        if (fstream != null)
        //        //            fstream.Close();
        //        //            Content("Файлы прочитаны");
        //        //    }

        //        }



        //        // ViewData["FilePath"] = path_to_Images;
        //        return RedirectToAction("Create");


        //    }



        //}


    }  
}