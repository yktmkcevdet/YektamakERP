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
    }
}
