using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface IAnaVeriService
    {
        public Task<string> SaveMaliyetUnsur(MaliyetUnsur maliyetUnsur);
        public Task<string> SaveMaliyetTespitKanal(MaliyetTespitKanal maliyetTespitKanal);
        public string GetMaliyetUnsur();
        public string GetMaliyetTespitKanal();
        public string GetDosyaTip();
    }
}
