using ApiService.Interfaces;
using System.Net.Http;
using Utilities.Interfaces;

namespace ApiService.Implementations
{
    public class FileService:IFileService
    {
        private readonly IApiService _apiService;
        private readonly IFileHelper _fileHelper;
        private readonly HttpClient _httpClient = new HttpClient();

        public FileService(IApiService apiService, IFileHelper fileHelper)
        {
            _apiService = apiService;
            _fileHelper = fileHelper;
        }

        public void SaveFile(byte[] data, string fileName)
        {
            var response = _apiService.PostAsync(_fileHelper.Compress(data,fileName), "upload");
        }
        public async Task DeleteFile(string filePath)
        {
            await _apiService.DeleteAsync($"delete/{filePath}");
        }
        public async Task<byte[]> GetFileDecompress(string fileId)
        {
            var pdfBytes = await _apiService.GetAsyncByte($"download/{fileId}");
            return _fileHelper.Decompress(pdfBytes);
        }
        public async Task<byte[]> GetFile(string fileId)
        {
            var pdfBytes = await _apiService.GetAsyncByte($"download/{fileId}");
            return pdfBytes;
        }

    }
}
