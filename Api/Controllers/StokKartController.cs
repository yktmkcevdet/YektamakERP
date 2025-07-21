using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    public class StokKartController:Controller
	{
        private readonly Business.IDataAccessLayer _dataAccessLayer;

        public StokKartController(Business.IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpPost,Route("api/GetStokKart")]
		public string GetStokKartFilter([FromBody] StokKart restData)
		{
            string result = _dataAccessLayer.GetObject(restData, "spGetStokKart");
            return result;
		}
        [HttpPost, Route("api/GetStokKartPdf")]
        public string GetStokKartPdf([FromBody] StokKart restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetStokKartPdf");
            return result;
        }
        [HttpPost, Route("api/SaveStokKart")]
		public string SaveStokKart([FromBody] StokKart restData)
		{
            string result = _dataAccessLayer.SaveObject(restData, "spSaveStokKart");
            return result;
		}
        [HttpPost, Route("api/DeleteStokKart")]
        public string DeleteStokKart([FromBody] StokKart restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteStokKart");
            return result;
        }
        [HttpPost, Route("api/DeleteStokKartDosya")]
        public string DeleteStokKartDosya([FromBody] StokKartDosya restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteStokKartDosya");
            return result;
        }
        [HttpPost, Route("api/SaveStokKartHammadde")]
        public string SaveStokKartHammadde([FromBody] StokKart restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveStokKartHammadde");
            return result;
        }
        [HttpPost,Route("api/GetMalzeme")]
		public string GetMalzeme([FromBody] Malzeme restData)
		{
            string result = _dataAccessLayer.GetObject(restData, "spGetMalzeme");
            return result;
		}
		[HttpPost, Route("api/SaveMalzeme")]
		public string SaveMalzeme([FromBody] Malzeme restData)
		{
            string result = _dataAccessLayer.SaveObject(restData, "spSaveMalzeme");
            return result;
		}
        [HttpPost, Route("api/GetStokGrup")]
        public string GetStokGrup([FromBody] StokGrup restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetStokGrup");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeGrup")]
        public string GetMalzemeGrup([FromBody] MalzemeGrup restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetMalzemeGrup");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeAltGrup2")]
        public string GetMalzemeAltGrup2([FromBody] MalzemeAltGrup2 restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetMalzemeAltGrup2");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeAltGrup")]
        public string GetMalzemeAltGrup([FromBody] MalzemeAltGrup restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetMalzemeAltGrup");
            return result;
        }
        [HttpPost, Route("api/DeleteProjeDosya")]
        public string DeleteProjeDosya([FromBody] Proje restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteProjeDosya");
            return result;
        }
        
        [HttpPost, Route("api/GetStokTip")]
        public string GetStokTip([FromBody] StokTip restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetStokTip");
            return result;
        }
        [HttpPost, Route("api/GetProfilTip")]
        public string GetProfilTip([FromBody] ProfilTip restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetProfilTip");
            return result;
        }
        [HttpPost, Route("api/GetOlcuBirim")]
        public string GetOlcuBirim([FromBody] OlcuBirim restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetOlcuBirim");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeStandart")]
        public string GetMalzemeStandart([FromBody] MalzemeStandart restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetMalzemeStandart");
            return result;
        }
        [HttpGet, Route("api/GetStokGrupKriter")]
        public string GetStokGrupKriter()
        {
            string result = _dataAccessLayer.GetObject("spGetStokGrupKriter");
            return result;
        }
        [HttpGet, Route("api/GetExcelGrupParametre")]
        public string GetExcelGrupParametre()
        {
            string result = _dataAccessLayer.GetObject("spGetExcelGrupParametre");
            return result;
        }
    }
}
