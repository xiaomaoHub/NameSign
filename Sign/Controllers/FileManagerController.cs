using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sign.Contract;
using Sign.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sign.Controllers
{
    [Route("FileManager")]
    public class FileManagerController
    {
        private readonly IFileManagerService _service;
        public FileManagerController(IFileManagerService service) 
        {
            _service = service;
        }

        [HttpPost]
        [Route("UploadFiles")]
        public async Task<ResponseBase> UploadFiles(IFormFile file)
        {
            return await _service.UploadFiles(file);
        }
    }
}
