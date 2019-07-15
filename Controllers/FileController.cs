using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Geoportal.Services;
using Geoportal.file_streaming;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Geoportal.Services.Logging;


namespace Geoportal.Controllers
{
    //контроллер для пересылки файлов и получения,а затем сохранения аттрибутов файлов
    public class FileController : Controller
    {
        private readonly ILogger_custom _logger;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IConfiguration _configuration;
        //database context
        private iContext _db;
        static List<FilesCmr> filesCmrs = new List<FilesCmr>();
        static public string Cmr_Id { get; set; }
    
        [Authorize]
        public IActionResult Index()
        {

            return View(filesCmrs);
        }


        [Authorize]
        public IActionResult Send()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        [DisableFormValueModelBinding]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            filesCmrs.Clear();
            long _demandArchiveErsNr;
            try
            {
                DemandArchiveErs DAE = new DemandArchiveErs()
                {
                    WorkstationsNr = Int32.Parse(_configuration["WorkstationsNr"]),
                    RegionTypesNr = Int32.Parse(_configuration["RegionTypesNr"]),
                    ConfirmDeleteAfterArchive = Int32.Parse(_configuration["ConfirmDeleteAfterArchive"])

                };

                //сохраняем аттрибуты пакета файлов
                _demandArchiveErsNr = await Save_Package_atrributes(DAE);
              
            }
            catch(Exception ex)
            {
                _logger.LogFatal(ex, "Error while saving data in demandArchiveErs");
                return Content("Error while saving data in demandArchiveErs");

            }
            _logger.LogInfo($"Package atrributes were saved in demandArchiveErs,ID : {_demandArchiveErsNr}");
            FormValueProvider formModel;
            string name_date = DateTime.Now.ToString("_dd_MM_yyyy_(hh_mm_ss)");

           
            string path_to_directory = Path.Combine(_appEnvironment.WebRootPath, Path.Combine(AccountController.Current_user, name_date));
            //string path_to_directory = Path.Combine("D:", Path.Combine(AccountController.Current_user, name_date));
            //создаем директорию с уникальным именем(папка, заданая в appsettings.json,+имя пользователя+дата время)
            if (!Directory.Exists(path_to_directory))
            {
                Directory.CreateDirectory(path_to_directory);

            }
            _logger.LogInfo($"Crate directory {path_to_directory}");
            string path = (path_to_directory);
            string path1 = Path.Combine(path_to_directory, Path.GetRandomFileName());
          
            using (var stream = System.IO.File.Create(path1))
            {
                formModel = await Request.StreamFile(stream, path);

            }

            var viewModel = new MyViewModel();
          

            var bindingSuccessful = await TryUpdateModelAsync(viewModel, prefix: "",
               valueProvider: formModel);

            if (!bindingSuccessful)
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Error has happend in file_sending");
                    return BadRequest(ModelState);
                }
            }
            long? file_size;
            long? _filesDemandArchiveErsNr;
            try
            {
                for (var i = 0; i <FileStreamingHelper.file_name.Count-1; i++)
                {

                    file_size = new System.IO.FileInfo(Path.Combine(path, FileStreamingHelper.file_name[i])).Length;
                    FilesDemandArchiveErs FDE = new FilesDemandArchiveErs()
                    {
                        FileSizeInBytes = file_size,
                        PathFileName = path,
                        DemandArchiveErsNr = _demandArchiveErsNr
                    };
                    //сохраняем атрибуты файлов
                    _filesDemandArchiveErsNr = await Save_File_atrributes(FDE);
                    FilesCmr filesCmr = new FilesCmr()
                    {

                        RootDir = path,
                        FileName = FileStreamingHelper.file_name[i],
                        FileSize = file_size.ToString(),
                        FilesDemandArchiveNr = _filesDemandArchiveErsNr,
                        DemandArchiveErsNr = _demandArchiveErsNr,
                        DateSendDemand = DateTime.Now.Date


                    };

                    filesCmrs.Add(filesCmr);
                }
            }
            catch(Exception ex)
            {
                _logger.LogFatal(ex, "Error while saving data in filesDemandArchiveErs");
                return Content(ex.Message);
            }

            _logger.LogInfo("All file's attributes were saved");
          
            return RedirectToAction("Index","File");




        }



        public async Task<IActionResult> Save_filescmr(int Cmr_id, string Switch_shape)
        {
            try
            {
                //сохраняем атрибуты файлов, полученные в методе Upload, в таблицу files_cmr
                foreach (var file_cmr in filesCmrs)
                {
                    file_cmr.CmrId = Cmr_id;
                    _db.FilesCmrs.Add(file_cmr);
                    await _db.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                _logger.LogFatal(ex, "Error while saving files' attributes in files_cmr");
            }
            _logger.LogInfo("Files' attributes were saved in files_cmr");
            //перенапрявляем пользователя на страницу успешного добавления рамки
            switch (Switch_shape)
            {
                case "WKT":
                    
                    return RedirectToAction("Ramka_Added_WKT", "Ramka", new { cmr_Id = Cmr_id });

                case "SHP":
                   
                    return RedirectToAction("Ramka_Added_SHP", "Ramka", new { cmr_Id = Cmr_id });

                case "Draw":

                    return RedirectToAction("Ramka_Added_Draw", "Ramka", new { cmr_Id = Cmr_id });

                default:
                    _logger.LogInfo("Error in saving shape");
                    return Content("Error in saving shape");
            }

        }



        public FileController(IHostingEnvironment appEnviroment, iContext context, ISave_Files save_Files, IConfiguration configuration, ILogger_custom logger)
        {
            _logger = logger;
            _appEnvironment = appEnviroment;
            _db = context;
            _configuration = configuration;
           
        }



        //сохраняем аттрибуты пакета файлов в таблицу DemandArchiveErs
        //возвращает ID записи
        public async Task<long> Save_Package_atrributes(DemandArchiveErs DAE)
        {
            _db.DemandArchiveErss.Add(DAE);
            await _db.SaveChangesAsync();
            return DAE.DemandArchiveErsNr;

        }
        //сохраняем аттрибуты файлов в таблицу FilesDemandArchiveErs
        //возвращает ID записи
        public async Task<long> Save_File_atrributes(FilesDemandArchiveErs FDE)
        {
            _db.FilesDemandArchiveErss.Add(FDE);
            await _db.SaveChangesAsync();
            return FDE.FilesDemandArchiveErsNr;
        }
    }
}