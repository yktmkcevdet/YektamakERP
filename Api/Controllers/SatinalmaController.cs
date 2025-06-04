using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;
namespace Api.Controllers
{
    public class SatinalmaController : Controller
    {
        private readonly IDataAccessLayer _dataAccesLayer;

        public SatinalmaController(IDataAccessLayer dataAccesLayer)
        {
            _dataAccesLayer = dataAccesLayer;
        }

        [HttpPost, Route("api/SaveSatinalmaTalep")]
        public string SaveSatinalmaTalep([FromBody] string restData)
        {
            string result = _dataAccesLayer.SaveObject(JsonStringToModel<SatinalmaTalep>(restData), "spSaveSatinalmaTalep");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaTalepSatirDetay")]
        public string GetSatinalmaTalepSatirDetay([FromBody] string restData)
        {
            string result = _dataAccesLayer.GetObject(JsonStringToModel<SatinalmaTalepSatirDetay>(restData), "spGetSatinalmaTalepSatirDetay");
            return result;
        }
    }
}
