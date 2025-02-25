using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace ApiService.Interfaces
{
    public interface ISatisService
    {
        public Task<List<MondayTeklif>> GetMondayTeklif();
        public Task<string> DeleteSatisSiparisTeklifTalep(string siparisTeklifTalep);
    }
}
