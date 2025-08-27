using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface ISatinalmaTeklifService
    {
        public Task<string> SaveSatinalmaTeklif(SatinalmaTeklifBaslik satinalmaTeklifBasliks);
        public Task<string> GetSatinalmaTeklif(SatinalmaTeklifBaslik satinalmaTeklifBaslik);
        public Task<string> DeleteSatinalmaTeklif(SatinalmaTeklifBaslik satinalmaTeklifBaslik);
        public Task<string> SaveSatinalmaSiparis(SatinalmaTeklifBaslik satinalmaTeklifBaslik);
    }
}
