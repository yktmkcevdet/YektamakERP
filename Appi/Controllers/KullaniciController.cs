using Appi.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using static Appi.Controllers.GeneralMethods;

namespace Appi.Controllers
{
    public class KullaniciController:Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public KullaniciController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpPost, Route("api/SaveKullanici")]
        public string SaveKullanici([FromBody] Kullanici restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveKullanici");
            return result;
		}
        
        [HttpPost, Route("api/GetKullanici")]
        public string GetKullanici([FromBody] Kullanici restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetKullanici");
            return result;
		}
        [HttpPost, Route("api/GetRol")]
        public string GetRol([FromBody] Kullanici restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetRol");
            return result;
        }
        [HttpGet, Route("api/GetKullanici/{username}")]
        public string GetUser(string username)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.ad = username;
            string result = _dataAccessLayer.GetObject(kullanici,"spGetKullanici");
            return result;
        }

        [HttpPost, Route("api/GetKullaniciYetki")]
        public string GetKullaniciYetki([FromBody] Kullanici restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetKullaniciYetki");
            return result;
		}

        [HttpPost, Route("api/SaveEkran")]
        public string SaveEkran([FromBody] Ekran restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveEkran");
            return result;
		}

        [HttpPost, Route("api/SaveYetki")]
        public string SaveYetki([FromBody] Yetki restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveYetki");
            return result;
		}
        [HttpPost, Route("api/SaveAlanYetki")]
        public string SaveAlanYetki([FromBody] AlanYetkiDTO restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveAlanYetki");
            return result;
        }
        [HttpPost, Route("api/DeleteAlanYetki")]
        public string DeleteAlanYetki([FromBody] AlanYetki restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteAlanYetki");
            return result;
        }
        [HttpPost, Route("api/DeleteEkran")]
        public string DeleteEkran([FromBody] Ekran restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteEkran");
            return result;
		}
        [HttpPost, Route("api/GetAnaMenu")]
        public string GetAnaMenu([FromBody] AnaMenuDTO restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetAnaMenu");
            return result;
        }
        [HttpPost, Route("api/GetYetki")]
        public string GetYetki([FromBody] Yetki restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetYetki");
            return result;
        }
        [HttpPost, Route("api/GetMenu")]
        public string GetMenu([FromBody] Menu restData)
        {
            string result = _dataAccessLayer.GetObject(restData,"spGetMenu");
            return result;
        }
        [HttpPost,Route("api/SaveMenu")]
        public string SaveMenu([FromBody] Menu restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveMenu");
            return result;
        }
        [HttpPost, Route("api/DeleteMenu")]
        public string DeleteMenu([FromBody] Menu restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteMenu");
            return result;
        }
        [HttpPost, Route("api/GetAlanYetki")]
        public string GetAlanYetki([FromBody] AlanYetkiDTO restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetAlanYetki");
            return result;
        }
    }
}
