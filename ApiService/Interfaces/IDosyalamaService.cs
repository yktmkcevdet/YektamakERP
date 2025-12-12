using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface IDosyalamaService
    {
        public Task CreateOrderFile(List<ProjeStokKart> projeStokKartList,string path=null);
    }
}
