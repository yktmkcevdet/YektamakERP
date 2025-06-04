using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;

namespace Api.Controllers
{
    public class StokKartController
	{
        private readonly Business.IDataAccessLayer _dataAccessLayer;

        public StokKartController(Business.IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpPost,Route("api/GetStokKart")]
		public string GetStokKartFilter([FromBody] string restData)
		{
            string result = _dataAccessLayer.GetObject(JsonStringToModel<StokKart>(restData), "spGetStokKart");
            return result;
		}
        [HttpPost, Route("api/GetStokKartPdf")]
        public string GetStokKartPdf([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<StokKart>(restData), "spGetStokKartPdf");
            return result;
        }
        [HttpPost, Route("api/SaveStokKart")]
		public string SaveStokKart([FromBody] string restData)
		{
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<StokKart>(restData), "spSaveStokKart");
            return result;
		}
        [HttpPost, Route("api/DeleteStokKart")]
        public string DeleteStokKart([FromBody] string restData)
        {
            string result = _dataAccessLayer.DeleteObject(JsonStringToModel<StokKart>(restData), "spDeleteStokKart");
            return result;
        }
        [HttpPost, Route("api/SaveStokKartHammadde")]
        public string SaveStokKartHammadde([FromBody] string restData)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<StokKart>(restData), "spSaveStokKartHammadde");
            return result;
        }
        [HttpPost,Route("api/GetMalzeme")]
		public string GetMalzeme([FromBody] string restData)
		{
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Malzeme>(restData), "spGetMalzeme");
            return result;
		}
		[HttpPost, Route("api/SaveMalzeme")]
		public string SaveMalzeme([FromBody] string restData)
		{
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<Malzeme>(restData), "spSaveMalzeme");
            return result;
		}
        [HttpPost, Route("api/GetStokGrup")]
        public string GetStokGrup([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<StokGrup>(restData), "spGetStokGrup");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeGrup")]
        public string GetMalzemeGrup([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<MalzemeGrup>(restData), "spGetMalzemeGrup");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeAltGrup2")]
        public string GetMalzemeAltGrup2([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<MalzemeAltGrup2>(restData), "spGetMalzemeAltGrup2");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeAltGrup")]
        public string GetMalzemeAltGrup([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<MalzemeAltGrup>(restData), "spGetMalzemeAltGrup");
            return result;
        }
        [HttpPost, Route("api/DeleteProjeDosya")]
        public string DeleteProjeDosya([FromBody] string restData)
        {
            string result = _dataAccessLayer.DeleteObject(JsonStringToModel<Proje>(restData), "spDeleteProjeDosya");
            return result;
        }
        
        [HttpPost, Route("api/GetStokTip")]
        public string GetStokTip([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<StokTip>(restData), "spGetStokTip");
            return result;
        }
        [HttpPost, Route("api/GetProfilTip")]
        public string GetProfilTip([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<ProfilTip>(restData), "spGetProfilTip");
            return result;
        }
        [HttpPost, Route("api/GetOlcuBirim")]
        public string GetOlcuBirim([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<OlcuBirim>(restData), "spGetOlcuBirim");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeStandart")]
        public string GetMalzemeStandart([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<MalzemeStandart>(restData), "spGetMalzemeStandart");
            return result;
        }
    }
}
