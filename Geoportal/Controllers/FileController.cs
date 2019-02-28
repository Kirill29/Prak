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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //попытка вывода всех имен файлов в данном каталоге
            //выводит только имя  последнего файла
            //var webRoot = _appEnvironment.WebRootPath;
            //var appData = System.IO.Path.Combine(webRoot, "Files/");
            //FileModel file = new FileModel();
            //IEnumerable <string> models = Directory.EnumerateFiles(appData);
            //foreach(string item in models)
            //{
            //    file.Name = item;
            //}
            //ViewData["FilePath"] = file.Name;

            //return View();

            return View(await _db.DemandArchiveErss.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DemandArchiveErs DAE)
        {
            _db.DemandArchiveErss.Add(DAE);
            ViewData["Id"] = DAE.DemandArchiveErsNr;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
           
        }

        public FileController(IHostingEnvironment appEnviroment,iContext context)
        {
            _appEnvironment = appEnviroment;
            _db = context;
        }
        //Загрузка файлов
        [HttpPost]
        public async Task<IActionResult> Upload_File(IFormFileCollection File_col)
        {

            foreach (var file in File_col)
            {
                if ((file == null) || (file.Length == 0)) return Content("File is not selected");
                string path_Root = _appEnvironment.WebRootPath;
                string path_to_Images = path_Root + "//Files//" + file.FileName;
                //string path_to_Images = "Macintosh HD// Users // kirill // shared";
                //try
                //{
                    //List<IFormFile> fl = new List<IFormFile>();
                    using (var stream = new FileStream(path_to_Images, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        //stream.Dispose();

                    }

                //}
                //catch (Exception ex)
                //{
                  //  return Content(ex.Message);
                //}

            }



            // ViewData["FilePath"] = path_to_Images;
            return RedirectToAction("Create");


        }



    }

}
