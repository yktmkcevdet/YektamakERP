using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Models;

namespace ApiService.Interfaces
{
    public interface ISatisService
    {
        public string GetReferansKaynak();
        public Task<List<MondayTeklif>> GetMondayTeklif();
        public Task<string> DeleteSatisSiparisTeklifTalep(string siparisTeklifTalep);
        public string GetSatisTeklifTalep(SatisTeklifTalep satisTeklifTalep);
        public Task<string> SaveSatisSiparisTeklifTalep(SatisTeklifTalep satisTeklifTalep);
    }
}
