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
using Microsoft.Extensions.Configuration;

namespace Geoportal.Services
{
    public class Save_Files : ISave_Files
    {
        readonly IHostingEnvironment _appEnvironment;
        private readonly IConfiguration _configuration;
        private string file_name;
        private string path_to_file;
        private long file_size;
        private iContext _db;
        long? _filesDemandArchiveErsNr;
        long _demandArchiveErsNr;
        public string FilesDemandArchiveErsNr { get; private set; }
        
        public Save_Files(IHostingEnvironment appEnvironment, iContext context, IConfiguration configuration)
        {
            //environment variable to get wwwroot location
            _appEnvironment = appEnvironment;
            //context of db
            _db = context;
            //configuration from appsettings.json
            _configuration = configuration;
           

        }
        //Save files and get atrributes
        public async Task<List<FilesCmr>> Save_files(IFormFileCollection file_collection,string _user_name)
        {
            //list of data that will be needed to add a shape in future
            List<FilesCmr> files_cmr = new List<FilesCmr>();
            //Package of files atrributes
            //read from appsettings.json
            DemandArchiveErs DAE = new DemandArchiveErs()
            {
                WorkstationsNr =Int32.Parse( _configuration["WorkstationsNr"]),
                RegionTypesNr= Int32.Parse(_configuration["RegionTypesNr"]),
                ConfirmDeleteAfterArchive= Int32.Parse(_configuration["ConfirmDeleteAfterArchive"])

            };
            //add Package of files atrributes to the database
            _demandArchiveErsNr = await Save_Package_atrributes(DAE);
            //get current date and time to get an uniq name
            string name_date = DateTime.Now.ToString("_dd_MM_yyyy_(hh_mm_ss)");
            
            //creating uniq folder's name depends on date+time
            string path_to_directory = Path.Combine(_appEnvironment.WebRootPath, Path.Combine(_user_name,name_date));
            //create directory with uniq name
            if (!Directory.Exists(path_to_directory))
            {
                Directory.CreateDirectory(path_to_directory);

            }
            //working with IFormFileCollection
            foreach (var file in file_collection)
            {
                //get file's name
                file_name = Path.GetFileName(file.FileName);
                //get file's files path
                path_to_file = Path.Combine(path_to_directory, file_name);
               
                try
                {
                    //save file
                    FileStream fstream = new FileStream(path_to_file, FileMode.Create);
                    await file.CopyToAsync(fstream);
                }
                catch (IOException ioException)
                {
                    //need to make some exception
                    
                }
                //find file's size
                file_size = new System.IO.FileInfo(path_to_file).Length;
               //fill file's atrributes
                FilesDemandArchiveErs FDE = new FilesDemandArchiveErs()
                {
                    FileSizeInBytes = file_size,
                    PathFileName = path_to_file,
                    DemandArchiveErsNr=_demandArchiveErsNr
                };
                //save file's atrributes in the database
                _filesDemandArchiveErsNr = await Save_File_atrributes(FDE);
                FilesCmr filesCmr = new FilesCmr()
                {

                    RootDir = path_to_directory,
                    FileName = file_name,
                    FileSize = file_size.ToString(),
                    FilesDemandArchiveNr = _filesDemandArchiveErsNr,
                    DemandArchiveErsNr = _demandArchiveErsNr,
                    DateSendDemand = DateTime.Now.Date
                    

                };
                
                files_cmr.Add(filesCmr);

            }
            //return data that will be needed to add a shape in future
            return files_cmr.ToList();
        }
        //Save_Package_atrributes to the database
        //return ID of package
        public async Task<long> Save_Package_atrributes(DemandArchiveErs DAE)
        {
            _db.DemandArchiveErss.Add(DAE);
            await _db.SaveChangesAsync();
            return DAE.DemandArchiveErsNr;
            
        }
        //Save_File_atrributes to the database
        //return ID of file
        public async Task<long> Save_File_atrributes(FilesDemandArchiveErs FDE)
        {
            _db.FilesDemandArchiveErss.Add(FDE);
            await _db.SaveChangesAsync();
            return FDE.FilesDemandArchiveErsNr;
        }
    }
}
