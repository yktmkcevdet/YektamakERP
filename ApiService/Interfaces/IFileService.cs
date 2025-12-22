namespace ApiService.Interfaces
{
    public interface IFileService
    {
        public void SaveFile(byte[] data, string fileName);
        public Task<byte[]> GetFileDecompress(string fileId);
        public Task<byte[]> GetFile(string fileId);
    }
}
