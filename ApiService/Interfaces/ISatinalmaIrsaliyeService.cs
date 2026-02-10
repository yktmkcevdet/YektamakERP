using Models.Models.Satinalma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface ISatinalmaIrsaliyeService
    {
        public Task<string> SaveSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik); 
    }
}
