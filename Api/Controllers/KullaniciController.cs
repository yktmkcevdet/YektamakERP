using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using static Api.Controllers.GeneralMethods;

namespace Api.Controllers
{
    [ApiController]
    public class KullaniciController
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public KullaniciController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpPost, Route("api/SaveKullanici")]
        public string SaveKullanici([FromBody] string restData)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<Models.Kullanici>(restData), "spSaveKullanici");
            return result;
		}
        
        [HttpPost, Route("api/GetKullanici")]
        public string GetKullanici([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Models.Kullanici>(restData), "spGetKullanici");
            return result;
		}
        [HttpPost, Route("api/GetRol")]
        public string GetRol([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Models.Kullanici>(restData), "spGetRol");
            return result;
        }
        [HttpGet, Route("api/GetKullanici/{username}")]
        public string GetUser(string username)
        {
            Models.Kullanici kullanici = new Models.Kullanici();
            kullanici.ad = username;
            string result = _dataAccessLayer.GetObject(kullanici,"spGetKullanici");
            return result;
        }

        [HttpPost, Route("api/GetKullaniciYetki")]
        public string GetKullaniciYetki([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Models.Kullanici>(restData), "spGetKullaniciYetki");
            return result;
		}

        [HttpPost, Route("api/SaveEkran")]
        public string SaveEkran([FromBody] string restData)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<Ekran>(restData), "spSaveEkran");
            return result;
		}

        [HttpPost, Route("api/SaveYetki")]
        public string SaveYetki([FromBody] string restData)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<Yetki>(restData), "spSaveYetki");
            return result;
		}
        [HttpPost, Route("api/SaveAlanYetki")]
        public string SaveAlanYetki([FromBody] string restData)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<Models.DTO.AlanYetkiDTO>(restData), "spSaveAlanYetki");
            return result;
        }
        [HttpPost, Route("api/DeleteEkran")]
        public string DeleteEkran([FromBody] string restData)
        {
            string result = _dataAccessLayer.DeleteObject(JsonStringToModel<Ekran>(restData), "spDeleteEkran");
            return result;
		}
        [HttpPost, Route("api/GetAnaMenu")]
        public string GetAnaMenu([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<AnaMenuDTO>(restData), "spGetAnaMenu");
            return result;
        }
        [HttpPost, Route("api/GetYetki")]
        public string GetYetki([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Yetki>(restData), "spGetYetki");
            return result;
        }
        [HttpPost, Route("api/GetMenu")]
        public string GetMenu([FromBody]string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Menu>(restData),"spGetMenu");
            return result;
        }
        [HttpPost,Route("api/SaveMenu")]
        public string SaveMenu([FromBody] string restData)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<Menu>(restData), "spSaveMenu");
            return result;
        }
        [HttpPost, Route("api/DeleteMenu")]
        public string DeleteMenu([FromBody] string restData)
        {
            string result = _dataAccessLayer.DeleteObject(JsonStringToModel<Menu>(restData), "spDeleteMenu");
            return result;
        }
        [HttpPost, Route("api/GetAlanYetki")]
        public string GetAlanYetki([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Models.DTO.AlanYetkiDTO>(restData), "spGetAlanYetki");
            return result;
        }
    }
}
