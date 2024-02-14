namespace UploadFileProject.Services.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> UploadingFile(string filePath, IFormFile file);
        Task<byte[]> DownloadingFile(string filePath, string fileName);
    }
}
