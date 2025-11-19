using ApiService.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace ApiService.Implementations
{
    public class FileService:IFileService
    {
        private readonly IApiService _apiService;

        public FileService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public void SaveFile(MultipartFormDataContent file)
        {
            var response = _apiService.PostAsync(file, "upload");
        }
        public async Task<byte[]> GetFile(string fileId)
        {
            var pdfBytes = await _apiService.GetAsyncByte($"download/{fileId}");
            return pdfBytes;
        }
    }
}
