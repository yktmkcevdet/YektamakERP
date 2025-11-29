namespace Utilities.Interfaces
{
    public interface IFileHelper
    {
        public byte[] Decompress(byte[] compressedData);
        public MultipartFormDataContent Compress(byte[] data, string fileName);
        public Task<byte[]> ReadFileAsBinaryAsync(string filePath);
    }
}
