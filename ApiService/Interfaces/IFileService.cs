using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface IFileService
    {
        public void SaveFile(MultipartFormDataContent file);
        public Task<byte[]> GetFile(string fileId);
    }
}
