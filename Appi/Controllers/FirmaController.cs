using Appi.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Appi.Controllers.GeneralMethods;
namespace Appi.Controllers
{
    public class FirmaController:Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public FirmaController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        [HttpPost, Route("api/SaveFirma")]
        public string SaveFirma([FromBody] string firma)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<Firma>(firma), "spSaveFirma");
            return result;
        }
        [HttpPost, Route("api/GetFirma")]
        public string GetFirma([FromBody] string firma)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Firma>(firma), "spGetFirma");
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
