using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;
namespace Api.Controllers
{
    public class FirmaController:Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public FirmaController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        [HttpPost, Route("api/SaveFirma")]
        public string SaveFirma([FromBody] Firma firma)
        {
            string result = _dataAccessLayer.SaveObject(firma, "spSaveFirma");
            return result;
        }
        [HttpPost, Route("api/GetFirma")]
        public string GetFirma([FromBody] Firma firma)
        {
            string result = _dataAccessLayer.GetObject(firma, "spGetFirma");
            return result;
        }
        [HttpGet, Route("api/GetFirma")]
        public string GetFirma()
        {
            string result = _dataAccessLayer.GetObject("spGetFirma");
            return result;
        }
    }
}
