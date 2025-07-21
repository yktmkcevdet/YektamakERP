using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    public class PersonelService : IPersonelService
    {
        private readonly IApiService _apiService;
        public PersonelService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public string GetPersonel(Personel personel)
        {
            return _apiService.Post(personel, "GetPersonel");
        }
        public string GetPozisyon(Pozisyon pozisyon)
        {
            return _apiService.Post(pozisyon, "GetPozisyon");
        }
        public async Task<string> SavePersonel(Personel personel)
        {
            return await _apiService.PostAsync(personel, "SavePersonel");
        }
        public async Task<string> SavePersonelResim(PersonelResim personelResim)
        {
            return await _apiService.PostAsync(personelResim, "SavePersonelResim");
        }
        public async Task<string> DeletePersonel(Personel personel)
        {
            return await _apiService.PostAsync(personel, "DeletePersonel");
        }
    }
}
