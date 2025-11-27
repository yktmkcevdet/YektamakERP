using ApiService.Interfaces;
using Utilities.Interfaces;

namespace ApiService.Implementations
{
    public class FileService:IFileService
    {
        private readonly IApiService _apiService;
        private readonly IFileHelper _fileHelper;

        public FileService(IApiService apiService, IFileHelper fileHelper)
        {
            _apiService = apiService;
            _fileHelper = fileHelper;
        }

        public void SaveFile(byte[] data, string fileName)
        {
            var response = _apiService.PostAsync(_fileHelper.Compress(data,fileName), "upload");
        }
        public async Task<byte[]> GetFile(string fileId)
        {
            var pdfBytes = await _apiService.GetAsyncByte($"download/{fileId}");
            return _fileHelper.Decompress(pdfBytes);
        }
    }
}
