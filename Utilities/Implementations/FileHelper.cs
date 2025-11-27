using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class FileHelper:IFileHelper
    {
        public byte[] Decompress(byte[] compressedData)
        {
            using (var input = new MemoryStream(compressedData))
            using (var gzip = new GZipStream(input, CompressionMode.Decompress))
            using (var output = new MemoryStream())
            {
                gzip.CopyTo(output);
                return output.ToArray();
            }
        }
        public MultipartFormDataContent Compress(byte[] data,string fileName)
        {
            MultipartFormDataContent content = new MultipartFormDataContent();
            using (var output = new MemoryStream())
            {
                using (var gzip = new GZipStream(output, CompressionMode.Compress))
                {
                    gzip.Write(data, 0, data.Length);
                }
                content.Add(new ByteArrayContent(output.ToArray()), "file", fileName);
                return content;
            }
        }
        public async Task<byte[]> ReadFileAsBinaryAsync(string filePath)
        {
            try
            {
                return await File.ReadAllBytesAsync(filePath);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
