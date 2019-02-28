using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Geoportal.Models;
//using Microsoft.AspNetCore.Http.Internal;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geoportal.Controllers
{

    public class FileController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        // GET: /<controller>/
       
        [HttpGet]
        public IActionResult Upload_Image()
        {
            var webRoot = _appEnvironment.WebRootPath;
            var appData = System.IO.Path.Combine(webRoot, "Files/");
            FileModel file = new FileModel();
            IEnumerable <string> models = Directory.EnumerateFiles(appData);
            foreach(string item in models)
            {
                file.Name = item;
            }
            ViewData["FilePath"] = file.Name;
            return View();
        }
        public FileController(IHostingEnvironment appEnviroment)
        {
            _appEnvironment = appEnviroment;
        }
        [HttpPost]
        public async Task<IActionResult> Upload_Image(IFormFileCollection File_col)
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
            return RedirectToAction("Upload_Image");


        }



    }

}
