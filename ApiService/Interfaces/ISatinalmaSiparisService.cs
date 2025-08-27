using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface ISatinalmaSiparisService
    {
        public Task<string> GetSatinalmaSiparisAsync(SatinalmaSiparis satinalmaSiparis);
        public Task<string> SaveSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis);
    }
}
