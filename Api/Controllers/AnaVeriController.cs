using Api.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;
using Api.Business;
using static Api.Controllers.GeneralMethods;
using Models.Models;

namespace Api.Controllers
{
    public class AnaVeriController : Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public AnaVeriController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpGet, Route("api/GetParcaGrupList/")]
        public string GetParcaGrupList()
        {
            string result = _dataAccessLayer.GetObject("spGetParcaGrupList");
            return result;
        }
        [HttpGet, Route("api/GetParcaAltGrupList/")]
        public string GetParcaAltGrupList()
        {
            string result = _dataAccessLayer.GetObject("spGetParcaAltGrupList");
            return result;
        }
        [HttpGet, Route("api/GetReferansKaynak/")]
        public string GetReferansKaynak()
        {
            string result = _dataAccessLayer.GetObject("spGetReferansKaynak");
            return result;
        }

        [HttpGet, Route("api/GetMaliyetUnsur/")]
        public string GetMarka()
        {
            return _dataAccessLayer.GetObject("spGetMaliyetUnsur");
        }
        [HttpGet, Route("api/GetMaliyetTespitKanal")]
        public string GetMaliyetTespitKanal()
        {
            return _dataAccessLayer.GetObject("spGetMaliyetTespitKanal");
        }
        [HttpPost, Route("api/SaveMaliyetUnsur")]
        public string SaveMaliyetUnsur([FromBody]string restData)
        {
            return _dataAccessLayer.SaveObject(JsonStringToModel<MaliyetUnsur>(restData), "spSaveMaliyetUnsur");
        }
        [HttpPost, Route("api/SaveMaliyetTespitKanal")]
        public string SaveMaliyetTespitKanal([FromBody] string restData)
        {
            return _dataAccessLayer.SaveObject(JsonStringToModel<MaliyetTespitKanal>(restData), "spSaveMaliyetTespitKanal");
        }
        [HttpGet, Route("api/GetDosyaTip")]
        public string GetDosyaTip()
        {
            return _dataAccessLayer.GetObject("spGetDosyaTip");
        }
        [HttpPost, Route("api/SaveExcelForm")]
        public string SaveExcelForm([FromBody] string restData)
        {
            return _dataAccessLayer.SaveObject(JsonStringToModel<ExcelForm>(restData), "spSaveExcelForm");
        }
        
        [HttpPost, Route("api/GetExcelForm")]
        public string GetExcelForm([FromBody] ExcelForm excelForm)
        {
            try
            {
                return _dataAccessLayer.GetObject(excelForm, "spGetExcelForm");
            }
            catch (Exception ex)
            {
                throw new Exception($"Excel formu alınırken hata oluştu: {ex.Message}");
            }
        }
    }
}
