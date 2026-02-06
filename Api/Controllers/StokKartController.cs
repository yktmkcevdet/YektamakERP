using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    public class StokKartController:Controller
	{
        private readonly Business.IDataAccessLayer _dataAccessLayer;
        private readonly Business.IStokService _stokService;

        public StokKartController(Business.IDataAccessLayer dataAccessLayer, Business.IStokService stokService)
        {
            _dataAccessLayer = dataAccessLayer;
            _stokService = stokService;
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
        [HttpPost, Route("api/SaveStokKartDosya")]
        public async Task<string> SaveStokKartDosya([FromBody] StokKartDosya restData)
        {
            string result = await _stokService.SaveStokKartDosya(restData);
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
        [HttpPost, Route("api/SaveStokGrup")]
        public string SaveStokGrup([FromBody] StokGrup restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveStokGrup");
            return result;
        }
        [HttpPost, Route("api/DeleteStokGrup")]
        public string DeleteStokGrup([FromBody] StokGrup restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteStokGrup");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeGrup")]
        public string GetMalzemeGrup([FromBody] MalzemeGrup restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetMalzemeGrup");
            return result;
        }
        [HttpPost, Route("api/SaveMalzemeGrup")]
        public string SaveMalzemeGrup([FromBody] MalzemeGrup restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveMalzemeGrup");
            return result;
        }
        [HttpPost, Route("api/DeleteMalzemeGrup")]
        public string DeleteMalzemeGrup([FromBody] MalzemeGrup restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteMalzemeGrup");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeAltGrup2")]
        public string GetMalzemeAltGrup2([FromBody] MalzemeAltGrup2 restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetMalzemeAltGrup2");
            return result;
        }
        [HttpPost, Route("api/SaveMalzemeAltGrup2")]
        public string SaveMalzemeAltGrup2([FromBody] MalzemeAltGrup2 restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveMalzemeAltGrup2");
            return result;
        }
        [HttpPost, Route("api/DeleteMalzemeAltGrup2")]
        public string DeleteMalzemeAltGrup2([FromBody] MalzemeAltGrup2 restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteMalzemeAltGrup2");
            return result;
        }
        [HttpPost, Route("api/GetMalzemeAltGrup")]
        public string GetMalzemeAltGrup([FromBody] MalzemeAltGrup restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetMalzemeAltGrup");
            return result;
        }
        [HttpPost, Route("api/SaveMalzemeAltGrup")]
        public string SaveMalzemeAltGrup([FromBody] MalzemeAltGrup restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSaveMalzemeAltGrup");
            return result;
        }
        [HttpPost, Route("api/DeleteMalzemeAltGrup")]
        public string DeleteMalzemeAltGrup([FromBody] MalzemeAltGrup restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeleteMalzemeAltGrup");
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
        [HttpPost, Route("api/GetExcelGrupParametre")]
        public string GetExcelGrupParametre([FromBody] ExcelGrupParametre excelGrupParametre)
        {
            string result = _dataAccessLayer.GetObject(excelGrupParametre,"spGetExcelGrupParametre");
            return result;
        }
        [HttpPost, Route("api/SaveExcelGrupParametre")]
        public string SaveExcelGrupParametre([FromBody] ExcelGrupParametre excelGrupParametre)
        {
            string result = _dataAccessLayer.SaveObject(excelGrupParametre,"spSaveExcelGrupParametre");
            return result;
        }
        [HttpPost, Route("api/DeleteExcelGrupParametre")]
        public string DeleteExcelGrupParametre([FromBody] ExcelGrupParametre excelGrupParametre)
        {
            string result = _dataAccessLayer.DeleteObject(excelGrupParametre, "spDeleteExcelGrupParametre");
            return result;
        }
    }
}
