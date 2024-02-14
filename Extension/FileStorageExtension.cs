using UploadFileProject.Services.Interfaces;
using UploadFileProject.Services;
using System.Reflection.Metadata.Ecma335;

namespace UploadFileProject.Extension
{
    public static class FileStorageExtension
    {
        public static IServiceCollection AddFileLocalStorage( this IServiceCollection services)
        {
            services.AddScoped<IFileStorageService, LocalFileStorageService>();
            return services;
        }
   
    }
}
