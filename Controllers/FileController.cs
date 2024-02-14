using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFileProject.Services.Interfaces;

namespace UploadFileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private readonly IFileStorageService _fileStorageService;

        public FileController(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        // default limit of file is 30 MB to upload big file more than 30 MB used DisableRequestSizeLimit annotation
        [HttpPost("uploadFile"), DisableRequestSizeLimit]
       // [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile( IFormFile file)
        {
            string filePath = "FileStorage";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            if (!Directory.Exists(folderPath)) { 
                 Directory.CreateDirectory(folderPath);
            }
         

            await _fileStorageService.UploadingFile(folderPath, file);

            return Ok("File Uploaded Successfully");

        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> DownloadFile( string fileName)
        {
           
            string filePath = "FileStorage";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            var fileBytes = await _fileStorageService.DownloadingFile(folderPath, fileName);

            if (fileBytes == null || fileBytes.Length == 0)
            {
                return NotFound();
            }

            return File(fileBytes, "application/octet-stream", fileName);
        }
    }
}

