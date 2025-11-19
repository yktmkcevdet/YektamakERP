using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Interfaces
{
    public interface IFileHelper
    {
        public byte[] Decompress(byte[] compressedData);
        public MultipartFormDataContent Compress(byte[] data, string fileName);
    }
}
