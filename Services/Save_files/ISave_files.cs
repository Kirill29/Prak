using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geoportal.Models;

namespace Geoportal.Services
{
     public  interface ISave_Files
    {
        //send files to server and get file attributes
        Task<List<FilesCmr>> Save_files(IFormFileCollection file_collection,string user_name);
        //save  package file's attributes in db
        Task<long> Save_Package_atrributes(DemandArchiveErs DAE);
        //save files attributes in db
        Task<long> Save_File_atrributes(FilesDemandArchiveErs FDE);

    }
}
