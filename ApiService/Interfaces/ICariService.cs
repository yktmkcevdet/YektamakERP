using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface ICariService
    {
        public Task<string> GetCariHesapEkstresi(CariKart cariKart);  
    }
}
