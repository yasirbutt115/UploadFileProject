using UploadFileProject.Services.Interfaces;

namespace UploadFileProject.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        async Task<byte[]> IFileStorageService.DownloadingFile(string filePath, string fileName)
        {

            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("File Path not exist");
          
            var fileUploadingPath = Path.Combine(filePath, fileName);

            if(!File.Exists(fileUploadingPath)) throw new ArgumentException("File not exist on path " + filePath + " with file name" + fileName);
            return await File.ReadAllBytesAsync(fileUploadingPath);
        }

        async Task<string> IFileStorageService.UploadingFile(string filePath, IFormFile file)
        {
            

            if(string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Invalid file Path");

            }
            else
            {
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                var fileUploadingPath = Path.Combine(filePath, filename);

                using (var filestream = new FileStream(fileUploadingPath,FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
                return fileUploadingPath;

            }


        }
    }
}
